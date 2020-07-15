using System;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsProjects
    {
        private String _ID;
        private String _Name;
        private String _Code;
        private String _RepositoryPath;

        public String ID
        {
            set
            {
                String strID = value.ToString();

                _ID = strID;
            }
            get
            {
                return _ID;
            }
        }

        public String Name
        {
            set
            {
                String strName = value.ToString();

                strName = strName.Trim();
                strName = strName.ToUpper();

                if ((strName.Length == 0) || (strName.Length > clsConstVars.ProjectNameLength))
                {
                    throw new Exception("Project name length must be less than " + clsConstVars.ProjectNameLength.ToString() + " character or you cannot leave projects name empty.");
                }

                _Name = strName;
            }
            get
            {
                return _Name;
            }
        }

        public String Code
        {
            set
            {
                String strCode = value.ToString();

                strCode = strCode.Trim();
                strCode = strCode.ToUpper();

                if ((strCode.Length == 0) || (strCode.Length > clsConstVars.ProjectCodeLength))
                {
                    throw new Exception("Project code length must be less than " + clsConstVars.ProjectCodeLength.ToString() + " character or you cannot leave projects code empty.");
                }

                _Code = strCode;
            }
            get
            {
                return _Code;
            }
        }

        public String RepositoryPath
        {
            set
            {
                String strRepositoryPath = value.ToString();

                strRepositoryPath = strRepositoryPath.Trim();
                strRepositoryPath = strRepositoryPath.ToUpper();

                if ((strRepositoryPath.Length == 0) || (strRepositoryPath.Length > clsConstVars.RepositoryPathLength))
                {
                    throw new Exception("Project repository path length must be less than " + clsConstVars.RepositoryPathLength.ToString() + " character or you cannot leave repository path empty.");
                }

                _RepositoryPath = strRepositoryPath;
            }
            get
            {
                return _Code;
            }
        }
    }
}