<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="EntryAdd.aspx.cs" Inherits="Store_admin_EntryAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Entry Add</h1>
        <!-- Headings -->
        <p class="msg info">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="ItemAdd.aspx">Add/Modify Product Details</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="ItemDelete.aspx">Delete Product</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="UnitAdd.aspx">Add/Modify Unit Details</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="VendorAdd.aspx">Add/Modify Vendor Details</asp:HyperLink>
        </p>
        <!-- Tabs -->
    </div>
</asp:Content>



