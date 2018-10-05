using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SecureAdmin_EditAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int albumID = 0;

        try
        {
            albumID = Convert.ToInt32(txtSearch.Text);
        }
        catch (Exception ex)
        {
            lblSearchError.Text = "ID must be an integer.";
            return;
        }

        Album album = Music.GetAlbum(albumID);

        if (album != null)
        {
            lblSearchError.Text = "";
            imgNewImage.ImageUrl = "~" + album.GetAlbumArtPath();
            imgNewImage.Visible = true;

            lblEditing.Text = "Editing \"" + album.GetAlbumTitle() + "\"";

            fulNewImage.Enabled = true;

            txtNewPrice.Text = album.GetAlbumPrice().ToString();
            txtNewPrice.Enabled = true;

            btnUpdate.Enabled = true;

            Session["EDITALBUM"] = album;
        }
        else
        {
            lblSearchError.Text = "Album not found.";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Album album = (Album)Session["EDITALBUM"];

        try
        {
            double newPrice = Convert.ToDouble(txtNewPrice.Text.Trim());
            album.SetAlbumPrice(newPrice);
        }
        catch (Exception ex)
        {
            lblNewPriceError.Text = "Price must be numeric.";
            lblNewPriceError.Visible = true;
            return;
        }

        if (fulNewImage.HasFile)
        {
            String filePath = "/Files/Images/Albums/" + album.GetArtistName() + "/" + fulNewImage.FileName;
            fulNewImage.SaveAs(Server.MapPath("~") + filePath);
            album.SetAlbumArtPath(filePath);
        }

        Music.UpdateAlbum(album);
        Response.Redirect("~/DisplayAlbum.aspx?albumID=" + album.GetAlbumID());
    }
}