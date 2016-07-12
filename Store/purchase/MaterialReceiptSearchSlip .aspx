<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReceiptSearchSlip .aspx.cs" Inherits="Store_ProductEntrySearchSlip" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <div id="content" class="box">
        <h1>Purchase Order </h1>
        <p>
            <asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click" Text="Back To Search" Width="200px" />
        </p>
      <!-- Headings -->
      <!-- Table -->
        <asp:Panel ID="Panel1" runat="server">
            <table class="nostyle" width="100%" border="2px" height="100%">
        <tr>
            <td colspan="4" align="center" style="height:50px">
                <%= System.Web.Configuration.WebConfigurationManager.AppSettings["Institute"] %>
                <br />
                <%= System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteAddress"] %><br /> <%= System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteContactNo"] %></td>
        </tr>
        <tr>
            <td colspan="4" align="center" style="height: 30px">
                Purchase Order</td>
        </tr>
                <tr>
            <td  align="left" style="height: 60px;width:50%;">
                 To,<br />
                 <br />
                 <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                 <br />
                 <asp:Label ID="Label7" runat="server" Text="*"></asp:Label>
                 <br />
                 <br />
            </td>
            <td  align="right" >
                Po<b> No:&nbsp; </b>
                <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                <br />
                Date:&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                <br />
                </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px" align="left">
                We are pleased to place an order for the following material/equipment on the terms and conditions mentioned here under.This is in reference to your quotation/personal enquiry regarding rates quoted by you.</td>
        </tr>
        <tr>
            <td colspan="4" valign="TOP">
            <br/>
                <asp:GridView ID="GridView1" runat="server"
            HeaderStyle-BackColor = "blue"
            AutoGenerateColumns = "false" Font-Names = "Arial" 
            Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"
           OnRowDataBound="GridView1_RowDataBound" AllowPaging = "false"  Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowFooter="True" FooterStyle-Font-Bold="true" >
                    <AlternatingRowStyle BackColor="#C2D69B" />
                    <Columns>
                        <asp:BoundField DataField="Srno" HeaderText="Sr" ItemStyle-Width="5%">
                        <ItemStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Iname" HeaderText="Item Name" ItemStyle-Width="2000px">
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="200px">
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QRequired" HeaderText="Quantity Required" ItemStyle-Width="10%">
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Uname" HeaderText="Unit" ItemStyle-Width="10%">
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Rate" HeaderText="Rate" ItemStyle-Width="10%">
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Cost(in Rs)" ItemStyle-Width="10%">
                                    <ItemTemplate >
                                        <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost")%>' />
                                    </ItemTemplate>
                                      <FooterTemplate>
                                        <asp:Label ID="costtotal" runat="server" />
                                    </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount(in Rs)" ItemStyle-Width="10%">
                                    <ItemTemplate >
                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount")%>' />
                                    </ItemTemplate>
                                      <FooterTemplate>
                                        <asp:Label ID="discounttotal" runat="server" />
                                    </FooterTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Amount(in Rs)" ItemStyle-Width="10%">
                                    <ItemTemplate >
                                        <asp:Label ID="lblNet" runat="server" Text='<%# Eval("Amount")%>' />
                                    </ItemTemplate>
                                      <FooterTemplate>
                                        <asp:Label ID="nettotal" runat="server" />
                                    </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <rowstyle backcolor="#EFF3FB" />
                                <editrowstyle backcolor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
                                 <footerstyle backcolor="#6699ff" font-bold="True" forecolor="Black" />
                                <alternatingrowstyle backcolor="White" />
                    <HeaderStyle BackColor="Blue" />
        </asp:GridView>
                <br/>
                </td>
         </tr>
        <tr>
            <td colspan="4" style="height: 30px">
                <div>
                     <p class="auto-style2"><strong>Terms and Conditions:</strong></p>
                         <ol>
                          <li style="text-align: left">All disputes are subject to Ghaziabad Jurisdiction</li>
                          <li class="auto-style2">Inspection shall be carried out at our premises and goods nots as per specification shall be rejected</li>
                          <li class="auto-style2">Rejected material shall be collected by vender within 5 days, falling which the same shall be despatched to you at your cost and risk.</li>
                           <li class="auto-style2">No responsibility shall be taken for the rejected material during storage at our end.</li>
                          <li class="auto-style2">All Materials shall accompany the proper test certificate/inspection report/calibration certificate/warranty card, whatever applicable.</li>
                            <li> 
                             <p class="auto-style2">Delievery Period:Taxes,Levis,Octroi etc:<b><asp:Label ID="lbl1" runat="server" Text=""></asp:Label></b></p>
                            <p class="auto-style2">Delievery Period: <b><asp:Label ID="lbl2" runat="server" Text=""></asp:Label></b></p>
                             <p class="auto-style2">Delievery Place: <b><asp:Label ID="lbl3" runat="server" Text=""></asp:Label></b></p>
                             <p class="auto-style2">Frieght: <b><asp:Label ID="lbl4" runat="server" Text=""></asp:Label></b></p>
                              <p class="auto-style2">Mode of Payment: <b><asp:Label ID="lbl5" runat="server" Text=""></asp:Label></b></p>
                              <p class="auto-style2">Gurantee/Warranty if any: <b><asp:Label ID="lbl6" runat="server" Text=""></asp:Label></b></p>
                             </li>
                            </ol>
                </div>
            </td>
        </tr>
         <tr>
            <td colspan="4">
                <table class="nostyle" width="100%" border="0"
                    <tr>
                        <td>
                            <br/><br/>
                            <asp:Label ID="Label4" runat="server" Text="Prepared By"></asp:Label>
                            </td>
                        <td>
                            <br/><br/>
                            <asp:Label ID="Label5" runat="server" Text="Checked By"></asp:Label>
                            </td>
                        <td>
                            <br/><br/>
                            <asp:Label ID="Label8" runat="server" Text="Manager Admin"></asp:Label>
                            </td>
                        <td>
                            <br/><br/>
                            <asp:Label ID="Label9" runat="server" Text="Authorized Signatory"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>   
          </tr>
    </table>
        </asp:Panel>
        <asp:Label ID="Label6" runat="server" Text="* In case of Invalid data, try reloading the page by clicking &quot;Back To Search&quot; Button"></asp:Label>
      <!-- Table (TABLE) -->
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Height="50px" OnClick="Button2_Click" Text="Print" OnClientClick = "return PrintPanel('Panel1');" Width="200px" />
      </div>
</asp:Content>
