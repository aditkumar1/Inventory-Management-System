<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IssueModify.aspx.cs" Inherits="ProductEntryModify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div id="content" class="box" align="center">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <h1>ISSUE REGISTER MODIFY  </h1>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Data Successfully Modified..." Visible="False"></asp:Label>
        </p>
        <p>
            SELECT AN ENTRY AND CLICK ON MODIFY
        </p>
        <asp:SqlDataSource ID="sqlDsSubCategories" runat="server"
            ConnectionString="<%$ ConnectionStrings:Sql %>"></asp:SqlDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView Width="100%" Height="1000%" AllowPaging="True" ID="gvSubCategories"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    PagerStyle-CssClass="pgr"
                    DataSourceID="sqlDsSubCategories"
                    CssClass="mGrid"
                    runat="server"
                    ShowHeader="True"
                    DataKeyNames="Isno,Depname,Sortdate"
                    OnRowCreated="gvSubCategories_RowCreated" PageSize="40">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Panel ID="pnlSubCategories" runat="server">
                                    <table align="center" style="width: 100%; border-style: solid; border-width: 1px">
                                        <tr>
                                            <td style="width: 8%">
                                                <asp:Image ID="imgCollapsible" Style="margin-right: 5px;" runat="server" src="close.gif" /></td>
                                            <td style="width: 23%"><span><%#Eval("Isno")%></span></td>
                                            <td style="width: 23%"><span><%#Eval("Isby")%></span></td>
                                            <td style="width: 23%"><span><%#Eval("Depname")%></span></td>
                                            <td><span><%#Eval("Date")%></span></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:SqlDataSource ID="sqlDsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>"
                                    SelectCommand="select Sno,Iname,Pcname,QRequired,Qissued,Uname from IssueDetails,ProductCategory,ItemDetails,UnitDetails,ItemBalance where IssueDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and Isno= @Isno and Depname=@Depname and IssueDetails.Date=@Sortdate">
                                    <SelectParameters>
                                        <asp:Parameter Name="Isno" Type="String" DefaultValue="" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:Parameter Name="Depname" Type="String" DefaultValue="" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:Parameter Name="Sortdate" Type="String" DefaultValue="" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:Panel ID="pnlProducts" runat="server"
                                    Width="75%" Height="100%"
                                    Style="margin-left: 20px; margin-right: 20px; height: 0px; overflow: hidden;">
                                    <asp:GridView AutoGenerateColumns="False"
                                        CssClass="mGrid" ID="gvProducts"
                                        DataSourceID="sqlDsProducts"
                                        runat="server" EnableViewState="False"
                                        GridLines="None"
                                        AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="RadioButton1" runat="server"
                                                          onclick="RadioCheck(this,'gvSubCategories');" />
                                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                                        Value='<%#Eval("Sno")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Iname" HeaderText="Item Name" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Pcname" HeaderText="Item Category" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QRequired" HeaderText="Quantity Required" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Qissued" HeaderText="Quantity Issued" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:CollapsiblePanelExtender
                                    ID="ctlCollapsiblePanel"
                                    runat="Server"
                                    TargetControlID="pnlProducts"
                                    CollapsedSize="0" Collapsed="True"
                                    ExpandControlID="pnlSubCategories"
                                    CollapseControlID="pnlSubCategories"
                                    AutoCollapse="False" AutoExpand="False"
                                    ScrollContents="false"
                                    ImageControlID="imgCollapsible"
                                    ExpandedImage="close.gif"
                                    CollapsedImage="expand.gif"
                                    ExpandDirection="Vertical" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings PageButtonCount="40" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Modify" OnClick="Button1_Click1" Height="70px" Style="text-align: center" Width="250px" />
    </div>
</asp:Content>


