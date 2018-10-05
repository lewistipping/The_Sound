using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_TheSoundExclusive : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USER"] == null)
        {
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            LoadExclusiveDetails();
        }
    }

    private void LoadExclusiveDetails()
    {
        DataSet exclusiveSet = Music.GetExclusiveDetails();
        DataTable exclusiveTable = exclusiveSet.Tables["exclusiveSet"];
        exclusivetitle.InnerHtml = "This Week's Exclusive: \"" + exclusiveTable.Rows[0]["TrackTitle"].ToString() 
            + "\" by " + exclusiveTable.Rows[0]["ArtistName"].ToString();
        lblExclusiveArtist.Text = exclusiveTable.Rows[0]["ArtistName"].ToString();
        lblExclusiveCountry.Text = exclusiveTable.Rows[0]["ArtistCountry"].ToString();
        lblExclusiveDesc.Text = exclusiveTable.Rows[0]["ArtistDescription"].ToString();
    }

    [WebMethod]
    public static string GetSong()
    {
        return ".." + Music.GetExclusiveSong();
    }
}