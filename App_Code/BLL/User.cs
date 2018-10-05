using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private int userID;
    private String username;
    private String forename;
    private String surname;
    private String emailAddress;

    public User(int userID, String username, String forename, String surname, String emailAddress)
    {
        this.userID = userID;
        this.username = username;
        this.forename = forename;
        this.surname = surname;
        this.emailAddress = emailAddress;
    }

    public int GetUserID()
    {
        return userID;
    }

    public void SetUserID(int userID)
    {
        this.userID = userID;
    }

    public String GetUsername()
    {
        return username;
    }

    public void SetUsername(String username)
    {
        this.username = username;
    }

    public String GetForename()
    {
        return forename;
    }

    public void SetForename(String forename)
    {
        this.forename = forename;
    }

    public String GetSurname()
    {
        return surname;
    }

    public void SetSurname(String surname)
    {
        this.surname = surname;
    }

    public String GetEmailAddress()
    {
        return emailAddress;
    }

    public void SetEmailAddress(String emailAddress)
    {
        this.emailAddress = emailAddress;
    }
}