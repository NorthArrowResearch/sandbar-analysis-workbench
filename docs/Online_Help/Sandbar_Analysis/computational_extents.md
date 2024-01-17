---
title: Computational Extents
---

A ShapeFile that delineates each sandbar site is used within the sandbar analysis to clip surveys down to the appropriate sections of channel. This ShapeFile is a mandatory prequisite for running the sandbar analysis (but not for viewing prior runs) and it must meet the following requirements:

1. The spatial reference must be [Stateplane Arizona Central FIPS 0202](http://www.spatialreference.org/ref/sr-org/nad832011-state-plane-arizona-central-fips-0202/).
2. There must be a string attribute field called `Site` that identifies the sandbar site associated with each polygon. (see *site identification* below).
3. There must be at least one polygon for each sandbar **section type**.  There must be a string attribute field called `Section` that contains one of the following section types:
    * `channel` - the section of river adjacent to the sandbar.
    * `eddy` - a single section of sand.
    * `separation` - the section of a sandbar that is in the upstream separation-eddy.
    * `reattachment` - the section of a sandbar that is in the downstream, reattachment-eddy.


![Computational Extents](/images/sandbar_analysis/computational_extents.png)

## Site identification

GCMRC has historically used four digit site codes (e.g. 003L) to identify sandbar sites. Moving forward, there is an intent to start using five digit codes (e.g. 0005L) that provide more resolution to the river mile part of the code.

The sandbar analysis is capable of identifying sites using either the four or five digit site codes. The only requirement is that whichever format is used for the file paths to the raw point text files must also be used in the computational extents ShapeFile. See the [Options](/online_help/tools_menu/Options) form for how to change between four and five digit site codes.
