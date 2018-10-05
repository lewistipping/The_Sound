using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    private int albumID;
    private String albumName;
    private String albumArtPath;
    private int artistID;
    private String artistName;
    private double price;

    public CartItem(int albumID, string albumName, String albumArtPath, int artistID, string artistName, double price)
    {
        this.albumID = albumID;
        this.albumName = albumName;
        this.albumArtPath = albumArtPath;
        this.artistID = artistID;
        this.artistName = artistName;
        this.price = price;
    }

    public int GetAlbumID()
    {
        return albumID;
    }

    public String GetAlbumName()
    {
        return albumName;
    }

    public String GetAlbumArtPath()
    {
        return albumArtPath;
    }

    public int GetArtistID()
    {
        return artistID;
    }

    public String GetArtistName()
    {
        return artistName;
    }

    public double GetPrice()
    {
        return price;
    }
}