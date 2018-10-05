using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_ThankYou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PURCHASE"] == null)
        {
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            CleanUpSale();
        }
    }

    private void CleanUpSale()
    {
        ((ArrayList)Session["CART"]).Clear();
        Session["CART"] = null;
        Session["PURCHASE"] = null;
    }
}