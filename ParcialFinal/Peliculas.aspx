<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Peliculas.aspx.cs" Inherits="ParcialFinal.Peliculas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cine - Gestor peliculas</title>
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
    <form id="frmPeliculas" runat="server">
        <div class="menu">
            <h3>Gestor de películas</h3>
            <div>
                <asp:Button ID="backBtn" runat="server" Text="Volver" Font-Size="Medium" OnClick="backBtn_Click" />
                <asp:Button ID="cerrarSesionBtn" runat="server" Text="Cerrar sesión" Font-Size="Medium" OnClick="cerrarSesionBtn_Click" />
            </div>
        </div>
        <div class="container">
            <div class="peliculas">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Label ID="lbCodigo" runat="server" Text="Codigo:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqCodigo" runat="server" ErrorMessage="Ingrese un código." ControlToValidate="txtCodigo" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="reqCodigoDelete" runat="server" ErrorMessage="Ingrese un código." ControlToValidate="txtCodigo" ValidationGroup="validation2">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbNombre" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="Ingrese un nombre." ControlToValidate="txtNombre" ValidationGroup="validation1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbClasificacion" runat="server" Text="Clasificacion:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cbClasificacion" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                            <asp:ValidationSummary ID="ValidationSu1" ValidationGroup="validation1" runat="server"></asp:ValidationSummary>
                            <asp:ValidationSummary ID="ValidationSu2" ValidationGroup="validation2" runat="server"></asp:ValidationSummary>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="agregarBtn" runat="server" Text="Agregar" Font-Size="Medium" ValidationGroup="validation1" OnClick="agregarBtn_Click" />
                            <asp:Button ID="actualizarBtn" runat="server" Text="Actualizar" Font-Size="Medium" ValidationGroup="validation1" OnClick="actualizarBtn_Click" />
                            <asp:Button ID="eliminarBtn" runat="server" Text="Eliminar"  Font-Size="Medium" ValidationGroup="validation2" OnClick="eliminarBtn_Click" />
                            <asp:Button ID="consultarBtn" runat="server" Text="Consultar" Font-Size="Medium" ValidationGroup="validation2" OnClick="consultarBtn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tabla_peliculas">
                <asp:GridView ID="tablaPeliculas" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
