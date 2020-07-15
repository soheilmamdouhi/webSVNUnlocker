using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webSVNUnlocker.Model.Helpers;
using webSVNUnlocker.Model.DataAccess;
using System.Data;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsRegisteredUsersManager
    {
        public static void Insert(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "INSERT INTO REGISTEREDUSERS (ID, FirstName, LastName, PersonalCode, Email, PasswordHash, RegistrationDate, ExpireDate, isActive, IPAddress, ISADMINISTRATOR) VALUES (USERSID_SEQ.NEXTVAL, '" + objRegisteredUsers.FirstName + "', '" + objRegisteredUsers.LastName + "', '" + objRegisteredUsers.PersonalCode + "', '" + objRegisteredUsers.Email + "', '" + objRegisteredUsers.PasswordHash + "', SYSDATE, '" + objRegisteredUsers.ExpireDate + "', '" + objRegisteredUsers.isActive + "', '" + objRegisteredUsers.ClientAddress + "', '0')";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable SelectFromREGISTEREDUSERS_VIEW()
        {
            try
            {
                String strSQL = "SELECT * FROM REGISTEREDUSERS_VIEW ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static String PersonalCodeByID(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT PERSONALCODE FROM REGISTEREDUSERS WHERE ID = " + objRegisteredUsers.ID;

                clsDBMS objDBMS = new clsDBMS();
                DataTable objPersonalCode = new DataTable();

                objPersonalCode = objDBMS.ExecuteSelectSQL(strSQL);

                return objPersonalCode.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsExist(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM REGISTEREDUSERS WHERE PERSONALCODE = '" + objRegisteredUsers.PersonalCode + "'";

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

        public static String IDByPersonalCode(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT ID FROM REGISTEREDUSERS WHERE PERSONALCODE = '" + objRegisteredUsers.PersonalCode + "'";

                clsDBMS objDBMS = new clsDBMS();
                DataTable objID = new DataTable();

                objID = objDBMS.ExecuteSelectSQL(strSQL);

                return objID.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsDuplicate(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM REGISTEREDUSERS WHERE PERSONALCODE = '" + objRegisteredUsers.PersonalCode + "' OR EMAIL = '" + objRegisteredUsers.Email + "'";

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

        public static void ResetPasword(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "UPDATE REGISTEREDUSERS SET PASSWORDHASH = '" + objRegisteredUsers.PasswordHash + "' WHERE PERSONALCODE = '" + objRegisteredUsers.PersonalCode + "'";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static Boolean IsDuplicatePassword(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM REGISTEREDUSERS WHERE PASSWORDHASH = '" + objRegisteredUsers.PasswordHash + "'";

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

        public static Boolean Login(clsRegisteredUsers objRegisteredUsers)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM REGISTEREDUSERS WHERE PERSONALCODE = '" + objRegisteredUsers.PersonalCode + "' AND PASSWORDHASH = '" + objRegisteredUsers.PasswordHash + "'";

                clsDBMS objDBMS = new clsDBMS();
                DataTable objLoginStatus = new DataTable();

                objLoginStatus = objDBMS.ExecuteSelectSQL(strSQL);

                if (objLoginStatus.Rows[0][0].ToString() != "0")
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