﻿/*
Deployment script for SSDBNew

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SSDBNew"
:setvar DefaultFilePrefix "SSDBNew"
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
PRINT N'Creating Procedure [dbo].[Sp_Insert_Sides]...';


GO
CREATE PROCEDURE [dbo].[Sp_Insert_Sides]
	@SIDE_NO int  NOT NULL,
	@SIDE_TYPE int  NOT NULL,
	@SIDE_A_NAME nvarchar (max) NULL,
	@SIDE_E_NAME nvarchar (max) NULL,
	@AD_U_ID int  NULL,
	@AD_DATE datetime  NULL,
	@AD_TRMNL_NM nvarchar (50) NULL
AS
begin
	INSERT INTO [dbo].[SS_Sides]
           ([SIDE_NO]
           ,[SIDE_TYPE]
           ,[SIDE_A_NAME]
           ,[SIDE_E_NAME]
           ,[AD_U_ID]
           ,[AD_DATE]
           ,[AD_TRMNL_NM])
     VALUES
           (@SIDE_NO                     
           ,@SIDE_TYPE                   
           ,@SIDE_A_NAME                 
           ,@SIDE_E_NAME                 
           ,@AD_U_ID                     
           ,@AD_DATE                     
           ,@AD_TRMNL_NM )
end
GO
PRINT N'Update complete.';


GO
