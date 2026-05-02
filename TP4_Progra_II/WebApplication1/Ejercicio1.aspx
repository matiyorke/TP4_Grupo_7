<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="WebApplication1.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TP4_grupo_7</title>
    <style>
        body {
            background-color: #4a7fa5;
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            padding-top: 150px;
            margin: 0;
            min-height: 100vh;
            gap: 30px;
            align-items: flex-start;
        }

        form {
            display: flex;
            justify-content: center;
            gap: 30px;
            width: 100%;
        }

        .contenedor {
            background-color: #2c5f8a;
            border: 2px solid #f0c040;
            border-radius: 14px;
            padding: 40px 60px;
            width: 480px;
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.4);
            height: fit-content;
        }

        .titulo-seccion {
            color: #ffffff;
            font-size: 16px;
            font-weight: bold;
            text-decoration: underline;
            margin-bottom: 15px;
            display: block;
        }

        .fila {
            display: flex;
            align-items: center;
            margin-bottom: 14px;
            gap: 15px;
        }

        .fila label {
            color: #ffffff;
            font-size: 14px;
            font-weight: bold;
            width: 100px;
        }

        select {
            background-color: #ffffff;
            color: #000000;
            border: 1px solid #f0c040;
            border-radius: 6px;
            padding: 6px 10px;
            font-size: 14px;
            width: 200px;
            cursor: pointer;
        }

        select:focus {
            outline: none;
            border-color: #f0c040;
        }

        .separador {
            border: none;
            border-top: 1px solid #f0c040;
            margin: 20px 0;
        }

        /*[NUEVO] Estilo del panel de resumen a la derecha*/
        .resumen-panel {
            background-color: #2c5f8a;
            border: 2px solid #f0c040;
            border-radius: 14px;
            padding: 40px 40px;
            width: 280px;
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.4);
            height: fit-content;
        }

        .resumen-titulo {
            color: #f0c040;
            font-size: 16px;
            font-weight: bold;
            text-decoration: underline;
            margin-bottom: 15px;
            display: block;
        }

        .resumen-texto {
            color: #ffffff;
            font-size: 14px;
            font-weight: bold;
        }
    </style>
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
                    <asp:DropDownList ID="ddlLocalidad1" runat="server"></asp:DropDownList>
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
                    <asp:DropDownList ID="ddlLocalidad2" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

       </div>

       <%-- Panel de resumen a la derecha del cartel principal--%>
       <div class="resumen-panel">
           <span class="resumen-titulo">RESUMEN DEL VIAJE</span>
           <asp:Label ID="lblResumen" runat="server" Visible="False" CssClass="resumen-texto"></asp:Label>
       </div>

    </form>
</body>
</html>