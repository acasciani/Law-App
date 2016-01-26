<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LawAppWeb.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="LawAppPlaceHolder">
    <div>
        <h2>Create New Account</h2>
    </div>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser" RequireEmail="false">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="UserName" TextMode="Email" placeholder="Email" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error text-danger" ErrorMessage="The email field is required." Display="Dynamic" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" placeholder="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error text-danger" ErrorMessage="The password field is required." Display="Dynamic" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" placeholder="Confirm password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="field-validation-error text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="field-validation-error text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12 text-right">
                                <asp:Button runat="server" CommandName="MoveNext" Text="Register" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>

                    <div class="text-left">
                        Already have an account? <asp:HyperLink runat="server" ID="LoginHyperLink" ViewStateMode="Disabled">Click here to login.</asp:HyperLink>
                    </div>

                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>