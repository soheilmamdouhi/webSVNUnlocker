using System;
using System.Net;
using webSVNUnlocker.Model.Commen;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsRegisteredUsers
    {
        private String _ID;
        private String _FirstName;
        private String _LastName;
        private String _PersonalCode;
        private String _Email;
        private String _PasswordHash;
        private String _RegistrationDate;
        private String _ExpireDate;
        private String _isActive;
        private String _ClientAddress;
        private String _isAdministrator;

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

        public String FirstName
        {
            set
            {
                String strFirstName = value.ToString();

                strFirstName = strFirstName.Trim();
                strFirstName = strFirstName.ToUpper();

                if ((strFirstName.Length == 0) || (strFirstName.Length > clsConstVars.FirstNameLength))
                {
                    throw new Exception("First name length must be less than " + clsConstVars.FirstNameLength.ToString() + " character or you cannot leave first name empty.");
                }

                _FirstName = strFirstName;
            }

            get
            {
                return _FirstName;
            }
        }

        public String LastName
        {
            set
            {
                String strLastName = value.ToString();

                strLastName = strLastName.Trim();
                strLastName = strLastName.ToUpper();

                if ((strLastName.Length == 0) || (strLastName.Length > clsConstVars.LastNameLength))
                {
                    throw new Exception("Last name length must be less than " + clsConstVars.LastNameLength.ToString() + " character or you cannot leave last name empty.");
                }

                _LastName = strLastName;
            }

            get
            {
                return _LastName;
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

        public String Email
        {
            set
            {
                String strEmail = value.ToString();

                strEmail = strEmail.Trim();
                strEmail = strEmail.ToUpper();

                if ((strEmail.Length == 0) || (strEmail.Length > clsConstVars.EmailLength))
                {
                    throw new Exception("Email address length must be less than " + clsConstVars.EmailLength.ToString() + " character or you cannot leave email address empty.");
                }

                _Email = strEmail;
            }

            get
            {
                return _Email;
            }
        }

        public String PasswordHash
        {
            set
            {
                String strPassword = value.ToString();
                clsHasher objHasher = new clsHasher();

                strPassword = strPassword.Trim();
                _PasswordHash = objHasher.getSHA1Hash(strPassword);


                if ((strPassword.Length == 0) || (strPassword.Length > clsConstVars.PasswordLength))
                {
                    throw new Exception("Password length must be less than " + clsConstVars.PasswordLength.ToString() + " character or you cannot leave password empty.");
                }

                _PasswordHash = objHasher.getSHA1Hash(strPassword);
            }

            get
            {
                return _PasswordHash;
            }
        }

        public String RegistrationDate
        {
            set
            {
                _RegistrationDate = DateTime.Now.ToString();
            }

            get
            {
                return _RegistrationDate;
            }
        }

        public String ExpireDate
        {
            set
            {
                String strExpireDate = value.ToString();

                _ExpireDate = strExpireDate;
            }

            get
            {
                return _ExpireDate;
            }
        }

        public String isActive
        {
            set
            {
                String strIsActive = value.ToString();

                _isActive = strIsActive;
            }
            get
            {
                return _isActive;
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

        public String isAdministrator
        {
            set
            {
                String strIsAdministrator = value.ToString();

                _isAdministrator = strIsAdministrator;
            }
            get
            {
                return _isAdministrator;
            }
        }
    }
}