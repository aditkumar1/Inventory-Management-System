<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseOrderSearch.aspx.cs" Inherits="ProductEntryModify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">

        <h1>Purchase Order Search</h1>
        <!-- Headings -->
        <h2>Input The Field To Search And Press Enter</h2>
        <p>&nbsp;</p>
        <h2>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SearchSelect" Text="Purchase Order No" AutoPostBack="True" Checked="True" />
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
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
        <h2>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
        </h2>
        <h2>Select a PO no and click View Button</h2>
        <h2>
            <asp:GridView ID="GridView1" runat="server"
                HeaderStyle-BackColor="green"
                AutoGenerateColumns="false" Font-Names="Arial"
                Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" Width="100%"
                AllowPaging="true" OnPageIndexChanging="OnPaging" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton1" runat="server"
                                onclick="RadioCheck(this,'GridView1');" />
                            <asp:HiddenField ID="HiddenField1" runat="server"
                                Value='<%#Eval("Pono")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Pono"
                        HeaderText="Pruchase Order No" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Vfirm"
                        HeaderText="Vendor's Name" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Vaddress"
                        HeaderText="Vendor's Address" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Date"
                        HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </h2>
        <h2>&nbsp;<asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click1" Text="View" Width="200px" />
        </h2>
    </div>
</asp:Content>



