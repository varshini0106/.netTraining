using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ElectricityBillingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Simple admin-only login (as per requirement)
            if (txtUser.Text == "admin" && txtPass.Text == "Admin@06")
            {
                Session["AdminName"] = "admin";
                FormsAuthentication.RedirectFromLoginPage("admin", false);
            }
            else
            {
                lblMsg.Text = "Invalid login!";
            }
        }
    }
}