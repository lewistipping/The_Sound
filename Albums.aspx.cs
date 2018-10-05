using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAlbums();
    }

    private void LoadAlbums()
    {
        DataSet albumsSet = Music.GetAlbums();
        pnlAlbums.Controls.Clear();
        Table tblAlbums = new Table();
        tblAlbums.CssClass = "table";

        foreach(DataRow dr in albumsSet.Tables["albumsSet"].Rows)
        {
            TableRow tr = new TableRow();
            tr.CssClass = "table-row";

            TableCell tc1 = new TableCell();
            tc1.CssClass = "acell";
            Image albumImage = new Image();
            albumImage.ImageUrl = "~/" + dr["AlbumArtPath"].ToString();
            tc1.Controls.Add(albumImage);
            tr.Cells.Add(tc1);

            TableCell tc2 = new TableCell();
            tc2.CssClass = "acell";
            HyperLink hylAlbum = new HyperLink();
            hylAlbum.Text = dr["AlbumTitle"].ToString();
            hylAlbum.NavigateUrl = "~/DisplayAlbum.aspx?albumID=" + dr["AlbumID"].ToString();
            tc2.Controls.Add(hylAlbum);
            LiteralControl lc = new LiteralControl("<br/><span style=\"font-size:medium;\">by </span>");
            tc2.Controls.Add(lc);
            HyperLink hylArtist = new HyperLink();
            hylArtist.CssClass = "albumtagline";
            hylArtist.Text = dr["ArtistName"].ToString().ToUpper();
            hylArtist.NavigateUrl = "~/DisplayArtist.aspx?artistID=" + dr["ArtistID"].ToString();
            tc2.Controls.Add(hylArtist);
            tr.Cells.Add(tc2);

            tblAlbums.Rows.Add(tr);
        }

        pnlAlbums.Controls.Add(tblAlbums);
    }
}