<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="PushoverOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_Pushover_Pushover"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PUSHOVER</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript">function TABLE1_onclick() {

}

</script>
   

    <link href="../../../../../VirtualLabIS/Varios/Archivos/Styles/stlServicios.css"
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
                            <table style="width: 60%; height: 100%">                                
                                <tr>
                                    <td align="center" valign="middle" style="width: 80%">
                                        &nbsp;<table style="width: 100%; height: 95%" class="Tabla-Principales">
                                            <tr>
                                                <td align="center" class="Ocultar-texto" valign="middle" style="width: 877px; height: 16px;">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12pt; width: 877px; text-align: center;" valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="Funcionalidad-titulo" style="width: 877px; text-align: center;">
                                                    <asp:Label ID="lblTituloExp" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="width: 877px; text-align: center;">
                                                    <asp:Label ID="lblTituloGeneral" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 877px; text-align: center"
                                                    valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 100%; height: 100%">
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; text-align: center">
                                                                        <table style="width: 95%; height: 90%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px">
                                                                                    <asp:Image ID="imgPortico" runat="server" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px">
                                                                    <asp:Label ID="lblFrame" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px">
                                                                                    <asp:Label ID="lblInputData1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 20px; text-align: left;">
                                                                                    <asp:Label ID="lblGeometryProperties" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 178px; text-align: left" rowspan="1">
                                                                                    <div style="text-align: center">
                                                                                        <div style="text-align: center">
                                                                                            <table style="width: 100%; height: 100%">
                                                                                                <tr>
                                                                                                    <td style="width: 100px; height: 18px; text-align: left">
                                                                                    <asp:Label ID="lblSpan1" runat="server" CssClass="Funcionalidad-datos-entrada" Width="241px"></asp:Label></td>
                                                                                                    <td style="width: 100px; height: 18px; text-align: left">
                                                                                    <asp:TextBox ID="txtvano1" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:Label ID="lblSpan2" runat="server" CssClass="Funcionalidad-datos-entrada" Width="241px"></asp:Label></td>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:TextBox ID="txtvano2" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:Label ID="lblHStory1" runat="server" CssClass="Funcionalidad-datos-entrada" Width="242px"></asp:Label></td>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:TextBox ID="txtaltura1" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:Label ID="lblHStory2" runat="server" CssClass="Funcionalidad-datos-entrada" Width="242px"></asp:Label></td>
                                                                                                    <td style="width: 100px; text-align: left">
                                                                                    <asp:TextBox ID="txtaltura2" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                                <td colspan="12" rowspan="1">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 16px">
                                                                                    <asp:Label ID="lblVigas" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" rowspan="1">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td style="width: 100px">
                                                                                                    <asp:Image ID="imgViga" runat="server" /></td>
                                                                                                            <td style="width: 100px">
                                                                                                            </td>
                                                                                                            <td style="width: 100px">
                                                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/CORTE VIGA.jpg" /></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" rowspan="1">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left; height: 18px;">
                                                                                    <asp:Label ID="lblBeamNumber" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblBeam1" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                    <asp:Label ID="lblBeam2" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                    <asp:Label ID="lblBeam3" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                    <asp:Label ID="lblBeam4" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="True"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="5" style="text-align: left">
                                                                                    <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;" align="right">
                                                                    <asp:Label ID="lblSectionBase" runat="server" CssClass="Funcionalidad-datos-entrada" Width="366px"></asp:Label></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseB1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseB2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseB3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseB4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;" align="right">
                                                                    <asp:Label ID="lblSectionHeight" runat="server" CssClass="Funcionalidad-datos-entrada" Width="358px"></asp:Label></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightB1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightB2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightB3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightB4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;">
                                                                    <asp:Label ID="lblRefuerzoCSuperior" runat="server" CssClass="Funcionalidad-datos-entrada" Width="444px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: left;">
                                                                    <asp:TextBox ID="txtTopContinuous1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTopContinuous2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTopContinuous3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTopContinuous4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;">
                                                                    <asp:Label ID="lblRefuerzoCInferior" runat="server" CssClass="Funcionalidad-datos-entrada" Width="440px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: left;">
                                                                    <asp:TextBox ID="txtBottomContinuous1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBottomContinuous2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBottomContinuous3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBottomContinuous4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; height: 12px; text-align: left;">
                                                                    <asp:Label ID="lblRefuerzoIzquierdo" runat="server" CssClass="Funcionalidad-datos-entrada" Width="438px"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 12px">
                                                                    <asp:TextBox ID="txtReinfLeft1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px; height: 12px">
                                                                    <asp:TextBox ID="txtReinfLeft2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px; height: 12px">
                                                                    <asp:TextBox ID="txtReinfLeft3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px; height: 12px">
                                                                    <asp:TextBox ID="txtReinfLeft4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left">
                                                                    <asp:Label ID="lblRefuerzoDerecho" runat="server" CssClass="Funcionalidad-datos-entrada" Width="438px"></asp:Label></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtReinfRight1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtReinfRight2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtReinfRight3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtReinfRight4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;">
                                                                    <asp:Label ID="lblRefuerzoTransversal" runat="server" CssClass="Funcionalidad-datos-entrada" Width="366px"></asp:Label></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTransReinf1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTransReinf2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTransReinf3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtTransReinf4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="5" style="text-align: left">
                                                                                    <asp:Label ID="lblLoads" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left;">
                                                                    <asp:Label ID="lblGravityLoad" runat="server" CssClass="Funcionalidad-datos-entrada" Width="366px"></asp:Label></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtGravityLoad1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtGravityLoad2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtGravityLoad3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtGravityLoad4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                    <div style="text-align: center">
                                                                                        &nbsp;</div>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 21px; text-align: center">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center; height: 21px;" colspan="13">
                                                                                    <asp:Label ID="lblColumnas" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="height: 21px; text-align: left">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td style="width: 100px">
                                                                                                    <asp:Image ID="imgColumn" runat="server" /></td>
                                                                                                            <td style="width: 100px">
                                                                                                            </td>
                                                                                                            <td style="width: 100px">
                                                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/CORTE COLUMNA.jpg" /></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" rowspan="1">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td style="width: 86px; text-align: left; height: 18px;">
                                                                    <asp:Label ID="lblBeamNumberC" runat="server" CssClass="Funcionalidad-datos-entrada" Width="156px"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn1" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn2" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 56px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn3" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn4" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn5" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                                <td style="width: 55px; height: 18px; text-align: center;">
                                                                                    <asp:Label ID="lblColumn6" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="7" style="text-align: left">
                                                                                    <asp:Label ID="lblSectionProperties" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 86px; text-align: left">
                                                                    <asp:Label ID="lblBaseColumna" runat="server" CssClass="Funcionalidad-datos-entrada" Width="148px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: center;">
                                                                    <asp:TextBox ID="txtBaseC1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseC2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 56px">
                                                                    <asp:TextBox ID="txtBaseC3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtBaseC4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtBaseC5" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtBaseC6" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 86px; text-align: left">
                                                                    <asp:Label ID="lblAlturaColumna" runat="server" CssClass="Funcionalidad-datos-entrada" Width="96px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: center;">
                                                                    <asp:TextBox ID="txtHeightC1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightC2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 56px">
                                                                    <asp:TextBox ID="txtHeightC3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtHeightC4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtHeightC5" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtHeightC6" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 86px; text-align: left">
                                                                                    <asp:Label ID="lblRefuerzoLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                        Width="400px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: center;">
                                                                    <asp:TextBox ID="txtLongReinf1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtLongReinf2" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 56px">
                                                                    <asp:TextBox ID="txtLongReinf3" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                    <asp:TextBox ID="txtLongReinf4" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtLongReinf5" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtLongReinf6" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 86px; text-align: left">
                                                                                    <asp:Label ID="lblRefuerzoTransv" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                        Width="442px"></asp:Label></td>
                                                                                                <td style="width: 55px; text-align: center;">
                                                                                    <asp:TextBox ID="txtTransvReinfC1" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtTransvReinfC2" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 56px">
                                                                                    <asp:TextBox ID="txtTransvReinfC3" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtTransvReinfC4" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtTransvReinfC5" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                                <td style="width: 55px">
                                                                                    <asp:TextBox ID="txtTransvReinfC6" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                    <div style="text-align: center">
                                                                                        &nbsp;</div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="text-align: center; height: 18px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center" colspan="13">
                                                                    <asp:Label ID="lblMaterialProperties" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; width: 178px;" rowspan="1">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left">
                                                                    <asp:Label ID="lblFc" runat="server" CssClass="Funcionalidad-datos-entrada" Width="248px"></asp:Label></td>
                                                                                                <td style="width: 100px; text-align: left">
                                                                    <asp:TextBox ID="txtFc" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; text-align: left">
                                                                    <asp:Label ID="lblFy" runat="server" CssClass="Funcionalidad-datos-entrada" Width="246px"></asp:Label></td>
                                                                                                <td style="width: 100px; text-align: left">
                                                                    <asp:TextBox ID="txtFyTrans1" runat="server" Width="45px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="13" style="text-align: center">
                                                                                    <asp:Label ID="lblPushover" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 22px; text-align: left;">
                                                                                    <asp:Label ID="lblDatosAnálisis" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                        Width="108px"></asp:Label></td>
                                                                                <td colspan="11" rowspan="3" style="width: 124%; text-align: left;">
                                                                                    <chart:WebChartViewer ID="WebChartViewerPushover" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" rowspan="2" style="text-align: left">
                                                                                    <div style="text-align: center">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td style="width: 100px">
                                                                                    <asp:Label ID="lblPatronCarga" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                        Width="228px"></asp:Label></td>
                                                                                                <td style="width: 28px; text-align: left">
                                                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                                                        <asp:ListItem>Triangular</asp:ListItem>
                                                                                        <asp:ListItem>Uniform</asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 100px; height: 23px">
                                                                                    <asp:Label ID="lblDesplazamientoMeta" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                        Width="226px"></asp:Label></td>
                                                                                                <td style="width: 28px; height: 23px; text-align: left">
                                                                                    <asp:TextBox ID="txtDesplazamientoMeta" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                        Width="45px"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="text-align: center">
                                                                                            <asp:Button ID="btnCargarEjemplo" runat="server" CssClass="Boton" Style="position: static" Width="226px" /></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="text-align: center">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static" Width="274px" /></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 18px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="width: 877px">
                                                    <div style="text-align: center">
                                                        <table class="TablaDatos-Graficas" style="width: 90%">
                                                            <tr>
                                                                <td>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 16px">
                                                                    <div style="text-align: center">
                                                                        &nbsp;</div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="text-align: center">
                                                                        <table style="width: 40%">
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
                                                                    <table style="width: 95%; height: 90%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                                                                        <tr>
                                                                            <td colspan="8" style="height: 20px">
                                                                                <asp:Label ID="lblResults" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="8" style="height: 4px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="8" style="height: 20px">
                                                                                <asp:Label ID="lblBeams" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left; width: 97px;" rowspan="4"><asp:Image ID="imgPortico2" runat="server" /></td>
                                                                            <td colspan="2" style="height: 22px">
                                                                            </td>
                                                                            <td style="height: 22px;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px;">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:Label ID="lblDraw" runat="server"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:CheckBox ID="CheckBoxSelectAll" runat="server" AutoPostBack="True" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px; height: 22px;">
                                                                                <asp:CheckBox ID="cbBeam1" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px; height: 22px">
                                                                                <asp:CheckBox ID="cbBeam2" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px; height: 22px;">
                                                                                <asp:CheckBox ID="cbBeam3" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                <asp:CheckBox ID="cbBeam4" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:Button ID="btnGraficarVigas" runat="server" CssClass="Boton" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td rowspan="2">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 26px; width: 11px;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 26px">
                                                                            </td>
                                                                            <td style="height: 26px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 26px">
                                                                            </td>
                                                                            <td style="height: 26px; width: 69px;">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="border-right: 1px solid; border-top: black 1px solid; border-left: 1px solid;
                                                                                border-bottom: 1px solid; height: 17px; text-align: center">
                                                                                <asp:Label ID="Label6" runat="server" CssClass="Funcionalidad-titulo" Text="LEFT END"></asp:Label></td>
                                                                            <td colspan="4" style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid;
                                                                                border-bottom: 1px solid; height: 17px; text-align: center">
                                                                                <asp:Label ID="Label8" runat="server" CssClass="Funcionalidad-titulo" Text="RIGHT END"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center; height: 17px; border-left: 1px solid;" colspan="2">
                                                                                <chart:WebChartViewer ID="WebChar11" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td style="height: 17px; text-align: center; border-right: 1px solid;" colspan="2">
                                                                                <chart:WebChartViewer ID="WebChart12" runat="server" style="position: static; border-right: 1px solid;" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; text-align: center; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart13" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart14" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 17px; text-align: center; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart21" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; text-align: center; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart22" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 90%; width: 90%; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart23" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart24" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 17px; text-align: center; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart31" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; text-align: center; border-right: 1px double;">
                                                                                <chart:WebChartViewer ID="WebChart32" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart33" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 17px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart34" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: center; border-left: 1px solid; border-bottom: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart41" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="text-align: center; border-right: 1px solid; border-bottom: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart42" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-left: 1px solid; border-bottom: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChart43" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid; border-bottom: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChart44" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="8" style="height: 6px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center; height: 21px;" colspan="8">
                                                                                <asp:Label ID="lblColumnsResults" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left; width: 97px;" rowspan="4"><asp:Image ID="imgPortico3" runat="server" /></td>
                                                                            <td colspan="2" rowspan="4">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:Label ID="lblColumnsDraw" runat="server"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:CheckBox ID="CheckBoxAllColumns" runat="server" AutoPostBack="True" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                <asp:CheckBox ID="cbColumn1" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px; height: 22px">
                                                                                <asp:CheckBox ID="cdColumn2" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px; height: 22px;">
                                                                                <asp:CheckBox ID="cdColumn3" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                <asp:CheckBox ID="cdColumn4" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:CheckBox ID="cdColumn5" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:CheckBox ID="cdColumn6" runat="server" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 373px">
                                                                                            <asp:Button ID="btnGraficarColumnas" runat="server" CssClass="Boton" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td style="height: 21px;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 21px; text-align: center;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 21px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 21px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 21px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 22px;">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px">
                                                                            </td>
                                                                            <td style="width: 69px; height: 22px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                            <td style="width: 69px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid;
                                                                                height: 17px; text-align: center; border-bottom: 1px solid;">
                                                                                <asp:Label ID="Label10" runat="server" CssClass="Funcionalidad-titulo" Text="LEFT END"></asp:Label></td>
                                                                            <td colspan="4" style="border-top: 1px solid; border-left: 1px solid; height: 17px; border-right: 1px solid; border-bottom: 1px solid;">
                                                                                <asp:Label ID="Label11" runat="server" CssClass="Funcionalidad-titulo" Text="RIGHT END"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: center; height: 202px; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC11" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid; height: 202px">
                                                                                <chart:WebChartViewer ID="WebChartC12" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 202px; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC13" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 202px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC14" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 16px; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC21" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 16px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC22" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 16px; border-left: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC23" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="height: 16px; border-right: 1px solid;">
                                                                                <chart:WebChartViewer ID="WebChartC24" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="border-left: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC31" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC32" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-left: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC33" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC34" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="border-left: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC41" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC42" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-left: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC43" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                            <td colspan="2" style="border-right: 1px solid">
                                                                                <chart:WebChartViewer ID="WebChartC44" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" /></td>
                                                                        </tr>
                                                                    </table>
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
                                                <td align="center" style="width: 877px; height: 100%; text-align: center;" valign="middle">
                                                    <div style="text-align: center">
                                                        <div style="text-align: center">
                                                            <div style="text-align: center">
                                                                &nbsp;</div>
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
