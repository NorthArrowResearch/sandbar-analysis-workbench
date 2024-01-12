CREATE TABLE StageDischargeParams 
(
	StageDischargeID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	SiteID INT NOT NULL REFERENCES SandbarSites(SiteID) ON DELETE CASCADE,
	EffectiveDate DATE NOT NULL,
	Description TEXT,
	ParameterA REAL NOT NULL,
	ParameterB REAL NOT NULL,
	ParameterC REAL NOT NULL,
	AddedOn DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	AddedBy TEXT NOT NULL,
	UpdatedOn DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	UpdatedBy TEXT NOT NULL
);
CREATE UNIQUE INDEX ux_StageDischargeParams ON StagedischargeParams(SiteID, EffectiveDate);

INSERT INTO StageDischargeParams (
	SiteID,
	EffectiveDate,
	ParameterA,
	ParameterB,
	ParameterC,
	AddedBy,
	UpdatedBy
)
	SELECT
		SiteID,
		'1900-01-01',
		StageDischargeA,
		StageDischargeB,
		StageDischargeC,
		'admin',
		'admin'
	FROM SandbarSites
	WHERE (StageDischargeA IS NOT NULL)
		AND (StageDischargeB IS NOT NULL)
		AND (StageDischargeC IS NOT NULL);

-- Need to drop the sandbar view before dropping the stage discharge columns.
DROP VIEW vwSandbarSites;

CREATE VIEW vwSandbarSites AS
SELECT S.SiteID
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
    , RC.SiteCode AS CameraSiteCode
    , RC.BestPhotoTime
    , S.Northing
    , S.Easting
    , S.Latitude
    , S.Longitude
    , S.InitialSurvey
    , S.Remarks
    , S.AddedOn
    , S.AddedBy
    , S.UpdatedOn
    , S.UpdatedBy
FROM SandbarSites S
    INNER JOIN LookupListItems RS ON S.RiverSideID = RS.ItemID
    INNER JOIN LookupListItems ST ON S.SiteTypeID = ST.ItemID
    LEFT JOIN Reaches R ON S.ReachID = R.ReachID
    LEFT JOIN Segments Seg ON S.SegmentID = Seg.SegmentID
    LEFT JOIN RemoteCameras RC ON S.RemoteCameraID = RC.CameraID
ORDER BY S.SiteCode;

ALTER TABLE SandbarSites DROP COLUMN StageDischargeA;
ALTER TABLE SandbarSites DROP COLUMN StageDischargeB;
ALTER TABLE SandbarSites DROP COLUMN StageDischargeC;
