CREATE PROCEDURE [dbo].[Sp_Insert_Sides]
	@SIDE_NO int=NULL,
	@SIDE_TYPE int=NULL,
	@SIDE_A_NAME nvarchar (max)= NULL,
	@SIDE_E_NAME nvarchar (max)= NULL,
	@AD_U_ID int = NULL,
	@AD_DATE datetime = NULL,
	@AD_TRMNL_NM nvarchar (50)= NULL
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