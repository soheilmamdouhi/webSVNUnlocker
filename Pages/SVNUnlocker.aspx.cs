using SharpSvn;
using SharpSvn.UI;
using System;
using System.IO;
using webSVNUnlocker.Model.Helpers;
using System.Data;
using webSVNUnlocker.Model.DataManagers;

namespace webSVNUnlocker.Pages
{
    public partial class SVNUnlocker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnlock_Click(object sender, EventArgs e)
        {
            clsUnlockList objUnlockList = new clsUnlockList();
            EventHandler<SvnStatusEventArgs> statusHandler = new EventHandler<SvnStatusEventArgs>(HandleStatusEvent);
            DataTable objDataTableLog = new DataTable();
            clsAccessList objAccessList = new clsAccessList();
            clsBlackList objBlackList = new clsBlackList();
            Boolean blnAccessStatus;
            Boolean blnBlackListed;

            objDataTableLog.Columns.Add("Row", typeof(int));
            objDataTableLog.Columns.Add("Path", typeof(string));
            objDataTableLog.Columns.Add("Status", typeof(string));
            objDataTableLog.Columns.Add("Detail", typeof(string));

            int intSuccessful = 0;
            int intError = 0;

            string[] arrPaths = txtPaths.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            objUnlockList.JIRACode = txtJIRACode.Text;

            for (int intCounter = 0; intCounter < arrPaths.Length; intCounter++)
            {
                if ((string.IsNullOrWhiteSpace(arrPaths[intCounter])) || (arrPaths[intCounter] == ""))
                {
                    objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "Null or white-space");
                }
                else
                {
                    if (HasWhiteSpace(arrPaths[intCounter]))
                    {
                        objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "Invalid Path, path cannot have white-space");
                        intError++;
                    }
                    else
                    {
                        objUnlockList.Path = arrPaths[intCounter];

                        objAccessList.Path = objUnlockList.Path;
                        objBlackList.Path = objUnlockList.Path;

                        if (clsAccessListManager.HasAccess(objAccessList))
                        {
                            if (!clsBlackListManager.IsBlackListed(objBlackList))
                            {
                                String strWindowsPath = WindowsPath(objUnlockList.Path);

                                //objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "OK");

                                if (File.Exists(strWindowsPath))
                                {
                                    using (SvnClient objSvnClient = new SvnClient())
                                    {
                                        SvnUI.Bind(objSvnClient, (System.Windows.Forms.IWin32Window)this);
                                        try
                                        {
                                            objSvnClient.Update(strWindowsPath);
                                            objSvnClient.Unlock(WindowsPath(arrPaths[intCounter]));

                                            intSuccessful++;

                                            objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Successful", "File unlocked Successfully");
                                        }
                                        catch (Exception ex)
                                        {
                                            intError++;
                                            objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "File already unlocked or has error in unlocking");
                                        }
                                    }
                                }
                                else
                                {
                                    intError++;
                                    objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "Path or file dose not exist");
                                }
                            }
                            else
                            {
                                intError++;
                                objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "Path or file is in black list");
                            }
                        }
                        else
                        {
                            intError++;
                            objDataTableLog.Rows.Add(intCounter + 1, arrPaths[intCounter], "Failed", "Path or file is not in access list for unlock");
                        }
                    }
                }
            }

            dgridShowData.DataSource = objDataTableLog;
            dgridShowData.DataBind();
            ErrorMessage.Text = "Files successfully unlocked: " + intSuccessful.ToString() + "  " + "Error in unlocking process: " + intError.ToString();
        }







        public bool HasWhiteSpace(String strLine)
        {
            if (strLine == null)
                throw new ArgumentNullException("strLine");

            for (int intLineLength = 0; intLineLength < strLine.Length; intLineLength++)
            {
                if (char.IsWhiteSpace(strLine[intLineLength]))
                    return true;
            }
            return false;
        }


        public String WindowsPath(String strURL)
        {
            //clsPathNormalizer.PathNormalizer(strURL);

            strURL = "D:" + strURL;

            if (strURL.Contains(@"\MCFS_Code2\"))
            {
                //int intIndexOfMCFS = strURL.IndexOf("MCFS_Code2");
                strURL = strURL.Replace(@"\MCFS_Code2\", @"\MCFS_Code\");
            }

            return strURL;
        }

        public void HandleStatusEvent(object sender, SvnStatusEventArgs args)
        {
            switch (args.LocalContentStatus)
            {
                case SvnStatus.Added:
                    break;
            }
        }
    }
}