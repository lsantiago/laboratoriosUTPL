<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfColumnaCircularOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Analysis_McCOLUMNACIRC_wfColumnaCircular"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-ANALYSIS CIRCULAR COLUMN</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    
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
                                                    <asp:Label ID="lblGeneralTitle" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo"
                                                    valign="middle">
                                                        <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td rowspan="1" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                    width: 46%; border-top-color: activeborder; text-align: center; border-right-color: activeborder">
                                                                                <table style="width: 90%; height: 90%; border-top-width: 1px; border-top-color: activecaption;">
                                                                                    <tr>
                                                                                        <td colspan="2" style="height: 17px">
                                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSectionDiameter" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False" Font-Underline="False" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td style="width: 369px; height: 26px;" class="Funcionalidad-datos-entrada">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblSectionDiameter" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtConvertLB" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblConvertLB" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtLongBarDiameter" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongBarDiameter" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtNumberLongBars" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <asp:Label ID="lblNumberLongBars" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtTransverseReinfDiam" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblTransverseReinfDiam" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:DropDownList ID="ddTipo" runat="server" CssClass="Funcionalidad-etiqueta-dato"
                                                                                                Width="56px">
                                                                                                <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                                                <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                                            </asp:DropDownList></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <asp:Label ID="lblTipo" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtSpacingTransSteel" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblSpacingTransSteel" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td style="width: 81px; height: 14px;">
                                                                                            <asp:TextBox ID="txtAxialLoad" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td style="width: 369px; height: 14px;" align="left">
                                                                                                <asp:Label ID="lblAxialLoad" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td align="center" style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="txtShearSpan" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" Wrap="False"></asp:TextBox></td>
                                                                                        <td style="width: 369px; height: 14px" align="left">
                                                                                            <asp:Label ID="lblShearSpan" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td align="center" style="width: 81px; height: 14px">
                                                                                            <asp:DropDownList ID="ddmode" runat="server" CssClass="Funcionalidad-etiqueta-dato"
                                                                                                Width="56px">
                                                                                                <asp:ListItem Selected="True" Value="uniaxial">uniaxial</asp:ListItem>
                                                                                                <asp:ListItem Value="biaxial">biaxial</asp:ListItem>
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 369px; height: 14px" align="left">
                                                                                            <asp:Label ID="lblDmode" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td colspan="2" style="height: 17px">
                                                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="color: #222222">
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtConcrComprStrength" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblConcrComprStrength" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <a href="../../MC-Parameter/Beam/wfBeamOriginal.aspx">../../MC-Parameter/Beam/wfBeamOriginal.aspx</a>              <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtLongRYS" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongRYS" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 38px">
                                                                                            <asp:TextBox ID="txtTransRYS" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px; height: 38px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblTransRYS" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtIHardening" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 369px">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongRMX" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-datos-entrada" colspan="2" style="height: 30px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-datos-entrada" colspan="2" style="text-align: center">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="center">
                                                                                            <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="184px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="138px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                            </td>
                                                                            </tr>
                                                                        </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-datos-entrada" colspan="2">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                    <div style="text-align: center;">
                                                                        &nbsp;</div>
                                                                    <div style="text-align: center">
                                                                        <table style="width: 100%; height: 100%">
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
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                                <td style="width: 45%; text-align: center">
                                                                    <table style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td style="height: 193px">
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/Mc Analysis Circular.jpg" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 4px">
                                                                    <asp:Label ID="lblTituloEsquemaColumna" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 193px">
                                                                                <asp:Image ID="imgModeloConcreto" runat="server" />&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 21px">
                                                                                <asp:Label ID="lblmodeloC" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 193px">
                                                                                <asp:Image ID="imgModeloAcero" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 21px">
                                                                                <asp:Label ID="lblmodeloA" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkExperimento" style="width: 80%; height: 150px">linkExperimento</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="height: 48px" valign="middle">
                                                                            <asp:Label ID="lblResults" runat="server" CssClass="Funcionalidad-titulo" Font-Size="X-Large"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                                            <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblAnalysis" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblTituloMCR" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="1" style="width: 50%">
                                                                                <table style="width: 90%; height: 90%">
                                                                                    <tr>
                                                                                        <td colspan="3" style="height: 18px">
                                                                                            <asp:Label ID="lblTituloAnalysisIndex" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%; height: 22px;">
                                                                                            <asp:Label ID="lblLongRR" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Font-Italic="False" Font-Underline="False"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt; height: 22px;">
                                                                                            <span><span style="font-size: 10pt"><span style="color: #000000; font-family: Symbol">
                                                                                                <img src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" id="imgCargaAxial" /></span></span></span></td>
                                                                                        <td style="width: 20%; font-size: 8pt; height: 22px;">
                                                                                            <asp:TextBox ID="txtLongRR" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblTransRR" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <img src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" id="imgAceroTrans" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtTransRR" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblAxialLoadRatio" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <img src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" id="imgPorcCargaAxial" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtAxialLoadRatio" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt; color: #222222">
                                                                                        <td style="width: 60%">
                                                                                        </td>
                                                                                        <td style="width: 97px">
                                                                                        </td>
                                                                                        <td style="width: 100px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt; color: #222222">
                                                                                        <td colspan="3" style="height: 15px">
                                                                                            <asp:Label ID="lblAnalysisResult" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblMomentoPrimeraFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <span style="font-size: 7pt">
                                                                                                <asp:Image ID="imgMomentoPrimeraFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" /></span></td>
                                                                                        <td style="font-size: 8pt; width: 100px">
                                                                                                                <asp:TextBox ID="txtMomentoPrimeraFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblPrimeraCurvaturaFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <asp:Image ID="imgPrimeraCurvaturaFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtPrimeraCurvaturaFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%; height: 32px;">
                                                                                            <asp:Label ID="lblMomentoNominal" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt; height: 32px;">
                                                                                            <span style="font-size: 7pt">
                                                                                                <asp:Image ID="imgMomentoNominal" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" /></span></td>
                                                                                        <td style="width: 100px; font-weight: bold; font-size: 8pt; color: #000000; height: 32px;">
                                                                                                                <asp:TextBox ID="txtMomentoNominal" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblCurvaturaFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" /></td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                            <asp:TextBox ID="txtCurvaturaFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblIncerciaAgrietada" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <asp:Image ID="imgAgrietada" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" /></td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                            <asp:TextBox ID="txtInercia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%; height: 20px;">
                                                                                            <asp:Label ID="lblConcreteStrain" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px; height: 20px;">
                                                                                            </td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000; height: 20px;">
                                                                                            <asp:TextBox ID="txtconcreteStrengh" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                   
                                                                                
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores">
                                                                                            <asp:Label ID="lblDamageMoment" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            </td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtdamageMoment" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="height: 16px">
                                                                                            <asp:Label ID="lbldamageCurvatura" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px; height: 16px;">
                                                                                        </td>
                                                                                        <td style="font-size: 8pt; width: 100px; height: 16px;">
                                                                                            <asp:TextBox ID="txtdamagecurvatura" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="height: 16px">
                                                                                            <asp:Label ID="lblsloperatio" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px; height: 16px">
                                                                                        </td>
                                                                                        <td style="font-size: 8pt; width: 100px; height: 16px">
                                                                                            <asp:TextBox ID="txtsloperatio" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                </table>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="height: 20px" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                                                        <asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="800px" CssClass="texto-interno-pequeno"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle">
                                                    <div style="text-align: center">
                                                        <div style="text-align: center">
                                                            <div style="text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td colspan="2" rowspan="1">
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
