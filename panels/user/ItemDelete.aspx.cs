using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class Store_admin_ProductCategoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Fill all Mandatory Entries\" );", true);
        if (!Page.IsPostBack)
        {
            BindProductCategory();
        }
    }
    private void BindProductCategory()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Pcid,Pcname from ProductCategory Order By Pcname", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Pcname";
        DropDownList2.DataValueField = "Pcid";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("----------Select Product Category-----------", "0"));
        con.Close();
        con.Dispose();
    }
    private void BindGrid(String id)
    {
        String strQuery = "select ItemDetails.Itemid,Iname,Uname from Store.dbo.ProductCategory,Store.dbo.ItemDetails,Store.dbo.UnitDetails,Store.dbo.ItemBalance where ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and ItemDetails.Pcid = "+id+" Order By Iname";
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
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex != e.Row.RowIndex)
        {
            (e.Row.Cells[3].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Itemid = (int)GridView1.DataKeys[e.RowIndex].Value;
        int i=DeleteRecordByID(Itemid);
        if(i>0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Product Successfully Deleted\" );", true);
            BindGrid(DropDownList2.SelectedValue);
        }
        else if(i==-100)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Operation Failed.Critical Databse Error\" );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Product can not be deleted as the Product is already in use in Store Entry or Store Issue\" );", true);
        }
    }
    private int DeleteRecordByID(int Itemid)
    {
        String strQuery = "item_delete";
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.AddWithValue("Itemid",Itemid);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        con.Open();
        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
           return -100;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex.Equals("0"))
        {
            GridView1.DataSource = null;
        }
        else
        {
            BindGrid(DropDownList2.SelectedValue);
        }
    }
}