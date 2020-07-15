using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSVNUnlocker.Model.DataManagers;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Pages
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clsRegisteredUsers objRegisteredUsers = new clsRegisteredUsers();

            objRegisteredUsers.PersonalCode = txtPersonalCode.Text;
            objRegisteredUsers.PasswordHash = txtPassword.Text;

            if (!clsRegisteredUsersManager.IsDuplicatePassword(objRegisteredUsers))
            {
                clsRegisteredUsersManager.ResetPasword(objRegisteredUsers);

                ErrorMessage.Text = "Password for user with personal code " + objRegisteredUsers.PersonalCode + " successfully changed.";
            }
            else
            {
                ErrorMessage.Text = "New password cannot be the same as old.";
            }           
        }
    }
}