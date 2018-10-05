<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheSoundExclusive.aspx.cs" Inherits="Secure_TheSoundExclusive" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/ExclusiveTilePuzzle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="exclusivetop"></div>
        <div class="container">
            <p id="exclusivetitle" class="exclusiveheadline whiteheadline" runat="server"></p>
            <div class="exclusiveartist">
                <asp:Image ID="imgExclusiveArtist" runat="server" ImageUrl="~/Files/Exclusive/exclusiveartist.jpg" Height="150px" Width="150px" /><br />
                <asp:Label ID="lblExclusiveArtist" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblExclusiveCountry" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div class="exclusivedesc">
                <asp:Label ID="lblExclusiveDesc" runat="server" Text=""></asp:Label><br /><br />
                <asp:Label ID="lblSolve" runat="server" Text="Hear it here first! All you have to do is solve the sliding tile puzzle below." CssClass="solve"></asp:Label>
            </div>
            <br />
            <br />
            <div id="puzzle">
                <div class="puzzletable">
                    <div class="table-row">
                        <div id="tile00" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img00.jpg" id="img00" class="tile" onclick="select(id)" /></div>
                        <div id="tile01" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img01.jpg" id="img01" class="tile" onclick="select(id)" /></div>
                        <div id="tile02" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img02.jpg" id="img02" class="tile" onclick="select(id)" /></div>
                    </div>
                    <div class="table-row">                     
                        <div id="tile11" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img10.jpg" id="img10" class="tile" onclick="select(id)" /></div>
                        <div id="tile12" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img11.jpg" id="img11" class="tile" onclick="select(id)" /></div>
                        <div id="tile13" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img12.jpg" id="img12" class="tile" onclick="select(id)" /></div>
                    </div>
                    <div class="table-row">                        
                        <div id="tile21" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img20.jpg" id="img20" class="tile" onclick="select(id)" /></div>
                        <div id="tile22" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/imgBlank.jpg" id="img21" class="tile" onclick="select(id)" /></div>
                        <div id="tile23" class="puzzlecell"><img src="../Files/Exclusive/Puzzle/img21.jpg" id="img22" class="tile" onclick="select(id)" /></div>
                    </div>
                </div>
                <asp:ScriptManager ID="smrGetSong" runat="server" EnablePageMethods="True"></asp:ScriptManager>
            </div>
            <div style="clear:both;"></div> 
        </div>
    </div>
</asp:Content>

