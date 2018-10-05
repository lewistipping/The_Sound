using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SecureAdmin_EditWeeklyExclusive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadExclusive();
        }
    }

    private void LoadExclusive()
    {
        DataSet exclusiveSet = Music.GetExclusiveDetails();
        DataTable exclusiveTable = exclusiveSet.Tables[0];
        txtArtistName.Text = exclusiveTable.Rows[0]["ArtistName"].ToString();
        txtArtistCountry.Text = exclusiveTable.Rows[0]["ArtistCountry"].ToString();
        txtDescription.Text = exclusiveTable.Rows[0]["ArtistDescription"].ToString();
        txtTrack.Text = exclusiveTable.Rows[0]["TrackTitle"].ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        String artistName = txtArtistName.Text;
        String artistCountry = txtArtistCountry.Text;
        String description = txtDescription.Text;

        if (fulBanner.HasFile)
        {
            String bannerFilePath = "/Files/Exclusive/exclusivebanner.jpg";
            fulBanner.SaveAs(Server.MapPath("~") + bannerFilePath);
        }

        if (fulArtistImage.HasFile)
        {
            String artistFilePath = "/Files/Exclusive/exclusiveartist.jpg";
            fulArtistImage.SaveAs(Server.MapPath("~") + artistFilePath);
        }

        String trackTitle = txtTrack.Text;
        String trackFilePath = null;

        if (fulTrack.HasFile)
        {
            trackFilePath = "/Files/Exclusive/" + fulTrack.FileName;
            fulTrack.SaveAs(Server.MapPath("~") + trackFilePath);
        }

        if (fulUploadCover.HasFile)
        {
            MakeTiles();
        }

        Music.UpdateExclusive(artistName, description, artistCountry, trackTitle, trackFilePath);
        Response.Redirect("~/Secure/TheSoundExclusive.aspx");
    }

    private void MakeTiles()
    {
        File.Delete(Server.MapPath("~/Files/Exclusive/Puzzle/cover.jpg"));
        fulUploadCover.SaveAs(Server.MapPath("~/Files/Exclusive/Puzzle/cover.jpg"));

        Bitmap[,] tiles = new Bitmap[3, 3];
        Bitmap original = new Bitmap(Server.MapPath("~/Files/Exclusive/Puzzle/cover.jpg"));
        int widthThird = (int)((double)original.Width / 3.0 + 0.5);
        int heightThird = (int)((double)original.Height / 3.0 + 0.5);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tiles[i, j] = new Bitmap(widthThird, heightThird);
                Graphics g = Graphics.FromImage(tiles[i, j]);
                g.DrawImage(original, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                g.Dispose();
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Bitmap tile = tiles[i, j];
                String filename = "img" + i + j + ".jpg";
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(Server.MapPath("~/Files/Exclusive/Puzzle/" + filename), FileMode.Create, FileAccess.ReadWrite))
                    {
                        tile.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}