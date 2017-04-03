<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfmRecColOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_DesignColumnRec_wfmRecCol"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-DESIGN RECTANGULAR COLUMN</title>
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
                                    <td align="center" style="width: 78%" valign="middle">
                                        &nbsp;<table class="Tabla-Principales" style="width: 100%; height: 95%">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                    <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12pt"
                                                    valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo"
                                                    valign="middle" style="height: 6px">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <asp:Label ID="lblGeneralTitle" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr style="color: #000000">
                                                <td align="center" class="Funcionalidad-titulo" style="width: 50%; text-align: center"
                                                    valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                        <tr>
                                                            <td rowspan="3" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                width: 44%; border-top-color: activeborder; text-align: center; border-right-color: activeborder">
                                                                <table style="border-top-width: 1px; width: 90%; border-top-color: activecaption;
                                                                    height: 90%">
                                                                    <tr>
                                                                        <td colspan="2" style="height: 20px">
                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 28px; width: 81px;">
                                                                            <asp:TextBox ID="txtbase" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 28px">
                                                                            <strong>
                                                                                <asp:Label ID="lblbase" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="178px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px">
                                                                            <asp:TextBox ID="txtaltura" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <asp:Label ID="lblaltura" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="180px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtcoverTopBottom" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                            <strong>
                                                                                <asp:Label ID="lblcoverTopBottom" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtcoverlateral" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <asp:Label ID="lblCoverLateral" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="178px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtNumBarsTopBottom" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <strong>
                                                                                <asp:Label ID="lblNumBarsTopBottom" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtNumberLateralBars" runat="server" AutoCompleteType="Disabled"
                                                                                CssClass="Funcionalidad-textbox-habilitado" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                            <asp:Label ID="lblNumberLateral" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtNumberStirrupsX" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <asp:Label ID="lblNumStirrups" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False" Width="208px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtNumStirrupsY" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                            <asp:Label ID="lblLateralBars" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtSpacingStirrups" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <asp:Label ID="lblSpacingStirrups" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False" Width="208px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtShearSpan" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                <asp:Label ID="lblShearSpan" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 20px" colspan="2">
                                                                            <asp:Label ID="lblMaterialProperties" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtConcrComprStrength" runat="server" AutoCompleteType="Disabled"
                                                                                CssClass="Funcionalidad-textbox-habilitado" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                            <strong>
                                                                                <asp:Label ID="lblConcrComprStrength" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="180px"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtfyLong" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                <asp:Label ID="lblLongFy" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="179px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 26px">
                                                                            <asp:TextBox ID="txtfyTrans" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                <asp:Label ID="lblTransFy" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Font-Bold="False" Width="176px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="font-weight: bold">
                                                                        <td colspan="2" style="height: 20px">
                                                                            <asp:Label ID="lblDesignForces" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtAxialLoad" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                            <strong>
                                                                            <asp:Label ID="lblAxialLoad" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                Font-Bold="False"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtMoment" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 24px">
                                                                            <strong>
                                                                            <asp:Label ID="lblMoment" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 81px; height: 24px">
                                                                            <asp:TextBox ID="txtangle" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                Width="52px"></asp:TextBox></td>
                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 24px">
                                                                            <asp:Label ID="lblAngle" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
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
                                                                    <table style="width: 90%">
                                                                        <tr>
                                                                            <td style="width: 100%; height: 100%">
                                                                                <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="184px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%; height: 100%">
                                                                                <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="138px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%; height: 100%">
                                                                                </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="width: 50%; height: 771px; text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td style="height: 213px">
                                                                            &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/MCColumna Retangular.jpg" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 6px">
                                                                <asp:Label ID="lblTituloEsquemaColumna" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 171px">
                                                                            <asp:Image ID="imgModeloConcreto" runat="server" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 9px">
                                                                            <asp:Label ID="lblConcreteModel" runat="server" Width="277px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 208px">
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
                                                        <tr>
                                                            <td style="width: 50%; height: 16px; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%; height: 5px; text-align: center">
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
                                                <td align="center" class="Funcionalidad-titulo" style="width: 1107px; height: 35px"
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
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 100%; width: 80%;">
                                                                            <table class="TablaDatos-Graficas" style="width: 25%; height: 90%">
                                                                                <tr>
                                                                                    <td align="center" colspan="2" rowspan="2" style="width: 72%; height: 70%">
                                                                                        <table style="width: 111%; height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 18px">
                                                                                                    <asp:Label ID="lblTituloAnalysisIndex" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblDiameterTop" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Text="lblDiameterTop"></asp:Label></td>
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
                                                                                                    <asp:Label ID="lblDiameterStirrup" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Font-Bold="False" Font-Italic="False" Font-Underline="False"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 43px">
                                                                                                    <asp:TextBox ID="txtDiameterStirrup" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="font-size: 8pt; height: 239px; text-align: left;">
                                                                                                    <asp:TextBox ID="TextBox1" runat="server" Height="228px" TextMode="MultiLine" Width="667px"></asp:TextBox></td>
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
                                                                            <table class="TablaDatos-Graficas" style="width: 100%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblAnalysis" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblMCResponse" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" style="width: 50%">
                                                                                        <table style="width: 90%; height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 18px">
                                                                                                    <asp:Label ID="lblAnalysisIndex" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%; height: 22px">
                                                                                                    <asp:Label ID="lblLongRR" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                        Font-Italic="False" Font-Underline="False" Width="220px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                    <span><span style="font-size: 10pt"><span style="color: #000000; font-family: Symbol">
                                                                                                        <img id="imgCargaAxial" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" /></span></span></span></td>
                                                                                                <td style="font-size: 8pt; width: 20%; height: 22px">
                                                                                                    <asp:TextBox ID="txtLongRR1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblTransRR" runat="server" CssClass="Funcionalidad-datos-entrada" Width="221px"></asp:Label></td>
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
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lbldefConc" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Width="215px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                </td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="txtDefMomNom1" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores">
                                                                                                    <asp:Label ID="lblDamConMom" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px">
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
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        </td>
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
