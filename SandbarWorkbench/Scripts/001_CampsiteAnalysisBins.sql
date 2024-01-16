ALTER TABLE AnalysisBins ADD COLUMN BinType TEXT CHECK(BinType IN ('AnalysisBins', 'CampsiteBins')) NOT NULL DEFAULT 'AnalysisBins';

INSERT INTO AnalysisBins (Title, LowerDischarge, UpperDischarge, IsActive, DisplayColor, AddedBy, UpdatedBy, BinType) VALUES ('Below 10k bin', 10000, 15000, 1, '#1f78b4', 'admin', 'admin', 'CampsiteBins');
INSERT INTO AnalysisBins (Title, LowerDischarge, UpperDischarge, IsActive, DisplayColor, AddedBy, UpdatedBy, BinType) VALUES ('10k to 25k bin', 15000, 25000, 1, '#33a02c', 'admin', 'admin', 'CampsiteBins');
INSERT INTO AnalysisBins (Title, LowerDischarge, UpperDischarge, IsActive, DisplayColor, AddedBy, UpdatedBy, BinType) VALUES ('Above 25k bin', 25000, NULL, 1, '#ff7f00', 'admin', 'admin', 'CampsiteBins');

CREATE TABLE ModelResultsCampsites
(
	RunID INT NOT NULL REFERENCES ModelRuns(LocalRunID) ON DELETE CASCADE,
	SurveyID INT NOT NULL REFERENCES SandbarSurveys(SurveyID) ON DELETE CASCADE,
	BinID INT NOT NULL REFERENCES AnalysisBins(BinID) ON DELETE CASCADE,
	CampsiteShapeFile TEXT,
	Area REAL
);

CREATE VIEW vwCampsiteResults AS
SELECT 
    MR.RunID,
	S.SiteID,
	S.SiteCode,
	SS.SurveyID,
	SS.SurveyDate,
	SS.TripID,
	MR.BinID,
	B.LowerDischarge,
	B.UpperDischarge,
	MR.Area
FROM ModelResultsCampsites MR
	INNER JOIN SandbarSurveys SS ON MR.SurveyID = SS.SurveyID
	INNER JOIN SandbarSites S ON SS.SiteID = S.SiteID
	INNER JOIN AnalysisBins B ON MR.BinID = B.BinID;