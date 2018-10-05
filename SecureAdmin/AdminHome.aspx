<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="SecureAdmin_AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <p class="headline whiteheadline">Admin Home</p>
            <div class="displaybox">
                <asp:HyperLink ID="hylEditArtist" runat="server" CssClass="adminoption" NavigateUrl="~/SecureAdmin/EditArtist.aspx">Edit Artist</asp:HyperLink><br /><br />
                <asp:HyperLink ID="hylEditAlbum" runat="server" CssClass="adminoption" NavigateUrl="~/SecureAdmin/EditAlbum.aspx">Edit Album</asp:HyperLink><br /><br />
                <asp:HyperLink ID="hylEditExclusive" runat="server" CssClass="adminoption" NavigateUrl="~/SecureAdmin/EditWeeklyExclusive.aspx">Edit Weekly Exclusive</asp:HyperLink><br />
            </div>
        </div>
    </div>
</asp:Content>

