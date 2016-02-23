<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="LawAppWeb.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">

    <div>
        <h2>Reset Password</h2>
    </div>

    <ui:AlertBox runat="server" ID="AlertBox" />

    <div class="form-group">
        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Email" AutoCompleteType="None" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
    </div>

    <div class="form-group">
        <asp:Button runat="server" Text="Reset Password" CssClass="btn btn-default" ID="btnSubmit" OnClick="btnSubmit_Click" />
    </div>

    <div class="text-left">
        Already have an account? <a href="/Account/Login">Click here to login</a><br />
        Don't have an account yet? <a href="/Account/Register">Click here to create a new account</a><br />
    </div>

</asp:Content>
