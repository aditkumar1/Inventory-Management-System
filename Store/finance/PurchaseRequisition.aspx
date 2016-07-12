<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseRequisition.aspx.cs" Inherits="Store_user_Search" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Purchase Requisition</h1>
        <!-- Headings -->
        <p class="msg info">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="NewPurchaseRequest.aspx">New Purchase Request</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="PendingPurchaseRequest.aspx">Search Purchase Request</asp:HyperLink>
        </p>
    </div>
</asp:Content>
