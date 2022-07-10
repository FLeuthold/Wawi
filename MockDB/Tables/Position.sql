CREATE TABLE [dbo].[Position]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtikelId] INT NULL, 
    [Menge] INT NULL DEFAULT 1, 
    [BelegId] INT NULL
)
