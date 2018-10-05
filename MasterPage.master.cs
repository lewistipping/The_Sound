using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CART"] != null)
        {
            UpdateCartDetails();
        }

        if (Session["USER"] != null)
        {
            hylRegister.Visible = false;
            hylSignIn.Visible = false;
            hylSignOut.Visible = true;
        }
    }

    public void UpdateCartDetails()
    {
        ArrayList arrCart = (ArrayList)Session["CART"];
        hylCart.Text = "Cart: " + arrCart.Count;
    }

    protected void lbnCart_Click(object sender, EventArgs e)
    {
        if(Session["CART"] == null)
        {
            return;
        }
        else
        {
            ArrayList arrCart = (ArrayList)Session["CART"];
            if(arrCart.Count == 0) return;
            else Response.Redirect("~/Cart.aspx");
        }
    }
}

