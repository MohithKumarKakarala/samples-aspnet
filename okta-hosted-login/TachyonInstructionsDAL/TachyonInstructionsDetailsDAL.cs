using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Web;
using System.Web.Services;

namespace DXC.Tachyon.TachyonInstructionsDAL
{
    public static class FileHelper
    {
        public static async Task CopyFileAsync(string sourceFile, string destinationFile)
        {
            await Task.Run(() => File.Copy(sourceFile, destinationFile, true));
        }
    }

    public static class TachyonInstructionsDetailsDAL
    {
        public static SQLiteCommand cmd = null;
        public static DataTable dt = new DataTable();
        public static SQLiteDataAdapter da = null;
        public static SQLiteConnection con = null;// new SQLiteConnection("Data Source=/App_Data/TachyonInstructions.db");

        public static SQLiteConnection connect()
        {
            con = new SQLiteConnection(@"Data Source=/App_Data/TachyonInstructions.db");

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                else con.Open();
            }
            catch (Exception ex)
            {
                return con;
            }

            return con;

        }

        public static bool DMLOpperation(string query)
        {
            cmd = new SQLiteCommand(query, connect());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable SelactAll(string query)
        {
            da = new SQLiteDataAdapter(query, connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        [WebMethod]
        public static void GetName(string instructionID)
        {
            DataTable dt = new DataTable();
            SQLiteConnection SQLiteConnection = null;

            try
            {
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + ChopBackSlashFromPath(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath) + @"\App_Data\TachyonInstructions.db");

                string SelectQuery = @"SELECT    InstructionID,InstructionName, InstructionReadablePayload, InstructionDescription, InstructionTtlMinutes, InstructionResponseTtlMinutes, InstructionAuthor,  InstructionPayload, InstructionComments, 
                                     InstructionSchemaJson, InstructionCreatedDateTime 
                                     FROM      Instructions 
                                     WHERE     InstructionID = '" + instructionID + "'";
                SQLiteConnection = new SQLiteConnection(connection);
                SQLiteDataAdapter SQLiteDataAdapter = new SQLiteDataAdapter() { SelectCommand = new SQLiteCommand(SelectQuery, SQLiteConnection) };
                dt = new DataTable();
                SQLiteConnection.Open();

                SQLiteDataAdapter.Fill(dt);

                //ErrorLogging.WriteToLogFile(string.Format("SUCCESS: Instruction data for specific Instruction - {0} has been populated.", instructionID), 0);

            }
            catch (Exception ex)
            {
                //Log Errors
                //ErrorLogging.WriteToLogFile("ERROR: " + ex.Message, 2);
            }
            finally
            {
                SQLiteConnection.Close();
            }
        }

        public static string ChopBackSlashFromPath(string strPath)
        {
            string strPathNew = string.Empty;
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(strPath);
                sb[strPath.Length - 1] = ' ';
                strPathNew = sb.ToString();
            }
            catch (Exception ex)
            {
                strPathNew = strPath;
            }
            //return System.Text.RegularExpressions.Regex.Replace(strPathNew, @"^s+$ [rn]*", string.Empty, System.Text.RegularExpressions.RegexOptions.Multiline);
            return strPathNew.Remove(strPathNew.Length - 1, 1);
        }

    }


}
