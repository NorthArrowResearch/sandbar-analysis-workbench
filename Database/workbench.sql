--
-- File generated with SQLiteStudio v3.0.6 on Mon Jul 18 10:50:26 2016
--
-- Text encoding used: windows-1252
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Reaches
CREATE TABLE Reaches (ReachID INTEGER PRIMARY KEY, ReachCode TEXT (10) NOT NULL UNIQUE, Title TEXT (50) UNIQUE NOT NULL, AddedOn DATETIME DEFAULT (CURRENT_TIMESTAMP) NOT NULL, AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME DEFAULT (CURRENT_TIMESTAMP) NOT NULL, UpdatedBy TEXT (50) NOT NULL)
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (1, '0_Glen', 'Glen Canyon', '2016-07-18 17:40:40', 'pgb', '2016-07-18 17:40:40', 'pgb');
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (2, '1_UMC', 'Upper Marble Canyon', '2016-07-18 17:41:02', 'pgb', '2016-07-18 17:41:02', 'pgb');
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (3, '2_LMC', 'Lower Marble Canyon', '2016-07-18 17:41:24', 'pgb', '2016-07-18 17:41:24', 'pgb');
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (4, '3_EGC', 'EGC', '2016-07-18 17:42:15', 'pgb', '2016-07-18 17:42:15', 'pgb');
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (5, '4_CGC', 'CGC', '2016-07-18 17:42:15', 'pgb', '2016-07-18 17:42:15', 'pgb');
INSERT INTO Reaches (ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (6, '5_WGC', 'WGC', '2016-07-18 17:46:41', 'pgb', '2016-07-18 17:46:41', 'pgb');

-- Table: LookupListItems
CREATE TABLE LookupListItems (ItemID INTEGER PRIMARY KEY, ListID INTEGER REFERENCES LookupLists (ListID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL, Title TEXT (50), AddedOn DATETIME DEFAULT (CURRENT_TIMESTAMP), UpdatedOn DATETIME DEFAULT (CURRENT_TIMESTAMP))
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (1, 1, 'Right', '2016-07-18 17:08:59', '2016-07-18 17:08:59');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (2, 1, 'Left', '2016-07-18 17:08:59', '2016-07-18 17:08:59');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (3, 2, 'Sandbar Monitoring', '2016-07-18 17:13:16', '2016-07-18 17:13:16');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (4, 2, 'Sanbar Irregular', '2016-07-18 17:13:16', '2016-07-18 17:13:16');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (5, 2, 'Sandbar Backwater', '2016-07-18 17:13:16', '2016-07-18 17:13:16');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (6, 3, 'Separation', '2016-07-18 17:18:00', '2016-07-18 17:18:00');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (7, 3, 'Re-attachment', '2016-07-18 17:18:00', '2016-07-18 17:18:00');
INSERT INTO LookupListItems (ItemID, ListID, Title, AddedOn, UpdatedOn) VALUES (8, 3, 'Unknown', '2016-07-18 17:18:00', '2016-07-18 17:18:00');

-- Table: LookupLists
CREATE TABLE LookupLists (ListID INTEGER PRIMARY KEY, Title TEXT (50) UNIQUE NOT NULL, EditableByUser BOOLEAN DEFAULT (0))
INSERT INTO LookupLists (ListID, Title, EditableByUser) VALUES (1, 'River Banks', 0);
INSERT INTO LookupLists (ListID, Title, EditableByUser) VALUES (2, 'Site Types', 0);
INSERT INTO LookupLists (ListID, Title, EditableByUser) VALUES (3, 'Sandbar Area Types', 0);

-- Table: Segments
CREATE TABLE Segments (SegmentID INTEGER PRIMARY KEY, SegmentCode TEXT (10) NOT NULL UNIQUE, Title TEXT (50) UNIQUE NOT NULL, UpstreamRiverMile REAL NOT NULL, DownstreamRiverMile REAL NOT NULL, AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL)

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
