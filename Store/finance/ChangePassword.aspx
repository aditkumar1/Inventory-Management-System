<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Store_user_ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Change Password</h1>
        <br />
        <table width="100%">
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label1" runat="server" Text="Enter Old Password"></asp:Label>
                </td>
                <td style="width: 70%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="30px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label2" runat="server" Text="Enter New Password"></asp:Label>
                </td>
                <td style="width: 70%">
                    <asp:TextBox ID="TextBox2" runat="server" Width="50%" Height="30px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; height: 40px">
                    <asp:Label ID="Label3" runat="server" Text="Re-Enter New Password"></asp:Label>
                </td>
                <td style="width: 70%">
                    <asp:TextBox ID="TextBox3" runat="server" Width="50%" Height="30px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <!-- Headings -->
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="Change" Align="center" Width="250px" Height="40px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Reset" Align="center" Width="250px" Height="40px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
    </div>
    <br />
</asp:Content>



