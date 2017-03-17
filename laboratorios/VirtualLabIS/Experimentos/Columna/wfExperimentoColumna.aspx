<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfExperimentoColumna.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_Columna_wfExperimentoColumna"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="ctlLinksFig.ascx" TagName="ctlLinksFig" TagPrefix="uc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MOMENT-CURVATURE ANALYSIS</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    <link href="../../../VirtualLabIS/Varios/Archivos/Styles/cssVentanaEmergente.css"
        rel="stylesheet" type="text/css" />
    

    
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
                                    <td align="center" valign="middle" style="width: 80%">
                                        &nbsp;<table style="width: 100%; height: 95%" class="Tabla-Principales">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 80%; height: 12pt" valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 80px;" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="VIRTUAL SETUP FOR MOMENT-CURVATURE ANALYSIS <br> OF CIRCULAR REINFORCED CONCRETE COLUMNS" CssClass="Funcionalidad-titulo"></asp:Label><br />
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo"
                                                    valign="middle">
                                                        <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td class="PanelHeader" rowspan="1" style="border-top-width: 2px; border-left-width: 2px;
                                                                    border-left-color: activeborder; border-bottom-width: 2px; border-bottom-color: activeborder;
                                                                    width: 50%; border-top-color: activeborder; text-align: center; border-right-width: 2px;
                                                                    border-right-color: activeborder">
                                                                    <asp:Label ID="lblInputData1" runat="server" CssClass="Funcionalidad-titulo" Text="INPUT DATA"></asp:Label></td>
                                                                <td class="PanelHeader" style="width: 50%; text-align: center">
                                                                    <asp:Label ID="lblTituloEsquemaColumna" runat="server" CssClass="Funcionalidad-titulo" Text="SECTION"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td rowspan="3" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                    width: 50%; border-top-color: activeborder; text-align: center; border-right-color: activeborder">
                                                                                <table style="width: 90%; height: 90%; border-top-width: 1px; border-top-color: activecaption;">
                                                                                    <tr>
                                                                                        <td colspan="2" style="height: 17px">
                                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="SECTION PROPERTIES" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSectionDiameter" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False" Font-Underline="False" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td style="width: 100%; height: 26px;" class="Funcionalidad-datos-entrada">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblSectionDiameter" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Text="SECTION DIAMETER D(mm)"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtConvertLB" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblConvertLB" runat="server" Font-Bold="False" Text="COVER r (mm)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtLongBarDiameter" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongBarDiameter" runat="server" Font-Bold="False" Text="LONGITUDINAL REBAR DIAMETER dbl (mm)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtNumberLongBars" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblNumberLongBars" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Text="# LONGITUDINAL REBARS"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtTransverseReinfDiam" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblTransverseReinfDiam" runat="server" Font-Bold="False" Text="TRANSVERSE REBAR DIAMETER dbt (mm)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:DropDownList ID="ddTipo" runat="server" CssClass="Funcionalidad-etiqueta-dato"
                                                                                                Width="56px">
                                                                                                <asp:ListItem Selected="True" Value="spirals">Spirals</asp:ListItem>
                                                                                                <asp:ListItem Value="hoops">Hoops</asp:ListItem>
                                                                                            </asp:DropDownList></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblTipo" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Text="TRANSVERSE REINFORCEMENT TYPE"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtSpacingTransSteel" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblSpacingTransSteel" runat="server" Font-Bold="False" Text="SPACING OF TRANSVERSE REBAR et(mm)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td style="width: 81px; height: 14px;">
                                                                                        </td>
                                                                                        <td style="width: 100px; height: 14px;">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td colspan="2" style="height: 17px">
                                                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" Text="MATERIAL PROPERTIES" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="color: #222222">
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtConcrComprStrength" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblConcrComprStrength" runat="server" Font-Bold="False" Text="UNCONFINED COMPRESION CONCRETE STRENGTH f'ce (Mpa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtLongRYS" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongRYS" runat="server" Font-Bold="False" Text="YIELD STRESS OF LONGITUDINAL REBAR fy (Mpa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 38px">
                                                                                            <asp:TextBox ID="txtTransRYS" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%; height: 38px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblTransRYS" runat="server" Font-Bold="False" Text="YIELD STRESS OF TRANSVERSE REBAR fyh (Mpa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtLongRMX" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongRMX" runat="server" Font-Bold="False" Text="ULIMATE TENSION STRENGTH OF LONGITUDINAL REBAR fu (Mpa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtAxialLoad" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblAxialLoad" runat="server" Font-Bold="False" Text="AXIAL LOAD P (KN)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                                                <asp:TextBox ID="tbModuloElasticidadAcero" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                                    Style="position: static" Width="52px" Enabled="False"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblModuloElasticidadAcero" runat="server" Font-Bold="False" Text="ELASTIC MODULUS OF STEEL Es (MPa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbModuloElasticidadConcreto" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" Enabled="False"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblModuloElasticidadConcreto" runat="server" Font-Bold="False" Text="ELASTIC MODULUS OF CONCRETE Ec (MPa)" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                                                <asp:TextBox ID="tbDeformacionFluenciaAceroLongitudinal" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                                    Style="position: static" Width="52px" Enabled="False"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblDeformacionFluenciaAceroLongitudinal" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Text="<P>YIELD STRAIN OF LONGITUDINAL REINFORCEMENT ε<SUB>y</SUB>"></asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                </td>
                                                                <td style="width: 50%; text-align: center">
                                                                    <table style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <ASPNetFlash:Flash ID="Flash1Exp" runat="server" MovieURL="~/VirtualLabIS/Varios/Archivos/Animacion/EsquemaColumna.swf">
                                                                                        <!--- HTML Alternative --->
                                                                                    </ASPNetFlash:Flash>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%; text-align: center">
                                                                    <table style="width: 80%">
                                                                        <tr>
                                                                            <td style="height: 30px">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static"
                                                                                                Text="RUN MOMENT- CURVATURE ANALYSIS" Width="260px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 30px">
                                                                                            <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static"
                                                                                                Text="LOAD EXAMPLE DATA" Width="184px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 30px">
                                                                                            <asp:Button ID="btnLimpiar" runat="server" CssClass="Boton" Style="position: static"
                                                                                                Text="CLEAR ALL RESULTS" Width="160px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 30px">
                                                                                            <asp:Button ID="btnInforme" runat="server" CssClass="Boton"
                                                                                                Style="position: static" Text="PRINT REPORT" Enabled="False" Width="160px" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%; text-align: center">
                                                                                    <table style="width: 80%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblMensajeRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                                    Width="100%"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" style="text-align: center;">
                                                                                                <asp:HyperLink ID="hplRegistrarse" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                                    Visible="False">[hplRegistrarse]</asp:HyperLink></td>
                                                                                        </tr>
                                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" rowspan="1" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                    border-top-color: activeborder; height: 15px; text-align: center; border-right-color: activeborder">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%" valign="middle">
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
                                                                            <asp:Label ID="lblResults" runat="server" CssClass="Funcionalidad-titulo" Font-Size="X-Large"
                                                                                Text="RESULTS"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" rowspan="1">
                                                                            <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblAnalysis" runat="server" CssClass="Funcionalidad-titulo" Text="ANALYSIS"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblTituloMCR" runat="server" CssClass="Funcionalidad-titulo" Text="MOMENT-CURVATURE RESPONSE"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" style="width: 50%">
                                                                                <table style="width: 90%; height: 90%">
                                                                                    <tr>
                                                                                        <td colspan="3" style="height: 18px">
                                                                                            <asp:Label ID="lblTituloAnalysisIndex" runat="server" Text="ANALYSIS INDEXES" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%; height: 22px;">
                                                                                            <asp:Label ID="lblLongRR" runat="server" CssClass="Funcionalidad-indicadores" Font-Bold="False"
                                                                                                Font-Italic="False" Font-Underline="False" Text="LONGITUDINAL STEEL RATIO (1%-4%)"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt; height: 22px;">
                                                                                            <span><span style="font-size: 10pt"><span style="color: #000000; font-family: Symbol">
                                                                                                <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" id="imgCargaAxial" /></span></span></span></td>
                                                                                        <td style="width: 20%; font-size: 8pt; height: 22px;">
                                                                                            <asp:TextBox ID="txtLongRR" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblTransRR" runat="server" CssClass="Funcionalidad-indicadores" Text="TRANSVERSE STEEL RATIO (0.2%-1%)"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" id="imgAceroTrans" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtTransRR" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblAxialLoadRatio" runat="server" CssClass="Funcionalidad-indicadores" Text="AXIAL LOAD RATIO (0-20%)"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" id="imgPorcCargaAxial" /></td>
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
                                                                                            <asp:Label ID="lblAnalysisResult" runat="server" Text="ANALISIS RESULTS" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblMomentoPrimeraFluencia" runat="server" CssClass="Funcionalidad-indicadores" Text="FIRST YIELD MOMENT"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <span style="font-size: 7pt">
                                                                                                <asp:Image ID="imgMomentoPrimeraFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" /></span></td>
                                                                                        <td style="font-size: 8pt; width: 100px">
                                                                                                                <asp:TextBox ID="tbMomentoPrimeraFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblPrimeraCurvaturaFluencia" runat="server" CssClass="Funcionalidad-indicadores" Text="FIRST YIELD CURVATURE"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <asp:Image ID="imgPrimeraCurvaturaFluencia" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="tbPrimeraCurvaturaFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblMomentoNominal" runat="server" CssClass="Funcionalidad-indicadores" Text="NOMINAL MOMENT"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <span style="font-size: 7pt">
                                                                                                <asp:Image ID="imgMomentoNominal" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" /></span></td>
                                                                                        <td style="width: 100px; font-weight: bold; font-size: 8pt; color: #000000;">
                                                                                                                <asp:TextBox ID="tbMomentoNominal" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblCurvaturaFluencia" runat="server" CssClass="Funcionalidad-indicadores" Text="YIELD CURVATURE"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" /></td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                            <asp:TextBox ID="tbCurvaturaFluencia" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblInerciaGruesa" runat="server" CssClass="Funcionalidad-indicadores" Text="GROSS INERTIA lg(m^4)"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <asp:Image ID="imgInerciaGruesa" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaGruesaAMC.png" /></td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                            <asp:TextBox ID="tbInerciaGruesa" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblIncerciaAgrietada" runat="server" CssClass="Funcionalidad-indicadores" Text="CRACKED INERTIA lcr(m^4)"></asp:Label></td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                            <asp:Image ID="imgAgrietada" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" /></td>
                                                                                        <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                            <asp:TextBox ID="tbIncerciaAgrietada" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                   
                                                                                
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores">
                                                                                            <asp:Label ID="lblIcrIg" runat="server" CssClass="Funcionalidad-indicadores" Text="CRACKED TO GROSS INERTIA RATIO"></asp:Label></td>
                                                                                        <td style="width: 97px; font-size: 8pt;">
                                                                                            <asp:Image ID="imgGruesaAgrietada" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaGruesaInerciaAgrietadaAMC.png" /></td>
                                                                                        <td style="width: 100px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="tbIcrIg" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores">
                                                                                        </td>
                                                                                        <td style="font-size: 8pt; width: 97px">
                                                                                        </td>
                                                                                        <td style="font-size: 8pt; width: 100px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                                <asp:Button ID="btnEliminarTest" runat="server" CssClass="Boton" Enabled="False"
                                                                                                    Style="position: static" Text="Delete Response" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 15px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1">
                                                                                        <table style="width: 100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                <uc1:ctlLinksFig ID="CtlLinksFig1" runat="server" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td colspan="2" rowspan="1">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>                                                                                     
                                            <tr>
                                                <td align="center" style="width: 80%; height: 150px" valign="middle" class="Ocultar-texto">
                                                    <a name="linkGrafica1">linkGrafica1</a></td>
                                            </tr>
                                           
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td class="PanelHeader" colspan="2" style="height: 11px">
                                                                    <asp:Label ID="lblTituloFig1" runat="server" Text="FIG. 1 YIELD CURVATURE ASSESSMENT" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%">
                                                                        <table style="width: 90%; height: 90%">
                                                                            <tr>
                                                                                <td style="width: 434px">
                                                                                    <chart:WebChartViewer ID="WebChartViewer2" runat="server" /></td>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                                <td rowspan="1" style="width: 50%">
                                                                            <table style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td>
                                                                        <table class="texto" style="width: 100%; height: 100%">
                                                                            <tr>
                                                                                <td class="Funcionalidad-subtitulo" style="height: 27px;">
                                                                                    <asp:Label ID="lblTituloTeoria1" runat="server" Text="HINT" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="text-align: center">
                                                                                        <table class="texto-interno" style="width: 90%; height: 90%">
                                                                                            <tr>
                                                                                                <td style="text-align: center">
                                                                                                    &nbsp;<asp:Label ID="lblTeoria1" runat="server" Text="YIELD CURVATURE HAS BEEN FOUND TO BE DIRECTLY PROPORTIONAL TO &epsilon;  y/D. <br> THE PROPORCIONALY FACTOR HAS <br> BEEN REPORTED AS 2.25 (PRIESTLEY, ) " CssClass="texto" Width="240px"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="text-align: center">
                                                                                                    <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ecuacionEstimacionCurvaturaFlueciaAMC.png" /></td>
                                                                                            </tr>
                                                                                            
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 30px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <uc1:ctlLinksFig ID="CtlLinksFig2" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%; height: 150px" valign="middle">
                                                    <a name="linkGrafica2">linkGrafica2</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig2" runat="server"
                                                                    Text="FIG. 2 RELATION BETWEEN STRENGTH AND STIFFNESS" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer3" runat="server" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td rowspan="1" style="width: 50%">
                                                                        <table style="width: 90%; height: 90%">
                                                                            <tr>
                                                                                <td>
                                                                    <table class="texto" style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td class="Funcionalidad-subtitulo" style="height: 27px">
                                                                                <asp:Label ID="lblTituloTeoria2" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="HINT"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="text-align: center">
                                                                                    <table class="texto-interno" style="width: 90%; height: 90%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:Label ID="lblTeoria2" runat="server" CssClass="texto" Text="FOR SECTIONS OF SAME DIAMETER AND <br>  WITH SAME MATERIALS PROPERTIES, FY <br> IS A CONSTANT AND MY IS PROPORTIONAL TO EI"
                                                                                                    Width="248px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ecuacionRelacionResistenciaRigidezAMC.png" /></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 30px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <uc1:ctlLinksFig ID="CtlLinksFig3" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%; height: 150px" valign="middle">
                                                    <a name="linkGrafica3">linkGrafica3</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig3"
                                                                    runat="server" Text="FIG. 3 CRACKED TO GROSS INERTIA RATIO VS. LONGITUDINAL STEEL RATIO" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer4" runat="server" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td rowspan="1" style="width: 50%">
                                                                        <table style="width: 90%; height: 90%">
                                                                            <tr>
                                                                                <td>
                                                                    <table class="texto" style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td class="Funcionalidad-subtitulo" style="height: 27px">
                                                                                <asp:Label ID="lblTituloTeoria3" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="HINT"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="text-align: center">
                                                                                    <table class="texto-interno" style="width: 90%; height: 90%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:Label ID="lblTeoria3" runat="server" CssClass="texto" Text="KEEPING CONSTANT THE AXIAL LOAD <br> RATIO, Icr/Ig IS PROPORTIONAL TO <br> THE LONGITUDINAL STEEL RATIO"
                                                                                                    Width="224px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ecuacionRelacionInerciaGruesavsAgrietadaAMC.png" /></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 30px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <uc1:ctlLinksFig ID="CtlLinksFig4" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%; height: 150px" valign="middle">
                                                    <a name="linkGrafica4">linkGrafica4</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig4" runat="server" Text="FIG. 4 EVALUATION OF MODEL FOR ASSESMENT OF Icr/Ig " CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer5" runat="server" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td rowspan="1" style="width: 50%">
                                                                        <table style="width: 90%; height: 80%">
                                                                            <tr>
                                                                                <td>
                                                                    <table class="texto" style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td class="Funcionalidad-subtitulo" style="height: 27px">
                                                                                <asp:Label ID="lblTituloTeoria4" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="HINT"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="text-align: center">
                                                                                    <table class="texto-interno" style="width: 90%; height: 90%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:Label ID="lblTeoria4" runat="server" CssClass="texto" Text="THIS FIGURE PRESENTS Icr/Ig FROM  MOMENT <br> CURVATURE ANALYSIS AND Icr/Ig WITH <br> A MODEL BY KOWALSKY (2000)"
                                                                                                    Width="272px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <img src="../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ecuacionIcrIgRealVsCalculadoAMC.png" /></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 30px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <uc1:ctlLinksFig ID="CtlLinksFig5" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%; height: 150px" valign="middle">
                                                   <a name="linkgrafica5">linkgrafica5</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig5" runat="server"
                                                                    Text="FIG. 5 RELATION BETWEEN CONCRETE STRAIN AND CURVATURE" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%; height: 23px">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer6" runat="server" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td rowspan="3" style="width: 50%">
                                                                        <table style="width: 90%; height: 80%">
                                                                            <tr>
                                                                                <td style="width: 315px">
                                                                    <table class="texto" style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td class="Funcionalidad-subtitulo" style="height: 27px">
                                                                                <asp:Label ID="lblTituloTeoria5" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="HINT"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="text-align: center">
                                                                                    <table class="texto-interno" style="width: 90%; height: 90%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:Label ID="lblTeoria5" runat="server" CssClass="texto" Text="THESE FIGURES SHOW THE RELATION <br> BETWEEN STRAIN AND THE PRODUCT <br> OF CURVATURE AND DIAMETER. THE <br> RELATION IS ALMOST LINEAR."
                                                                                                    Width="232px"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 30px; width: 315px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 315px">
                                                                                    <uc1:ctlLinksFig ID="CtlLinksFig6" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%; height: 23px">
                                                                <asp:Label ID="lblTituloFig6" runat="server"
                                                                    Text="FIG. 6 RELATION BETWEEN STEEL STRAIN AND CURVATURE" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%; height: 23px">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td>
                                                                                <chart:WebChartViewer ID="WebChartViewer7" runat="server" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%;" valign="middle">
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
