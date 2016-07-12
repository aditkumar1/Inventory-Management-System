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
    decimal totalCost = 0, totalDiscount = 0,totalNet=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SelectedPono"] != null )
        {
            Label3.Text=Session["SelectedPono"].ToString();
            BindField();
            BindGrid();
        }
    }
    private void BindField()
    {
        string strQuery = "select Vfirm,Vaddress,PurchaseOrderTerms.* from Main.dbo.PurchaseOrder,Main.dbo.PurchaseOrderTerms,VendorDetails where PurchaseOrder.Vendorid=VendorDetails.Vendorid and PurchaseOrder.Pono=PurchaseOrderTerms.Pono and PurchaseOrder.Date=PurchaseOrderTerms.Date and PurchaseOrder.Pono=" + Session["SelectedPono"].ToString();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        DateTime dt = DateTime.Now;
        String format = "dd/MM/yyyy";
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand(strQuery,con);
        try
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = dr["Vfirm"].ToString();
                Label7.Text = dr["Vaddress"].ToString();
                lbl1.Text = dr["Tax"].ToString();
                lbl2.Text = dr["Delperiod"].ToString();
                lbl3.Text = dr["Delplace"].ToString();
                lbl4.Text = dr["Freight"].ToString();
                lbl5.Text = dr["MOP"].ToString();
                lbl6.Text = dr["Warranty"].ToString();
            }
            Label2.Text = dt.ToString(format);
            dr.Close();
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
    private void BindGrid()
    {
        string strQuery = "select Iname,Pcname,PurchaseOrder.Description,QRequired,Rate,Cost,Discount,(Cost-Discount) as Amount,Uname,ROW_NUMBER() OVER (ORDER BY Iname) as Srno from Main.dbo.PurchaseOrder,ProductCategory,ItemDetails,UnitDetails,ItemBalance where PurchaseOrder.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and Pono=" + Session["SelectedPono"].ToString() ;
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
            GridView1.DataSource = dt ;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCost = (Label)e.Row.FindControl("lblCost");
            decimal qty = decimal.Parse(lblCost.Text);
            totalCost = totalCost + qty;
            Label lblDiscount = (Label)e.Row.FindControl("lblDiscount");
            decimal qty2 = decimal.Parse(lblDiscount.Text);
            totalDiscount = totalDiscount + qty2;
            Label lblNet = (Label)e.Row.FindControl("lblNet");
            decimal qty3 = decimal.Parse(lblNet.Text);
            totalNet = totalNet + qty3;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty1 = (Label)e.Row.FindControl("costtotal");
            lblTotalqty1.Font.Bold = true;
            lblTotalqty1.Text = "Total Cost:\nINR " + totalCost.ToString()+"/-";
            Label lblTotalqty2 = (Label)e.Row.FindControl("discounttotal");
            lblTotalqty2.Font.Bold = true;
            lblTotalqty2.Text = "Total Discount:\nINR " + totalDiscount.ToString()+"/-";
            Label lblTotalqty3 = (Label)e.Row.FindControl("nettotal");
            lblTotalqty3.Font.Bold = true;
            lblTotalqty3.Text = "Net Total:\nINR " + totalNet.ToString()+"/-";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReceiptSearch.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
}