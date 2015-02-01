<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Calendar.ascx.cs" Inherits="LawAppWeb.Controls.Calendar" %>
<%@ Register Assembly="LawApp" Namespace="LawAppWeb.Controls" TagPrefix="ui" %>

<script>
    function CheckMarkDate(parameter) {
        //__doPostBack('', 'parameter');
    }
</script>

<asp:UpdatePanel runat="server" ID="pnlCalendar" UpdateMode="Conditional">
    <ContentTemplate>
<div class="panel month">
        <table class="table table-bordered">
            <thead>
                <tr class="month-lbl">
                    <th colspan="7"><asp:Label ID="lblMonthYear" runat="server" /></th>
                </tr>
                <tr class="weekday-lbl">
                    <th>S</th>
                    <th>M</th>
                    <th>T</th>
                    <th>W</th>
                    <th>T</th>
                    <th>F</th>
                    <th>S</th>
                </tr>
            </thead>
            <tbody runat="server">
                <asp:Repeater ID="CalendarWeeks" runat="server">
                    <ItemTemplate>
                        <tr>
                            <ui:CalendarDay runat="server" ID="Sunday" Date='<%# (DateTime?)Eval("Sunday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Monday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Tuesday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Wednesday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Thursday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Friday") %>' OnDayClicked="On_DayClicked" />
                            <ui:CalendarDay runat="server" Date='<%# (DateTime?)Eval("Saturday") %>' OnDayClicked="On_DayClicked" />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
</div>
</ContentTemplate>
    </asp:UpdatePanel>