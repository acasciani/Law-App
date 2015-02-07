<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Calendar.ascx.cs" Inherits="LawAppWeb.Controls.Calendar" %>
<%@ Register Assembly="LawApp" Namespace="LawAppWeb.Controls" TagPrefix="ui" %>

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
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Sunday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Sunday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Monday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Monday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Tuesday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Tuesday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Wednesday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Wednesday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Thursday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Thursday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Friday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Friday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" Date='<%# (LawAppWeb.Day)Eval("Saturday") %>' OnDayClicked="On_DayClicked" CssClass='<%#Eval("Saturday")==null ? "" : "CalendarDay" %>' />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
</div>
</ContentTemplate>
    </asp:UpdatePanel>