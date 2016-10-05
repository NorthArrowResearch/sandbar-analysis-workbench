Workbench



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