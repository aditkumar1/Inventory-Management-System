<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="UserAdd.aspx.cs" Inherits="Store_admin_ItemAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>User Add/Delete</h1>
        <!-- Headings -->
        <br />
        <br />
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
            DataKeyNames="Userid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
            <Columns>
                <asp:BoundField DataField="Userid" HeaderText="User Id" ItemStyle-Width="150" />
                <asp:BoundField DataField="Username" HeaderText="User Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" ItemStyle-Width="150" />
                <asp:BoundField DataField="Depname" HeaderText="Department" ItemStyle-Width="150" />
                <asp:BoundField DataField="Role" HeaderText="Role" ItemStyle-Width="150" />
                <asp:CommandField ButtonType="Link" ShowDeleteButton="true"
                    ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%">
            <tr>
                <td style="width: 150px">User Id<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtUserid" runat="server" Width="80%" />
                </td>
                <td style="width: 150px">User Name<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtUserName" runat="server" Width="80%" AutoCompleteType="Disabled" />
                </td>
                <td style="width: 150px">Password<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtPassword" runat="server" Width="80%" TextMode="Password" AutoCompleteType="Disabled" />
                </td>
                <td style="width: 150px">Designation<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:TextBox ID="txtDesignation" runat="server" Width="80%" />
                </td>
                <td style="width: 150px">Department<asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 150px">Roles<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    :<br />
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Width="80%" Height="40px" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>"
            SelectCommand="SELECT * FROM UserDetailsMain where Designation NOT LIKE 'master'"
            InsertCommand="INSERT INTO UserDetailsMain(Userid,Password,Username,Designation,Depname,Role) VALUES (@Userid,@Password, @Username,@Designation,@Depname,@Role)"
            DeleteCommand="DELETE FROM UserDetailsMain WHERE Userid = @Userid">
            <InsertParameters>
                <asp:ControlParameter Name="Userid" ControlID="txtUserid" Type="String" />
                <asp:ControlParameter Name="Username" ControlID="txtUserName" Type="String" />
                <asp:ControlParameter Name="Password" ControlID="txtPassword" Type="String" />
                <asp:ControlParameter Name="Designation" ControlID="txtDesignation" Type="String" />
                <asp:ControlParameter Name="Depname" ControlID="DropDownList1" Type="String" />
                <asp:ControlParameter Name="Role" ControlID="DropDownList2" Type="String" />
            </InsertParameters>
            <DeleteParameters>
                <asp:Parameter Name="Userid" Type="String" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*Mandatory Fields"></asp:Label>
    </div>
</asp:Content>


