using System;
using webSVNUnlocker.Model.DataManagers;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            clsRegisteredUsers objRegisteredUsers = new clsRegisteredUsers();

            objRegisteredUsers.FirstName = txtFirstName.Text;
            objRegisteredUsers.LastName = txtLastName.Text;
            objRegisteredUsers.PersonalCode = txtPersonalCode.Text;
            objRegisteredUsers.Email = txtEmail.Text;
            objRegisteredUsers.PasswordHash = txtPassword.Text;
            //objRegisteredUsers.RegistrationDate = DateTime.Now.ToString();
            //objRegisteredUsers.ExpireDate
            objRegisteredUsers.isActive = "1";
            objRegisteredUsers.ClientAddress = Request.UserHostAddress;

            if (!clsRegisteredUsersManager.IsDuplicate(objRegisteredUsers))
            {
                clsRegisteredUsersManager.Insert(objRegisteredUsers);

                ErrorMessage.Text = "User successfully registered. For access to unlockling files in projects please call to your team manager.";

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPersonalCode.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                ErrorMessage.Text = "User is duplicate.";
            }
        }
    }
}