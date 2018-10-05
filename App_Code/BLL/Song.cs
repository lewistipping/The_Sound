using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Song
/// </summary>
public class Song
{
    private String title;
    private String filePath;

    public Song()
    {

    }

    public String getTitle()
    {
        return title;
    }

    public String getFilePath()
    {
        return filePath;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    public void setFilePath(String filePath)
    {
        this.filePath = filePath;
    }
}