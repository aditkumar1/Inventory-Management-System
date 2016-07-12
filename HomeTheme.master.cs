using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class HomeTheme : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = System.Web.Configuration.WebConfigurationManager.AppSettings["AppName"];
        Label2.Text = System.Web.Configuration.WebConfigurationManager.AppSettings["Institute"];
        Label3.Text = System.Web.Configuration.WebConfigurationManager.AppSettings["InstituteAddress"];
    }
}
