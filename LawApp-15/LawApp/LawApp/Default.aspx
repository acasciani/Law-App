<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">
    <div style="margin-top: 70px;">
        <h2>My Dashboard</h2>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Timesharing Calendar
                </div>
                <div class="panel-body">
                    <a href="/Modules/TSC/">Create a New Calendar</a><br />
                    <a href="/Modules/TSC/Existing">Manage Saved Calendars</a>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    My Account
                </div>
                <div class="panel-body">
                    <a href="#">Manage Subscriptions</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
