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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RadioTax.Checked)
        {
            EnableTax();
        }
        else
        {
            DisableTax();
        }
        if (!Page.IsPostBack)
        {
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
                DisableTax();
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
            EnableTextbox();
        }
        else if (CheckBox1.Enabled &&! CheckBox1.Checked)
        {
            FillTextbox();
            DisableTextbox();
        }
        else
        {
            DisableTextbox();
        }
    }
    private void EnableTax()
    {
        EC0.ReadOnly = false;
        EC1.ReadOnly = false;
        EC2.ReadOnly = false;
        EC3.ReadOnly = false;
        EC0.BackColor = System.Drawing.Color.White;
        EC1.BackColor = System.Drawing.Color.White;
        EC2.BackColor = System.Drawing.Color.White;
        EC3.BackColor = System.Drawing.Color.White;
    }
    private void DisableTax()
    {
        EC0.Text = "0";
        EC1.Text = "0";
        EC2.Text = "0";
        EC3.Text = "0";
        EC0.ReadOnly = true;
        EC1.ReadOnly = true;
        EC2.ReadOnly = true;
        EC3.ReadOnly = true;
        EC0.BackColor = System.Drawing.Color.Silver;
        EC1.BackColor = System.Drawing.Color.Silver;
        EC2.BackColor = System.Drawing.Color.Silver;
        EC3.BackColor = System.Drawing.Color.Silver;
    }
    private void FillTextbox()
    {
        VC0.Text = "0";
        VC1.Text = "0";
        VC2.Text = "0";
        VC3.Text = "0";
        VC4.Text = "0";
        VC5.Text = "";
    }
    private Boolean CheckSaveTextbox()
    {
        if(Session["VC0"]!=null&&Session["VC1"]!=null&&Session["VC2"]!=null&&Session["VC3"]!=null&&Session["VC4"]!=null&&Session["VC5"]!=null)
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
        Session["VC0"] = Request.Form[VC0.UniqueID];
        Session["VC1"] = Request.Form[VC1.UniqueID];
        Session["VC2"] = Request.Form[VC2.UniqueID];
        Session["VC3"] = Request.Form[VC3.UniqueID];
        Session["VC4"] =Request.Form[VC4.UniqueID];
        Session["VC5"] =Request.Form[VC5.UniqueID];
    }
    private void PutSaveTextbox()
    {
        VC0.Text = Session["VC0"].ToString();
        VC1.Text = Session["VC1"].ToString();
        VC2.Text = Session["VC2"].ToString();
        VC3.Text = Session["VC3"].ToString();
        VC4.Text = Session["VC4"].ToString();
        VC5.Text = Session["VC5"].ToString(); ;
    }
    private void DisableTextbox()
    {
        VC0.ReadOnly = true;
        VC1.ReadOnly = true;
        VC2.ReadOnly = true;
        VC3.ReadOnly = true;
        VC4.ReadOnly = true;
        VC5.ReadOnly = true;
        VC0.BackColor = System.Drawing.Color.Silver;
        VC1.BackColor = System.Drawing.Color.Silver;
        VC2.BackColor = System.Drawing.Color.Silver;
        VC3.BackColor = System.Drawing.Color.Silver;
        VC4.BackColor = System.Drawing.Color.Silver;
        VC5.BackColor = System.Drawing.Color.Silver;
    }
    private void EnableTextbox()
    {
        VC0.ReadOnly = false;
        VC1.ReadOnly = false;
        VC2.ReadOnly = false;
        VC3.ReadOnly = false;
        VC4.ReadOnly = false;
        VC5.ReadOnly = false;
        VC0.BackColor = System.Drawing.Color.White;
        VC1.BackColor = System.Drawing.Color.White;
        VC2.BackColor = System.Drawing.Color.White;
        VC3.BackColor = System.Drawing.Color.White;
        VC4.BackColor = System.Drawing.Color.White;
        VC5.BackColor = System.Drawing.Color.White;
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
    private void BindItem(String s)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Itemid,Iname from ItemDetails where Pcid=" + s+"Order By Iname", con);
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
    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList1.Enabled = true;
            int i = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("insert_material_receipt", con);
            command.Parameters.AddWithValue("@Mrno", Request.Form[TextBox1.UniqueID]);
            command.Parameters.AddWithValue("@Billno", Request.Form[TextBox12.UniqueID]);
            command.Parameters.AddWithValue("@Challanno", Request.Form[TextBox13.UniqueID]);
            command.Parameters.AddWithValue("@Pono", Request.Form[TextBox14.UniqueID]);
            command.Parameters.AddWithValue("@Vendorid",DropDownList1.SelectedValue);
            command.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
            command.Parameters.AddWithValue("@Description", TextBox6.Text);
            command.Parameters.AddWithValue("@Qtybill", TextBoxQuantity.Text);
            command.Parameters.AddWithValue("@Qtyactual", TextBox15.Text);
            command.Parameters.AddWithValue("@Qtyrejected", TextBox16.Text);
            command.Parameters.AddWithValue("@Rate", TextBox3.Text);
            command.Parameters.AddWithValue("@Discount", Request.Form[EC0.UniqueID]);
            command.Parameters.AddWithValue("@Vat", Request.Form[EC1.UniqueID]);
            command.Parameters.AddWithValue("@Tax", Request.Form[EC2.UniqueID]);
            command.Parameters.AddWithValue("@Misc", Request.Form[EC3.UniqueID]);
            command.Parameters.AddWithValue("@Exduty", Request.Form[VC0.UniqueID]);
            command.Parameters.AddWithValue("@Packcharge", Request.Form[VC1.UniqueID]);
            command.Parameters.AddWithValue("@Freightcharge", Request.Form[VC2.UniqueID]);
            command.Parameters.AddWithValue("@Othercharge", Request.Form[VC3.UniqueID]);
            command.Parameters.AddWithValue("@Adjustmant", Request.Form[VC4.UniqueID]);
            command.Parameters.AddWithValue("@Remarks", Request.Form[VC5.UniqueID]);
            command.CommandType = CommandType.StoredProcedure;
            i = command.ExecuteNonQuery();
            con.Close();
            Session["SelectedPono"] = Request.Form[TextBox1.UniqueID];
                Response.Redirect("MaterialReceiptSearchSlip.aspx");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
    }
    protected void Button_AddMore_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
        con.Open();
        DropDownList1.Enabled = true;
        SqlCommand command = new SqlCommand("insert_material_receipt", con);
        command.Parameters.AddWithValue("@Mrno", Request.Form[TextBox1.UniqueID]);
        command.Parameters.AddWithValue("@Billno", Request.Form[TextBox12.UniqueID]);
        command.Parameters.AddWithValue("@Challanno", Request.Form[TextBox13.UniqueID]);
        command.Parameters.AddWithValue("@Pono", Request.Form[TextBox14.UniqueID]);
        command.Parameters.AddWithValue("@Vendorid", DropDownList1.SelectedValue);
        command.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
        command.Parameters.AddWithValue("@Description", TextBox6.Text);
        command.Parameters.AddWithValue("@Qtybill", TextBoxQuantity.Text);
        command.Parameters.AddWithValue("@Qtyactual", TextBox15.Text);
        command.Parameters.AddWithValue("@Qtyrejected", TextBox16.Text);
        command.Parameters.AddWithValue("@Rate", TextBox3.Text);
        command.Parameters.AddWithValue("@Discount", Request.Form[EC0.UniqueID]);
        command.Parameters.AddWithValue("@Vat", Request.Form[EC1.UniqueID]);
        command.Parameters.AddWithValue("@Tax", Request.Form[EC2.UniqueID]);
        command.Parameters.AddWithValue("@Misc", Request.Form[EC3.UniqueID]);
        command.Parameters.AddWithValue("@Exduty", Request.Form[VC0.UniqueID]);
        command.Parameters.AddWithValue("@Packcharge", Request.Form[VC1.UniqueID]);
        command.Parameters.AddWithValue("@Freightcharge", Request.Form[VC2.UniqueID]);
        command.Parameters.AddWithValue("@Othercharge", Request.Form[VC3.UniqueID]);
        command.Parameters.AddWithValue("@Adjustmant", Request.Form[VC4.UniqueID]);
        command.Parameters.AddWithValue("@Remarks", Request.Form[VC5.UniqueID]);
        command.CommandType = CommandType.StoredProcedure;
        try
        {
            i=command.ExecuteNonQuery();    
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);    
        }
        finally
        {
            con.Close();
        }
        Session["Slipno"] = Request.Form[TextBox1.UniqueID];
        Session["Vid"] = DropDownList1.SelectedValue;
        Session["Vaddress"] = Request.Form[TextBox4.UniqueID];
        SaveTextbox();
        Response.Redirect("MaterialReceiptGenerate.aspx");
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList2.SelectedValue;
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
    protected void DropDownListt4_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList4.SelectedValue;
        if (!index.Equals("0"))
        {
            BindUnit(index);
        }
        else
        {
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
}