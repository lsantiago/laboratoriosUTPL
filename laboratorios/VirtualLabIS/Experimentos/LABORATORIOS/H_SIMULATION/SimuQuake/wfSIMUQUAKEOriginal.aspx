<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfSIMUQUAKEOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_wfSIMUQUAKE"%>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<%--Tipos de Especimenes--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SIMUQUAKE</title>
    <link href="../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
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
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="SIMUQUAKE <br> Artificial Earthquake Generation" CssClass="Funcionalidad-titulo"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 80px" valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 70%;">
                                                        <tr>
                                                            <td colspan="3" style="height: 20px" class="PanelHeader">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px; text-align: left">
                                                            </td>
                                                            <td colspan="1" style="height: 10px; text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px; text-align: left;">
                                                            </td>
                                                            <td colspan="1" style="height: 10px; text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                    <table style="width: 90%">
                                                                        <tr>
                                                                            <td colspan="1" style="text-align: left">
                                                                            </td>
                                                                            <td colspan="2" style="text-align: left">
                                                                                <asp:Label ID="lblTituloParamSimul" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="SIMULATED EARTHQUAKE PARAMETERS"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="1" style="text-align: left">
                                                                            </td>
                                                                            <td colspan="2" style="text-align: left">
                                                                                <table style="border-right: #cccc99 1px solid; border-top: #cccc99 1px solid; border-left: #cccc99 1px solid;
                                                                                    width: 250pt; border-bottom: #cccc99 1px solid">
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNomSismo"
                                                                                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNomSismo" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="150px"></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblNomSismo" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Text="EARTHQUAKE/S NAME TAG"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumSimulaciones"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtNumSimulaciones" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblNumSimulaciones" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="NUMBER OF EARTHQUAKES TO BE SIMULATED"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDuracion"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtDuracion" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblDuracion" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="DURATION (s)"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTiempo1"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtTiempo1" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblTiempo1" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="TIME 1 (s) FOR DEFINITION OF EARTHQUAKE ENVELOPE."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTiempo2"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtTiempo2" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblTiempo2" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="TIME 2 (s) FOR DEFINITION OF EARTHQUAKE ENVELOPE."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                            </td>
                                                                            <td style="width: 15px; text-align: left">
                                                                            </td>
                                                                            <td style="width: 85%; text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td colspan="1" rowspan="1" style="text-align: center">
                                                                    <table style="width: 80%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Image ID="imgFig1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/SIMUQUAKE/FigEarthquakeParameter-EN.gif" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblNomFig" runat="server" CssClass="Funcionalidad-subtitulo" Text="Fig. # 1. Earthquake Parameter"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: center">
                                                            </td>
                                                            <td colspan="1" rowspan="1" style="text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                    <table style="width: 90%">
                                                                        <tr>
                                                                            <td colspan="1" style="text-align: left">
                                                                            </td>
                                                                            <td colspan="2" style="text-align: left">
                                                                                <asp:Label ID="lblTituloTarget" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                    Text="TARGET SPECTRUM PARAMETERS"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFactorA"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtFactorA" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblFactorA" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="FA FACTOR."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFactorV"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtFactorV" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblFactorV" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="FV FACTOR."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAceleracionPerdCorto"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtAceleracionPerdCorto" runat="server" AutoCompleteType="Disabled"
                                                                                    CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False"
                                                                                    Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblAceleracionPerdCorto" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="Ss SHORT PERIOD SPECTRAL ACCELERATION (M/S^2)."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAceleracionPerdPrim"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtAceleracionPerdPrim" runat="server" AutoCompleteType="Disabled"
                                                                                    CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False"
                                                                                    Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblAceleracionPerdPrim" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="S1 ONE PERIOD SPECTRAL ACCELERATION (M/S^2)."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPeriodoEsquina"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                            <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtPeriodoEsquina" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                            <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblPeriodoEsquina" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="CORNER PERIOD, TC (s)."></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15px; text-align: left">
                                                                            </td>
                                                                            <td style="width: 15px; text-align: left">
                                                                            </td>
                                                                            <td style="width: 85%; text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                            <td colspan="1" rowspan="1" style="text-align: center"><table style="width: 80%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Image ID="imgFig2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/SIMUQUAKE/FigTargetSpectrumPar-EN.gif" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblNomFig2" runat="server" CssClass="Funcionalidad-subtitulo" Text="Fig. # 2. Target Spectrum Parameters"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 30px; text-align: center">
                                                            </td>
                                                            <td colspan="1" rowspan="1" style="text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                <table style="width: 90%">
                                                                    <tr>
                                                                        <td colspan="1" style="text-align: left">
                                                                        </td>
                                                                        <td colspan="2" style="text-align: left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="Funcionalidad-subtitulo" Text="MATCHING PERIOD RANGE"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPeriodoInicial"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtPeriodoInicial" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                        <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblPeriodoInicial" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="MATCH FROM (s)"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPeriodoFinal"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtPeriodoFinal" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                    Font-Bold="False" Font-Italic="False" Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                        <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblPeriodoFinal" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="MATCH TO (s)"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumPuntEspectrales"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                        <td style="width: 15px; text-align: left">
                                                                                <asp:TextBox ID="txtNumPuntEspectrales" runat="server" AutoCompleteType="Disabled"
                                                                                    CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False"
                                                                                    Font-Underline="False" Width="50px"></asp:TextBox></td>
                                                                        <td style="width: 85%; text-align: left">
                                                                                <asp:Label ID="lblNumPuntEspectrales" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                    Text="NUMBER OF SPECTRAL POINTS AT WHICH SPECTRUM IS MATCHED"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 15px; text-align: left">
                                                                        </td>
                                                                        <td style="width: 15px; text-align: left">
                                                                        </td>
                                                                        <td style="width: 85%; text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td colspan="1" rowspan="1" style="text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                            <td colspan="1" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                    <table style="width: 30%">
                                                                        <tr>
                                                                            <td style="text-align: center;">
                                                                </td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                </asp:ScriptManager>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div style="text-align: center">
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td>
                                                                    <asp:Label ID="lblMensajes" runat="server" CssClass="Funcionalidad-Mensajes-Links" Font-Size="Small"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Image ID="imgIndicador" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/ajax-loader.gif"
                                                                                            Visible="False" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Timer ID="timeSimular" runat="server" Enabled="False"  Interval="5000" OnTick="timeSimular_Tick">
                                                                                        </asp:Timer>
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
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 15px">
                                                                <div style="text-align: center">
                                                                <asp:Button ID="cmdSimular" runat="server" Text="GENERATE" CssClass="Boton" Width="100px" />&nbsp;</div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 15px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                            <td colspan="1" style="height: 10px">
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
                                        <asp:HiddenField ID="hiddIndicador" runat="server" />
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
