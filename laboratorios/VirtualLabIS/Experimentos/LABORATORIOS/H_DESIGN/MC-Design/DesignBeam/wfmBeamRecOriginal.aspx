<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfmBeamRecOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_DesignBeam_wfmBeamRec"%>
                                                                                                                                
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-DESING RECTANG BEAN</title>
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
                            <table style="width: 70%; height: 100%">                                
                                <tr>
                                    <td align="center" valign="middle" style="width: 78%">
                                        &nbsp;<table style="width: 100%; height: 95%" class="Tabla-Principales">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12px" valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="height: 18px">
                                                    <asp:Label ID="lblGeneralTitle" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo"
                                                    valign="middle" style="width: 50%; text-align: center;">
                                                        <table style="width: 90%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td rowspan="2" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                    width: 44%; border-top-color: activeborder; text-align: center; border-right-color: activeborder">
                                                                                <table style="width: 90%; height: 90%; border-top-width: 1px; border-top-color: activecaption;">
                                                                                    <tr>
                                                                                        <td colspan="2" style="height: 20px">
                                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 28px">
                                                                                            <asp:TextBox ID="txtbase" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False" Font-Underline="False" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td style="width: 88%; height: 28px;" class="Funcionalidad-datos-entrada">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblbase" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Width="178px"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtaltura" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                            <asp:Label ID="lblaltura" runat="server" Width="180px" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtcoverbottom" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblcover1" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtcovertop" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px;">
                                                                                            <asp:Label ID="lblcover2" runat="server" Width="240px" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtNumTopSteel" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblNumBarsTop" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtNumberBottomSteel" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                                            <asp:Label ID="lblNumberBottomSteel" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtLateralDiam" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                            <asp:Label ID="lblLongBarDiameter2" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="264px"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtNumLateralBars" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                                            <asp:Label ID="lblLateralBars" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtNumStirrups" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                            <asp:Label ID="lblNumLegsShear" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False" Width="208px"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 40px">
                                                                                            <asp:TextBox ID="txtSpacingStirrups" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 40px;">
                                                                                            <asp:Label ID="lblSpacingStirrups" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtShearSpan" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblShearSpan" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr style="font-weight: bold">
                                                                                        <td colspan="2">
                                                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr style="color: #222222">
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtConcrComprStrength" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblConcrComprStrength" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada" Width="180px"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtfyLong" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblLongRYS" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada" Width="179px"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 38px">
                                                                                            <asp:TextBox ID="txtfyTrans" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 38px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblTransRYS" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada" Width="176px"></asp:Label></strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="Funcionalidad-datos-entrada" colspan="2" style="height: 20px;
                                                                                            text-align: center">
                                                                                            <asp:Label ID="lblTituloDesignForces" runat="server" CssClass="Funcionalidad-subtitulo" Text="DESIGN FORCES"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtPositiveM" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px;">
                                                                                            <strong>
                                                                                                <asp:Label ID="lblPositive" runat="server" Font-Bold="False" CssClass="Funcionalidad-datos-entrada" Width="184px" Height="10px"></asp:Label><div
                                                                                                    style="text-align: center">
                                                                                                    &nbsp;</div>
                                                                                            </strong></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 81px; height: 26px">
                                                                                            <asp:TextBox ID="txtNegativeM" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="width: 88%; height: 26px">
                                                                                            <asp:Label ID="lblNegative" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Height="10px" Width="184px"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 45px">
                                                                                            <asp:TextBox ID="txtCortanteGravitacional" runat="server" AutoCompleteType="Disabled"
                                                                                                CssClass="Funcionalidad-textbox-habilitado" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                        <td class="Funcionalidad-datos-entrada" style="height: 45px">
                                                                                            <asp:Label ID="lblCortanteGravitacional" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Height="17px" Width="258px"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                        <table style="width: 90%">
                                                                            <tr>
                                                                                <td style="width: 100%; height: 100%">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 100%;">
                                                                                            <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="184px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 100%;">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="132px" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 100%;">
                                                                                            </td>
                                                                            </tr>
                                                                        </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td class="Funcionalidad-datos-entrada">
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
                                                                </td>
                                                                <td style="width: 50%; text-align: center; height: 771px;">
                                                                    <table style="width: 100%; height: 100%">
                                                                        <tr>
                                                                            <td style="height: 203px">
                                                                                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/Beam Design.jpg" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 17px">
                                                                    <asp:Label ID="lblTituloEsquemaColumna" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 167px">
                                                                                <asp:Image ID="imgModeloConcreto" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 13px">
                                                                                <asp:Label ID="lblConcreteModel" runat="server" Width="277px"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 221px">
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
                                                                <td style="width: 50%; text-align: center; height: 5px;">
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
                                                <td align="center" class="Funcionalidad-titulo" style="width: 1107px; height: 36px"
                                                    valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1107px; height: 100%;" valign="middle">
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
                                                                                    <td rowspan="2" style="width: 70%; height: 70%;" align="center" colspan="2">
                                                                                <table style="width: 90%; height: 90%">
                                                                                    <tr>
                                                                                        <td colspan="2" style="height: 18px">
                                                                                            <asp:Label ID="lblResultLongitudinal" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Funcionalidad-indicadores" style="width: 10%; height: 10%; position: static;" align="right">
                                                                                            <asp:Label ID="lblDiameterBottom" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Font-Italic="False" Font-Underline="False"></asp:Label></td>
                                                                                        <td style="width: 43px; font-size: 8pt; height: 22px;">
                                                                                            <asp:TextBox ID="txtDiameterBottom" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblDiameterTop" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 43px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtDiameterTop" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt">
                                                                                        <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                            <asp:Label ID="lblDiameterLateral" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                        <td style="width: 43px; font-size: 8pt;">
                                                                                                                <asp:TextBox ID="txtDiameterLateral" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                                    Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt; color: #222222">
                                                                                        <td style="width: 60%">
                                                                                        </td>
                                                                                        <td style="width: 43px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="font-size: 8pt; color: #222222">
                                                                                        <td colspan="2" style="height: 15px">
                                                                                            <asp:Label ID="lblResultTransversal" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
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
                                                                            <asp:Label ID="lblTitlePositive" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" rowspan="1" align="center" style="width: 100%; height: 100%">
                                                                            <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%; height: 18px;">
                                                                                        <asp:Label ID="lblAnalysis" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%; height: 18px;">
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
                                                                                                        Font-Italic="False" Font-Underline="False" Width="216px"></asp:Label></td>
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
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lbldefConc" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Width="209px"></asp:Label></td>
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
                                                                            <asp:Label ID="lblTitleNegative" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="width: 100%; height: 100%">
                                                                            <table class="TablaDatos-Graficas" style="width: 90%; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblAnalisisNeg" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%">
                                                                                        <asp:Label ID="lblMCResponseNeg" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="1" style="width: 50%">
                                                                                        <table style="width: 90%; height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 18px">
                                                                                                    <asp:Label ID="lblAnalisisIndexNeg" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%; height: 22px">
                                                                                                    <asp:Label ID="lblLongRatioNeg" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                        Font-Italic="False" Font-Underline="False" Width="218px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                    <span><span style="font-size: 10pt"><span style="color: #000000; font-family: Symbol">
                                                                                                        <img id="Img1" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" /></span></span></span></td>
                                                                                                <td style="font-size: 8pt; width: 20%; height: 22px">
                                                                                                    <asp:TextBox ID="txtLongRR2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblTranRatioNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <img id="Img2" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtTransRR2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblAxialLoadNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <img id="Img3" src="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtAxialLoadRatio2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
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
                                                                                                    <asp:Label ID="lblAnalysisResulNeg" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblFirstYieldMomNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <span style="font-size: 7pt">
                                                                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" /></span></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtMomentoPrimeraFluencia2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblFirstYieldCurvNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" /></td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="tbPrimeraCurvaturaFluencia2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblNominalMomentNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <span style="font-size: 7pt">
                                                                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" /></span></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbMomentoNominal2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblYieldCurvNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" /></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbCurvaturaFluencia2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblCrackedNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" /></td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="tbIncerciaAgrietada2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="width: 60%">
                                                                                                    <asp:Label ID="lblConStrainNeg" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                        Width="211px"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                </td>
                                                                                                <td style="font-weight: bold; font-size: 8pt; width: 100px; color: #000000">
                                                                                                    <asp:TextBox ID="txtDefMomNom2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores">
                                                                                                    <asp:Label ID="lblDamMomNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px">
                                                                                                    <asp:TextBox ID="txtDamageControl2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="height: 22px">
                                                                                                    <asp:Label ID="lblDamCurvNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px; height: 22px">
                                                                                                    <asp:TextBox ID="txtDamCon2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr style="font-size: 8pt">
                                                                                                <td class="Funcionalidad-indicadores" style="height: 22px">
                                                                                                    <asp:Label ID="lblStiffnessCoefNeg" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="font-size: 8pt; width: 95px; height: 22px">
                                                                                                </td>
                                                                                                <td style="font-size: 8pt; width: 100px; height: 22px">
                                                                                                    <asp:TextBox ID="txtSlopeRatio2" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                                                                                        Style="position: static" Width="42px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <chart:WebChartViewer ID="WebChartViewer2" runat="server" BorderColor="White" SelectionBorderColor="Transparent"
                                                                                            Style="position: static" /></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" rowspan="1" style="height: 127px">
                                                                            <asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="860px" CssClass="texto-interno-pequeno"></asp:TextBox></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>                                                                                     
                                            <tr>
                                                <td align="center" style="width: 1107px; height: 11px;" valign="middle">
                                                    <span style="color: #000000">&nbsp;&nbsp; Copyright © 2006 - 2008 VirtualLab UTPL. All rights reserved.
                                                    </span>
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
