<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="wfAnalisisEspectralVersOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_Columna_wfAnalisisEspectral"%>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<%--Referencias a controles de Tipos de Exitacion--%>
<%@ Reference Control="Modulos/ctrlAcelerograma.ascx" %>
<%@ Reference Control="Modulos/ctrlCargaSinusoidal.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SPECTRUM</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
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
                                                <td align="center" class="Funcionalidad-titulo" style="width: 80%; height: 12pt" valign="middle">
                                                    <asp:Image ID="imgTituloLaboratorio" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-ES.png"
                                                        Style="position: static" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 50px;" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExperimento" runat="server" Font-Size="Large" Text="SPECTRUM"></asp:Label><br />
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="ANALISIS ESPECTRAL" CssClass="Funcionalidad-titulo"></asp:Label></td>
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
                                                                        <td rowspan="2" style="width: 30%; height: 564px;">
                                                                            <div style="text-align: center">
                                                                                <div style="text-align: center">
                                                                                    <div style="text-align: center">
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <table class="TablaDatos-Graficas" style="width: 95%; position: static; height: 90%">
                                                                                <tr>
                                                                                    <td class="PanelHeader" rowspan="1" style="border-top-width: 2px; border-left-width: 2px;
                                                                                        border-left-color: activeborder; border-bottom-width: 2px; border-bottom-color: activeborder;
                                                                                        width: 50%; border-top-color: activeborder; text-align: center; border-right-width: 2px;
                                                                                        border-right-color: activeborder">
                                                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="PARAMETROS" CssClass="Funcionalidad-subtitulo" style="position: static"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%; text-align: center">
                                                                                        <asp:Label ID="lblTituloEsquemaColumna" runat="server" CssClass="Funcionalidad-titulo"
                                                                                            Text="SECTION"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="1" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                                        width: 50%; border-top-color: activeborder; text-align: center; border-right-color: activeborder" valign="top">
                                                                                        <table style="border-top-width: 1px; width: 450px; border-top-color: activecaption;
                                                                                            height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 17px">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                            <asp:TextBox ID="tbPeriodo1" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False" Font-Underline="False" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%; height: 26px">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblPeriodo1" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Text="PERIODO 1(s)" style="position: static"></asp:Label>
                                                                                                        </strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%; height: 26px">
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPeriodo1"
                                                                                                            ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbPeriodo2" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static"
                                                                                                Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblPeriodo2" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Style="position: static" Text="PERIODO 2 (s)"></asp:Label>
                                                                                                        </strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPeriodo2"
                                                                                                            ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbNumPuntos" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static"
                                                                                                Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblNumPuntos" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Style="position: static" Text="NÚMERO DE PUNTOS"></asp:Label>
                                                                                                        </strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNumPuntos"
                                                                                                            ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbMasa" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static"
                                                                                                Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblMasa" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Style="position: static" Text="MASA (tonne)"></asp:Label>
                                                                                                    </td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbMasa"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px" align="right">
                                                                                            <asp:RadioButton ID="rbAnalisisElastico" runat="server" Style="position: static" AutoPostBack="True" Checked="True" GroupName="gTipoAnalisis" /></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblAElastico" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Style="position: static" Text="ANALISIS ELASTICO"></asp:Label>
                                                                                                    </strong>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbDamping1" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblDamping1" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="DAMPING 1 %" Width="97px"></asp:Label>
                                                                                                    </td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbDamping1"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbDamping2" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                            <asp:Label ID="lblDamping2" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="DAMPING 2 %" Width="101px"></asp:Label>
                                                                                                        </strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbDamping2"
                                                                                                            ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbNumCurvas" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblNumCurvas" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="NÚMERO DE CURVAS" Width="242px"></asp:Label>
                                                                                                    </td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbNumCurvas"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px" align="right">
                                                                                            <asp:RadioButton ID="rbAnalisisInelastico" runat="server" GroupName="gTipoAnalisis" Style="position: static" AutoPostBack="True" /></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                <asp:Label ID="lblAInelastico" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Style="position: static" Text="ANALISIS INELASTICO" Width="128px"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbDamping3" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblDamping3" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="DAMPING %" Width="279px"></asp:Label>
                                                                                                    </td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbDamping3"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbR1" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblR1" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Style="position: static" Text="R1" Width="212px"></asp:Label>
                                                                                                    </td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbR1"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbR2" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblR2" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                                                                Style="position: static" Text="R2" Width="210px"></asp:Label>
                                                                                                    </td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbR2"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbCoefRigidez" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblCoefRigidez" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="COEFICIENTE DE RIGIDEZ POST FLUENCIA" Width="240px"></asp:Label>
                                                                                                    </td>
                                                                                                <td style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbCoefRigidez"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                            <asp:TextBox ID="tbNumCurvas2" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Font-Bold="False" Font-Italic="False" Font-Underline="False" Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                            <asp:Label ID="lblNumCurvas2" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                Font-Bold="False" Style="position: static" Text="NUMERO DE CURVAS"
                                                                                                Width="204px"></asp:Label>
                                                                                                    </td>
                                                                                                <td align="left" style="width: 100px; height: 14px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbNumCurvas2"
                                                                                                        ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td colspan="2" style="height: 17px">
                                                                                            </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" rowspan="6">
                                                                                                    <strong></strong>
                                                                                                    <strong></strong>
                                                                                                    <strong></strong>
                                                                                                    <strong></strong>
                                                                                                    <strong></strong>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                            </tr>
                                                                                            <tr>
                                                                                            </tr>
                                                                                            <tr>
                                                                                            </tr>
                                                                                            <tr>
                                                                                            </tr>
                                                                                            <tr>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 50%; text-align: center" valign="top">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Image ID="img1" runat="server" Style="position: static" Height="248px" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/EN/1_EN.jpg" Width="424px" CssClass="TablaDatosEntrada" /><br />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <asp:Image ID="img2" runat="server" Style="position: static" Height="248px" ImageUrl="~/VirtualLabis/Varios/Archivos/Imagenes/Dinamica/ES/6_ES.jpg" Width="424px" Visible="False" />
                                                                                                    <asp:Image ID="img3" runat="server" Style="position: static" Height="248px" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/ES/7_ES.jpg" Width="424px" Visible="False" /></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br />
                                                                            <table class="TablaDatosEntrada" style="width: 95%">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" Text="TIPO DE EXITACION" CssClass="Funcionalidad-subtitulo" style="position: static"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 213px">
                                                                                        &nbsp;<asp:RadioButton ID="rbCargaSinusoidal" runat="server" Checked="True" GroupName="groupTipoExitacion"
                                                                                                Style="position: static" AutoPostBack="True" />
                                                                                                <asp:Label ID="lblCargaSinusoidal" runat="server" Font-Bold="False" Text="FUNCION DE CARGA SINUSOIDAL" CssClass="Funcionalidad-datos-entrada" style="position: static" Font-Underline="False"></asp:Label></td>
                                                                                    <td style="width: 233px">
                                                                                            <asp:RadioButton ID="rbAcelerograma" runat="server" GroupName="groupTipoExitacion"
                                                                                                Style="position: static" AutoPostBack="True" />
                                                                                        <asp:Label ID="lblAcelerograma" runat="server" Font-Bold="False" Text="ACELEROGRAMA" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="1">
                                                                            
                                                                                <asp:PlaceHolder ID="phTipoExitacion" runat="server"></asp:PlaceHolder>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="1" style="height: 53px">
                                                                            <div style="text-align: center">
                                                                                <table style="width: 40%">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static"
                                                                                                Text="Ejecutar" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>                                                                                     
                                           
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 95%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td class="PanelHeader" colspan="2" style="height: 11px">
                                                                    <asp:Label ID="lblTituloFig1" runat="server" Text="FIG. 1 ESPECTRO DE ACELERACIÓN" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%">
                                                                        <table style="width: 90%; height: 90%">
                                                                            <tr>
                                                                                <td style="width: 434px"><chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" style="width: 434px">
                                                                                    <asp:Button ID="btnGetResult1" runat="server" CssClass="Boton" Text="Get Results" /></td>
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
                                                    <table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig2" runat="server"
                                                                    Text="FIG. 2 ESPECTRO DE VELOCIDAD" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                    <chart:WebChartViewer ID="WebChartViewer2" runat="server" style="position: static" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 434px">
                                                                                <asp:Button ID="btnGetResult2" runat="server" CssClass="Boton" Text="Get Results" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <a name="linkGrafica2">linkGrafica2</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                    <table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig3"
                                                                    runat="server" Text="FIG. 3 ESPECTRO DE DESPLAZAMIENTO" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                    <table style="width: 90%; height: 90%">
                                                                        <tr>
                                                                            <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer3" runat="server" style="position: static" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 434px">
                                                                                <asp:Button ID="btnGetResult3" runat="server" CssClass="Boton" Text="Get Results" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 80%; height: 150px" valign="middle"><table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                    <tr>
                                                        <td class="PanelHeader" colspan="2" rowspan="1">
                                                            <asp:Label ID="lblTituloFig4" runat="server" CssClass="Funcionalidad-titulo" Text="FIG. 4 ESPECTRO DE DUCTILIDAD"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <table style="width: 90%; height: 90%">
                                                                <tr>
                                                                    <td style="width: 434px">
                                                                                <chart:WebChartViewer ID="WebChartViewer4" runat="server" style="position: static" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 434px">
                                                                        <asp:Button ID="btnGetResult4" runat="server" CssClass="Boton" Text="Get Results" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    <a name="linkGrafica3">linkGrafica3</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 80%; height: 112px;" valign="middle">
                                                    <span style="color: #000000">
                                                        Copyright © 2008 &nbsp;VirtualLab UTPL. All rights reserved.
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
