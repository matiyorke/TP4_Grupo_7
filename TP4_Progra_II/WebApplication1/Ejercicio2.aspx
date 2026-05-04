<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="WebApplication1.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id class= "contenedor">  <%--clase "contenedor" para todos los campos--%>IdProducto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            <br />
            IdCategoria:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
            <br />
            IdProveedor:&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProveedor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblStock" runat="server" Text="Stock"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnQuitar" runat="server" Text="Quitar Filtro" OnClick="btnQuitar_Click" />
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblError" runat="server" Font-Italic="True" ForeColor="#333333"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblResultados" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvProdCat" runat="server">
            </asp:GridView>
        &nbsp;<asp:Button ID="btnWF1EJ2" runat="server" OnClick="btnWF1EJ2_Click" Text="Ir a WebForm 1" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnWF3EJ2" runat="server" OnClick="btnWF3EJ2_Click" Text="Ir a WebForm 3" />
            &nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
