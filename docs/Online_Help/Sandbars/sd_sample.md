---
title: Stage Discharge Samples
---

The Workbench maintains a list of stage discharge sample data for each sandbar site. These records capture historical measurements of stage discharge and are used to parameterize the official stage discharge curve that is used for each site. There is a video demonstration of this feature at the bottom of this page.

Over time the stage discharge curve calibration might depart from the historical samples and require recalibrating. 

![sd_samples](/images/sandbars/sd_samples.png)

To view the stage discharge samples for a particular sandbar site:

1. Open the GCMRC Workbench.
2. Choose `Sandbar Sites` from the main `Views` menu.
3. Select a single sandbar site in the list and then either double click it or right click and choose `View Properties` to open the property view of the sandbar site.
4. Click on the `Stage Discharge` tab.

The stage discharge tab contains several elements:

* A stage discharge calculator (top left) for manually calculating stage values for a specific discharge/
* A dropdown list of samples (top right) that contains all historical samples collected for this sandbar site. The buttons to the right of this dropdown list can be used to manage the list of samples.
* Chart showing:
  * All historical stage discharge samples as grey dots.
  * The current selection in the list of historical samples is shown as a red square. Click on the dropdown list and use the up/down arrow to select any of the historical values and it highlighted in the chart).
  * The current official stage discharge curve (blue).
    * Key discharges (nominally 8,000 and 25,000 CFS)
    * The current manually calculated stage discharge point (red dot)

## Managing Historical Samples

You can add, edit and delete historical stage discharge samples using the buttons to the right of the drop down list. Clicking the add or edit button opens the stage discharge properties window:

![sd_sample_properties](/images/sandbars/sd_sample_properties.png)

The following properties are available for a stage discharge sample:

* `Site` - this should already be selected for the sandbar site that was active in the sandbar list when this form was opened. The sandbar site is shown here merely as a reference.
* `Date` - If a valid date is known for the sample then check the box to activate the date control and then select the appropriate date. Note that unchecking the box next to the date will clear any previously entered date in the database.
* `Time` - Enter the time that the sample was collected. The time is an unformatted string and so words can be used if needed. The 24hr clock format is recommended: `HH:MM`.
* `Code` - sample code.
* `Local Elevation` - Check the box if a local elevation in assumed coordinate space is available. Unchecking the box clears any historical value in the database.
* `SP Elevation` - The absolute stateplane elevation in meters.
* `Sample Count` - Check the box if a sample count is available. This represents the total number of stage discharge sample measurements made to obtain this sample.
* `Flow (cfs)` - Measured flow in cubic feet per second.
* `Flow (ms)` - Measured flow converted to meters per second.
* `Comments` - Optional, miscellaneous remarks about the sample.

Clicking `Save` will save the entered information simultaneously on the master GCMRC Workbench database as well as the local database. If anything goes wrong with the operation, both databases are rolled back to the same point before the operation occurred.

### Deleting Stage Discharge Samples

Click the red X button to delete the currently selected stage discharge sample shown in the drop down list. This will delete the sample on both the remote master database as well as the local database. **This action is permanent and cannot be undone!**

## Exporting Stage Discharge Samples

Click the `Export` button to save all the historical samples for the selected sandbar site to a comma separated value (CSV) text file.

 ![sd_sample_export](/images/sandbars/sd_sample_export.png)

 The file produced contains all the property fields described above:

 ```
 Sample Date,Sample Time,Sample Code,Local Elevation, SP Elevation, Sample Count, Flow, Flow MS, Comments
,,,93.3365173339844,920.2705078125,,5022.56005859375,142.238891601563,
,,,96.239501953125,923.173522949219,,27434.75,776.9521484375,
,,,97.5,924.434020996094,,45895,1299.74645996094,highest daily mean was 45600.  max peak1996 controlled flood was 45895
,,,95.5400009155273,922.473999023438,,20279.19921875,574.306945800781,
,,,95.9599990844727,922.893981933594,,24626,697.408325195313,97 March hi steady flow
,test,test,,100,,1000,10,test sample
1997-11-06,,31k,96.4810028076172,923.414978027344,13,30848,873.615356445313,
2000-06-02,,we,93.941650390625,920.875671386719,37,8220,232.790405273438,steady 8k
...
 ```

## Exporting Stage Discharge Curve

You can export the stage discharge curve itself using the `Export` button at the far right of the tab.

![sd_curve_export](/images/sandbars/sd_curve_export.png)

This will produce a CSV text file of values along the stage discharge curve from 8,000 to 45,000 CFS in 500 CFS increments.

```
discharge,stage
8000,920.82328
8500,920.89757
9000,920.97112
9500,921.04393
10000,921.116
10500,921.18733
11000,921.25792
11500,921.32777
...
​```
```

## Video Demonstration

{{< youtube 3wfGRSIN8MY >}}