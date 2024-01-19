---
title: Model Runs
layout: default
parent: Sandbar Analysis
grand_parent: Online Help
nav_order: 1
---

# Model Runs

The results of each sandbar analysis run are stored in the GCMRC Workbench database. The database only stores the tabular results (areas and volumes for both the incremental and binned analysis) and does not store all the miscellaneous output rasters and files.

The list of historical sandbar analyses can be viewed in the workbench by selecting `Sandbar Analysis Results` from the main `Views` menu. This brings up the list of all analysis results currently stored in the local workbench database. It includes runs that were actually performed on the local computer as well as runs that were performed on other computers and downloaded (see synchronization details below). The list of analysis runs can be filtered by date or by whether each run was performed on the local computer or not.

![model results](/images/sandbar_analysis/model_results.png)

## Editing Sandbar Analysis Results

You can edit the selected sandbar analysis either by double clicking the row in the table or right clicking and choosing `Edit`. You can only edit the title and remarks for a sandbar analysis run. i.e. you can't alter the configuration of a historical run and/or re-run it.

The title for each analysis run is required and must be unique across all runs on the local and master databases (see synchronization details below). Remarks are optional (but recommended to communicate the motivation or history behind each sandbar analysis run).

![model results property](/images/sandbar_analysis/model_results_properties.png)

## Deleting Sandbar Analysis Results

Right click on a run in the table of results and select `Delete`. Deleting a run is permanent and cannot be undone. This operation also deletes the run on the local computer **as well as also on the master database**. If the the run was ever synchronized to the master database in the past, it could still reside on other users' computers until they trigger a synchronization, at which point the affected run will also be deleted from their computer. Further explanation of this feature is provided in the video demonstration at the bottom of this video.


## Exporting Sandbar Analysis Results

The incremental and binned results for each sandbar analysis run can be exported to comma separated value (CSV) flat text files. Right click on a run and choose one of the export options.

![export](/images/sandbar_analysis/export_results.png)

The final output is a highly portable listing of all tabular results for the selected run:

```
SiteID	SiteCode	SectionID	Instrument	Uncertainty	SectionTypeID	SectionType	SurveyID	SurveyDate	Elevation	Area	Volume
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	919.62	3560	5606.4368
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	919.72	3551	5305.9758
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	919.82	3507	5005.2108
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	919.92	3438	4706.894
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	920.02	3327	4415.5289
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	920.12	3215	4133.1165
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	920.22	3112	3859.2845
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	920.32	3009	3592.7247
1	0003L	340	Total Station	0	10	Eddy - Single	457	9/28/1990	920.42	2920	3331.4428
```



## Video Demonstration

<iframe width="100%" height="500" src="https://www.youtube.com/embed/iVCHKBjzblQ?si=80c4FSIMeGU" title="YouTube video player" frameborder="0" allowfullscreen></iframe>