CREATE TABLE [dbo].[SS_Users]
(
    [U_ID] [int] NOT NULL PRIMARY KEY,
	[U_NAME] [nvarchar](max)  NULL,
	EMAIL [nvarchar](max)  NULL,
	[USR_PASSWORD] [nvarchar](max) NOT NULL,
	[INACTIVE] [bit] NULL,
	[UNIT_NO] [int] NULL,
	[AD_U_ID] [int] NULL,
	[AD_DATE] [datetime] NULL,
	[UP_U_ID] [int] NULL,
	[UP_DATE] [datetime] NULL,
	[AD_TRMNL_NM] [nvarchar](50) NULL,
	[UP_TRMNL_NM] [nvarchar](50) NULL, 
)
