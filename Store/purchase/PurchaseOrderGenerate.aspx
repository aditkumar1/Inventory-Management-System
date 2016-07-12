<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseOrderGenerate.aspx.cs" Inherits="Store_Hod_NewIssueRequest" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box" align="center">
        <h1>Generate Purchase Order</h1>
        <br />
        <asp:Label ID="Label_Result" runat="server" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <table class="auto-style3" width="100%">
            <tr>
                <td style="height: 40px; width: 50%">
                    <asp:Label ID="Label1" runat="server" Text="Purchase Order No:"></asp:Label>
                </td>
                <td style="height: 40px; width: 50%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="90%" ReadOnly="True"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 40px" class="auto-style3">Vendor Name <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="90%" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Vendor Address:</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Height="90%" TextMode="MultiLine" Width="50%" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div>
                        <asp:GridView ID="gvEG" runat="server" AutoGenerateColumns="False" CssClass="grid"
                            AlternatingRowStyle-CssClass="gridAltRow" RowStyle-CssClass="gridRow" ShowFooter="True"
                            EditRowStyle-CssClass="gridEditRow" FooterStyle-CssClass="gridFooterRow"
                            OnRowDeleting="gvEG_RowDeleting" DataKeyNames="Sno,Itemid,Unitid" OnSelectedIndexChanged="gvEG_SelectedIndexChanged" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("Iname")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("Uname")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                            Width="90px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Description") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("QRequired") %>'
                                            Width="90px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="r3" ValidationGroup="Update" runat="server"
                                            ControlToValidate="txtQuantity" ErrorMessage="Please Enter Quantity" ToolTip="Please Enter Quantity"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("QRequired") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate(in Rs)" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRate" runat="server" Text='<%# Bind("Rate") %>'
                                            Width="90px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="r4" ValidationGroup="Update" runat="server"
                                            ControlToValidate="txtRate" ErrorMessage="Please Enter Rate" ToolTip="Please Enter Rate"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Rate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount(in %)" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDiscount" runat="server" Text='<%# Bind("Discount") %>'
                                            Width="90px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="r5" ValidationGroup="Update" runat="server"
                                            ControlToValidate="txtDiscount" ErrorMessage="Please Enter Discount" ToolTip="Please Enter Discount"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Discount") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                        <table class="grid" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
                            <tr class="gridFooterRow">
                                <td>Product Category:<br />
                                    <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Iname" DataValueField="Itemid" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>Product Name:<br />
                                    <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="Iname" DataValueField="Itemid" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="r1" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="DropDownList4" ErrorMessage="Item name Required" ToolTip="Please Select Item"
                                        SetFocusOnError="true" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="Label2" runat="server" ForeColor="#0000CC"></asp:Label>
                                </td>
                                <td>Unit:<br />
                                    <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="Uname" DataValueField="Unitid" Width="80%">
                                    </asp:DropDownList>
                                </td>
                                <td>Description:<br />
                                    <asp:TextBox ID="Description" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>Quantity Required:<br />
                                    <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="r3" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="Quantity" ErrorMessage="Please Enter Quantity" ToolTip="Please Enter Quantity"
                                        SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>Rate:<br />
                                    <asp:TextBox ID="Rate" runat="server"></asp:TextBox>
                                </td>
                                <td>Discount:<br />
                                    <asp:TextBox ID="Discount" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2" align="justify" valign="middle">
                                    <asp:Button ID="B1" runat="server" CausesValidation="True" Text="Add" OnClick="B1_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px" colspan="2">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Default Terms & Condition" AutoPostBack="true" Checked="true" /></td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Taxes,Levis,Octroi etc( in Rs): :</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Delivery Period: :</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Delivery Place: :</td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" Width="50%" Height="90%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Freight: :</td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Mode Of Payment: :</td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Guarantee/Warranty, if any: :</td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="Button_Submit" runat="server" Style="height: 50px; width: 200px; border-radius: 6px;" Text="Generate" BackColor="#66FF99" OnClick="Button_Submit_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="*Mandatory Field" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </div>
        <!-- Headings -->
    </div>
    <br />
</asp:Content>



