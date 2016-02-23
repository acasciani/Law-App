<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LawAppWeb.Account.Login" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="LawAppPlaceHolder">
    <div>
        <h2>Login</h2>
    </div>

    <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" OnLoggedIn="loginForm_LoggedIn" ID="loginForm">
        <LayoutTemplate>
            <span class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </span>


            <div class="form-group">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error text-danger" ErrorMessage="The password field is required." Display="Dynamic" />
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-xs-8 text-left">
                        <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox-inline">
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            Remember me?
                        </asp:Label>
                    </div>
                    <div class="col-xs-4 text-right">
                        <asp:Button runat="server" CommandName="Login" Text="Login" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
            <div class="text-left">
                Don't have an account yet? <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Click here to create a new account</asp:HyperLink><br />
                Forgot your password? <a href="/Account/ResetPassword">Click here to reset your password</a>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
