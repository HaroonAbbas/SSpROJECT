CREATE PROCEDURE [dbo].[Sp_Insert_SpareParts]
	@PieceName nvarchar(max)=null,
	@StorageNumber	nvarchar(max)=null,
	@AD_U_ID int = NULL,
	@AD_DATE datetime = NULL,
	@AD_TRMNL_NM nvarchar (50)= NULL
AS
begin

INSERT INTO [dbo].[SS_SpareParts]
           ([StorageNumber]
           ,[PieceName]
           ,[AD_U_ID]
           ,[AD_DATE]
           ,[AD_TRMNL_NM])
     VALUES
           (@StorageNumber          
           ,@PieceName              
           ,@AD_U_ID                
           ,@AD_DATE                
           ,@AD_TRMNL_NM)
end