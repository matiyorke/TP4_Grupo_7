<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="WebApplication1.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TP4_grupo_7</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">     
       <div id class= "contenedor">  <%--clase "contenedor" para todos los campos--%>
        <div>
            <asp:Label ID="lblDestinoInicio" runat="server" Font-Underline="True" Text="DESTINO INICIO: "></asp:Label>
            <br />
            <br />
        </div>
        <asp:Label ID="lblProvincia1" runat="server" Font-Bold="True" Text="PROVINCIA: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlProvincia1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblLocalidad1" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlLocalidad1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblDestinoFinal" runat="server" Font-Underline="True" Text="DESTINO FINAL:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblProvincia2" runat="server" Font-Bold="True" Text="PROVINCIA:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlProvincia2" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblLocalidad2" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlLocalidad2" runat="server">
        </asp:DropDownList>
       </div>
    </form>
</body>
</html>
