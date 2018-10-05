<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>The Sound - Your Cart</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <p class="headline whiteheadline">Your Cart</p>
            <asp:Panel ID="pnlCartDetails" runat="server"></asp:Panel>
            <asp:Panel ID="pnlCost" runat="server" CssClass="displaybox cost">
                <asp:Label ID="lblCost" runat="server"></asp:Label>
                <div style="float:right; margin: 0px 5px">
                    <asp:Button ID="btnRemoveAll" runat="server" Text="Remove All" CssClass="roundbutton redbutton" OnClick="btnRemoveAll_Click" />
                    <asp:Button ID="btnCheckout" runat="server" Text="Purchase" CssClass="roundbutton bluebutton" OnClick="btnCheckout_Click" />
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

