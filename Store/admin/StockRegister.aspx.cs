using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Store_PurchaseItemSummary : System.Web.UI.Page
{
    decimal totalReceived = 0,totalIssued=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "dd/MM/yyyy  HH:mm";    // Use this format
        Label3.Text = (time.ToString(format));
        if(!Page.IsPostBack)
        {
            BindProductCategory();
            DropDownList3.Enabled=false;
            DropDownList3.BackColor = System.Drawing.Color.Silver;
        }
        if (Session["category"] != null && Session["Item"] != null)
        {
            DropDownList3.Enabled =true;
            DropDownList3.BackColor = System.Drawing.Color.White;
            DropDownList2.SelectedValue = Session["category"].ToString();
            BindItem(DropDownList2.SelectedValue);
            DropDownList3.SelectedValue = Session["Item"].ToString();
            Label1.Text = DropDownList2.SelectedItem.Text;
            Label2.Text = DropDownList3.SelectedItem.Text;
            BindGrid(DropDownList3.SelectedValue);
            Session.Clear();
        }
     }
    private void BindProductCategory()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Pcid,Pcname  from ProductCategory Order By Pcname", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Pcname";
        DropDownList2.DataValueField = "Pcid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("----Select Product Category----", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindItem(String s)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Itemid,Iname from ItemDetails where Pcid=" + s+"Order By Iname", con);
        DropDownList3.Enabled = true;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "Iname";
        DropDownList3.DataValueField = "Itemid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("------------Select Item------------", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindGrid(String itemid)
    {
        String strQuery = "Stock_Details_test";
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.AddWithValue("@InameSearch",itemid.Trim());
        cmd.CommandType = CommandType.StoredProcedure;
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
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblrecv = (Label)e.Row.FindControl("lblReceived");
            decimal qty = decimal.Parse(lblrecv.Text);
            //qty = Math.Round(qty,2);
            totalReceived = totalReceived + qty;
            Label lbliss = (Label)e.Row.FindControl("lblissued");
            decimal qty2 = decimal.Parse(lbliss.Text);
            //qty2 = Math.Round(qty2, 2);
            totalIssued = totalIssued + qty2;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty1 = (Label)e.Row.FindControl("receivedtotal");
            totalReceived = Math.Round(totalReceived, 2);
            lblTotalqty1.Text ="Total\nReceived:"+totalReceived.ToString();
            totalIssued = Math.Round(totalIssued, 2);
            Label lblTotalqty2 = (Label)e.Row.FindControl("issuetotal");
            lblTotalqty2.Text = "Total\nIssued:" + totalIssued.ToString();
            Label lblTotalqty3 = (Label)e.Row.FindControl("totalBalance");
            lblTotalqty3.Text = "Current\nBalance:" +(totalReceived-totalIssued);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["category"] = DropDownList2.SelectedValue;
        Session["Item"] = DropDownList3.SelectedValue;
        Response.Redirect("~/store/user/StockRegister.aspx");
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList2.SelectedValue;
        Label2.Text = "";
        Label1.Text = "";
        GridView1.DataBind();
        if (!index.Equals("0"))
        {
            BindItem(index);
            DropDownList3.BackColor = System.Drawing.Color.White;
        }
        else
        {
            DropDownList3.Enabled = false;
            DropDownList3.BackColor = System.Drawing.Color.Silver;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList3.SelectedValue;
        if (!index.Equals("0"))
        {
            Label2.Text = DropDownList2.SelectedItem.Text;
            Label1.Text = DropDownList3.SelectedItem.Text;
            BindGrid(index);
        }
        else
        {
            GridView1.DataBind();
        }
    }
}