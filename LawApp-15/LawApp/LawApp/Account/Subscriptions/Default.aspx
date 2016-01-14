<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Account.Subscriptions.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="LawAppPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#subscribe-TSC-click").click(function () {
                $("#subscribe-TSC").toggle('blind', { display: 'block' }, 500);
            });
        });
    </script>

    <div style="margin-top: 70px;">
        <h2>My Subscriptions</h2>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Timesharing Calendar Subscription
                </div>
                <div class="panel-body">
                    <strong>You do not have an active Timesharing Calendar subscription.</strong> <asp:LinkButton runat="server" ID="lnkSubscribeTSC" CommandArgument="1,3,5,6" CommandName="Timesharing Calendar" OnClick="lnkSubscribe_Click">Click here to subscribe</asp:LinkButton>.
                </div>
            </div>
        </div>
    </div>

    <div class="row" runat="server" id="divSubscribeToProduct" visible="false">
        <div class="col-sm-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Subscribe to <asp:Literal runat="server" ID="litProductName" />
                </div>
                <div class="panel-body">
                    <strong>Please select a plan from the following list:</strong>

                    <div>
                        <asp:RadioButtonList runat="server" ID="chkPlans" AutoPostBack="true" OnSelectedIndexChanged="chkPlans_SelectedIndexChanged" />
                    </div>

                    <div>
                        <asp:LinkButton runat="server" ID="lnkPurchaseSubscription" ToolTip="Purchase Subscription" OnClick="lnkPurchaseSubscription_Click">
                            <span class="glyphicon glyphicon-credit-card"></span> Continue to Purchase Subscription
                        </asp:LinkButton>
                    </div>

                    <hr />
                    
                    <div>
                        <label>Cost:</label> <asp:Label runat="server" ID="lblPlanCost" /><br />
                        <label>Expires:</label> <asp:Label runat="server" ID="lblPlanExpires" /><br />
                        <label>Description:</label> <asp:Label runat="server" ID="lblDescription" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
