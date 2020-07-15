using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using webSVNUnlocker.Model.DataAccess;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsBlackListManager
    {
        public static void Insert(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = "INSERT INTO BLACKLIST (ID, PATH, INSERTDATE, EXPIREDATE, JIRACODE) VALUES (BLACKLIST_SEQ.NEXTVAL, '" + objBlackList.Path + "', SYSDATE, TO_DATE('" + objBlackList.ExpireDate + "', 'MM/DD/YYYY'), '" + objBlackList.JIRACode + "')";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Update(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = "UPDATE BLACKLIST SET PATH = '" + objBlackList.Path + "', EXPIREDATE = TO_DATE('" + objBlackList.ExpireDate + "', 'MM/DD/YYYY'), JIRACODE = '" + objBlackList.JIRACode + "' WHERE ID = " + objBlackList.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Delete(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = "DELETE FROM BLACKLIST WHERE ID = " + objBlackList.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable SelectFromBLACKLIST_VIEW()
        {
            try
            {
                String strSQL = "SELECT * FROM BLACKLIST_VIEW ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsDuplicate(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM BLACKLIST WHERE PATH = '" + objBlackList.Path + "'";

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

        public static DataTable SearchByPath(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = @"SELECT * FROM BLACKLIST_VIEW WHERE BLACKLIST_VIEW.""Path"" LIKE '%" + objBlackList.Path + "%' ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsBlackListed(clsBlackList objBlackList)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM BLACKLIST WHERE WHERE PATH = LIKE '%" + objBlackList.Path + "%' ORDER BY ID";

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