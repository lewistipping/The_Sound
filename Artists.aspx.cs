using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Artists : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadArtists();
    }

    private void LoadArtists()
    {
        DataSet artistsSet = Music.GetArtists();
        pnlArtists.Controls.Clear();
        Table tblArtists = new Table();
        tblArtists.CssClass = "table";

        foreach(DataRow dr in artistsSet.Tables["artistsSet"].Rows)
        {
            TableRow tr = new TableRow();
            tr.CssClass = "table-row";

            TableCell tc1 = new TableCell();
            tc1.CssClass = "acell";
            Image artistImage = new Image();
            artistImage.ImageUrl = "~/" + dr["ArtistArtPath"].ToString();
            tc1.Controls.Add(artistImage);
            tr.Cells.Add(tc1);

            TableCell tc2 = new TableCell();
            tc2.CssClass = "acell";
            HyperLink hylArtist = new HyperLink();
            hylArtist.Text = dr["ArtistName"].ToString();
            hylArtist.NavigateUrl = "~/DisplayArtist.aspx?artistID=" + dr["ArtistID"].ToString();
            tc2.Controls.Add(hylArtist);
            tr.Cells.Add(tc2);

            tblArtists.Rows.Add(tr);
        }

        pnlArtists.Controls.Add(tblArtists);

    }
}