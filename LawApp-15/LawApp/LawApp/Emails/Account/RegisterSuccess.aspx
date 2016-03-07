<%@ Page Title="Welcome to My Law Tools" Language="C#" MasterPageFile="~/Emails/Email.Master" AutoEventWireup="true" CodeBehind="RegisterSuccess.aspx.cs" Inherits="LawAppWeb.Emails.Account.RegisterSuccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MessageBody" runat="server">
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
                                                <td align="left" style="padding: 5px; color: #31657D; font-family: 'Segoe UI',Verdana; font-size: 120%;"><strong>Welcome to My Law Tools</strong></td>
                                                <td align="right" style="padding: 5px; color: #31657D; font-family: 'Segoe UI',Verdana; font-size: 120%; font-style: italic;"><strong><%: DateTime.Now.ToShortDateString() %></strong></td>
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
                                    Thank you for choosing My Law Tools. Your registration is almost complete. <strong>Please click (or navigate to) the following link to verify your account:</strong><br /><br />
                                    <span align="left"><asp:HyperLink runat="server" ID="lnkVerify" NavigateUrl="http://mylawtools.com/Account/Verify?email={0}&token={1}"></asp:HyperLink></span>
                                    <br /><br />
                                    The link above will expire within 24 hours and the temporary account created will be removed.
                                    <br/><br/>

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