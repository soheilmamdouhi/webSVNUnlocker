using System;
using System.Net;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsUnlockList
    {
        private String _ID;
        private String _UserID;
        private String _Path;
        private String _Time;
        private String _isBlockListed;
        private String _FileStatus;
        private String _UnlockingStatus;
        private String _Log;
        private String _JIRACode;
        private String _ClientAddress;

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

        public String Time
        {
            set
            {
                _Time = DateTime.Now.ToString();
            }

            get
            {
                return _Time;
            }
        }

        public String isBlockListed
        {
            set
            {
                String strIsBlockListed = value.ToString();

                _isBlockListed = strIsBlockListed;
            }
            get
            {
                return _isBlockListed;
            }
        }

        public String FileStatus
        {
            set
            {
                String strFileStatus = value.ToString();

                _FileStatus = strFileStatus;
            }
            get
            {
                return _FileStatus;
            }
        }

        public String UnlockingStatus
        {
            set
            {
                String strUnlockingStatus = value.ToString();

                _UnlockingStatus = strUnlockingStatus;
            }
            get
            {
                return _UnlockingStatus;
            }
        }

        public String Log
        {
            set
            {
                String strLog = value.ToString();

                _Log = strLog;
            }
            get
            {
                return _Log;
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

        public String ClientAddress
        {
            set
            {
                String strClientAddress = value.ToString();
                IPAddress objIPAddress;

                bool ValidateIP = IPAddress.TryParse(strClientAddress, out objIPAddress);

                if (ValidateIP)
                {
                    _ClientAddress = strClientAddress;
                }
                else
                {
                    throw new Exception("This address isn't valid IP");
                }
            }

            get
            {
                return _ClientAddress;
            }
        }
    }
}