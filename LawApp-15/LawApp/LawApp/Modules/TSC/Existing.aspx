<%@ Page Title="Saved Calendars" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="true" CodeBehind="Existing.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Existing" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">
    <asp:UpdateProgress runat="server">
        <ProgressTemplate>
            <div class="spinner-wrapper">
                <div class="spinner-cover"></div>
                <div class="spinner">
                    <div class="bounce1"></div>
                    <div class="bounce2"></div>
                    <div class="bounce3"></div>
                    <div class="bounce4"></div>
                </div>
                <div class="spinner-text">Please wait</div>
            </div>
            <div class="loader-cover"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <asp:UpdatePanel runat="server" ID="MainContent">
        <ContentTemplate>
            <script type="text/javascript">
                function confirmDelete() {
                    var alertText = 'Please confirm that you would like to delete the selected calendar.';
                    return confirm(alertText);
                }
                function confirmDuplicate() {
                    var alertText = 'Please confirm that you would like to duplicate the selected calendar.';
                    return confirm(alertText);
                }
            </script>

            <ui:AlertBox runat="server" ID="AlertBox" />

            <div class="col-sm-12">
                <div class="row">
                    <asp:GridView runat="server" ID="Results" EmptyDataText="You have not saved any calendars yet." AutoGenerateColumns="false" CssClass="table table-striped table-responsive table-hover">
                        <Columns>
                            <asp:BoundField DataField="CaseName" HeaderText="Case Name" ShowHeader="true" />
                            <asp:BoundField DataField="CaseNumber" HeaderText="Case #" ShowHeader="true" />
                            <asp:BoundField DataField="Exhibit" HeaderText="Exhibit" ShowHeader="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='Default.aspx?cid=<%# Eval("CalendarId") %>' class="glyphicon glyphicon-edit" title="Open to view and edit calendar"></a>&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("CalendarId") %>' ID="Clone" OnClientClick='return confirmDuplicate()' OnClick="Clone_Click" CssClass="glyphicon glyphicon-new-window" ToolTip="Duplicate this calendar" />&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("CalendarId") %>' ID="Delete" OnClientClick='return confirmDelete()' OnClick="Delete_Click" CssClass="glyphicon glyphicon-trash" ToolTip="Delete this calendar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
