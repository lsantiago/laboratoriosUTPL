<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfColumCircOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Parameter_ColumCirc_wfColumCirc"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-PARAMETER CIRCULLAR COLUMN</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../../../Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    
</head>
<body style="color: #000000">
    <form id="frmMain" runat="server">
    <div>
        <div style="text-align: center">
            <div style="text-align: center">
                <div style="text-align: center">
                    <div style="text-align: center">
                        <div style="text-align: center" class="Funcionalidad-cuerpo">
                            <table style="width: 60%; height: 100%">                                
                                <tr>
                                    <td align="center" valign="middle" style="width: 80%">
                                        &nbsp;<table style="width: 100%; height: 95%" class="Tabla-Principales">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12pt" valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <asp:Label ID="lblTituloGeneral" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/Mc Analysis Circular.jpg" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSectionGraf" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNumSections" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtNumberSections" runat="server" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="text-align: center">
                                                                        <table style="width: 90%; height: 90%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                                </td>
                                                                                <td colspan="10">
                                                                    <asp:Label ID="lblInputData1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; height: 16px;">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                                <td style="height: 16px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                                    <asp:Label ID="lblSectionNumber" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label16" runat="server" Text="1" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text="2" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text="3" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label19" runat="server" Text="4" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server" Text="5" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label21" runat="server" Text="6" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label22" runat="server" Text="7" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label23" runat="server" Text=" 8" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label24" runat="server" Text="9" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label25" runat="server" Text="10" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="11" style="text-align: center">
                                                                    <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblSectionDiameter" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtdiameter10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblCoverMain" runat="server" CssClass="Funcionalidad-datos-entrada" Width="304px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtcoverMain10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>  
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblDiamMain" runat="server" CssClass="Funcionalidad-datos-entrada" Width="176px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamMain10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblNumMainBars" runat="server" CssClass="Funcionalidad-datos-entrada" Width="176px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumMain10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblDiamTrans" runat="server" CssClass="Funcionalidad-datos-entrada" Width="256px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTrans10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; height: 8px;">
                                                                    <asp:Label ID="lblSpacingTrans" runat="server" CssClass="Funcionalidad-datos-entrada" Width="254px"></asp:Label></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 8px">
                                                                    <asp:TextBox ID="txtpacingTrans10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblTypeTrans" runat="server" CssClass="Funcionalidad-datos-entrada" Width="204px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo1" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo2" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo3" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo4" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo5" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo6" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo7" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo8" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo9" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                    <asp:DropDownList ID="ddTipo10" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                        Width="56px">
                                                                        <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                        <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblAxialLoad" runat="server" CssClass="Funcionalidad-datos-entrada" Width="94px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtAxialLoad10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblShearSpan" runat="server" CssClass="Funcionalidad-datos-entrada" Width="98px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtShearSpan10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center" colspan="11">
                                                                    <asp:Label ID="lblTituloMaterialProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblFc" runat="server" CssClass="Funcionalidad-datos-entrada" Width="216px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtfc10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblFyLon" runat="server" CssClass="Funcionalidad-datos-entrada" Width="190px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyLong10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblFyTrans" runat="server" CssClass="Funcionalidad-datos-entrada" Width="226px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtFyTrans10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblSteelRatio" runat="server" CssClass="Funcionalidad-datos-entrada" Width="132px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSteelRatio10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="text-align: center">
                                                                        <table style="width: 40%">
                                                                            <tr>
                                                                                <td>
                                                                                            <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="184px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="260px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                            </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                                <asp:Label ID="lblMensajeRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                                    Width="100%"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                                <asp:HyperLink ID="hplRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                                    Visible="False">[hplRegistrarse]</asp:HyperLink></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkExperimento" style="width: 80%; height: 150px">linkExperimento</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%; height: 100%" valign="middle">
                                                    <div style="text-align: center">
                                                        <div style="text-align: center">
                                                            <div style="text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td colspan="2" rowspan="1" style="height: 48px">
                                                                            <asp:Label ID="lblResults" runat="server" CssClass="Funcionalidad-titulo" Font-Size="X-Large"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" rowspan="1" style="height: 737px">
                                                                            <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 1480px">
                                                                                        </td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="text-align: center">
                                                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblTituloMCR" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px">
                                                                                        </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80%; text-align: center;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer2" runat="server" BorderColor="White" SelectionBorderColor="Transparent"
                                                                                            Style="position: static" /></td>
                                                                                    <td style="width: 50%; text-align: left">
                                                                                        <asp:Label ID="lblFigura2" runat="server" CssClass="texto" Height="83px"
                                                                                            Width="230px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 16px;" colspan="2">
                                                                                        <asp:Label ID="lblTituloFig1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px">
                                                                                        </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px; text-align: center;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer3" runat="server" /></td>
                                                                                    <td style="width: 50%; text-align: left">
                                                                                        <asp:Label ID="lblFigura3" runat="server" CssClass="texto" Height="83px"
                                                                                            Width="229px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblTituloFig2" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px">
                                                                                        </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px; text-align: center;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer4" runat="server" /></td>
                                                                                    <td style="width: 50%; text-align: left">
                                                                                        <asp:Label ID="lblFigura4" runat="server" CssClass="texto"
                                                                                            Width="231px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblTituloFig3" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px">
                                                                                        </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px; text-align: center;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer5" runat="server" /></td>
                                                                                    <td style="width: 50%; text-align: left">
                                                                                        <asp:Label ID="lblFigura5" runat="server" CssClass="texto"
                                                                                            Width="231px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblTituloFig5" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px">
                                                                                        </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 1480px; text-align: center;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer6" runat="server" /></td>
                                                                                    <td style="width: 50%; text-align: left">
                                                                                        <asp:Label ID="lblFigura6" runat="server" CssClass="texto"
                                                                                            Width="231px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 15px">
                                                                                        <asp:Label ID="lblTituloFig6" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" rowspan="1" style="height: 190px">
                                                                                        <asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="800px" CssClass="texto-interno-pequeno"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Label ID="Label1" runat="server" Text="Copyright © 2006 - 2008 VirtualLab UTPL. All rights reserved. "></asp:Label></td>
                                            </tr>                                                                                     
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 80%" valign="middle">
                                        <asp:HiddenField ID="hiddNumTest" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
