using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!this.IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean Auth = false;
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;//"Server=SANGEETA-PC\\SQLEXPRESS;initial catalog=store;integrated security=yes;";
        String role = "";
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Userid,Password,Role from UserDetailsMain", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (dr["Userid"].ToString().Equals(TextBox1.Text) && dr["Password"].ToString().Equals(TextBox2.Text))
            {
                role = dr["Role"].ToString().Trim();
                Auth=true;
                break;
            }
        }
        con.Close();
        con.Dispose();
        if(Auth&&!role.Equals(""))
        {
            Authenticate(role);
        }
        else
        {
            Label1.Visible = true;
        }
    }
    private void Authenticate(String role)
    {
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, TextBox1.Text, DateTime.Now, DateTime.Now.AddHours(6), true, role, FormsAuthentication.FormsCookiePath);
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
        if (ticket.IsPersistent)
        {
            cookie.Expires = ticket.Expiration;
        }
        Response.Cookies.Add(cookie);
        string returnUrl = Request.QueryString["ReturnUrl"] as string;
        if (returnUrl != null)
        {
            Response.Redirect(returnUrl);
        }
        else
        {
            if(role.Equals("Admin"))
            {
                Response.Redirect("~/store/admin/UserMain.aspx");
            }
            else if(role.Equals("Finance Office"))
            {
                Response.Redirect("~/store/finance/UserMain.aspx");
            }
            else if(role.Equals("Store User"))
            {
                Response.Redirect("~/store/user/UserMain.aspx");
            }
            else if (role.Equals("HoD"))
            {
                Response.Redirect("~/store/Hod/UserMain.aspx");
            }
            else if (role.Equals("Director"))
            {
                Response.Redirect("~/store/director/UserMain.aspx");
            }
            else if (role.Equals("Purchase Office"))
            {
                Response.Redirect("~/store/purchase/UserMain.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}