<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfExperimentoCICHA_Original.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_CICHA_wfExperimentoCICHA"%>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<%--Tipos de Especimenes--%>
<%@ Reference Control="~/VirtualLabIS/Experimentos/CICHA/Modulos/ctrlSpecimenCircular.ascx" %>
<%@ Reference Control="~/VirtualLabIS/Experimentos/CICHA/Modulos/ctrlSpecimenRectangular.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CICHA</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
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
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="VIRTUAL SETUP FOR REINFORCED CONCRETE <br> COLUMN SIMULATION" CssClass="Funcionalidad-titulo"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="height: 80px" valign="middle">
                                                    <table class="TablaDatos-Graficas" style="width: 60%;">
                                                        <tr>
                                                            <td colspan="2" style="height: 20px" class="PanelHeader">
                                                                <asp:Label ID="lblSelectTest" runat="server" CssClass="Funcionalidad-titulo" Text="SELECT A TEST"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 20px">
                                                                <div style="text-align: center">
                                                                    <table style="width: 90%">
                                                                        <tr>
                                                                            <td style="width: 100px; text-align: left">
                                                                <asp:Label ID="lblTipoSeccion" runat="server" Text="COLUMN SECTION:" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                            <td style="width: 100px; text-align: left">
                                                                <asp:RadioButton ID="radCircular" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Circular" GroupName="grpSeccionColumna" AutoPostBack="True" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px">
                                                                            </td>
                                                                            <td style="width: 100px; text-align: left">
                                                                <asp:RadioButton ID="radRectangular" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Rectangular" GroupName="grpSeccionColumna" AutoPostBack="True" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px; text-align: left">
                                                                <asp:Label ID="lblTestSpec" runat="server" Text="TEST:" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                                                            <td style="width: 100px; text-align: left">
                                                                <asp:DropDownList ID="ddlSpecimen" runat="server" Width="250px" AutoPostBack="True">
                                                                </asp:DropDownList></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center">
                                                                    <table style="width: 50%">
                                                                        <tr>
                                                                            <td style="text-align: center;">
                                                                                <asp:Button ID="cmdNuevoSpecimen" runat="server" CssClass="Boton" Text="NEW" Width="70px" /></td>
                                                                            <td style="text-align: center;">
                                                                <asp:Button ID="cmdIrExp" runat="server" Text="SETUP" CssClass="Boton" Width="70px" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 15px">
                                                                <div style="text-align: center">
                                                                    <asp:Label ID="lblMensajesError" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label>&nbsp;</div>
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
                                                    <div style="text-align: center">
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
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle" style="height: 30px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <table style="height: 90%" class="TablaDatos-Graficas" id="tblFiles" runat="server">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="4">
                                                                <asp:Label ID="lblFiles" runat="server" CssClass="Funcionalidad-titulo" Text="FILES"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblIngRespuestaReal" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                    Text="SIMULATION FILE f,d(mm):" Width="152px"></asp:Label></td>
                                                            <td>
                                                                <asp:FileUpload ID="fupIngRespuestaReal" runat="server" CssClass="Boton" /></td>
                                                            <td style="text-align: center">
                                                                <asp:Button ID="cmdIngRespuestaReal" runat="server" CssClass="Boton" Text="LoadFile Simulation"
                                                                    Width="130px" /></td>
                                                            <td>
                                                                <asp:Label ID="lblIngRespuestaRealEstado" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                    Width="180px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblIngArchivoTCL" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                    Text="TCL FILE:" Width="152px"></asp:Label></td>
                                                            <td>
                                                                <asp:FileUpload ID="fupIngArchivoTCL" runat="server" CssClass="Boton" /></td>
                                                            <td style="text-align: center">
                                                                <asp:Button ID="cmdIngArchivoTCL" runat="server" CssClass="Boton" Text="LoadFile TCL"
                                                                    Width="130px" /></td>
                                                            <td>
                                                                <asp:Label ID="lblIngArchivoTCLEstado" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                                                    Width="180px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 4px">
                                                            </td>
                                                            <td style="height: 4px">
                                                                &nbsp;</td>
                                                            <td style="text-align: center; height: 4px;">
                                                                </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" valign="middle">
                                                    <table style="width: 40%">
                                                        <tr>
                                                                            <td style="width: 100px; height: 26px;">
                                                                                &nbsp;<asp:Button ID="cmdGuardarSpecimen" runat="server" CssClass="Boton" Text="SAVE" Width="70px" /></td>
                                                                            <td style="width: 50%;">
                                                                                <asp:Button ID="cmdEliminarSpecimen" runat="server" CssClass="Boton" Text="DELETE"
                                                                                    Width="70px" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 26px">
                                                                <asp:Label ID="lblMensajeError2" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                                                        </tr>
                                                    </table>
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
