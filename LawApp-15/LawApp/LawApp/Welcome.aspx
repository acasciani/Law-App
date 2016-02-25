<%@ Page Title="My Law Tools - Next Generation Attorney Tools" Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="LawAppWeb.Welcome" %>


<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <title>My Law Tools - Next Generation Attorney Tools</title>
    <meta charset="utf-8" />
	<meta name="description" content="MyLawTools.com provides attorneys and individuals with a wide range of easy to use law tools.">
	<meta name="keywords" content="family law, divorce, custody, attorney, lawyer, florida law, florida divorce attorneys, florida time sharing, time-sharing, florida time-sharing, time sharing calendar, timesharing, timesharing calendar, my law tools">
	<meta name="viewport" content="width=device-width, initial-scale=1">

    <!--favicon--
	<link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
	<link rel="icon" href="img/favicon.ico" type="image/x-icon">
        -->

    <link href="~/Content/Site.css" rel="stylesheet" /> 
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" /> 
    <link href="~/Content/bootstrap-datepicker3.min.css" rel="stylesheet" /> 
    <link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300' rel='stylesheet' type='text/css'>

    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <asp:PlaceHolder runat="server">        
        <script src="<%: ResolveUrl("~/Scripts/modernizr-2.6.2.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery-2.1.3.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery-ui-1.11.2.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/bootstrap.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/lodash.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/bootstrap-datepicker.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery.validate.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/Datepicker.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery.cookie.js") %>"></script>
    </asp:PlaceHolder>
    <meta name="viewport" content="width=device-width" />

    <style type="text/css">
        body {
            margin-top: 0px !important;
        }

        h1 {
            font-family: 'Open Sans Condensed', sans-serif;
        }

        h1:first-child {
            color:#337AB7;
        }

        h1:nth-child(2){
            color:#A94442;
        }

        h1:nth-child(3){
            color:#8A6D3B;
        }
    </style>
</head>

<body>
    <form runat="server">
        <asp:ScriptManager runat="server" ID="MainScriptManager" EnablePartialRendering="true" LoadScriptsBeforeUI="true">
        </asp:ScriptManager>

        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#more-user-options"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand" href="/">My Law Tools</a>
                </div>

                <div class="collapse navbar-collapse" id="more-user-options">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="/Account/Login">Login</a></li>
                        <li><a href="/Account/Register">Register</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <h1><strong>Lawyers!</strong> Are you still preparing your time-sharing calendars by hand?</h1>

                    <h1>Worse yet, are you "estimating" the number of overnights for child support?</h1>

                    <h1>Imagine creating accurate time-sharing calendars in 60 seconds…or less!</h1>

                    <h1>Watch the video below to see the tool insiders are using to crush their competition.</h1>

                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <a href="/Account/Login" class="btn btn-default">Login To Your Account</a>

                            <a href="/Account/Register" class="btn btn-primary">Register A New Account</a>
                        </div>
                    </div>

                    <div class="embed-responsive embed-responsive-16by9" style="margin-top: 20px;">
                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/954JJRlg1io" frameborder="0" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>

</html>