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
    String Prno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["SelectedSlipno"]!=null)
        {
            Prno = Session["SelectedSlipno"].ToString();
            SqlDataSource1.SelectCommand = "select_admin_purchase_receive";
            SqlDataSource1.SelectParameters["Prno"].DefaultValue=Session["SelectedSlipno"].ToString();
            SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            BindDirectorRemarks();    
        }
    }
    private void BindDirectorRemarks()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
        con.Open();
        try
        {
            string strQuery = "Select Apprvremarks from PurchaseRequisitionTrack where ForwardDesignation='Director' and Prno= "+ Prno;
            SqlCommand command = new SqlCommand(strQuery, con);
            SqlDataReader dr=command.ExecuteReader();
            if(dr.Read())
            {
               TextBox1.Text= dr["Apprvremarks"].ToString();
            }
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
    protected void ButtonApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            con.Open();
            string update_request = "update_admin_incoming_requisition";
            SqlCommand command = new SqlCommand(update_request, con);
            DateTime dt = DateTime.Now;
            dt.ToShortDateString();
            String format = "yyyy-MM-dd";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Prno", Prno);
            command.Parameters.AddWithValue("@Remarks", Remark2.Text);
            command.Parameters.AddWithValue("@Apprvdate", dt.ToString(format));
            command.ExecuteNonQuery();
            Label1.Text = "Approved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRequest", "alertRequest(\"This Request Has Been Approved\",\"IncomingPurchaseRequests.aspx\" );", true);
        }
        catch (Exception ex)
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertError", "alertError(\"Critical Error. Details: "+ ex.ToString()+"\" );", true);
        }
    }
    protected void ButtonDA_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
        con.Open();
        try
        {
            string update_request = "update [dbo].[PurchaseRequisitionTrack] set Status=@st where Prno=" +Prno;
            SqlCommand command = new SqlCommand(update_request, con);
            command.Parameters.AddWithValue("@st", "Declined By Manager Admin");
            command.ExecuteNonQuery();
            Label1.Text = "Dis-Approved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRequest", "alertRequest(\"This Request Has Been Dis-Approved\",\"IncomingPurchaseRequests.aspx\" );", true);
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