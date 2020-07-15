using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsPermissions
    {
        public String strPersonalCode;
        private String _PageURL;

        public String strPageURL
        {
            set
            {
                String strPage = value.ToString();
                int intURLLength;

                strPage = strPage.Replace("ASP.", "~/");
                strPage = strPage.Replace("_", "/");

                intURLLength = strPage.Length;

                strPage = strPage.Remove(intURLLength - 5);
                //strPage = strPage.Remove(intURLLength - 6);
                strPage += ".aspx";
                _PageURL = strPage;
            }

            get
            {
                return _PageURL;
            }
        }
    }
}