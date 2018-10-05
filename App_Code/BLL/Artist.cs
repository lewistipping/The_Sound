using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Artist
{
    private int artistID;
    private String artistName;
    private String artistDesc;
    private String artistArtPath;

    public Artist()
    {

    }

    public int GetArtistID()
    {
        return artistID;
    }

    public void SetArtistID(int artistID)
    {
        this.artistID = artistID;
    }

    public String GetArtistName()
    {
        return artistName;
    }

    public void SetArtistName(String artistName)
    {
        this.artistName = artistName;
    }

    public String GetArtistDesc()
    {
        return artistDesc;
    }

    public void SetArtistDesc(String artistDesc)
    {
        this.artistDesc = artistDesc;
    }

    public String GetArtistArtPath()
    {
        return artistArtPath;
    }

    public void SetArtistArtPath(String artistArtPath)
    {
        this.artistArtPath = artistArtPath;
    }    
}