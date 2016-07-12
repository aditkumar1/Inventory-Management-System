<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" CodeFile="ProductEntry.aspx.cs" Inherits="ProductEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <!--
        <script>
            function hideEditModalPopup(popupid, val1, val2, val3, val4,val5)
            {
                $('#ContentPlaceHolder1_HiddenField2').val(val1);
                $('#ContentPlaceHolder1_TextBox5').val(val2);
                $('#ContentPlaceHolder1_TextBox10').val(val3);
                $('#ContentPlaceHolder1_Label2').html("Product Balance Is " + val4);
                $('#ContentPlaceHolder1_Label3').html(val5);
                $find(popupid).hide();
                return false;
            }
       </script>
    <script>
            function hideEditModalPopup2(popupid, val1, val2, val3)
            {
                $('#ContentPlaceHolder1_HiddenField1').val(val1);
                $('#ContentPlaceHolder1_TextBox3').val(val2);
                $('#ContentPlaceHolder1_TextBox4').val(val3);
                $find(popupid).hide();
                return false;
            }
        </script>
   -->
    <div id="content" class="box">
        <h1>Inward Register Entry</h1>
        <!-- Headings -->
        <!-- Table -->
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="Items Successfull Saved. Input Other Items For Same GE NO..." Visible="False"></asp:Label>
        <br />
        <br />
        <table width="100%" border="0">
            <tr>
                <td style="height: 50px; width: 200px;">Gate Entry No
                    (GE NO)<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px" Style="height: 20px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 50px; width: 200px;">Invoice/Challan No<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Vendor Name</td>
                <td style="height: 50px; width: 453px;">
                    <asp:DropDownList ID="DropDownList1" Width="200px" runat="server" Style="margin-left: 0px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#CC0000" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox4" runat="server" Width="200px" TextMode="MultiLine" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 50px; width: 200px;" colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td style="height: 50px; width: 200px;">Date (yyyy-mm-dd)<span style="color: #CC0000">*</span></td>
                            <td style="height: 50px; width: 453px;">
                                <asp:TextBox runat="server" ID="TextBox9" Width="200px" ClientIDMode="Static" />
                                <asp:CalendarExtender ID="TextBox9_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox9" Format="yyyy-MM-dd">
                                </asp:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox9" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 50px; width: 200px;">Mode Of Payment (MOP)</td>
                            <td style="height: 50px; width: 453px;">
                                <asp:TextBox ID="TextBox8" runat="server" Width="200px"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox8" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <fieldset>
                        <legend>Items</legend>
                        <div>
                            <asp:GridView ID="gvEG" runat="server" AutoGenerateColumns="False"
                                AlternatingRowStyle-CssClass="gridAltRow" RowStyle-CssClass="gridRow"
                                EditRowStyle-CssClass="gridEditRow" FooterStyle-CssClass="gridFooterRow" CssClass="grid" ShowFooter="True" Width="100%"
                                OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="gvEG_RowDeleting" DataKeyNames="Sno,Itemid,Unitid" OnSelectedIndexChanged="gvEG_SelectedIndexChanged" showgrid="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr" ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsr" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Category" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Pcname") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("Iname") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Uname") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Description") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrequired" runat="server" Text='<%# Eval("QRequired") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost(Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcost" runat="server" Text='<%# Eval("ItemTotalCost") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount(Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Discount") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VAT(Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvat" runat="server" Text='<%# Eval("Vat") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax(Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltax" runat="server" Text='<%# Eval("Tax") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc(Rs)" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMisc" runat="server" Text='<%# Eval("Misc") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Net" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnet" runat="server" Text='<%# Eval("Net")%>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="nettotal" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <table class="grid" cellpadding="0" cellspacing="0" border="1" rules="all" style="border-collapse: collapse; color: blue; width: 100%">
                                <tr class="gridFooterRow">
                                    <td style="width: 15%;">Product Category:<br />
                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="DropDownList2" ErrorMessage="Item name Required" ToolTip="Please Select Item"
                                            SetFocusOnError="true" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 25%;">Product Name:<br />
                                        <asp:DropDownList ID="DropDownList4" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="r1" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="DropDownList4" ErrorMessage="Item name Required" ToolTip="Please Select Item"
                                            SetFocusOnError="true" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" ForeColor="#0000CC"></asp:Label>
                                    </td>
                                    <td style="width: 5%;">Unit:<br />
                                        <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="Uname" DataValueField="Unitid" Width="80%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 10%;">Description:<br />
                                        <asp:TextBox ID="Description" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td style="width: 7%;">Quantity Received:<br />
                                        <asp:TextBox ID="Quantity" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="r11" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Quantity" ToolTip="Please Enter Quantity"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 7%;">Net Cost<br />
                                        (in Rs):<br />
                                        <asp:TextBox ID="Cost" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Cost" ToolTip="Please Enter Cost"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 7%;">Discount<br />
                                        (in
                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="60%">
                                            <asp:ListItem Value="1" Text="%" />
                                            <asp:ListItem Value="2" Text="Rs" />
                                        </asp:DropDownList>)
                            :<br />
                                        <asp:TextBox ID="Discount" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Discount" ToolTip="Please Enter Discount"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 7%;">VAT<br />
                                        (in %):<br />
                                        <asp:TextBox ID="Vat" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Vat" ToolTip="Please Enter Vat"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 7%;">S.Tax<br />
                                        (in Rs):<br />
                                        <asp:TextBox ID="Tax" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Tax" ToolTip="Please Enter Tax"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 7%;">Misc<br />
                                        (in Rs):<br />
                                        <asp:TextBox ID="Misc" runat="server" Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="Misc" ToolTip="Please Enter Discount"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="justify" valign="middle" style="width: 7%;">
                                        <asp:Button ID="B1" runat="server" CausesValidation="true" ValidationGroup="Insert" Text="Add" OnClick="B1_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
        <br />
        <span style="color: #CC0000">* Mandatory Fields<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
            <br />
            <br />
        </span>
        <br />
        <div>
            <asp:Button ID="Button5" runat="server" Text="Submit" Width="200px" OnClick="Button5_Click" Height="40px" align="left" />
            <!-- Table (TABLE) -->
            <!-- Form -->
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Text="Reset" Width="201px" OnClick="Button6_Click" Height="40px" Style="margin-left: 0px" CausesValidation="false" align="right" />
        </div>
    </div>
</asp:Content>


