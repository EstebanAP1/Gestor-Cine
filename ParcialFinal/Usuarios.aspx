<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ParcialFinal.PagAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cine - Gestor usuarios</title>
    <style>
        .menu {
            width: 100%;
            min-height: 80px;
            display: flex;
            justify-content: space-around;
            align-items: center;
        }

        .container {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            padding: 1% 3%;
            gap: 10px;
            justify-content: space-around;
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
    <form id="frmAdmin" runat="server">
        <div class="menu">
            <h3>Gestor de Salas</h3>
            <div>
                <asp:Button ID="backBtn" runat="server" Text="Volver" Font-Size="Medium" OnClick="backBtn_Click" />
                <asp:Button ID="cerrarSesionBtn" runat="server" Text="Cerrar sesión" Font-Size="Medium" OnClick="cerrarSesionBtn_Click" />
            </div>
        </div>
        <div class="container">
            <div class="salas">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Label ID="lbNombres" runat="server" Text="Nombres: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombres" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="Ingrese el nombre." ControlToValidate="txtNombres" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="reqNombreUpdate" runat="server" ErrorMessage="Ingrese el nombre." ControlToValidate="txtNombres" ValidationGroup="validation3">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbUsuario" runat="server" Text="Nombre de usuario: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqUsuario" runat="server" ErrorMessage="Ingrese un nombre de usuario." ControlToValidate="txtUsuario" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="reqUsuarioDelete" runat="server" ErrorMessage="Ingrese un nombre de usuario." ControlToValidate="txtUsuario" ValidationGroup="validation2">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="reqUsuarioUpdate" runat="server" ErrorMessage="Ingrese un nombre de usuario." ControlToValidate="txtUsuario" ValidationGroup="validation3">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbPass" runat="server" Text="Contraseña: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqPass" runat="server" ErrorMessage="Ingrese la contraseña." ControlToValidate="txtPass" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbCorreo" runat="server" Text="Correo: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqCorreo" runat="server" ErrorMessage="Ingrese el correo." ControlToValidate="txtCorreo" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="reqCorreoUpdate" runat="server" ErrorMessage="Ingrese el correo." ControlToValidate="txtCorreo" ValidationGroup="validation3">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                            <asp:ValidationSummary ID="ValidationSu1" ValidationGroup="validation1" runat="server"></asp:ValidationSummary>
                            <asp:ValidationSummary ID="ValidationSu2" ValidationGroup="validation2" runat="server"></asp:ValidationSummary>
                            <asp:ValidationSummary ID="ValidationSu3" ValidationGroup="validation3" runat="server"></asp:ValidationSummary>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="agregarBtn" runat="server" Text="Agregar" Font-Size="Medium" ValidationGroup="validation1" OnClick="agregarBtn_Click" />
                            <asp:Button ID="actualizarBtn" runat="server" Text="Actualizar" Font-Size="Medium" ValidationGroup="validation3" OnClick="actualizarBtn_Click" />
                            <asp:Button ID="eliminarBtn" runat="server" Text="Eliminar" Font-Size="Medium" ValidationGroup="validation2" OnClick="eliminarBtn_Click" />
                            <asp:Button ID="consultarBtn" runat="server" Text="Consultar" Font-Size="Medium" ValidationGroup="validation2" OnClick="consultarBtn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tabla_usuarios">
                <asp:GridView ID="tablaUsuarios" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
