using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
public partial class Store_Hod_NewIssueRequest : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrid();
            Label_Result.Visible = false;
            BindVendor();
            BindProductCategory();
            DropDownList4.BackColor = System.Drawing.Color.Silver;
            TextBox4.BackColor = System.Drawing.Color.Silver;
            if (Session["Slipno"] != null && CheckSaveTextbox() && Session["Vid"] != null && Session["Vaddress"] != null)
            {
                TextBox1.Text = Session["Slipno"].ToString();
                DropDownList1.SelectedValue = Session["Vid"].ToString();
                TextBox4.Text = Session["Vaddress"].ToString();
                DropDownList1.Enabled = false;
                PutSaveTextbox();
                CheckBox1.Enabled = false;
                Session.Clear();
                Label_Result.Text = "Item Successfully Saved. Input more items to same Request";
                Label_Result.Visible = true;
            }
            else
            {
                TextBox1.Text = generateUnique().ToString();
            }
            TextBox1.BackColor = System.Drawing.Color.Silver;
        }
        if (CheckBox1.Enabled && CheckBox1.Checked)
        {
            FillTextbox();
            DisableTextbox();
        }
        else if (CheckBox1.Enabled && !CheckBox1.Checked)
        {
            EnableTextbox();
        }
        else
        {
            DisableTextbox();
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
        dt1.Columns.Add(new DataColumn("Iname", typeof(string)));
        dt1.Columns.Add(new DataColumn("Uname", typeof(string)));
        dt1.Columns.Add(new DataColumn("Description", typeof(string)));
        dt1.Columns.Add(new DataColumn("QRequired", typeof(float)));
        dt1.Columns.Add(new DataColumn("Rate", typeof(float)));
        dt1.Columns.Add(new DataColumn("Discount", typeof(float)));
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
    private void FillTextbox()
    {
        TextBox2.Text = "INCLUDE";
        TextBox7.Text = "WITHIN ONE WEEK";
        TextBox8.Text = "AS ABOVE ADDRESS";
        TextBox9.Text = "FOR";
        TextBox10.Text = "BY CHEQUE AFTER DELIVERY";
        TextBox11.Text = "";
    }
    private Boolean CheckSaveTextbox()
    {
        if (Session["TextBox2"] != null && Session["TextBox7"] != null && Session["TextBox8"] != null && Session["TextBox9"] != null && Session["TextBox10"] != null && Session["TextBox11"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void SaveTextbox()
    {
        Session["TextBox2"] = Request.Form[TextBox2.UniqueID];
        Session["TextBox7"] = Request.Form[TextBox7.UniqueID];
        Session["TextBox8"] = Request.Form[TextBox8.UniqueID];
        Session["TextBox9"] = Request.Form[TextBox9.UniqueID];
        Session["TextBox10"] = Request.Form[TextBox10.UniqueID];
        Session["TextBox11"] = Request.Form[TextBox11.UniqueID];
    }
    private void PutSaveTextbox()
    {
        TextBox2.Text = Session["TextBox2"].ToString();
        TextBox7.Text = Session["TextBox7"].ToString();
        TextBox8.Text = Session["TextBox8"].ToString();
        TextBox9.Text = Session["TextBox9"].ToString();
        TextBox10.Text = Session["TextBox10"].ToString();
        TextBox11.Text = Session["TextBox11"].ToString(); ;
    }
    private void DisableTextbox()
    {
        TextBox2.ReadOnly = true;
        TextBox7.ReadOnly = true;
        TextBox8.ReadOnly = true;
        TextBox9.ReadOnly = true;
        TextBox10.ReadOnly = true;
        TextBox11.ReadOnly = true;
        TextBox2.BackColor = System.Drawing.Color.Silver;
        TextBox7.BackColor = System.Drawing.Color.Silver;
        TextBox8.BackColor = System.Drawing.Color.Silver;
        TextBox9.BackColor = System.Drawing.Color.Silver;
        TextBox10.BackColor = System.Drawing.Color.Silver;
        TextBox11.BackColor = System.Drawing.Color.Silver;
    }
    private void EnableTextbox()
    {
        TextBox2.ReadOnly = false;
        TextBox7.ReadOnly = false;
        TextBox8.ReadOnly = false;
        TextBox9.ReadOnly = false;
        TextBox10.ReadOnly = false;
        TextBox11.ReadOnly = false;
        TextBox2.BackColor = System.Drawing.Color.White;
        TextBox7.BackColor = System.Drawing.Color.White;
        TextBox8.BackColor = System.Drawing.Color.White;
        TextBox9.BackColor = System.Drawing.Color.White;
        TextBox10.BackColor = System.Drawing.Color.White;
        TextBox11.BackColor = System.Drawing.Color.White;
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
    private string generateUnique()
    {
        var chars = "0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
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
    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        DataTable dt = getDatatable();
        if (dt.Rows.Count != 0)
        {
            DropDownList1.Enabled = true;
            int i = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("insert_purchase_order", con);
            SqlParameter param1 = new SqlParameter("@Itemid", SqlDbType.Int);
            SqlParameter param2 = new SqlParameter("@Description", SqlDbType.VarChar);
            SqlParameter param3 = new SqlParameter("@QRequired", SqlDbType.Float);
            SqlParameter param4 = new SqlParameter("@Rate", SqlDbType.Float);
            SqlParameter param5 = new SqlParameter("@Discount", SqlDbType.Float);
            command.Parameters.AddWithValue("@Pono", Request.Form[TextBox1.UniqueID]);
            command.Parameters.AddWithValue("@Vendorid", DropDownList1.SelectedValue);
            command.Parameters.AddWithValue("@Tax", Request.Form[TextBox2.UniqueID]);
            command.Parameters.AddWithValue("@Delperiod", Request.Form[TextBox7.UniqueID]);
            command.Parameters.AddWithValue("@Delplace", Request.Form[TextBox8.UniqueID]);
            command.Parameters.AddWithValue("@Freight", Request.Form[TextBox9.UniqueID]);
            command.Parameters.AddWithValue("@MOP", Request.Form[TextBox10.UniqueID]);
            command.Parameters.AddWithValue("@Warranty", Request.Form[TextBox11.UniqueID]);
            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);
            command.Parameters.Add(param5);
            command.CommandType = CommandType.StoredProcedure;
            foreach (DataRow dr in dt.Rows)
            {
                param1.Value = dr["Itemid"].ToString();
                param2.Value = dr["Description"].ToString();
                param3.Value = dr["QRequired"].ToString();
                param4.Value = dr["Rate"].ToString();
                param5.Value = dr["Discount"].ToString();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Check all Entries like required date pattern etc\" );", true);
                    break;
                }
            }
            con.Close();
            Session["SelectedPono"] = Request.Form[TextBox1.UniqueID];
            Response.Redirect("PurchaseOrderSearchSlip.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: No Items Added+\" );", true);
        }
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
        dr["Iname"] = DropDownList4.SelectedItem.Text;
        dr["Uname"] = DropDownList3.SelectedItem.Text;
        dr["Description"] = Description.Text;
        dr["QRequired"] = Quantity.Text;
        dr["Rate"] = Rate.Text;
        dr["Discount"] = Discount.Text;
        dt.Rows.Add(dr);
        ViewState["dt"] = dt;
        FillGrid();
    }
}