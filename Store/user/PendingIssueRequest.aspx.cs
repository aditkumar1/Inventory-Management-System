using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class Store_Hod_PendingIssueRequest : System.Web.UI.Page
{
    String Requester="", Depname="", Designation="";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserDetails();
        GetSelectedRecord();
         if (RadioButton3.Checked)
         {
            TextBox2.Enabled = true;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            string strQuery = "select DISTINCT(Slipno),Status,ApprvRemarks as Remarks,Convert(varchar(10),CONVERT(date,Gendate,106),103) as Date,Gendate as Sortdate from IssueRequisition where Slipno LIKE '%" + TextBox2.Text + "%'  Order By Sortdate DESC";
            BindGrid(strQuery);
        }
        if (RadioButton4.Checked)
        {
            TextBox2.Enabled = false;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            string strQuery = "select DISTINCT(Slipno),Status,ApprvRemarks as Remarks,Convert(varchar(10),CONVERT(date,Gendate,106),103) as Date,Gendate as Sortdate from IssueRequisition Where Gendate BETWEEN '" + TextBox3.Text + "' AND  '" + TextBox4.Text + "'  Order By Sortdate DESC";
            BindGrid(strQuery);
        }
    }
    protected void GetUserDetails()
    {
        String   Userid = User.Identity.Name.ToString();
        if (!Userid.Equals(""))
        {
            string strQuery = "select * from UserDetailsMain where Userid='" + Userid + "'";
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strQuery, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Requester = dr["Username"].ToString();
                    Depname = dr["Depname"].ToString();
                    Designation = dr["Designation"].ToString();
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
    private void BindGrid(String strQuery)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
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
    private void GetSelectedRecord()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)GridView1.Rows[i]
                            .Cells[0].FindControl("RadioButton1");
            if (rb != null)
            {
                if (rb.Checked)
                {
                    HiddenField hf = (HiddenField)GridView1.Rows[i]
                                    .Cells[0].FindControl("HiddenField1");
                    if (hf != null )
                    {
                        ViewState["SelectedSno"] = hf.Value;
                    }
                    break;
                }
            }
        }
    }
    private void SetSelectedRecord()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0]
                                            .FindControl("RadioButton1");
            if (rb != null)
            {
                HiddenField hf = (HiddenField)GridView1.Rows[i]
                                    .Cells[0].FindControl("HiddenField1");
                if (hf != null && ViewState["SelectedSno"] != null)
                {
                    if (hf.Value.Equals(ViewState["SelectedSno"].ToString()))
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        SetSelectedRecord();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        GetSelectedRecord();
        if (ViewState["SelectedSno"] != null)
        {
            Session["SelectedSlipno"] = ViewState["SelectedSno"].ToString().Trim();
            Response.Redirect("IssueRequestSlip.aspx");
        }
    }
}