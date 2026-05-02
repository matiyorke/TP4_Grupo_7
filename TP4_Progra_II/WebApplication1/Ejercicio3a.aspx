<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3a.aspx.cs" Inherits="WebApplication1.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div  id class= "contenedor">  Seleccionar Tema:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server">
                <asp:ListItem Value="1">Tema 1</asp:ListItem>
                <asp:ListItem Value="2">Tema 2</asp:ListItem>
                <asp:ListItem Value="3">Tema 3</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:LinkButton ID="lbVerLibros" runat="server" OnClick="lbVerLibros_Click">Ver libros</asp:LinkButton>
        </div>
    </form>
</body>
</html>
