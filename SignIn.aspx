<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="signin" class="whitebody">
        <div class="container centretext">
            <p class="headline">Sign In</p>
            <asp:TextBox ID="txtUsernameSignIn" placeholder="Username" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvUsernameSignIn" runat="server" ErrorMessage="Username cannot be blank." ControlToValidate="txtUsernameSignIn" CssClass="validators" Display="Dynamic"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="txtPasswordSignIn" placeholder="Password" runat="server" TextMode="Password" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvPasswordSignIn" runat="server" ErrorMessage="Password cannot be blank." ControlToValidate="txtPasswordSignIn" CssClass="validators" Display="Dynamic"></asp:RequiredFieldValidator><br />
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="roundbutton bluebutton" OnClick="btnSignIn_Click" /><br />
            <asp:Label ID="lblSignInError" runat="server" CssClass="validators" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

