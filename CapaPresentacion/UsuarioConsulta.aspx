<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="CapaPresentacion.UsuarioConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>Consulta de Usuarios</h1>
            <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" OnRowCommand="grdUsuarios_RowCommand" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:ButtonField  Text="Modificar" CommandName="Modificar"/>
                    <asp:ButtonField Text="Eliminar" CommandName="Deleting" />
                </Columns>
            </asp:GridView>
        <br />
         <asp:Button ID="btnGuardar" runat="server" Text="Agregar" OnClick="btnNuevo_Click" CssClass="btn"/>
        <asp:Label ID="labelError" runat="server">Error</asp:Label>
    </div>
    </form>
</body>
</html>
