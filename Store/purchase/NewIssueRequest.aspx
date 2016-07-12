<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="NewIssueRequest.aspx.cs" Inherits="Store_Hod_NewIssueRequest" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box" align="center">
        <h1>New Issue Request</h1>
        <br />
        <asp:Label ID="Label_Result" runat="server" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <table class="auto-style1" width="100%">
            <tr>
                <td style="height: 40px">
                    <asp:Label ID="Label1" runat="server" Text="Issue Request No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="50%" Height="90%" ReadOnly="True"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 40px" class="auto-style3">Product Category <span style="color: #CC3300">*</span> :</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="90%" Width="50%" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Product Name <span style="color: #CC3300">*</span> :</td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server" Style="margin-left: 0px" Height="90%" Width="50%" OnSelectedIndexChanged="DropDownListt4_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList4" ErrorMessage="*" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px"></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
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
                <td class="auto-style3" style="height: 40px">Quantity Required <span style="color: #CC3300">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBoxQuantity" runat="server" Height="90%" Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxQuantity" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Forward to :</td>
                <td>
                    <asp:DropDownList ID="DropDownListForward" runat="server" Style="margin-left: 0px" Height="90%" Width="50%">
                        <asp:ListItem>Manager Admin</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 40px">Date <span style="color: #CC3300">*</span>:</td>
                <td>
                    <asp:TextBox ID="TextBoxDate" runat="server" Width="50%"></asp:TextBox>
                    <asp:CalendarExtender ID="TextBoxDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBoxDate" Format="yyyy-MM-dd" CssClass="cal_Theme1"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Remarks :</td>
                <td>
                    <asp:TextBox ID="TextBoxRemarks" runat="server" Height="100px" Width="50%"></asp:TextBox>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="Button_AddMore" runat="server" Style="height: 50px; width: 200px; border-radius: 6px;" BackColor="#66FF99" OnClick="Button_AddMore_Click" Text="Add More Items" />
            <asp:Button ID="Button_Submit" runat="server" Style="height: 50px; width: 200px; border-radius: 6px;" Text="Submit Request" BackColor="#66FF99" OnClick="Button_Submit_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="*Mandatory Field" ForeColor="Red"></asp:Label>
            <br />
        </div>
        <!-- Headings -->
    </div>
    <br />
</asp:Content>



