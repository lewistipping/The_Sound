<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="Secure_EditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="blackbody">
        <div class="container centretext whitetext">
            <p class="headline whiteheadline">Edit Account</p>
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label><br />
            <asp:TextBox ID="txtUsername" placeholder="Username (A-Z, 0-9)" runat="server" CssClass="inputboxes" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="lblForename" runat="server" Text="Forename"></asp:Label><br />
            <asp:TextBox ID="txtForename" placeholder="Forename" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvForename" runat="server" ErrorMessage="Forename cannot be blank." CssClass="validators" ControlToValidate="txtForename" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revForename" runat="server" ErrorMessage="Characters A-Z only." CssClass="validators" ControlToValidate="txtForename" ValidationExpression="[A-Za-z]+" Display="Dynamic"></asp:RegularExpressionValidator><br />
            <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label><br />
            <asp:TextBox ID="txtSurname" placeholder="Surname" runat="server" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ErrorMessage="Surname cannot be blank." CssClass="validators" ControlToValidate="txtSurname" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSurname" runat="server" ErrorMessage="Characters A-Z only." CssClass="validators" ControlToValidate="txtSurname" ValidationExpression="[A-Za-z]+" Display="Dynamic"></asp:RegularExpressionValidator><br />
            <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label><br />
            <asp:TextBox ID="txtEmail" placeholder="Email" runat="server" TextMode="Email" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email address cannot be blank." CssClass="validators" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="validators" ErrorMessage="Invalid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password (leave blank to retain old password)"></asp:Label><br />
            <asp:TextBox ID="txtPassword" placeholder="Password (A-Z, 0-9)"  runat="server" TextMode="Password" CssClass="inputboxes"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Characters A-Z, 0-9 only." CssClass="validators" ControlToValidate="txtPassword" ValidationExpression="^[A-Za-z0-9]*$+" Display="Dynamic"></asp:RegularExpressionValidator><br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="roundbutton bluebutton" OnClick="btnUpdate_Click" /><br />
            <asp:HyperLink ID="hylCancelEdit" runat="server" ForeColor="White" NavigateUrl="~/Secure/MyAccount.aspx">Cancel</asp:HyperLink>
        </div>
    </div>
</asp:Content>

