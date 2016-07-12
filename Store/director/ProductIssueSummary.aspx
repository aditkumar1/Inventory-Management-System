<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProductIssueSummary.aspx.cs" Inherits="Store_PurchaseItemSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="content" class="box">
        <h1>Product Issue Reports </h1>
        <!-- /col33 -->
        <fieldset>
            <legend>Settings</legend>
            <table class="nostyle" width="100%">
                <tr>
                    <td style="width: 20%; height: 30px;">Product Category</td>
                    <td style="width: 30%; height: 30px;">
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20%; height: 30px;">Product Name</td>
                    <td style="width: 30%; height: 30px;">
                        <asp:DropDownList ID="DropDownList4" runat="server" Enabled="False" Width="90%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="va-top" style="width: 20%; height: 30px">Department Name</td>
                    <td style="width: 30%; height: 30px">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="90%">
                        </asp:DropDownList>
                    </td>
                    <td class="va-top" style="width: 20%;">&nbsp;Date</td>
                    <td style="width: 30%">
                        <table>
                            <tr>
                                <td>From
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox2" CssClass="cal_Theme2" Format="yyyy-MM-dd">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>To                           
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox3" CssClass="cal_Theme2" Format="yyyy-MM-dd">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="t-right">
                        <asp:Button ID="Button1" runat="server" Height="31px" Style="margin-left: 0px" Text="Submit" Width="98px" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Height="31px" Style="margin-left: 0px" Text="Reset" Width="98px" OnClick="Button3_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <!-- Definition List -->
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <br />
        <asp:Button ID="Button2" runat="server" Height="30px" Text="Print" OnClientClick="return PrintPanel('Panel1');" Width="151px" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <table width="100%" border="2px" height="100%">
                <tr>
                    <td colspan="4" align="center" style="height: 50px"><%= System.Web.Configuration.WebConfigurationManager.AppSettings["Institute"] %>
                <br />
                        <%= System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteAddress"] %></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 40px">Product Issue Report</td>
                </tr>
                <tr>
                    <td colspan="4" align="left" style="height: 30px">Date:
            <asp:Label ID="Label1" runat="server"></asp:Label>
                        &nbsp;to
            <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="TOP">
                        <br />
                        <asp:GridView ID="GridView1" runat="server" GridLines="None"
                            HeaderStyle-BackColor="white"
                            AutoGenerateColumns="false" Font-Names="Arial"
                            Font-Size="11pt" ForeColor="#4C4C4C"
                            AllowPaging="false" Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Isno" HeaderText="Issue Slip No" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Isby" HeaderText="Issued By" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Iname" HeaderText="Product Name" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pcname" HeaderText="Product Category" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Qissued" HeaderText="Quantity Issued" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Depname" HeaderText="Department Name" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left" style="height: 30px">Print Date:
                <asp:Label ID="Label3" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>


