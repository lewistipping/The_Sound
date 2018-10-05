using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USER"] != null)
        {
            if (Session["ADMIN"] != null)
            {
                Response.Redirect("~/SecureAdmin/AdminHome.aspx");
                return;
            }
            LoadUser();
        }
        else
        {
            Response.Redirect("~/SignIn.aspx");
        }
    }

    private void LoadUser()
    {
        User user = (User)Session["USER"];
        lblAccount.Text = "Your account, " + user.GetUsername();

        pnlPurchased.Controls.Clear();
        Table tblPurchased = new Table();
        tblPurchased.CssClass = "table";

        DataSet purchasedSet = Users.GetPurchasedAlbums(user.GetUserID());
        if (purchasedSet.Tables["purchasedSet"].Rows.Count == 0)
        {
            lblEmpty.Visible = true;
            pnlPurchased.Controls.Add(lblEmpty);
        }
        else
        {
            foreach (DataRow dr in purchasedSet.Tables["purchasedSet"].Rows)
            {
                TableRow tr = new TableRow();
                tr.CssClass = "table-row";

                TableCell tc1 = new TableCell();
                tc1.CssClass = "table-cell";
                Label receipt = new Label();
                receipt.Text = "Receipt ID: " + dr["ReceiptID"].ToString();
                tc1.Controls.Add(receipt);
                tr.Cells.Add(tc1);

                TableCell tc2 = new TableCell();
                tc2.CssClass = "table-cell";
                Image albumArt = new Image();
                albumArt.ImageUrl = "~/" + dr["AlbumArtPath"];
                tc2.Controls.Add(albumArt);
                tr.Controls.Add(tc2);

                TableCell tc3 = new TableCell();
                tc3.CssClass = "table-cell";
                Label albumInfo = new Label();
                albumInfo.Text = dr["AlbumTitle"].ToString();
                tc3.Controls.Add(albumInfo);
                LiteralControl lc = new LiteralControl("<br/><span style=\"font-size:medium;\">by </span>");
                tc3.Controls.Add(lc);
                HyperLink hylArtist = new HyperLink();
                hylArtist.CssClass = "albumtagline";
                hylArtist.Text = dr["ArtistName"].ToString().ToUpper();
                hylArtist.NavigateUrl = "~/DisplayArtist.aspx?artistID=" + dr["ArtistID"].ToString();
                tc3.Controls.Add(hylArtist);
                tr.Controls.Add(tc3);

                TableCell tc4 = new TableCell();
                tc4.CssClass = "table-cell";
                Button btnStream = new Button();
                btnStream.Text = "Stream";
                btnStream.ID = dr["AlbumID"].ToString();
                btnStream.Click += StreamNow;
                tc4.Controls.Add(btnStream);
                tr.Controls.Add(tc4);

                tblPurchased.Controls.Add(tr);
            }

            pnlPurchased.Controls.Add(tblPurchased);
        }
    }

    private void StreamNow(object sender, EventArgs e)
    {
        Session["STREAM"] = ((Button)sender).ID;
        Response.Redirect("~/Secure/Stream.aspx");
    }
}