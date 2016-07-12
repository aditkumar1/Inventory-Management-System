using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ProductEntryModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetSelectedRecord();
        if(RadioButton2.Checked)
        {
            TextBox1.Enabled = true;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            string strQuery = "select DISTINCT(Isno),Depname,Isby,Convert(varchar(10),CONVERT(date,IssueDetails.Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails where Isno LIKE '%" + TextBox1.Text +"%' Order By Sortdate DESC";
            BindGrid(strQuery);
        }
        if(RadioButton3.Checked)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = true;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            string strQuery = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,IssueDetails.Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails where Depname LIKE '%" + TextBox2.Text + "%' Order By Sortdate DESC";
            BindGrid(strQuery);
        }
        if(RadioButton4.Checked)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            string strQuery = "select DISTINCT(Isno),Isby,Depname,Convert(varchar(10),CONVERT(date,IssueDetails.Date,106),103) as Date,IssueDetails.Date as Sortdate from IssueDetails where SortDate BETWEEN '" + TextBox3.Text + "' AND  '" + TextBox4.Text + "' Order By Sortdate DESC";
            BindGrid(strQuery);
        }
    }
    private void BindGrid(String strQuery)
    {
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
                    HiddenField hf2 = (HiddenField)GridView1.Rows[i]
                                    .Cells[0].FindControl("HiddenField2");
                    if (hf != null)
                    {
                        ViewState["SelectedSno"] = hf.Value;
                        ViewState["Date"] = hf2.Value;
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
                HiddenField hf2 = (HiddenField)GridView1.Rows[i]
                                    .Cells[0].FindControl("HiddenField2");

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
        if(ViewState["SelectedSno"]!=null&&ViewState["Date"]!=null)
        {
            Session["SelectedIsno"] = ViewState["SelectedSno"].ToString().Trim();
            Session["Date"] = ViewState["Date"].ToString().Trim();
            Response.Redirect("IssueSearchSlip.aspx");
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (ViewState["SelectedSno"] != null && ViewState["Date"] != null)
        {
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("issue_delete", con);
            cmd.Parameters.AddWithValue("@Isno", ViewState["SelectedSno"].ToString().Trim());
            cmd.Parameters.AddWithValue("@Date", ViewState["Date"].ToString().Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error.Check all Entries like required date pattern etc\" );", true);
            }
            con.Close();
            Response.Redirect("IssueSearch.aspx");
        }
    }
}