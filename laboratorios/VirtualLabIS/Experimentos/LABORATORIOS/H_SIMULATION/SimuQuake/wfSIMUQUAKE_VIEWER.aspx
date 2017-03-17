<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfSIMUQUAKE_VIEWER.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_wfSIMUQUAKE_VIEWER"%>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<%--Controles para las Gráficas--%>
<%@ Reference Control="ModuloGrafcSismo/ctrlGraficSismos.ascx" %>
<%@ Reference Control="ModuloGrafcSismo/ctrlGraficAcelDespSpectral.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SIMUQUAKE VIEWER</title>
    <link href="../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <%--<script language="javascript" src="Scripts/jsActualizarControles.js" type="text/javascript"></script>--%>
    
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmdVerGrafc_onclick() {
    var getObj = function(id) {    return document.getElementById ? document.getElementById(id) : document.all[id]; }
    var hiddIndicador_html = getObj("hiddIndicador");
    hiddIndicador_html.value = "true"
    var boolIndicador = hiddIndicador_html.value    
}

// ]]>
</script>
</head>
<body style="color: #000000">
    <form id="frmMain" runat="server">
    <div>
        <div style="text-align: center">
            <div style="text-align: center">
                <div style="text-align: center">
                    <div style="text-align: center">
                        <div style="text-align: center" class="Funcionalidad-cuerpo">
                            <table style="width: 90%; height: 100%">                                
                                <tr>
                                    <td align="center" valign="middle">
                                        <table style="width: 100%; height: 95%" class="Tabla-Principales">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 80%; height: 12pt"
                                                    valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 80px;" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="SIMUQUAKE VIEWER" CssClass="Funcionalidad-titulo"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 80px" valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 70%;">
                                                        <tr>
                                                            <td colspan="2" style="height: 20px" class="PanelHeader">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px; text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                <div style="text-align: center">
                                                                    <table>
                                                                        <tr>
                                                                            <td colspan="3" style="text-align: left">
                                                                                <asp:Label ID="lblTituloCargarSismo" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="LOAD SIMULATED EARTHQUAKE"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center">
                                                                                <asp:FileUpload ID="fupSismoEntrada" runat="server" CssClass="Boton" /></td>
                                                                            <td style="text-align: center">
                                                                                <asp:Button ID="cmdSismoEntrada" runat="server" Text="LOAD FILE" CssClass="Boton" Width="100px" /></td>
                                                                            <td style="text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="text-align: left">
                                                                    <asp:Label ID="lblMensajes" runat="server" CssClass="Funcionalidad-Mensajes-Links" Font-Size="Small"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="text-align: left">
                                                                                <asp:Button ID="cmdVerGrafc" runat="server" CssClass="Boton" Enabled="False" Text="VIEW CHART" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 20px; text-align: center">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                <div style="text-align: center">
                                                                    <table style="width: 75%; border-right: #dde1e3 2px solid; border-top: #dde1e3 2px solid; border-left: #dde1e3 2px solid; border-bottom: #dde1e3 2px solid;" id="tblGraficSismos" runat="server">
                                                                        <tr>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblTituloGraficSismo" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="SIMULATED EARTHQUAKES"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:PlaceHolder ID="phlWcvSismo" runat="server"></asp:PlaceHolder>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
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
                                                            <td colspan="2" style="height: 30px; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: center"><table style="width: 75%; border-right: #dde1e3 2px solid; border-top: #dde1e3 2px solid; border-left: #dde1e3 2px solid; border-bottom: #dde1e3 2px solid;" id="Table1" runat="server">
                                                                <tr>
                                                                    <td style="height: 20px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTituloAcelerEspectral" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                            Text="ACCELERATION SPECTRAL"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:PlaceHolder ID="phlAcelerEspectral" runat="server"></asp:PlaceHolder>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: center">
                                                                <table style="width: 75%; border-right: #dde1e3 2px solid; border-top: #dde1e3 2px solid; border-left: #dde1e3 2px solid; border-bottom: #dde1e3 2px solid;" id="Table2" runat="server">
                                                                    <tr>
                                                                        <td style="height: 20px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblTituloDesplazEspectral" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                Text="DISPLACEMENT SPECTRAL"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 16px">
                                                                            <asp:PlaceHolder ID="phlDesplazEspectral" runat="server"></asp:PlaceHolder>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 15px">
                                                                <div style="text-align: center">
                                                                    &nbsp;</div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 30px" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 50%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                    <asp:Label ID="lblMensajesFiles" runat="server" CssClass="Funcionalidad-Mensajes-Links" Font-Size="Small"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <asp:LinkButton ID="lbDownload" runat="server">HERE</asp:LinkButton>&nbsp;&nbsp;
                                                                    <asp:Image ID="imgDownload" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/Puente/Imagenes/Download.gif"
                                                                        Style="position: static" Visible="False" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1" style="text-align: center">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1" style="text-align: center">
                                                                    <asp:Label ID="lblInformacion" runat="server" CssClass="texto-interno-pequeno"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%; height: 112px;" valign="middle">
                                                    <span style="color: #000000">Copyright © 2006 - 2008 VirtualLab UTPL. All rights reserved.
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" style="width: 80%">
                                        <asp:HiddenField ID="hiddIndicador" runat="server" Value="false" />
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
