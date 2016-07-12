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
     String Sno = "";
     SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox9_CalendarExtender.EndDate = DateTime.Today;
        if (Session["SelectedSno"] != null)
        {
            Sno = Session["SelectedSno"].ToString();
            if(!Page.IsPostBack)
            {
                BindDepartment();
                BindProductCategory();
                FillTextBoxes();
            }
            DropDownList2.Enabled = false;
            DropDownList4.Enabled = false;
        }
        else
        {
            Response.Redirect("IssueModify.aspx");
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
        DropDownList1.DataValueField = "Depname";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("----------Select department-----------", "0"));
        con.Close();
        con.Dispose();
    }
    private void FillTextBoxes()
    {
        string strQuery = "select IssueDetails.Itemid,Isno,Isby,Iname,ProductCategory.Pcid,QRequired,Qissued,UnitDetails.Unitid,Balance,Depname,ReceivedBy,Remarks,CONVERT(varchar(10),IssueDetails.Date) as Date from IssueDetails,ItemBalance,ItemDetails,ProductCategory,UnitDetails where  IssueDetails.Itemid=ItemDetails.Itemid and IssueDetails.Itemid=ItemBalance.Itemid and ItemBalance.Unitid=UnitDetails.Unitid and ItemDetails.Pcid=ProductCategory.Pcid and Sno=" + Sno;
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString; SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            TextBox1.Text=dr["Isno"].ToString();
            TextBox2.Text = dr["Isby"].ToString();
            DropDownList2.SelectedValue = dr["PcID"].ToString();
            BindItem(DropDownList2.SelectedValue);
            DropDownList4.SelectedValue = dr["Itemid"].ToString();
            BindUnit(DropDownList4.SelectedValue);
            BindBalance(DropDownList4.SelectedValue);
            DropDownList3.SelectedValue = dr["Unitid"].ToString();
            TextBox5.Text = dr["QRequired"].ToString();
            TextBox6.Text = dr["Qissued"].ToString();
            TextBox7.Text = dr["ReceivedBy"].ToString();
            TextBox8.Text = dr["Remarks"].ToString();
            TextBox9.Text = dr["Date"].ToString();
            try
            {
                DropDownList1.Items.FindByText(dr["Depname"].ToString()).Selected = true;
            }
            catch(Exception ex)
            {
            }
        }
        con.Close();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "setLabelValue", "setLabelValue(\"" + val1 + "\",\"" + val2 + "\");", true);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
       if (Session["SelectedSno"] != null)
       {
           DropDownList2.Enabled = true;
           DropDownList4.Enabled = true;
           Sno = Session["SelectedSno"].ToString();
           String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
           SqlConnection con = new SqlConnection(strConnString);
           con.Open();
           SqlCommand cmd = new SqlCommand("IssueModify", con);
           cmd.Parameters.AddWithValue("@Sno", Session["SelectedSno"].ToString());
           cmd.Parameters.AddWithValue("@Isno", Request.Form[TextBox1.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@Isby", Request.Form[TextBox2.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@Itemid", DropDownList4.SelectedValue.Trim());
           cmd.Parameters.AddWithValue("@QRequired", Request.Form[TextBox5.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@QIssued", Request.Form[TextBox6.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@Depname", DropDownList1.SelectedItem.Text.Trim());
           cmd.Parameters.AddWithValue("@ReceivedBy", Request.Form[TextBox7.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@Remarks", Request.Form[TextBox8.UniqueID].Trim());
           cmd.Parameters.AddWithValue("@Date", Request.Form[TextBox9.UniqueID].Trim());
           cmd.CommandType = CommandType.StoredProcedure;
           int i=cmd.ExecuteNonQuery();
           con.Close();
           con.Open();
           if (i < 0)
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Entries not inserted.Check Product Balance\" );", true);
           }
           else
           {
               Session["Modified"] = "yes";
               Response.Redirect("IssueModify.aspx");
           }
       }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("IssueModifyForm.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("IssueModify.aspx");
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