using System;
using System.Collections.Generic;
using System.Web;
using System.Data.OleDb;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using System.Globalization;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{

    public DataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static OleDbConnection OpenConnection()
    {
        String configPath = "~";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
        String conStr = null;
        OleDbConnection conn = null;

        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            try
            {
                conStr = rootWebConfig.ConnectionStrings.ConnectionStrings["MUSIC"].ToString();
            }
            catch (Exception e)
            {
                conStr = null;
            }

            if (conStr != null)
            {
                conn = new OleDbConnection(conStr);
                conn.Open();
                HttpContext.Current.Trace.Warn("Connection opened.");
            }
            else
            {
                HttpContext.Current.Trace.Warn("Connection is not available.");
            }
        }
        return conn;
    }

    private static void CloseConnection(OleDbConnection conn)
    {
        conn.Close();
    }

    public static String GetTrackPath()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT FilePath FROM Test WHERE ID = 1";
        String trackPath = null;

        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                trackPath = reader["FilePath"].ToString();
            }
            reader.Close();
        }
        catch (Exception e)
        {
            HttpContext.Current.Trace.Warn(e.StackTrace);
        }

        CloseConnection(conn);
        return trackPath;
    }

    public static List<List<String>> GetTrackPaths()
    {
        List<List<String>> trackPaths = new List<List<String>>();
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT TrackTitle, FilePath FROM Test WHERE ArtistID = 1";

        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<String> track = new List<String>();
                track.Add(reader["TrackTitle"].ToString());
                track.Add(reader["FilePath"].ToString());
                trackPaths.Add(track);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            HttpContext.Current.Trace.Warn(e.StackTrace);
        }

        CloseConnection(conn);
        return trackPaths;
    }

    public static List<Song> GetSongs()
    {
        List<Song> songList = new List<Song>();
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT TrackTitle, FilePath FROM Test WHERE ArtistID = 1";

        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Song song = new Song();
                song.setTitle(reader["TrackTitle"].ToString());
                song.setFilePath(reader["FilePath"].ToString());
                songList.Add(song);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            HttpContext.Current.Trace.Warn(e.StackTrace);
        }
        CloseConnection(conn);
        return songList;
    }

    public static Album GetAlbum(int albumID)
    {
        Album album = null;
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT tblAlbum.ArtistID, ArtistName, AlbumTitle, AlbumArtPath, AlbumPrice,TrackTitle, TrackNo, TrackFilePath FROM "
            + "(tblAlbum INNER JOIN tblSong ON tblSong.AlbumID = tblAlbum.AlbumID) INNER JOIN tblArtist ON tblArtist.ArtistID = tblAlbum.ArtistID "
            + "WHERE tblAlbum.AlbumID = " + albumID + " ORDER BY TrackNo ASC;";

        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count != 0)
            {
                album = new Album();
                album.SetAlbumID(albumID);
                album.SetAlbumTitle(dataTable.Rows[0]["AlbumTitle"].ToString());
                album.SetAlbumArtPath(dataTable.Rows[0]["AlbumArtPath"].ToString());
                album.SetArtistID(Convert.ToInt32(dataTable.Rows[0]["ArtistID"]));
                album.SetArtistName(dataTable.Rows[0]["ArtistName"].ToString());
                album.SetAlbumPrice(Convert.ToDouble(dataTable.Rows[0]["AlbumPrice"]));

                foreach(DataRow row in dataTable.Rows)
                {
                    Song song = new Song();
                    song.setTitle(row["TrackTitle"].ToString());
                    song.setFilePath(row["TrackFilePath"].ToString());
                    album.AddSongs(song);
                }

            }
        }
        catch (Exception e)
        {
            HttpContext.Current.Trace.Warn(e.StackTrace);
        }
        CloseConnection(conn);
        return album;
    }

    public static DataSet GetArtistAlbums(int artistID)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT AlbumID, AlbumTitle, AlbumArtPath, AlbumReleaseDate FROM tblAlbum WHERE ArtistID = " + artistID + ";";

        DataSet artistAlbums = new DataSet();
        OleDbDataAdapter albumsAdapter = new OleDbDataAdapter(strSQL, conn);
        albumsAdapter.Fill(artistAlbums, "albumsSet");
        CloseConnection(conn);
        return artistAlbums;
    }

    public static Artist GetArtist(int artistID)
    {
        Artist artist = null;
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT tblArtist.ArtistID, ArtistName, ArtistArtPath, ArtistDescription, AlbumID, AlbumTitle, AlbumArtPath FROM tblArtist INNER JOIN tblAlbum ON tblAlbum.ArtistID = tblArtist.ArtistID "
            + "WHERE tblArtist.ArtistID = " + artistID + " ORDER BY tblAlbum.AlbumReleaseDate DESC;";

        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count != 0)
            {
                artist = new Artist();
                artist.SetArtistID(Convert.ToInt32(dataTable.Rows[0]["ArtistID"].ToString()));
                artist.SetArtistName(dataTable.Rows[0]["ArtistName"].ToString());
                artist.SetArtistArtPath(dataTable.Rows[0]["ArtistArtPath"].ToString());
                artist.SetArtistDesc(dataTable.Rows[0]["ArtistDescription"].ToString());

            }
        }
        catch (Exception e)
        {
            HttpContext.Current.Trace.Warn(e.StackTrace);
        }
        CloseConnection(conn);
        return artist;
    }

    public static DataSet GetNewAlbums()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT TOP 5 AlbumID, AlbumTitle, AlbumArtPath, AlbumReleaseDate FROM tblAlbum ORDER BY AlbumID DESC";

        DataSet newAlbums = new DataSet();
        OleDbDataAdapter albumsAdapter = new OleDbDataAdapter(strSQL, conn);
        albumsAdapter.Fill(newAlbums, "albumsSet");
        CloseConnection(conn);
        return newAlbums;
    }

    public static DataSet GetTopAlbums()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT TOP 5 tblAlbum.AlbumID, tblAlbum.AlbumTitle, tblAlbum.AlbumArtPath "
                        + "FROM(tblAlbum INNER JOIN tblAlbumSale ON tblAlbum.AlbumID = tblAlbumSale.AlbumID) "
                        + "INNER JOIN tblSale ON tblSale.ReceiptID = tblAlbumSale.ReceiptID WHERE tblSale.SaleDate >= DATEADD('d', -7, DATE()) "
                        + "GROUP BY tblAlbum.AlbumID, tblAlbum.AlbumTitle, tblAlbum.AlbumArtPath ORDER BY COUNT(tblAlbumSale.AlbumID) DESC, tblAlbum.AlbumID DESC;";

        DataSet topAlbums = new DataSet();
        OleDbDataAdapter albumsAdapter = new OleDbDataAdapter(strSQL, conn);
        albumsAdapter.Fill(topAlbums, "topSet");
        CloseConnection(conn);
        return topAlbums;
    }

    public static DataSet GetRandomSong()
    {
        OleDbConnection conn = OpenConnection();
        Random random = new Random((int)DateTime.Now.Ticks);

        String getLastID = "SELECT TOP 1 TrackID FROM tblSong ORDER BY TrackID DESC";
        OleDbCommand cmd = new OleDbCommand(getLastID, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        reader.Read();
        int lastID = Convert.ToInt32(reader["TrackID"]);
        int randomID = random.Next(1, lastID);

        String strSQL = "SELECT TOP 1 TrackID, TrackTitle, TrackFilePath, tblAlbum.AlbumID, tblAlbum.AlbumTitle, tblAlbum.AlbumArtPath, "
            + "tblArtist.ArtistID, tblArtist.ArtistName FROM (tblSONG INNER JOIN tblAlbum ON tblAlbum.AlbumID = tblSong.AlbumID) "
            + "INNER JOIN tblArtist ON tblArtist.ArtistID = tblSong.ArtistID WHERE TrackID = " + randomID + ";";

        DataSet randomSong = new DataSet();
        OleDbDataAdapter randomAdapter = new OleDbDataAdapter(strSQL, conn);
        randomAdapter.Fill(randomSong, "randomSet");
        CloseConnection(conn);
        return randomSong;
    }

    public static DataSet GetArtists()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT ArtistID, ArtistName, ArtistArtPath FROM tblArtist ORDER BY ArtistName ASC;";
        DataSet artistsSet = new DataSet();
        OleDbDataAdapter artistsAdapter = new OleDbDataAdapter(strSQL, conn);
        artistsAdapter.Fill(artistsSet, "artistsSet");
        CloseConnection(conn);
        return artistsSet;
    }

    public static DataSet GetAlbums()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT tblArtist.ArtistName, tblAlbum.ArtistID, tblAlbum.AlbumID, tblAlbum.AlbumTitle, tblAlbum.AlbumArtPath "
            + "FROM (tblAlbum INNER JOIN tblArtist ON tblArtist.ArtistID = tblAlbum.ArtistID) ORDER BY AlbumTitle ASC;";
        DataSet albumsSet = new DataSet();
        OleDbDataAdapter albumsAdapter = new OleDbDataAdapter(strSQL, conn);
        albumsAdapter.Fill(albumsSet, "albumsSet");
        CloseConnection(conn);
        return albumsSet;
    }

    public static Boolean CheckDuplicateUsername(String username)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT UserUsername FROM tblUser WHERE UserUsername = '" + username.ToUpper() + "';";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        Boolean isDuplicate = false;
        if (reader.HasRows)
        {
            isDuplicate = true;
        }
        CloseConnection(conn);
        return isDuplicate;
    }

    public static Boolean CheckDuplicateEmailAddress(String email)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT EmailAddress FROM tblUser WHERE EmailAddress = '" + email.ToUpper() + "';";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        Boolean isDuplicate = false;
        if (reader.HasRows)
        {
            isDuplicate = true;
        }
        CloseConnection(conn);
        return isDuplicate;
    }

    public static User RegisterUser(String username, String forename, String surname, String email, String password)
    {
        User user;
        OleDbConnection conn = OpenConnection();

        String insertSQL = "INSERT INTO tblUser(UserUsername, Forename, Surname, EmailAddress, UserPassword) VALUES "
            + "('" + username + "', '" + forename + "', '" + surname + "', '" + email + "', '" + password + "');";
        OleDbCommand cmd = new OleDbCommand(insertSQL, conn);
        cmd.ExecuteNonQuery();

        cmd.CommandText = "SELECT @@IDENTITY";
        int newUserID = Convert.ToInt32(cmd.ExecuteScalar());

        user = new User(newUserID, username, forename, surname, email);
        CloseConnection(conn);
        return user;
    }

    public static User VerifySignIn(String usernameIn, String passwordIn)
    {
        User user = null;
        OleDbConnection conn = OpenConnection();

        String strSQL = "SELECT * FROM tblUser WHERE UserUsername = '" + usernameIn + "' AND UserPassword = '" + passwordIn + "';";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int userID = Convert.ToInt32(reader["UserID"]);
            String usernameOut = reader["UserUsername"].ToString();
            String forename = reader["Forename"].ToString();
            String surname = reader["Surname"].ToString();
            String emailAddress = reader["EmailAddress"].ToString();
            user = new User(userID, usernameOut, forename, surname, emailAddress);
        }
        CloseConnection(conn);
        return user;
    }

    public static void MakePurchase(Purchase purchase)
    {
        OleDbConnection conn = OpenConnection();

        String formattedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        String purchaseSQL = "INSERT INTO tblSale(UserID, SalePrice, CardNo, CardCVV, CardExpiryMonth, CardExpiryYear, SaleDate) "
            + "VALUES (" + purchase.GetUserID() + ", " + purchase.GetTotalCost() + ", '" + purchase.GetEndCardDigits() + "', '"
            + purchase.GetCVV() + "', " + purchase.GetExpMonth() + ", " + purchase.GetExpYear() + ", '" + formattedDate +"');";
        OleDbCommand purchaseCmd = new OleDbCommand(purchaseSQL, conn);
        purchaseCmd.ExecuteNonQuery();

        purchaseCmd.CommandText = "SELECT @@IDENTITY;";
        purchase.SetReceiptID(Convert.ToInt32(purchaseCmd.ExecuteScalar()));

        ArrayList arrCart = purchase.GetCart();
        foreach(CartItem ci in arrCart)
        {
            String saleSQL = "INSERT INTO tblAlbumSale(ReceiptID, AlbumID) VALUES (" + purchase.GetReceiptID() + ", " + ci.GetAlbumID() + ");";
            purchaseCmd.CommandText = saleSQL;
            purchaseCmd.ExecuteNonQuery();
        }
        CloseConnection(conn);
    }

    public static DataSet GetPurchasedAlbums(int userID)
    {
        OleDbConnection conn = OpenConnection();

        String strSQL = "SELECT tblSale.ReceiptID, tblAlbum.AlbumID, tblAlbum.AlbumTitle, tblAlbum.AlbumArtPath, tblArtist.ArtistID, tblArtist.ArtistName, tblArtist.ArtistArtPath "
                        + "FROM tblSale INNER JOIN (tblArtist INNER JOIN(tblAlbum INNER JOIN tblAlbumSale ON tblAlbum.AlbumID = tblAlbumSale.AlbumID) ON tblArtist.ArtistID = tblAlbum.ArtistID) "
                        + "ON tblSale.ReceiptID = tblAlbumSale.ReceiptID WHERE tblSale.UserID = " + userID + " ORDER BY tblSale.ReceiptID DESC;";
        DataSet purchasedSet = new DataSet();
        OleDbDataAdapter albumsAdapter = new OleDbDataAdapter(strSQL, conn);
        albumsAdapter.Fill(purchasedSet, "purchasedSet");
        CloseConnection(conn);
        return purchasedSet;
    }

    public static DataSet GetExclusiveDetails()
    {
        OleDbConnection conn = OpenConnection();

        String strSQL = "SELECT * FROM tblExclusive;";
        DataSet exclusiveSet = new DataSet();
        OleDbDataAdapter exclusiveAdapter = new OleDbDataAdapter(strSQL, conn);
        exclusiveAdapter.Fill(exclusiveSet, "exclusiveSet");
        CloseConnection(conn);
        return exclusiveSet;
    }

    public static String GetExclusiveSong()
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "SELECT TrackFilePath FROM tblExclusive;";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        reader.Read();
        String trackFilePath = reader["TrackFilePath"].ToString();
        CloseConnection(conn);
        return trackFilePath;
    }

    public static void UpdateArtist(Artist artist)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "UPDATE tblArtist SET ArtistDescription = @ARTISTDESC, ArtistArtPath = '"
            + artist.GetArtistArtPath() + "' WHERE ArtistID = " + artist.GetArtistID() + ";";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        cmd.Parameters.AddRange(new OleDbParameter[] { new OleDbParameter("@ARTISTDESC", artist.GetArtistDesc()) });
        cmd.ExecuteNonQuery();
        CloseConnection(conn);
    }

    public static void UpdateAlbum(Album album)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "UPDATE tblAlbum SET AlbumArtPath = '" + album.GetAlbumArtPath() + "', AlbumPrice = " + album.GetAlbumPrice()
            + " WHERE AlbumID = " + album.GetAlbumID() + ";";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        cmd.ExecuteNonQuery();
        CloseConnection(conn);
    }

    public static void UpdateExclusive(String artistName, String artistDescription, String artistCountry, String trackTitle, String trackFilePath)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "UPDATE tblExclusive SET ArtistName = '" + artistName + "', ArtistDescription = @ARTISTDESC, "
            + "ArtistCountry = '" + artistCountry + "', TrackTitle = '" + trackTitle + "', TrackFilePath = ";
        if(trackFilePath != null)
        {
            strSQL += "'" + trackFilePath + "';";
        }
        else
        {
            strSQL += " tblExclusive.TrackFilePath;";
        }
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        cmd.Parameters.AddRange(new OleDbParameter[] { new OleDbParameter("@ARTISTDESC", artistDescription) });
        cmd.ExecuteNonQuery();
        CloseConnection(conn);
    }

    public static void UpdateUser(User user, String password)
    {
        OleDbConnection conn = OpenConnection();
        String strSQL = "UPDATE tblUser SET Forename = '" + user.GetForename() + "', Surname = '" + user.GetSurname() + "', EmailAddress = '" + user.GetEmailAddress() + "', ";
        if(password == null)
        {
            strSQL += "UserPassword = UserPassword ";
        }
        else
        {
            strSQL += "UserPassword = '" + password + "' ";
        }
        strSQL += "WHERE UserID = " + user.GetUserID() + ";";
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        cmd.ExecuteNonQuery();
        CloseConnection(conn);
    }
}