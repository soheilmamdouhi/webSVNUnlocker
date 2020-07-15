using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace webSVNUnlocker.Model.DataAccess
{
    public class clsDBMS
    {
        OracleConnection objOracleConnection;
        OracleCommand objOracleCommand;

        public clsDBMS()
        {
            objOracleConnection = new OracleConnection();
            objOracleCommand = new OracleCommand();

            objOracleCommand.Connection = objOracleConnection;

            objOracleConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SVNUnlockerDS"].ConnectionString;
        }

        public void ExecuteSQL(String strSQL)
        {
            try
            {
                objOracleCommand.CommandText = strSQL;

                objOracleConnection.Open();
                objOracleCommand.ExecuteNonQuery();
                objOracleConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public DataTable ExecuteSelectSQL(String strSQL)
        {
            try
            {
                objOracleCommand.CommandText = strSQL;

                OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter(objOracleCommand);
                DataTable objDataTable = new DataTable();

                objOracleDataAdapter.Fill(objDataTable);

                return objDataTable;
            }
            catch (Exception ex)
            {
                //throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}