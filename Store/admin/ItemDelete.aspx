<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ItemDelete.aspx.cs" Inherits="Store_admin_ProductCategoryAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Delete Product</h1>
        <!-- Headings -->
        <br />
        <fieldset>
            <legend>Product Category</legend>
            <table width="100%">
                <tr>
                    <td style="height: 40px; width: 40%">
                        <asp:Label ID="Label1" runat="server" Text="Select Product Category"></asp:Label>
                    </td>
                    <td style="height: 40px;">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="60%" Height="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false"
            DataKeyNames="Itemid" OnRowDataBound="OnRowDataBound" EmptyDataText="No Records Found." OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Itemid" HeaderText="Product ID" ItemStyle-Width="150" />
                <asp:BoundField DataField="Iname" HeaderText="Product Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="Uname" HeaderText="Unit Name" ItemStyle-Width="150" />
                <asp:CommandField ButtonType="Link" ShowDeleteButton="true"
                    ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
</asp:Content>


