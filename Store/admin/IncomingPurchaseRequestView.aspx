<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IncomingPurchaseRequestView.aspx.cs" Inherits="Store_admin_IncomingIssueRequestView" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Incoming Purchase Request View</h1>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <div id="Grid">
                <asp:GridView ID="GridView1" Width="100%" runat="server" Style="text-align: center;" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                    DataKeyNames="Iname" EmptyDataText="No records has been added.">
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
                                <asp:HiddenField ID="HiddenPrno" runat="server" Value='<%# Bind("Prno") %>'></asp:HiddenField>
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
                        <asp:BoundField DataField="QRequired" HeaderText="Quantity Required" ItemStyle-Width="10%">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Store Balance">
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="LabelBalance" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit" ItemStyle-Width="2000px">
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="Labeldep" runat="server" Text='<%# Bind("Uname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apprxcost" ItemStyle-Width="2000px">
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="Labeldep2" runat="server" Text='<%# Bind("Apprxcost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requester Remarks" ItemStyle-Width="2000px">
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="Labelremark" runat="server" Text='<%# Bind("Reqremarks") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="2000px">
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Label ID="Labeldep24" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true"
                            ItemStyle-Width="100" />
                    </Columns>
                    <HeaderStyle BackColor="Blue" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>"
                    UpdateCommand="UPDATE dbo.[PurchaseRequisition] set QRequired=@QRequired where Itemid=@Itemid and Prno=@Prno">
                    <UpdateParameters>
                        <asp:Parameter Name="QRequired" Type="Int32" />
                        <asp:Parameter Name="Itemid" Type="String" />
                        <asp:Parameter Name="Prno" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="Prno" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </asp:Panel>
        <br />
        <br />
        <div width="100%">
            <table width="100%">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label3" runat="server" Text="Director Remarks (if forwarded from Director)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="50%" Height="100px" BackColor="Silver" ReadOnly="true"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label2" runat="server" Text="Remarks"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="Remark2" runat="server" TextMode="MultiLine" Width="50%" Height="100px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="ButtonApprove" runat="server" OnClick="ButtonApprove_Click" Width="30%" Height="35px" Text="Approve" />
                    </td>
                    <td align="left">
                        <asp:Button ID="ButtonDA" runat="server" OnClick="ButtonDA_Click" Width="30%" Height="35px" Text="Decline" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- Headings -->
    </div>
</asp:Content>



