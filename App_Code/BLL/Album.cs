using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Album
/// </summary>
public class Album
{
    private int artistID;
    private String artistName;
    private int albumID;
    private String albumTitle;
    private String albumArtPath;
    private double albumPrice;
    private List<Song> songList;

    public Album()
    {
        songList = new List<Song>();
    }

    public int GetArtistID()
    {
        return artistID;
    }

    public String GetArtistName()
    {
        return artistName;
    }

    public int GetAlbumID()
    {
        return albumID;
    }

    public String GetAlbumTitle()
    {
        return albumTitle;
    }

    public String GetAlbumArtPath()
    {
        return albumArtPath;
    }

    public List<Song> GetSongs()
    {
        return songList;
    }

    public double GetAlbumPrice()
    {
        return albumPrice;
    }

    public void SetArtistID(int artistID)
    {
        this.artistID = artistID;
    }

    public void SetArtistName(String artistName)
    {
        this.artistName = artistName;
    }

    public void SetAlbumID(int albumID)
    {
        this.albumID = albumID;
    }

    public void SetAlbumTitle(String albumTitle)
    {
        this.albumTitle = albumTitle;
    }

    public void SetAlbumArtPath(String albumArtPath)
    {
        this.albumArtPath = albumArtPath;
    }

    public void SetAlbumPrice(double albumPrice)
    {
        this.albumPrice = albumPrice;
    }

    public void AddSongs(Song song)
    {
        songList.Add(song);
    }
}