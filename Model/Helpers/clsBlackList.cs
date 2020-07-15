using System;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsBlackList
    {
        private String _ID;
        private String _Path;
        private String _InsertDate;
        private String _ExpireDate;
        private String _JIRACode;

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

        public String Path
        {
            set
            {
                String strPath = value.ToString();

                strPath = strPath.Trim();

                if ((strPath.Length == 0) || (strPath.Length > clsConstVars.PathLength))
                {
                    throw new Exception("Path length must be less than " + clsConstVars.PathLength.ToString() + " character or you cannot leave paths empty.");
                }

                _Path = clsPathNormalizer.PathNormalizer(strPath);
            }

            get
            {
                return _Path;
            }
        }

        public String InsertDate
        {
            set
            {
                _InsertDate = DateTime.Now.ToString();
            }

            get
            {
                return _InsertDate;
            }
        }

        public String ExpireDate
        {
            set
            {
                String strExpireDate = value.ToString();
                //int intIndexOfSpace = strExpireDate.IndexOf(" ");

                if (strExpireDate.IndexOf(" ") > 0)
                {
                    _ExpireDate = strExpireDate.Substring(0, strExpireDate.IndexOf(" "));
                }
                else
                {
                    _ExpireDate = strExpireDate;
                }
            }

            get
            {
                return _ExpireDate;
            }
        }

        public String JIRACode
        {
            set
            {
                String strJIRACode = value.ToString();

                strJIRACode = strJIRACode.Trim();
                strJIRACode = strJIRACode.ToUpper();

                if ((strJIRACode.Length == 0) || (strJIRACode.Length > clsConstVars.JIRACodeLength))
                {
                    throw new Exception("JIRA Code length must be less than " + clsConstVars.JIRACodeLength.ToString() + " character or you cannot leave JIRA Codes empty.");
                }

                _JIRACode = strJIRACode;
            }

            get
            {
                return _JIRACode;
            }
        }
    }
}