using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Store_ProductEntrySearchSlip : System.Web.UI.Page
{
    decimal total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SelectedGEno"] != null && Session["SelectedInvoiceno"] != null && Session["Date"]!=null)
        {
            Label3.Text=Session["SelectedGEno"].ToString();
            Label4.Text = Session["SelectedInvoiceno"].ToString();
            BindField();
            BindGrid();
        }
    }
    private void BindField()
    {
        string strQuery = "select Vfirm,Vaddress,EntryDetails.Invoiceno,Convert(varchar(10),CONVERT(date,Date,106),103) as Date,Status from EntryDetails,InvoiceDetails,VendorDetails where EntryDetails.Mrno=InvoiceDetails.Mrno and EntryDetails.Vendorid=VendorDetails.Vendorid and GEno=" + Session["SelectedGEno"].ToString() + " and EntryDetails.Invoiceno=" + Session["SelectedInvoiceno"].ToString()+ " and EntryDetails.Date='"+Session["Date"].ToString()+"'";
       // string strQuery2 = "select Vat,Tax,Misc,NetItemCost as sum,Vat+Tax+Misc+NetItemCost as Net from InvoiceExtraCost where GEno=" + Session["SelectedGEno"].ToString() + " and Invoiceno=" + Session["SelectedInvoiceno"].ToString()+" and Date='"+Session["Date"].ToString()+"'";
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand(strQuery,con);
        //SqlCommand cmd2 = new SqlCommand(strQuery2, con);
        try
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = dr["Vfirm"].ToString();
                Label2.Text = dr["Date"].ToString();    
                Label7.Text = dr["Vaddress"].ToString();
                Label8.Text = dr["Status"].ToString();
            }
            dr.Close();
            /*SqlDataReader dr2 = cmd2.ExecuteReader();
            if(dr2.Read())
            {
                Label5.Text = dr2["sum"].ToString();
                EC1.Text = dr2["Vat"].ToString().Equals("") ? "0" : dr2["Vat"].ToString();
                EC2.Text = dr2["Tax"].ToString().Equals("") ? "0" : dr2["Tax"].ToString();
                EC3.Text = dr2["Misc"].ToString().Equals("") ? "0" : dr2["Misc"].ToString();
                EC4.Text = dr2["Net"].ToString();
            }*/
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
        finally
        {
            con.Close();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblrecv = (Label)e.Row.FindControl("lblnet");
            decimal qty = decimal.Parse(lblrecv.Text);
            //qty = Math.Round(qty,2);
            total = total + qty;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty1 = (Label)e.Row.FindControl("nettotal");
            total = Math.Round(total, 2);
            lblTotalqty1.Text = "Net\nAamount:" + total.ToString();
        }
    }
    private void BindGrid()
    {
        string strQuery = "select Pcname as Pcname,(Iname+CHAR(13)+IsNull(InvoiceDetails.Description,'')) as Iname,QReceived,ItemTotalCost,Uname,Discount,Vat,Tax,Misc,(Vat+Tax+Misc+ItemTotalCost-Discount) as Net,ROW_NUMBER() OVER (ORDER BY Iname) as Srno from EntryDetails,InvoiceDetails,ProductCategory,ItemDetails,UnitDetails,ItemBalance where EntryDetails.Mrno=InvoiceDetails.Mrno and InvoiceDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and GEno=" + Session["SelectedGEno"].ToString() + " and EntryDetails.Invoiceno=" + Session["SelectedInvoiceno"].ToString() + " and EntryDetails.Date='" + Session["Date"].ToString() + "'";
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            //throw ex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: " + ex.ToString() + "\" );", true);
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
 /*   private DataTable InsertRowAtEnd(DataTable dt)
    {
        for (int i =dt.Rows.Count+1; i <=25 ;i++)
        {
            DataRow dr =dt.NewRow();
            dt.Rows.Add(dr);
        }
        return dt;
    }
   */ 
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductEntrySearch.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int i = 0;
        string strQuery = "update EntryDetails set Status='Verified' where GEno=" + Session["SelectedGEno"].ToString() + " and EntryDetails.Invoiceno=" + Session["SelectedInvoiceno"].ToString() + " and EntryDetails.Date='" + Session["Date"].ToString() + "'";
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand(strQuery, con);
        try
        {
            i=cmd.ExecuteNonQuery();
            if(i>=0)
            {
                BindField();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Invoice has been successfully verified\" );", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: " + ex.ToString() + "\" );", true);
        }
        finally
        {
            con.Close();
        }
    }
}