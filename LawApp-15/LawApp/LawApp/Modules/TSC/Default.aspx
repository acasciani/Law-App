<%@ Page Title="Time Sharing Calendar" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Default" %>
<%@ Register TagPrefix="ui" TagName="Calendar" Src="~/Source/Controls/Calendar.ascx" %>
<%@ Register TagPrefix="ui" Assembly="LawApp" Namespace="LawAppWeb.Controls" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">

 



    <div class="col-md-4 collapsed" id="drawer">
        <div class="panel-group" id="panel-300013">
            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#panel-300013" href="#panel-element-233857">Weekend Overnights</a></div>
                <div id="panel-element-233857" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <strong>Weekend overnights</strong> for purposes of this calendar is every other weekend (Friday overnight and Saturday overnight) spent with Parent B.

                        <div class="form-horizontal">
                            <div class="col-sm-12 checkbox form-group"><label><asp:CheckBox runat="server" /> Every other weekend Choose first Friday</label></div>
                            <div class="col-sm-offset-1 col-sm-12 form-group"><asp:TextBox CssClass="form-control" runat="server" TextMode="Date" /></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#panel-300013" href="#panel-element-233858">Individual Overnights</a></div>
                <div id="panel-element-233858" class="panel-collapse collapse">
                    <div class="panel-body">
                        Select any overnights spent with Parent B that may apply.
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><a class="panel-title" data-toggle="collapse" data-parent="#panel-300013" href="#panel-element-233859">Weekend Overnights</a></div>
                <div id="panel-element-233859" class="panel-collapse collapse">
                    <div class="panel-body">

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

                <asp:UpdatePanel runat="server" ID="pnlDaysClickedUpdate" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row clearfix">
                            <div class="col-sm-12 days-selected">
                                You have selected <span id="tsc-calendar-days-selected-count">0</span> of <span id="tsc-calendar-days-total-count">0</span> days.
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
    
                <div class="row clearfix" id="CalendarsHolder" runat="server"></div>

            </div>
        </div>
    </div>

</asp:Content>