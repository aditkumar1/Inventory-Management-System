<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="EntryAdd.aspx.cs" Inherits="Store_admin_EntryAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Entry Add</h1>
        <!-- Headings -->
        <p class="msg info">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Store/admin/ProductCategoryAdd.aspx">Add/Modify Product Category </asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Store/admin/ItemAdd.aspx">Add/Modify Product Details</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Store/admin/ItemDelete.aspx">Delete Product</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Store/admin/UnitAdd.aspx">Add/Modify Unit Details</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Store/admin/VendorAdd.aspx">Add/Modify Vendor Details</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Store/admin/DepartmentAdd.aspx">Add/Modify Departments</asp:HyperLink>
        </p>
        <p class="msg info">
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Store/admin/UserAdd.aspx">Add/Delete User Details</asp:HyperLink>
        </p>
        <!-- Tabs -->
    </div>
</asp:Content>



