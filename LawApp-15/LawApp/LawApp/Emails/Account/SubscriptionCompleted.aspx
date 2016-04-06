<%@ Page Title="Subscription Completed" Language="C#" MasterPageFile="~/Emails/Email.Master" AutoEventWireup="true" CodeBehind="SubscriptionCompleted.aspx.cs" Inherits="LawAppWeb.Emails.Account.SubscriptionCompleted" %>

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
                                                <td align="left" style="padding: 5px; color: #31657D; font-family: 'Segoe UI',Verdana; font-size: 120%;"><strong>Subscription Process Completed</strong></td>
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
                                    Your subscription registration for our product <asp:Literal runat="server" ID="litProductName" /> has been successfully completed. We are preparing your account and this may take up to 15 minutes. 
                                    You can access the product from the <a href="http://mylawtools.com/Default.aspx" title="My Law Tools Dashboard">My Law Tools dashboard</a> in 15 minutes.
                                    <br /><br />
                                    Your subscription is active from <asp:Literal runat="server" ID="litActiveFrom" /> to <asp:Literal runat="server" ID="litActiveTo" />
                                    <br /><br />
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