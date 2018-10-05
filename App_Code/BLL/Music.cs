using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for Music
/// </summary>
public class Music
{
    public Music()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Artist GetArtist(int artistID)
    {
        return DataAccess.GetArtist(artistID);
    }

    public static Album GetAlbum(int albumID)
    {
        return DataAccess.GetAlbum(albumID);
    }

    public static void UpdateArtist(Artist artist)
    {
        DataAccess.UpdateArtist(artist);
    }

    public static DataSet GetArtists()
    {
        return DataAccess.GetArtists();
    }

    public static DataSet GetAlbums()
    {
        return DataAccess.GetAlbums();
    }

    public static DataSet GetNewAlbums()
    {
        return DataAccess.GetNewAlbums();
    }

    public static DataSet GetTopAlbums()
    {
        return DataAccess.GetTopAlbums();
    }

    public static void UpdateAlbum(Album album)
    {
        DataAccess.UpdateAlbum(album);
    }

    public static DataSet GetRandomSong()
    {
        return DataAccess.GetRandomSong();
    }

    public static void MakePurchase(Purchase purchase)
    {
        DataAccess.MakePurchase(purchase);
    }

    public static DataSet GetExclusiveDetails()
    {
        return DataAccess.GetExclusiveDetails();
    }

    public static String GetExclusiveSong()
    {
        return DataAccess.GetExclusiveSong();
    }

    public static void UpdateExclusive(String artistName, String artistDescription, String artistCountry, String trackTitle, String trackFilePath)
    {
        DataAccess.UpdateExclusive(artistName, artistDescription, artistCountry, trackTitle, trackFilePath);
    }
}