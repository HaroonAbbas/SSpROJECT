CREATE TABLE [dbo].[SS_SpareParts]
(
	StorageNumber NVARCHAR(50) NOT NULL PRIMARY KEY,
	PieceName NVARCHAR(50) NOT NULL,
	[AD_U_ID] [int] NULL,
	[AD_DATE] [datetime] NULL,
	[UP_U_ID] [int] NULL,
	[UP_DATE] [datetime] NULL,
	[AD_TRMNL_NM] [nvarchar](50) NULL,
	[UP_TRMNL_NM] [nvarchar](50) NULL,
)
