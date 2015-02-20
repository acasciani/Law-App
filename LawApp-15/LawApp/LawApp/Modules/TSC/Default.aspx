<%@ Page Title="Time Sharing Calendar" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Default" %>
<%@ Register TagPrefix="ui" TagName="Calendar" Src="~/Source/Controls/Calendar.ascx" %>
<%@ Register TagPrefix="ui" Assembly="LawApp" Namespace="LawAppWeb.Controls" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">

    <div class="col-md-4 collapsed" id="drawer">
                <div class="row clearfix">
                    <div class="col-sm-12 days-selected">
                        You have selected <span class="tsc-calendar-days-selected-count">0</span> of <span class="tsc-calendar-days-total-count">0</span> days.
                    </div>
                </div>

        <div class="panel-group" id="criteria">
            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-weekend-overnights">Weekend Overnights</a></div>
                <div id="criteria-weekend-overnights" class="panel-collapse collapse ">
                    <div class="panel-body">
                        <strong>Weekend overnights</strong> for purposes of this calendar is every other weekend (Friday overnight and Saturday overnight) spent with Parent B.
                        <hr />
                        <div class="form-horizontal">
                            <div class="col-sm-12 checkbox form-group"><label><asp:CheckBox runat="server" /> Every other weekend Choose first Friday</label></div>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date monday-only">
                                    <asp:TextBox CssClass="form-control" runat="server" data-provide="datepicker" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-individual-overnights">Individual Overnights</a></div>
                <div id="criteria-individual-overnights" class="panel-collapse collapse in">
                    <div class="panel-body">
                        Select any overnights spent with Parent B that may apply.
                        <hr />

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Monday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualMondayDate" data-day="Monday">
                                <asp:ListItem Value="1">Every Monday</asp:ListItem>
                                <asp:ListItem Value="2">Every other MO, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date monday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualMondayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Tuesday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualTuesdayDate" data-day="Tuesday">
                                <asp:ListItem Value="1">Every Tuesday</asp:ListItem>
                                <asp:ListItem Value="2">Every other TU, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date tuesday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualTuesdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Wednesday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualWednesdayDate" data-day="Wednesday">
                                <asp:ListItem Value="1">Every Wednesday</asp:ListItem>
                                <asp:ListItem Value="2">Every other WE, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualWednesdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Thursday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualThursdayDate" data-day="Thursday">
                                <asp:ListItem Value="1">Every Thursday</asp:ListItem>
                                <asp:ListItem Value="2">Every other TR, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualThursdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Friday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualFridayDate" data-day="Friday">
                                <asp:ListItem Value="1">Every Friday</asp:ListItem>
                                <asp:ListItem Value="2">Every other FR, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualFridayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Saturday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualSaturdayDate" data-day="Saturday">
                                <asp:ListItem Value="1">Every Saturday</asp:ListItem>
                                <asp:ListItem Value="2">Every other SA, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualSaturdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Sunday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualSundayDate" data-day="Sunday">
                                <asp:ListItem Value="1">Every Sunday</asp:ListItem>
                                <asp:ListItem Value="2">Every other SU, starting</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualSundayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    
    <div class="col-md-8" id="workpane">
        <div class="row">
            <div class="col-md-1 col-sm-0 col-xs-0 collapsible">
                <button type="button" onclick="javascript:collapse('#drawer', '#workpane', $(this));">&laquo;</button>
            </div>
            <div class="col-md-11 col-sm-12 col-xs-12">
                <div class="row clearfix">
                    <div class="col-sm-12 days-selected">
                        You have selected <span class="tsc-calendar-days-selected-count">0</span> of <span class="tsc-calendar-days-total-count">0</span> days.
                    </div>
                </div>
    
                <div class="row clearfix" id="CalendarsHolder" runat="server"></div>

            </div>
        </div>
    </div>

</asp:Content>