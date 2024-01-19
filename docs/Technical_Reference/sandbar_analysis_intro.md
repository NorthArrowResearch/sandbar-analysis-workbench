---
title: Analysis Methodology
layout: default
parent: Technical Reference
nav_order: 3
---

# Sandbar Analysis Methodology

The sandbar analysis processes sandbar survey data and calculates the area and volume of sand exposed at various discharges. The current version of this analysis takes elevations at point locations and interpolates rasters from these points. The rasters are then sliced at elevations that correspond to river discharges and reports the area and volume of sand exposed. This new version was developed by North Arrow Research and replaces an earlier methodology developed by GCMRC that produced the same results by analyzing TIN surfaces.

The new sandbar analysis actually performs two different, but subtly different types of analysis. Both types of analysis are performed every time the sandbar analysis is run.

* **Incremental Analysis** - takes an analysis elevation at the lowest point of all historical surveys and then raises this elevation at 10cm increments. At each increment the area and volume of sand is exposed *above* the specified elevation.
* **Binned Analysis** - takes user specified upper and lower discharges and calculates the area and volume *between* the elevations that correspond with these two discharges. 

## Sandbar Process Overview

Each time that the sandbar process is run the following high level steps are performed:

### 1. Read Input File

When you [configure a sandbar analysis run](/Online_Help/Sandbar_Analysis/sandbar_analysis_run.html) in the Workbench the options that you choose are actually written to an XML file on your computer. This input file is then passed to the sandbar analysis Python script. The input specifies all the parameters that the analysis needs as well as the paths to the input point grid text files etc.

There are several reasons for this approach, but one beneficial byproduct is that users comfortable running Python scripts manually can take one of these input files, hand edit it for their own specific needs, and then run the modified input file directly. This enables batch processing etc.

The end result of reading the input file is that the code is aware of the file paths to all the point text files and which surveys should be processed.

### 2. Read Computational Extents ShapeFile
The computational extents polygon ShapeFile is loaded and the script verifies that every site and section set to be processed also possesses a corresponding feature in this ShapeFile.

## 3. Prepare Rasters

The script loops over each survey at each sandbar site and creates a raster from the point elevation text file. If the specified raster resolution is the same as the spacing of the text file points then no interpolation is used. Each raster cell is centered on each corresponding point. If the two resolutions don't match then the user's choice of [interpolation method](./interpolation_methods) is used to generate the rasters.

The outermost extent that covers all surveys is used as the extent for all rasters at a site. In other words, small or partial surveys are generated as the same extent as large, all encompassing surveys, but will contain `NoData` in the places where the survey didn't occur.

## 4. Minimum Surface

During the preparation of rasters, the script also calculates the minimum value of each pixel and saves this as the minimum surface. This raster possesses an elevation value wherever at least one survey has a value. The minimum surface raster is created with the same outermost spatial extent as all the individual survey rasters.

## 5. Incremental Analysis

The incremental analysis is performed on a site by site basis. The process starts by identifying the elevation that corresponds to the 8,000 CFS discharge using the site-specific [stage discharge coefficients](/Online_Help/Sandbars/sd_sample.html). The elevation at 8,000 CFS is then converted to a *minimum analysis elevation* using the following formula:

```
minAnalysisStage = benchmarkStage - ceil((benchmarkStage - minSurveyElevation) / analysisIncrement) * analysisIncrement
```

Where the `benchmarkStage` is the elevation at 8,000 CFS and the `minSurveyElevation` is the lowest elevation across all surveys being analysed. The `analysisIncrement` is the vertical spacing of the incremental analysis, typically 0.1m.

The incremental analysis proceeds by looping over every survey and processing it separately. For each survey the code starts at the minimum analysis elevation and starts moving upwards in increments of 0.1m. At each elevation the area of cells with elevations greater than the current elevation are counted and the sum of the values of these cells is added to produce the volume.

These areas and volumes for each site, survey and elevation are kept in memory and then written to a CSV file when the processing has finished. A log file is also created summarizing script progress and any warnings or errors.

## 6. Binned Analysis

The binned analysis is somewhat simpler than the incremental analysis. The same loop is performed over each site and survey, but instead of incrementally raising an analysis elevation, this process looks at sand in predefined bins. The user [defines the bins in the Workbench](/Online_Help/Views/Managing-Reference-Information.html#analysis-bins) ahead of time. The Workbench ships with three bins defined:

* Up to 8,000 CFS
* Between 8,000 and 25,000 CFS
* Above 25,000 CFS.

The analysis measures the area and volume of sand in each bin, excluding the minimum surface. The resultant areas and volumes are written to a CSV text file next to that of the incremental analysis. 

## Video Demonstration

The following video demonstration walks through the input and output files produced by the sandbar analysis. It describes the folder and file structure used and how to interpret the results.

<iframe width="100%" height="500" src="https://www.youtube.com/embed/iVCHKBjzblQ?si=3bCgCKY34A4" title="YouTube video player" frameborder="0" allowfullscreen></iframe>