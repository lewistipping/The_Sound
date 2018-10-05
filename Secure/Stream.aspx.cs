using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_Stream : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["STREAM"] == null)
        {
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            int albumID = Convert.ToInt32(Session["STREAM"]);
            LoadAlbum(albumID);
        }
    }

    private void LoadAlbum(int albumID)
    {
        Album album = Music.GetAlbum(albumID);
        imgStream.ImageUrl = "~" + album.GetAlbumArtPath();
        lblAlbum.Text = album.GetAlbumTitle();
        lblArtist.Text = "by " + album.GetArtistName();

        StringBuilder sb = new StringBuilder();
        List<Song> songs = album.GetSongs();

        for(int i = 0; i < songs.Count; i++)
        {
            Song song = songs[i];
            if(i == 0)
            {
                sb.Append("<li class=\"active\"><a href=\"..").Append(song.getFilePath()).Append("\">").Append(song.getTitle()).Append("</a></li>\n");
            }
            else
            {
                sb.Append("<li><a href=\"..").Append(song.getFilePath()).Append("\">").Append(song.getTitle()).Append("</a></li>\n");
            }
        }
        audiosrc.Src = album.GetSongs()[0].getFilePath();
        playlist.InnerHtml = sb.ToString();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Secure/MyAccount.aspx");
    }
}