This repo contains the [GCMRC Sandbar Workbench](https:gcmrc.northarrowresearch.com) software. This is a small, lightweight desktop software application for managing Grand Canyon sandbars and the results from the [Sandbar Python Analysis](https://github.com/NorthArrowResearch/sandbar-analysis-python).  

# Requirements

- [Requirements](https://gcmrc.northarrowresearch.com/download.html#prerequisites)

The software was coded using Microsoft Visual Studio 2022 and relies on several Nuget packages, including `System.Data.SQLites` and `DBUp`.

# Database 

The latest version of the Workbench uses a single SQLite database. It no longer uses a master MySQL database.

## Create a new DB with the contents of the SQL File:

``` bash
sqlite3 -init workbench_schema_data.sql workbench.sqlite ""
```

## Export Schema from DB:

``` bash
# Export only the schema
sqlite3 workbench.sqlite .schema > workbench_schema.sql
# Export everything including Data
sqlite3 workbench.sqlite .dump > workbench_schema_data.sql
```