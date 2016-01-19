<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="LawAppWeb.Account.ManagePassword" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="LawAppPlaceHolder" runat="server">
    <h2>Manage Password</h2>

    <ui:AlertBox runat="server" ID="AlertBox" />

    <asp:ChangePassword runat="server" ID="changePassword"
        CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" 
        SuccessPageUrl="ManagePassword?m=ChangePwdSuccess">
        <ChangePasswordTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">Change Password</div>
                <div class="panel-body">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>

                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="CurrentPassword" CssClass="col-sm-4 control-label">Current Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="The current password field is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-sm-4 control-label">New Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="The new password is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword" CssClass="col-sm-4 control-label">Confirm Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" CssClass="text-danger"
                                     Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>

                        <div class="col-sm-8 col-sm-offset-4">
                             <asp:Button runat="server" CssClass="btn btn-default" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                        </div>
                    </div>
                </div>
            </div>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
