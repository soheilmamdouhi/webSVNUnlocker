using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using webSVNUnlocker.Model.DataAccess;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsAccessListManager
    {
        public static void Insert(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = "INSERT INTO ACCESSLIST (ID, PATH, INSERTDATE, JIRACODE) VALUES (ACCESSLIST_SEQ.NEXTVAL, '" + objAccessList.Path + "', SYSDATE, '" + objAccessList.JIRACode + "')";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Update(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = "UPDATE ACCESSLIST SET PATH = '" + objAccessList.Path + "', JIRACODE = '" + objAccessList.JIRACode + "' WHERE ID = " + objAccessList.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Delete(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = "DELETE FROM ACCESSLIST WHERE ID = " + objAccessList.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable SelectFromACCESSLIST_VIEW()
        {
            try
            {
                String strSQL = "SELECT * FROM ACCESSLIST_VIEW ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsDuplicate(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM ACCESSLIST WHERE PATH = '" + objAccessList.Path + "'";

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

        public static DataTable SearchByPath(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = @"SELECT * FROM ACCESSLIST_VIEW WHERE ACCESSLIST_VIEW.""Path"" LIKE '%" + objAccessList.Path + "%' ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean HasAccess(clsAccessList objAccessList)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM ACCESSLIST WHERE WHERE PATH = LIKE '%" + objAccessList.Path + "%' ORDER BY ID";

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
    }
}