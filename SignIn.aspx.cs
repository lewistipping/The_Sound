using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USER"] != null)
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        String username = txtUsernameSignIn.Text;
        String password = txtPasswordSignIn.Text;
        User user = Users.VerifySignIn(username, password);
        if (user != null)
        {
            Session["USER"] = user;
            if (user.GetUsername().Equals("soundadmin")) Session["ADMIN"] = user;

            FormsAuthentication.RedirectFromLoginPage(user.GetUsername(), true);
        }
        else
        {
            lblSignInError.Text = "Invalid details.";
        }
    }
}