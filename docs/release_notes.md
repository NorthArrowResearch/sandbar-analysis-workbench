---
title: Release Notes
nav_order: 5
layout: default
---

# Release Notes

### 2.0.0 - 6 Feb 2024

* New [Campsite Analysis](/Technical_Reference/sandbar_analysis_intro.html#7-campsite-analysis).
* Ability to [run any of the three analyses](/Online_Help/Sandbar_Analysis/sandbar_analysis_run.html) (incremental, binned or campsite) separately.
* Ability to reuse rasters to speed up processing.
* Maximum sandbar surface created and used to calculate max volume and area (by subtracting the minimum surface).
* Multiple [stage discharges](/Online_Help/Sandbars/sd_sample.html) per sandbar site.
* Ability to [import trip data from CSV](/Online_Help/Views/Managing-Reference-Information.html#import-trip).
* Discontinued the centralized MySQL database. The workbench now uses a single, standalone SQLite database.
* Sandbar Python script updated to Python3 and uses PEP8 coding standards.
* Sandbar Workbench upgraded to .NetFramework 4.6.2.

### 1.0.13 - 9 Nov 2017

* Fixing mis-alignment chart bars when displaying binned sandbar analysis results.
* Implementing data series color management for incremental sandbar analysis.

### 1.0.12 - 9 Aug 2017

* Fixed model result syncing by omitting fields in binned results that are not present on master database.
* Syncing model results now checks master database credentials before attempting to sync.
* Implemented create database feature, as well as the database upgrade pattern.

### 1.0.11 - 1 Aug 2017

* Fixed survey properties not updating properly.

### 1.0.10 - 1 Aug 2017

* Fixed bug in survey properties form related to ID/Value property in combo box loading.

### 1.0.9 - 28 Jul 2017

* Options form changes
    * new test connection feature
    * Options form now available when no database is open.
* Creating new database now works using DDL shipped with the workbench.
* Fixed editing remote camera setup so that the correct item is updated.

### 1.0.8 - 30 Jun 2017

* Several user interface cleanup items such as
	* tab order
	* form titles
	* online help hookup
* Implementing high performance master database sync for sandbar analysis results
* Better capturing of Python return code
* Fix to data synchronization process

### 1.0.7 - 10 Jan 2017

* Miscellaneous user interface improvements
	* Tool tips
	* Online help linkages
	* F1 launches help
* Stage discharge
	* Samples added to database and plots
	* Manually calculated stage discharge data series added to plots
	* Controls for editing stage discharge coefficients now use exponents to help user edit very small values.
* *Double CRUD* implemented that saves updates to the master and local databases simultaneously without the need for a full synchronization.
* Developers can override installation GUID
* Date time now appears in local time zone instead of UTC.
* User can edit the display color for analysis bins
* Data grid exporting to CSV.
* Database version 4.

### 1.0.6 - 12 Dec 2016

* Sandbar Analysis Plots
	* Fixed bug in the way the binned analysis was being summed for display.
	* Ability to filter by analysis bin.
	* Moved controls for discharge.
	* Binned analysis x axis labels.

### 1.0.5 - 12 Dec 2016

* Sandbar Analysis Plots
	* Implemented binned analysis plots
	* Area and volume plots now side-by-side
* Exporting data grids to CSV
* Stage discharge export to CSV

### 1.0.4 - 9 Dec 2016

* Sandbar Analysis Configuration
	* Sorting dates correctly in date picker.
	* Removed proof of concept output messages on console window.
	* Model analysis folder name now uses 24 hour clock.
* Data GridView cells now read only by default
* Photo background worker doesn't fail on multiple calls.
* Stage discharge plot titles with formula
* Catching foreign key constraint when deleting sandbar sites
* All multi-line text boxes capture return key.

### 1.0.3 - 2 Dec 2016

* Remote Camera Thumbail Loading Optimizations
	* Implemented the picture thumbnail viewer using a background worker.
	* Only searching the first 100 files in a folder
	* If a thumbnail is found during a search, then the code looks directly for the full and web res of the same file name instead of performing 2 more searches.
* Changed the user name for the DB login.
* Implemented check for updates on the main form help menu
