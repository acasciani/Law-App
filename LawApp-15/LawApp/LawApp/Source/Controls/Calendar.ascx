<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Calendar.ascx.cs" Inherits="LawAppWeb.Controls.Calendar" %>
<%@ Register Assembly="LawApp" Namespace="LawAppWeb.Controls" TagPrefix="ui" %>

<asp:UpdatePanel runat="server" ID="pnlCalendar" UpdateMode="Conditional">
    <ContentTemplate>
<div class="col-md-4 column-calendar-month">
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
                            <ui:CalendarDay runat="server" ID="Sunday" Date='<%# (LawAppWeb.Day)Eval("Sunday") %>' CssClass='<%#Eval("Sunday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Monday" Date='<%# (LawAppWeb.Day)Eval("Monday") %>' CssClass='<%#Eval("Monday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Tuesday" Date='<%# (LawAppWeb.Day)Eval("Tuesday") %>' CssClass='<%#Eval("Tuesday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Wednesday" Date='<%# (LawAppWeb.Day)Eval("Wednesday") %>' CssClass='<%#Eval("Wednesday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Thursday" Date='<%# (LawAppWeb.Day)Eval("Thursday") %>' CssClass='<%#Eval("Thursday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Friday" Date='<%# (LawAppWeb.Day)Eval("Friday") %>' CssClass='<%#Eval("Friday")==null ? "" : "CalendarDay" %>' />
                            <ui:CalendarDay runat="server" ID="Saturday" Date='<%# (LawAppWeb.Day)Eval("Saturday") %>' CssClass='<%#Eval("Saturday")==null ? "" : "CalendarDay" %>' />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
</div>
</div>
</ContentTemplate>
    </asp:UpdatePanel>