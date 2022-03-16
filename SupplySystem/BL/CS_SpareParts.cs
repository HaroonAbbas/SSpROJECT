using SupplySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplySystem.BL
{
    public class CS_SpareParts
    {
        DAL.DataAccessLayer access = new DAL.DataAccessLayer();
        public DataTable GetSpareParts()
        {
            return access.SelectDate("select * from SS_SpareParts");
        }
        public bool InsertUpdateSpareParts(SparePartsModel t,int AddorUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@StorageNumber", SqlDbType.NVarChar);
            parameters[0].Value = t.StorageNumber;

            parameters[1] = new SqlParameter("@PieceName", SqlDbType.NVarChar);
            parameters[1].Value = t.PieceName;

            string SpName = string.Empty;
            if (AddorUpdate == 1)
            {
                parameters[2] = new SqlParameter("@AD_U_ID", SqlDbType.Int);
                parameters[2].Value = t.AD_U_ID;

                parameters[3] = new SqlParameter("@AD_DATE", SqlDbType.DateTime);
                parameters[3].Value = t.AD_DATE;

                parameters[4] = new SqlParameter("@AD_TRMNL_NM", SqlDbType.NVarChar);
                parameters[4].Value = t.AD_TRMNL_NM;

                SpName = "Sp_Insert_SpareParts";
            }
            else if (AddorUpdate == 2)
            {
                parameters[2] = new SqlParameter("@UP_U_ID", SqlDbType.Int);
                parameters[2].Value = t.UP_U_ID;

                parameters[3] = new SqlParameter("@UP_DATE", SqlDbType.DateTime);
                parameters[3].Value = t.UP_DATE;

                parameters[4] = new SqlParameter("@UP_TRMNL_NM", SqlDbType.NVarChar);
                parameters[4].Value = t.UP_TRMNL_NM;

                SpName = "Sp_Update_SpareParts";
            }

            if (access.InsertUpdateData(parameters, SpName) == true)
            {
                return true;
            }
            else return false;
        }
        public DataTable ConfSpareParts(SparePartsModel t)
        {
            return access.SelectDate("select * from SS_SpareParts where StorageNumber = '" + t.StorageNumber + "'");
        }
        public DataTable ConfSparePartsInSupplyBonds(string StorageNumber)
        {
            return access.SelectDate("select * from SS_SupplyBonds where StorageNumber = '" + StorageNumber + "'");
        }
        public bool DeleteSpareParts(SparePartsModel t)
        {
            string add = "Delete SS_SpareParts where StorageNumber = '" + t.StorageNumber + "'";

            if (access.InsertUpdateDeleteData(add) == true)
            {
                return true;
            }
            else return false;
        }
    }
}