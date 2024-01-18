---
title: Remote Cameras Setups
layout: default
---

The GCMRC Workbench maintains a list of remote camera setups within the Grand Canyon. Each setup represents an individual camera location and there might be more than one camera pointing at a single sandbar site. 

Each remote camera setup possesses a unique site code that is typically based on the river mile location of the camera (e.g. RC003L is on the left bank at river mile 3 downstream on the Glen Canyon dam). Where more than one setup is located at a given river mile a suffix of a, b, c etc is used to distinguish the individual setups.

There is a video demonstrtion of the remote camera setup features of the GCMRC Workbench at the bottom of this page.

## Main Remote Camera Grid

Select `Remote Cameras` from the main `Views` menu in the Workbench. You can filter the setups shown by either river mile, site name or on which bank the camera is located and/or targeted. The site name filter operates on *any part* of the site name. For example, entering a site name filter of `ca` matches *Cathedral Wash*, *South Canyon* and *Carbon* etc.

Note that initially the list is filtered to just active camera setups. Uncheck the box on the left to display all camera locations. The active status is not stored as a Boolean property on each remote camera setup record. Rather it is identifies camera setups that have an ongoing digitial record. This is defined as setups that have a non Null start date for their digital record and a null end date for their digital record. In other words its camera.

You can select and then right click any remote camera setup to see a context menu of actions that can be performed. Records can be added, edited and deleted. In addition the currently displayed list of records can be exported to a CSV file.

![remote cameras](/images/remote_cameras/remote_cameras.png)

## Viewing Remote Camera Setup Properties

Double clicking a remote camera setup, or right clicking and choosing `View Properties` displays the properties of the record in **read only** mode. Click the `Show Pictures` button to open the pop-out section of the form that displays photos for this setup. See the [picture viewer](/online_help/pictures/picture_viewer) page for how to configure the Workbench to work with a repository of photos.

![remote camera properties with photos](/images/remote_cameras/remote_camera_properties_with_pictures.png)

## Editing Remote Camera Setup Properties

To enable editing you have to select the record and then right click to choose **Edit Properties**. This opens the same properties form as is used for viewing properties, but in edit mode.

Note that saving remote camera setup properties simultaneously stores changes to both the local Workbench database as well as to the central, master Workbench database. Other users will receive these changes the next time that they [synchronize](/online_help/tools_menu/synchronize) their local Workbench with the master database.

## Deleting Remote Camera Setups

Right click on a remote camera setup in the main grid and then choose `Delete Selected`. You will be asked to confirm the operation. Deleting remote camera setups simulatenously deletes the item from both the local Workbench database as well as to the central, master Workbench database. Deleting records is permanent and cannot be undone!

## Video Demonstration

<iframe width="100%" height="500" src="https://www.youtube.com/embed/iVCHKBjzblQ?si=0EqazKKqb08" title="YouTube video player" frameborder="0" allowfullscreen></iframe>

