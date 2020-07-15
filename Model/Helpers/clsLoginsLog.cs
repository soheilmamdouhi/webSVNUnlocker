using System;
using System.Net;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsLoginsLog
    {
        private String _ID;
        private String _PersonalCode;
        private String _Time;
        private String _LoginStatus;
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

        public String PersonalCode
        {
            set
            {
                String strPersonalCode = value.ToString();

                strPersonalCode = strPersonalCode.Trim();
                strPersonalCode = strPersonalCode.ToUpper();

                if ((strPersonalCode.Length == 0) || (strPersonalCode.Length > clsConstVars.PersonalCodeLength))
                {
                    throw new Exception("Personal code length must be less than " + clsConstVars.PersonalCodeLength.ToString() + " character or you cannot leave personals code empty.");
                }

                _PersonalCode = strPersonalCode;
            }

            get
            {
                return _PersonalCode;
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

        public String LoginStatus
        {
            set
            {
                String strLoginStatus = value.ToString();

                _LoginStatus = strLoginStatus;
            }
            get
            {
                return _LoginStatus;
            }
        }

        public String ClientAddress
        {
            set
            {
                String strClientAddress = value.ToString();
                IPAddress objIPAddress;

                strClientAddress = strClientAddress.Trim();

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