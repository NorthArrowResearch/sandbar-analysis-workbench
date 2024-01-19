---
title: Configuring Sandbar Analysis Script
layout: default
parent: Sandbar Analysis
grand_parent: Online Help
nav_order: 5
---

# Configuring Sandbar Analysis Script

The sandbar analysis is structured as a separate Python script and not directly built into the workbench. This makes it possible - albeit with a little effort and know-how - to run the sandbar analysis as a standalone script. The following instructions describes how to obtain the sandbar analysis Python script and configure it to run from within the workbench. Instructions for running the sandbar analysis as a standalone script are at the bottom of this page.

## OSGeo

Go and get it from the [QGIS download site](http://www.qgis.org/en/site/forusers/download.html) (It's underneath the Standalone installers). You want 64-bit if you can:

Make sure to select `Advanced install` with the following packages turned on:

* `Desktop -> qgis`: QGIS Desktop
* `Libs -> python-scipy` (needed for sandbar analysis)
* `Libs -> qt4-devel` (needed for lrelease/translations)
* `Libs -> setuptools` (needed for installing pip)

Then continue. It will ask you about a whole bunch of dependencies to select the above packages. Agree to that then agree to everything else and do the install.

## Sandbar Analysis script

The sandbar analysis script is stored on GitHub as its own open source repository at:

```
https://github.com/NorthArrowResearch/sandbar-analysis-python
```

You should clone or download the entire repository to your computer. Cloning it is preferable if you have [git](https://git-scm.com) and are familiar with how to do so. That way any *ad hoc* changes or bug fixes that you make are easily incorporated. Download it if you don't use git or simply want to quickly get up and running. You can put the sandbar analysis code anywhere on your system. It is recommended that the folder does not have any spaces in the path.

## Workbench Python Environment

See the workbench [python environment configuration](/Online_Help/Sandbar_Analysis/python_configuration.html) page and ensure that the path to your OSGeo folder is specified correctly.

## Raw Topo Data Grid Files

You need the raw point text files for each of the sandbar surveys that you want to use in the analysis. These should accessible from your computer (network locations are OK) preferably in a folder path that does not contain any spaces. The files must be formatted as follows:

* Plain text
* Values separate by spaces
* No header row
* Columns of data in the following, mandatory, order:
  * Point identifier (not used by code)
  * Easting ([Stateplane Arizona Central FIPS 0202](http://www.spatialreference.org/ref/sr-org/nad832011-state-plane-arizona-central-fips-0202/))
  * Northing ([Stateplane Arizona Central FIPS 0202](http://www.spatialreference.org/ref/sr-org/nad832011-state-plane-arizona-central-fips-0202/))
  * Elevation (meters)

An example of the first few lines from one such file (`corgrids\001Rcorgrids\1_050507_grid.txt`):

```
5000 241055.000 649332.000 921.677
5001 241056.000 649332.000 921.376
5002 241052.000 649333.000 922.469
5003 241053.000 649333.000 922.314
5004 241054.000 649333.000 922.140
5005 241055.000 649333.000 921.863
5006 241056.000 649333.000 921.554
...
```

Ensure that the path to these files is specified in the workbench [Options](/Online_Help/Tools_Menu/Options.html) under the `Sandbar Analysis` tab. The mandatory folder structure for the point files under this folder is:

```
<folder_specified_in_options>\<site_code>corgrids\<site_code_brief>YYMMDD_grid.txt
```

Where

* `<site_code>` refers to either the four or five digit site code in full.
* `<site_code_brief>` refers to the site code without any zero padding or bank code.
* `YYMMDD` refers to two year digit year, zero padded two digit month and zero padded two digit day of the survey date.

## Computational Extents ShapeFile

You must have a [computational extents ShapeFile](/Online_Help/Sandbar_Analysis/computational_extents.html) that meets the requirements described on the separate page. It can be stored on a network drive, but must be accessible from the local computer, and the path specified in the [Options](/Online_Help/Tools_Menu/Options.html) form under the `Sandbar Analysis` tab.

## Running the Sandbar Analysis Within the Workbench

Once you have completed all the steps above, you are ready to [run the sandbar analysis](sandbar_analysis_run)!

## Running the Sandbar Analysis Standalone

The easiest way to run the sandbar analysis as a standalone Python script is to perform the process once from *within* the Workbench. This will generate an input.xml file that contains all the parameters required by the Python script. You can then edit this input XML file manually to satisfy your needs and then run the Python script at the command using this altered file. In more detail the steps are:

1. Complete all the steps described above on this page to ensure that your Python enivronment is correctly configured and that you have access to the necessary data.
2. Follow the steps on the [running the sandbar analysis](sandbar_analysis_run) page once. If you know the sandbar sites that you want to run manually, then you can save some work by ensuring that you make this the site selection that you use when running the analysis from within the Workbench. Don't worry, you can change the sites and surveys later. **Before you run** the sandbar analysis make note of the output folder where the Workbench will write results.
3. When the Workbench has finished running the analysis (or sooner if you don't intend to use this run and simply want to get to the command line), navigate to the results folder and copy the `input.xml` file.
4. Create a new folder for your manual, standalone run of the sandbar analysis and copy the `input.xml` file into this folder.
5. Open a command   