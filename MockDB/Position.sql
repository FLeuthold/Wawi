CREATE TABLE [dbo].[Position]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [artikel_id] INT NULL, 
    [menge] INT NULL DEFAULT 1, 
    [bestellung_id] INT NULL
)
