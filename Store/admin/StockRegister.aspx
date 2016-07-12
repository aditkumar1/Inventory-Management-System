<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" CodeFile="StockRegister.aspx.cs" Inherits="Store_PurchaseItemSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Master Stock Register </h1>
        <!-- /col33 -->
        <fieldset>
            <legend>Settings</legend>
            <table class="nostyle" width="100%">
                <tr>
                    <td class="va-top" style="width: 30%;">Select&nbsp; Product Category</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%;">Select Product Name</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="t-center">
                        <asp:Button ID="Button1" runat="server" Height="31px" Style="margin-left: 0px" Text="Submit" Width="98px" OnClick="Button1_Click" />
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
                    <td colspan="4" align="center" style="height: 40px">
                        <asp:Label ID="Label4" runat="server" Text="Stock Register" Font-Bold="True" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="height: 30px">Product Name:
            <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td colspan="2" align="left" style="height: 30px">Product Category:
            <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="TOP">
                        <br />
                        <asp:GridView ID="GridView1" runat="server"
                            HeaderStyle-BackColor="white"
                            AutoGenerateColumns="false" Font-Names="Arial"
                            Font-Size="11pt" ForeColor="#4C4C4C"
                            OnRowDataBound="GridView1_RowDataBound" AllowPaging="false" Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowFooter="True">
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Acctype" HeaderText="Activity Type" ItemStyle-Width="250px">
                                    <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Invoiceno" HeaderText="Invoice/Bill/Issue Slip No" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vfirm" HeaderText="Vendor Name" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Quantity Received" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReceived" runat="server" Text='<%# Eval("QReceived")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="receivedtotal" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity Issued" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblissued" runat="server" Text='<%# Eval("Qissued")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="issuetotal" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Departmant Issued" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Depname")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="totalBalance" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ItemTotalCost" HeaderText="Total Cost" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#6699ff" Font-Bold="True" ForeColor="Black" />
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


