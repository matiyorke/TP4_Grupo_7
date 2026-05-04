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
       <div class="contenedor">  <%--clase "contenedor" para todos los campos--%>

            <div class="seccion">
                <asp:Label ID="lblDestinoInicio" runat="server" CssClass="titulo-seccion" Font-Underline="True" Text="DESTINO INICIO:"></asp:Label>

                <div class="fila">
                    <asp:Label ID="lblProvincia1" runat="server" Font-Bold="True" Text="PROVINCIA:"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia1_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="fila">
                    <asp:Label ID="lblLocalidad1" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidad1_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <hr class="separador" />

            <div class="seccion">
                <asp:Label ID="lblDestinoFinal" runat="server" CssClass="titulo-seccion" Font-Underline="True" Text="DESTINO FINAL:"></asp:Label>

                <div class="fila">
                    <asp:Label ID="lblProvincia2" runat="server" Font-Bold="True" Text="PROVINCIA:"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia2_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="fila">
                    <asp:Label ID="lblLocalidad2" runat="server" Font-Bold="True" Text="LOCALIDAD:"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidad2_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="botones">
                <asp:Button ID="btnWF2EJ1" runat="server" OnClick="btnWF2EJ1_Click" Text="Ir al WebForm 2" CssClass="btn" />
                <asp:Button ID="btnWF3EJ1" runat="server" OnClick="btnWF3EJ1_Click" Text="Ir al WebForm 3" CssClass="btn" />
            </div>

       </div>

       <div class="resumen-panel">
           <span class="resumen-titulo">RESUMEN DEL VIAJE</span>
           <asp:Label ID="lblResumen" runat="server" Visible="False" CssClass="resumen-texto"></asp:Label>
       </div>

    </form>
</body>
</html>