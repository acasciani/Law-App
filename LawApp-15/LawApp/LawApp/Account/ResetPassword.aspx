<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="LawAppWeb.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">

    <div>
        <h2>Reset Password</h2>
    </div>

    <asp:PasswordRecovery runat="server" ID="PasswordRecovery" RenderOuterTable="false" SuccessText="Your new temporary password has been emailed to you with instructions on how to reset it.">
        <UserNameTemplate>
            <span class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </span>

            <div class="form-group">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Email" AutoCompleteType="None" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
            </div>

            <div class="form-group">
                <asp:Button runat="server" CommandName="Submit" Text="Reset Password" CssClass="btn btn-default" />
            </div>
        </UserNameTemplate>

        <MailDefinition BodyFileName="~/Emails/Account/ResetPassword.aspx" IsBodyHtml="true" Priority="Normal" Subject="Password Reset - My Law Tools" From="no-reply@mylawtools.com" />
    </asp:PasswordRecovery>
    
    <div class="text-left">
        Already have an account? <a href="/Account/Login">Click here to login</a><br />
        Don't have an account yet? <a href="/Account/Register">Click here to create a new account</a><br />
    </div>

</asp:Content>