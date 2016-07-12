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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
            BindGrid2();
        }
        GetSelectedRecord(GridView1);
        GetSelectedRecord(GridView2);
    }
    private void BindGrid()
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        String strQuery = "select DISTINCT(PurchaseRequisition.Prno) as Prno,Depname,Requester,Designation,Convert(varchar(10),CONVERT(date,Gendate,106),103) as GenDate,Convert(varchar(10),CONVERT(date,Expdate,106),103) as Expdate,Gendate as Sortdate from PurchaseRequisition,PurchaseRequisitionTrack where PurchaseRequisition.Prno=PurchaseRequisitionTrack.Prno  and Status='Pending' and ForwardDesignation='Manager Admin' Order By Sortdate DESC";
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
    private void BindGrid2()
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        String strQuery = "select DISTINCT(PurchaseRequisition.Prno) as Prno,Depname,Requester,Designation,Convert(varchar(10),CONVERT(date,Gendate,106),103) as GenDate,Convert(varchar(10),CONVERT(date,Expdate,106),103) as Expdate,Gendate as Sortdate from PurchaseRequisition,PurchaseRequisitionTrack where PurchaseRequisitionTrack.Sno=(Select Max(Sno) from PurchaseRequisitionTrack where PurchaseRequisitionTrack.Prno=PurchaseRequisition.Prno)   and Status Like 'Approved By Director%' and ForwardDesignation='Manager Admin' Order By Sortdate DESC";
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
            GridView2.DataSource = dt;
            GridView2.DataBind();
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
    private void GetSelectedRecord(GridView Grid)
    {
        for (int i = 0; i < Grid.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)Grid.Rows[i]
                            .Cells[0].FindControl("RadioButton1");
            if (rb != null)
            {
                if (rb.Checked)
                {
                    HiddenField hf = (HiddenField)Grid.Rows[i]
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
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void OnPaging2(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        GetSelectedRecord(GridView2);
        if (ViewState["SelectedSno"] != null)
        {
            Session["SelectedSlipno"] = ViewState["SelectedSno"].ToString().Trim();
            Response.Redirect("IncomingPurchaseRequestView.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GetSelectedRecord(GridView1);
        if (ViewState["SelectedSno"] != null)
        {
            Session["SelectedSlipno"] = ViewState["SelectedSno"].ToString().Trim();
            Response.Redirect("IncomingPurchaseRequestView.aspx");
        }
    }
}