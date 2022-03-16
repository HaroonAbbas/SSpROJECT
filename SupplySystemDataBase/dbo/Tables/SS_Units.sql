CREATE TABLE [dbo].[SS_Units]
(
	[UnitId] INT NOT NULL PRIMARY KEY, 
    [UnitName] NVARCHAR(800) NOT NULL, 
    [UnitIdName] NVARCHAR(800) NOT NULL,
    BackUpPath nvarchar(800) null,
)
