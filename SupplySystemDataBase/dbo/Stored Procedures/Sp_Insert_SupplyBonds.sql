CREATE PROCEDURE [dbo].[Sp_Insert_SupplyBonds]
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
	@NOTES_SIDE_NO int ,
    @AD_U_ID int = NULL,
	@AD_DATE datetime = NULL,
	@AD_TRMNL_NM nvarchar (50)= NULL
AS
	
INSERT INTO [dbo].[SS_SupplyBonds]
           ([OP_ID]
           ,[OP_DATE]
           ,[JULIAN_DATE]
           ,[SERIAL_NO]
           ,[SEND_TO_SIDE_NO]
           ,[StorageNumber]
           ,[REQUEST_FOR]
           ,[FIELD_PRIORITY]
           ,[INITIAL_SIGNATURE]
           ,[REQUIRED_QTY]
           ,[RECEIVED_QTY]
           ,[WAITING_ENTRY_QTY]
           ,[FOLLOW_UP_DATE]
           ,[COMPLETION_DATE]
           ,[NOTES_SIDE_NO]
           ,[AD_U_ID]
           ,[AD_DATE]
           ,[AD_TRMNL_NM])
     VALUES
           (@OP_ID                           
           ,@OP_DATE                         
           ,@JULIAN_DATE                     
           ,@SERIAL_NO                       
           ,@SEND_TO_SIDE_NO                 
           ,@StorageNumber                   
           ,@REQUEST_FOR                     
           ,@FIELD_PRIORITY                  
           ,@INITIAL_SIGNATURE               
           ,@REQUIRED_QTY                    
           ,@RECEIVED_QTY                    
           ,@WAITING_ENTRY_QTY               
           ,@FOLLOW_UP_DATE                  
           ,@COMPLETION_DATE                 
           ,@NOTES_SIDE_NO
           ,@AD_U_ID                     
           ,@AD_DATE                     
           ,@AD_TRMNL_NM )

RETURN