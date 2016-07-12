<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UserMain.aspx.cs" Inherits="UserMain" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>User Home</h1>
        <p>
            &nbsp;
        </p>
        <table width="100%">
            <tr>
                <td style="width: 283px; font-size: large"><b>User Id</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Style="font-size: large" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 283px; font-size: large"><b>Password</td>
                <td>
                    <a href="ChangePassword.aspx">Change Password</a>
                </td>
            </tr>
            <tr class="bg" style="font-weight: bold; font-size: x-large">
                <td style="width: 283px; height: 49px; font-size: large">User Name</td>
                <td style="height: 49px; font-size: large">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 283px; font-size: large"><b>Department</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Style="font-size: large" Text=""></asp:Label>
                    </b></td>
            </tr>
            <tr class="bg" style="font-weight: bold; font-size: x-large">
                <td style="width: 283px; font-size: large">Designation</td>
                <td style="font-size: large">
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 283px; font-size: large"><b>Role</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Style="font-size: large" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <!-- Form -->
    </div>
</asp:Content>


