<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="webSVNUnlocker.Pages.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPersonalCode" CssClass="col-md-2 control-label">Personal code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPersonalCode" CssClass="form-control" MaxLength="4" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPersonalCode"
                    CssClass="text-danger" ErrorMessage="The personal code field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" MaxLength="100" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" MaxLength="500" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" MaxLength="500" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Register" CssClass="btn btn-default" ID="btnRegister" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
