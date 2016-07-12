<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Store_admin_ProductModify" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Reports</h1>
        <!-- Headings -->
        <p class="msg info">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ProductEntrySummary.aspx">Product Received Report</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ProductIssueSummary.aspx">Product Issue Report</asp:HyperLink>
        </p>
    </div>
</asp:Content>


