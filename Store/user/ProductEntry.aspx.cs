using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ProductEntry : System.Web.UI.Page
{
    decimal vat, tax, misc, cost, discount, total;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox9_CalendarExtender.EndDate = DateTime.Today;
        if (!Page.IsPostBack)
        {
            BindVendor();
            BindProductCategory();
            DropDownList4.BackColor = System.Drawing.Color.Silver;
            FillGrid();
        }
    }
    private void FillGrid()
    {
        dt = getDatatable();
        gvEG.DataSource = dt;
        gvEG.DataBind();
    }
    private DataTable getDatatable()
    {
        DataTable d1;
        if (ViewState["dt"] != null)
        {
            d1 = (DataTable)ViewState["dt"];
        }
        else
        {
            d1 = CreateDatatable();
        }
        return d1;
    }
    private DataTable CreateDatatable()
    {
        DataTable dt1 = new DataTable();
        dt1.TableName = "Entries";
        dt1.Columns.Add("Sno", typeof(int));
        dt1.Columns["Sno"].AutoIncrement = true;
        dt1.Columns["Sno"].AutoIncrementSeed = 0;
        dt1.Columns["Sno"].AutoIncrementStep = 1;
        dt1.Columns.Add(new DataColumn("Itemid", typeof(Int32)));
        dt1.Columns.Add(new DataColumn("Unitid", typeof(Int32)));
        dt1.Columns.Add(new DataColumn("Pcname", typeof(string)));
        dt1.Columns.Add(new DataColumn("Iname", typeof(string)));
        dt1.Columns.Add(new DataColumn("Uname", typeof(string)));
        dt1.Columns.Add(new DataColumn("Description", typeof(string)));
        dt1.Columns.Add(new DataColumn("QRequired", typeof(float)));
        dt1.Columns.Add(new DataColumn("ItemTotalCost", typeof(float)));
        //dt1.Columns.Add(new DataColumn("Rate", typeof(float)));
        dt1.Columns.Add(new DataColumn("Discount", typeof(float)));
        dt1.Columns.Add(new DataColumn("Vat", typeof(float)));
        dt1.Columns.Add(new DataColumn("Tax", typeof(float)));
        dt1.Columns.Add(new DataColumn("Misc", typeof(float)));
        dt1.Columns.Add(new DataColumn("Net", typeof(float)));
        ViewState["dt"] = dt1;
        return dt1;
    }
    protected void gvEG_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Int32 Sno = Convert.ToInt32(gvEG.DataKeys[e.RowIndex].Values[0].ToString());
        DataTable dt = getDatatable();
        dt.Rows[e.RowIndex].Delete();
        FillGrid();
    }
    protected void gvEG_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    private void BindUnit(String id)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select UnitDetails.Unitid,Uname from UnitDetails,ItemBalance where ItemBalance.Unitid=UnitDetails.Unitid and Itemid=" + id, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "Uname";
        DropDownList3.DataValueField = "Unitid";
        DropDownList3.DataBind();
        //DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindVendor()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;//"Server=SANGEETA-PC\\SQLEXPRESS;initial catalog=store;integrated security=yes;";
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Vendorid,Vfirm from VendorDetails Order By Vfirm", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Vfirm";
        DropDownList1.DataValueField = "Vendorid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--------Select Vendor---------", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindBalance(String id)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Balance from ItemBalance where Itemid=" + id, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Label2.Text = "Product Balance In Store Is " + dr["Balance"].ToString();
        }
        dr.Close();
        con.Close();
        con.Dispose();
    }
    private void BindAddress(String id)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString; ;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Vaddress from VendorDetails where Vendorid=" + id, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TextBox4.Text = dr["Vaddress"].ToString();
        }
        dr.Close();
        con.Close();
        con.Dispose();
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
        SqlCommand cmd = new SqlCommand("Select Itemid,Iname from ItemDetails where Pcid=" + s + " Order by Iname", con);
        DropDownList4.Enabled = true;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "Iname";
        DropDownList4.DataValueField = "Itemid";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("------------Select Item------------", "0"));
        con.Close();
        con.Dispose();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (getDatatable().Rows.Count != 0)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlParameter param1 = new SqlParameter("@Itemid", SqlDbType.Int);
            SqlParameter param2 = new SqlParameter("@QReceived", SqlDbType.Float);
            SqlParameter param3 = new SqlParameter("@Description", SqlDbType.VarChar);
            SqlParameter param4 = new SqlParameter("@ItemTotalCost", SqlDbType.Float);
            SqlParameter param5 = new SqlParameter("@Discount", SqlDbType.Float);
            SqlParameter param6 = new SqlParameter("@Vat", SqlDbType.Float);
            SqlParameter param7 = new SqlParameter("@Tax", SqlDbType.Float);
            SqlParameter param8 = new SqlParameter("@Misc", SqlDbType.Float);
            SqlCommand cmd = new SqlCommand("form_insert", con);
            cmd.Parameters.AddWithValue("@GEno", Request.Form[TextBox1.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Invoiceno", Request.Form[TextBox2.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Vendorid", DropDownList1.SelectedValue.Trim());
            cmd.Parameters.AddWithValue("@Date", Request.Form[TextBox9.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@MOP", TextBox8.Text.Trim());
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            dt = getDatatable();
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            foreach (DataRow dr in dt.Rows)
            {
                param1.Value = dr["Itemid"].ToString();
                param2.Value = dr["QRequired"].ToString();
                param3.Value = dr["Description"].ToString();
                param4.Value = dr["ItemTotalCost"].ToString();
                param5.Value = dr["Discount"].ToString();
                param6.Value = dr["Vat"].ToString();
                param7.Value = dr["Tax"].ToString();
                param8.Value = dr["Misc"].ToString();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Check all Entries like required date pattern etc\" );", true);
                    break;
                }
            }
            con.Close();
            Session["SelectedGEno"] = Request.Form[TextBox1.UniqueID].Trim();
            Session["SelectedInvoiceno"] = Request.Form[TextBox2.UniqueID].Trim();
            Session["Date"] = Request.Form[TextBox9.UniqueID].Trim();
            Response.Redirect("ProductEntrySearchSlip.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Atleast 1 item required in table\" );", true);
        }
    }
    // Response.Redirect("~/store/EntrySuccessfull.aspx");
    protected void clear()
    {
        //DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
        Description.Text = "";
        Quantity.Text = "";
        Cost.Text = "";
        Discount.Text = "";
        Vat.Text = "";
        Tax.Text = "";
        Misc.Text = "";
        Label2.Text = "";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductEntry.aspx");
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList4.SelectedValue;
        if (!index.Equals("0"))
        {
            BindBalance(index);
            BindUnit(index);
        }
        else
        {
            Label2.Text = "";
            DropDownList3.Items.Clear();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList1.SelectedValue;
        if (!index.Equals("0"))
        {
            BindAddress(index);
        }
        else
        {
            TextBox4.Text = "";
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList2.SelectedValue;
        Label2.Text = "";
        if (!index.Equals("0"))
        {
            BindItem(index);
            DropDownList4.BackColor = System.Drawing.Color.White;
        }
        else
        {
            DropDownList4.Enabled = false;
            DropDownList4.BackColor = System.Drawing.Color.Silver;
        }
    }
    protected void B1_Click(object sender, EventArgs e)
    {
        DataTable dt = getDatatable();
        DataRow dr = dt.NewRow();
        dr["Itemid"] = DropDownList4.SelectedValue;
        dr["Unitid"] = DropDownList3.SelectedValue;
        dr["Pcname"] = DropDownList2.SelectedItem.Text;
        dr["Iname"] = DropDownList4.SelectedItem.Text;
        dr["Uname"] = DropDownList3.SelectedItem.Text;
        dr["Description"] = Description.Text;
        dr["QRequired"] = Quantity.Text;
        decimal cost = decimal.Parse(Cost.Text);
        dr["ItemTotalCost"] = Cost.Text;
        decimal discount = decimal.Parse(Discount.Text);
        decimal actualdiscount = 0;
        if (DropDownList5.SelectedValue.Equals("1"))
        {
            actualdiscount = (discount * cost) / 100;
        }
        else
        {
            actualdiscount = discount;
        }
        dr["Discount"] = Math.Round(actualdiscount, 2).ToString();
        decimal vat = decimal.Parse(Vat.Text);
        decimal actualvat = (vat * (cost - discount)) / 100;
        dr["Vat"] = Math.Round(actualvat, 2).ToString();
        dr["Tax"] = Tax.Text;
        dr["Misc"] = Misc.Text;
        dr["Net"] = cost - discount + actualvat + decimal.Parse(Tax.Text) + decimal.Parse(Misc.Text);
        dt.Rows.Add(dr);
        ViewState["dt"] = dt;
        clear();
        FillGrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label net = (Label)e.Row.FindControl("lblnet");
            decimal qty2 = decimal.Parse(net.Text);
            qty2 = Math.Round(qty2, 2);
            total = total + qty2;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty3 = (Label)e.Row.FindControl("nettotal");
            lblTotalqty3.Text = "Net\nTotal:INR " + (total) + "/-";
        }
    }
}