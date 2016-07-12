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
        if (Session["SelectedSlipno"] != null)
        {
            Label3.Text = Session["SelectedSlipno"].ToString();
            BindField();
            BindGrid();
        }
    }
     protected void BindField()
    {
        String Userid=User.Identity.Name.ToString();
        Label3.Text = Session["SelectedSlipno"].ToString();
        String format = "dd/MM/yyyy";
         Label2.Text = DateTime.Now.ToString(format);
         if(!Userid.Equals(""))
        {
            string strQuery = "select Requester,Depname,Status,Convert(varchar(10),CONVERT(date,Gendate,106),103) as Gendate,ForwardDesignation as Approver from IssueRequisition where Slipno=" + Session["SelectedSlipno"].ToString(); 
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strQuery, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Label4.Text = dr["Requester"].ToString();
                    Label1.Text = dr["Depname"].ToString();
                    Label5.Text = dr["Status"].ToString();
                    Label8.Text = dr["Gendate"].ToString();
                    if(Label5.Text.Equals("Approved"))
                    {
                        Label7.Text =dr["Approver"].ToString();
                    }
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
    }
    private void BindGrid()
    {
        string strQuery = "select_issue_requisition"; 
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.AddWithValue("@Slipno", Session["SelectedSlipno"].ToString());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource =dt;
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
    /*
    private DataTable InsertRowAtEnd(DataTable dt)
    {
        for (int i = dt.Rows.Count + 1; i <= 25; i++)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }
        return dt;
    }
    */
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PendingIssueRequest.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
}