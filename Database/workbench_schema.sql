CREATE TABLE LookupLists (ListID INTEGER PRIMARY KEY, Title TEXT (50) UNIQUE NOT NULL, EditableByUser BOOLEAN DEFAULT (0));
CREATE TABLE LookupListItems (ItemID INTEGER PRIMARY KEY, ListID INTEGER REFERENCES LookupLists (ListID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL, Title TEXT (50), AddedOn DATETIME DEFAULT (CURRENT_TIMESTAMP), UpdatedOn DATETIME DEFAULT (CURRENT_TIMESTAMP));
CREATE TABLE Reaches (ReachID INTEGER PRIMARY KEY, ReachCode TEXT (10) NOT NULL UNIQUE, Title TEXT (50) UNIQUE NOT NULL, AddedOn DATETIME DEFAULT (CURRENT_TIMESTAMP) NOT NULL, AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME DEFAULT (CURRENT_TIMESTAMP) NOT NULL, UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE Segments (SegmentID INTEGER PRIMARY KEY, SegmentCode TEXT (10) NOT NULL UNIQUE, Title TEXT (50) UNIQUE NOT NULL, UpstreamRiverMile REAL NOT NULL, DownstreamRiverMile REAL NOT NULL, AddedBy TEXT (50) NOT NULL, UpdatedBy TEXT (50) NOT NULL, AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP));
CREATE TABLE Trips (TripID INTEGER PRIMARY KEY, TripDate DATE NOT NULL, AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE SandbarSites (SiteID INTEGER PRIMARY KEY, SiteCode TEXT (10) UNIQUE NOT NULL, SiteCode5 TEXT (5), RiverMile REAL NOT NULL, RiverSideID INTEGER REFERENCES LookupListItems (ItemID) NOT NULL, Title TEXT (50) NOT NULL UNIQUE, AlternateTitle TEXT (50), SiteTypeID INTEGER NOT NULL REFERENCES LookupListItems (ItemID), History TEXT (50), EddySize INTEGER, ExpansionRatio8k REAL, ExpansionRatio45k REAL, StageChange8k45k REAL, PrimaryGDAWS INTEGER, SecondaryGDAWS INTEGER, ReachID INTEGER REFERENCES Reaches (ReachID), SegmentID INTEGER REFERENCES Segments (SegmentID), CampsiteSurveyRecord TEXT (50), RemoteCameraID INTEGER, StageDischargeA REAL, StageDischargeB REAL, StageDischargeC REAL, Northing REAL, Easting REAL, Latitude REAL, Longitude REAL, InitialSurvey DATE, AddedOn DATETIME DEFAULT (CURRENT_TIMESTAMP) NOT NULL, AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE SandbarSurveys (SurveyID INTEGER PRIMARY KEY, SiteID INTEGER REFERENCES SandbarSites (SiteID) ON DELETE NO ACTION ON UPDATE NO ACTION NOT NULL, TripID INTEGER REFERENCES Trips (TripID) ON DELETE NO ACTION ON UPDATE NO ACTION NOT NULL, SurveyDate DATE, AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE AnalysisBins (BinID INTEGER PRIMARY KEY, Title TEXT (50) UNIQUE NOT NULL, LowerDischarge REAL, UpperDischarge REAL, IsActive BOOLEAN NOT NULL DEFAULT (1), AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE ModelRuns (RunID INTEGER PRIMARY KEY, Title TEXT (50), RunTypeID INTEGER REFERENCES LookupListItems (ItemID), InputXML VARCHAR (1000), AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL);
CREATE TABLE SandbarSections (SectionID INTEGER PRIMARY KEY, SurveyID INTEGER REFERENCES SandbarSurveys (SurveyID) ON DELETE CASCADE NOT NULL, SectionTypeID INTEGER REFERENCES LookupListItems (ItemID) NOT NULL, Uncertainty REAL DEFAULT (0) NOT NULL);
CREATE TABLE ModelResultsBinned (RunID INTEGER NOT NULL REFERENCES ModelRuns (RunID) ON DELETE NO ACTION ON UPDATE NO ACTION, SectionID INTEGER NOT NULL REFERENCES SandbarSections (SectionID) ON DELETE CASCADE, BinID INTEGER REFERENCES AnalysisBins (BinID) NOT NULL, Area REAL NOT NULL, Volume REAL, Area3D REAL);
CREATE TABLE SandbarSectionUncertainties (UncertaintyID INTEGER PRIMARY KEY, SectionID INTEGER REFERENCES SandbarSections (SectionID) ON DELETE NO ACTION NOT NULL, BinID INTEGER REFERENCES AnalysisBins (BinID) NOT NULL, Uncertainty REAL NOT NULL DEFAULT (0), AddedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), AddedBy TEXT (50) NOT NULL, UpdatedOn DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), UpdatedBy TEXT (50) NOT NULL);
CREATE TABLE VersionInfo ("Key" TEXT (50) PRIMARY KEY UNIQUE NOT NULL, ValueInfo TEXT (255) NOT NULL);
CREATE TABLE VersionChangeLog (DateOfChange DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP), Version INTEGER NOT NULL, Description TEXT (255) NOT NULL);
CREATE TABLE ModelResultsIncremental (RunID INTEGER NOT NULL REFERENCES ModelRuns (RunID) ON DELETE CASCADE ON UPDATE CASCADE, SectionID INTEGER NOT NULL REFERENCES SandbarSections (SectionID) ON DELETE CASCADE, Elevation REAL NOT NULL, Area REAL, Volume REAL, Area3D REAL);
CREATE INDEX FX_SandbarSurveys_SiteID ON SandbarSurveys (SiteID);
CREATE UNIQUE INDEX PK_ModelResultsIncremental ON ModelResultsIncremental (RunID DESC, SectionID ASC, Elevation ASC);
CREATE VIEW vwSandbarSites AS SELECT S.SiteID
    , S.SiteCode
    , S.SiteCode5
    , S.RiverMile
    , S.RiverSideID
    , RS.Title AS RiverSide
    , S.Title
    , S.AlternateTitle
    , S.SiteTypeID
    , ST.Title AS SiteType
    , S.History
    , S.EddySize
    , S.ExpansionRatio8k
    , S.ExpansionRatio45k
    , S.StageChange8k45k
    , S.PrimaryGDAWS
    , S.SecondaryGDAWS
    , S.ReachID
    , R.Title AS Reach
    , S.SegmentID
    , Seg.Title AS Segment
    , S.CampSiteSurveyRecord
    , S.RemoteCameraID
    , S.StageDischargeA
    , S.StageDischargeB
    , S.StageDischargeC
    , S.Northing
    , S.Easting
    , S.Latitude
    , S.Longitude
    , S.InitialSurvey
    , S.AddedOn
    , S.AddedBy
    , S.UpdatedOn
    , S.UpdatedBy
FROM SandbarSites S
    INNER JOIN LookupListItems RS ON S.RiverSideID = RS.ItemID
    INNER JOIN LookupListItems ST ON S.SiteTypeID = ST.ItemID
    LEFT JOIN Reaches R ON S.ReachID = R.ReachID
    LEFT JOIN Segments Seg ON S.SegmentID = Seg.SegmentID
ORDER BY S.SiteCode;
CREATE TRIGGER LookupListItem_Update AFTER UPDATE OF ListID, Title ON LookupListItems FOR EACH ROW BEGIN UPDATE LookupListItems SET UpdatedOn = CURRENT_TIMESTAMP WHERE ItemID = NEW.ITemID; END;
CREATE VIEW vwIncrementalResults AS Select
    S.SiteID
    , MR.RunID
    , MR.SectionID
    , SS.SectionTypeID
    , S.SurveyID
    , S.SurveyDate
    , MR.Elevation
    , MR.Area
    , MR.Volume

FROM ModelResultsIncremental MR
    INNER JOIN SandbarSections SS ON MR.SectionID = SS.SectionID
    INNER JOIN SandbarSurveys S ON S.SurveyID = SS.SurveyID;