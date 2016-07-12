using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class Store_user_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label4.Visible = true;
        if(IsValidPassword(TextBox1.Text))
        {
            if(TextBox2.Text.Trim().Equals(TextBox3.Text.Trim()))
            {
                if(changePassword(Request.Form[TextBox2.UniqueID]))
                {
                    Label4.Text = "Password Successfully Changed";
                }
                else
                {
                    Label4.Text = "Password Not Changed.Please Retry";
                }
            }
            else
            {
                Label4.Text = "Password Do not Match";
            }
        }
        else
        {
            Label4.Text = "Invalid Old Password";
        }
    }
    protected Boolean changePassword(String Password)
    {
        String Userid = User.Identity.Name.ToString();
        if (!Userid.Equals("")&&!Password.Equals(""))
        {
            string strQuery = "update UserDetailsMain set Password='"+Password+"' where Userid='" + Userid + "'";
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd=new SqlCommand(strQuery,con);
            con.Open();
            try
            {
                if (cmd.ExecuteNonQuery() >= 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
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
        return false;
    }
    protected Boolean IsValidPassword(String Password)
    {
        String Userid = User.Identity.Name.ToString();
        String OldPassword="";
        if (!Userid.Equals(""))
        {
            string strQuery = "select Password from UserDetailsMain where Userid='" + Userid + "'";
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strQuery, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    OldPassword = dr["Password"].ToString();
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
        if(OldPassword.Equals(Password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
}