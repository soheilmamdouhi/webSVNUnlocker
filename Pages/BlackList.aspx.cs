using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSVNUnlocker.Model.Helpers;
using webSVNUnlocker.Model.DataManagers;

namespace webSVNUnlocker.Pages
{
    public partial class BlackList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgridShowData.DataSource = clsBlackListManager.SelectFromBLACKLIST_VIEW();
                dgridShowData.DataBind();
            }
        }

        protected void calExpireDate_SelectionChanged(object sender, EventArgs e)
        {
            txtExpireDate.Text = calExpireDate.SelectedDate.ToShortDateString();
            calExpireDate.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            clsBlackList objBlackList = new clsBlackList();

            objBlackList.Path = txtPath.Text;
            objBlackList.JIRACode = txtJIRACode.Text;
            objBlackList.ExpireDate = txtExpireDate.Text;  //Must have validation control

            if (!clsBlackListManager.IsDuplicate(objBlackList))
            {
                clsBlackListManager.Insert(objBlackList);

                dgridShowData.DataSource = clsBlackListManager.SelectFromBLACKLIST_VIEW();
                dgridShowData.DataBind();

                txtPath.Text = "";
                txtJIRACode.Text = "";
                txtExpireDate.Text = "";

                ErrorMessage.Text = "New path added to black list.";
            }
            else
            {
                ErrorMessage.Text = "Path is duplicate.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsBlackList objBlackList = new clsBlackList();

            objBlackList.ID = lblID.Text;
            objBlackList.Path = txtPath.Text;
            objBlackList.JIRACode = txtJIRACode.Text;
            objBlackList.ExpireDate = txtExpireDate.Text;

            if (!clsBlackListManager.IsDuplicate(objBlackList))
            {
                clsBlackListManager.Update(objBlackList);

                dgridShowData.DataSource = clsBlackListManager.SelectFromBLACKLIST_VIEW();
                dgridShowData.DataBind();

                txtPath.Text = "";
                txtJIRACode.Text = "";
                txtExpireDate.Text = "";

                ErrorMessage.Text = "Path or JIRA code is updated in black list.";
            }
            else
            {
                ErrorMessage.Text = "Path is duplicate.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            clsBlackList objBlackList = new clsBlackList();

            objBlackList.ID = lblID.Text;
            objBlackList.Path = txtPath.Text;
            objBlackList.JIRACode = txtJIRACode.Text;

            clsBlackListManager.Delete(objBlackList);

            dgridShowData.DataSource = clsBlackListManager.SelectFromBLACKLIST_VIEW();
            dgridShowData.DataBind();

            txtPath.Text = "";
            txtJIRACode.Text = "";
            txtExpireDate.Text = "";

            ErrorMessage.Text = "Path is deleted successfully.";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clsBlackList objBlackList = new clsBlackList();

            objBlackList.Path = txtPath.Text;

            dgridShowData.DataSource = clsBlackListManager.SearchByPath(objBlackList);
            dgridShowData.DataBind();
        }

        protected void dgridShowData_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsBlackList objBlackList = new clsBlackList();

            lblID.Text = dgridShowData.SelectedRow.Cells[1].Text;
            txtPath.Text = dgridShowData.SelectedRow.Cells[2].Text;
            objBlackList.ExpireDate = dgridShowData.SelectedRow.Cells[4].Text;
            txtExpireDate.Text = objBlackList.ExpireDate;
            txtJIRACode.Text = dgridShowData.SelectedRow.Cells[5].Text;
        }

        protected void ibtnGetDate_Click(object sender, ImageClickEventArgs e)
        {
            calExpireDate.Visible = true;
        }
    }
}