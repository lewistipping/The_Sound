using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CART"] == null) Response.Redirect("Home.aspx");
        else DisplayDetails();
    }

    private void DisplayDetails()
    {
        if (Session["CART"] == null) Response.Redirect("~/Home.aspx");
        ArrayList arrCart = (ArrayList)Session["CART"];
        if (arrCart.Count == 0) Response.Redirect("~/Home.aspx");

        double totalCost = 0.0;

        pnlCartDetails.Controls.Clear();

        Table tblCartDetails = new Table();
        tblCartDetails.CssClass = "table";

        for(int loop = 0; loop < arrCart.Count; loop++)
        {
            CartItem cartItem = (CartItem)arrCart[loop];

            TableRow tr = new TableRow();
            tr.CssClass = "table-row";

            TableCell tc1 = new TableCell();
            tc1.CssClass = "table-cell";
            Image albumArt = new Image();
            albumArt.ImageUrl = "~/" + cartItem.GetAlbumArtPath();
            tc1.Controls.Add(albumArt);
            tr.Cells.Add(tc1);

            TableCell tc2 = new TableCell();
            tc2.CssClass = "table-cell";
            Label albumName = new Label();
            albumName.Text = cartItem.GetAlbumName();
            tc2.Controls.Add(albumName);
            tr.Cells.Add(tc2);

            TableCell tc3 = new TableCell();
            tc3.CssClass = "table-cell";
            Label price = new Label();
            price.Text = "£" + String.Format("{0:0.00}", cartItem.GetPrice());
            tc3.Controls.Add(price);
            tr.Cells.Add(tc3);

            TableCell tc4 = new TableCell();
            tc4.CssClass = "table-cell";
            Button btnRemove = new Button();
            btnRemove.ID = loop.ToString();
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;
            tc4.Controls.Add(btnRemove);
            tr.Cells.Add(tc4);

            tblCartDetails.Rows.Add(tr);
            totalCost += cartItem.GetPrice();          
        }

        pnlCartDetails.Controls.Add(tblCartDetails);
        lblCost.Text = "Total cost: £" + String.Format("{0:0.00}", totalCost);
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        Button btnRemove = (Button)sender;
        ArrayList arrCart = (ArrayList)Session["CART"];
        int cartIndex = Convert.ToInt32(btnRemove.ID);

        arrCart.RemoveAt(cartIndex);
        (this.Master as MasterPage).UpdateCartDetails();

        if (arrCart.Count == 0) Response.Redirect("~/Home.aspx");
        else DisplayDetails();
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Secure/Payment.aspx");
    }

    protected void btnRemoveAll_Click(object sender, EventArgs e)
    {
        ArrayList arrCart = (ArrayList)Session["CART"];
        arrCart.Clear();
        Session["CART"] = null;
        DisplayDetails();
    }
}