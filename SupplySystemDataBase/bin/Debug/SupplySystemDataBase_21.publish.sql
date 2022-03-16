﻿/*
Deployment script for SSDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SSDB"
:setvar DefaultFilePrefix "SSDB"
:setvar DefaultDataPath "C:\Users\DELL\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\DELL\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Table [dbo].[SS_Sides]...';


GO
CREATE TABLE [dbo].[SS_Sides] (
    [SIDE_NO]     INT            NOT NULL,
    [SIDE_A_NAME] NVARCHAR (MAX) NULL,
    [SIDE_E_NAME] NVARCHAR (MAX) NULL,
    [SIDE_TYPE]   INT            NULL,
    PRIMARY KEY CLUSTERED ([SIDE_NO] ASC)
);


GO
PRINT N'Update complete.';


GO