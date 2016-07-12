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
                    <td width="50%" style="height: 30px">
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
                            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" DataKeyNames="Itemid,Mrno"
                            OnRowDataBound="GridView1_RowDataBound" AllowPaging="false" Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowFooter="true" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="0%">
                                    <ItemStyle Width="0%" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenItemid" runat="server" Value='<%# Bind("Itemid") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="0%">
                                    <ItemStyle Width="0%" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenItemid2" runat="server" Value='<%# Bind("Mrno") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sr" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="ll" runat="server" Text='<%# Bind("Srno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="2000px">
                                    <ItemStyle Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="LabelItem" runat="server" Text='<%# Bind("Iname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Category" ItemStyle-Width="2000px">
                                    <ItemStyle Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="LabelCategory" runat="server" Text='<%# Bind("Pcname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QReceived" HeaderText="Quantity Received" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Unit" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="Labelu" runat="server" Text='<%# Bind("Uname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ItemTotalCost" HeaderText="Cost" ItemStyle-Width="10%">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Discount" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnet22" runat="server" Text='<%# Eval("Discount")%>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="80%">
                                            <asp:ListItem Value="1" Text="Rs" />
                                            <asp:ListItem Value="2" Text="%" />
                                        </asp:DropDownList>
                                        <br />
                                        <asp:TextBox ID="discount" runat="server" Text='<%# Eval("Discount")%>' Width="80%" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vat" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnet23" runat="server" Text='<%# Eval("Vat")%>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList6" runat="server" Width="80%">
                                            <asp:ListItem Value="1" Text="Rs" />
                                            <asp:ListItem Value="2" Text="%" />
                                        </asp:DropDownList>
                                        <br />
                                        <asp:TextBox ID="vat" runat="server" Text='<%# Eval("Vat")%>' Width="80%" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
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
                                <asp:CommandField ButtonType="Link" ShowEditButton="true"
                                    ItemStyle-Width="100" />
                            </Columns>
                            <FooterStyle BackColor="#6699ff" Font-Bold="True" ForeColor="Black" />
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="Blue" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>"
                            UpdateCommand="UPDATE dbo.[IssueRequisition] set QRequired=@QRequired where Itemid=@Itemid and Slipno=@Slipno">
                            <UpdateParameters>
                                <asp:Parameter Name="QRequired" Type="Int32" />
                                <asp:Parameter Name="Itemid" Type="String" />
                                <asp:Parameter Name="Slipno" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
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
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Height="50px" OnClick="Button3_Click" Text="Modify" Width="200px" />
    </div>
</asp:Content>



