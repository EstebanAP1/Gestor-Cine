<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ParcialFinal.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cine - Menu</title>
    <style>
        .menu {
            width: 100%;
            min-height: 80px;
            display: flex;
            justify-content: space-around;
            align-items: center;
        }

        table {
            padding: 40px 20px;
            border-collapse: collapse
        }

            table tr td {
                padding-right: 30px;
                padding-left: 30px;
            }
    </style>
</head>
<body>
    <form id="frmMenu" runat="server">
        <h1>Bienvenido al sistema</h1>
        <nav class="menu">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" Font-Size="X-Large" OnClick="btnUsuarios_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSalas" runat="server" Text="Salas" Font-Size="X-Large" OnClick="btnSalas_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnPeliculas" runat="server" Text="Peliculas" Font-Size="X-Large" OnClick="btnPeliculas_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnFunciones" runat="server" Text="Funciones" Font-Size="X-Large" OnClick="btnFunciones_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" Font-Size="X-Large" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
        </nav>
    </form>
</body>
</html>
