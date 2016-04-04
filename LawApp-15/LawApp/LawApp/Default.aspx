<%@ Page Title="My Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">
    <div>
        <h2>Welcome, <asp:Literal runat="server" ID="litPersonName" />!</h2>
        <p>This is your personalized dashboard. You can use it to quickly navigate to all the tools you have access to.</p>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Timesharing Calendar
                </div>
                <div class="panel-body">
                    <asp:Panel runat="server" ID="pnlTSCLinks" Visible="false">
                        <a href="/Modules/TSC/">Create a New Calendar</a><br />
                        <a href="/Modules/TSC/Existing">Manage Saved Calendars</a>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlTSCNoAccess" Visible="false">
                        <span class="text-danger">You do not have access to the Timesharing Calendar tool.</span> <a href="/Account/Subscriptions">Please click here to order a subscription.</a>
                    </asp:Panel>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    My Account
                </div>
                <div class="panel-body">
                    <a href="/Account/Subscriptions/">Manage Subscriptions</a><br />
                    <a href="/Account/ManagePassword">Change Password</a>
                </div>
            </div>
        </div>
    </div>

    <div>
        <p>For technical support, please email: <a href="mailto:lawapp15+Support@gmail.com">lawapp15+Support@gmail.com</a></p>
    </div>

</asp:Content>
