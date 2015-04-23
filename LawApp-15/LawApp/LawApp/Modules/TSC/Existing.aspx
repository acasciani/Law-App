<%@ Page Title="Existing Calendars" Language="C#" MasterPageFile="~/Modules/TSC/TSC.master" AutoEventWireup="true" CodeBehind="Existing.aspx.cs" Inherits="LawAppWeb.Modules.TSC.Existing" %>

<asp:Content ID="TSCProduct_Page" ContentPlaceHolderID="TSCProduct_Holder" runat="server">

    <div class="col-sm-12">
        <div class="row">
            <asp:GridView runat="server" ID="Results" EmptyDataText="You have not saved any calendars yet." AutoGenerateColumns="false" CssClass="table table-striped table-responsive table-hover">
                <Columns>
                    <asp:BoundField DataField="CaseNumber" HeaderText="Case #" ShowHeader="true" />
                    <asp:BoundField DataField="CaseName" HeaderText="Case Name" ShowHeader="true" />
                    <asp:BoundField DataField="Exhibit" HeaderText="Exhibit" ShowHeader="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='Default.aspx?cid=<%# Eval("CalendarId") %>' class="glyphicon glyphicon-edit" title="Open to view and edit calendar"></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
