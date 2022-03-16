CREATE PROCEDURE [dbo].[Sp_Update_SpareParts]
		@PieceName nvarchar(max)=null,
	@StorageNumber	nvarchar(max)=null,
	@UP_U_ID int = NULL,
	@UP_DATE datetime = NULL,
	@UP_TRMNL_NM nvarchar (50)= NULL
AS
begin
UPDATE dbo.SS_SpareParts
   SET StorageNumber = @StorageNumber        
      ,PieceName = @PieceName                
      ,UP_U_ID = @UP_U_ID                    
      ,UP_DATE = @UP_DATE                    
      ,UP_TRMNL_NM = @UP_TRMNL_NM
WHERE StorageNumber=@StorageNumber
end