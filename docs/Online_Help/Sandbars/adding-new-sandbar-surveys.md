---
title: Adding New Sandbar Surveys

---

There are several steps that must be performed when adding new sandbar surveys to the Workbench. These steps are required and need to be performed correctly for the sandbar analysis to work with the new surveys.

Typically, the process of adding new surveys will occur only once or twice a year, after a river trip where surveys were performed. The current process is rather tedious as it requires manual editing of each sandbar site. This involves a lot of mouse clicks for river trips where many sites were surveyed. We are planning a feature in the future that will avoid the need to do this and skip the time consuming step 3 altogether.

## 1. River Trips Record

Ensure that the correct river [Trips](/online_help/views/Managing-Reference-Information) record is created that describes the river trip on which the surveys were performed.

## 2. Survey Instrument Record
Ensure that the correct  [Survey Instruments](/online_help/views/Managing-Reference-Information) records are created for all the various equipment used to perform the surveys.

## 3. Create Survey Records In Workbench

Follow the **Editing Survey Information** steps on the [Sandbar Surveys](/online_help/sandbars/sandbar_surveys/) page to create the individual survey records for every sandbar site that was surveyed. 

## 4. Store Point Grid Text Files

The point grid text files produced by NAU must be placed in the correct location alongside all the other surveys and with a very specific file naming convention. Typically the location for these files at GCMRC is `P:\PHYSICAL\Sandbars\Topo_Data\corgrids`.

Inside this top level folder there should be an individual folder for each sandbar site called `XXXXcorgrids` where XXXX represents the four digit site code. So site 003L uses the folder name `003Lcorgrids`.

Each survey file inside this folder has the format `Z_YYMMDD_grid.txt` where Z is the site code stripped of leading zeroes and the trailing bank code (L or R). YY is the two digit year, MM is the two digit month and DD is the two digit day. 

A subset of the existing survey folder structure looks like:

```
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\001Rcorgrids
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\001Rcorgrids\1_000819_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\001Rcorgrids\1_000909_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\001Rcorgrids\1_020427_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\001Rcorgrids\1_020920_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\...
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_000318_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_000602_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_000819_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_000909_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_011005_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_020427_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\003Lcorgrids\3_020920_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\...
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\008Lcorgrids
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\008Lcorgrids\8_000318_grid.TXT
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\008Lcorgrids\8_000604_grid.txt
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\008Lcorgrids\8_000821_grid.TXT
P:\PHYSICAL\Sandbars\Topo_Data\corgrids\008Lcorgrids...
...
```

The grid text files must adhere to the same format that is used for the existing files:

* Must follow the file name convention described above

* Must not have a header row

* Columns in the following order:

  * Point code
  * Easting (m)
  * Northing (m)
  * Elevation (m)

## Testing

Once you have created all the necessary Workbench database records and correctly stored the point grid text files on the network, you can test the result by [running the sandbar analysis](/online_help/sandbar_analysis/sandbar_analysis_run). The output messages will provide a warning when surveys are encountered in the Workbench database that have no corresponding point grid text file on disk.