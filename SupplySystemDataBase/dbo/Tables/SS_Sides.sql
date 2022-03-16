CREATE TABLE [dbo].[SS_Sides]
(
    [SIDE_NO]     INT            NOT NULL,
    [SIDE_TYPE]   INT            NOT NULL,
    [SIDE_A_NAME] NVARCHAR (MAX) NULL,
    [SIDE_E_NAME] NVARCHAR (MAX) NULL, 
    [AD_U_ID] [int] NULL,
	[AD_DATE] [datetime] NULL,
	[UP_U_ID] [int] NULL,
	[UP_DATE] [datetime] NULL,
	[AD_TRMNL_NM] [nvarchar](50) NULL,
	[UP_TRMNL_NM] [nvarchar](50) NULL,
    CONSTRAINT [PK_SS_Sides] PRIMARY KEY ([SIDE_NO], [SIDE_TYPE]),
);
