<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Artists.aspx.cs" Inherits="Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container">
            <p class="headline whiteheadline">Artists</p>
            <asp:Panel ID="pnlArtists" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>

