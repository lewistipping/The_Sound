using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNewAlbums();
        LoadTopAlbums();
    }

    private void LoadNewAlbums()
    {
        DataSet ds = Music.GetNewAlbums();
        StringBuilder sb = new StringBuilder();

        foreach (DataRow dr in ds.Tables["albumsSet"].Rows)
        {
            sb.Append("<div class=\"item\">")
                .Append("<a href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">")
                .Append("<img height=\"200\" width=\"200\" src=\"").Append(dr["AlbumArtPath"]).Append("\"/></a>")
                .Append("<div class=\"titlewrapper\">")
                .Append("<a class=\"title\" href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">").Append(dr["AlbumTitle"]).Append("</a>")
                .Append("</div></div>");
        }
        newalbums.InnerHtml = sb.ToString();
    }

    private void LoadTopAlbums()
    {
        DataSet ds = Music.GetTopAlbums();
        StringBuilder sb = new StringBuilder();

        foreach (DataRow dr in ds.Tables["topSet"].Rows)
        {
            sb.Append("<div class=\"item\">")
                .Append("<a href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">")
                .Append("<img height=\"200\" width=\"200\" src=\"").Append(dr["AlbumArtPath"]).Append("\"/></a>")
                .Append("<div class=\"titlewrapper\">")
                .Append("<a class=\"title\" href=\"/DisplayAlbum.aspx?albumID=").Append(dr["AlbumID"]).Append("\">").Append(dr["AlbumTitle"]).Append("</a>")
                .Append("</div></div>");
        }
        popular.InnerHtml = sb.ToString();
    }

    protected void btnRandom_Click(object sender, EventArgs e)
    {
        LoadRandomSong();
    }

    protected void btnAnother_Click(object sender, EventArgs e)
    {
        LoadRandomSong();
    }

    private void LoadRandomSong()
    {
        DataSet randomSong = Music.GetRandomSong();
        DataRow songRow = randomSong.Tables["randomSet"].Rows[0];

        randomalbumart.Src = songRow["AlbumArtPath"].ToString();

        randomsong.InnerHtml = "\"" + songRow["TrackTitle"].ToString()
            + "\" from <a id=\"randomalbum\" href=\"/DisplayAlbum.aspx?albumID="
            + songRow["AlbumID"].ToString() 
            + "\">"
            + songRow["AlbumTitle"].ToString()
            + "</a>";

        randomartist.InnerHtml = "by "
            + "<a href=\"/DisplayArtist.aspx?artistID="
            + songRow["ArtistID"].ToString()
            + "\">"
            + songRow["ArtistName"].ToString().ToUpper()
            + "</a>";

        randomplayersource.Src = songRow["TrackFilePath"].ToString();
        btnAnother.Text = "Try another ";

        randomone.Visible = false;
        randomtwo.Visible = true;
    }
}