<%@ Page Title="Password Reset" Language="C#" MasterPageFile="~/Emails/Email.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="LawAppWeb.Emails.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MessageBody" runat="server">

    <table width="100%" cellspacing="0" cellpadding="0" align="center" style="font-size: 100%; border-collapse: collapse;">
        <tbody>
            <tr>
                <td align="center" style="background-color: #ffffff;">
                    <br>
                    <table width="600" cellspacing="0" cellpadding="0" style="border: 1px solid; border-collapse: collapse;">
                        <tbody>
                            <tr>
                                <td style="background-color: #D3EDF9;">
                                    <table width="100%" style="border-collapse: collapse;">
                                        <tbody>
                                            <tr>
                                                <td align="left" style="padding: 5px; color: #31657D; font-family: 'Segoe UI',Verdana; font-size: 120%;"><strong>Password Reset</strong></td>
                                                <td align="right" style="padding: 5px; color: #31657D; font-family: 'Segoe UI',Verdana; font-size: 120%; font-style: italic;"><strong>

                                                    <%: DateTime.Now.ToShortDateString() %></strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 5px; line-height: 5px; background-color: #31657D; height: 5px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; font-family: 'Segoe UI',Verdana; background-color: #ffffff;">
                                    Dear <em><asp:Literal runat="server" ID="litName"/></em>,
                                    <br/><br/>
                                    A request was made to reset your password. Your new temporary password is: <br/><br/>
                                    <span align="center"><asp:Literal runat="server" ID="litPassword" /></span>
                                    <br/><br/>

                                    Please visit <a href="http://mylawtools.com/Account/ManagePassword">http://mylawtools.com/Account/ManagePassword</a> to login and change your password.<br/><br/>
                                    Sincerely,<br/>
                                    Account Support
                                </td>
                            </tr>
                            <tr>
                                <td style="color: #31657D; font-size: 10px; line-height: 10px; background-color: #D3EDF9; height: 10px;">&nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>


</asp:Content>