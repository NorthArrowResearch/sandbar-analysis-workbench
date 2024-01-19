---
title: Python Configuration
layout: default
parent: Sandbar Analysis
grand_parent: Online Help
nav_order: 3
---

# Python Environment Configuration

The sandbar analysis code is written in [Python](https://www.python.org/) script that uses several third party libraries, most notably the [GDAL](http://www.gdal.org/) open source GIS software. When the workbench launches the sandbar analysis script it's extremely important that the Python environment is correctly configured so that each of these libraries can be referenced correctly.

The following is a list of commands that need to be executed on the local computer immediately prior to the sandbar analysis to ensure that the Python environment is configured correctly:

## QGIS

If you have QGIS installed, use this code block, adjusting the first line to point to the location of your QGIS installation.

```bash
set QGIS_ROOT="C:\Program Files\QGIS 3.22.11"
call %QGIS_ROOT%\OSGeo4W.bat
set PATH=%PATH%;%QGIS_ROOT%\bin
set PYTHONPATH=%PYTHONPATH%;%QGIS_ROOT%\bin
set PYTHONPATH=%PYTHONPATH%;%QGIS_ROOT%\apps\Python39\Lib\site-packages
set QGIS_PREFIX_PATH=%QGIS_ROOT%\apps\qgis
```

## OSGeo

If you have OSGeo installed use this code block.

```bash
set OSGEO4W_ROOT=C:\\OSGeo4W64
call C:\OSGeo4W64\bin\o4w_env.bat
set PATH=%PATH%;%OSGEO4W_ROOT%\apps\qgis\bin
set PYTHONPATH=%PYTHONPATH%;%OSGEO4W_ROOT%\apps\qgis\python
set PYTHONPATH=%PYTHONPATH%;%OSGEO4W_ROOT%\apps\Python27\Lib\site-packages
set QGIS_PREFIX_PATH=%OSGEO4W_ROOT%\apps\qgis
```

These commands should appear in the `Python` tab of the `Options` window under the `Tools` menu in the workbench. Note **the local OSGeo installation path** on the first line should be verified and changed to whatever it is on the local computer.

![python environment](/images/python_environment.png)
