<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>The Sound - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="whitebody">
    <div id="welcome">
        <div class="container">
            <div id="message">
                <p class="headline whiteheadline">Welcome to The Sound</p>
                <div id="randomone" runat="server" visible="true">
                    <p>Not sure what you want to listen to?</p>
                    <asp:Button ID="btnRandom" runat="server" Text="Click here" CssClass="roundbutton randombutton" OnClick="btnRandom_Click" />
                </div>
            </div>
            <div id="randomtwo" runat="server" visible="false">
                <div id="randomart" style="float:left">
                    <img id="randomalbumart" runat="server" src="about:blank" width="100" height="100" />
                </div>
                <div id="randomdetails" style="float:left">
                    <p id="randomsong" runat="server"></p>
                    <p id="randomartist" runat="server"></p>
                    <div oncontextmenu="return false">
                        <audio id="randomplayer" controls controlsList="nodownload">
                            <source id="randomplayersource" type="audio/mpeg" runat="server" />
                            Your browser does not support the audio tag.
                        </audio>
                    </div>
                    <%--<asp:Hyperlink runat="server" ID="hylAnother">TRY ANOTHER</asp:Hyperlink>--%>
                    <asp:Button runat="server" text="Try another" ID="btnAnother" OnClick="btnAnother_Click" />
                </div>
            </div>
        </div>
    </div>
    <div>
        <div class="homecontainer">
        <p class="hometitles">Just Added</p>
            <div id="newalbums" runat="server"></div>
        <p class="hometitles">Most Popular This Week</p>
            <div id="popular" runat="server"></div>
        </div>
   </div>
        </div>
</asp:Content>

