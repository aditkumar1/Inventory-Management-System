using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ProductEntryModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Modified"]!=null&&Session["Modified"].ToString().Equals("yes"))
        {
            Label1.Visible = true;
            Session.Clear();
        }
       /*
        if (RadioButton2.Checked)
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox2.Text = "";
            TextBox3.Text ="";
            TextBox4.Text = "";
            sqlDsSubCategories.SelectCommand = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails  where Isno=" + TextBox1.Text + " Order By Sortdate";
        }
        if (RadioButton3.Checked)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = true;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            sqlDsSubCategories.SelectCommand = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails where Depname Like '%" + TextBox2.Text + "%' Order By Sortdate";
        }
        if (RadioButton4.Checked)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
            sqlDsSubCategories.SelectCommand = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails where Date BETWEEN '" + TextBox3.Text + "' AND  '" + TextBox4.Text + "' Order By Sortdate";
        }
        * <div align="left">
        <h2>Input The Field To Search And Press Enter</h2>
        <h2>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SearchSelect" Text="Issue Slip No" AutoPostBack="True" Checked="True" />
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
        </h2>
        <h2>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SearchSelect" Text="Department" AutoPostBack="True" />
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
            </div>
        if (TextBox1.Text.Equals("") && TextBox2.Text.Equals("") && TextBox3.Text.Equals("") && TextBox4.Text.Equals(""))
        {*/
            sqlDsSubCategories.SelectCommand = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails Order By Sortdate DESC";
        GetSelectedRecord();
        gvSubCategories.DataBind();
    }
   private void GetSelectedRecord()
    {
        for (int j = 0; j < gvSubCategories.Rows.Count; j++)
        {
            Panel Panel1 = (Panel)gvSubCategories.Rows[j].FindControl("pnlProducts");
            GridView GridView1 = (GridView)Panel1.FindControl("gvProducts");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)GridView1.Rows[i] .Cells[0].FindControl("RadioButton1");
                if (rb != null)
                {
                    if (rb.Checked)
                    {
                            HiddenField Sno = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("HiddenField1");
                        if (Sno!=null)
                        {
                            ViewState["SelectedSno"] = Sno.Value;
                            Session["SelectedSno"] = Sno.Value;
                        }
                        break;
                    }
                }
            }
        }  
    }
    protected void gvSubCategories_RowCreated(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "<table align=\"center\" style=\"width: 100%; border-style: solid; border-width: 1px\"><tr><td style=\"width: 8%\"><img alt=\"\" src=\"../images/close.gif\" style=\"width: 16px; height: 16px\" /></td><td style=\"width: 23%\"><font color=\"white\">IS No</font></td><td style=\"width: 23%\"><font color=\"white\">Issued By</font></td><td style=\"width: 23%\"><font color=\"white\">Department</font></td><td><font color=\"white\">Date</font></td> </tr></table>";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlDataSource ctrl = e.Row.FindControl("sqlDsProducts")  as SqlDataSource;
            if (ctrl != null && e.Row.DataItem != null)
            {
                ctrl.SelectParameters["Isno"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[0].ToString();
                ctrl.SelectParameters["Depname"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[1].ToString();
                ctrl.SelectParameters["Sortdate"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[2].ToString();
            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        GetSelectedRecord();
        if(Session["SelectedSno"]!=null)
        {
            Response.Redirect("IssueModifyForm.aspx");
        }
    }
}