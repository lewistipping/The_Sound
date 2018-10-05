<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Secure_MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <asp:Label ID="lblAccount" runat="server" Text="" CssClass="headline whiteheadline"></asp:Label><br />
            <asp:HyperLink ID="hylEditAccount" runat="server" ForeColor="White" NavigateUrl="~/Secure/EditAccount.aspx" Font-Names="'Montserrat', sans-serif" Font-Size="Large">Edit Account</asp:HyperLink>
            <asp:HyperLink ID="hylExclusive" runat="server" ForeColor="White" NavigateUrl="~/Secure/TheSoundExclusive.aspx" Font-Names="'Montserrat', sans-serif" Font-Size="Large">View This Week's Exclusive!</asp:HyperLink>
            <div class="displaybox">
                <asp:Panel ID="pnlPurchased" runat="server">
                    <asp:Label ID="lblEmpty" runat="server" Text="No albums purchased yet." Enabled="false" Font-Names="'Montserrat', sans-serif" Font-Size="XX-Large"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

