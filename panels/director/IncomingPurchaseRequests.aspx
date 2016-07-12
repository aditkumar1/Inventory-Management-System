<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IncomingPurchaseRequests.aspx.cs" Inherits="Store_Hod_PendingIssueRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="box">
        <h1>Incoming New Purchase Requests</h1>
        <p>&nbsp;</p>
        <!-- Headings -->
        <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="Select a Purchase Request no and Click on View button"></asp:Label>
        <br />
        <br />
        <h2>
            <asp:GridView ID="GridView1" runat="server"
                HeaderStyle-BackColor="green"
                AutoGenerateColumns="false" Font-Names="Arial"
                Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" Width="100%"
                AllowPaging="true" OnPageIndexChanging="OnPaging" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton1" runat="server"
                                onclick="RadioCheck(this,'GridView1');" />
                            <asp:HiddenField ID="HiddenField1" runat="server"
                                Value='<%#Eval("Prno")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Purchase Request No">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Prno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Requester">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Requester") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Depname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="LabelRDate" runat="server" Text='<%# Bind("Gendate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expected Delivery Date">
                        <ItemTemplate>
                            <asp:Label ID="LabelEDate" runat="server" Text='<%# Bind("Expdate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </h2>
        <h2>&nbsp;<asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click1" Text="View" Width="200px" />
        </h2>
    </div>
</asp:Content>

