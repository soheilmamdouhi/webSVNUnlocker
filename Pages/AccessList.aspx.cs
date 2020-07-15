using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSVNUnlocker.Model.DataManagers;
using webSVNUnlocker.Model.Helpers;

namespace webSVNUnlocker.Pages
{
    public partial class AccessList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgridShowData.DataSource = clsAccessListManager.SelectFromACCESSLIST_VIEW();
                dgridShowData.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            clsAccessList objAccessList = new clsAccessList();

            objAccessList.Path = txtPath.Text;
            objAccessList.JIRACode = txtJIRACode.Text;

            if (!clsAccessListManager.IsDuplicate(objAccessList))
            {
                clsAccessListManager.Insert(objAccessList);

                dgridShowData.DataSource = clsAccessListManager.SelectFromACCESSLIST_VIEW();
                dgridShowData.DataBind();

                txtPath.Text = "";
                txtJIRACode.Text = "";

                ErrorMessage.Text = "New path added to access list.";
            }
            else
            {
                ErrorMessage.Text = "Path is duplicate.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsAccessList objAccessList = new clsAccessList();

            objAccessList.ID = lblID.Text;
            objAccessList.Path = txtPath.Text;
            objAccessList.JIRACode = txtJIRACode.Text;

            if (!clsAccessListManager.IsDuplicate(objAccessList))
            {
                clsAccessListManager.Update(objAccessList);

                dgridShowData.DataSource = clsAccessListManager.SelectFromACCESSLIST_VIEW();
                dgridShowData.DataBind();

                txtPath.Text = "";
                txtJIRACode.Text = "";

                ErrorMessage.Text = "Path or JIRA code is updated in access list.";
            }
            else
            {
                ErrorMessage.Text = "Path is duplicate.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            clsAccessList objAccessList = new clsAccessList();

            objAccessList.ID = lblID.Text;
            objAccessList.Path = txtPath.Text;
            objAccessList.JIRACode = txtJIRACode.Text;

            clsAccessListManager.Delete(objAccessList);

            txtPath.Text = "";
            txtJIRACode.Text = "";

            ErrorMessage.Text = "Path is deleted successfully.";

            dgridShowData.DataSource = clsAccessListManager.SelectFromACCESSLIST_VIEW();
            dgridShowData.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clsAccessList objAccessList = new clsAccessList();

            objAccessList.Path = txtPath.Text;

            dgridShowData.DataSource = clsAccessListManager.SearchByPath(objAccessList);
            dgridShowData.DataBind();
        }

        protected void dgridShowData_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = dgridShowData.SelectedRow.Cells[1].Text;
            txtPath.Text = dgridShowData.SelectedRow.Cells[2].Text;
            txtJIRACode.Text = dgridShowData.SelectedRow.Cells[4].Text;
        }
    }
}