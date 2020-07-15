using System;

namespace webSVNUnlocker.Model.Helpers
{
    public class clsPathNormalizer
    {
        public static String PathNormalizer(String strPath)
        {
            int intCutLocation = strPath.LastIndexOf("/svn/");

            if (intCutLocation > 0)
            {
                intCutLocation += 4;
                strPath = strPath.Remove(0, intCutLocation);
            }

            strPath = strPath.Replace("/", "\\");
            //strPath = "D:" + strPath;
            //strURL = "D:\\MySource" + strURL;

            //if (strPath.Contains("MCFS_Code2"))
            //{
            //    int intIndexOfMCFS = strPath.IndexOf("MCFS_Code2");
            //    strPath = strPath.Replace("MCFS_Code2", "MCFS_Code");
            //}

            return strPath;
        }
    }
}