---
title: Getting Started
layout: default
---

### Download

1. [Download](/download) and install the Sandbar Workbench software.

2. Download the latest local [Sandbar SQLite database](https://dl.dropboxusercontent.com/u/11461815/SandbarWorkbench/2016_12_01_sandbar_workbench_database.zip). (This will eventually get bundled with the software.)

### Configuration

Launch the Sandbar Workbench software and configure the following items under the **Tools - Options** menu item.

1. On the **Master Database** enter the password for the central, MySQL database.

2. On the **Folders** tab set the following three folders:

* `Sandbar Topo Data`: This is the folder that contains the raw point cloud topo data for sandbars. This will typically be `P:\PHYSICAL\Sandbars\Topo_Data\corgrids`
* `Remote Camera Photo Image Folder`: This is the folder containing the images for the remote camera setups. This will typically be `P:\PHYSICAL\Sandbars\RemoteCameras`
* `Sandbar Analysis Results`: This is the local folder  on your computer where you want sandbar analysis to be performed and the results written.

3. On the **Error Logging** tab check the box to share status and error information with developers.