using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;
public partial class Store_PurchaseItemSummary : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            BindProductCategory();
            BindDepartment();
            if (Session["mindate"] != null && Session["maxdate"] != null&&Session["category"]!=null&&Session["Item"]!=null&&Session["Depname"]!=null)
            {
                DropDownList2.SelectedValue = Session["category"].ToString();
                BindItem(DropDownList2.SelectedValue);
                DropDownList1.SelectedValue = Session["Depname"].ToString();
                DropDownList4.SelectedValue = Session["item"].ToString();
                SetDate(Session["mindate"].ToString(), Session["maxdate"].ToString());
                Session.Clear();
            }
        }
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
        DropDownList1.Items.Insert(0, new ListItem("------All-------", "0"));
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
        DropDownList2.Items.Insert(0, new ListItem("-------All-------", "0"));
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
        DropDownList4.Items.Insert(0, new ListItem("--------All--------", "0"));
        con.Close();
        con.Dispose();
    }
    private void SetDate(String Datemin,String Datemax)
    {
        if (Datemin.Equals("") && Datemax.Equals(""))
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CONVERT(varchar(10),min(IssueDetails.Date)) as MinDate from IssueDetails", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Datemin = dr["MinDate"].ToString();
            }
            con.Close();
            con.Dispose();
            DateTime time1 = DateTime.Now;              // Use current time
            string format1 = "yyyy-MM-dd";    // Use this format
            Datemax = (time1.ToString(format1));
        }
        else
        {
            TextBox2.Text = Datemin;
            TextBox3.Text = Datemax;
        }
        //DateTime dt = DateTime.Parse("");
        //String formatdate = "dd/MM/yyyy";
        Label1.Text = Datemin;//dt.ToString(formatdate);
        Label2.Text = Datemax;
        DateTime time = DateTime.Now;              // Use current time
        string format = "dd/MM/yyyy  HH:mm";    // Use this format
        Label3.Text = (time.ToString(format));
        BindGrid(Datemin, Datemax);
    }
    private void BindGrid(String Datemin,String Datemax)
    {
            String Depindex = DropDownList1.SelectedValue;
            String Depquery = DropDownList1.SelectedValue;
            String  itemquery = DropDownList4.SelectedValue, pcquery = DropDownList2.SelectedValue;
            if (DropDownList2.SelectedValue.Equals("0"))
            {
                pcquery = "%%";
            }
            if (DropDownList4.SelectedValue.Equals("0"))
            {
                itemquery = "%%";
            }
            if (Depindex.Equals("0"))
            {
                Depquery = "%%";
            }
            String strQuery = "select Isno,Isby,ItemDetails.Iname,ProductCategory.Pcname,Qissued,Uname,Depname,ReceivedBy,Convert(varchar(10),CONVERT(date,Date,106),103) as Date from Store.dbo.IssueDetails,Store.dbo.ProductCategory,Store.dbo.ItemDetails,Store.dbo.UnitDetails,Store.dbo.ItemBalance  where IssueDetails.Itemid=ItemDetails.Itemid and ItemDetails.Pcid=ProductCategory.Pcid and ItemBalance.Itemid=ItemDetails.Itemid and UnitDetails.Unitid=ItemBalance.Unitid and IssueDetails.Depname Like '" + Depquery + "' and ItemDetails.Itemid Like '" +itemquery + "' and ProductCategory.Pcid Like '" + pcquery + "' and Date Between '" + Datemin + "' and '" + Datemax + "' Order By IssueDetails.Date";
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductIssueSummary.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["mindate"] = Request.Form[TextBox2.UniqueID].Trim();
        Session["maxdate"] = Request.Form[TextBox3.UniqueID].Trim();
        Session["Depname"] = DropDownList1.SelectedValue;
        Session["category"] = DropDownList2.SelectedValue;
        Session["Item"] = DropDownList4.SelectedValue;
        Response.Redirect("ProductIssueSummary.aspx");
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages
                //GridView1.AllowPaging = false;
                //this.BindGrid();
                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Data might not be loaded \" );", true);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}