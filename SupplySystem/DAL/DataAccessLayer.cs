
using SupplySystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace SupplySystem.DAL
{
    public class DataAccessLayer
    {
        public SqlConnection _sqlConnection = new SqlConnection();
        //public string _connectionstring = "Data Source = (localdb)\\MSSQLLocalDB;Integrated Security = True; Database=SSDBnew;";
        public string _connectionstring = ConfigurationManager.ConnectionStrings["SSDBConn"].ConnectionString;

        public DataAccessLayer()
        {
            _sqlConnection = new SqlConnection(_connectionstring);
        }
        public void OpenConn()
        {
            try
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
            }
            catch (Exception ex){
                MessageBoxShowing.Show("الاتصال بقواعد البيانات", ex.Message, MessageBoxButton.OK);
            }
        }
        public void CloseConn()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }
        public void CloseAllConnection()
        {
            //USE[master];
            //DECLARE @kill varchar(8000) = '';
            //SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
            //FROM sys.dm_exec_sessions
            //WHERE database_id = db_id('SSDB')
            //EXEC(@kill);
            string script = File.ReadAllText("closesCons.sql"); //file included in debug folder 
            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            SqlConnection _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    using (var command = new SqlCommand(commandString, _connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            _connection.Close();
            _connection.Dispose();
        }
        public DataTable SelectDate(string command)
        {
            OpenConn();
            SqlCommand cmd = new SqlCommand(command, _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConn();
            return dt;
        }
        public bool InsertUpdateDeleteData(string command)
        {
            OpenConn();
            bool returend = false;
            SqlCommand cmd = new SqlCommand(command, _sqlConnection);
            Clipboard.SetText(command);
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                returend = true;
            }
            else returend = false;
            CloseConn();
            return returend;
        }
        public bool InsertUpdateData(SqlParameter[] sqlParameters,string SpName)
        {
            OpenConn();
            bool returend = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SpName;
            if (sqlParameters!=null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                returend = true;
            }
            else returend = false;
            CloseConn();
            return returend;
        }
        public void BackUpDatabase(string fileName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                    ("BACKUP DATABASE SSDBnew TO DISK ='" + fileName + "'"
                    , _sqlConnection);
                Clipboard.SetText(cmd.CommandText);
                OpenConn();
                cmd.ExecuteNonQuery();
                CloseConn();
                MessageBoxShowing.Show("النسخ الاحتياطي", "تم عمل نسخة احتياطية بنجاح",
                    MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show("النسخ الاحتياطي", ex.Message,
                    MessageBoxButton.OK);
            }
        }
        public void RestoreDatabase(string fileName)
        {
            try
            {
                string qyery = "use master alter database SSDBnew set single_user with rollback immediate";
                qyery += " RESTORE DATABASE SSDBnew FROM DISK = '" + fileName + "' WITH REPLACE";
                SqlCommand cmd = new SqlCommand(qyery, _sqlConnection);
                Clipboard.SetText(cmd.CommandText);
                OpenConn();
                cmd.ExecuteNonQuery();
                CloseConn();
                MessageBoxShowing.Show("النسخ الاحتياطي", "تم استرجاع النسخة الاحتياطية بنجاح",
              MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show("النسخ الاحتياطي", ex.Message,
                    MessageBoxButton.OK);
            }
        }
    }
}