<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfBeamOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Parameter_Beam_wfBeam"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MC-PARAMETER BEAM</title>
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
                                                <td align="center" class="Ocultar-texto" valign="middle" style="width: 877px">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12pt; width: 877px;" valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="Funcionalidad-titulo" style="width: 877px">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="width: 877px">
                                                    <asp:Label ID="lblTituloGeneral" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="width: 877px">
                                                    <div style="text-align: center">
                                                        <table class="TablaDatos-Graficas" style="width: 90%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/Mc Analysis Viga.jpg" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSeccion" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                        <table style="width: 40%; height: 100%">
                                                                            <tr>
                                                                                <td style="width: 233px; height: 28px;">
                                                                                    <asp:Label ID="lblNumeroSecciones" runat="server" CssClass="Funcionalidad-datos-entrada" Width="200px"></asp:Label></td>
                                                                                <td style="width: 100px; height: 28px;">
                                                                                    <asp:TextBox ID="txtNumberSections" runat="server" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="text-align: center">
                                                                        <table style="width: 95%; height: 90%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                                                                            <tr>
                                                                                <td style="width: 239px; height: 20px">
                                                                                </td>
                                                                                <td colspan="10" style="height: 20px">
                                                                    <asp:Label ID="lblInputData1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 239px">
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                                    <asp:Label ID="lblSectionNumber" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label16" runat="server" CssClass="Funcionalidad-titulo" Text="1"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text="2" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text="3" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label19" runat="server" Text="4" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server" Text=" 5" CssClass="Funcionalidad-titulo"></asp:Label></td>
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
                                                                                <td style="text-align: center" colspan="11">
                                                                    <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblSectionBase" runat="server" CssClass="Funcionalidad-datos-entrada" Width="116px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBase10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblSectionHeight" runat="server" CssClass="Funcionalidad-datos-entrada" Width="128px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtHeight10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px; height: 26px;">
                                                                    <asp:Label ID="lblCoverTop" runat="server" CssClass="Funcionalidad-datos-entrada" Width="218px"></asp:Label></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td style="height: 26px">
                                                                    <asp:TextBox ID="txtcoverTopBottom10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblCoverBottom" runat="server" CssClass="Funcionalidad-datos-entrada" Width="232px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtCoverLateral10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblNumBarsTop" runat="server" CssClass="Funcionalidad-datos-entrada" Width="114px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtBarsTop10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblDiamTop" runat="server" CssClass="Funcionalidad-datos-entrada" Width="190px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamTop10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblNumBarsBottom" runat="server" CssClass="Funcionalidad-datos-entrada" Width="136px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsBottom10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblDiamBottom" runat="server" CssClass="Funcionalidad-datos-entrada" Width="214px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamBottom10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblNumLateral" runat="server" CssClass="Funcionalidad-datos-entrada" Width="140px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumBarsLateral10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblDiamLateral" runat="server" CssClass="Funcionalidad-datos-entrada" Width="216px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamLateral10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblStirrupsX" runat="server" CssClass="Funcionalidad-datos-entrada" Width="218px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsX10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblStirrupsY" runat="server" CssClass="Funcionalidad-datos-entrada" Width="218px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtNumStirrupsY10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblDiamStirrups" runat="server" CssClass="Funcionalidad-datos-entrada" Width="156px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtDiamStirrups10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblSpacingStirrups" runat="server" CssClass="Funcionalidad-datos-entrada" Width="148px"></asp:Label></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups5" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups6" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups7" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups8" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups9" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                <td>
                                                                    <asp:TextBox ID="txtSpacingStirrups10" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblShearSpan" runat="server" CssClass="Funcionalidad-datos-entrada" Width="96px"></asp:Label></td>
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
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblFc" runat="server" CssClass="Funcionalidad-datos-entrada" Width="218px"></asp:Label></td>
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
                                                                                <td style="text-align: left; width: 239px;">
                                                                    <asp:Label ID="lblFyLong" runat="server" CssClass="Funcionalidad-datos-entrada" Width="188px"></asp:Label></td>
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
                                                                                <td style="text-align: left; width: 239px;">
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
                                                                                <td style="text-align: left; width: 239px;">
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
                                                <td align="center" class="Ocultar-texto" valign="middle" style="width: 877px; height: 16px;">
                                                   <a name="#linkExperimento" style="width: 80%; height: 150px">linkExperimento</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 877px; height: 100%" valign="middle">
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
                                                                                    <td class="PanelHeader" style="width: 540px; height: 15px;">
                                                                                        </td>
                                                                                    <td class="PanelHeader" style="width: 404px; height: 15px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloMCR" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="height: 15px; width: 540px;">
                                                                                    </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px; height: 15px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="height: 18px; width: 540px;">
                                                                                        </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px; height: 18px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="height: 15px; width: 540px; text-align: right;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer2" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                        <asp:Label ID="lblFigura2" runat="server" CssClass="texto" Height="83px" Style="width: 90%"
                                                                                            Width="230px"></asp:Label>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloFig1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px">
                                                                                        </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="height: 15px; width: 540px; text-align: right;">
                                                                                        <chart:WebChartViewer ID="WebChartViewer3" runat="server" /></td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px; height: 15px">
                                                                                        &nbsp;<asp:Label ID="lblFigura3" runat="server" CssClass="texto" Height="83px" Style="width: 90%"
                                                                                            Width="229px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloFig2" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px">
                                                                                        </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px; text-align: right">
                                                                                        <chart:WebChartViewer ID="WebChartViewer4" runat="server" /></td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                        <asp:Label ID="lblFigura4" runat="server" CssClass="texto" Style="width: 90%"
                                                                                            Width="233px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloFig3" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px">
                                                                                        </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px; text-align: right">
                                                                                        <chart:WebChartViewer ID="WebChartViewer5" runat="server" /></td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                        <asp:Label ID="lblFigura5" runat="server" CssClass="texto" Style="width: 90%"
                                                                                            Width="229px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloFig5" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px">
                                                                                        </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px; text-align: right">
                                                                                        <chart:WebChartViewer ID="WebChartViewer6" runat="server" /></td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                        <asp:Label ID="lblFigura6" runat="server" CssClass="texto" Style="width: 90%"
                                                                                            Width="203px" Height="83px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" rowspan="1" style="height: 30px">
                                                                                        <asp:Label ID="lblTituloFig6" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px; height: 16px">
                                                                                    </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px; height: 16px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1" rowspan="1" style="width: 540px">
                                                                                    </td>
                                                                                    <td colspan="1" rowspan="1" style="width: 404px">
                                                                                    </td>
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
