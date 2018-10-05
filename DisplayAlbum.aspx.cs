using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayAlbum : System.Web.UI.Page
{
    Album album;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["albumID"] == null)
        {
            Response.Redirect("~/Home.aspx");
        }
        else if (!IsPostBack)
        {
            try
            {
                LoadAlbum(Int32.Parse(Request.QueryString["albumID"]));
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        if (Session["CART"] == null)
        {
            ArrayList arrCart = new ArrayList();
            Session["CART"] = arrCart;
        }
        else
        {
            (this.Master as MasterPage).UpdateCartDetails();
        }

        if (CheckAlbumInCart())
        {
            btnBuy.Text = "In cart";
            btnBuy.CssClass = "disabledbutton";
            btnBuy.Enabled = false;
        }
        else if(Session["ADMIN"] != null)
        {
            btnBuy.Text = "Disabled - Admin Viewing";
            btnBuy.CssClass = "disabledbutton";
            btnBuy.Enabled = false;
        }
    }

    private void LoadAlbum(int albumID)
    {
        album = Music.GetAlbum(albumID);

        if (album != null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Song song in album.GetSongs())
            {
                sb.Append("<li><p>").Append(song.getTitle()).Append("</p>")
                    .Append("<div oncontextmenu =\"return false\"><audio controls controlsList=\"nodownload\">\n")
                    .Append("<source src=\"").Append(song.getFilePath()).Append("\" type=\"audio/mpeg\">")
                    .Append("Your browser does not support the audio element.</audio>").Append("</div></li>\n");
            }
            songlist.InnerHtml = sb.ToString();

            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/" + album.GetAlbumArtPath()));
            String colourHex = getDominantColour(new Bitmap(img));

            albumtitle.InnerHtml = album.GetAlbumTitle() + " | <a href=\"DisplayArtist.aspx?artistID=" + album.GetArtistID() + "\">"
                                    + album.GetArtistName() + "</a>";
            albumart.Src = album.GetAlbumArtPath();
            albumtop.Attributes.CssStyle.Add("background", "linear-gradient(to bottom, " + colourHex + ", #000000)");
            btnBuy.Text = "£" + String.Format("{0:0.00}", album.GetAlbumPrice()) + " - Add To Cart";
            albumdisplay.Visible = true;

            Page.Title = "The Sound - View Album - " + album.GetArtistName() + ": " + album.GetAlbumTitle();
            Session["CURRENT"] = album;
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    private static String getDominantColour(Bitmap img)
    {
        //Used for tally
        int r = 0;
        int g = 0;
        int b = 0;

        int total = 0;

        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                Color clr = img.GetPixel(x, y);

                r += clr.R;
                g += clr.G;
                b += clr.B;

                total++;
            }
        }

        //Calculate average
        r /= total;
        g /= total;
        b /= total;

        Color color = Color.FromArgb(r, g, b);
        return String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        if (CheckAlbumInCart()) return;

        Album buyAlbum = (Album)Session["CURRENT"];
        CartItem cartItem = new CartItem(buyAlbum.GetAlbumID(), buyAlbum.GetAlbumTitle(), buyAlbum.GetAlbumArtPath(),
            buyAlbum.GetArtistID(), buyAlbum.GetArtistName(), buyAlbum.GetAlbumPrice());

        ArrayList arrCart = (ArrayList)Session["CART"];
        arrCart.Add(cartItem);
        (this.Master as MasterPage).UpdateCartDetails();

        btnBuy.Text = "In cart";
        btnBuy.CssClass = "disabledbutton";
        btnBuy.Enabled = false;
    }

    private Boolean CheckAlbumInCart()
    {
        Album album = (Album)Session["CURRENT"];
        ArrayList arrCart = (ArrayList)Session["CART"];
        foreach(CartItem cartItem in arrCart)
        {
            if (cartItem.GetAlbumID() == album.GetAlbumID()) return true;
        }
        return false;
    }
}