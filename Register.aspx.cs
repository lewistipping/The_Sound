using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    User user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null)
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        String username = txtUsernameRegister.Text;
        String forename = txtForename.Text;
        String surname = txtSurname.Text;
        String emailAddress = txtEmail.Text;
        String password = txtPasswordRegister.Text;
        Boolean isDuplicateUsername = Users.CheckDuplicateUsername(username);
        Boolean isDuplicateEmailAddress = Users.CheckDuplicateEmailAddress(emailAddress);

        if (isDuplicateUsername && isDuplicateEmailAddress)
        {
            lblStatus.Attributes.CssStyle.Add("color", "crimson");
            lblStatus.Text = "Username and email address already registered.";
        }
        else if (isDuplicateUsername)
        {
            lblStatus.Attributes.CssStyle.Add("color", "crimson");
            lblStatus.Text = "Username already registered.";
        }
        else if (isDuplicateEmailAddress)
        {
            lblStatus.Attributes.CssStyle.Add("color", "crimson");
            lblStatus.Text = "Email address already registered.";
        }
        else
        {
            user = Users.RegisterUser(username, forename, surname, emailAddress, password);
            Session["USER"] = user;
            lblStatus.Attributes.CssStyle.Add("color", "darkgreen");
            lblStatus.Text = "Account registered! You will be taken to your account in 2 seconds.";
            FormsAuthentication.SetAuthCookie(user.GetUsername(), true);
            Response.AddHeader("REFRESH", "2;URL=/Secure/MyAccount.aspx");
        }
    }
}