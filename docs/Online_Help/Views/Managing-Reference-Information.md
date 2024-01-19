---
title: Managing Lookup Lists
layout: default
parent: Online Help
nav_order: 5
---

# Managing Lookup Lists

The GCMRC Workbench maintains several lists of reference information that are editable by the user. These lists are accessible from the `Views` item on the main menu.

![views](/images/views/views.png)

All these views operate in essentially the same way. Selecting one of the reference lists opens a table of the existing items in the local database. You can then select and double click or right click to edit any particular item. 

Deleting items is permanent and cannot be undone!

## Analysis Bins

Analysis bins represent the vertical bins that are used in the [binned sandbar analysis](/technical_reference/binned_analysis). They are editable and so the next time the sandbar analysis is performed it will include all the bins currently defined in the local database. Note that deleting an analysis bin will also delete the results for all historical sandbar analyses stored in the local database! Therefore, rather than deleting an analysis bin, it is recommended that you deactivate it by unchecking the checkbox on the properties form (see below).

![analysis bins](/images/views/analysis_bins.png)

## Campsite Analysis Bins

These bins are similar to the Analysis Bins above, but are exclusively used for the campsite analysis. The same rules apply to campsite analysis bins.

## Reaches

Reaches represent major analytical sections of the Grand Canyon. Each reach possesses a code and a name, both of which must be unique.

![Reaches](/images/views/reaches.png)

## Segments

Segments represent analytical sections within Reaches. Each segment possesses a name as well as an associated with a Reach.

![Segments](/images/views/reaches.png)

## Trips

Survey trips on the Colorado River are defined by their departure date. Trips can also have optional remarks for capturing miscellaneous information about the river trip. Note that you can't delete a trip that is referenced by a sandbar site survey. You first have to [edit the sandbar site survey](/Online_Help/Sandbars/sandbar_surveys.html)) and disassociate it from the trip before you can then delete the trip.

![Trips](/images/views/trips.png)

### Import Trip

You can generate a new trip by importing a comma separated value (CSV) text file that lists the sites and sections surveyed on the trip. The CSV file must have a header row and contain the following columns:

- **SiteCode5** - the five character site code matching one of the sites in the database.
- **SurveyDate** - the date that the site was surveyed in `YYYY-MM-DD` format.
- **SectionType** - one of the following section types:
   - Channel
   - Eddy - Single
   - Eddy - Separation
   - Eddy - Reattachment
- **Instrument** - one of the [survey instruments](#survey-instruments) listed in the database.
- **Uncertainty** - an uncertainty associated with the survey instrument, measured in meters. This value is not used in any of the analyses.

The following shows an example of how the CSV should be formatted:

```
SiteCode5,SurveyDate,SectionType,Instrument,Uncertainty
0041R,2008-03-31,Channel,Multi Beam Sonar,0
0041R,2008-03-31,Eddy - Reattachment,Total Station,0
0041R,2008-03-31,Eddy - Separation,Total Station,0
0009L,2008-03-29,Eddy - Single,Total Station,0
0033L,2008-03-30,Eddy - Single,Total Station,0
0047R,2008-04-01,Eddy - Single,Total Station,0
0047R,2008-04-01,Channel,Multi Beam Sonar,0
0068R,2008-04-05,Eddy - Single,Total Station,0
0068R,2008-04-05,Channel,Multi Beam Sonar,0
...
```

To import trip data:

1. Click the `Trips` item on the Views menu inside the Workbench.
1. Click `Import Trip` and the import form will appear.
2. Use the date picker to specify the trip start date.
3. Click the browse button and navigate to the CSV file containing the trip data.
4. Provide any remarks about the trip.
5. Click OK.

Should an error occur, all changes to the database will be aborted and no new information will be saved. The error should explain the problem, together with the relevant line number in the CSV where the problem occurred.

![import trip](/images/views/import_trip.png)

## Survey Instruments

The list of survey instruments is used when defining a [sandbar survey](/online_help/sandbars/sandbar_surveys). Similar to other lookup lists, you cannot delete an instrument that is being referenced by a sandbar survey. You first have to edit the sandbar survey and disassociate it from the instrument before you can then delete that instrument lookup item.

![instruments](/images/views/instruments.png)