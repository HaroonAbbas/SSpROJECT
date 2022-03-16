CREATE PROCEDURE [dbo].Sp_Get_SupplyBonds
	--@OP_ID int,
	@JULIAN_DATE nvarchar(10)       
	--@SERIAL_NO nvarchar(10)         
AS
	SELECT P.OP_ID
      ,P.OP_DATE
      ,P.JULIAN_DATE
      ,P.SERIAL_NO      
      ,P.StorageNumber
      ,P.REQUEST_FOR
      ,P.FIELD_PRIORITY
      ,P.INITIAL_SIGNATURE
      ,P.REQUIRED_QTY
      ,P.RECEIVED_QTY
      ,P.WAITING_ENTRY_QTY
      ,P.FOLLOW_UP_DATE
      ,P.COMPLETION_DATE
	,(SELECT SIDE_A_NAME FROM SS_Sides WHERE SIDE_TYPE=1 AND SIDE_NO=P.SEND_TO_SIDE_NO) SEND_TO_SIDE_NO
	  ,(SELECT SIDE_A_NAME FROM SS_Sides WHERE SIDE_TYPE=2 AND SIDE_NO=P.NOTES_SIDE_NO) NOTES_SIDE_NO
	  	  ,u.UnitName
	  ,u.UnitIdName
	 ,parts.PieceName
  FROM SS_SupplyBonds P
  LEFT JOIN SS_SpareParts parts  ON P.StorageNumber=parts.StorageNumber
  join dbo.SS_Units u on u.UnitId=1
  where p.JULIAN_DATE=@JULIAN_DATE