using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Store_ProductEntrySearchSlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SelectedIsno"] != null)
        {
            Label3.Text=Session["SelectedIsno"].ToString();
            BindField();
            BindGrid();
        }
    }
    private void BindField()
    {
        string strQuery = "select Isby,Depname,ReceivedBy,CONVERT(varchar(10),Date) as Date from IssueDetails,ProductCategory,ItemDetails where IssueDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and Isno=" + Session["SelectedIsno"];
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand(strQuery,con);
        try
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = dr["Depname"].ToString();
                Label2.Text = dr["Date"].ToString();
                Label4.Text = dr["Isby"].ToString();
                Label5.Text = dr["ReceivedBy"].ToString();
            }
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
    private void BindGrid()
    {
        string strQuery = "select Iname,Pcname,Qissued,Uname,ROW_NUMBER() OVER (ORDER BY Iname) as Srno from IssueDetails,ProductCategory,ItemDetails,UnitDetails,ItemBalance where IssueDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemDetails.Itemid=ItemBalance.Itemid and ItemBalance.Unitid=UnitDetails.Unitid and Isno=" + Session["SelectedIsno"];
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
    private DataTable InsertRowAtEnd(DataTable dt)
    {
        for (int i = dt.Rows.Count + 1; i <= 25; i++)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }
        return dt;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("IssueSearch.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
}