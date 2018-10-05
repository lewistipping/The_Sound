<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Secure_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 250px;
        }
        .auto-style3 {
            width: 250px;
            height: 27px;
        }
        .auto-style4 {
            height: 27px;
        }
        .auto-style5 {
            height: 27px;
            width: 290px;
        }
        .auto-style6 {
            width: 290px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <p class="headline whiteheadline">Payment</p>
            <div class="displaybox">
                <asp:Label ID="lblForename" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblSurname" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label><br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="lblCardNo" runat="server" Text="Card No.:"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtCardNo" placeholder="16 digits, 0-9 only, no spaces" runat="server" Width="280px"></asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            <asp:RequiredFieldValidator ID="rfvCardNo" runat="server" CssClass="validators" Display="Dynamic" ControlToValidate="txtCardNo">Required field.</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCardNo" runat="server" ErrorMessage="Invalid card number format." ControlToValidate="txtCardNo" CssClass="validators" Display="Dynamic" ValidationExpression="\d{16}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblCVV" runat="server" Text="CVV / Security Code:"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtCVV" runat="server" Width="50px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvCVV" runat="server" CssClass="validators" Display="Dynamic" ErrorMessage="Required field." ControlToValidate="txtCVV"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCVV" runat="server" ControlToValidate="txtCVV" CssClass="validators" Display="Dynamic" ErrorMessage="Invalid CVV format." ValidationExpression="\d{3}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date:"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="ddlMonth" runat="server">
                                <asp:ListItem Selected="True">Month</asp:ListItem>
                                <asp:ListItem Value="1">01</asp:ListItem>
                                <asp:ListItem Value="2">02</asp:ListItem>
                                <asp:ListItem Value="3">03</asp:ListItem>
                                <asp:ListItem Value="4">04</asp:ListItem>
                                <asp:ListItem Value="5">05</asp:ListItem>
                                <asp:ListItem Value="6">06</asp:ListItem>
                                <asp:ListItem Value="7">07</asp:ListItem>
                                <asp:ListItem Value="8">08</asp:ListItem>
                                <asp:ListItem Value="9">09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlYear" runat="server">
                                <asp:ListItem>Year</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblExpired" runat="server" CssClass="validators"></asp:Label>
                        </td>
                    </tr>
                </table><br />
                <asp:HyperLink ID="hylCancel" runat="server" NavigateUrl="~/Cart.aspx">Go Back</asp:HyperLink><br />
                <asp:Button ID="btnPay" runat="server" Text="Pay" CssClass="roundbutton bluebutton" OnClick="btnPay_Click" />
            </div>
        </div>
    </div>
</asp:Content>

