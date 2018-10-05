using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_EditAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserDetails();
        }
        
    }

    private void LoadUserDetails()
    {
        User user = (User)Session["USER"];
        txtUsername.Text = user.GetUsername();
        txtForename.Text = user.GetForename();
        txtSurname.Text = user.GetSurname();
        txtEmail.Text = user.GetEmailAddress();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        User user = (User)Session["USER"];
        user.SetForename(txtForename.Text);
        user.SetSurname(txtSurname.Text);
        user.SetEmailAddress(txtEmail.Text);
        String password = null;
        if (txtPassword.Text.Trim().Length > 0) password = txtPassword.Text;

        Users.UpdateUser(user, password);
    }
}