<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="CapaPresentacion.Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Crear Usuario</h1>
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <br />
            <label>Fecha de nacimiento:</label>
            <asp:Calendar ID="calFechaNacimiento" runat="server"></asp:Calendar>
            <br />
            <label>Sexo:</label>
            <asp:DropDownList ID="ddlSexo" runat="server">
                <asp:ListItem Text="Masculino" Value="M" />
                <asp:ListItem Text="Femenino" Value="F" />
            </asp:DropDownList>
            <br />
            <br />
            <div class="wrapBtn">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn" />
                <asp:Button ID="btnListar" runat="server" Text="LIstar" OnClick="btnListar_Click"  CssClass="btnList"/>
            </div>

            <br />
            <asp:Label ID="labelError" runat="server" CssClass="labelError">Error:</asp:Label>
        </div>
    </form>
</body>
</html>
