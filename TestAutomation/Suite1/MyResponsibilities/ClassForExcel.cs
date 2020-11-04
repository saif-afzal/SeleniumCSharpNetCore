using System;
using System.Data;
using System.Windows.Forms;
//using Microsoft.Office.Core;
using System.Data.OleDb;

using System.Threading;

namespace MyExcel
{
    #region open a Excel file and read from it
    public class ReadExcel
    {
        DataTable dtCSV;
       
        public DataTable getCitationFromXLS(string strFilePath, string sheet,int startrowid)   //For Citalink
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                //OleDbCommand cmdSelect = new OleDbCommand("SELECT * from [" + sheet + "] where Citalink='Notes Not available'", _connection);
                OleDbCommand cmdSelect = new OleDbCommand("SELECT * from [" + sheet + "$] where ID between "+ startrowid.ToString()+" and 1000", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;
                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);
            
              
                _connection.Close();
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        
        public DataTable getRepositoryforregression(string strFilePath, string sheet)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT source from [" + sheet + "$] where type='Regression Repository'", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable getversionforbrowsers(string strFilePath, string sheet, string browser)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT [" + browser + "]  from [" + sheet + "$] ", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable setappconfig(string strFilePath, string sheet,string Key,string WriteConfig)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT *  from [" + sheet + "$] where WriteConfig ='" + WriteConfig + "'", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable CheckBlankStatus(string strFilePath, string sheet, string Status)
        {
            try
            {
               // Status = null;
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT *  from [" + sheet + "$] where Status ='" + Status + "'", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable CheckTotal(string strFilePath, string sheet)
        {
            try
            {
                // Status = null;
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT *  from [" + sheet + "$] ", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable browserstackUser(string strFilePath, string sheet, string Key, string WriteConfig)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT *  from [" + sheet + "$] ", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable getRepositoryforsmoke(string strFilePath, string sheet)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT source from [" + sheet + "$] where type='Smoke Repository'", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;
                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }

        public DataTable loadurlfromexcel(string strFilePath, string sheet, string urlid="")
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

              "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT URL from [" + sheet + "$] where ID like'%"+urlid+"%'", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;
                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }
        public DataTable getBlank(string strFilePath, string sheet)
        {
            try
            {
                string strConnectionString = string.Empty;
                string _conn;

                _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

                "Extended Properties=Excel 12.0;";

                OleDbConnection _connection = new OleDbConnection(_conn);

                _connection.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT *  from [" + sheet + "$] WHERE Status IS null ", _connection);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                dtCSV = new DataTable();
                daCSV.Fill(dtCSV);

                _connection.Close();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("No value given for one or more required parameters."))
                    MessageBox.Show(ex.Message);
            }
            return dtCSV;
        }

    #endregion
    }

    #region writing in excel
   public class WriteExcel
    {
       public void InsertDataInXLS(string strFilePath, string sheet,string path)
       {
           try
           {
               string strConnectionString = string.Empty;
               string _conn;

               _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

            "Extended Properties=Excel 12.0;";
               OleDbConnection _connection = new OleDbConnection(_conn);

               _connection.Open();

               string sql = "UPDATE [" + sheet + "$] SET source='"+path+"' WHERE type='Regression Repository'";
               OleDbCommand cmdInsert = new OleDbCommand(sql, _connection);
               cmdInsert.ExecuteNonQuery();

               _connection.Close();
               //  OleDbConnection _connection = new OleDbConnection(_conn);
               //  OleDbCommand cmdInsert = _connection.CreateCommand();
               //  cmdInsert.CommandText = "Update [Setting$] SET value='abc' where setting='Regression Repository'";
               ////  cmdInsert.CommandText = "Update [" + sheet + "$] SET " + column + "='" + data + "' where setting='" + row+"'";
               //  _connection.Open();
               //  cmdInsert.ExecuteNonQuery();
               //  _connection.Close();
           }
           catch (Exception ex)
           {
               if (!ex.Message.Equals("No value given for one or more required parameters."))
                   MessageBox.Show("Err in excel write " + ex.Message);
           }
       }
       public void InsertDataInXLSUpdate(string strFilePath, string sheet,string text)
       {
         
               string strConnectionString = string.Empty;
               string _conn;

               _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

            "Extended Properties=Excel 12.0;";
               OleDbConnection _connection = new OleDbConnection(_conn);
               string insertStatement = "INSERT INTO [Browsers$] " +
                            "([Browser],[Execute]) " +
                            "VALUES (?,?)";
               try
               {
                   OleDbCommand insertCommand = new OleDbCommand(insertStatement, _connection);
                   insertCommand.Parameters.AddWithValue("@Browser", text);
                   insertCommand.Parameters.AddWithValue("@Execute", "yes");

               _connection.Open();
               insertCommand.ExecuteNonQuery();
         

               _connection.Close();
               //  OleDbConnection _connection = new OleDbConnection(_conn);
               //  OleDbCommand cmdInsert = _connection.CreateCommand();
               //  cmdInsert.CommandText = "Update [Setting$] SET value='abc' where setting='Regression Repository'";
               ////  cmdInsert.CommandText = "Update [" + sheet + "$] SET " + column + "='" + data + "' where setting='" + row+"'";
               //  _connection.Open();
               //  cmdInsert.ExecuteNonQuery();
               //  _connection.Close();
           }
           catch (Exception ex)
           {
               if (!ex.Message.Equals("No value given for one or more required parameters."))
                   MessageBox.Show("Err in excel write " + ex.Message);
           }
       }
       public void UpdateDataInXLSUpdate(string strFilePath, string sheet, string url)
       {

           string strConnectionString = string.Empty;
           string _conn;
           string Status = "";
           _conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + strFilePath + ";" +

        "Extended Properties=Excel 12.0;";
           OleDbConnection _connection = new OleDbConnection(_conn);
           string updateStatement = "UPDATE [Credentials$] SET Status = '" + @Status + "'";
           try
           {
               OleDbCommand updateCommand = new OleDbCommand(updateStatement, _connection);
               updateCommand.Parameters.AddWithValue("@URL", url);
               //     updateCommand.Parameters.AddWithValue("@Status", "yes");

               _connection.Open();
               int rowsAffeted = updateCommand.ExecuteNonQuery();


               _connection.Close();
               //  OleDbConnection _connection = new OleDbConnection(_conn);
               //  OleDbCommand cmdInsert = _connection.CreateCommand();
               //  cmdInsert.CommandText = "Update [Setting$] SET value='abc' where setting='Regression Repository'";
               ////  cmdInsert.CommandText = "Update [" + sheet + "$] SET " + column + "='" + data + "' where setting='" + row+"'";
               //  _connection.Open();
               //  cmdInsert.ExecuteNonQuery();
               //  _connection.Close();
           }
           catch (Exception ex)
           {
               if (!ex.Message.Equals("No value given for one or more required parameters."))
                   MessageBox.Show("Err in excel write " + ex.Message);
           }
       }
    #endregion

    }
}