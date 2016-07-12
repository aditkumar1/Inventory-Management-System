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
            BindRoles();
            BindDepartment();
        }
    }
    private void BindRoles()
    {
        DropDownList2.Items.Insert(0, new ListItem("------Select-------", ""));
        DropDownList2.Items.Insert(1, new ListItem("Director", "Director"));
        DropDownList2.Items.Insert(2, new ListItem("Admin", "Admin"));
        DropDownList2.Items.Insert(3, new ListItem("HoD", "HoD"));
        DropDownList2.Items.Insert(4, new ListItem("Finance Office", "Finance Office"));
        DropDownList2.Items.Insert(5, new ListItem("Purchase Office", "Purchase Office"));
        DropDownList2.Items.Insert(6, new ListItem("Store User", "Store User"));
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
//        DropDownList1.Items.Insert(0, new ListItem("------None-------", ""));
        con.Close();
        con.Dispose();
    }
    protected void clearText()
    {
        txtUserName.Text = "";
        txtUserid.Text = "";
        txtPassword.Text = "";
        txtDesignation.Text = "";
    }
    protected void Insert(object sender, EventArgs e)
    {
        try
        {
            SqlDataSource1.Insert();
            clearText();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Fill all Mandatory Entries\" );", true);
        }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex != e.Row.RowIndex)
        {
            (e.Row.Cells[5].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }
}