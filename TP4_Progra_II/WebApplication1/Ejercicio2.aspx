<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="WebApplication1.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TP4_grupo_7</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor-wide">  <%--clase "contenedor" para todos los campos--%>

            <span class="titulo-seccion">FILTROS</span>

            <div class="fila">
                <label>IdProducto:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl-filtro">
                    <asp:ListItem Value="0">Igual a:</asp:ListItem>
                    <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="2">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtProducto" runat="server" CssClass="txt-filtro"></asp:TextBox>
            </div>

            <div class="fila">
                <label>IdCategoria:</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="ddl-filtro">
                    <asp:ListItem Value="0">Igual a:</asp:ListItem>
                    <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="2">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="txt-filtro"></asp:TextBox>
            </div>

            <div class="fila">
                <label>IdProveedor:</label>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="ddl-filtro">
                    <asp:ListItem Value="0">Igual a:</asp:ListItem>
                    <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="2">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtProveedor" runat="server" CssClass="txt-filtro"></asp:TextBox>
            </div>

            <div class="fila">
                <label>Stock:</label>
                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="ddl-filtro">
                    <asp:ListItem Value="0">Igual a:</asp:ListItem>
                    <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                    <asp:ListItem Value="2">Menor a:</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtStock" runat="server" CssClass="txt-filtro"></asp:TextBox>
            </div>

            <div class="fila">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click1" CssClass="btn" />
                <asp:Button ID="btnQuitar" runat="server" Text="Quitar Filtro" OnClick="btnQuitar_Click" CssClass="btn" />
                <asp:Label ID="lblError" runat="server" Font-Italic="True" CssClass="lbl-error"></asp:Label>
                <asp:Label ID="lblResultados" runat="server" CssClass="lbl-resultado"></asp:Label>
            </div>

            <asp:GridView ID="gvProdCat" runat="server" CssClass="grid" AutoGenerateColumns="True">
            </asp:GridView>

            <div class="botones">
                <asp:Button ID="btnWF1EJ2" runat="server" OnClick="btnWF1EJ2_Click" Text="Ir a WebForm 1" CssClass="btn" />
                <asp:Button ID="btnWF3EJ2" runat="server" OnClick="btnWF3EJ2_Click" Text="Ir a WebForm 3" CssClass="btn" />
            </div>

        </div>
    </form>
</body>
</html>