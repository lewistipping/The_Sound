using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SecureAdmin_EditArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int artistID = 0;

        try
        {
            artistID = Convert.ToInt32(txtSearch.Text);
        }
        catch(Exception ex)
        {
            lblSearchError.Text = "ID must be an integer.";
            return;
        }

        Artist artist = Music.GetArtist(artistID);

        if(artist != null)
        {
            lblSearchError.Text = "";
            imgNewImage.ImageUrl = "~" + artist.GetArtistArtPath();
            imgNewImage.Visible = true;

            lblEditing.Text = "Editing \"" + artist.GetArtistName() + "\"";
            
            fulNewImage.Enabled = true;

            txtDescription.Text = artist.GetArtistDesc();
            txtDescription.Enabled = true;

            btnUpdate.Enabled = true;
            rfvDescription.Enabled = true;

            Session["EDITARTIST"] = artist;
        }
        else
        {
            lblSearchError.Text = "Artist not found.";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Artist artist = (Artist)Session["EDITARTIST"];

        if (fulNewImage.HasFile)
        {
            String filePath = "/Files/Images/Artists/" + artist.GetArtistName() + "/" + fulNewImage.FileName;
            fulNewImage.SaveAs(Server.MapPath("~") + filePath);
            artist.SetArtistArtPath(filePath);
        }

        artist.SetArtistDesc(txtDescription.Text);
        Music.UpdateArtist(artist);
        Response.Redirect("~/DisplayArtist.aspx?artistID=" + artist.GetArtistID());
    }
}