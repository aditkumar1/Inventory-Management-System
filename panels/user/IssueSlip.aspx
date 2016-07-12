<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" CodeFile="IssueSlip.aspx.cs" Inherits="ProductEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script>
        function hideEditModalPopup(popupid, val1, val2, val3, val4, val5) {
            $('#ContentPlaceHolder1_HiddenField1').val(val1);
            $('#ContentPlaceHolder1_TextBox3').val(val2);
            $('#ContentPlaceHolder1_TextBox4').val(val3);
            $('#ContentPlaceHolder1_Label2').html("Product Balance Is " + val4);
            $('#ContentPlaceHolder1_Label3').html(val5);
            $('#ContentPlaceHolder1_Label4').html(val5);
            $find(popupid).hide();
            return false;
        }
    </script>
    <script>
        function alertError(val) {
            alert(val);
            return false;
        }
    </script>
    <div id="content" class="box">
        <h1>Issue Register Entry<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        </h1>
        <!-- Headings -->
        <!-- Table -->
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000099" Text="Items Successfull Saved. Input Other Items..." Visible="False"></asp:Label>
        <br />
        <br />
        <table class="nostyle" width="100%">
            <tr>
                <td style="height: 50px; width: 200px;">Issue Slip No<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px" Style="height: 20px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Issued By</td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Product Category<span style="color: #990000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:DropDownList ID="DropDownList2" Width="200px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="#CC0000" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Product Name<span style="color: #990000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:DropDownList ID="DropDownList4" Width="200px" runat="server" Style="margin-left: 0px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList4" ErrorMessage="*" ForeColor="#CC0000" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;"><span style="color: #0000CC">Quantity Required</span><span style="color: #990000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator runat="server" ID="wspXformat" ControlToValidate="TextBox5" MinimumValue="0" Type="Double" Text="(+ve)" ForeColor="Red" />
                    &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="#0000CC">Unit</asp:Label>
                    &nbsp;
                &nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownList3" ErrorMessage="*" ForeColor="#CC0000" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Quantity Issued<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="TextBox6" MinimumValue="0" Type="Double" Text="(+ve)" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Department Name<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#CC3300" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Received By<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Remarks</td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox8" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 200px;">Date (yyyy-mm-dd)<span style="color: #CC0000">*</span></td>
                <td style="height: 50px; width: 453px;">
                    <asp:TextBox ID="TextBox9" runat="server" Width="200px"></asp:TextBox>
                    <asp:CalendarExtender ID="TextBox9_CalendarExtender" Format="yyyy-MM-dd" runat="server" Enabled="True" TargetControlID="TextBox9" CssClass="cal_Theme2">
                    </asp:CalendarExtender>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox9" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <span style="color: #CC0000">* Mandatory Fields<br />
            <br />
        </span>
        <br />
        <asp:Button ID="Button5" runat="server" Text="Submit" Width="200px" OnClick="Button5_Click" Height="40px" />
        <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe style="width: 550px; height: 400px;" id="irm1" src="ProductCategorySearch.aspx" runat="server"></iframe>
            <br />
            <hr />
            <asp:Button ID="Button3" runat="server" Text="Close" />
        </asp:Panel>
        <!-- Table (TABLE) -->
        <!-- Form -->
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button7" runat="server" Text="Issue More Product" Width="200px" OnClick="Button7_Click" Height="40px" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Text="Reset" Width="201px" OnClick="Button6_Click" Height="40px" Style="margin-left: 0px" CausesValidation="false" />
    </div>
</asp:Content>


