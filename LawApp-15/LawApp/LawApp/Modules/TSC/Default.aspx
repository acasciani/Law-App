<%@ Page Title="Time Sharing Calendar" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Default" %>
<%@ Register TagPrefix="ui" TagName="Calendar" Src="~/Source/Controls/Calendar.ascx" %>
<%@ Register TagPrefix="ui" Assembly="LawApp" Namespace="LawAppWeb.Controls" %>

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

            function pageLoad() {
                $('#tsc-calendar-days-selected-count').text($('.day-checked').length.toString());
                $('#tsc-calendar-days-total-count').text($('.CalendarDay').length.toString());
            }
        </script>

    <asp:UpdatePanel runat="server" ID="pnlDaysClickedUpdate" UpdateMode="Conditional">
        <ContentTemplate>

    
            <div class="row clearfix">
                <div class="col-sm-12">
                    You have selected <span id="tsc-calendar-days-selected-count">0</span> of <span id="tsc-calendar-days-total-count">0</span> days.
                </div>
            </div>
    </ContentTemplate>
    </asp:UpdatePanel>


            <div class="row clearfix" id="CalendarsHolder" runat="server"></div>
        

</asp:Content>