<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditWeeklyExclusive.aspx.cs" Inherits="SecureAdmin_EditWeeklyExclusive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container centretext whitetext">
            <p class="headline whiteheadline">Edit Weekly Exclusive</p>
            <asp:Label ID="lblArtistName" runat="server" Text="Artist Name"></asp:Label><br />
            <asp:TextBox ID="txtArtistName" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvArtistName" runat="server" ControlToValidate="txtArtistName" CssClass="validators" Display="Dynamic" ErrorMessage="Must not be blank."></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblArtistCountry" runat="server" Text="Artist Country"></asp:Label><br />
            <asp:TextBox ID="txtArtistCountry" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvArtistCountry" runat="server" ControlToValidate="txtArtistCountry" CssClass="validators" Display="Dynamic" ErrorMessage="Must not be blank."></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Artist Description"></asp:Label><br />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="500px" Height="100px" BorderStyle="None" Font-Names="'Arial',sans-serif" Font-Size="Small"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" CssClass="validators" Display="Dynamic" ErrorMessage="Must not be blank."></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="lblBanner" runat="server" Text="Banner"></asp:Label><br />
            <asp:FileUpload ID="fulBanner" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revBanner" runat="server" ErrorMessage="JPEG or PNG only." ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$" ControlToValidate="fulBanner" Display="Dynamic" CssClass="validators"></asp:RegularExpressionValidator><br />

            <asp:Label ID="lblArtistImage" runat="server" Text="Artist Image"></asp:Label><br />
            <asp:FileUpload ID="fulArtistImage" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revArtistImage" runat="server" ErrorMessage="JPEG or PNG only." ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$" ControlToValidate="fulArtistImage" Display="Dynamic" CssClass="validators"></asp:RegularExpressionValidator>
            <br />
            <br />

            <asp:Label ID="lblTrack" runat="server" Text="Song Title"></asp:Label><br />
            <asp:TextBox ID="txtTrack" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvTrack" runat="server" CssClass="validators" Display="Dynamic" ErrorMessage="Must not be blank." ControlToValidate="txtTrack"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblUploadSong" runat="server" Text="Upload Song"></asp:Label><br />
            <asp:FileUpload ID="fulTrack" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revTrack" runat="server" ErrorMessage="MP3 only." ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.mp3|.MP3)$" ControlToValidate="fulTrack" Display="Dynamic" CssClass="validators"></asp:RegularExpressionValidator><br />
            <asp:Label ID="lblUploadCover" runat="server" Text="Upload Cover"></asp:Label><br />
            <asp:FileUpload ID="fulUploadCover" runat="server" /><br />
            <asp:RegularExpressionValidator ID="revUploadCover" runat="server" ErrorMessage="JPG or PNG only." ControlToValidate="fulUploadCover" CssClass="validators" Display="Dynamic" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$"></asp:RegularExpressionValidator><br />
            <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" Width="100px" Height="25px" OnClick="btnUpdate_Click"/><br />
            <asp:HyperLink ID="hylCancelEdit" runat="server" ForeColor="White" NavigateUrl="~/SecureAdmin/AdminHome.aspx">Cancel</asp:HyperLink>
        </div>
    </div>
</asp:Content>

