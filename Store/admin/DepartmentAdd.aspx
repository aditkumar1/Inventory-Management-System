<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="DepartmentAdd.aspx.cs" Inherits="Store_admin_ProductCategoryAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Department Add/Modify</h1>
        <!-- Headings -->
        <br />
        <br />
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
            DataKeyNames="Depid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
            <Columns>
                <asp:BoundField DataField="Depname" HeaderText="Department Name" ItemStyle-Width="150" />
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%">
            <tr>
                <td style="width: 150px">Department Name<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtName" runat="server" Width="80%" />
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Width="80%" Height="40px" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>"
            SelectCommand="SELECT * FROM DepartmentTable"
            InsertCommand="INSERT INTO DepartmentTable VALUES ((Select max(Depid) from DepartmentTable)+1,@Depname)"
            UpdateCommand="UPDATE DepartmentTable SET Depname = @Depname WHERE Depid = @Depid"
            DeleteCommand="DELETE FROM DepartmentTable WHERE Depid = @Depid">
            <InsertParameters>
                <asp:ControlParameter Name="Depname" ControlID="txtName" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Depid" Type="Int32" />
                <asp:Parameter Name="Depname" Type="String" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Depid" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*Mandatory Fields"></asp:Label>
    </div>
</asp:Content>



