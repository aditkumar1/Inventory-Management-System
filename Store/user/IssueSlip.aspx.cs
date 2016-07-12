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
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox9_CalendarExtender.EndDate = DateTime.Today;
        Label1.Visible = false;
        if (!Page.IsPostBack)
        {
            BindProductCategory();
            BindName();
            DropDownList4.BackColor = System.Drawing.Color.Silver;
        }    
            if (Session["Isno"] != null && Session["DropDown"]!=null&&Session["Isby"] != null && Session["ReceivedBy"] != null && Session["Remarks"] != null && Session["Date"] != null && Session["Save"] != null)
            {
                Label1.Visible = true;
                TextBox1.Text = Session["Isno"].ToString();
                TextBox2.Text = Session["Isby"].ToString();
                TextBox7.Text = Session["ReceivedBy"].ToString();
                TextBox8.Text = Session["Remarks"].ToString();
                TextBox9.Text = Session["Date"].ToString();
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
                TextBox7.ReadOnly = true;
                TextBox8.ReadOnly = true;
                TextBox9.ReadOnly = true;
                TextBox1.BackColor = System.Drawing.Color.Silver;
                TextBox2.BackColor = System.Drawing.Color.Silver;
                TextBox7.BackColor = System.Drawing.Color.Silver;
                TextBox8.BackColor = System.Drawing.Color.Silver;
                TextBox9.BackColor = System.Drawing.Color.Silver;
                TextBox9_CalendarExtender.Enabled = false;
                if(!Page.IsPostBack)
                BindDepartment();
                DropDownList1.Items.FindByText(Session["DropDown"].ToString()).Selected = true;
                DropDownList1.Enabled = false;
                Session.Clear();
            }
            else
            {
                if (!Page.IsPostBack)
                BindDepartment();
            }
            TextBox9.ReadOnly = true;
    }
    protected void BindName()
    {
        string Userid = HttpContext.Current.User.Identity.Name;
        string strQuery = "select Username from UserDetailsMain where Userid='" + Userid + "'";
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand(strQuery, con);
        try
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox2.Text =dr["Username"].ToString();
            }
            TextBox2.ReadOnly = true;
            TextBox2.BackColor = System.Drawing.Color.Silver;
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
    private void BindDepartment()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Depid,Depname from DepartmentTable Order By Depname", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Depname";
        DropDownList1.DataValueField = "Depid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0,new ListItem("----------Select department-----------","0"));
        con.Close();
        con.Dispose();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        int i = 0;
        DropDownList1.Enabled = true;
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand("issue_insert", con);
        cmd.Parameters.AddWithValue("@Isno", Request.Form[TextBox1.UniqueID].Trim());
        cmd.Parameters.AddWithValue("@Isby", Request.Form[TextBox2.UniqueID].Trim());
        cmd.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
        cmd.Parameters.AddWithValue("@QRequired", TextBox5.Text.Trim());
        cmd.Parameters.AddWithValue("@QIssued", TextBox6.Text.Trim());
        cmd.Parameters.AddWithValue("@Depname", DropDownList1.SelectedItem.Text.Trim());
        cmd.Parameters.AddWithValue("@ReceivedBy", Request.Form[TextBox7.UniqueID].Trim());
        cmd.Parameters.AddWithValue("@Remarks", Request.Form[TextBox8.UniqueID].Trim());
        cmd.Parameters.AddWithValue("@Date", Request.Form[TextBox9.UniqueID].Trim());
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            i=cmd.ExecuteNonQuery();
            if (i < 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Entries not inserted.Check Product Balance\" );", true);
            }
            else
            {
                Session["SelectedIsno"] = Request.Form[TextBox1.UniqueID].Trim();
                Session["Date"] = Request.Form[TextBox9.UniqueID].Trim();
                Response.Redirect("IssueSearchSlip.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Check all Entries like required date pattern etc\" );", true);
        }
        finally
        {
            con.Close();
        }
        //Response.Redirect("~/store/IssueEntrySuccessfull.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("IssueSlip.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        int i = 0;
            DropDownList1.Enabled = true;
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("issue_insert", con);
            cmd.Parameters.AddWithValue("@Isno", Request.Form[TextBox1.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Isby", Request.Form[TextBox2.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Itemid", Request.Form[DropDownList4.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@QRequired", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@QIssued", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@Depname", DropDownList1.SelectedItem.Text.Trim());
            cmd.Parameters.AddWithValue("@ReceivedBy", Request.Form[TextBox7.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Remarks", Request.Form[TextBox8.UniqueID].Trim());
            cmd.Parameters.AddWithValue("@Date", Request.Form[TextBox9.UniqueID].Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                i=cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Entries not inserted.Check Product Balance\" );", true);
                }
                else
                {
                    Session["Isno"] = Request.Form[TextBox1.UniqueID].Trim();
                    Session["Isby"] = Request.Form[TextBox2.UniqueID].Trim();
                    Session["ReceivedBy"] = Request.Form[TextBox7.UniqueID].Trim();
                    Session["Remarks"] = Request.Form[TextBox8.UniqueID].Trim();
                    Session["Date"] = Request.Form[TextBox9.UniqueID].Trim();
                    Session["DropDown"] = DropDownList1.SelectedItem.Text;
                    Session["Save"] = "Yes";
                    Response.Redirect("IssueSlip.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Check all Entries like required date pattern etc\" );", true);
            }
            finally
            {
                con.Close();
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
}