<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3_web2.aspx.cs" Inherits="WebApplication1.Ejercicio3_web2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id class= "contenedor">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:LinkButton ID="libVolver" runat="server" OnClick="libVolver_Click">Volver</asp:LinkButton>
        </div>
    </form>
</body>
</html>
