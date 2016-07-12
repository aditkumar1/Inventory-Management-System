<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="VendorAdd.aspx.cs" Inherits="Store_admin_ItemAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Vendor Add/Modify</h1>
        <!-- Headings -->
        <br />
        <br />
        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="Vendorid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                <Columns>
                    <asp:BoundField DataField="Vfirm" HeaderText="Vendor Firm" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Vaddress" HeaderText="Vendor Address" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Vname" HeaderText="Vendor Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Vcontactno" HeaderText="Vendor Contact No" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Vemail" HeaderText="Vendor Email" ItemStyle-Width="100" />
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                        ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%">
            <tr>
                <td style="width: 150px">Vendor Firm<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtVfirm" runat="server" Width="80%" />
                </td>
                <td style="width: 150px">Vendor Address:<br />
                    <asp:TextBox ID="txtAddress" runat="server" Width="80%" TextMode="MultiLine" />
                </td>
                <td style="width: 150px">Vendor Name:<br />
                    <asp:TextBox ID="txtName" runat="server" Width="80%" />
                </td>
                <td style="width: 150px">Vendor Contact No:<br />
                    <asp:TextBox ID="txtVcontactno" runat="server" Width="80%" TextMode="Phone" />
                </td>
                <td style="width: 150px">Vendor Email:<br />
                    <asp:TextBox ID="txtVemail" runat="server" Width="80%" TextMode="Email" />
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Width="80%" Height="40px" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreConnection %>"
            SelectCommand="SELECT * FROM VendorDetails"
            InsertCommand="INSERT INTO VendorDetails VALUES ((Select isnull(max(Vendorid),0) from VendorDetails)+1,@Vfirm, @Vaddress,@Vname,@Vcontactno,@Vemail)"
            UpdateCommand="UPDATE VendorDetails SET Vfirm = @Vfirm, Vaddress = @Vaddress,Vname=@Vname,Vcontactno=@Vcontactno,Vemail=@Vemail WHERE Vendorid = @Vendorid"
            DeleteCommand="DELETE FROM VendorDetails WHERE Vendorid = @Vendorid">
            <InsertParameters>
                <asp:ControlParameter Name="Vname" ControlID="txtName" Type="String" />
                <asp:ControlParameter Name="Vaddress" ControlID="txtAddress" Type="String" />
                <asp:ControlParameter Name="Vfirm" ControlID="txtVfirm" Type="String" />
                <asp:ControlParameter Name="Vcontactno" ControlID="txtVcontactno" Type="String" />
                <asp:ControlParameter Name="Vemail" ControlID="txtVemail" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Vendorid" Type="Int32" />
                <asp:Parameter Name="Vname" Type="String" />
                <asp:Parameter Name="Vaddress" Type="String" />
                <asp:Parameter Name="Vfirm" Type="String" />
                <asp:Parameter Name="Vcontactno" Type="String" />
                <asp:Parameter Name="Vemail" Type="String" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Vendorid" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*Mandatory Fields"></asp:Label>
    </div>
</asp:Content>


