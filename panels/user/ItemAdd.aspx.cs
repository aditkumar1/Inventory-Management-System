using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class Store_admin_ItemAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            BindProductCategory();
            BindUnit();
            DropDownList2.Enabled = false;
        }
        if(RadioButton1.Checked)
        {
            RequiredFieldValidator3.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList2.DataBind();
            Button2.Enabled = false;
            Button1.Enabled = true;
        }
        if (RadioButton2.Checked)
        {
            RequiredFieldValidator3.Enabled =true;
            DropDownList2.Enabled = true;
            DropDownList2.DataBind();
            Button1.Enabled = false;
            Button2.Enabled = true;
        }
    }
    private void BindUnit()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select UnitDetails.Unitid,Uname from UnitDetails", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "Uname";
        DropDownList3.DataValueField = "Unitid";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindUnit(String id)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Unitid from ItemBalance where Itemid=" + id, con);
        SqlDataReader dr =cmd.ExecuteReader();
        if (dr.Read())
        {
            DropDownList3.SelectedValue = dr["Unitid"].ToString();
        }
       //DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
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
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Pcname";
        DropDownList1.DataValueField = "Pcid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("----Select Product Category----", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindItem(String s)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Itemid,Iname from ItemDetails where Pcid=" + s+"Order By Iname", con);
        //DropDownList2.Enabled = true;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Iname";
        DropDownList2.DataValueField = "Itemid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("------------Select Item------------", "0"));
        con.Close();
        con.Dispose();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList1.SelectedValue;
        //Label2.Text = "";
        if (!index.Equals("0"))
        {
            if (!RadioButton1.Checked)
            {
                BindItem(index);
            }
            DropDownList2.BackColor = System.Drawing.Color.White;
        }
        else
        {
            DropDownList2.Enabled = false;
            DropDownList2.BackColor = System.Drawing.Color.Silver;
            TextBox1.Text = "";
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String index = DropDownList2.SelectedValue;
        if (!index.Equals("0"))
        {
            TextBox1.Text = DropDownList2.SelectedItem.Text;
            BindUnit(index);
        }
        else
        {
            TextBox1.Text = "";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand("insert into ItemDetails(Itemid,Iname,Pcid) Values((Select max(Itemid)+1 from ItemDetails),'"+Request.Form[TextBox1.UniqueID].ToUpper()+"',"+Request.Form[DropDownList1.UniqueID]+")", con);
        SqlCommand cmd1 = new SqlCommand("insert into ItemBalance(Itemid,Balance,Unitid) Values((Select max(Itemid) from ItemDetails),'" + "0" + "'," + Request.Form[DropDownList3.UniqueID] +")", con);
        con.Open();
        try
        {
            if (cmd.ExecuteNonQuery() >= 0 && cmd1.ExecuteNonQuery() >= 0)
            {
                DropDownList1.SelectedValue = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Item Added Successfully\" );", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Fill all Mandatory Entries\" );", true);
        }
        finally
        {
            con.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand("update ItemDetails set Iname='" + Request.Form[TextBox1.UniqueID].ToUpper() + "' where Itemid=" + Request.Form[DropDownList2.UniqueID], con);
        SqlCommand cmd2 = new SqlCommand("update ItemBalance set Unitid='" + Request.Form[DropDownList3.UniqueID] + "' where Itemid=" + Request.Form[DropDownList2.UniqueID], con);
        con.Open();
        try
        {
            if (cmd.ExecuteNonQuery() >= 0&&cmd2.ExecuteNonQuery()>0)
            {
                DropDownList1.SelectedValue = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Item Successfully Modified\" );", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Fill all Mandatory Entries\" );", true);
        }
        finally
        {
            con.Close();
        }
    }
}