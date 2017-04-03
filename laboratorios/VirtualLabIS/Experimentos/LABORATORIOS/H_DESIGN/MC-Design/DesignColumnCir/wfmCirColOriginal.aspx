<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfmCirColOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_DesignColumnCir_wfmCirCol"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-DESIGN CIRCULAR COLUMN</title>
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
                            .<table style="width: 60%; height: 100%">
                                <tr>
                                    <td align="center" style="width: 78%" valign="middle">
                                        &nbsp;<table class="Tabla-Principales" style="width: 100%; height: 95%">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1107px" valign="middle">
                                                    <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 1107px; height: 12pt"
                                                    valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo"
                                                    valign="middle">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <asp:Label ID="lblTitle" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr style="color: #000000">
                                                <td align="center" class="Funcionalidad-titulo" style="width: 50%; text-align: center"
                                                    valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                        <tr>
                                                            <td rowspan="1" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                width: 44%; border-top-color: activeborder; text-align: center; border-right-color: activeborder; height: 924px;">
                                                                <table style="border-top-width: 1px; width: 90%; border-top-color: activecaption;">
                                                                    <tr>
                                                                        <td colspan="2" style="height: 20px">
                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtdiameter" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <strong>
                                                                                <asp:Label ID="lblbase" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="178px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtNumBars" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada">
                                                                            <asp:Label ID="lblaltura" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="230px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtSpacingStirrups" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px;">
                                                                            <strong>
                                                                                <asp:Label ID="lblSpacingStirrups" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="192px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtcoverRebar" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <asp:Label ID="lblCoverLateral" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="246px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtShearSpan" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                                <asp:Label ID="lblShearSpan" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="font-weight: bold">
                                                                        <td colspan="2" style="height: 20px">
                                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="color: #222222">
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtConcrComprStrength" runat="server" AutoCompleteType="Disabled"
                                                                                CssClass="Funcionalidad-textbox-habilitado" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <strong>
                                                                                <asp:Label ID="lblConcrComprStrength" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="200px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtfyLong" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px;">
                                                                            <strong>
                                                                                <asp:Label ID="lblLongFy" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="179px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtfyTrans" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <strong>
                                                                                <asp:Label ID="lblTransFy" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="176px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 20px" colspan="2">
                                                                            <asp:Label ID="lblDesignForces" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 26px">
                                                                            <asp:TextBox ID="txtAxialLoad" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <asp:Label ID="lblAxialLoad" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 26px">
                                                                            <asp:TextBox ID="txtMoment" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 26px">
                                                                            <asp:Label ID="lblMoment" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 20px">
                                                                        </td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px; height: 20px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                    <table style="width: 90%">
                                                                        <tr>
                                                                            <td style="width: 100%; height: 100%">
                                                                                <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="184px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%; height: 100%">
                                                                                <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="146px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%; height: 131%">
                                                                                </td>
                                                                        </tr>
                                                                    </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 249px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <div style="text-align: center">
                                                                </div>
                                                                <div style="text-align: right">
                                                                    <div style="text-align: right">
                                                                        <div style="text-align: center">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div style="text-align: center">
                                                                    &nbsp;</div>
                                                                <table style="width: 80%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblMensajeRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                Width="100%"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="text-align: center">
                                                                            <asp:HyperLink ID="hplRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                Visible="False">[hplRegistrarse]</asp:HyperLink></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 50%; height: 924px; text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td style="height: 204px">
                                                                            &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/Mc Analysis Circular.jpg" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 8px">
                                                                <asp:Label ID="lblTituloEsquemaColumna" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 157px">
                                                                            <asp:Image ID="imgModeloConcreto" runat="server" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 8px">
                                                                            <asp:Label ID="lblConcreteModel" runat="server" Width="277px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 202px">
                                                                            <asp:Image ID="imgModeloAcero" runat="server" /></td>
                                                                    </tr>
                                                                </table>
                                                                <div style="text-align: center">
                                                                </div>
                                                                <div style="text-align: center">
                                                                </div>
                                                                <div style="text-align: center">
                                                                    <asp:Label ID="lblSteelModel" runat="server" Width="277px"></asp:Label></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 1107px; height: 36px"
                                                    valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1107px; height: 100%" valign="middle">
                                                    <a name="#linkExperimento" style="width: 80%; height: 100%">linkExpe<asp:Label ID="lblDesignResults"
                                                        runat="server" CssClass="Funcionalidad-titulo" Font-Size="X-Large"></asp:Label>rimento</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1107px; height: 100%" valign="middle">
                                                    <div style="text-align: center">
                                                        <div style="text-align: center">
                                                            <div style="text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 100%">
                                                                            <table class="TablaDatos-Graficas" style="width: 25%; height: 90%">
                                                                                <tr>
                                                                                    <td align="center" colspan="2" rowspan="2" style="width: 70%; height: 70%">
                                                                                        <table style="width: 90%; height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 18px">
                                                                                                    <asp:Label ID="lblTituloAnalysisIndex" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblDiameterLongitudinal" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 43px">
                                                                                                    <asp:TextBox ID="txtDiameterLongitudinal" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt; color: #222222">
                                                                                                <td colspan="2">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt; color: #222222">
                                                                                                <td colspan="2" style="height: 15px">
                                                                                                    <asp:Label ID="lblAnalysisResult" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblDiameterStirrup" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 43px">
                                                                                                    <asp:TextBox ID="txtDiameterStirrup" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="font-size: 8pt; height: 239px">
                                                                                                    <asp:TextBox ID="TextBox1" runat="server" Height="228px" TextMode="MultiLine" Width="495px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 570%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 658%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 658%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 100%">
                                                                            <asp:Label ID="lblMCResults" runat="server" CssClass="Funcionalidad-titulo" Font-Size="X-Large"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 175%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="width: 100%; height: 100%">
                                                                            <asp:Label ID="lblMomentResponse" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="width: 100%; height: 100%">
                                                                            <table class="TablaDatos-Graficas" style="width: 80%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblAnalysis" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblMCResponse" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="1" style="width: 50%">
                                                                                        <table style="width: 90%; height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 18px">
                                                                                                    <asp:Label ID="lblAnalysisIndexes" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%; height: 22px">
                                                                                                    <asp:Label ID="lblLongRR" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                        Font-Italic="False" Font-Underline="False" Width="217px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                    <span><span style="font-size: 10pt"><span style="color: #000000; font-family: Symbol">
                                                                                                        <img id="imgCargaAxial" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" /></span></span></span></td>
                                                                                                <td style="font-size: 8pt; width: 20%; height: 22px">
                                                                                                    <asp:TextBox ID="txtLongRR1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblTransRR" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <img id="imgAceroTrans" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtTransRR1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblAxialLoadRatio" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <img id="imgPorcCargaAxial" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtAxialLoadRatio1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt; color: #222222">
                                                                                                <td style="width: 60%">
                                                                                                </td>
                                                                                                <td style="width: 95px">
                                                                                                </td>
                                                                                                <td style="width: 100px">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt; color: #222222">
                                                                                                <td colspan="3" style="height: 15px">
                                                                                                    <asp:Label ID="lblAnalysisResults" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblMomentoPrimeraFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <span style="font-size: 7pt">
                                                                                                        <asp:Image ID="imgMomentoPrimeraFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" /></span></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtMomentoPrimeraFluencia1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblPrimeraCurvaturaFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="imgPrimeraCurvaturaFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="tbPrimeraCurvaturaFluencia1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblMomentoNominal" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <span style="font-size: 7pt">
                                                                                                        <asp:Image ID="imgMomentoNominal" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" /></span></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbMomentoNominal1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblCurvaturaFluencia" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" /></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbCurvaturaFluencia1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblIncerciaAgrietada" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="imgAgrietada" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" /></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbIncerciaAgrietada1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%; height: 20px;">
                                                                                                    <asp:Label ID="lbldefConc" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Width="205px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 20px;">
                                                                                                </td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000; height: 20px;">
                                                                                                    <asp:TextBox ID="txtDefMomNom1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="height: 20px">
                                                                                                    <asp:Label ID="lblDamConMom" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 20px;">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px; height: 20px;">
                                                                                                    <asp:TextBox ID="txtDamageControl1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="height: 22px">
                                                                                                    <asp:Label ID="lblDamageControl" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px; height: 22px">
                                                                                                    <asp:TextBox ID="txtDamCon1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="height: 22px">
                                                                                                    <asp:Label ID="lblSlopeRatio" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px; height: 22px">
                                                                                                    <asp:TextBox ID="txtSlopeRatio1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <chart:WebChartViewer ID="WebChartViewer1" runat="server" BorderColor="White" SelectionBorderColor="Transparent"
                                                                                            Style="position: static" /></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="width: 100%; height: 100%">
                                                                            </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="width: 100%; height: 100%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 127px">
                                                                            <asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="800px" CssClass="texto-interno-pequeno"></asp:TextBox></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1107px; height: 11px" valign="middle">
                                                    <span style="color: #000000">&nbsp;&nbsp; Copyright © 2006 - 2008 VirtualLab UTPL. All rights reserved. </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 78%" valign="middle">
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
