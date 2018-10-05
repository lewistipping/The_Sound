<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="whitebody">
        <div class="container centretext">
            <p class="headline">Register</p>
            <asp:TextBox ID="txtUsernameRegister" placeholder="Username (A-Z, 0-9)" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvUsernameRegister" runat="server" ErrorMessage="Username cannot be blank." CssClass="validators" ControlToValidate="txtUsernameRegister" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUsernameRegister" runat="server" ErrorMessage="Characters A-Z, 0-9 only." CssClass="validators" ControlToValidate="txtUsernameRegister" ValidationExpression="[A-Za-z0-9]+" Display="Dynamic"></asp:RegularExpressionValidator><br />

            <asp:TextBox ID="txtForename" placeholder="Forename" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvForename" runat="server" ErrorMessage="Forename cannot be blank." CssClass="validators" ControlToValidate="txtForename" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revForename" runat="server" ErrorMessage="Characters A-Z only." CssClass="validators" ControlToValidate="txtForename" ValidationExpression="[A-Za-z]+" Display="Dynamic"></asp:RegularExpressionValidator><br />

            <asp:TextBox ID="txtSurname" placeholder="Surname" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ErrorMessage="Surname cannot be blank." CssClass="validators" ControlToValidate="txtSurname" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSurname" runat="server" ErrorMessage="Characters A-Z only." CssClass="validators" ControlToValidate="txtSurname" ValidationExpression="[A-Za-z]+" Display="Dynamic"></asp:RegularExpressionValidator><br />

            <asp:TextBox ID="txtEmail" placeholder="Email" runat="server" TextMode="Email" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email address cannot be blank." CssClass="validators" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="validators" ErrorMessage="Invalid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            <br />

            <asp:TextBox ID="txtPasswordRegister" placeholder="Password (A-Z, 0-9)"  runat="server" TextMode="Password" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvPasswordRegister" runat="server" ErrorMessage="Password cannot be blank." CssClass="validators" ControlToValidate="txtPasswordRegister" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPasswordRegister" runat="server" ErrorMessage="Characters A-Z, 0-9 only." CssClass="validators" ControlToValidate="txtPasswordRegister" ValidationExpression="[A-Za-z0-9]+" Display="Dynamic"></asp:RegularExpressionValidator><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="roundbutton bluebutton" OnClick="btnRegister_Click" /><br />

            <asp:Label runat="server" text="" ID="lblStatus" CssClass="status"></asp:Label>
        </div>
    </div>
</asp:Content>

