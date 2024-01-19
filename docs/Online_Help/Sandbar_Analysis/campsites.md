---
title: Campsites Data
parent: Sandbar Analysis
grand_parent: Online Help
nav_order: 8
layout: default
---

# Campsites

The campsite analysis the areas captured as polylines during sandbar surveys. The top level folder where the campsite data are located is specified in the Workbench Options:

![options](/images/options/options_sandbar.png)

Each folder under this top level should refer to a site code and within each of these subfolders should be the campsite ShapeFiles. Each ShapeFile must start with the site name, then an underscore, followed by the date specified as below. The part of the ShapeFile that comes after the date is not important.

```
<site_code5>\<site_code5>_YYYYMMDD_camp.shp
```

## ShapeFile Requirements

1. The ShapeFiles must be **polyline** geometry type.
2. One feature per campsite, digitized as closed loop.
3. The polylines must be 3D with the vertices possessing elevations.
4. The spatial reference coordinate system much match that of the `corgrids` textfiles.

Below is an example of what the campsites look like in 2023 for 004L.

![campsites](/images/sandbar_analysis/campsites.jpg)