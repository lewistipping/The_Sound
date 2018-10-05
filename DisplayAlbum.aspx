<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayAlbum.aspx.cs" Inherits="DisplayAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        window.addEventListener("play", function (evt) {
            if (window.$_currentlyPlaying && window.$_currentlyPlaying != evt.target) {
                window.$_currentlyPlaying.pause();
                window.$_currentlyPlaying.currentTime = 0;
            }
            window.$_currentlyPlaying = evt.target;
        }, true);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <asp:Label ID="lblFailure" runat="server" Text="" Visible="true"></asp:Label>
        <div id="albumdisplay" runat="server" visible="false">
            <div id="albumtop" runat="server">
                <img id="albumart" runat="server" src="about:blank" width="200" height="200" />
                <p id="albumtitle" runat="server"></p>
                <div id="buy">
                    <asp:Button ID="btnBuy" runat="server" Text="Button" CssClass="roundbutton buybutton" OnClick="btnBuy_Click" />
                </div> 
            </div>
            <div class="container">
                <div id="songs" class="displaybox" runat="server">
                    <ol id="songlist" runat="server" style="list-style-type:decimal"></ol>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

