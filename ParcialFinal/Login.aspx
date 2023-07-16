<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ParcialFinal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cine - Login</title>
    <style>
        .container {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            padding: 1% 3%;
            gap: 10px;
            justify-content: center;
        }

        table {
            border: 1px solid #808080ff;
            padding: 40px 20px;
            border-collapse: collapse
        }

            table tr td {
                padding: 20px;
            }
    </style>
</head>
<body>
    <form id="frmLogin" runat="server">
        <div class="container">
            <div class="login">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Label ID="lbUsuario" runat="server" Text="Usuario: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbPassword" runat="server" Text="Contraseña: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="loginBtn" runat="server" Text="Login" Font-Size="Medium" OnClick="loginBtn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
