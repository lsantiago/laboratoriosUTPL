<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true"  CodeFile="Dinamica_2GDL2Original.aspx.vb" Inherits="VirtualLabIS_Experimentos_Dinamica_2GDL_Tool2_Dinamica_2GDL2" %>

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
    <div>
        <table id="EstiloP" onclick="return TABLE1_onclick()" style="border-right: lightgrey thin solid;
            border-top: lightgrey thin solid; left: 0%; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid; position: relative; top: 0%;
            height: 1%; text-align: center" class="Tabla-Principales" width="800">
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <asp:Image ID="imgCaratula" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png" /></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <asp:Label ID="lblNameTool" runat="server" Font-Bold="True" Font-Size="Large" Style="position: static"
                        Text="Pórtico-2P"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <strong><span>
                        <asp:Label ID="lblTitulo2GDLtool2" runat="server" Font-Bold="True" Font-Size="Small"
                            Style="position: static" Text="Analisis dinámico de un Portico de 2 pisos"></asp:Label></span></strong></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table id="TABLE1" onclick="return TABLE1_onclick()" class="TablaDatos-Graficas" width="800">
                        <tr>
                            <td colspan="4" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                                height: 15px; text-align: center">
                        <asp:Label ID="lblProSis" runat="server" CssClass="Funcionalidad-subtitulo" Text="PROPIEDADES DEL SISTEMA"></asp:Label></td>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid;
                                width: 514px; border-bottom: darkgray thin solid; height: 15px; text-align: center">
                        <asp:Label ID="lblEsquemaMain" runat="server" CssClass="Funcionalidad-subtitulo"
                            Text="ESQUEMA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                                height: 15px; text-align: center">
                                <table>
                                    <tr>
                                        <td style="width: 41px">
                                        </td>
                                        <td style="width: 68px">
                        <asp:Label ID="lblPiso1" runat="server" CssClass="Funcionalidad-subtitulo" Text="Piso 1"></asp:Label></td>
                                        <td style="width: 67px">
                        <asp:Label ID="lblPiso2" runat="server" CssClass="Funcionalidad-subtitulo" Text="Piso 1"></asp:Label></td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 41px">
                                            <strong>m =</strong></td>
                                        <td style="width: 68px">
                    <asp:TextBox ID="txtM1" runat="server" Width="59px"></asp:TextBox>&nbsp;
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtM1" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td style="width: 67px">
                    <asp:TextBox ID="txtM2" runat="server" Width="63px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender2" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtM2" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td align="left" style="width: 100px">
                    <asp:Label ID="lblM" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Masa  [Tonnes]" Width="226px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 41px">
                                            <strong>H =</strong></td>
                                        <td style="width: 68px">
                    <asp:TextBox ID="txtH1" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender3" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtH1" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td style="width: 67px">
                    <asp:TextBox ID="txtH2" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender4" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtH2" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td align="left" style="width: 100px">
                    <asp:Label ID="lblH" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Altura entre pisos [m]" Width="128px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 41px">
                                            <strong>EI=</strong></td>
                                        <td style="width: 68px">
                    <asp:TextBox ID="txtEI1" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender5" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtEI1" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td style="width: 67px">
                    <asp:TextBox ID="txtEI2" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender6" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtEI2" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td align="left" style="width: 100px">
                    <asp:Label ID="lblEI" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Producto de la rigidez por la inercia [kN.m^3]" Width="245px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 41px">
                                        </td>
                                        <td colspan="2">
                        <asp:Label ID="lblDV" runat="server" CssClass="Funcionalidad-subtitulo" Text="Definimos vibración"></asp:Label></td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 41px">
                                            <strong>ξ =</strong></td>
                                        <td style="width: 68px">
                    <asp:TextBox ID="txtA1" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender7" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtA1" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td style="width: 67px">
                    <asp:TextBox ID="txtA2" runat="server" Width="59px"></asp:TextBox>
                                            <cc1:filteredtextboxextender id="FilteredTextBoxExtender8" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtA2" validchars=".">
                                            </cc1:filteredtextboxextender>
                                        </td>
                                        <td align="left" style="width: 100px">
                    <asp:Label ID="lblA" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Amortiguamiento (%)" Width="136px"></asp:Label></td>
                                    </tr>
                                </table>
                                &nbsp;
                                <asp:Label ID="Label14" runat="server" Width="440px"></asp:Label></td>
                            <td style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid;
                                width: 514px; border-bottom: darkgray thin solid; height: 15px; text-align: center">
                    <asp:Image ID="FigMain" runat="server" Height="350px" ImageUrl="~/Imagenes/General/Tools/Dinamica_2GDL_Tool2.bmp"
                        Width="350px" /></td>
                        </tr>
        </table>
        <table class="TablaDatos-Graficas" width="800">
            <tr>
                <td colspan="2" style="height: 15px; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid; text-align: center;">
                    <asp:Label ID="lblTM" runat="server" CssClass="Funcionalidad-subtitulo" Text="TIPO DE MATERIAL"></asp:Label></td>
                <td rowspan="1" style="width: 514px; height: 15px; text-align: center; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid;">
                    <asp:Label ID="lblCT" runat="server" CssClass="Funcionalidad-subtitulo" Text="COMPORTAMIENTO TIPO"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right" align="right">
                    <asp:Label ID="lblEscTM" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Escoger:" Font-Bold="True"></asp:Label></td>
                <td style="text-align: left" align="left">
                    <asp:DropDownList ID="DDLmatTyp" runat="server" AutoPostBack="True" Height="24px"
                        Width="131px">
                        <asp:ListItem Selected="True" Value="0">El&#225;stico</asp:ListItem>
                        <asp:ListItem Value="1">Bilineal 1</asp:ListItem>
                        <asp:ListItem Value="2">Bilineal 2</asp:ListItem>
                    </asp:DropDownList></td>
                <td rowspan="2" align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid; height: 15px; text-align: center">
                    &nbsp;<br />
                    <br />
                    <br />
                    <asp:Image ID="FigMat1" runat="server" Height="27px" Width="28px" /><asp:Image ID="FigMat2"
                        runat="server" Height="27px" Width="24px" /><asp:Image ID="FigMat3" runat="server"
                            Height="28px" Width="25px" /><br />
                    <asp:Label ID="Label17" runat="server" Width="350px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 514px; height: 15px; text-align: center; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid;">
                    &nbsp;<em><span style="font-size: 10pt"><br />
                    </span></em>
                    <asp:Panel ID="panBlineal1" runat="server" Height="44px" Width="410px">
                        <table style="width: 419px; height: 61px">
                            <tr>
                                <td style="height: 21px">
                                </td>
                                <td style="width: 462px; height: 21px">
                                    <strong>
                                        <asp:Label ID="lblEle11" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento  1"
                                            Width="75px"></asp:Label></strong></td>
                                <td style="width: 734px; height: 21px">
                                    <strong>
                                        <asp:Label ID="lblEle21" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento  1"
                                            Width="75px"></asp:Label></strong></td>
                                <td style="width: 28193px; height: 21px; text-align: left">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Fy =" Width="36px"></asp:Label></strong></td>
                                <td style="width: 462px">
                                    <asp:TextBox ID="txtFy1" runat="server" Width="70px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender9" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFy1" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 734px">
                                    <asp:TextBox ID="txtFy2" runat="server" Width="72px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender10" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFy2" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 28193px; text-align: left">
                                    <asp:Label ID="lblFyMat21" runat="server" CssClass="Funcionalidad-datos-entrada"
                                        Font-Bold="False" Text="Fuerza de fluencia  [kN]" Width="159px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="r =" Width="36px"></asp:Label></strong></td>
                                <td style="width: 462px">
                                    <asp:TextBox ID="txtr1" runat="server" Width="68px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender11" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtr1" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 734px">
                                    <asp:TextBox ID="txtr2" runat="server" Width="69px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender12" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtr2" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 28193px; text-align: left">
                                    <asp:Label ID="lblrMat21" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                        Text="Coeficiente Post-Fluencia" Width="164px"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="panBlineal2" runat="server" Height="44px" Width="409px">
                        <table style="width: 416px; height: 61px">
                            <tr>
                                <td style="width: 17635px; height: 21px">
                                </td>
                                <td style="width: 367px; height: 21px">
                                    <strong>
                                        <asp:Label ID="lblEle12" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento  1"
                                            Width="75px"></asp:Label></strong></td>
                                <td style="width: 557px; height: 21px">
                                    <strong>
                                        <asp:Label ID="lblEle22" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento  2"
                                            Width="75px"></asp:Label></strong></td>
                                <td style="width: 93766px; height: 21px; text-align: left">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17635px">
                                    <strong>
                                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Fy =" Width="36px"></asp:Label></strong></td>
                                <td style="width: 367px">
                                    <asp:TextBox ID="txtFy1M3" runat="server" Width="69px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender13" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFy1M3" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 557px">
                                    <asp:TextBox ID="txtFy2M3" runat="server" Width="69px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender14" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFy2M3" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 93766px; text-align: left">
                                    <asp:Label ID="lblFyMat31" runat="server" CssClass="Funcionalidad-datos-entrada"
                                        Font-Bold="False" Text="Fuerza de Fluencia  [kN]"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 17635px">
                                    <strong>
                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="r =" Width="36px"></asp:Label></strong></td>
                                <td style="width: 367px">
                                    <asp:TextBox ID="txtr1M3" runat="server" Width="69px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender15" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtr1M3" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 557px">
                                    <asp:TextBox ID="txtr2M3" runat="server" Width="67px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender16" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtr2M3" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 93766px; text-align: left">
                                    <asp:Label ID="lblrMat31" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Bold="False"
                                        Text="Coeficiente Post-Fluencia"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17635px; height: 18px">
                                    <strong>
                                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="R =" Width="36px"></asp:Label></strong></td>
                                <td style="width: 367px; height: 18px">
                                    <asp:TextBox ID="txtRo1" runat="server" Width="71px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender17" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtRo1" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 557px; height: 18px">
                                    <asp:TextBox ID="txtRo2" runat="server" Width="69px"></asp:TextBox>
                                    <cc1:filteredtextboxextender id="Filteredtextboxextender18" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtRo2" validchars=".">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td style="width: 93766px; height: 18px; text-align: left">
                                    <asp:Label ID="lblRoMat31" runat="server" CssClass="Funcionalidad-datos-entrada"
                                        Font-Bold="False" Text="Val. Recom: 10 a 20" Width="192px"></asp:Label></td>
                            </tr>
                        </table>
                        <br />
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
                    <asp:Label ID="Label15" runat="server" Width="440px"></asp:Label><br />
                    <br />
                </td>
            </tr>
        </table>
        <table class="TablaDatos-Graficas" width="800">
            <tr>
                <td colspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                    border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                    height: 15px; text-align: center">
                        <asp:Label ID="lblTE" runat="server" CssClass="Funcionalidad-subtitulo" Text="TIPO DE EXITACIÓN"></asp:Label></td>
                <td rowspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                    border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                    height: 15px; text-align: center">
                        <asp:Label ID="lblEsqTE" runat="server" CssClass="Funcionalidad-subtitulo" Text="ESQUEMA"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right">
                        <asp:Label ID="lblEscTE" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Seleccionar:"
                            Width="66px" Font-Bold="True"></asp:Label></td>
                <td style="text-align: left">
                    <asp:DropDownList ID="DDLexiTyp" runat="server" AutoPostBack="True" Height="24px"
                        Width="197px">
                        <asp:ListItem Value="0">Funci&#243;n lineal</asp:ListItem>
                        <asp:ListItem Value="1">Funci&#243;n trilineal</asp:ListItem>
                        <asp:ListItem Value="2">Funci&#243;n sinusoidal</asp:ListItem>
                        <asp:ListItem Value="3">Acelerograma</asp:ListItem>
                    </asp:DropDownList></td>
                <td rowspan="2" align="center" style="border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid; height: 15px; text-align: center">
                    &nbsp;<br />
                    <br />
                    &nbsp;<br />
                    <asp:Image ID="FigExi1" runat="server" Height="33px" Width="36px" /><asp:Image ID="FigExi2"
                        runat="server" Height="32px" Width="41px" /><asp:Image ID="FigExi3" runat="server"
                            Height="33px" Width="40px" /><asp:Image ID="FigExi4" runat="server" Height="33px"
                                Width="42px" />
                    &nbsp; &nbsp; &nbsp;
                    <br />
                    <asp:Label ID="Label18" runat="server" Width="350px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: justify; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid; height: 15px;">
                    &nbsp;&nbsp;<asp:Panel ID="Panel4" runat="server" Height="50px" Width="125px">
                        <asp:Panel ID="panFL" runat="server" Height="50px" Width="125px">
                            <table style="width: 338px; height: 61px">
                                <tr>
                                    <td style="width: 195px">
                                        <strong>I =</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtI" runat="server" Width="79px"></asp:TextBox>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender20" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtI" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 543px; text-align: left">
                                        <asp:Label ID="lblI" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Magnitud del impulso [kN/s]"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                        <strong>DI =</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtDI" runat="server" Width="79px"></asp:TextBox>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender21" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtDI" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 543px; text-align: left">
                                        <asp:Label ID="lblDI" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Duración del impulso [s]"></asp:Label></td>
                                </tr>
                            </table>
                            <asp:Label ID="lblEcFL" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Pmax = (I).(DI)" Font-Bold="True" Font-Size="Small" Width="199px"></asp:Label></asp:Panel>
                        <br />
                        <asp:Panel ID="panFT" runat="server" Height="50px" Width="125px">
                            <table id="Table2" style="width: 338px; height: 61px">
                                <tr>
                                    <td style="width: 195px">
                                        <strong>Pmax &nbsp;=</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtFmax" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblPmax" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Carga máxima [kN]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender22" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFmax" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                        <strong>t<span style="font-size: 6pt">1</span> =</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtT1" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblT1" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 1 [s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender23" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtT1" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                        <strong>t<span style="font-size: 6pt">2</span> =</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtT2" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblT2" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 2 [s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender24" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtT2" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                        <strong>t<span style="font-size: 6pt">3 </span>=</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtT3" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblT3" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Tiempo 3 [s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender25" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtT3" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="panFS" runat="server" Height="50px" Width="125px">
                            <table style="width: 338px; height: 61px">
                                <tr>
                                    <td style="width: 195px">
                                        <strong>Po &nbsp;=</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtFo" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblPo" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Amplitud [kN]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender26" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtFo" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                        <strong><span lang="ES-TRAD" style="font-size: 11pt; layout-grid-mode: line; font-family: Symbol;
                                            mso-ansi-language: ES-TRAD; mso-bidi-font-weight: bold; mso-bidi-font-family: 'Times New Roman';
                                            mso-fareast-font-family: 'Times New Roman'; mso-fareast-language: ES; mso-bidi-language: AR-SA">
                                            w</span> =</strong></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtWa" runat="server" Width="79px"></asp:TextBox></td>
                                    <td style="width: 491px; text-align: left">
                                        <asp:Label ID="lblFrecuenciaE" runat="server" CssClass="Funcionalidad-datos-entrada"
                                            Text="Frecuencia [rad/s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender27" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtwa" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lblFS" runat="server" CssClass="Funcionalidad-datos-entrada" Text="P(t) = Po.Sin(w.t)" Font-Bold="True" Font-Size="Small" Width="182px"></asp:Label></asp:Panel>
                        <br />
                        <asp:Panel ID="panAC" runat="server" Height="16px" Width="397px">
                            <table>
                                <tr>
                                    <td colspan="3" style="height: 29px">
                                        <asp:FileUpload ID="FUpLoadAC" runat="server" Height="22px" Width="354px" />
                                    </td>
                                    <td colspan="1" style="height: 29px">
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/SubirAce.bmp"
                                            Width="25px" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: justify">
                                        <asp:Label ID="lblNotaAce" runat="server" CssClass="Funcionalidad-datos-entrada"
                                            Text="Nota: El archivo solo puede contener valores de aceleración. Verificar que al inicio de la columna no haya espacio ni tab. Si las aceleraciones estan en columnas deberán estar separadas por:"></asp:Label><br />
                                        <asp:DropDownList ID="DDLsepCol" runat="server" Visible="False">
                                            <asp:ListItem Value="0">Tabs</asp:ListItem>
                                            <asp:ListItem Value="1">Espacio</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 22px; text-align: left">
                                        <asp:TextBox ID="txtdAC" runat="server" Width="47px"></asp:TextBox></td>
                                    <td colspan="3" style="text-align: left">
                                        &nbsp;<asp:Label ID="lblDace" runat="server" CssClass="Funcionalidad-datos-entrada"
                                            Text="Duración del acelerograma [s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender28" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtdAC" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 22px; text-align: left">
                                        <asp:TextBox ID="txtpasoAC" runat="server" Width="47px"></asp:TextBox></td>
                                    <td style="width: 89px; text-align: left">
                                        <asp:Label ID="lblPasoAce" runat="server" CssClass="Funcionalidad-datos-entrada"
                                            Text="Paso [s]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender29" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtpasoAC" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td colspan="2" style="text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 22px; text-align: left">
                                        <asp:TextBox ID="txtfacAC" runat="server" Width="47px"></asp:TextBox></td>
                                    <td colspan="3" style="text-align: left">
                                        <asp:Label ID="lblFacAce" runat="server" CssClass="Funcionalidad-datos-entrada" Text="Factor de aceleración [m/s^2]"></asp:Label>
                                        <cc1:filteredtextboxextender id="Filteredtextboxextender30" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtfacAC" validchars=".">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 59px; text-align: left">
                                        <br />
                                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Blue"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <strong><span style="color: #ff0000"></span></strong>
                        </asp:Panel>
                    </asp:Panel>
                    &nbsp;<br />
                    &nbsp;<br />
                    <br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Width="440px"></asp:Label><br />
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
                </td>
            </tr>
        </table>
                    <br />
        <table class="TablaDatos-Graficas" width="800">
            <tr>
                <td colspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                    border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                    height: 15px; text-align: center">
                        <asp:Label ID="lblAnalisis" runat="server" CssClass="Funcionalidad-subtitulo" Text="ANALISIS"></asp:Label></td>
                <td rowspan="1" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                    border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                    height: 15px; text-align: center">
                    <asp:Label ID="lblRespMax" runat="server" CssClass="Funcionalidad-subtitulo"
                        Font-Italic="False" Text=" RESPUESTA MAXIMA"></asp:Label></td>
            </tr>
            <tr style="font-size: 11pt">
                <td colspan="1" rowspan="2" style="height: 15px; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid; text-align: center;">
                    <table style="width: 224px">
                        <tr>
                            <td style="height: 35px">
                                &nbsp;<asp:Label ID="lblLoadExample" runat="server" Font-Bold="False" Text="Cargar Ejemplo"
                                    Width="120px"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 11pt; width: 100px; font-style: italic;
                                height: 35px">
                                <asp:ImageButton ID="ibtnLoadExample" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="23px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/LoadExample.bmp"
                                    Width="30px" /></td>
                            <td align="left">
                                <asp:Label ID="lblMensCE" runat="server" Font-Italic="True" ForeColor="Blue" Text="Listo!!"
                                    Visible="False" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="width: 224px">
                        <tr>
                            <td style="width: 100px; height: 23px">
                                <strong>
                                    <asp:Label ID="lblDA" runat="server" CssClass="Funcionalidad-subtitulo" Text="Duración = "></asp:Label></strong>
                            </td>
                            <td align="left" style="width: 68px">
                                <asp:TextBox ID="txtDA" runat="server" Width="55px"></asp:TextBox>&nbsp;
                            </td>
                            <td align="left">
                                [s]</td>
                        </tr>
                    </table>
                    <table style="font-size: 11pt; width: 219px">
                        <tr>
                            <td colspan="1" style="width: 29px; height: 35px">
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/RunTool.bmp" Width="45px" /></td>
                            <td colspan="2">
                                <strong></strong>
                                <asp:DropDownList ID="DDLborrarA" runat="server" Height="20px" Width="170px">
                                    <asp:ListItem Value="0">Analizar</asp:ListItem>
                                    <asp:ListItem Value="1">Borrar &#250;ltimo Analisis</asp:ListItem>
                                    <asp:ListItem Value="2">Borrar todos los analisis</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />
                                <cc1:filteredtextboxextender id="Filteredtextboxextender19" runat="server" filtertype="Custom, numbers"
                                                targetcontrolid="txtDA" validchars=".">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                <td rowspan="2" style="width: 514px; height: 15px; text-align: center; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid;">
                    <table id="TABLE3" onclick="return TABLE3_onclick()" style="border-right: darkgray thin solid;
                        border-top: darkgray thin solid; border-left: darkgray thin solid;
                        border-bottom: darkgray thin solid; text-align: right" width="555">
                        <tr>
                            <td style="width: 431px; height: 28px; text-align: center">
                            </td>
                            <td colspan="2" style="height: 28px; text-align: center">
                                <strong>
                                    <asp:Label ID="lblNudo21" runat="server" CssClass="Funcionalidad-subtitulo" Text="Nudo 2"></asp:Label></strong></td>
                            <td colspan="2" style="height: 28px; text-align: center">
                                <strong>
                                    <asp:Label ID="lblNudo31" runat="server" CssClass="Funcionalidad-subtitulo" Text="Nudo 3"></asp:Label></strong></td>
                            <td style="width: 1425px; height: 28px; text-align: left">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 431px; height: 28px; text-align: justify">
                                <span style="font-size: 10pt; font-family: Calibri">
                                    <p class="MsoNormal" style="margin: 0cm 0cm 10pt">
                                        <span style="font-size: 11pt"><strong><i style="mso-bidi-font-style: normal"><span
                                            lang="ES-TRAD" style="font-family: 'Times New Roman','serif'; mso-ansi-language: ES-TRAD">
                                            u<sub>max<span style="mso-spacerun: yes">&nbsp; </span></sub></span></i><span lang="ES-TRAD"
                                                style="font-family: 'Times New Roman','serif'; mso-ansi-language: ES-TRAD">=<i style="mso-bidi-font-style: normal"><?xml
                                                    namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace=""
                                                      prefix="O" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></i></span></strong></span></p>
                                </span>
                            </td>
                            <td style="height: 28px; text-align: justify">
                                <asp:TextBox ID="txtXmax1" runat="server" Width="57px"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m" Width="30px"></asp:Label><em></em></td>
                            <td style="height: 28px; text-align: justify">
                                <asp:Label ID="lblXmax1" runat="server" Font-Italic="True" Width="90px"></asp:Label></td>
                            <td style="height: 28px; text-align: justify">
                                <asp:TextBox ID="txtXmax2" runat="server" Width="52px"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m" Width="22px"></asp:Label><em></em></td>
                            <td style="height: 28px; text-align: justify">
                                <asp:Label ID="lblXmax2" runat="server" Font-Italic="True" Width="93px"></asp:Label></td>
                            <td style="width: 1425px; height: 28px; text-align: justify">
                                &nbsp;<asp:Label ID="lblRdespMax" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Font-Italic="True" Text="Desplazamiento máximo"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 431px; height: 40px; text-align: justify">
                                <span style="font-size: 11pt"><span style="font-family: Calibri"><b style="mso-bidi-font-weight: normal">
                                    <i style="mso-bidi-font-style: normal"><span style="mso-bidi-font-family: Calibri;
                                        mso-bidi-theme-font: minor-latin">
                                        <p class="MsoNormal" style="margin: 0cm 0cm 10pt">
                                            <b style="mso-bidi-font-weight: normal"><i style="mso-bidi-font-style: normal"><span
                                                style="font-family: 'Times New Roman','serif'">ů<sub>max <span style="mso-spacerun: yes">
                                                    &nbsp;</span></sub></span></i></b><span style="font-family: 'Times New Roman','serif'">=<b
                                                        style="mso-bidi-font-weight: normal"><i style="mso-bidi-font-style: normal"><o:p></o:p></i></b></span></p>
                                    </span></i></b></span></span>
                            </td>
                            <td style="font-family: Times New Roman; height: 40px; text-align: justify">
                                <asp:TextBox ID="txtXomax1" runat="server" Width="55px"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m/s" Width="31px"></asp:Label><em></em></td>
                            <td style="font-family: Times New Roman; height: 40px; text-align: justify">
                                <asp:Label ID="lblXoMax1" runat="server" Font-Italic="True" Width="75px"></asp:Label></td>
                            <td style="font-family: Times New Roman; height: 40px; text-align: justify">
                                <asp:TextBox ID="txtXoMax2" runat="server" Width="51px"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m/s" Width="23px"></asp:Label><em></em></td>
                            <td style="font-family: Times New Roman; height: 40px; text-align: justify">
                                <asp:Label ID="lblXoMax2" runat="server" Font-Italic="True" Width="94px"></asp:Label></td>
                            <td style="width: 1425px; font-family: Times New Roman; height: 40px; text-align: justify">
                                <asp:Label ID="lblRVeloMax" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Font-Italic="True" Text="Velocidad máxima"></asp:Label></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="width: 431px; height: 21px; text-align: justify">
                                <em><span style="font-size: 11pt"><strong><span>ü</span><sub><span style="line-height: 115%;
                                    mso-ansi-language: ES-CR; mso-bidi-font-family: 'Times New Roman'; mso-fareast-font-family: Calibri;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-theme-font: minor-bidi;
                                    mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin">max</span></sub>
                                    =</strong></span></em></td>
                            <td style="font-family: Times New Roman; height: 21px; text-align: justify">
                                <asp:TextBox ID="txtXoomax1" runat="server" Width="57px"></asp:TextBox><asp:Label
                                    ID="Label3" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m/s^2" Width="23px"></asp:Label></td>
                            <td style="font-family: Times New Roman; height: 21px; text-align: justify">
                                <asp:Label ID="lblXooMax1" runat="server" Font-Italic="True" Width="95px"></asp:Label></td>
                            <td style="font-family: Times New Roman; height: 21px; text-align: justify">
                                <asp:TextBox ID="txtXooMax2" runat="server" Width="50px"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="m/s^2" Width="23px"></asp:Label><em></em></td>
                            <td style="font-family: Times New Roman; height: 21px; text-align: justify">
                                <asp:Label ID="lblXooMax2" runat="server" Font-Italic="True" Width="95px"></asp:Label></td>
                            <td style="width: 1425px; font-family: Times New Roman; height: 21px; text-align: justify">
                                <asp:Label ID="lblRacelMax" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Font-Italic="True" Text="Aceleración máxima"></asp:Label></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="border-top-width: thin; width: 431px; border-top-color: darkgray; height: 15px;
                                text-align: justify">
                            </td>
                            <td colspan="2" style="height: 15px; text-align: center">
                                <strong style="border-top-width: thin; border-top-color: darkgray">
                                    <asp:Label ID="lblEle13" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento 1"></asp:Label></strong></td>
                            <td colspan="2" style="height: 15px; text-align: center">
                                <strong style="border-top-width: thin; border-top-color: darkgray">
                                    <asp:Label ID="lblEle23" runat="server" CssClass="Funcionalidad-subtitulo" Text="Elemento 2"></asp:Label></strong></td>
                            <td style="border-top-width: thin; width: 1425px; border-top-color: darkgray; height: 15px;
                                text-align: justify">
                            </td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="width: 431px; height: 8px; text-align: justify">
                                <span><strong><em>F<sub><span style="line-height: 115%;
                                    mso-ansi-language: ES-CR; mso-bidi-font-family: 'Times New Roman'; mso-fareast-font-family: Calibri;
                                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-bidi-theme-font: minor-bidi;
                                    mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin">max</span></sub>
                                    =</em></strong></span></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:TextBox ID="txtFomax1" runat="server" Width="59px"></asp:TextBox><asp:Label
                                    ID="Label4" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="kN" Width="23px"></asp:Label><em></em></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="lblFomax1" runat="server" Font-Italic="True" Width="89px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:TextBox ID="txtFomax2" runat="server" Width="55px"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                    Text="kN" Width="23px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="lblFoMax2" runat="server" Font-Italic="True" Width="93px"></asp:Label></td>
                            <td style="width: 1425px; height: 8px; text-align: justify">
                                <asp:Label ID="lblRfuerzaMax" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Font-Italic="True" Text="Fuerza máxima"></asp:Label></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="width: 431px; height: 8px; text-align: justify">
                                <asp:Label ID="lblSp0" runat="server" Width="49px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="Label19" runat="server" Width="97px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="Label21" runat="server" Width="95px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="Label20" runat="server" Width="95px"></asp:Label></td>
                            <td style="height: 8px; text-align: justify">
                                <asp:Label ID="Label22" runat="server" Width="95px"></asp:Label></td>
                            <td style="width: 1425px; height: 8px; text-align: justify">
                                <asp:Label ID="Label23" runat="server" Width="95px"></asp:Label></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td colspan="6" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                                border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 15px;
                                text-align: center">
                                <asp:ImageButton ID="ImageButton14" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR1" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</td>
            </tr>
            <tr style="font-family: Times New Roman">
            </tr>
        </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                    border-left: darkgray thin solid; width: 514px; border-bottom: darkgray thin solid;
                    height: 15px; text-align: center">
                                    <asp:Label ID="lblGraficas" runat="server" CssClass="Funcionalidad-subtitulo" Text=" GRAFICAS"
                                        Width="246px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdAcSoil" runat="server" height="38px" width="199px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul1" runat="server" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR2" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdFuncionFuerza" runat="server" height="33px" width="188px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul2" runat="server" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR3" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px; height: 21px">
                                <chart:webchartviewer id="wcdDespVsTime1" runat="server" height="38px" width="199px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul3" runat="server" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR4" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdDespVsTime2" runat="server" height="39px" width="194px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul4" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR5" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdVeloVsTime1" runat="server" height="41px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul5" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR6" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdVeloVsTime2" runat="server" height="41px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul6" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR7" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdAceVsTime1" runat="server" height="46px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-top: darkgray thin solid; border-left: darkgray thin solid;
                                width: 100px; border-bottom: darkgray thin solid">
                                <asp:ImageButton ID="btnDownResul7" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDr8" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="False" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdAceVsTime2" runat="server" height="46px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul8" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR9" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdForceVsTime1" runat="server" height="42px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul9" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR10" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdForceVsTime2" runat="server" height="42px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul10" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR11" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdFvsD1" runat="server" height="41px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul11" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR12" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    <table class="TablaDatos-Graficas">
                        <tr>
                            <td style="width: 100px">
                                <chart:webchartviewer id="wcdFvsD2" runat="server" height="41px" width="196px"></chart:webchartviewer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnDownResul12" runat="server" AlternateText="Ejecutar" CommandArgument="Run "
                                    CommandName="Run " Height="37px" ImageUrl="~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/DescargarResp.bmp"
                                    Width="45px" /><br />
                                <asp:Label ID="lblDR13" runat="server" BackColor="#E0E0E0" BorderColor="White" Font-Bold="False"
                                    Font-Italic="True" ForeColor="#8080FF" Text="Descargar Resultados" Width="159px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 16px; text-align: center">
                    Copyright © 2006 - 2010 VirtualLab UTPL. All rights reserved.
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
