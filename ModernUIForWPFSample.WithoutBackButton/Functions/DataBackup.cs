using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    
    class DataBackup
    {
        
        static string DATABASENAME = "adoraDB";
        static string SEVERNAME = "localhost";
        
        static string CONNECTIONSTRING = "Server=" + SEVERNAME + ";Database=" + DATABASENAME + ";Trusted_Connection=True;";
        static string CONNECTIONSTRINGRE = "Server=" + SEVERNAME + "; Trusted_Connection=True;";


        private SqlConnection conn;
        private SqlCommand command;
        //private SqlDataReader reader;
        string sql = "";

                
        public bool restoreDatabase(String filePath)
        {

            try
            {
                conn = new SqlConnection(CONNECTIONSTRINGRE);
                conn.Open();
                sql = "Alter Database adoraDB Set SINGLE_USER WITH ROLLBACK IMMEDIATE; Restore Database adoraDB FROM Disk= '" + filePath + "' WITH REPLACE;";
                //sql = "Alter Database adora Set SINGLE_USER WITH ROLLBACK IMMEDIATE; Restore Database adora FROM Disk= 'F:\\a\\axxxsa.bak' WITH REPLACE;";
                command = new SqlCommand(sql, conn);
                command.CommandTimeout = 90;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                return false;
            }
        }
        public bool backup(String filePath)
        {
            try
            {

                conn = new SqlConnection(CONNECTIONSTRINGRE);
                conn.Open();
                sql = "BACKUP DATABASE adoraDB TO DISK ='" + filePath + "' ";
                //sql = "BACKUP DATABASE adora TO DISK ='F:\\a\\axxxsa.bak' ";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        

       
                    
        
    }
}
