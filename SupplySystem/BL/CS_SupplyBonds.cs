using SupplySystem.DAL;
using SupplySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupplySystem.BL
{
    public class CS_SupplyBonds
    {
        DataAccessLayer access = new DataAccessLayer();
        public DataTable GetSupplyBonds()
        {
            return access.SelectDate("select * from SS_SupplyBonds");
        }
        public DataTable GetSupplyBondsById(int opid)
        {
            return access.SelectDate("select * from SS_SupplyBonds where OP_ID=" + opid + "");
        }
        public int GetSerialNoByDate(string juliateDate)
        {
            int count = access.SelectDate("select * from SS_SupplyBonds where JULIAN_DATE=" + juliateDate + "")
                .Rows.Count;
            if (count == 0)
            {
                return 1;
            }
            else return count + 1;
        }
        public int MaxId()
        {
            var count = access.SelectDate("select * from SS_SupplyBonds").Rows.Count;
            if (count == 0)
            {
                return 1;
            }
            else return count + 1;
        }
        public bool InsertUpdateSupplyBonds(SupplyBondsModel t,int AddorUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[18];
            parameters[0] = new SqlParameter("@OP_ID", SqlDbType.Int);
            parameters[0].Value = t.OP_ID;

            parameters[1] = new SqlParameter("@COMPLETION_DATE", SqlDbType.NVarChar, 10);
            parameters[1].Value = t.COMPLETION_DATE;

            parameters[2] = new SqlParameter("@FIELD_PRIORITY", SqlDbType.NVarChar, 50);
            parameters[2].Value = t.FIELD_PRIORITY;

            parameters[3] = new SqlParameter("@FOLLOW_UP_DATE", SqlDbType.NVarChar, 10);
            parameters[3].Value = t.FOLLOW_UP_DATE;

            parameters[4] = new SqlParameter("@INITIAL_SIGNATURE", SqlDbType.NVarChar, 50);
            parameters[4].Value = t.INITIAL_SIGNATURE;

            parameters[5] = new SqlParameter("@JULIAN_DATE", SqlDbType.NVarChar, 10);
            parameters[5].Value = t.JULIAN_DATE;

            parameters[6] = new SqlParameter("@NOTES_SIDE_NO", SqlDbType.Int);
            parameters[6].Value = t.NOTES_SIDE_NO;

            parameters[7] = new SqlParameter("@OP_DATE", SqlDbType.DateTime);
            parameters[7].Value = t.OP_DATE;

            parameters[8] = new SqlParameter("@RECEIVED_QTY", SqlDbType.Int);
            parameters[8].Value = t.RECEIVED_QTY;

            parameters[9] = new SqlParameter("@REQUEST_FOR", SqlDbType.NVarChar, 50);
            parameters[9].Value = t.REQUEST_FOR;

            parameters[10] = new SqlParameter("@REQUIRED_QTY", SqlDbType.Int);
            parameters[10].Value = t.REQUIRED_QTY;

            parameters[11] = new SqlParameter("@SEND_TO_SIDE_NO", SqlDbType.Int);
            parameters[11].Value = t.SEND_TO_SIDE_NO;

            parameters[12] = new SqlParameter("@SERIAL_NO", SqlDbType.NVarChar, 10);
            parameters[12].Value = t.SERIAL_NO;

            parameters[13] = new SqlParameter("@WAITING_ENTRY_QTY", SqlDbType.Int);
            parameters[13].Value = t.WAITING_ENTRY_QTY;

            parameters[14] = new SqlParameter("@StorageNumber", SqlDbType.NVarChar, 50);
            parameters[14].Value = t.StorageNumber;

            string SpName = string.Empty;
            if (AddorUpdate == 1)
            {
                parameters[15] = new SqlParameter("@AD_U_ID", SqlDbType.Int);
                parameters[15].Value = t.AD_U_ID;

                parameters[16] = new SqlParameter("@AD_DATE", SqlDbType.DateTime);
                parameters[16].Value = t.AD_DATE;

                parameters[17] = new SqlParameter("@AD_TRMNL_NM", SqlDbType.NVarChar);
                parameters[17].Value = t.AD_TRMNL_NM;

                SpName = "Sp_Insert_SupplyBonds";
            }
            else if (AddorUpdate == 2)
            {
                parameters[15] = new SqlParameter("@UP_U_ID", SqlDbType.Int);
                parameters[15].Value = t.UP_U_ID;

                parameters[16] = new SqlParameter("@UP_DATE", SqlDbType.DateTime);
                parameters[16].Value = t.UP_DATE;

                parameters[17] = new SqlParameter("@UP_TRMNL_NM", SqlDbType.NVarChar);
                parameters[17].Value = t.UP_TRMNL_NM;

                SpName = "Sp_Update_SupplyBonds";
            }

            if (access.InsertUpdateData(parameters, SpName) == true)
            {
                return true;
            }
            else return false;
        }

        internal void DeleteSides(int opid)
        {
            access.InsertUpdateDeleteData("delete SS_SupplyBonds where OP_ID=" + opid + "");
        }
    }
}