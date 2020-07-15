using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webSVNUnlocker.Model.Helpers;
using webSVNUnlocker.Model.DataAccess;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsLoginLogManagement
    {
        public static void Insert(clsLoginsLog objLoginsLog)
        {
            try
            {
                String strSQL = "INSERT INTO LOGINS_LOG (ID, PERSONALCODE, TIME, LOGINSTATUS, CLIENTADDRESS) VALUES (LOGINS_LOG_SEQ.NEXTVAL, '" + objLoginsLog.PersonalCode + "', SYSDATE, '" + objLoginsLog.LoginStatus + "', '" + objLoginsLog.ClientAddress + "')";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }
    }
}