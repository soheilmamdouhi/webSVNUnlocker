using System;
using System.Data;
using webSVNUnlocker.Model.Helpers;
using webSVNUnlocker.Model.DataAccess;

namespace webSVNUnlocker.Model.DataManagers
{
    public class clsProjectsManager
    {
        public static void Insert(clsProjects objProjects)
        {
            try
            {
                String strSQL = "INSERT INTO PROJECTS (ID, NAME, CODE, REPOSITORYPATH) VALUES (PROJECTS_SEQ.NEXTVAL, '" + objProjects.Name + "', '" + objProjects.Code + "', '" + objProjects.RepositoryPath + ")";

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Update(clsProjects objProjects)
        {
            try
            {
                String strSQL = "UPDATE PROJECTS SET NAME = '" + objProjects.Name + "', CODE = '" + objProjects.Code + "' WHERE ID = " + objProjects.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static void Delete(clsProjects objProjects)
        {
            try
            {
                String strSQL = "DELETE FROM PROJECTS WHERE ID = " + objProjects.ID;

                clsDBMS objDBMS = new clsDBMS();

                objDBMS.ExecuteSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static DataTable SelectFromPROJECTS_VIEW()
        {
            try
            {
                String strSQL = "SELECT * FROM PROJECTS_VIEW ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static String CodeByID(clsProjects objProjects)
        {
            try
            {
                String strSQL = "SELECT CODE FROM PROJECTS WHERE ID = " + objProjects.ID;

                clsDBMS objDBMS = new clsDBMS();
                DataTable objCode = new DataTable();

                objCode = objDBMS.ExecuteSelectSQL(strSQL);

                return objCode.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        public static String IDByCode(clsProjects objProjects)
        {
            try
            {
                String strSQL = "SELECT ID FROM PROJECTS WHERE CODE = '" + objProjects.Code + "'";

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

        public static Boolean IsDuplicate(clsProjects objProjects)
        {
            try
            {
                String strSQL = "SELECT COUNT(*) FROM PROJECTS WHERE CODE = '" + objProjects.Code + "'";

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

        public static DataTable SearchByCode(clsProjects objProjects)
        {
            try
            {
                String strSQL = @"SELECT * FROM PROJECTS_VIEW WHERE PROJECTS_VIEW.""Code"" LIKE '%" + objProjects.Code + "%' ORDER BY ID";

                clsDBMS objDBMS = new clsDBMS();

                return objDBMS.ExecuteSelectSQL(strSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
            }
        }

        //public static DataTable 
    }
}