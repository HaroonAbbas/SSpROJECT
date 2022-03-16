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
    public class CS_Sides
    {
        DAL.DataAccessLayer access = new DAL.DataAccessLayer();
        public DataTable GetSides(int type)
        {
            return access.SelectDate("select * from SS_Sides where SIDE_TYPE=" + type + "");
        }
        public DataTable ConfSides_SEND_TO_SIDE_NO_InSupplyBonds(int SEND_TO_SIDE_NO)
        {
            return access.SelectDate("select * from SS_SupplyBonds where SEND_TO_SIDE_NO=" + SEND_TO_SIDE_NO + "");
        }
        public DataTable ConfSides_NOTES_SIDE_NO_nSupplyBonds(int NOTES_SIDE_NO)
        {
            return access.SelectDate("select * from SS_SupplyBonds where NOTES_SIDE_NO=" + NOTES_SIDE_NO + "");
        }
        public int MaxId(int type)
        {
            int max = 1;
            if (GetSides(type).Rows.Count > 0)
            {
                var dt = access.SelectDate("select  MAX(SIDE_NO)+1 SIDE_NO from SS_Sides where SIDE_TYPE=" + type + "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    max = int.Parse(dt.Rows[0][0].ToString());
                }
            }
            else
            {
                max = 1;
            }
            return max;
        }
        public bool InsertUpdateSides(SidesModel t, int AddorUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@SIDE_NO", SqlDbType.Int);
            parameters[0].Value = t.SIDE_NO;

            parameters[1] = new SqlParameter("@SIDE_A_NAME", SqlDbType.NVarChar, 50);
            parameters[1].Value = t.SIDE_A_NAME;

            parameters[2] = new SqlParameter("@SIDE_E_NAME", SqlDbType.NVarChar, 50);
            parameters[2].Value = t.SIDE_E_NAME;

            parameters[3] = new SqlParameter("@SIDE_TYPE", SqlDbType.Int);
            parameters[3].Value = t.SIDE_TYPE;

            string SpName = string.Empty;
            if (AddorUpdate == 1)
            {
                parameters[4] = new SqlParameter("@AD_U_ID", SqlDbType.Int);
                parameters[4].Value = t.AD_U_ID;

                parameters[5] = new SqlParameter("@AD_DATE", SqlDbType.DateTime);
                parameters[5].Value = t.AD_DATE;

                parameters[6] = new SqlParameter("@AD_TRMNL_NM", SqlDbType.NVarChar);
                parameters[6].Value = t.AD_TRMNL_NM;

                SpName = "Sp_Insert_Sides";
            }
            else if (AddorUpdate == 2)
            {
                parameters[4] = new SqlParameter("@UP_U_ID", SqlDbType.Int);
                parameters[4].Value = t.UP_U_ID;

                parameters[5] = new SqlParameter("@UP_DATE", SqlDbType.DateTime);
                parameters[5].Value = t.UP_DATE;

                parameters[6] = new SqlParameter("@UP_TRMNL_NM", SqlDbType.NVarChar);
                parameters[6].Value = t.UP_TRMNL_NM;

                SpName = "Sp_Update_Sides";
            }
            
            if (access.InsertUpdateData(parameters, SpName) == true)
            {
                return true;
            }
            else return false;
        }
        public bool DeleteSides(SidesModel t)
        {
            string add = "Delete SS_Sides where SIDE_NO = " + t.SIDE_NO + " and SIDE_TYPE=" + t.SIDE_TYPE + "";

            if (access.InsertUpdateDeleteData(add) == true)
            {
                return true;
            }
            else return false;
        }

    }
}