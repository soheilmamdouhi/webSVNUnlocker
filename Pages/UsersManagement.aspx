<%@ Page Title="Users management" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="UsersManagement.aspx.cs" Inherits="webSVNUnlocker.Pages.UsersManagement" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <%--<h4>Managing users</h4>--%>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPath" CssClass="col-md-2 control-label">Path</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPath" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPath"
                    CssClass="text-danger" ErrorMessage="The path field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtJIRACode" CssClass="col-md-2 control-label">JIRA code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtJIRACode" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtJIRACode"
                    CssClass="text-danger" ErrorMessage="The JIRA code field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Insert" CssClass="btn btn-default" />
            </div>
        </div>

        <asp:GridView ID="dgridShowData" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
		    <EditRowStyle BackColor="#2461BF" />
		    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
		    <RowStyle BackColor="#EFF3FB" />
		    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>