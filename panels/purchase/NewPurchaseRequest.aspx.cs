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
        TextBoxDate_CalendarExtender.EndDate = DateTime.Today;
        if (!Page.IsPostBack)
        {
            Label_Result.Visible = false;
            BindProductCategory();
            DropDownList4.BackColor = System.Drawing.Color.Silver;
            if (Session["Slipno"] != null && Session["Date"] != null && Session["Expdate"] != null && Session["ForwardDesignation"]!=null)
            {
                TextBox1.Text = Session["Slipno"].ToString();
                TextBoxDate.Text = Session["Date"].ToString();
                TextBoxDate.BackColor = System.Drawing.Color.Silver;
                TextBoxDate_CalendarExtender.Enabled = false;
                TextBoxDate.ReadOnly = true;
                TextBox2.Text = Session["Expdate"].ToString();
                TextBox2.BackColor = System.Drawing.Color.Silver;
                TextBox2_CalendarExtender.Enabled = false;
                TextBox2.ReadOnly = true;
                DropDownListForward.SelectedValue = Session["ForwardDesignation"].ToString();
                DropDownListForward.Enabled = false;
                //DropDownListForward.Enabled = false;
                DropDownListForward.BackColor = System.Drawing.Color.Silver;
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
            DropDownListForward.Enabled = true;
            int i = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("insert_purchase_requisition", con);
            command.Parameters.AddWithValue("@Userid", User.Identity.Name);
            command.Parameters.AddWithValue("@Prno", Request.Form[TextBox1.UniqueID]);
            command.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
            command.Parameters.AddWithValue("@QRequired", TextBoxQuantity.Text);
            command.Parameters.AddWithValue("@Apprxcost", TextBox3.Text);
            command.Parameters.AddWithValue("@ForwardDesignation",DropDownListForward.SelectedItem.Text.Trim());
            command.Parameters.AddWithValue("@Reqremarks", TextBoxRemarks.Text);
            command.Parameters.AddWithValue("@Gendate", Request.Form[TextBoxDate.UniqueID]);
            command.Parameters.AddWithValue("@Expdate", Request.Form[TextBox2.UniqueID]);
            command.Parameters.AddWithValue("@Status", "Pending");
            command.CommandType = CommandType.StoredProcedure;
            i = command.ExecuteNonQuery();
            con.Close();
                Response.Redirect("RequestSuccessfull.aspx");
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
    }
    protected void Button_AddMore_Click(object sender, EventArgs e)
    {
        DropDownListForward.Enabled = true;
        int i = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
        con.Open();
        SqlCommand command = new SqlCommand("insert_purchase_requisition", con);
        command.Parameters.AddWithValue("@Userid", User.Identity.Name);
        command.Parameters.AddWithValue("@Prno", Request.Form[TextBox1.UniqueID]);
        command.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
        command.Parameters.AddWithValue("@QRequired", TextBoxQuantity.Text);
        command.Parameters.AddWithValue("@Apprxcost", TextBox3.Text);
        command.Parameters.AddWithValue("@ForwardDesignation", DropDownListForward.SelectedItem.Text.Trim());
        command.Parameters.AddWithValue("@Reqremarks", TextBoxRemarks.Text);
        command.Parameters.AddWithValue("@Gendate", Request.Form[TextBoxDate.UniqueID]);
        command.Parameters.AddWithValue("@Expdate", Request.Form[TextBox2.UniqueID]);
        command.Parameters.AddWithValue("@Status", "Pending");
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
        Session["Date"] = Request.Form[TextBoxDate.UniqueID];
        Session["Expdate"]=Request.Form[TextBox2.UniqueID];
        Session["ForwardDesignation"] = Request.Form[DropDownListForward.UniqueID];
        Response.Redirect("NewPurchaseRequest.aspx");
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
}