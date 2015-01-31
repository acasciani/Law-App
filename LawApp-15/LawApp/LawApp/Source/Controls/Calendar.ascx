<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Calendar.ascx.cs" Inherits="LawAppWeb.Controls.Calendar" %>

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
            <tbody>
                <asp:Repeater ID="CalendarWeeks" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Sunday") == null ? "" : ((DateTime)Eval("Sunday")).Day.ToString() %></td>
                            <td><%# Eval("Monday") == null ? "" : ((DateTime)Eval("Monday")).Day.ToString() %></td>
                            <td><%# Eval("Tuesday") == null ? "" : ((DateTime)Eval("Tuesday")).Day.ToString() %></td>
                            <td><%# Eval("Wednesday") == null ? "" : ((DateTime)Eval("Wednesday")).Day.ToString() %></td>
                            <td><%# Eval("Thursday") == null ? "" : ((DateTime)Eval("Thursday")).Day.ToString() %></td>
                            <td><%# Eval("Friday") == null ? "" : ((DateTime)Eval("Friday")).Day.ToString() %></td>
                            <td><%# Eval("Saturday") == null ? "" : ((DateTime)Eval("Saturday")).Day.ToString() %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
</div>