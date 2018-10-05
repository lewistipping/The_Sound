<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditArtist.aspx.cs" Inherits="SecureAdmin_EditArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container centretext whitetext">
            <p class="headline whiteheadline">Edit Artist</p>
            <asp:Label ID="lblSearch" runat="server" Text="Enter Artist ID: "></asp:Label><br />
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /><br />
            <asp:Label ID="lblSearchError" runat="server" Text="" CssClass="validators"></asp:Label><br /><br />
            <asp:Label ID="lblEditing" runat="server" Font-Size="Large"></asp:Label><br /><br />
            <asp:Label ID="lblNewImage" runat="server" Text="Upload New Image"></asp:Label><br />
            <asp:FileUpload ID="fulNewImage" runat="server" Enabled="false"/><br />
            <asp:RegularExpressionValidator ID="revNewImage" runat="server" ErrorMessage="JPEG or PNG only." Display="Dynamic" ControlToValidate="fulNewImage" CssClass="validators" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$"></asp:RegularExpressionValidator><br />
            <asp:Image ID="imgNewImage" runat="server" Visible="false" Width="200px" Height="200px"/><br /><br />
            <asp:Label ID="lblDescription" runat="server" Text="Edit Description"></asp:Label><br />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Enabled="false" Width="500px" Height="100px" BorderStyle="None" Font-Names="'Arial',sans-serif" Font-Size="Small"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Enabled="false" ErrorMessage="Description required." Display="Dynamic" ControlToValidate="txtDescription" CssClass="validators"></asp:RequiredFieldValidator><br />
            <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" Enabled="false" Width="100px" Height="25px" OnClick="btnUpdate_Click"/><br />
            <asp:HyperLink ID="hylCancelEdit" runat="server" ForeColor="White" NavigateUrl="~/SecureAdmin/AdminHome.aspx">Cancel</asp:HyperLink>
        </div>
    </div>
</asp:Content>

