---
title: Sandbar Surveys
---

Each time that data are collected at a sandbar site is considered a survey. The collection of both topographic and bathymetric data is considered one survey, even though the data are collected by different means (the former by total station and the latter by boat). Note that even if a sandbar site is surveyed over more than one day, the entire survey is still tagged with a single date, nominally the first day on which surveyed started.

The workbench maintains a list of surveys for each sandbar site. This list can be managed by the user and surveys added, edited or deleted. To get to the list of surveys for a site:

1. Open the GCMRC Workbench and ensure that you are connected to a valid database.
2. If you don't see the main list of sandbar sites then click on the `Views` menu and choose `Sandbar Sites` from the dropdown menu.
3. Select the relevant sandbar site in the list and right click and choose `Properties`.
4. Switch to the `Surveys` tab.

The list shows the date of the survey along with the launch date of the trip on which the survey occurred. The eddy count represents the number of eddies surveyed (1 for a single eddy site and 2 for a separation and reattachment eddy). The Channel survey column indicates true when bathymetry in the channel were collected, otherwise false. The remaining columns contain audit information about when the information was last edited.

![surveys](/images/sandbars/sandbar_properties_surveys.png)

## Editing Survey Information

Right click to edit the selected survey or to add or delete a new one. The form that appears allows you to set the following properties:

* **Trip Date** - pick the corresponding river trip departure date from the drop down. If the trip does not appear then exit the current form and return to the main menu and choose `Trips` from the `Views` menu to add the relevant item.
* **Survey Date** - specify the date on which the sandbar was surveyed.
* **Sections** - Add, edit or delete rows from the `Sections Surveyed` list to accurately represent which parts of the sandbar were surveyed on this date. 
  * The **section type** should represent either a single eddy, the channel or either the separation or reattachment part of a multi-part eddy.
  * The **instrument type** should be the dominant instrument used for the section. Additional instruments can be added on the main menu under `Views` and `Survey Instruments`. 
  * **Uncertainty** - represents the vertical uncertainty in the survey of each particular section, measured in meters.

![survery properties](/images/sandbars/survey_properties.png)

## Video Demonstration

{{< youtube iVCHKBjzblQ >}}