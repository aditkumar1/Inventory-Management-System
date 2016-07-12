<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseOrder.aspx.cs" Inherits="Store_user_Search" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Purchase Order</h1>
        <!-- Headings -->
        <p class="msg info">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="PurchaseOrderGenerate.aspx">Generate Purchase Order</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="PurchaseOrderSearch.aspx">Search Purchase Order</asp:HyperLink>
        </p>
    </div>
</asp:Content>
