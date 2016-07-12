using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class UserMain : System.Web.UI.Page
{
    String Userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindField();
    }
    protected void BindField()
    {
        Userid=User.Identity.Name.ToString();
        if(!Userid.Equals(""))
        {
            Label1.Text = Userid;
            string strQuery = "select * from UserDetailsMain where Userid='"+Userid+"'";
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strQuery, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Label2.Text = dr["Username"].ToString();
                    Label3.Text = dr["Depname"].ToString();
                    Label4.Text = dr["Designation"].ToString();
                    Label5.Text = dr["Role"].ToString();
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
}