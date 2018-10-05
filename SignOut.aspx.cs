using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

// This page has been created with the sole intent of signing the user out of their account. Previously,
// LinkButtons were used to represent the Sign In/Out links, but these were causing the RequiredFieldValidators
// to fire on pages containing that type of validator (e.g. Register.aspx), preventing the buttons' OnClick methods
// from running. The buttons were changed to Hyperlinks and the Sign Out link, when visible, sends the user here.
// The user sees no content whether they come here via the Hyperlink or type the link themselves. Either way,
// they are transferred back to the homepage, the only difference being that, if they had Sessions, they will
// be cleared. For this reason, no storyboard has been provided for this page.
public partial class SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("~/Home.aspx");
    }
}