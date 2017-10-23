<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testlogin.aspx.cs" Inherits="testlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="dist/login/css/style.css" />
</head>
<body>
    <div class="wrapper" style="height: 100%;margin-top:-400px;">
        <div style="margin-top: 100px;" class="container">
            <h1>Welcome</h1>

            <form class="form" runat="server">
                <input type="text" id="user" placeholder="Username" />
                <input type="password" id="pass" placeholder="Password" />
                <button type="submit" id="login-button">Login</button>
            </form>
        </div>

        <ul class="bg-bubbles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script src="dist/login/js/index.js"></script>

</body>
</html>
