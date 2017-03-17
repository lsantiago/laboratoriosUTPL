<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="wfLinearizacionEquivalenteVersOriginal.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LinearizacionEquivalente_wfLinearizacionEquivalente"%>

<%@ Register Src="Modulos/ctrlAcelerograma.ascx" TagName="ctrlAcelerograma" TagPrefix="uc1" %>
<%@ Register Src="Modulos/ctrlAcelerograma.ascx" TagName="ctrlAcelerograma" TagPrefix="uc2" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<%--<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<%@ Register Src="~/VirtualLabIS/Experimentos/LinearizacionEquivalente/Modulos/ctrlAcelerograma.ascx" TagPrefix="uc2" TagName="ctrlAcelerograma" %>--%>


<%--Referencias a controles de Tipos de Exitacion--%>
<%@ Reference Control="Modulos/ctrlAcelerograma.ascx" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LINEARIZATION</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../Varios/Archivos/Scripts/ActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript">function IMG1_onclick() {

}

</script>
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
                                                <td align="center" class="Ocultar-texto" valign="middle" style="width: 1016px">
                                                   <a name="#linkInicio">linkInicio</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Funcionalidad-titulo" style="width: 1016px; height: 12pt" valign="middle">
                                                    &nbsp;<asp:Image ID="imgTituloLaboratorio" runat="server" ImageUrl="~/VirtualLab/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-ES.png"
                                                        Style="position: static" /></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 50px; width: 1016px;" valign="middle" class="Funcionalidad-titulo">
                                                    <asp:Label ID="lblTituloExperimento" runat="server" Font-Size="Large" Text="LINEARIZATION"></asp:Label><br />
                                                    <asp:Label ID="lblTituloExp" runat="server" Text="LINEARIZACION EQUIVALENTE" CssClass="Funcionalidad-titulo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1016px" valign="middle">
                                                   <a name="#linkExperimento" style="width: 80%; height: 150px">linkExperimento</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1016px; height: 100%" valign="middle">
                                                    <div style="text-align: center">
                                                        <div style="text-align: center">
                                                            <div style="text-align: center">
                                                                <table style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td rowspan="2" style="width: 30%;">
                                                                            <div style="text-align: center">
                                                                                <div style="text-align: center">
                                                                                    <div style="text-align: center">
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <table class="TablaDatos-Graficas" style="width: 95%; position: static;">
                                                                                <tr>
                                                                                    <td class="PanelHeader" rowspan="1" style="border-top-width: 2px; border-left-width: 2px;
                                                                                        border-left-color: activeborder; border-bottom-width: 2px; border-bottom-color: activeborder;
                                                                                        width: 50%; border-top-color: activeborder; text-align: center; border-right-width: 2px;
                                                                                        border-right-color: activeborder" align="left">
                                                                                        <asp:Label ID="lblTituloSeccionProper" runat="server" CssClass="Funcionalidad-subtitulo"
                                                                                            Style="position: static" Text="PARAMETROS" Font-Bold="True"></asp:Label></td>
                                                                                    <td class="PanelHeader" style="width: 50%; text-align: center">
                                                                                        <asp:Label ID="lblTituloEsquemaColumna" runat="server" CssClass="Funcionalidad-titulo"
                                                                                            Text="SECTION" ForeColor="RoyalBlue"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="3" style="border-left-color: activeborder; border-bottom-color: activeborder;
                                                                                        width: 55%; border-top-color: activeborder; text-align: center; border-right-color: activeborder" valign="top">
                                                                                        <table style="border-top-width: 1px; width: 90%; border-top-color: activecaption;
                                                                                            height: 90%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 17px">
                                                                                            </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                            <asp:TextBox ID="txtPeriodo" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" Font-Bold="False" Font-Italic="False" Font-Underline="False" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%; height: 26px">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblPeriodo" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                                                                    Font-Bold="False" Text="PERIODO T(s)" style="position: static"></asp:Label></strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%; height: 26px">
                                                                                                    <asp:RequiredFieldValidator ID="rfvPeriodo" runat="server" ControlToValidate="txtPeriodo"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtMasa" runat="server" Width="52px" CssClass="Funcionalidad-textbox-habilitado" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblMasa" runat="server" Font-Bold="False" Text="MASA M(tonne)" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="rfvMasa" runat="server" ControlToValidate="txtMasa"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtFuerzaFluecia" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblFuerzaFluecia" runat="server" Font-Bold="False" Text="FUERZA DE FLUENCIA Fy(kN)" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="rfvFuerzaFluecia" runat="server" ControlToValidate="txtFuerzaFluecia"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtCoefRigPFluen" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblAcelInicial" runat="server" Text="COEFICIENTE DE RIGIDEZ  POST FLUENCIA r" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="rfvAcelInicial" runat="server" ControlToValidate="txtCoefRigPFluen"
                                                                                                ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="txtMasaProporcional" runat="server" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Width="52px" AutoCompleteType="Disabled" style="position: static"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <strong>
                                                                                                <asp:Label ID="lblMasaProporcional" runat="server" Font-Bold="False" Text="AMORTIGUAMIENTO PROPORCIONAL A LA MASA ξ(%)" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></strong></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="rfvMasaProporcional" runat="server" ControlToValidate="txtMasaProporcional"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 81px; height: 24px">
                                                                                            <asp:TextBox ID="tbDuctilidad" runat="server" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"
                                                                                                Style="position: static" Width="52px"></asp:TextBox></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                            <asp:Label ID="lblDuctilidad" runat="server" Text="DUCTILIDAD META" CssClass="Funcionalidad-datos-entrada" style="position: static"></asp:Label></td>
                                                                                                <td class="Funcionalidad-datos-entrada" style="width: 100%">
                                                                                                    <asp:RequiredFieldValidator ID="rfvDuctilidad" runat="server" ControlToValidate="tbDuctilidad"
                                                                                                ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="Funcionalidad-datos-entrada" colspan="2">
                                                                                                    &nbsp;<strong></strong></td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td style="width: 81px; height: 14px">
                                                                                                </td>
                                                                                                <td style="width: 100px; height: 14px">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="font-weight: bold">
                                                                                                <td colspan="2" style="height: 17px">
                                                                                                    </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 50%; text-align: center" valign="top">
                                                                                        <table style="width: 100%; height: 100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Image ID="img1" runat="server" Height="248px" Style="position: static" Width="424px" ImageUrl="~/VirtualLab/Varios/Archivos/Imagenes/Dinamica/ES/1_ES.jpg" />
                                                                                                    &nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="1">
                                                                                            <uc1:ctrlAcelerograma ID="CtrlAcelerograma1" runat="server" />
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="3" rowspan="1">
                                                                                            <asp:Button ID="btnGraficar" runat="server" CssClass="Boton" Style="position: static"
                                                                                                Text="EJECUTAR" /><asp:Button ID="btnBorrarUltimoTest" runat="server" CausesValidation="False"
                                                                                                    CssClass="Boton" Text="Eliminar Último Test" Width="179px" /><asp:Button ID="btnBorrarTodosTests"
                                                                                                        runat="server" CausesValidation="False" CssClass="Boton" Text="Borrar Todos Test"
                                                                                                        Width="179px" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="1">
                                                                            <div style="text-align: center">
                                                                                <table style="width: 40%">
                                                                                    <tr>
                                                                                        <td style="width: 100px">
                                                                                            <asp:Label ID="lblResultados" runat="server" CssClass="Funcionalidad-subtitulo" ForeColor="Red"
                                                                                                Style="position: static" Text="RESULTADOS" Visible="False"></asp:Label></td>
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
                                                <td align="center" style="width: 1016px" valign="middle">
                                                    <div style="text-align: center">
                                                        <table style="width: 95%; height: 90%" class="TablaDatos-Graficas">
                                                            <tr>
                                                                <td class="PanelHeader" colspan="2" style="height: 11px">
                                                                    <asp:Label ID="lblTituloFig1" runat="server" Text="FIG. 1 REDUCCION DE FUERZA vs. DUCTILIDAD" CssClass="Funcionalidad-titulo"></asp:Label></td>
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
                                                                                    <asp:Button ID="btnGetResult1" runat="server" CssClass="Boton" Text="Get Results" CausesValidation="False" /></td>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1016px; height: 150px" valign="middle">
                                                    <table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig2" runat="server"
                                                                    Text="FIG. 2  COEFICIENTE DE DESPLAZAMIENTO vs DUCTILIDAD" CssClass="Funcionalidad-titulo"></asp:Label></td>
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
                                                                                <asp:Button ID="btnGetResult2" runat="server" CssClass="Boton" Text="Get Results" CausesValidation="False" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <a name="linkGrafica2">linkGrafica2</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1016px" valign="middle">
                                                    <table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                        <tr>
                                                            <td class="PanelHeader" colspan="2" rowspan="1">
                                                                <asp:Label ID="lblTituloFig3"
                                                                    runat="server" Text="FIG. 3 AMORTIGUAMIENTO VISCOSO EQUIVALENTE vs. DUCTILIDAD" CssClass="Funcionalidad-titulo"></asp:Label></td>
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
                                                                                <asp:Button ID="btnGetResult3" runat="server" CssClass="Boton" Text="Get Results" CausesValidation="False" /></td>
                                                                        </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="Ocultar-texto" style="width: 1016px; height: 150px" valign="middle"><table style="width: 95%; height: 90%; position: static;" class="TablaDatos-Graficas">
                                                    <tr>
                                                        <td class="PanelHeader" colspan="2" rowspan="1">
                                                            <asp:Label ID="lblTituloFig4" runat="server" CssClass="Funcionalidad-titulo" Text="FIG. 4 ALARGAMIENTO DE PERIODO vs. DUCTILIDAD"></asp:Label></td>
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
                                                                        <asp:Button ID="btnGetResult4" runat="server" CssClass="Boton" Text="Get Results" CausesValidation="False" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    <a name="linkGrafica3">linkGrafica3</a></td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1016px; height: 112px;" valign="middle">
                                                    <span style="color: #000000">
                                                        Copyright © 2008 &nbsp;VirtualLab UTPL. All rights reserved.
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 1016px" valign="middle">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" style="width: 80%">
                                        &nbsp;</td>
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
