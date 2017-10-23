<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Tên Tài Khoản:
            <asp:TextBox ID="userAccount" runat="server"></asp:TextBox>
            <br />
             <br />
            Mật Khẩu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox  ID="passwordAccount" TextMode="Password" runat="server"></asp:TextBox>
            <br />
              <br />
            <div style="margin-left:130px" >
            <asp:Button ID="loginAccount" runat="server" Text="Đăng Nhập" OnClick="loginAccount_Click" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </div>
            <br />n
        </div>

    </form>
</body>
</html>
