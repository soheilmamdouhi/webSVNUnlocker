using System;
using webSVNUnlocker.Model.DataManagers;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Pages
{
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    dgridShowData.DataSource = clsProjectsManager.SelectFromPROJECTS_VIEW();
                    dgridShowData.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                clsProjects objProjects = new clsProjects();

                objProjects.Name = txtName.Text;
                objProjects.Code = txtCode.Text;
                objProjects.RepositoryPath = txtRepositoryPath.Text;

                if (!clsProjectsManager.IsDuplicate(objProjects))
                {
                    clsProjectsManager.Insert(objProjects);

                    dgridShowData.DataSource = clsProjectsManager.SelectFromPROJECTS_VIEW();
                    dgridShowData.DataBind();

                    txtName.Text = "";
                    txtCode.Text = "";
                    txtRepositoryPath.Text = "";

                    ErrorMessage.Text = "New project added.";
                }
                else
                {
                    ErrorMessage.Text = "Projects is duplicate.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    clsProjects objProjects = new clsProjects();

        //    objProjects.ID = lblID.Text;
        //    objProjects.Name = txtName.Text;
        //    objProjects.Code = txtCode.Text;

        //    if (!clsProjectsManager.IsDuplicate(objProjects))
        //    {
        //        clsProjectsManager.Update(objProjects);

        //        dgridShowData.DataSource = clsProjectsManager.SelectFromPROJECTS_VIEW();
        //        dgridShowData.DataBind();

        //        lblID.Text = "";
        //        txtName.Text = "";
        //        txtCode.Text = "";

        //        ErrorMessage.Text = "Projects data updated.";
        //    }
        //    else
        //    {
        //        ErrorMessage.Text = "Projects is duplicate.";
        //    }
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    clsProjects objProjects = new clsProjects();

        //    objProjects.ID = lblID.Text;
        //    objProjects.Name = txtName.Text;
        //    objProjects.Code = txtCode.Text;

        //    clsProjectsManager.Delete(objProjects);

        //    dgridShowData.DataSource = clsProjectsManager.SelectFromPROJECTS_VIEW();
        //    dgridShowData.DataBind();

        //    lblID.Text = "";
        //    txtName.Text = "";
        //    txtCode.Text = "";

        //    ErrorMessage.Text = "Project is deleted successfully.";
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                clsProjects objProjects = new clsProjects();

                objProjects.Code = txtCode.Text;

                dgridShowData.DataSource = clsProjectsManager.SearchByCode(objProjects);
                dgridShowData.DataBind();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
        }

        protected void dgridShowData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = dgridShowData.SelectedRow.Cells[1].Text;
                txtName.Text = dgridShowData.SelectedRow.Cells[2].Text;
                txtCode.Text = dgridShowData.SelectedRow.Cells[3].Text;
                txtRepositoryPath.Text = dgridShowData.SelectedRow.Cells[4].Text;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
        }
    }
}