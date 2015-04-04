<%@ Page Title="Time Sharing Calendar" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Default" %>
<%@ Register TagPrefix="ui" TagName="Calendar" Src="~/Source/Controls/Calendar.ascx" %>
<%@ Register TagPrefix="ui" Assembly="LawApp" Namespace="LawAppWeb.Controls" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">

    <div class="col-md-4 collapsed" id="drawer">
                <div class="row clearfix">
                    <div class="col-sm-12 days-selected">
                        <span class="tsc-calendar-days-selected-count">0</span> of <span class="tsc-calendar-days-total-count">0</span> overnights selected (<span class="tsc-calendar-days-selected-percentage">0</span>%)
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
                            <div class="col-sm-12 checkbox form-group"><label><asp:CheckBox runat="server" CssClass="checkbox-weekend" data-toggle="radio" /> Every other weekend Choose first Friday</label></div>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date friday-only">
                                    <asp:TextBox CssClass="form-control WeekendDateStart" runat="server" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-individual-overnights">Individual Overnights</a></div>
                <div id="criteria-individual-overnights" class="panel-collapse collapse">
                    <div class="panel-body">
                        Select any overnights spent with Parent B that may apply.
                        <hr />

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Monday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualMondayDate" data-day="Monday">
                                <asp:ListItem Value="1">Every Monday</asp:ListItem>
                                <asp:ListItem Value="2">Every other MO, starting (select date) (select date)</asp:ListItem>
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
                                <asp:ListItem Value="2">Every other TU, starting (select date)</asp:ListItem>
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
                                <asp:ListItem Value="2">Every other WE, starting (select date)</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date wednesday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualWednesdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Thursday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualThursdayDate" data-day="Thursday">
                                <asp:ListItem Value="1">Every Thursday</asp:ListItem>
                                <asp:ListItem Value="2">Every other TR, starting (select date)</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date thursday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualThursdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Friday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualFridayDate" data-day="Friday">
                                <asp:ListItem Value="1">Every Friday</asp:ListItem>
                                <asp:ListItem Value="2">Every other FR, starting (select date)</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date friday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualFridayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Saturday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualSaturdayDate" data-day="Saturday">
                                <asp:ListItem Value="1">Every Saturday</asp:ListItem>
                                <asp:ListItem Value="2">Every other SA, starting (select date)</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date saturday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualSaturdayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-horizontal">
                            <asp:CheckBoxList ID="Sunday" runat="server" CssClass="checkbox-list" data-toggle="radio" data-start-date="#IndividualSundayDate" data-day="Sunday">
                                <asp:ListItem Value="1">Every Sunday</asp:ListItem>
                                <asp:ListItem Value="2">Every other SU, starting (select date)</asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="col-sm-offset-1 col-sm-12 form-group">
                                <div class="input-group date sunday-only">
                                    <asp:TextBox CssClass="form-control IndividualDateStart" runat="server" ID="IndividualSundayDate" ClientIDMode="Static" Enabled="false" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-holidays">Holidays</a></div>
                <div id="criteria-holidays" class="panel-collapse collapse">
                    <div class="panel-body">
                        Holidays are displayed on the calendar as colored dots. The holiday markers can be hidden by toggling the checkbox below.
                        <hr />
                        <div class="form-horizontal clearfix">
                            <div class="col-sm-12 checkbox form-group"><label><asp:CheckBox runat="server" CssClass="checkbox-holidays" data-toggle="radio" /> Display holidays on calendar</label></div>
                        </div>
                        <hr />
                        <div class="col-sm-12" id="holiday-key-container">
                            <div class="holiday-key">No holidays were loaded.</div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-breaks-spring">Spring Break</a></div>
                <div id="criteria-breaks-spring" class="panel-collapse collapse criteria-breaks" data-break-color="green">
                    <div class="panel-body">
                        If dates input, then Spring Break will show in green on the calendar if one of the selections below is chosen. Please note that weekend and weekday nights previously selected will be overridden and controlled by the choice selected below.
                        <hr />

                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=SpringBreakStart.ClientID %>">First night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakStart" runat="server" ID="SpringBreakStart" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=SpringBreakEnd.ClientID %>">Last night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakEnd" runat="server" ID="SpringBreakEnd" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:CheckBoxList ID="SpringBreakPresentation" runat="server" CssClass="checkbox-breaks" data-toggle="radio" data-start-date="#SpringBreakStart" data-end-date="#SpringBreakEnd">
                                        <asp:ListItem Value="1">Show color only</asp:ListItem>
                                        <asp:ListItem Value="2">Parent B gets 1st ½</asp:ListItem>
                                        <asp:ListItem Value="3">Parent B gets 2nd ½</asp:ListItem>
                                        <asp:ListItem Value="4">Parent B gets 100%</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr />
                        If time period is an odd number of nights and the holiday is split in 1/2, then the default listing for this calendar is to give Parent B the extra night. If this is not the desired outcome, then User must deselect the extra night.
                    </div>    
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-breaks-summer">Summer Break</a></div>
                <div id="criteria-breaks-summer" class="panel-collapse collapse criteria-breaks" data-break-color="orange">
                    <div class="panel-body">
                        If dates input, then Summer Break will show in orange on the calendar if one of the selections below is chosen. Please note that weekend and weekday nights previously selected will be overridden and controlled by the choice selected below.
                        <hr />

                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=SummerBreakStart.ClientID %>">First night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakStart" runat="server" ID="SummerBreakStart" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=SummerBreakEnd.ClientID %>">Last night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakEnd" runat="server" ID="SummerBreakEnd" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:CheckBoxList ID="SummerBreakPresentation" runat="server" CssClass="checkbox-breaks" data-toggle="radio" data-start-date="#SummerBreakStart" data-end-date="#SummerBreakEnd">
                                        <asp:ListItem Value="1">Show color only</asp:ListItem>
                                        <asp:ListItem Value="2">Parent B gets 1st ½</asp:ListItem>
                                        <asp:ListItem Value="3">Parent B gets 2nd ½</asp:ListItem>
                                        <asp:ListItem Value="4">Parent B gets 100%</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr />
                        If time period is an odd number of nights and the holiday is split in 1/2, then the default listing for this calendar is to give Parent B the extra night. If this is not the desired outcome, then User must deselect the extra night.
                    </div>    
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#criteria" href="#criteria-breaks-winter">Winter Break</a></div>
                <div id="criteria-breaks-winter" class="panel-collapse collapse criteria-breaks" data-break-color="red">
                    <div class="panel-body">
                        If dates input, then Winter Break will show in red on the calendar if one of the selections below is chosen. Please note that weekend and weekday nights previously selected will be overridden and controlled by the choice selected below.
                        <hr />

                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=WinterBreakStart.ClientID %>">First night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakStart" runat="server" ID="WinterBreakStart" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-md-12 col-lg-6">
                                    <label class="control-label" for="<%=WinterBreakEnd.ClientID %>">Last night</label>
                                    <div class="input-group date">
                                        <asp:TextBox CssClass="form-control BreakEnd" runat="server" ID="WinterBreakEnd" ClientIDMode="Static" /><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:CheckBoxList ID="WinterBreakPresentation" runat="server" CssClass="checkbox-breaks" data-toggle="radio" data-start-date="#WinterBreakStart" data-end-date="#WinterBreakEnd">
                                        <asp:ListItem Value="1">Show color only</asp:ListItem>
                                        <asp:ListItem Value="2">Parent B gets 1st ½</asp:ListItem>
                                        <asp:ListItem Value="3">Parent B gets 2nd ½</asp:ListItem>
                                        <asp:ListItem Value="4">Parent B gets 100%</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <hr />
                        If time period is an odd number of nights and the holiday is split in 1/2, then the default listing for this calendar is to give Parent B the extra night. If this is not the desired outcome, then User must deselect the extra night.
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
                        <div class="clearfix">
                            <div class="pull-left" style="line-height:34px;">
                                <span class="tsc-calendar-days-selected-count">0</span> of <span class="tsc-calendar-days-total-count">0</span> overnights selected (<span class="tsc-calendar-days-selected-percentage">0</span>%)
                            </div>
                            <div class="pull-right">
                                <div class="btn-group pull-right" aria-label="Calendar Options" role="group">
                                    <asp:button runat="server" UseSubmitBehavior="false" Text="Save" ToolTip="Save calendar to your account" CssClass="btn btn-default disabled" aria-label="Save Calendar For Later Access"></asp:button>
                                    <asp:button runat="server" UseSubmitBehavior="false" Text="Print" ToolTip="Print calendar to a PDF" CssClass="btn btn-default disabled" aria-label="Print Calendar to a PDF"></asp:button>
                                    <asp:button runat="server" UseSubmitBehavior="false" OnClientClick="return;" Text="Clear" ToolTip="Clear selected dates and options in toolbar" CssClass="btn btn-danger" aria-label="Clear Selected Dates and Toolbar" id="btnClearCalendar" ClientIDMode="Static"></asp:button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    
                <div class="row clearfix" id="CalendarsHolder" runat="server"></div>

            </div>
        </div>
    </div>

</asp:Content>