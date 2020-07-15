using System;
using webSVNUnlocker.Model.Helpers;
using webSVNUnlocker.Model.DataManagers;

namespace webSVNUnlocker.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            clsRegisteredUsers objRegisteredUsers = new clsRegisteredUsers();
            clsLoginsLog objLoginsLog = new clsLoginsLog();

            objRegisteredUsers.PersonalCode = txtPersonalCode.Text;
            objRegisteredUsers.PasswordHash = txtPassword.Text;

            objLoginsLog.PersonalCode = txtPersonalCode.Text;
            objLoginsLog.ClientAddress = Request.UserHostAddress;


            if (clsRegisteredUsersManager.Login(objRegisteredUsers))
            {
                //LOGIN ACCEPTED

                objLoginsLog.LoginStatus = "1";
                clsLoginLogManagement.Insert(objLoginsLog);
            }
            else
            {
                //ErrorMessage.Text = "Personal code or password is incorrect, please try again.";
                objLoginsLog.LoginStatus = "0";
                clsLoginLogManagement.Insert(objLoginsLog);
            }
        }
    }
}