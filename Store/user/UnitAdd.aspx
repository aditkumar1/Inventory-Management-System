<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="UnitAdd.aspx.cs" Inherits="Store_admin_ProductCategoryAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Unit Add/Modify</h1>
        <!-- Headings -->
        <br />
        <br />
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
            DataKeyNames="Unitid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
            <Columns>
                <asp:BoundField DataField="Uname" HeaderText="Unit Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="150" />
                <asp:CommandField ButtonType="Link" ShowEditButton="true"
                    ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%">
            <tr>
                <td style="width: 150px">Unit Name<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtName" runat="server" Width="80%" />
                </td>
                <td style="width: 150px">Description:<br />
                    <asp:TextBox ID="txtDescription" runat="server" Width="80%" TextMode="MultiLine" />
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Width="80%" Height="40px" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreConnection %>"
            SelectCommand="SELECT * FROM UnitDetails"
            InsertCommand="INSERT INTO UnitDetails VALUES ((Select max(Unitid) from UnitDetails)+1,@Uname, @Description)"
            UpdateCommand="UPDATE UnitDetails SET Uname = @Uname, Description = @Description WHERE Unitid = @Unitid"
            DeleteCommand="DELETE FROM UnitDetails WHERE Unitid = @Unitid">
            <InsertParameters>
                <asp:ControlParameter Name="Uname" ControlID="txtName" Type="String" />
                <asp:ControlParameter Name="Description" ControlID="txtDescription" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Unitid" Type="Int32" />
                <asp:Parameter Name="Uname" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Unitid" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*Mandatory Fields"></asp:Label>
    </div>
</asp:Content>


