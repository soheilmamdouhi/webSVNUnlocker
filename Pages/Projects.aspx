<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="webSVNUnlocker.Pages.Projects" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Enter new project name to manage in subversion</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" MaxLength="100" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCode" CssClass="col-md-2 control-label">Code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCode"
                    CssClass="text-danger" ErrorMessage="The code field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Insert" CssClass="btn btn-default" ID="btnInsert" Width="180px" OnClick="btnInsert_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--                <asp:Button runat="server" Text="Update" CssClass="btn btn-default" ID="btnUpdate" Width="100px" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
<%--                <asp:Button runat="server" Text="Delete" CssClass="btn btn-default" ID="btnDelete" Width="100px" OnClick="btnDelete_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <asp:Button runat="server" Text="Search by project code" CssClass="btn btn-default" ID="btnSearch" Width="180px" CausesValidation="False" OnClick="btnSearch_Click" /><asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
            </div>
        </div>

        <asp:GridView ID="dgridShowData" runat="server" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="dgridShowData_SelectedIndexChanged" Width="100%">
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