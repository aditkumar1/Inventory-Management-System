<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTheme.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <hr class="noscreen" />
    <!-- Content (Right Column) -->
    <div id="content" class="box">
        <!-- Headings -->
        <asp:Label ID="Label1" runat="server" Text="*Invalid Id or Password. Please retry.." Font-Bold="True" Font-Size="X-Large" ForeColor="#000099"></asp:Label>
        <br />
        <div id="wrapper">
            <form name="login-form" class="login-form" method="post" runat="server">
                <div class="header">
                    <h1>STAFF LOGIN</h1>
                    <span>Fill in the details below to login to management dashboard.Kindly contact the authorities for login details in case of any problem with the login</span>
                </div>
                <div class="content">
                    <asp:TextBox ID="TextBox1" runat="server" name="adminname" type="text" class="input adminname" placeholder="Employee Id"></asp:TextBox>
                    <div class="admin-icon"></div>
                    <asp:TextBox ID="TextBox2" runat="server" name="password" type="password" class="input password" placeholder="Password"></asp:TextBox>
                    <div class="pass-icon"></div>
                </div>
                <div class="footer">
                    <asp:Button ID="Button1" runat="server" Text="Login" type="submit" name="submit" value="Login" class="button" OnClick="Button1_Click" />
                </div>
            </form>
            <br />
        </div>
    </div>
</asp:Content>
