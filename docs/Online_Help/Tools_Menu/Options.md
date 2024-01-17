---
title: Options
---
Several software settings can be controled via the **Options** feature that is found under the main `Tools` menu in the GCMRC Workbench. The settings are grouped into a series of tabs that are described below. A video demonstrating each of these tabs appears at the bottom of this page.

## Startup

* **Load Last Database** - Check this box to automatically reload the last used database when the Workbench launches. This avoids having to choose `File - Open` and browsing to the desired local database each time.

* **Open View At Startup** - If you always tend to use one of the core database views then you can select it here and it will be opened automatically each time that the software starts. This is helpful, say, if you only tend to work with sandbar sites. Choose `-- None --` to disable this feature and the workbench will start without a view open.

* **Sandbar Folder Identification** - Select which site code format - either four or five digit format - is used to store the corgrid point text files that are used for the sandbar analysis.

* **Installation GUID** - This is used by software developers only.

![startup](/images/options/options_startup.png)

## Master Database

  The CHaMP workbench runs off of a local SQLite database. Each workbench installation possesses its own local database and reads and writes information to this local copy. However, a master database is used to help users exchange information and this Options tab stores the credentials for connecting to the master database. The password can be obtained from either James Hensleigh or Rob Ross at GCMRC or the North Arrow Research development team (info@northarrowresearch.com).

![database](/images/options/options_database.png)

## Folders
The folders tab specifies several local folder paths used by the sandbar workbench. Click on a row in the table to change a path.

* **Sandbar Topo Data** - this is the top level folder where point corgrid text files are located. Under the path specified there should be one folder for each sandbar site.
* **Remote Camera Photo Image Folder** - the top level folder where full, web and thumbnail images are located. Under the path specified there should be one folder for each remote camera setup identified by its setup code.
* **Sandbar Analsys Results** - this is the default folder where sandbar analysis results will be written. This is just the default and you can override this folder each time that you run the software.

![folders](/images/options/options_folders.png)

## Sandbar Analysis

This tab stores several defaults for the sandbar analysis Python script. These values can overwritten each time that the analysis is run and the values stored here are just the defaults. See the [sandbar analysis configuration](/online_help/sandbar_analysis/sandbar_analysis_run) page for more information on these settings.

![sandbar](/images/options/options_sandbar.png)

## Error Logging

Check the box to share  status and error information with the workbench software development team. Enabling this feature is extremely helpful for the developers as it transmits anonymous information about any software crashes directly to the developers in real time.

When communicating with developers about software errors its also extremely helpful if you include the  installation logging key. This is unique to your workbench installation and will help them identify your issues in the log.

## Dates
The dates tab lets you specify the way dates are displayed in several locations throughout the software.

![dates](/images/options/options_dates.png)

## Python
The sandbar analysis code uses several important Python configuration settings. See the [Python Configuration](/online_help/sandbar_analysis/python_configuration) page for more information on these settings and how to configure them.

![python](/images/options/options_python.png)


## Video Demonstration

{{< youtube -a0kMyvbj44 >}}