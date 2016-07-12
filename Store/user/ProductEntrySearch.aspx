<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProductEntrySearch.aspx.cs" Inherits="ProductEntryModify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">

        <h1>INWARD REGISTER SEARCH</h1>
        <!-- Headings -->
        <h2>Input The Field To Search And Press Enter</h2>
        <h2>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SearchSelect" Text="GE NO" AutoPostBack="True" Checked="True" />
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
        </h2>
        <h2>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SearchSelect" Text="Bill No" AutoPostBack="True" />
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
        <h2>Select a GE no and click View Button</h2>
        <h2>
            <asp:GridView ID="GridView1" runat="server"
                HeaderStyle-BackColor="green"
                AutoGenerateColumns="false" Font-Names="Arial"
                Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" Width="100%"
                AllowPaging="true" OnPageIndexChanging="OnPaging" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" PageSize="40">
                <AlternatingRowStyle BackColor="#C2D69B"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton1" runat="server"
                                onclick="RadioCheck(this,'GridView1');" />
                            <asp:HiddenField ID="HiddenField1" runat="server"
                                Value='<%#Eval("GEno")%>' />
                            <asp:HiddenField ID="HiddenField2" runat="server"
                                Value='<%#Eval("Invoiceno")%>' />
                            <asp:HiddenField ID="HiddenField3" runat="server"
                                Value='<%#Eval("Sortdate")%>' />
                        </ItemTemplate>
                        <ItemStyle Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="GEno"
                        HeaderText="GE NO">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Vfirm"
                        HeaderText="Vendor's Name">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Invoiceno"
                        HeaderText="Invoice No">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Date"
                        HeaderText="Date">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Status"
                        HeaderText="Status">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" BackColor="Green"></HeaderStyle>
                <PagerSettings PageButtonCount="40" />
                <RowStyle HorizontalAlign="Center"></RowStyle>
            </asp:GridView>
        </h2>
        <h2>&nbsp;<asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click1" Text="View" Width="200px" />
            <asp:Button ID="Button2" runat="server" Height="50px" OnClick="Button2_Click1"  Text="Delete" Width="200px" />
        </h2>
    </div>
</asp:Content>


