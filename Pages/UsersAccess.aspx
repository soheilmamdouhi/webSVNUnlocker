<%@ Page Title="Users access" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersAccess.aspx.cs" Inherits="webSVNUnlocker.Pages.UsersAccess" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Enter new users for access to projects.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPersonalCode" CssClass="col-md-2 control-label">Personal code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPersonalCode" CssClass="form-control" MaxLength="4" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPersonalCode"
                    CssClass="text-danger" ErrorMessage="The personal code field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cblProjectsCode" CssClass="col-md-2 control-label">Project code</asp:Label>
            <div class="col-md-10">
                <%--<asp:DropDownList runat="server" ID="ddlProjectCode" CssClass="form-control" MaxLength="10" />--%>
                <asp:CheckBoxList ID="cblProjectsCode" runat="server" CssClass="form-control" Height="100%"></asp:CheckBoxList>
<%--                <asp:RequiredFieldValidator runat="server" ControlToValidate="cblProjectsCode"
                    CssClass="text-danger" ErrorMessage="The project codes field is required." />--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtJIRACode" CssClass="col-md-2 control-label">JIRA code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtJIRACode" CssClass="form-control" MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtJIRACode"
                    CssClass="text-danger" ErrorMessage="The JIRA code field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Insert" CssClass="btn btn-default" ID="btnInsert" OnClick="btnInsert_Click" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Update" CssClass="btn btn-default" ID="btnUpdate" OnClick="btnUpdate_Click" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Delete" CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" Text="Search" CssClass="btn btn-default" ID="btnSearch" OnClick="btnSearch_Click" Width="100px" CausesValidation="False" /><asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
            </div>
        </div>

        <asp:GridView ID="dgridShowData" runat="server" CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField SelectImageUrl="~/Images/checkmark.png" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>