<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Account.Subscriptions.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">
    <asp:Repeater runat="server" ID="rptSubscriptions">
        <ItemTemplate>
            <div class="panel">
                <div class="panel-body">

                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
