<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3_web2.aspx.cs" Inherits="WebApplication1.Ejercicio3_web2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TP4_grupo_7</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor-wide">

            <span class="titulo-seccion">LISTADO DE LIBROS</span>

            <asp:Label ID="Label1" runat="server" CssClass="lbl-resultado"></asp:Label>

            <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="True">
            </asp:GridView>

            <div class="fila" style="margin-top: 15px;">
                <asp:Label ID="lblTotal" runat="server" CssClass="lbl-resultado"></asp:Label>
                <asp:Label ID="lblCantidad" runat="server" CssClass="lbl-resultado"></asp:Label>
            </div>

            <div class="botones">
                <asp:LinkButton ID="libVolver" runat="server" OnClick="libVolver_Click" CssClass="btn-link">Consultar otro tema</asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>