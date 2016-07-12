<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ItemAdd.aspx.cs" Inherits="Store_admin_ItemAdd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Product Add/Modify</h1>
        <!-- Headings -->
        <br />
        <br />
        <table width="100%" height="100%">
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="50%" Height="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#FF3300" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label4" runat="server" Text="Add/Modify Item"></asp:Label>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td style="height: 40px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="90%"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    &nbsp;<asp:Label ID="Label8" runat="server" Text="Unit"></asp:Label>
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="20%" Height="90%"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList3" ErrorMessage="*" ForeColor="#FF3300" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label3" runat="server" Text="Select Item"></asp:Label>
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="50%" Height="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="#FF3300" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Text="Add" Checked="True" GroupName="Options" />
                    <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Text="Modify" GroupName="Options" />
                </td>
            </tr>
        </table>
        <table width="100%" height="50px">
            <tr>
                <td style="width: 50%; height=40px">
                    <asp:Button ID="Button1" runat="server" Text="Add" Width="40%" Height="90%" OnClick="Button1_Click" />
                </td>
                <td style="width: 50%">
                    <asp:Button ID="Button2" runat="server" Text="Modify" Width="40%" Height="90%" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*Mandatory Fields"></asp:Label>
    </div>
</asp:Content>



