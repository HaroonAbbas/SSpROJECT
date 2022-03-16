CREATE PROCEDURE [dbo].[Sp_Update_Sides]
	@SIDE_NO int=NULL,
	@SIDE_TYPE int=NULL,
	@SIDE_A_NAME nvarchar (max)= NULL,
	@SIDE_E_NAME nvarchar (max)= NULL,
	@UP_U_ID int = NULL,
	@UP_DATE datetime = NULL,
	@UP_TRMNL_NM nvarchar (50)= NULL
AS
begin
UPDATE dbo.SS_Sides
   SET   
 SIDE_NO = @SIDE_NO            
,SIDE_TYPE = @SIDE_TYPE       
,SIDE_A_NAME = @SIDE_A_NAME    
,SIDE_E_NAME = @SIDE_E_NAME    
,UP_U_ID = @UP_U_ID            
,UP_DATE = @UP_DATE            
,UP_TRMNL_NM = @UP_TRMNL_NM    
where SIDE_NO=@SIDE_NO and SIDE_TYPE=@SIDE_TYPE
end 