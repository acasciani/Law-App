<%@ Page Title="Time Sharing Calendar" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Default" %>
<%@ Register TagPrefix="ui" TagName="Calendar" Src="~/Source/Controls/Calendar.ascx" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">
    <script type="text/javascript">
        $(window).resize(function () {
            resizeCalendarMonthColumns();
        });

        $(function () {
            resizeCalendarMonthColumns();
        });

        function resizeCalendarMonthColumns() {
            var maxCalendarMonthHeight = Math.max.apply(null, $(".column-calendar-month").map(function () {
                return $(this).height();
            }).get());

            $('.column-calendar-month').height(maxCalendarMonthHeight);
        }
    </script>

    <div class="row clearfix">
        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-01-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-02-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-03-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-04-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-05-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-06-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-07-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-08-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-09-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-10-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-11-01" />
        </div>

        <div class="col-lg-4 col-sm-6 column column-calendar-month">
            <ui:Calendar runat="server" MonthReference="2015-12-01" />
        </div>

     </div>


</asp:Content>