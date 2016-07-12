<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProductEntrySearchSlip.aspx.cs" Inherits="Store_ProductEntrySearchSlip" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="content" class="box">
        <h1>Product Entry Details</h1>
        <p>
            <asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click" Text="Back To Search" Width="200px" />
        </p>
        <!-- Headings -->
        <!-- Table -->
        <asp:Panel ID="Panel1" runat="server">
            <table width="100%" border="2px" height="100%">
                <tr>
                    <td colspan="4" align="center" style="height: 50px"><%= System.Web.Configuration.WebConfigurationManager.AppSettings["Institute"] %>
                <br />
                        <%= System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteAddress"] %></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 30px">Product Entry Slip
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left" style="height: 60px">Vendor&#39;s Name:&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                        <br />
                        Vendor&#39;s Address:
                 <asp:Label ID="Label7" runat="server" Text="*"></asp:Label>
                        <br />
                        Date:&nbsp;&nbsp;
                 <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; width: 50%;">
                        <b>GE No:&nbsp; </b>
                        <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                    </td>
                    <td width="50%" style="height: 30px">Invoice<b> No:&nbsp; </b>
                        <asp:Label ID="Label4" runat="server" Text="*"></asp:Label>
                        <br />
                        Status:&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="TOP">
                        <br />
                        <asp:GridView ID="GridView1" runat="server"
                            HeaderStyle-BackColor="blue"
                            AutoGenerateColumns="false" Font-Names="Arial"
                            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                            OnRowDataBound="GridView1_RowDataBound" AllowPaging="false" Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowFooter="true">
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <Columns>
                                <asp:BoundField DataField="Srno" HeaderText="Sr" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Iname" HeaderText="Item Name" ItemStyle-Width="2000px">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pcname" HeaderText="Item Category" ItemStyle-Width="200px">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QReceived" HeaderText="Quantity Received" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemTotalCost" HeaderText="Cost" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vat" HeaderText="Vat" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tax" HeaderText="Tax" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Misc" HeaderText="Misc" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Net" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnet" runat="server" Text='<%# Eval("Net")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="nettotal" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#6699ff" Font-Bold="True" ForeColor="Black" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="Blue" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right" style="height: 30px" valign="TOP">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 30px">
                        <div style="text-align: right;">
                            &nbsp;
                        </div>
                        <br />
                        <div>
                            <span style="float: right;">SIGNATURE</span>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="Label6" runat="server" Text="* In case of Invalid data, try reloading the page by clicking &quot;Back To Search&quot; Button"></asp:Label>
        <!-- Table (TABLE) -->
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Height="50px" OnClick="Button2_Click" Text="Print" OnClientClick="return PrintPanel('Panel1');" Width="200px" />
    </div>
</asp:Content>

