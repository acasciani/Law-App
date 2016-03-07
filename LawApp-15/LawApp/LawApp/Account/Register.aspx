<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LawAppWeb.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="LawAppPlaceHolder">
    <div>
        <h2>Create New Account</h2>
    </div>

    <p class="message-info">
        Passwords are required to be a minimum of 8 characters in length and are alphanumeric.
    </p>

    <ui:AlertBox runat="server" ID="AlertBox" />

    <div class="form-group">
        <asp:TextBox runat="server" ID="txtUsername" TextMode="Email" placeholder="Email" CssClass="form-control" MaxLength="255" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" CssClass="field-validation-error text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
    </div>

    <div class="form-group">
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" CssClass="form-control" MaxLength="24" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="field-validation-error text-danger" ErrorMessage="The password field is required." Display="Dynamic" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password must be alphanumeric, contain at least one number and at least one letter and must be at least 8 characters long." Display="Dynamic" ValidationExpression="^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$" />
        <asp:CustomValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password must be at least 8 characters long." Display="Dynamic" OnServerValidate="validatorPasswordLength_ServerValidate" ID="validatorPasswordLength" />
    </div>

    <div class="form-group">
        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" placeholder="Confirm password" CssClass="form-control" MaxLength="24" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword" CssClass="field-validation-error text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
        <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" CssClass="field-validation-error text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
    </div>

    <div class="form-group">
        <div class="row">
            <div class="col-xs-12 text-right">
                <asp:Button runat="server" ID="btnRegister" OnClick="btnRegister_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

    <div class="text-left">
        Already have an account?
        <asp:HyperLink runat="server" ID="LoginHyperLink" ViewStateMode="Disabled">Click here to login.</asp:HyperLink>
    </div>
</asp:Content>