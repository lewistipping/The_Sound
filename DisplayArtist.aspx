<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayArtist.aspx.cs" Inherits="DisplayArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <asp:Label ID="lblFailure" runat="server" Text="" Visible="true"></asp:Label>
        <div id="artistdisplay" runat="server" visible="false">
            <div id="artisttop" runat="server">
                <img id="artistart" src="about:blank" runat="server" width="200" height="200" />
                <p id="artistname" runat="server"></p>
            </div>
            <div id="artistmid">
                <p>BIOGRAPHY</p>
                <p id="artistdesc" runat="server"></p>
                <p>DISCOGRAPHY</p>
            </div>
            <div class="wrapalbums">
                <div class="container">
                <div id="albums" runat="server"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

