<%@ Page Title="Unlocking file" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SVNUnlocker.aspx.cs" Inherits="webSVNUnlocker.Pages.SVNUnlocker" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Enter files path for unlock.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPaths" CssClass="col-md-2 control-label">Files path</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPaths" CssClass="form-control" TextMode="MultiLine" Height="325px" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPaths"
                    CssClass="text-danger" ErrorMessage="The paths field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtJIRACode" CssClass="col-md-2 control-label">JIRA code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtJIRACode" CssClass="form-control" MaxLength="15" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtJIRACode"
                    CssClass="text-danger" ErrorMessage="The JIRA code field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Unlock" CssClass="btn btn-default" ID="btnUnlock" OnClick="btnUnlock_Click" />
            </div>
        </div>
        <asp:GridView ID="dgridShowData" runat="server" CellPadding="4" ForeColor="#333333">
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