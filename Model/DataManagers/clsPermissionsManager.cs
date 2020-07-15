using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using webSVNUnlocker.Model.DataAccess;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsPermissionsManager
    {
        public static Boolean HasPermission(clsPermissions objPermission)
        {
            try
            {
                String strSQL = "";// "SELECT COUNT(*) FROM viewUsersTasks WHERE (chUsername = '" + objHasPermission.strUsername + "' AND chPageURL = '" + objHasPermission.strPageURL + "');";

                clsDBMS objDBMS = new clsDBMS();
                DataTable objDataTable;

                objDataTable = objDBMS.ExecuteSelectSQL(strSQL);

                if (objDataTable.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }
    }
}