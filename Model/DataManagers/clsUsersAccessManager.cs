using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using webSVNUnlocker.Model.DataAccess;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsUsersAccessManager
    {
        public static void Insert(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = "INSERT INTO USERSACCESS (ID, USERID, PROJECTID, JIRACODE) VALUES (USERSACCESS_SEQ.NEXTVAL, " + objUsersAccess.UserID + ", " + objUsersAccess.ProjectID + ", '" + objUsersAccess.JIRACode + "')";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Update(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = "UPDATE USERSACCESS SET USERID = '" + objUsersAccess.UserID + "', PROJECTID = '" + objUsersAccess.ProjectID + "' WHERE ID = '" + objUsersAccess.ID + "'";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Delete(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = "DELETE FROM USERSACCESS WHERE ID = '" + objUsersAccess.ID + "'";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable USERSACCESS_VIEW()
        {
            try
            {
                String strSQL = "SELECT * FROM USERSACCESS_VIEW ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable USERSACCESS_VIEW(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = @"SELECT * FROM USERSACCESS_VIEW WHERE USERSACCESS_VIEW.""ID"" = '" + objUsersAccess.UserID + "' ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsDuplicate(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM USERSACCESS WHERE USERID = '" + objUsersAccess.UserID + "' AND PROJECTID = '" + objUsersAccess.ProjectID + "'";

                clsDBMS objDBMS = new clsDBMS();
                DataTable objIsDuplicate = new DataTable();

                objIsDuplicate = objDBMS.ExecuteSelectSQL(strSQL);

                if (objIsDuplicate.Rows[0][0].ToString() != "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable SearchByPersonalCode(clsUsersAccess objUsersAccess)
        {
            try
            {
                String strSQL = "";//@"SELECT * FROM USERSACCESS_VIEW WHERE USERSACCESS_VIEW.""Personal Code"" = '" + objUsersAccess.per + "' ORDER BY ID"; ;

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }
    }
}