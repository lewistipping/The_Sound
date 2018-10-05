using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Boolean CheckDuplicateUsername(String username)
    {
        return DataAccess.CheckDuplicateUsername(username);
    }

    public static Boolean CheckDuplicateEmailAddress(String email)
    {
        return DataAccess.CheckDuplicateEmailAddress(email);
    }

    public static User RegisterUser(String username, String forename, String surname, String email, String password)
    {
        return DataAccess.RegisterUser(username, forename, surname, email, password);
    }

    public static User VerifySignIn(String username, String password)
    {
        return DataAccess.VerifySignIn(username, password);
    }

    public static DataSet GetPurchasedAlbums(int userID)
    {
        return DataAccess.GetPurchasedAlbums(userID);
    }

    public static void UpdateUser(User user, String password)
    {
        DataAccess.UpdateUser(user, password);
    }
}