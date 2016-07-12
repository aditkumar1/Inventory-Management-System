<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProductEntryModify.aspx.cs" Inherits="ProductEntryModify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="content" class="box" align="center">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <h1>INWARD REGISTER MODIFY  </h1>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Data Successfully Modified..." Visible="False"></asp:Label>
        </p>
        <br />
        <div align="left">
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
            </h2>
            <h2>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="SearchSelect" Text="Date" AutoPostBack="True" />
                &nbsp;<asp:Label ID="Label2" runat="server" Text="From"></asp:Label>
                &nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox3_CalendarExtender" Format="yyyy-MM-dd" runat="server" Enabled="True" TargetControlID="TextBox3" CssClass="cal_Theme1">
                </asp:CalendarExtender>
                <asp:Label ID="Label3" runat="server" Text="To"></asp:Label>
                &nbsp;<asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" Enabled="True" TargetControlID="TextBox4" CssClass="cal_Theme1">
                </asp:CalendarExtender>
            </h2>
        </div>
        <p>
            SELECT AN ENTRY AND CLICK ON MODIFY
        </p>
        <asp:SqlDataSource ID="sqlDsSubCategories" runat="server"
            ConnectionString="<%$ ConnectionStrings:Sql %>"></asp:SqlDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView Width="100%" Height="1000%" AllowPaging="True" ID="gvSubCategories"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    PagerStyle-CssClass="pgr"
                    DataSourceID="sqlDsSubCategories"
                    CssClass="mGrid"
                    runat="server"
                    ShowHeader="True"
                    DataKeyNames="GEno,Invoiceno,Sortdate"
                    OnRowCreated="gvSubCategories_RowCreated" OnRowCommand="gridMembersList_RowCommand" onRPageSize="40" PageSize="40">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="200px" />
                            <ItemTemplate>
                                <asp:Panel ID="pnlSubCategories" runat="server">
                                    <table align="center" style="width: 100%; border-style: solid; border-width: 1px">
                                        <tr>
                                            <td style="width: 3%">
                                                <asp:Image ID="imgCollapsible" Style="margin-right: 5px;" runat="server" src="close.gif" /></td>
                                            <td style="width: 7%">
                                                <asp:LinkButton ID="b1" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="More" runat="server" Text="Modify" /></td>
                                            <td style="width: 18%"><span><%#Eval("GEno")%></span></td>
                                            <td style="width: 18%"><span><%#Eval("Vfirm")%></span></td>
                                            <td style="width: 18%"><span><%#Eval("Invoiceno")%></span></td>
                                            <td><span><%#Eval("Date")%></span></td>
                                            <td style="width: 18%"><span><%#Eval("Status")%></span></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:SqlDataSource ID="sqlDsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>"
                                    SelectCommand="select Sno,EntryDetails.Mrno as Mrno,InvoiceDetails.Itemid,Iname,Pcname,QReceived,ItemTotalCost,Uname from EntryDetails,InvoiceDetails,ProductCategory,ItemDetails,UnitDetails,ItemBalance where EntryDetails.Mrno=InvoiceDetails.Mrno and InvoiceDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and GEno= @GEno and EntryDetails.Invoiceno=@Invoiceno and EntryDetails.Date=@Sortdate">
                                    <SelectParameters>
                                        <asp:Parameter Name="GEno" Type="String" DefaultValue="" />
                                        <asp:Parameter Name="Invoiceno" Type="String" DefaultValue="" />
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
                                            <asp:TemplateField ItemStyle-Width="0%">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField2" runat="server"
                                                        Value='<%#Eval("Sno")%>' />
                                                    <asp:HiddenField ID="HiddenField3" runat="server"
                                                        Value='<%#Eval("Mrno")%>' />
                                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                                        Value='<%#Eval("Itemid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Iname" HeaderText="Item Name" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Pcname" HeaderText="Item Category" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QReceived" HeaderText="Quantity Received" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="150px">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ItemTotalCost" HeaderText="Cost" ItemStyle-Width="150px">
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
    </div>
</asp:Content>

