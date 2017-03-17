<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfExperimentoCICHA_SETUP.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_CICHA_wfExperimentoCICHA_SETUP" Debug="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="chart" Namespace="ChartDirector" Assembly="netchartdir" %>

<%--Tipos de Especimenes--%>
<%@ Reference Control="~/VirtualLabIS/Experimentos/CICHA/Modulos/ctrlSpecimenCircular.ascx" %>
<%@ Reference Control="~/VirtualLabIS/Experimentos/CICHA/Modulos/ctrlSpecimenRectangular.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CICHA</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../Varios/Archivos/Scripts/CICHA/scActualizacionControles.js"type="text/javascript"></script>    
    <script language="javascript" src="../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    <script type="text/javascript" src="cdjcv.js"></script>

</head>
<body style="color: #000000">
<script type="text/javascript">

var intIntervalID

function funDesHabilitarBorones() {
    var getObj = function(id) {    return document.getElementById ? document.getElementById(id) : document.all[id]; }
    var cmdDibujarSimulacion_html = getObj("cmdDibujarSimulacion");
    var cmdDetenerSimulacion_html = getObj("cmdDetenerSimulacion");
    var cmdLimpiarSimulacion_html = getObj("cmdLimpiarSimulacion");        
    var txtMensaje_html = getObj("txtMensaje");      //Mensaje del Control PLAY STOP y PAUSE     
    cmdDibujarSimulacion_html.disabled = "disabled"; //Apaga el btn PLAY    
    cmdDetenerSimulacion_html.disabled = "disabled"; //Apaga el btn PAUSE    
    cmdLimpiarSimulacion_html.disabled = "disabled"; //Apaga el btn STOP    
    txtMensaje_html.value = "¡¡¡ Wait Please !!!";   //Muestra un Mensaje
}

// The followings is executed once every second
function updateDisplay(intLimArrayGraficas) {
      JsChartViewer.get('<%=wcvGraficasSimula.ClientID%>').streamUpdate();
}

function cmdDibujarSimulacion_onclick() {
    // Utility to get an object by id that works with most browsers
    intTimeLlamadas = 0
    var getObj = function(id) {    return document.getElementById ? document.getElementById(id) : document.all[id]; }
    var cmdDibujarSimulacion_html = getObj("cmdDibujarSimulacion");
    var hiddIndicador_html = getObj("hiddIndicador");
    var txtMensaje_html = getObj("txtMensaje");      //Mensaje del Control PLAY STOP y PAUSE
    var intLimArrayGraficas = hiddIndicador_html.value    
    //alert(intLimArrayGraficas)
    //disabled="disabled"    
    var intPeriodo = getObj("txtSliderExtPlay_html");
    var intPeriodo = parseInt(intPeriodo.value);       
    cmdDibujarSimulacion_html.disabled = "disabled"; //Apaga el btn PLAY    
    intIntervalID = window.setInterval("updateDisplay("+intLimArrayGraficas+")", intPeriodo);
    txtMensaje_html.value = "";   //Muestra un Mensaje para el control PLAY STOP y PAUSE
}

function cmdDetenerSimulacion_onclick(){
    var getObj = function(id) {    return document.getElementById ? document.getElementById(id) : document.all[id]; }
    var cmdDibujarSimulacion_html = getObj("cmdDibujarSimulacion");    
    var txtMensaje_html = getObj("txtMensaje"); //Mensaje del Control PLAY STOP y PAUSE
    cmdDibujarSimulacion_html.disabled = false; //Enciende el btn PLAY
    window.clearInterval(intIntervalID);        //Detiene el llamado pariodico de la funcion "updateDisplay" con window.setInterval
    intTimeLlamadas = 0
    txtMensaje_html.value = "¡Press PLAY for viewing Results!";   //Muestra un Mensaje para el control PLAY STOP y PAUSE
}

function cmdLimpiarSimulacion_onclick(){
      var getObj = function(id) {    return document.getElementById ? document.getElementById(id) : document.all[id]; }
      var cmdDibujarSimulacion_html = getObj("cmdDibujarSimulacion");    
      var txtMensaje_html = getObj("txtMensaje"); //Mensaje del Control PLAY STOP y PAUSE
      cmdDibujarSimulacion_html.disabled = false; //Enciende el btn PLAY
      var intIndicador = 1;
      window.clearInterval(intIntervalID);
      var viewer = JsChartViewer.get('<%=wcvGraficasSimula.ClientID%>');
      if (JsChartViewer.canSupportPartialUpdate())
      {
        // Browser can support partial update, so connect the view port change event and
        // the submit button to trigger a partial update
        viewer.attachHandler("ViewPortChanged", viewer.partialUpdate);
        viewer.partialUpdate(); 
      }
      window.clearInterval(intIntervalID);        //Detiene el llamado pariodico de la funcion "updateDisplay" con window.setInterval
      txtMensaje_html.value = "¡Press PLAY for viewing Results!";   //Muestra un Mensaje para el control PLAY STOP y PAUSE
      alert("hola uund");
}

</script>

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
                                                <td align="center" class="Ocultar-texto" valign="middle" style="width: 911px">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 12pt"
                                                    valign="middle">
                                                    <asp:Image ID="imgRutaTitulo" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 80px;" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="VIRTUAL SETUP FOR REINFORCED CONCRETE <br> COLUMN SIMULATION" CssClass="Funcionalidad-titulo"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 80px;" valign="middle">
                                                        <table style="width: 90%">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:PlaceHolder ID="phlCotrolesSpecimenes" runat="server"></asp:PlaceHolder>
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
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="height: 80px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 80px" valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 60%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblParamModel" runat="server" CssClass="Funcionalidad-titulo" Text="OPENSEES MODEL PARAMETERS"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        <asp:Label ID="lblParametros" runat="server" CssClass="Funcionalidad-titulo" Text="PARAMETERS"></asp:Label></td>
                                                                                                    <td colspan="1" style="text-align: center">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        &nbsp;<table>
                                                                                                            <tr>
                                                                                                                <td><asp:Image ID="imgAyudaFibrasSeccion" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblFibrasSeccion" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                            Text="FIBER SECTION" style="text-align: left" Width="200px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceFibrasSeccion" runat="server" TargetControlID="imgAyudaFibrasSeccion" PopupControlID="panelFibrasSeccion" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="text-align: center">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelFibrasSeccion" runat="server" Height="75px" Width="320px" CssClass="popupControl">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 100px; height: 41px;">
                                                                                                                            <asp:Label ID="lblAyudaFibrasSeccion" runat="server" Width="300px" CssClass="texto-interno-pequeno"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Image ID="imgAyudaParchesConctConfinado" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblParchesConctConfinado" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="CORE" Width="230px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceParchesConctConfinado" runat="server" TargetControlID="imgAyudaParchesConctConfinado" PopupControlID="panelParchesConctConfinado" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelParchesConctConfinado" runat="server" CssClass="popupControl"
                                                                                                            Height="370px" Width="320px">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Image ID="imgAyudaParchesConctConfinado1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgCoreCircular-EN.GIF" /></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblAyudaParchesConctConfinado" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                Width="250px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblLinksGraficaCore" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtCoreCircunfer_Y" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblCoreCircunfer_Y" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="CIRCUNFERENTIAL DIRECTION" Width="230px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCoreCircunfer_Y"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtCoreRadial_Z" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblCoreRadial_Z" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="RADIAL DIRECTION" Width="230px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCoreRadial_Z"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Image ID="imgParchesConctNoConfinado" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblParchesConctNoConfinado" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="COVER" Width="230px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceParchesConctNoConfinado" runat="server" TargetControlID="imgParchesConctNoConfinado" PopupControlID="panelParchesConctNoConfinado" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelParchesConctNoConfinado" runat="server" CssClass="popupControl"
                                                                                                            Height="370px" Width="320px">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Image ID="imgAyudaParchesConctNoConfinado" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgCoverCircular-EN.GIF" /></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblAyudaParchesConctNoConfinado" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                Width="250px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblLinksGraficaCover" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td colspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtCoverCircunfer_Y" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblCoverCircunfer_Y" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="CIRCUNFERENTIAL DIRECTION" Width="230px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCoverCircunfer_Y"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtCoverRadial_Z" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblCoverRadial_Z" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="RADIAL DIRECTION" Width="230px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCoverRadial_Z"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="height: 30px; text-align: left;">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Image ID="imgAyudaElementosSeccion" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblElementosSeccion" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                            Text="BEAM-COLUMN ELEMENTS" style="text-align: left" Width="200px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceElementosSeccion" runat="server" TargetControlID="imgAyudaElementosSeccion" PopupControlID="panelElementosSeccion" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="height: 30px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelElementosSeccion" runat="server" CssClass="popupControl" Height="400px"
                                                                                                            Width="320px">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Image ID="imgElementosSeccion" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgElementosSeccion-EN.GIF" /></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblTituloFigElementosSeccion" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                Width="250px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblAyudaElementosSeccion" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            &nbsp;<asp:Label ID="lblLinksGraficaElementosSeccion" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtNumSubElementos" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblNumSubElementos" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="# OF SUB ELEMENTS" Width="200px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumSubElementos"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:TextBox ID="txtNumPuntosInters" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                            Width="30px"></asp:TextBox></td>
                                                                                                    <td style="text-align: left">
                                                                                                        <asp:Label ID="lblNumPuntosInters" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="# OF INTEGRATION POINTS" Width="200px"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNumPuntosInters"
                                                                                                            CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="height: 30px; text-align: left;">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Image ID="imgAyudaModeloMateriales" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblModeloMateriales" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                            Text="MATERIAL MODELS" style="text-align: left" Width="200px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceModeloMateriales" runat="server" TargetControlID="imgAyudaModeloMateriales" PopupControlID="panelModeloMateriales" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="height: 30px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelModeloMateriales" runat="server" CssClass="popupControl" Height="75px"
                                                                                                            Width="320px">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 100px">
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesAcero" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="text-align: center">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td><asp:Image ID="imgAyudaModeloMaterialesAcero" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td style="width: 100px; text-align: left;">
                                                                                                        <asp:DropDownList ID="ddlModeloAcero" runat="server">
                                                                                                            <asp:ListItem Value="1" Selected="True">Steel 1</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">Steel 2</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                                <td style="width: 100px; text-align: left;">
                                                                                                        <asp:Label ID="lblModeloAcero" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="STEEL MODEL" Width="200px"></asp:Label></td>
                                                                                                                <td style="width: 100px">
                                                                                                                    <cc1:PopupControlExtender ID="pceModeloMaterialesAcero" runat="server" TargetControlID="imgAyudaModeloMaterialesAcero" PopupControlID="panelModeloMaterialesAcero" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="4">
                                                                                                                    <asp:Panel ID="panelModeloMaterialesAcero" runat="server" CssClass="popupControl"
                                                                                                                        Height="550px" Width="320px">
                                                                                                                        <div style="text-align: center">
                                                                                                                            <table style="width: 90%">
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Image ID="imgAyudaModeloMaterialesAcero1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgAcero1.GIF" /></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:Label ID="lblTituloFigModeloMaterialesAcero1" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                            Width="250px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesAcero1" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td style="width: 100px; height: 20px">
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Image ID="imgAyudaModeloMaterialesAcero2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgAcero2.GIF" /></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:Label ID="lblTituloFigModeloMaterialesAcero2" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                            Width="250px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesAcero2" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </div>
                                                                                                                    </asp:Panel>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><asp:Image ID="imgAyudaModeloMaterialesConcreto" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td style="width: 100px; text-align: left;">
                                                                                                                    <asp:DropDownList ID="ddlModeloConcreto" runat="server">
                                                                                                            <asp:ListItem Value="1" Selected="True">Concrete 1</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">Concrete 2</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">Concrete 3</asp:ListItem>
                                                                                                            <asp:ListItem Value="4">Concrete 4</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                                <td style="width: 100px; text-align: left;">
                                                                                                        <asp:Label ID="lblModeloConcreto" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                            Text="CONCRETE MODEL" Width="200px"></asp:Label></td>
                                                                                                                <td style="width: 100px">
                                                                                                                    <cc1:PopupControlExtender ID="pceModeloMaterialesConcreto" runat="server" TargetControlID="imgAyudaModeloMaterialesConcreto" PopupControlID="panelModeloMaterialesConcreto" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="4">
                                                                                                                    <asp:Panel ID="panelModeloMaterialesConcreto" runat="server" CssClass="popupControl"
                                                                                                                        Height="800px" Width="320px">
                                                                                                                        <div style="text-align: center">
                                                                                                                            <table style="width: 90%">
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Image ID="imgAyudaModeloMaterialesConcreto1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgConcreto1.GIF" /></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:Label ID="lblTituloFigModeloMaterialesConcreto1" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                            Width="250px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesConcreto1" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td style="height: 20px">
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Image ID="imgAyudaModeloMaterialesConcreto2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgConcreto2.GIF" /></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:Label ID="lblTituloFigModeloMaterialesConcreto2" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                            Width="250px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesConcreto2" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td style="height: 20px">
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Image ID="imgAyudaModeloMaterialesConcreto3" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/ImagenesAyuda/imgConcreto3.GIF" /></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:Label ID="lblTituloFigModeloMaterialesConcreto3" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                                                                            Width="250px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesConcreto3" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td style="height: 20px">
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                            <asp:Label ID="lblAyudaModeloMaterialesConcreto4" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </div>
                                                                                                                    </asp:Panel>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="text-align: center">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="height: 30px; text-align: left;">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Image ID="imgAyudaConsiderar" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/help.gif" /></td>
                                                                                                                <td>
                                                                                                        <asp:Label ID="lblConsiderar" runat="server" CssClass="Funcionalidad-subtitulo" Text="ACCOUNT FOR:" style="text-align: left" Width="200px"></asp:Label></td>
                                                                                                                <td>
                                                                                                                    <cc1:PopupControlExtender ID="pceConsiderar" runat="server" TargetControlID="imgAyudaConsiderar" PopupControlID="panelConsiderar" Position="Bottom">
                                                                                                                    </cc1:PopupControlExtender>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td colspan="1" style="height: 30px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:Panel ID="panelConsiderar" runat="server" CssClass="popupControl" Height="180px"
                                                                                                            Width="320px">
                                                                                                            <div style="text-align: center">
                                                                                                                <table style="width: 90%; height: 90%">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 100px; height: 41px;">
                                                                                                                            <asp:Label ID="lblAyudaConsiderar" runat="server" CssClass="texto-interno-pequeno"
                                                                                                                                Width="300px"></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                    <td colspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        &nbsp;&nbsp;
                                                                                                        <asp:CheckBox ID="ckbPenetracDeform" runat="server" Text="PENETRATION OF DEFORMATION" Width="200px" CssClass="Funcionalidad-datos-entrada" /></td>
                                                                                                    <td colspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" style="text-align: left">
                                                                                                        &nbsp;&nbsp;
                                                                                                        <asp:CheckBox ID="ckbEfectPDelta" runat="server" Text="EFECT P DELTA" Width="200px" CssClass="Funcionalidad-datos-entrada" /></td>
                                                                                                    <td colspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="3" style="height: 20px; text-align: left">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="3" style="text-align: left">
                                                                                                        <table style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
                                                                                                            width: 40%; border-bottom: #000000 1px solid; background-color: #d5d6c9">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    <asp:Label ID="lblInstrucciones" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                                                                        Style="font-size: 10pt" Text="QUICK INSTRUCTIONS:" Width="300px"></asp:Label></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    <asp:Label ID="lblInstruccionesTodas" runat="server" Text="1) Enter parameters on above panel.<br>2) Press RUN SIMULATION button.<br>3) Press PLAY – PAUSE – STOP bottons.<br>4) Change parameters on above panel. <br>5) Repeat from step 2. <br>"
                                                                                                                        Width="300px"></asp:Label></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="3" style="text-align: left">
                                                                                                    </td>
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
                                                            <td>
                                                                                        <table style="width: 90%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div style="text-align: center">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    <chart:WebChartViewer ID="wcvGraficasSimula" runat="server" /></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <input id="txtMensaje" type="text" runat="server" style="background-color: transparent; background-image: none; font-size: 9pt;" class="Funcionalidad-Mensajes-Links" enableviewstate="true" size="35" /></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div style="text-align: center">
                                                                                                        <table style="width: 40%; border-right: lightgrey 1px ridge; border-top: lightgrey 1px ridge; border-left: lightgrey 1px ridge; border-bottom: lightgrey 1px ridge;">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div style="text-align: center">
                                                                                                                        <table style="width: 90%">
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <input id="cmdDibujarSimulacion" style="background-position: center center; background-image: url(../../Varios/Archivos/Imagenes/CICHA/Iconos/control_play_blue.png);
                                                                                                                                        width: 28px; background-repeat: no-repeat; height: 28px; background-color: transparent"
                                                                                                                                        type="button" onclick="return cmdDibujarSimulacion_onclick()" title="Play"/></td>
                                                                                                                                <td>
                                                                                                                                    <input id="cmdDetenerSimulacion" style="background-image: url(../../Varios/Archivos/Imagenes/CICHA/Iconos/control_pause_blue.png);
                                                                                                                        width: 28px; background-repeat: no-repeat; height: 28px; background-color: transparent; background-position: center center;"
                                                                                                                        type="button" onclick="return cmdDetenerSimulacion_onclick()" title="Pause" /></td>
                                                                                                                                <td>
                                                                                                                                    <input id="cmdLimpiarSimulacion" style="background-image: url(../../Varios/Archivos/Imagenes/CICHA/Iconos/control_stop_blue.png);
                                                                                                                        width: 28px; background-repeat: no-repeat; height: 28px; background-color: transparent; background-position: center center;"
                                                                                                                        type="button" onclick="return cmdLimpiarSimulacion_onclick()" title="Stop" /></td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <cc1:sliderextender id="SliderExtPlay" runat="server" Minimum="100" Maximum="1000" TargetControlID="txtSliderExtPlay" Length="100"  BoundControlID="txtSliderExtPlay_html"   ></cc1:sliderextender>                                                                                                               
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtSliderExtPlay" runat="server" Width="100px"></asp:TextBox></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <input id="txtSliderExtPlay_html" class="Funcionalidad-Mensajes-Links" style="width: 24px"
                                                                                                                        type="text" />&nbsp;
                                                                                                                    <asp:Label ID="lblSliderExtPlayUnidades" runat="server" CssClass="Funcionalidad-Mensajes-Links">UPDATE TIME (ms)</asp:Label></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 20px">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div style="text-align: center">
                                                                                                        <table id="TABLE1" runat="server" style="width: 50%">
                                                                                                            <tr>
                                                                                                                <td style="height: 30px">
                                                                <asp:Button ID="cmdSimular" runat="server" Text="RUN SIMULALATION" CssClass="Boton" Width="150px" /></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px">
                                                                                                                    <asp:Button ID="cmdEliminarTest" runat="server" CssClass="Boton" Text="DELETE ANALYSIS" Width="150px" Enabled="False" /></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px">
                                                                                                                    <asp:Button ID="cmdLimpiar" runat="server" CssClass="Boton" Text="CLEAR ALL ANALYSIS" Width="150px" /></td>
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
                                                                                            <tr>
                                                                                                <td>
                                                                    <asp:Label ID="lblMensaje" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                                                                                            </tr>
                                                                                        </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="width: 911px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 911px; height: 112px;" valign="middle">
                                                    <span style="color: #000000">Copyright © 2006 - 2008 VirtualLab UTPL. All rights reserved.
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 911px" valign="middle">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" style="width: 80%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 80%" valign="middle">
                                        <div style="text-align: center">
                                            <table style="width: 90%">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                        <asp:HiddenField ID="hiddIndicador" runat="server" />
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
