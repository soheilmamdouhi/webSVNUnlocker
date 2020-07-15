<%@ Page  Title="Black list" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlackList.aspx.cs" Inherits="webSVNUnlocker.Pages.BlackList" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Enter new path to black list</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPath" CssClass="col-md-2 control-label">Path</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPath" CssClass="form-control" MaxLength="500" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPath"
                    CssClass="text-danger" ErrorMessage="The path field is required." />
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
            <asp:Label runat="server" AssociatedControlID="txtExpireDate" CssClass="col-md-2 control-label">Expire date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtExpireDate" ReadOnly="True" />
                <asp:ImageButton ID="ibtnGetDate" runat="server" CssClass="btn btn-default" CausesValidation="False"  ImageUrl="~/images/calendar.png" BorderStyle="None" Height="50px" OnClick="ibtnGetDate_Click" Width="60px" />
                <asp:Calendar ID="calExpireDate" runat="server" Visible="False" OnSelectionChanged="calExpireDate_SelectionChanged"></asp:Calendar>
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

        <asp:GridView ID="dgridShowData" runat="server" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="dgridShowData_SelectedIndexChanged">
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
<%--    <!-- Bootstrap -->
    <script type="text/javascript" src='~/Scripts/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='~/Scripts/bootstrap.min.js'></script>
    <link rel="stylesheet" href='~/Content/bootstrap.min.css' media="screen" />
    <!-- Bootstrap -->
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="~/Content/bootstrap-datepicker.css" type="text/css"/>
    <script src="~/Scripts/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap DatePicker -->

    <script type="text/javascript">
        $(function () {
            $('[id*=txtExpireDate]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "en"
            });
        });
    </script>--%>
</asp:Content>