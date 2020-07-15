using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace webSVNUnlocker.Model.DataAccess
{
    public class clsDatabaseType
    {
        private String _Oracle;
        private String _MSSQL;
        private String _MySQL;
        private String _SQLite;
        private String _OleDB;

        public String Oracle
        {
            set
            {
                //String 
            }

            get
            {
                return _Oracle;
            }
        }
    }
}