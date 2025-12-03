<%@ Register Src="~/ProductCard.ascx" TagPrefix="uc" TagName="ProductCard" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="G21Assignment5.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>TryIt Page</h1>

            <h2>DLL Hash / Encryption / Decryption Test</h2>

            Input Text:
            <asp:TextBox ID="txtDLLInput" runat="server"></asp:TextBox><br />
            <br />

            Key:
            <asp:TextBox ID="txtDLLKey" runat="server"></asp:TextBox><br />
            <br />

            <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" /><br />
            <br />
            <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" /><br />
            <br />
            <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" /><br />
            <br />

            <asp:Label ID="lblDLLResult" runat="server" Font-Bold="true"></asp:Label>
            <br />

            <asp:Button ID="btnReturn" runat="server" Text="Return to Default.aspx" OnClick="btnReturn_Click" /><br />
        </div>
    </form>
</body>
</html>
