<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReceiptGenerate .aspx.cs" Inherits="Store_Hod_NewIssueRequest" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box" align="center">
        <h1>Generate Material Receipt</h1>
        <br />
        <asp:Label ID="Label_Result" runat="server" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <table class="auto-style1" width="100%">
            <tr>
                <td style="height: 40px; width: 50%">
                    <asp:Label ID="Label1" runat="server" Text="Material Receipt No:"></asp:Label>
                </td>
                <td style="height: 40px; width: 50%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="90%" ReadOnly="True"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 40px; width: 50%">
                    <asp:Label ID="Label2" runat="server" Text="Bill No:"></asp:Label>
                </td>
                <td style="height: 40px; width: 50%">
                    <asp:TextBox ID="TextBox12" runat="server" Width="50%" Height="90%"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 40px; width: 50%">
                    <asp:Label ID="Label4" runat="server" Text="Challan No:"></asp:Label>
                </td>
                <td style="height: 40px; width: 50%">
                    <asp:TextBox ID="TextBox13" runat="server" Width="50%" Height="90%"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 40px; width: 50%">
                    <asp:Label ID="Label5" runat="server" Text="PO No:"></asp:Label>
                </td>
                <td style="height: 40px; width: 50%">
                    <asp:TextBox ID="TextBox14" runat="server" Width="50%" Height="90%"></asp:TextBox>
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
                <td style="height: 40px" class="auto-style3">Product Category <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="90%" Width="50%" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Product Name <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server" Style="margin-left: 0px" Height="90%" Width="50%" OnSelectedIndexChanged="DropDownListt4_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList4" ErrorMessage="*" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Unit :</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" Style="margin-left: 0px" Height="90%" Width="50%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Description :</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Height="90%" TextMode="MultiLine" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Quantity(Bill/Challan) <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBoxQuantity" runat="server" Height="90%" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxQuantity" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Quantity(Actual) <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Height="90%" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox15" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Quantity Rejected <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Height="90%" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox16" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Rate( in Rs) <span style="color: #FF0000">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="90%" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>
                            <asp:CheckBox ID="RadioTax" runat="server" Text="Extra Cost On Item(in Rs)" AutoPostBack="True" /></legend>
                        <table class="nostyle" width="100%">
                            <tr>
                                <td style="height: 50px; width: 10%;">Discount(in %)</td>
                                <td class="auto-style3" style="height: 50px; width: 10%;">
                                    <asp:TextBox ID="EC0" runat="server" Width="70%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="EC0" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style3" style="height: 50px; width: 10%;">VAT(in %)</td>
                                <td style="height: 50px; width: 10%;">
                                    <asp:TextBox ID="EC1" runat="server" Width="70%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="EC1" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style3" style="height: 50px; width: 10%;">S.Tax(in %)</td>
                                <td style="height: 50px; width: 10%;">
                                    <asp:TextBox ID="EC2" runat="server" Width="70%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="EC2" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style3" style="height: 50px; width: 10%;">Miscellaneous(in Rs)</td>
                                <td style="height: 50px; width: 10%;">
                                    <asp:TextBox ID="EC3" runat="server" Width="70%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="EC3" ErrorMessage="*" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px" colspan="2">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Other Whole Receipt Related Details" AutoPostBack="true" /></td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Excise Duty( in Rs): :</td>
                <td>
                    <asp:TextBox ID="VC0" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Packing Charge( in Rs): :</td>
                <td>
                    <asp:TextBox ID="VC1" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Freight Charge( in Rs): :</td>
                <td>
                    <asp:TextBox ID="VC2" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Other Charge( in Rs): :</td>
                <td>
                    <asp:TextBox ID="VC3" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Adjustment( in Rs): :</td>
                <td>
                    <asp:TextBox ID="VC4" runat="server" Width="50%" Height="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Remarks: :</td>
                <td>
                    <asp:TextBox ID="VC5" runat="server" Width="50%" Height="90%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="Button_AddMore" runat="server" Style="height: 50px; width: 200px; border-radius: 6px;" BackColor="#66FF99" OnClick="Button_AddMore_Click" Text="Add More Items" />
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
