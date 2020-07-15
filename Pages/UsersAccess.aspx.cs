using System;
using System.Web.UI;
using webSVNUnlocker.Model.DataManagers;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Pages
{
    public partial class UsersAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dgridShowData.DataSource = clsUsersAccessManager.USERSACCESS_VIEW();
                dgridShowData.DataBind();

                cblProjectsCode.DataSource = clsProjectsManager.SelectFromPROJECTS_VIEW();
                cblProjectsCode.DataTextField = "Code";
                cblProjectsCode.DataValueField = "ID";
                cblProjectsCode.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            clsUsersAccess objUsersAccess = new clsUsersAccess();
            clsRegisteredUsers objRegisteredUsers = new clsRegisteredUsers();
            clsProjects objProjects = new clsProjects();

            objRegisteredUsers.PersonalCode = txtPersonalCode.Text;
            if (clsRegisteredUsersManager.IsExist(objRegisteredUsers))
            {
                objUsersAccess.UserID = clsRegisteredUsersManager.IDByPersonalCode(objRegisteredUsers);
                objUsersAccess.JIRACode = txtJIRACode.Text;

                for (int intCounter = 0; intCounter < cblProjectsCode.Items.Count; intCounter++)
                {
                    if (cblProjectsCode.Items[intCounter].Selected == true)
                    {
                        objUsersAccess.ProjectID = cblProjectsCode.Items[intCounter].Value;

                        if (!clsUsersAccessManager.IsDuplicate(objUsersAccess))
                        {
                            clsUsersAccessManager.Insert(objUsersAccess);

                            dgridShowData.DataSource = clsUsersAccessManager.USERSACCESS_VIEW();
                            dgridShowData.DataBind();

                            cblProjectsCode.Items[intCounter].Selected = false;
                        }
                        else
                        {
                            ErrorMessage.Text = "Project " + cblProjectsCode.Items[intCounter].Text + " already assigned to this user.";
                            cblProjectsCode.Items[intCounter].Selected = false;
                        }
                    }
                }

                txtPersonalCode.Text = "";
                txtJIRACode.Text = "";
            }
            else
            {
                ErrorMessage.Text = "Entered personal code dose not exist.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clsUsersAccess objUsersAccess = new clsUsersAccess();
            clsRegisteredUsers objRegisteredUsers = new clsRegisteredUsers();

            objRegisteredUsers.PersonalCode = txtPersonalCode.Text;
            objUsersAccess.UserID = clsRegisteredUsersManager.IDByPersonalCode(objRegisteredUsers);

            if (clsRegisteredUsersManager.IsExist(objRegisteredUsers))
            {
                dgridShowData.DataSource = clsUsersAccessManager.USERSACCESS_VIEW(objUsersAccess);
                dgridShowData.DataBind();
            }
            else
            {
                ErrorMessage.Text = "Entered personal code dose not exist.";
            }
        }
    }
}