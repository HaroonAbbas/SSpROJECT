using SupplySystem.DAL;
using System.Data;

namespace SupplySystem.BL
{
    public class CS_Users
    {
        DataAccessLayer access = new DataAccessLayer();
        public DataTable IsInavtive(int U_ID, string USR_PASSWORD)
        {
            return access.SelectDate("select * from SS_Users" +
                " where U_ID =" + U_ID + " and USR_PASSWORD ='" + USR_PASSWORD + "' and INACTIVE=0");
        }
        public DataTable ConfUser(int U_ID, string USR_PASSWORD)
        {
            return access.SelectDate("select * from SS_Users" +
                " where U_ID =" + U_ID + " and USR_PASSWORD ='" + USR_PASSWORD + "'");
        }
        public DataTable GetUserById(int U_ID)
        {
            return access.SelectDate("select * from SS_Users where U_ID =" + U_ID + "");
        }
    }
}