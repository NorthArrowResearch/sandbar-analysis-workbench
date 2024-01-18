---
title: Managing Reference Information
layout: default
---

The GCMRC Workbench maintains several lists of reference information that are editable by the user. These lists are accessible from the `Views` item on the main menu.

![views](/images/views/views.png)

All these views operate in essentially the same way. Selecting one of the reference lists opens a table of the existing items in the local database. You can then select and double click or right click to edit any particular item. Changes are saved to both the local and master database simultaneously. Deleting items is permanent and cannot be undone!

Note that although changes to reference list items are immediately saved to the master database, other users will not receive these changes until they [synchronize their lookup lists](/online_help/tools_menu/synchronize).

## Analysis Bins

Analysis bins represent the vertical bins that are used in the [binned sandbar analysis](/technical_reference/binned_analysis). They are editable and so the next time the sandbar analysis is performed it will include all the bins currently defined in the local database. Note that deleting an analysis bin will also delete the results for all historical sandbar analyses stored in the local database! Therefore, rather than deleting an analysis bin, it is recommended that you deactivate it by unchecking the checkbox on the properties form (see below).

![analysis bins](/images/views/analysis_bins.png)

## Reaches

Reaches represent major analytical sections of the Grand Canyon. Each reach possesses a code and a name, both of which must be unique.

![Reaches](/images/views/reaches.png)

## Segments

Segments represent analytical sections within Reaches. Each segment possesses a name as well as an associated with a Reach.

![Segments](/images/views/reaches.png)

## Trips

Survey trips on the Colorado River are defined by their departure date. Trips can also have optional remarks for capturing miscellaneous information about the river trip. Note that you can't delete a trip that is referenced by a sandbar site survey. You first have to [edit the sandbar site survey](/online_help/sandbars/sandbar_surveys) and disassociate it from the trip before you can then delete the trip.

![Trips](/images/views/trips.png)

## Camera Cards

The list of digital camera card types is used in the remote camera setup properties. Note that you can't delete a camera card type that is referenced by a remote camera setup. You first have to [edit the remote camera setup](/online_help/remote-cameras/remote_camera_properties) and disassociate it with the camera card type before you can then delete the camera card type.

![Card Types](/images/views/cards.png)

# Survey Instruments

The list of survey instruments is used when defining a [sandbar survey](/online_help/sandbars/sandbar_surveys). Similar to other lookup lists, you cannot delete an instrument that is being referenced by a sandbar survey. You first have to edit the sandbar survey and disassociate it from the instrument before you can then delete that instrument lookup item.

![instruments](/images/views/instruments.png)