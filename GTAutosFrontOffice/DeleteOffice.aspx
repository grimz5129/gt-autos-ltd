﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteOffice.aspx.cs" Inherits="DeleteOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Are you sure you want to delete this record?</p>
        <p>
            <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Width="76px" />
&nbsp;<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Width="76px" />
        </p>
    </form>
</body>
</html>