---
title: Raster Interpolation
layout: default
parent: Technical Reference
nav_order: 3
---

# Raster Interpolation

***NB: There is currently a bug to do with raster interpolations methods. The following will only apply after this bug has been fixed.***

There are 4 resampling methods available to the user in the sandbar analysis:

* `linear`: tesselate the input point set to n-dimensional simplices, and interpolate linearly on each simplex.
* `cubic`: return the value determined from a piecewise cubic, continuously differentiable (C1), and approximately curvature-minimizing polynomial surface.
* `nearest`: return the value at the data point closest to the point of interpolation. 
* `bilinear`: perform linear interpolation first in one direction, and then again in the other direction. Although each step is linear in the sampled values and in the position, the interpolation as a whole is not linear but rather quadratic in the sample location.

## Different Methods

`linear`, `cubic`, and  `nearest` use those same methods directly from the [scipy.interpolate.griddata](https://docs.scipy.org/doc/scipy-0.18.1/reference/generated/scipy.interpolate.griddata.html) in the Scipy module. `Bilinear` is an interpretation of a well-known [bilinear interpolation algorithm](https://en.wikipedia.org/wiki/Bilinear_interpolation). The implications of this are that `linear`, `cubic` and `nearest` are optimized, fast and well-supported whereas `bilinear` uses a much less optimized approach and is slower.  

## Using different methods

Making use of interpolation is relatively easy and takes two parts:

1. Change `<ResampleMethod>` to the method you choose.
2. Change `<RasterCellSize>` to be different from `<CSVCellSize>`. This will indicate to the software that resampling needs to happen.

See Below:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<SandbarAnalysis>
  <MetaData>
    <Meta Name="date">2016-11-22T11:22:55.5653730-08:00</Meta>
    <Meta Name="system">MATTYMATT</Meta>
    <Meta Name="user">matt</Meta>
    <Meta Name="version">1</Meta>
  </MetaData>
  <Outputs>
    <Log>log.xml</Log>
    <BinnedResults>results_binned.csv</BinnedResults>
    <IncrementalResults>results_incremental.csv</IncrementalResults>
  </Outputs>
  <Inputs>    
    <TopLevelFolder>c:\Sandbars\Topo_Data\corgrids</TopLevelFolder>
 	<CompExtentShpPath>c:\Topo_Data\corgrids\ComputationExtents.shp</CompExtentShpPath>
 	<srsEPSG>PROJCS["NAD_1983_2011_StatePlane_Arizona_Central_FIPS_0202",...</srsEPSG>
    <GDALWarp>/usr/local/bin/gdalwarp</GDALWarp>
    <CSVCellSize>1</CSVCellSize>
    <RasterCellSize>1</RasterCellSize>
    <ElevationIncrement>0.1</ElevationIncrement>
    <ElevationBenchmark>8000</ElevationBenchmark>
    <ResampleMethod>bilinear</ResampleMethod>
    <ReUseRasters>False</ReUseRasters>
    ...
```

