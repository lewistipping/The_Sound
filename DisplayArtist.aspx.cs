using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["artistID"] == null)
        {
            //lblFailure.Text = "No artist found.";
            //lblFailure.Visible = true;
            Response.Redirect("~/Home.aspx");
        }
        else if (!IsPostBack)
        {
            try
            {
                LoadArtist(Int32.Parse(Request.QueryString["artistID"]));
            }
            catch (Exception ex)
            {
                //lblFailure.Text = ex.ToString();
                //lblFailure.Visible = true;
                Response.Redirect("~/Home.aspx");
            }
        }
    }

    private void LoadArtist(int artistID)
    {
        Artist artist = Music.GetArtist(artistID);
        if (artist != null)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/" + artist.GetArtistArtPath()));
            String colourHex = getDominantColour(new Bitmap(img));

            artistart.Src = artist.GetArtistArtPath();
            artistname.InnerHtml = artist.GetArtistName();
            artistdesc.InnerHtml = artist.GetArtistDesc();
            artisttop.Attributes.CssStyle.Add("background", "linear-gradient(to bottom, " + colourHex + ", #000000)");
            artistdisplay.Visible = true;
            lblFailure.Visible = false;

            StringBuilder sb = new StringBuilder();
            DataSet ds = DataAccess.GetArtistAlbums(artistID);
            foreach (DataRow dr in ds.Tables["albumsSet"].Rows)
            {
                sb.Append("<div class=\"item\">")
                    .Append("<a href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">")
                    .Append("<img height=\"200\" width=\"200\" src=\"").Append(dr["AlbumArtPath"]).Append("\"/></a>")
                    .Append("<div class=\"titlewrapper\">")
                    .Append("<a class=\"title\" href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">").Append(dr["AlbumTitle"]).Append("</a>")
                    .Append("</div></div>");
            }
            albums.InnerHtml = sb.ToString();
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
}