<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3a.aspx.cs" Inherits="WebApplication1.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TP4_grupo_7</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">

            <span class="titulo-seccion">SELECCIONAR TEMA</span>

            <div class="fila">
                <label>Tema:</label>
                <asp:DropDownList ID="ddlTemas" runat="server">
                    <asp:ListItem Value="1">Tema 1</asp:ListItem>
                    <asp:ListItem Value="2">Tema 2</asp:ListItem>
                    <asp:ListItem Value="3">Tema 3</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fila">
                <asp:Label ID="lblPrecio" runat="server" Text="Ordenar por precio:"></asp:Label>
                <asp:DropDownList ID="ddlPrecio" runat="server">
                    <asp:ListItem Value="ASC">Ascendente</asp:ListItem>
                    <asp:ListItem Value="DESC">Descendente</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fila">
                <asp:LinkButton ID="lbVerLibros" runat="server" OnClick="lbVerLibros_Click" CssClass="btn-link">Ver libros</asp:LinkButton>
            </div>

            <div class="botones">
                <asp:Button ID="btnWF1EJ3" runat="server" OnClick="Button1_Click" Text="Ir al WebForm 1" CssClass="btn" />
                <asp:Button ID="btnWF2EJ3" runat="server" OnClick="btnWF2EJ3_Click" Text="Ir al WebForm 2" CssClass="btn" />
            </div>

        </div>
    </form>
</body>
</html>