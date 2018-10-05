using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList arrCart = (ArrayList)Session["CART"];
        foreach(CartItem cartItem in arrCart)
        {
            Label1.Text += " " + cartItem.GetAlbumID();
        }
    }
}