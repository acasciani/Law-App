<%@ Page Title="My Subscriptions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawAppWeb.Account.Subscriptions.Default" %>

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

    <div>
        <h2>My Subscriptions</h2>
    </div>

    <ui:AlertBox runat="server" Id="AlertBox" />

    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Timesharing Calendar Subscription
                </div>
                <div class="panel-body">
                    <div runat="server" id="divTSCDetails_NoPlan" visible="false">
                        <div runat="server" id="divTSCDetails_NoPlan_Pending" visible="false">
                            <strong>You currently have a pending subscription.</strong> Please check back for a progress update. If the subscription is still pending in 24 hours, please contact support.
                        </div>

                        <div runat="server" id="divTSCDetails_NoPlan_None" visible="false">
                            <strong>You do not have an active Timesharing Calendar subscription.</strong> <asp:LinkButton runat="server" ID="lnkSubscribeTSC" CommandArgument="1,3,5,6" CommandName="Timesharing Calendar" OnClick="lnkSubscribe_Click">Click here to subscribe</asp:LinkButton>.
                        </div>
                    </div>

                    <div runat="server" id="divTSCDetails" visible="false">
                        <strong>Expires:</strong> <asp:Label runat="server" ID="lblSubTSC_Expires" /><br />
                        <strong>Plan:</strong> <asp:Label runat="server" ID="lblSubTSC_Plan" /><br />
                        <strong>Purchased On:</strong> <asp:Label runat="server" ID="lblSubTSC_PurchasedOn" />
                    </div>

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
