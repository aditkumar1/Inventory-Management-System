using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
public partial class Store_admin_IncomingIssueRequestView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["SelectedSlipno"]!=null)
        {
            SqlDataSource1.SelectCommand = "select_admin_issue_receive";
            SqlDataSource1.SelectParameters["Slipno"].DefaultValue=Session["SelectedSlipno"].ToString();
            SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        }
    }
    protected void ButtonApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            string update_request = "update [dbo].[IssueRequisition] set Status='Approved',Apprvremarks=@remarks, Apprvdate=@ad where Slipno='" + Session["SelectedSlipno"].ToString() + "'";
            SqlCommand command = new SqlCommand(update_request, con);
            DateTime dt = DateTime.Now;
            dt.ToShortDateString();
            String format = "yyyy-MM-dd";
            command.Parameters.AddWithValue("@remarks", Remark2.Text);
            command.Parameters.AddWithValue("@ad", dt.ToString(format));
            command.ExecuteNonQuery();
            Label1.Text = "Approved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRequest", "alertRequest(\"This Request Has Been Approved\",\"IncomingIssueRequests.aspx\" );", true);
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
    }
    protected void ButtonDA_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            string update_request = "update [dbo].[IssueRequisition] set Status=@st where Slipno=" + Session["SelectedSlipno"].ToString();
            SqlCommand command = new SqlCommand(update_request, con);
            command.Parameters.AddWithValue("@st", "Declined");
            command.ExecuteNonQuery();
            Label1.Text = "Dis-Approved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRequest", "alertRequest(\"This Request Has Been Dis-Approved\",\"IncomingIssueRequests.aspx\" );", true);
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
    }
}