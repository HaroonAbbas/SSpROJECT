CREATE TABLE [dbo].[Units] (
    [Id]         INT            NOT NULL,
    [UnitName]   NVARCHAR (800) NOT NULL,
    [UnitIdName] NVARCHAR (800) NOT NULL,
    [BackUpPath] NVARCHAR (800)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

