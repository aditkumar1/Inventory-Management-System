<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IssueRequestSlip.aspx.cs" Inherits="Store_ProductEntrySearchSlip" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        
    </script>
    <div id="content" class="box">
        <h1>ISSUE REQUEST DETAILS</h1>
        <p>
            <asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click" Text="Back To Search" Width="200px" />
        </p>
        <!-- Headings -->
        <!-- Table -->
        <asp:Panel ID="Panel1" runat="server">
            <table width="100%" height="100%" border="1px">
                <tr>
                    <td colspan="4" align="center" style="height: 50px"><%= System.Web.Configuration.WebConfigurationManager.AppSettings["Institute"] %>
                <br />
                        <%= System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteAddress"] %></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 30px">Issue Request Slip
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 50px">Department:&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                        <br />
                        Gen. Date:&nbsp;&nbsp;
                 <asp:Label ID="Label8" runat="server" ForeColor="#0000CC" Text="*"></asp:Label>
                        <br />
                        Print Date:&nbsp;&nbsp;
                 <asp:Label ID="Label2" runat="server" Text="*" ForeColor="#0000CC"></asp:Label>
                    </td>
                    <td width="50%">
                        <b>Status:&nbsp; </b>
                        <asp:Label ID="Label5" runat="server" Text="*" Font-Bold="True"></asp:Label>
                        <br />
                        Approved By:&nbsp;&nbsp;
                 <asp:Label ID="Label7" runat="server" ForeColor="#0000CC"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="50%" style="height: 30px">
                        <b>IS No:&nbsp; </b>
                        <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                    </td>
                    <td width="50%" style="height: 30px">Requester<b>:&nbsp; </b>
                        <asp:Label ID="Label4" runat="server" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="TOP" height="100%">
                        <br />
                        <asp:GridView ID="GridView1" runat="server"
                            HeaderStyle-BackColor="blue"
                            AutoGenerateColumns="false" Font-Names="Arial"
                            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                            AllowPaging="false" Width="100%">
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <Columns>
                                <asp:BoundField DataField="Srno" HeaderText="Sr" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Iname" HeaderText="Item Name" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pcname" HeaderText="Product Category" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QRequired" HeaderText="Quantity Required" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="Blue" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 30px" onstalled="text-align:right;">
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
    </div>
</asp:Content>



