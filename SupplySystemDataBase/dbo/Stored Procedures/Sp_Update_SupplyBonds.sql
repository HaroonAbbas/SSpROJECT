CREATE PROCEDURE [dbo].[Sp_Update_SupplyBonds]
	@OP_ID int,
	@OP_DATE  datetime              ,
	@JULIAN_DATE nvarchar(10)       ,
	@SERIAL_NO nvarchar(10)         ,
	@SEND_TO_SIDE_NO int            ,
	@StorageNumber nvarchar(50)     ,
	@REQUEST_FOR nvarchar(50)       ,
	@FIELD_PRIORITY nvarchar(50)    ,
	@INITIAL_SIGNATURE nvarchar(50) ,
	@REQUIRED_QTY int               ,
	@RECEIVED_QTY int               ,
	@WAITING_ENTRY_QTY int          ,
	@FOLLOW_UP_DATE nvarchar(10)    ,
	@COMPLETION_DATE nvarchar(10)   ,
	@NOTES_SIDE_NO int              ,
		@UP_U_ID int = NULL,
	@UP_DATE datetime = NULL,
	@UP_TRMNL_NM nvarchar (50)= NULL
AS
	UPDATE SS_SupplyBonds
	   SET OP_ID = @OP_ID,                            
	      OP_DATE = @OP_DATE,                         
	      JULIAN_DATE = @JULIAN_DATE,                 
	      SERIAL_NO = @SERIAL_NO,                     
	      SEND_TO_SIDE_NO = @SEND_TO_SIDE_NO,         
	      StorageNumber = @StorageNumber,             
	      REQUEST_FOR = @REQUEST_FOR,                 
	      FIELD_PRIORITY = @FIELD_PRIORITY,           
	      INITIAL_SIGNATURE = @INITIAL_SIGNATURE,     
	      REQUIRED_QTY = @REQUIRED_QTY,               
	      RECEIVED_QTY = @RECEIVED_QTY,               
	      WAITING_ENTRY_QTY = @WAITING_ENTRY_QTY,     
	      FOLLOW_UP_DATE = @FOLLOW_UP_DATE,           
	      COMPLETION_DATE = @COMPLETION_DATE,         
	      NOTES_SIDE_NO = @NOTES_SIDE_NO  
		  ,UP_U_ID = @UP_U_ID            
,UP_DATE = @UP_DATE            
,UP_TRMNL_NM = @UP_TRMNL_NM    
	 WHERE OP_ID = @OP_ID
RETURN