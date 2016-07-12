<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IssueSearch.aspx.cs" Inherits="ProductEntryModify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">

        <h1>ISSUE REGISTER SUMMARY</h1>
        <!-- Headings -->
        <h2>Input The Field To Search And Press Enter</h2>
        <h2>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SearchSelect" Text="Issue Slip No" AutoPostBack="True" Checked="True" />
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
        </h2>
        <h2>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SearchSelect" Text="Department" AutoPostBack="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
        </h2>
        <h2>
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="SearchSelect" Text="Date" AutoPostBack="True" />
            &nbsp;<asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox3_CalendarExtender" Format="yyyy-MM-dd" runat="server" Enabled="True" TargetControlID="TextBox3" CssClass="cal_Theme1">
            </asp:CalendarExtender>
            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" Enabled="True" TargetControlID="TextBox4" CssClass="cal_Theme1">
            </asp:CalendarExtender>
        </h2>
        <!-- Headings -->
        <h2>&nbsp;</h2>
        <h2>Select an Issue Slip no and click View Button</h2>
        <h2>
            <asp:GridView ID="GridView1" runat="server"
                HeaderStyle-BackColor="green"
                AutoGenerateColumns="false" Font-Names="Arial"
                Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" Width="100%"
                AllowPaging="true" OnPageIndexChanging="OnPaging">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton1" runat="server"
                                onclick="RadioCheck(this,'GridView1');" />
                            <asp:HiddenField ID="HiddenField1" runat="server"
                                Value='<%#Eval("Isno")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Isno"
                        HeaderText="Issue Slip No" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="IsBy"
                        HeaderText="Issued By" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Depname"
                        HeaderText="Department" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Date"
                        HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </h2>
        <h2>&nbsp;<asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click1" Text="View" Width="200px" />
        </h2>
    </div>
</asp:Content>
