-- Drop the old table that used to track synchronization with the master database
DROP TABLE TableChangeLog;

-- Drop the old version change log table that was used to track schem changes before DBUp
DROP TABLE VersionChangeLog;
