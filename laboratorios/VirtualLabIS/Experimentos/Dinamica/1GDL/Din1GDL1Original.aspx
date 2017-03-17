


<%@ Page Language="VB" AutoEventWireup="false"  MaintainScrollPositionOnPostback ="true" CodeFile="Din1GDL1Original.aspx.vb" Inherits="VirtualLabIS_Experimentos_Dinamica_1GDL_Din1GDL1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="../../../../VirtualLabIS/Varios/Archivos/Styles/estilosdinamica.css" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="EstiloP" style="text-align: center">
        &nbsp;<table>
            <tr>
                <td style="width: 800px">
                    <asp:Image ID="imgCaratula" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png" /></td>
         
              
            </tr>
            <tr>
                <td style="width: 800px">
                    <asp:Label ID="lblNameTool" runat="server" Font-Bold="True" Font-Size="Large" Style="position: static"
                        Text="SDOF-Dynamics"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td>
         <asp:Label ID="lblTitulo1GDLtool1" runat="server" Font-Bold="True" Font-Size="Small"
                            Style="position: static" Text="Analisis dinámico de un sistema de 1GDL" ></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 800px; height: 252px">
                    &nbsp;<table class="TablaDatos-Graficas" style="width: 800px" >
                        <tr>
                            <td style="text-align: center; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; width: 944px;">
                            <asp:Label ID="lblProSis" runat="server" CssClass="Funcionalidad-subtitulo" Text="PROPIEDADES DEL SISTEMA"
                            Width="200px"></asp:Label>
                            </td>
                            <td style="text-align: center; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; width: 514px;">
                            <asp:Label ID="lblEsquemaMain" runat="server" CssClass="Funcionalidad-subtitulo"
                        Text="ESQUEMA" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 944px; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; text-align: center;">
                                <table>
                                    <tr>
                                        <td colspan="2" style="width: 38px; height: 17px">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" CssClass="Funcionalidad-subtitulo" Text="T ="
                                                    Width="31px"></asp:Label></strong></td>
                                        <td colspan="1" style="height: 17px">
                                            <asp:TextBox ID="txtT" runat="server" Width="50px"></asp:TextBox>&nbsp;<cc1:filteredtextboxextender
                                                id="FilteredTextBoxExtender1" runat="server" filtertype="Custom, numbers" targetcontrolid="txtT"
                                                validchars="."></cc1:filteredtextboxextender></td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px; height: 17px">
                                            <asp:Label ID="lblT" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Periodo [s] " Width="90px"></asp:Label>&nbsp;
                                            <asp:Label
                                                ID="llbFT" runat="server" CssClass="Funcionalidad-datos-entrada"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="Funcionalidad-datos-entrada" colspan="2" style="width: 38px">
                                            &nbsp;<asp:Label ID="Label11" runat="server" CssClass="Funcionalidad-subtitulo" Text="m ="
                                                Width="31px"></asp:Label></td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1">
                                            <asp:TextBox ID="txtM" runat="server" Width="50px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender2" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtM" validchars="."></cc1:filteredtextboxextender>
                                        </td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px">
                                            <asp:Label ID="lblM" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Masa  [Tonne =kN.s^2/m =kN/g]"
                                                Width="183px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="Funcionalidad-datos-entrada" colspan="2" style="width: 38px">
                                            <asp:Label ID="Label12" runat="server" CssClass="Funcionalidad-subtitulo" Text="ξ   ="
                                                Width="31px"></asp:Label></td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1">
                                            <asp:TextBox ID="txtA" runat="server" Width="50px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender3" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtA" validchars="."></cc1:filteredtextboxextender>
                                        </td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px">
                                            <asp:Label ID="lblA" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Amortiguamiento [%]"
                                                Width="137px"></asp:Label></td>
                                    </tr>
                                    <tr style="font-weight: bold">
                                        <td colspan="2" style="width: 38px; height: 14px">
                                        </td>
                                        <td colspan="1" style="height: 14px">
                                            &nbsp;</td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px; height: 14px">
                                        </td>
                                    </tr>
                                    <tr style="font-weight: bold">
                                        <td colspan="2" style="width: 38px; height: 14px">
                                        </td>
                                        <td colspan="1" style="height: 14px">
                                            &nbsp;</td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px; height: 14px">
                                        </td>
                                    </tr>
                                    <tr style="font-weight: bold">
                                        <td colspan="2" style="width: 38px; height: 14px">
                                        </td>
                                        <td colspan="1" style="height: 14px">
                                            &nbsp;</td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px; height: 14px">
                                        </td>
                                    </tr>
                                    <tr style="font-weight: bold">
                                        <td colspan="2" style="width: 38px; height: 14px">
                                        </td>
                                        <td colspan="1" style="height: 14px">
                                            &nbsp;</td>
                                        <td class="Funcionalidad-datos-entrada" colspan="1" style="width: 1px; height: 14px">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <asp:Label ID="Label19" runat="server" Width="330px"></asp:Label></td>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; width: 470px;" align="right">
                                <asp:Image ID="FigMain" runat="server" Height="200px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/Tools/Dinamica_1GDL_Tool1.bmp"
                                    Width="440px" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 800px; height: 252px">
                    &nbsp;<table class="TablaDatos-Graficas" style="width:800px;">
                        <tr>
                            <td colspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                text-align: center">
                                    <asp:Label ID="lblTM" runat="server" CssClass="Funcionalidad-subtitulo" Text="TIPO DE MATERIAL" Width="209px"></asp:Label></td>
                            <td rowspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                text-align: center">
                                <asp:Label ID="lblCT" runat="server" CssClass="Funcionalidad-subtitulo" Text="COMPORTAMIENTO TIPO"
                                    Width="242px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style=" text-align: left; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;">
                                &nbsp;<asp:Label ID="lblEscTM" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Seleccionar:" Font-Bold="True" Font-Size="Small" Width="97px"></asp:Label>&nbsp;<asp:DropDownList ID="DDLmatTyp" runat="server" AutoPostBack="True" Height="24px"
                                    Width="115px">
                                    <asp:ListItem Selected="True" Value="0">El&#225;stico</asp:ListItem>
                                    <asp:ListItem Value="1">Bilineal 1</asp:ListItem>
                                    <asp:ListItem Value="2">Bilineal 2</asp:ListItem>
                                </asp:DropDownList><br />
                                <br />
                                <asp:Panel ID="panBlineal1" runat="server" Height="44px" Width="322px" Direction="LeftToRight">
                                    <table style="width: 290px; height: 61px">
                                        <tr>
                                            <td style="width: 35px" >
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Fy =" Width="36px"></asp:Label></strong></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtFy" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style=" text-align: left">
                                                <asp:Label ID="lblFyMat21" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                    Text="Fuerza de Fluencia  [kN]"></asp:Label>
                                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender4" runat="server" filtertype="Custom, numbers"
                                                    targetcontrolid="txtFy" validchars="."></cc1:filteredtextboxextender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35px">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="r =" Width="36px"></asp:Label></strong></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtr" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblrMat21" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Coeficiente Post-Fluencia" Width="191px"></asp:Label>
                                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender5" runat="server" filtertype="Custom, numbers"
                                                    targetcontrolid="txtr" validchars="."></cc1:filteredtextboxextender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <asp:Panel ID="panBlineal2" runat="server" Height="44px" Width="305px">
                                    <table style="width: 319px; height: 61px">
                                        <tr>
                                            <td >
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Fy =" Width="32px"></asp:Label></strong></td>
                                            <td>
                                                <asp:TextBox ID="txtFy1" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style=" text-align: left">
                                                <asp:Label ID="lblFyMat31" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                    Text="Fuerza de Fluencia  [kN]" Width="188px"></asp:Label>
                                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender6" runat="server" filtertype="Custom, numbers"
                                                    targetcontrolid="txtFy1" validchars="."></cc1:filteredtextboxextender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 195px">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="r =" Width="36px"></asp:Label></strong></td>
                                            <td>
                                                <asp:TextBox ID="txtr1" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style="width: 795px; text-align: left">
                                                <asp:Label ID="lblrMat31" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Coeficiente Post-Fluencia"
                                                    Width="190px"></asp:Label>
                                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender7" runat="server" filtertype="Custom, numbers"
                                                    targetcontrolid="txtr1" validchars="."></cc1:filteredtextboxextender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 195px">
                                                <strong>
                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="R =" Width="36px"></asp:Label></strong></td>
                                            <td>
                                                <asp:TextBox ID="txtRo" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style="width: 795px; text-align: left">
                                                <asp:Label ID="lblRoMat31" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                    Text="Val. Recom: 10 a 20" Width="211px"></asp:Label>&nbsp;<cc1:filteredtextboxextender
                                                        id="FilteredTextBoxExtender8" runat="server" filtertype="Custom, numbers" targetcontrolid="txtRo"
                                                        validchars="."></cc1:filteredtextboxextender></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label20" runat="server" Width="340px"></asp:Label></td>
                            <td align="center" rowspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; width: 470px;">
                                &nbsp;&nbsp;<br />
                                <br />
                                <asp:Image ID="FigMat1" runat="server" Height="27px" Width="28px" /><asp:Image ID="FigMat2"
                                    runat="server" Height="27px" Width="24px" /><asp:Image ID="FigMat3" runat="server"
                                        Height="28px" Width="25px" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 800px; height: 252px">
                    &nbsp;<table class="TablaDatos-Graficas" style="width: 800px;">
                        <tr>
                            <td colspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                left: 0%; border-left: darkgray thin solid; border-bottom: darkgray thin solid;
                                position: relative; top: 0px; height: 0%; text-align: center">
                                    <asp:Label ID="lblTE" runat="server" CssClass="Funcionalidad-subtitulo" Text="TIPO DE EXITACIÓN"></asp:Label></td>
                            <td rowspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                text-align: center">
                                
                               
                                <asp:Label ID="lblEsqTE" runat="server" CssClass="Funcionalidad-subtitulo" Text="ESQUEMA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid;">
                                    <asp:Label ID="lblEscTE" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Seleccionar: "
                                        Width="106px" Font-Bold="True" Font-Size="Small"></asp:Label>
                                <asp:DropDownList ID="DDLexiTyp" runat="server" AutoPostBack="True" Height="24px"
                                    Width="194px" Font-Bold="False">
                                    <asp:ListItem Value="0">Funci&#243;n lineal</asp:ListItem>
                                    <asp:ListItem Value="1">Funci&#243;n trilineal</asp:ListItem>
                                    <asp:ListItem Value="2">Funci&#243;n sinusoidal</asp:ListItem>
                                    <asp:ListItem Value="3">Acelerograma</asp:ListItem>
                                </asp:DropDownList></td>
                            <td align="center" rowspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; border-bottom: darkgray thin solid; width: 500px;">
                                &nbsp;<br />
                                <br />
                                &nbsp;<br />
                                <asp:Image ID="FigExi1" runat="server" Height="33px" Width="36px" /><asp:Image ID="FigExi2"
                                    runat="server" Height="32px" Width="41px" /><asp:Image ID="FigExi3" runat="server"
                                        Height="33px" Width="40px" /><asp:Image ID="FigExi4" runat="server" Height="33px"
                                            Width="42px" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border-right: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;" align="left">
                                &nbsp;&nbsp;
                                <br />
                                    <asp:Panel ID="panFS" runat="server" Height="50px" Width="189px">
                                        <table>
                                            <tr>
                                                <td style="width: 473px">
                                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Po  =" Width="30px"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtFo" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; text-align: left">
                                                    <asp:Label ID="lblPo" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Amplitud [kN]"
                                                        Width="165px"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender9" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtFo" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 473px; height: 28px;">
                                                    <strong><span lang="ES-TRAD" 
                                                         
                                                        ><span style="font-size: 11pt"><span style="font-family: Symbol">
                                                        w</span> </span>
                                                        =</span></strong></td>
                                                <td style="width: 100px; height: 28px;">
                                                    <asp:TextBox ID="txtWa" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; text-align: left; height: 28px;">
                                                    <asp:Label ID="lblFrecuenciaE" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                        Text="Frecuencia [rad/s]" Width="163px"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender10" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtWa" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="3">
                                        <asp:Label ID="lblFS" runat="server" CssClass="Funcionalidad-datos-entrada" Text="P(t) = Po.Sin(w.t)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                            </tr>
                                        </table>
                                        </asp:Panel>
                                &nbsp;&nbsp;<br /><asp:Panel ID="panFL" runat="server" Height="40px" Width="125px">
                                            <table>
                                                <tr>
                                                    <td style="width: 100px">
                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="I  =" Width="25px"></asp:Label></td>
                                                    <td style="width: 100px">
                                                    <asp:TextBox ID="txtI" runat="server" Width="50px"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    <asp:Label ID="lblI" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Magnitud del impulso [kN/s]"
                                                        Width="192px"></asp:Label>
                                                        <cc1:filteredtextboxextender id="FilteredTextBoxExtender11" runat="server" filtertype="Custom, numbers"
                                                            targetcontrolid="txtI" validchars="."></cc1:filteredtextboxextender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="DI =" Width="28px"></asp:Label></td>
                                                    <td style="width: 100px">
                                                    <asp:TextBox ID="txtDI" runat="server" Width="50px"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    <asp:Label ID="lblDI" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Duración del impulso [s]" Width="180px"></asp:Label>
                                                        <cc1:filteredtextboxextender id="FilteredTextBoxExtender12" runat="server" filtertype="Custom, numbers"
                                                            targetcontrolid="txtDI" validchars="."></cc1:filteredtextboxextender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="height: 20px">
                                        <asp:Label ID="lblEcFL" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Pmax = (I).(DI)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                &nbsp; &nbsp; &nbsp;<br />
                                    <asp:Panel ID="panFT" runat="server" Height="50px" Width="125px">
                                        <table id="Table2";>
                                            <tr>
                                                <td style="width: 50px">
                                                    <asp:Label ID="Label14" runat="server" Text="Pmax  =" Width="47px" Font-Bold="True"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtFmax" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; text-align: left">
                                                    <asp:Label ID="lblPmax" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Carga máxima [kN]" Width="127px"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender13" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtFmax" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50px; height: 26px">
                                                    <strong>t<span style="font-size: 6pt">1</span> =</strong></td>
                                                <td style="width: 100px; height: 26px">
                                                    <asp:TextBox ID="txtT1" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; height: 26px; text-align: left">
                                                    <asp:Label ID="lblT1" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 1 [s]"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender14" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtT1" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50px; height: 26px;">
                                                    <strong>t<span style="font-size: 6pt">2</span> =</strong></td>
                                                <td style="width: 100px; height: 26px;">
                                                    <asp:TextBox ID="txtT2" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; text-align: left; height: 26px;">
                                                    <asp:Label ID="lblT2" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 2 [s]"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender15" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtT2" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50px">
                                                    <strong>t<span style="font-size: 6pt">3 </span>=</strong></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtT3" runat="server" Width="50px"></asp:TextBox></td>
                                                <td style="width: 491px; text-align: left">
                                                    <asp:Label ID="lblT3" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 3 [s]" Width="76px"></asp:Label>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender16" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtT3" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                &nbsp;<br />
                                    <asp:Panel ID="panAC" runat="server" Height="16px" >
                                        <table>
                                            <tr>
                                                <td colspan="3" style="height: 29px">
                                                    <asp:FileUpload ID="FUpLoadAC" runat="server" Height="22px"  />
                                                </td>
                                                <td colspan="1" style="height: 29px">
                                                    <asp:ImageButton ID="ibtnLoadAce" runat="server" Height="23px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/SubirAce.bmp" Width="23px"
                                                         /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: justify;">
                                                    <asp:Label ID="lblNotaAce" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                        Text="Nota: El archivo solo puede contener valores de aceleración. Verificar que al inicio de la columna no haya espacio ni tab. Si las aceleraciones estan en columnas deberán estar separadas por:"></asp:Label>
                                                    <asp:DropDownList ID="DDLsepCol" runat="server" Visible="False">
                                                        <asp:ListItem Value="0">Tabs</asp:ListItem>
                                                        <asp:ListItem Value="1">Espacio</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1px;">
                                                    &nbsp;<asp:Label ID="lblDace" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                        Text="Duración del acelerograma [s]" Width="179px" ></asp:Label></td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:TextBox ID="txtdAC" runat="server" Width="50px"></asp:TextBox>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender17" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtdAC" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1px" >
                                                    <asp:Label ID="lblPasoAce" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                        Text="Paso [s]" Width="155px"></asp:Label></td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:TextBox ID="txtpasoAC" runat="server" Width="50px"></asp:TextBox>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender18" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtpasoAC" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1px" >
                                                    <asp:Label ID="lblFacAce" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Factor de aceleración [m/s^2]" Width="172px"></asp:Label></td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:TextBox ID="txtfacAC" runat="server" Width="50px"></asp:TextBox>
                                                    <cc1:filteredtextboxextender id="FilteredTextBoxExtender19" runat="server" filtertype="Custom, numbers"
                                                        targetcontrolid="txtfacAC" validchars="."></cc1:filteredtextboxextender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: left">
                                                    <br />
                                                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Blue"></asp:Label><br />
                                                </td>
                                            </tr>
                                        </table>
                                        <strong><span style="color: #ff0000"></span></strong>
                                    </asp:Panel>
                                &nbsp;&nbsp;
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label21" runat="server" Width="340px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td   style="width: 800px" >
                    &nbsp;<table class="TablaDatos-Graficas" style="width: 800px">
                        <tr>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;">
                                    <asp:Label ID="lblAnalisis" runat="server" CssClass="Funcionalidad-subtitulo" Text="ANALISIS"></asp:Label></td>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; text-align: center; font-size: 11pt; vertical-align: sub; font-style: italic; font-family: Times New Roman;">
                                    <asp:Label ID="lblRespMax" runat="server" CssClass="Funcionalidad-subtitulo" Text=" RESPUESTA MAXIMA"
                                        Width="177px"></asp:Label></td>
                        </tr>
                        <tr style="font-size: 11pt; vertical-align: sub">
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; text-align: center;">
                                <br />
                                <table>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 11pt; font-style: italic; height: 26px;" colspan="3">
                                            <br />
                                            <br />
                                            <table style="width: 224px">
                                                <tr>
                                                    <td style="width: 100px; height: 26px">
                                            <asp:Label ID="lblLoadExample" runat="server" Font-Bold="False" Text="Cargar Ejemplo" Width="153px"
                                                ></asp:Label></td>
                                                    <td style="font-weight: bold; font-size: 11pt; width: 100px; font-style: italic;
                                                        height: 26px">
                                            <asp:ImageButton ID="ibtnLoadExample" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="20px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/LoadExample.bmp"
                                                Width="25px" /></td>
                                                    <td style="font-weight: bold; font-size: 11pt; width: 38px; font-style: italic; height: 26px" align="left">
                                            <asp:Label ID="lblMensCE" runat="server" Font-Italic="True" ForeColor="Blue" Text="Listo!!"
                                                Visible="False" Font-Bold="True"></asp:Label></td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblDA" runat="server" CssClass="Funcionalidad-subtitulo" Text="Duración = "></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtDA" runat="server" Width="55px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender20" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtDA" validchars="."></cc1:filteredtextboxextender>
                                        </td>
                                        <td style="width: 100px; text-align: left;">
                                            [s]</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="ibtnRun" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/RunTool.bmp"
                                                Width="45px" /></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLborrarA" runat="server" Height="24px" Width="196px">
                                                <asp:ListItem Value="0">Analizar</asp:ListItem>
                                                <asp:ListItem Value="1">Borrar &#250;ltimo analisis</asp:ListItem>
                                                <asp:ListItem Value="2">Borrar todos los analisis</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="Label22" runat="server" Width="340px"></asp:Label></td>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px; width: 500px;" align="right">
                    <table class="TablaDatos-Graficas" style="border-right: lightgrey thin solid; border-top: lightgrey thin solid;
                        left: 0%; border-left: lightgrey thin solid;  border-bottom: lightgrey thin solid;
                        position: relative;  text-align: center">
                        <tr>
                            <td rowspan="2" style="height: 256px">
                                <table id="TABLE1" onclick="return TABLE1_onclick()">
                                    <tr>
                                        <td style="text-align: justify; width: 66px;">
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <strong>
                                                <asp:Label ID="lblNudo2" runat="server" CssClass="Funcionalidad-subtitulo" Text="Nudo 2"></asp:Label></strong></td>
                                        <td style="font-size: 11pt; vertical-align: sub; font-style: italic; text-align: justify">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px; text-align: left;">
                                            
                                               <span 
                                                   font-family: 'Calibri','sans-serif' ;>&nbsp;<strong><span style="font-size: 11pt"><em><span
                                                       style="font-family: Times New Roman">u<sub>max<span style="mso-spacerun: yes">&nbsp;
                                                       </span></sub></span></em><span lang="ES-TRAD" style="font-family: 'Times New Roman','serif';
                                                           mso-ansi-language: ES-TRAD">=</span></span><em><span style="font-family: Times New Roman"></span><span><i><span style="font-family: Calibri; text-align: left;"><span><sub><span style="font-family: Times New Roman"></span></sub></span></span></i></span></em></strong></span></td>
                                        <td style="height: 26px; text-align: left" >
                                            <asp:TextBox ID="txtXmax" runat="server" Width="51px"></asp:TextBox><asp:Label ID="Label1" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                                Text="m" Width="22px"></asp:Label></td>
                                        <td style="height: 26px;" align="left">
                                            <asp:Label ID="lblXmax" runat="server" Font-Italic="True" Font-Size="Small" Width="74px" style="font-family: 'Times New Roman'"></asp:Label></td>
                                        <td align="left" style="height: 26px">
                                            &nbsp;<asp:Label ID="lblRdespMax" runat="server"
                                                Font-Italic="True" Font-Size="Small" Text="Desplazamiento máximo" Width="143px" style="font-style: italic; font-family: 'Times New Roman'"></asp:Label></td>
                                    </tr>
                                    <tr style="font-weight: bold; font-size: 11pt">
                                        <td style="text-align: justify; width: 66px;">
                                            <span ><span  >
                                                <?xml namespace="" ns="urn:schemas-microsoft-com:vml" prefix="v" ?><?xml namespace="" prefix="V" ?><?xml namespace="" prefix="V" ?><?xml namespace="" prefix="V" ?><?xml namespace="" prefix="V" ?><?xml namespace="" prefix="V" ?><span><span
                                                                style="font-family: 'Times New Roman';"><span style="font-family: 'Times New Roman','serif'"><span><span style="font-family: 'Times New Roman';"><span style="font-family: Calibri; text-align: left"><span style="font-family: Times New Roman"></span><span style="font-family: 'Times New Roman','serif'"><em>ů<sub><span 
                                                  
                                             
                                                 >max</span></sub> =</em></span></span></span></span></span></span></span></span></span></td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtXomax" runat="server" Width="50px"></asp:TextBox>
                                            <asp:Label ID="Label2" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                                Font-Italic="True" Text="m/s" Width="23px"></asp:Label><em></em></td>
                                        <td align="left" style="font-size: 11pt">
                                            <asp:Label ID="lblXoMax" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="Small"
                                                Width="63px" style="font-family: 'Times New Roman'"></asp:Label></td>
                                        <td align="left" style="text-align: left; font-size: 11pt;">
                                            &nbsp;<asp:Label ID="lblRVeloMax" runat="server"
                                                Font-Bold="False" Font-Italic="True" Font-Size="Small" Text="Velocidad máxima"
                                                Width="146px" style="font-style: italic; font-family: 'Times New Roman'"></asp:Label></td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="text-align: left; width: 66px; height: 26px;">
                                            <strong><span style="font-size: 11pt"><em >ü<sub><span 
                                                  
                                             
                                                 >max</span></sub>
                                                =</em></span></strong></td>
                                        <td style="text-align: left; height: 26px;">
                                            <asp:TextBox ID="txtXoomax" runat="server" Width="48px"></asp:TextBox>
                                            <asp:Label ID="Label3" runat="server" CssClass="Funcionalidad-datos-entrada"
                                                Font-Italic="True" Text="m/s^2" Width="35px"></asp:Label>&nbsp;</td>
                                        <td style="width: 16px; font-family: Times New Roman; text-align: justify; height: 26px;">
                                            <asp:Label ID="lblXooMax" runat="server" Font-Italic="True" Font-Size="Small" Width="87px" style="font-family: 'Times New Roman'"></asp:Label></td>
                                        <td align="left" style="text-align: left; height: 26px;">
                                            &nbsp;<asp:Label ID="lblRacelMax" runat="server"
                                                Font-Italic="True" Font-Size="Small" Text="Aceleración máxima" Width="138px" style="font-style: italic; font-family: 'Times New Roman'"></asp:Label></td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="height: 10px; text-align: justify; width: 66px;">
                                        </td>
                                        <td colspan="2" style="height: 10px; text-align: center">
                                            <strong>
                                                <asp:Label ID="lblEle1" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento 1"></asp:Label></strong></td>
                                        <td style="height: 10px; text-align: justify">
                                        </td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="width: 66px">
                                            <span style="font-size: 11pt"><span><i><span style="font-family: 'Times New Roman'; font-size: 12pt;"><strong style="text-align: left">F<sub><span>max =</span></sub></strong></span></i></span></span></td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtFomax" runat="server" Width="47px"></asp:TextBox>&nbsp;
                                            <asp:Label ID="Label4" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                                Text="kN" Width="33px"></asp:Label><em></em></td>
                                        <td style="width: 16px; text-align: justify">
                                            <asp:Label ID="lblFomax" runat="server" Font-Italic="True" Font-Size="Small" Width="84px" style="font-family: 'Times New Roman'"></asp:Label></td>
                                        <td align="left" style="text-align: left">
                                            <asp:Label ID="lblRfuerzaMax" runat="server" Font-Italic="True"
                                                Font-Size="Small" Text="Fuerza máxima" Width="146px" style="font-style: italic; font-family: 'Times New Roman'"></asp:Label></td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="height: 15px; text-align: justify; width: 66px;">
                                            <asp:Label ID="lblSp0" runat="server" Width="47px"></asp:Label></td>
                                        <td style="height: 15px; text-align: left; width: 98px;">
                                            <asp:Label ID="lblSp1" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                                Width="95px"></asp:Label></td>
                                        <td style="width: 16px; height: 15px; text-align: justify">
                                            <asp:Label ID="Label17" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                                Width="105px"></asp:Label></td>
                                        <td align="left" style="text-align: left">
                                            <asp:Label ID="Label18" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                                Width="157px"></asp:Label></td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td colspan="4" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            &nbsp;<asp:ImageButton ID="ibtnDescRmax" runat="server" AlternateText="Ejecutar"
                                                CommandArgument="Run " CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR1" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                                &nbsp;</td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 15px; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; text-align: center;" >
                                            <asp:Label ID="lblGraficas" runat="server" CssClass="Funcionalidad-subtitulo" Text=" GRAFICAS"
                                                Width="195px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td>
                                            <chart:webchartviewer id="wcdAcSoil" runat="server" height="38px" width="199px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul1" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR2" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdFuncionFuerza" runat="server" height="33px" width="188px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul2" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR3" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdDespVsTime" runat="server" height="30px" width="193px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul3" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR4" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdVeloVsTime" runat="server" height="31px" width="191px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            &nbsp;<asp:ImageButton ID="btnDownResul4" runat="server" AlternateText="Ejecutar"
                                                CommandArgument="Run " CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" />
                                            <br />
                                            <asp:Label ID="lblDR5" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdAceVsTime" runat="server" height="28px" width="191px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul5" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR6" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td style="height: 100px">
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdForceVsTime" runat="server" height="26px" width="196px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul6" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR7" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
            <tr>
                <td>
                                <table class="TablaDatos-Graficas">
                                    <tr>
                                        <td style="width: 100px">
                                            <chart:webchartviewer id="wcdFvsD" runat="server" height="27px" width="196px"></chart:webchartviewer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                            border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                            text-align: center">
                                            <asp:ImageButton ID="btnDownResul7" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                                CommandName="Run " Height="25px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                                Width="30px" /><br />
                                            <asp:Label ID="lblDR8" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                                Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                                    </tr>
                                </table>
                </td>
            </tr>
        </table>
        Copyright © 2006 - 2010 VirtualLab UTPL. All rights reserved. .</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
