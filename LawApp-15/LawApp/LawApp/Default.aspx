<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">

    <h2>Welcome</h2>
    <p>We are currently developing a new release of Time Sharing Calendar. The new application is faster and more user friendly, making your work more productive and efficient. We are allowing end users to BETA test as we continue development.
        If you are interested in using the new platform, here's what we <em><strong>ask</strong></em>:<br />
        <ul>
            <li>Remember this application is still in development, some features will be unstable and others unusable. Any issues you encounter will be logged and fixed in a future release.</li>
            <li>If you encounter any issues, note them in detail. If you can provide screenshots that is very helpful in debugging issues. Providing detailed information including: browser (and version), operating system (windows/iOS/etc), 
                screen size, mobile/tablet/laptop/desktop interface will be helpful in diagnosing your issues.</li>
            <li>Let us know what your favorite features are or the features you use most often. We want to optimize these for your use!</li>
        </ul><br /><br />

        To begin, <a href="/Account/Register.aspx?ReturnUrl=/Modules/TSC/Default.aspx">click here to create a new BETA account</a>. When you have created your login information, please send an email to <a href="mailto:lawapp15@gmail.com">lawapp15@gmail.com</a> 
        with the subject: "Request BETA Access for TSC: {put login email address here}". Once we receive that email, you will be granted full BETA access and will receive a confirmation email within 48 hours.

        <br /><br />
        <strong>Already have a BETA account?</strong> <a href="/Account/Login.aspx?ReturnUrl=/Modules/TSC/Default.aspx">Login now</a>
    </p>

</asp:Content>
