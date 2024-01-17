---
title: Picture Viewer
---

The Workbench picture viewer is a proof of concept, experimental feature that shows photos related to sandbar sites stored on a network. There is a video demonstration of this feature at the bottom of this page.

![picture viewer](/images/picture_viewer/picture_viewer.png)

The tool works by searching the network folder path specified in the `Remote Camera Photo Image Folder` specified in the Workbench [Options](/online_help/tools_menu/Options/). The Workbench looks for three subfolders called:

* `Photos_Full_Res`
* `Photos_Thumb_Res`
* `Photos_Web_Res`

Inside these three folders should be a separate folder for each remote camera setup with the naming convention `RCXXXXX` where XXXXX represents the remote camera setup code. This code must precisely match what's specified on the [remote camera properties](/online_help/remote-cameras/remote_camera_properties) in the Workbench for the photo view to find the relevant files.

Use the dropdown box at the top of the photo viewer to select an individual remote camera setup and then select one of the three resolutions. The photo viewer should update and show all images on the right that match the criteria. You can double click any image to open it in the default image viewing software on your computer.

## Video Demonstration

{{< youtube vq83vCsLG3U >}}