using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class Purchase
{
    private int receiptID;
    private int userID;
    private double totalCost;
    private String endCardDigits;
    private String cvv;
    private int expMonth;
    private int expYear;
    private ArrayList arrCart;
    
    public Purchase(int userID, double totalCost, String endCardDigits, String cvv, int expMonth, int expYear, ArrayList arrCart)
    {
        this.userID = userID;
        this.totalCost = totalCost;
        this.endCardDigits = endCardDigits;
        this.cvv = cvv;
        this.expMonth = expMonth;
        this.expYear = expYear;
        this.arrCart = arrCart;
    }

    public int GetReceiptID()
    {
        return receiptID;
    }

    public void SetReceiptID(int receiptID)
    {
        this.receiptID = receiptID;
    }

    public int GetUserID()
    {
        return userID;
    }

    public double GetTotalCost()
    {
        return totalCost;
    }

    public String GetEndCardDigits()
    {
        return endCardDigits;
    }

    public String GetCVV()
    {
        return cvv;
    }

    public int GetExpMonth()
    {
        return expMonth;
    }

    public int GetExpYear()
    {
        return expYear;
    }

    public ArrayList GetCart()
    {
        return arrCart;
    }
}