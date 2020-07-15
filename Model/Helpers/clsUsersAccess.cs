using System;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsUsersAccess
    {
        private String _ID;
        private String _UserID;
        private String _ProjectID;
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

        public String UserID
        {
            set
            {
                String strUserID = value.ToString();

                _UserID = strUserID;
            }
            get
            {
                return _UserID;
            }
        }

        public String ProjectID
        {
            set
            {
                String strProjectID = value.ToString();

                _ProjectID = strProjectID;
            }

            get
            {
                return _ProjectID;
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