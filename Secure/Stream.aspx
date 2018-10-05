<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stream.aspx.cs" Inherits="Secure_Stream" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="../Scripts/Streamer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <div id="streamimage">
                <asp:Image ID="imgStream" runat="server" />
            </div>
            <div id="streamdetails">
                <p id="nowstreaming">NOW STREAMING</p>
                <asp:Label ID="lblAlbum" runat="server" Text="" CssClass="streamalbum"></asp:Label><br />
                <asp:Label ID="lblArtist" runat="server" Text="" CssClass="streamartist"></asp:Label><br /><br />
                <asp:Button ID="btnBack" runat="server" Text="Back to My Account" OnClick="btnBack_Click" />
            </div>
            <div class="displaybox streambox">
                <div id="streambox">
                    <div id="streamaudio">
                        <audio id="audio" preload="auto" tabindex="0" controls="" type="audio/mpeg">
                            <source id="audiosrc" type="audio/mp3" src="" runat="server"/>
                            Sorry, your browser does not support HTML5 audio.
                        </audio>
                    </div>
                    <ol id="playlist" runat="server" style="list-style-type:decimal"></ol>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>

