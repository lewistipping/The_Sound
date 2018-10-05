using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secure_Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null && Session["CART"] != null)
        {
            ArrayList arrCart = (ArrayList)Session["CART"];
            if(arrCart.Count != 0) LoadUserDetails();
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    private void LoadUserDetails()
    {
        User user = (User)Session["USER"];
        lblForename.Text = "Forename: " + user.GetForename();
        lblSurname.Text = "Surname: " + user.GetSurname();
        lblEmailAddress.Text = "Email Address: " + user.GetEmailAddress();
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        int selectedMonth;
        int selectedYear;
        try
        {
            selectedMonth = Convert.ToInt32(ddlMonth.SelectedValue.ToString());
            selectedYear = Convert.ToInt32(ddlYear.SelectedValue.ToString());
        }
        catch (Exception ex)
        {
            lblExpired.Text = "Invalid expiry date selected.";
            return;
        }

        if (CheckCardIsValid(selectedMonth, selectedYear))
        {
            User user = (User)Session["USER"];
            ArrayList arrCart = (ArrayList)Session["CART"];

            double totalCost = 0.0;
            foreach(CartItem ci in arrCart)
            {
                totalCost += ci.GetPrice();
            }

            String endCardDigits = txtCardNo.Text.Substring(12);

            Purchase purchase = new Purchase(user.GetUserID(), totalCost, endCardDigits, txtCVV.Text, selectedMonth, selectedYear, arrCart);
            Music.MakePurchase(purchase);

            Session["PURCHASE"] = purchase;
            Response.Redirect("~/Secure/ThankYou.aspx");
        }
        else
        {
            lblExpired.Text = "Card expired.";
        }
    }

    private Boolean CheckCardIsValid(int selectedMonth, int selectedYear)
    {
        int currentMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
        int currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

        if (selectedYear == currentYear)
        {
            if (selectedMonth >= currentMonth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (selectedYear > currentYear)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}