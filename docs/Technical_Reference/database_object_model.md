---
title: Database Object Model
---

The GCMRC Workbench relies on two databases. The first is a [SQLite](https://www.sqlite.org) database that is installed on each user's computer that has the Workbench installed. This is the database that the Workbench software interacts with directly and is the only database that users need to run the software. It contains all the lookup information required to run the sandbar analysis, as well as the results of any sandbar analysis model runs that an individual users has performed.

A centralized copy of lookup data (e.g. sandbar sites and photo setup attributes) is stored on a single, centralized [MySQL](https://www.mysql.com) database. Individual users can synchronize their local SQLite databases to ensure that they have the latest information, using features within the Workbench software. Users also have the option of sharing their sandbar analysis model results with other users by synchronizing them with this central MySQL database. 

The structure of both databases is described below. You should also refer to the [General Design Principles](#general-design-principles) section at the bottom of this page.

## SQLite Database

![sqlite](https://docs.google.com/drawings/d/1j4YH-dOJF8j0VbCeKtsEVVfdSehb7HRlwq90S8O6czc/pub?w=1532&h=1210)

## VersionDBTables

Describes each table in the Workbench database.

| Field       | Info                | Description |
| ----------- | ------------------- | ----------- |
| TableName   | VARCHAR (50), NN    |             |
| **TableID** | INTEGER, NN, **PK** |             |
| Description | VARCHAR (1000)      |             |

## LookupListItems

This table contains the values for various types of reference information used by the Workbench. For example, each type of survey instrument (RTKGPS, Total Station etc) are stored in this table. Each item is associated with a different list via the `ListID` column that is defined in the `LookupLists` table.

| Field      | Info            | Description |
| ---------- | --------------- | ----------- |
| **ItemID** | INTEGER, **PK** |             |
| Title      | TEXT (50), NN   |             |
| ListID     | INTEGER, NN     |             |

## SandbarSites

Each record in this table represents a single sandbar site. This is the master location for defining the properties for each sandbar site.

| Field                | Info            | Description |
| -------------------- | --------------- | ----------- |
| CampsiteSurveyRecord | TEXT (50)       |             |
| PrimaryGDAWS         | INTEGER         |             |
| Title                | TEXT (50), NN   |             |
| StageDischargeA      | REAL            |             |
| StageDischargeC      | REAL            |             |
| StageDischargeB      | REAL            |             |
| Latitude             | REAL            |             |
| ReachID              | INTEGER         |             |
| SecondaryGDAWS       | INTEGER         |             |
| ExpansionRatio45k    | REAL            |             |
| InitialSurvey        | DATE            |             |
| Remarks              | VARCHAR (1000)  |             |
| History              | TEXT (50)       |             |
| RemoteCameraID       | INTEGER         |             |
| RiverSideID          | INTEGER, NN     |             |
| Longitude            | REAL            |             |
| StageChange8k45k     | REAL            |             |
| RiverMile            | REAL, NN        |             |
| SiteCode5            | TEXT (5), NN    |             |
| ExpansionRatio8k     | REAL            |             |
| SegmentID            | INTEGER         |             |
| AlternateTitle       | TEXT (50)       |             |
| SiteTypeID           | INTEGER, NN     |             |
| EddySize             | INTEGER         |             |
| Easting              | REAL            |             |
| **SiteID**           | INTEGER, **PK** |             |
| SiteCode             | TEXT (10)       |             |
| Northing             | REAL            |             |

## ModelRuns

There is one record in this table for each time that the sandbar analysis is run within the Workbench. The columns track who initiated the run and when it was performed. The actual results associated with the run are stored in the `ModelResultsIncremental` and `ModelResultsBinned` tables.

The ModelRuns table possesses several columns that track whether the model run and it's results are [synchronized to the centralized master MySQL database](http://gcmrc.northarrowresearch.com/online_help/sandbar_analysis/model_runs/#synchronization:9ef2682d4a59335f2aa5c3d2e9a7e6ed).

| Field            | Info            | Description |
| ---------------- | --------------- | ----------- |
| AnalysisFolder   | VARCHAR (256)   |             |
| RunTypeID        | INTEGER         |             |
| RunOn            | DATETIME, NN    |             |
| Title            | TEXT (50)       |             |
| InstallationGuid | VARCHAR (256)   |             |
| Sync             | BOOLEAN         |             |
| **LocalRunID**   | INTEGER, **PK** |             |
| Published        | BOOLEAN, NN     |             |
| Remarks          | VARCHAR (1000)  |             |
| RunBy            | VARCHAR (50)    |             |
| MasterRunID      | INTEGER         |             |
| InputXML         | VARCHAR (1000)  |             |

## LookupLists

This table defines the various types of reference information used by the Workbench (e.g. survey instruments, digital camera card types) . The individual values within each type of list are stored in the LookupListItems table and related using the ListID column.

| Field          | Info            | Description |
| -------------- | --------------- | ----------- |
| **ListID**     | INTEGER, **PK** |             |
| EditableByUser | BOOLEAN         |             |
| Title          | TEXT (50), NN   |             |

## RemoteCameras

There is one record in this table for each remote camera setup within the Grand Canyon. Setups are identified by several code fields:

- `SiteCode4` - the legacy 4 digit code (e.g. 003L)
- `SiteID` - the database ID of the corresponding sandbar site that the camera points at, or `Null` if the camera is not associated with a sandbar site.
- `SiteName` - Commonly used plain English name of the setup (e.g. *22-Mile*)
- `SiteCode` - An extension of `SiteCode4 that distinguishes when there are multiple remote camera setups at a single location (e.g. *0307Ra* and *0307Rb*).
- `NAUName` - the name assigned to the remote camera setup by North Arizona University.

| Field              | Info             | Description |
| ------------------ | ---------------- | ----------- |
| CurrentNPSPermit   | BOOLEAN, NN      |             |
| **CameraID**       | INTEGER, **PK**  |             |
| EndDigitalRecord   | VARCHAR (10)     |             |
| EndFilmRecord      | VARCHAR (10)     |             |
| CameraRiverBankID  | INTEGER, NN      |             |
| SiteName           | VARCHAR (50), NN |             |
| Remarks            | VARCHAR (1000)   |             |
| TheSubject         | VARCHAR (50)     |             |
| BeginDigitalRecord | VARCHAR (10)     |             |
| BeginFilmRecord    | VARCHAR (10)     |             |
| SiteID             | INTEGER          |             |
| SiteCode4          | VARCHAR (10)     |             |
| HavePhotos         | BOOLEAN          |             |
| BestPhotoTime      | VARCHAR (10)     |             |
| TheView            | VARCHAR (50)     |             |
| TargetRiverBankID  | INTEGER, NN      |             |
| RiverMile          | REAL, NN         |             |
| NAUName            | VARCHAR (10)     |             |
| CardTypeID         | INTEGER          |             |
| SiteCode           | VARCHAR (10), NN |             |

## SandbarSurveys

Each record in this table represents a single sandbar site. This is the master location for defining the properties for each sandbar site.

| Field        | Info            | Description |
| ------------ | --------------- | ----------- |
| TripID       | INTEGER, NN     |             |
| **SurveyID** | INTEGER, **PK** |             |
| SiteID       | INTEGER, NN     |             |
| SurveyDate   | DATE            |             |

## Reaches

GCMRC divides the Grand Canyon into several, high level reaches (e.g. Upper Glen Canyon, Lower Glen Canyon). There is one record in the `Reaches` table for each of these reaches, and although this information can be [managed via the Workbench](http://gcmrc.northarrowresearch.com/online_help/views/Managing-Reference-Information/), these data are not currently used by any analytical tools or other features.

| Field       | Info            | Description |
| ----------- | --------------- | ----------- |
| Title       | TEXT (50), NN   |             |
| **ReachID** | INTEGER, **PK** |             |
| ReachCode   | TEXT (10), NN   |             |

## Trips

There is one record in this table for each surveying river trip down the Grand Canyon. The trip date refers to the date on which the trip departed. Each `SandbarSurvey` is associated with a trip.

| Field      | Info            | Description |
| ---------- | --------------- | ----------- |
| **TripID** | INTEGER, **PK** |             |
| Remarks    | VARCHAR (1000)  |             |
| TripDate   | DATE, NN        |             |

## AnalysisBins

When the sandbar analysis script performs the binned analysis it uses the bins defined in the `AnalysisBins` table. Each record in this table represents a separate bin that is analysed. Bins are defined in terms of discharge. A bin can have a lower discharge, an upper discharge, or both. A bin must have at least one discharge defined. At the time of running the sandbar analysis, these discharges are converted to elevations using the stage discharge relationships at each sandbar site. The initial bins defined are for 8,000 and 25,000 CFS. Users can add as many bins as they want however.

| Field          | Info            | Description                              |
| -------------- | --------------- | ---------------------------------------- |
| **BinID**      | INTEGER, **PK** | Unique identifier of each analysis bin   |
| DisplayColor   | CHAR (6)        | The color used to display this bin in the Workbench sandbar analysis results viewer. |
| Title          | TEXT (50), NN   | Name of the analysis bin. Must be unique. |
| LowerDischarge | REAL            | Lower bound of the analysis bin in cubic feet per second. If this is NULL then the bin is considered to be *all sand up to this elevation*. |
| UpperDischarge | REAL            | Upper bound of the analysis bin in cubic feet per second. If this value is NULL then the bin considers *all sand above this elevation*. |
| IsActive       | BOOLEAN, NN     | The analysis bin is considered active when this column contains any value other than zero. Only active analysis bins are considered when running the sandbar analysis. |

## ModelResultsBinned

This table stores the results of the sandbar **binned** analysis. This is the process that looks at the area and volume of sand exposed in prescribed elevation zones, or bins. The bins themselves are defined in the `AnalysisBins` table. Each record in this table is associated with a particular model run via `ModelID` that identifies the date, time and operator that ran the sandbar analysis.

| Field     | Info        | Description |
| --------- | ----------- | ----------- |
| BinID     | INTEGER, NN |             |
| Area      | REAL, NN    |             |
| SectionID | INTEGER, NN |             |
| Area3D    | REAL        |             |
| Volume    | REAL        |             |
| RunID     | INTEGER, NN |             |

## VersionChangeLog

Captures information about structural changes to the Workbench database. This information is provided the developer as they alter the database structure during software development.

| Field        | Info           | Description |
| ------------ | -------------- | ----------- |
| DateOfChange | DATETIME, NN   |             |
| Version      | INTEGER, NN    |             |
| Description  | TEXT (255), NN |             |

## VersionDBColumns

Describes each column in each database table. The tables are identified by `TableID` that is keyed to the `VersionDBTables` table.

| Field        | Info                | Description |
| ------------ | ------------------- | ----------- |
| ColumnName   | VARCHAR (50), NN    |             |
| TableID      | INTEGER, NN         |             |
| **ColumnID** | INTEGER, NN, **PK** |             |
| Description  | VARCHAR (1000)      |             |

## ModelResultsIncremental

This table stores the results of the sandbar **incremental** analysis. This is the process that looks at the area and volume of sand exposed above a particular elevation. The analysis is performed on each survey at a series of incremental vertical elevations, starting just below the minimum elevation for each survey and increasing vertically until just above the maximum for each survey. The default vertical increment is 0.1m. Each record in this table is associated with a particular model run via `ModelID` that identifies the date, time and operator that ran the sandbar analysis.

| Field      | Info        | Description |
| ---------- | ----------- | ----------- |
| Elevation  | REAL, NN    |             |
| SectionID  | INTEGER, NN |             |
| Area       | REAL        |             |
| SurveyVol  | REAL        |             |
| MinVol     | REAL        |             |
| SurveyArea | REAL        |             |
| Volume     | REAL        |             |
| MinArea    | REAL        |             |
| RunID      | INTEGER, NN |             |

## SandbarSitePhotos

This table defines the best photo image for each sandbar site. The records in this table are used by the [sandbar web site](https://www.gcmrc.gov/sandbar/surveys/sites/) to display images alongside the properties for each sandbar. There should be one image for each sandbar site. Note that there is no user interface in the Workbench software for interacting with the information in this table.

| Field         | Info                | Description |
| ------------- | ------------------- | ----------- |
| **PhotoID**   | INTEGER, NN, **PK** |             |
| FlowDirection | VARCHAR (50)        |             |
| FileName      | VARCHAR (255), NN   |             |
| PhotoDay      | INTEGER             |             |
| SiteID        | INTEGER, NN         |             |
| PhotoMonth    | INTEGER             |             |
| PhotoFrom     | VARCHAR (50)        |             |
| PhotoYear     | INTEGER             |             |
| View          | VARCHAR (50)        |             |

## SandbarSections

There is one record in this table for each section of a sandbar site that was collected during a survey. There might be one or more records in this table for each survey depending on whether topography and/or bathymetry were collected during a survey, and also depending on whether the sandbar site is a single eddy or a separation/reattachment eddy site. `SectionTypeID` distinguishes what type of section each record pertains too. The `instrumentID` field identify the type of instrument used to collect the survey while the `Uncertainty` captures the error associated with the instrument.

| Field         | Info            | Description |
| ------------- | --------------- | ----------- |
| InstrumentID  | INTEGER         |             |
| Uncertainty   | REAL, NN        |             |
| **SectionID** | INTEGER, **PK** |             |
| SectionTypeID | INTEGER, NN     |             |
| SurveyID      | INTEGER, NN     |             |

## VersionInfo

Information about the Workbench database, including the current version and release date. This information should only be changed by the Workbench software developers.

| Field     | Info                  | Description |
| --------- | --------------------- | ----------- |
| ValueInfo | TEXT (255), NN        |             |
| **Key**   | TEXT (50), NN, **PK** |             |

## TableChangeLog

This table stores the date and time that each table in the Workbench database was last updated. Whenever the user changes values in one or more of the tables listed, the corresponding `UpdatedOn` value in `TableChangeLog` is updated with the current time stamp. This process is automatic, using [SQLite triggers](https://sqlite.org/lang_createtrigger.html) and does not require the user to do anything manually. Because the triggers are stored in the the database itself, they operate regardless of whether the information in the database is updated via the Workbench or directly using SQL.

These `UpdatedOn` dates and times are used by the Workbench to deduce which information in a user's local SQLite database are newer than that stored in the remote, master MySQL database. See the documentation on [synchronizing databases](http://gcmrc.northarrowresearch.com/online_help/tools_menu/synchronize) for how this works.

| Field         | Info                 | Description |
| ------------- | -------------------- | ----------- |
| **TableName** | VARCHAR (50), **PK** |             |

## Segments

Similar to `Reaches`, segments represent a specific section of the Grand Canyon. This information can be [managed via the Workbench](http://gcmrc.northarrowresearch.com/online_help/views/Managing-Reference-Information/), these data are not currently used by any analytical tools or other features.

| Field               | Info            | Description |
| ------------------- | --------------- | ----------- |
| SegmentCode         | TEXT (10), NN   |             |
| **SegmentID**       | INTEGER, **PK** |             |
| Title               | TEXT (50), NN   |             |
| UpstreamRiverMile   | REAL, NN        |             |
| DownstreamRiverMile | REAL, NN        |             |

## StageDischarges

There is one record in this table for each historical stage discharge sample value. Collectively these values constitute the relationship used to derive the stage discharge relationship for each sandbar site. See the [Stage Discharge](http://gcmrc.northarrowresearch.com/online_help/sandbars/sd_sample) features of the Workbench for how these values are displayed and managed.

| Field          | Info            | Description |
| -------------- | --------------- | ----------- |
| ElevationSP    | REAL, NN        |             |
| SampleDate     | DATETIME        |             |
| Flow           | REAL, NN        |             |
| FlowMS         | REAL, NN        |             |
| SampleTime     | VARCHAR (50)    |             |
| ElevationLocal | REAL            |             |
| **SampleID**   | INTEGER, **PK** |             |
| Comments       | VARCHAR (255)   |             |
| SampleCode     | VARCHAR (50)    |             |
| SampleCount    | INTEGER         |             |
| SiteID         | INTEGER, NN     |             |


## MySQL

The structure of the central, master MySQL database essentially mirrors that of the local SQLite database. The major difference is that the `TableChangeLog` table has the following fields:

* TableName
* UpdatedOn
* Sequence
* Synchronize

It's this TableChangeLog table that controls whether the data in a table is copied down to local databases when users synchronize with the master database. The Workbench software looks for records in the local SQLite copy that have an `UpdatedOn` field that is older than that in the master, and have a `Synchronize` value <> 0. These records are then looped over and each table is synchronized in the order of the `Sequence` field.

## General Design Principles
