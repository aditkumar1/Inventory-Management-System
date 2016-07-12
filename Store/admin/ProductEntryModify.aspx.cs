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
        if (RadioButton2.Checked)
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox2.Text= "";
            TextBox3.Text = "";
            TextBox4.Text ="";
            sqlDsSubCategories.SelectCommand = "select DISTINCT(GEno),EntryDetails.Vendorid,Vfirm as Vfirm,EntryDetails.Invoiceno,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,Status,EntryDetails.Date as Sortdate from EntryDetails,InvoiceDetails,VendorDetails where EntryDetails.Mrno=InvoiceDetails.Mrno and EntryDetails.Vendorid=VendorDetails.Vendorid  and GEno=" + TextBox1.Text + " order by Sortdate";
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
            sqlDsSubCategories.SelectCommand = "select DISTINCT(GEno),EntryDetails.Vendorid,Vfirm as Vfirm,EntryDetails.Invoiceno,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,Status,EntryDetails.Date as Sortdate from EntryDetails,InvoiceDetails,VendorDetails where EntryDetails.Mrno=InvoiceDetails.Mrno and EntryDetails.Vendorid=VendorDetails.Vendorid and EntryDetails.Invoiceno =" + TextBox2.Text + " order by Sortdate";
        }
        if (RadioButton4.Checked)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
            sqlDsSubCategories.SelectCommand = "select DISTINCT(GEno),EntryDetails.Vendorid,Vfirm as Vfirm,EntryDetails.Invoiceno,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,Status,EntryDetails.Date as Sortdate from EntryDetails,InvoiceDetails,VendorDetails where EntryDetails.Mrno=InvoiceDetails.Mrno and EntryDetails.Vendorid=VendorDetails.Vendorid and Date BETWEEN '" + TextBox3.Text + "' AND  '" + TextBox4.Text + "' order by Sortdate";
        }
        if(TextBox1.Text.Equals("") && TextBox2.Text.Equals("") && TextBox3.Text.Equals("") && TextBox4.Text.Equals(""))
        {
            sqlDsSubCategories.SelectCommand = "select DISTINCT(GEno),EntryDetails.Vendorid,Vfirm as Vfirm,EntryDetails.Invoiceno,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,Status,EntryDetails.Date as Sortdate from EntryDetails,InvoiceDetails,VendorDetails where EntryDetails.Mrno=InvoiceDetails.Mrno and EntryDetails.Vendorid=VendorDetails.Vendorid  order by Sortdate DESC";
        }
        gvSubCategories.DataBind();
    }
   protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
   {
       if (e.CommandName == "More")
       {
           int index = Convert.ToInt32(e.CommandArgument.ToString());
           Session["SelectedGEno"] = gvSubCategories.DataKeys[index].Values[0].ToString();
           Session["SelectedInvoiceno"] = gvSubCategories.DataKeys[index].Values[1].ToString();
           Session["Date"] = gvSubCategories.DataKeys[index].Values[2].ToString();
           if(Session["SelectedGEno"]!=null&&Session["Date"]!=null)
           {
               Response.Redirect("ProductEntryModifyFormNew.aspx");
           }
       }
   }  
    protected void gvSubCategories_RowCreated(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "<table align=\"center\" style=\"width: 100%; border-style: solid; border-width: 1px\"><tr><td style=\"width: 10%\"><img alt=\"\" src=\"../images/expand.gif\" style=\"width: 16px; height: 16px\" /></td><td style=\"width: 18%\"><font color=\"white\">GE No</font></td><td style=\"width: 18%\"><font color=\"white\">Vendor Name</font></td><td style=\"width: 18%\"><font color=\"white\">Invoice No</font></td><td><font color=\"white\">Date</font></td><td style=\"width: 18%\"><font color=\"white\">Status</font></td> </tr></table>";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlDataSource ctrl = e.Row.FindControl("sqlDsProducts")  as SqlDataSource;
            if (ctrl != null && e.Row.DataItem != null)
            {
                ctrl.SelectParameters["GEno"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //ctrl.SelectParameters["Vendorid"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[1].ToString();
                ctrl.SelectParameters["Invoiceno"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[1].ToString();
                ctrl.SelectParameters["Sortdate"].DefaultValue = gvSubCategories.DataKeys[e.Row.RowIndex].Values[2].ToString();
            }
            Panel Panel1 = (Panel)e.Row.FindControl("pnlSubCategories");
            LinkButton lb = (LinkButton)Panel1.FindControl("b1");
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);
        }
    }
}