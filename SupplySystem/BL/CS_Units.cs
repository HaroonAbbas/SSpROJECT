using SupplySystem.DAL;
using SupplySystem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
 
namespace SupplySystem.BL
{
    public class CS_Units
    {
        DataAccessLayer access = new DataAccessLayer();
        public DataTable GetUnits()
        {
            return access.SelectDate("select * from SS_Units");
        }
        public bool InsertUnit(UnitsModel t)
        {
            string add = "Insert into SS_Units(UnitId, UnitName, UnitIdName,BackUpPath) " +
                  "values(" + t.UnitId + ",'" + t.UnitName + "','" + t.UnitIdName+"','Empty')";
            
            if (access.InsertUpdateDeleteData(add) == true)
            {
                return true;
            }
            else return false;
        }
    }
}