<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="Din1GDL1.aspx.vb" Inherits="VirtualLabIS_Experimentos_Dinamica_1GDL_Din1GDL1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>SDOF-Dynamics</b></span>
                    <ol class="breadcrumb">
                        <li>TIME HISTORY ANALYSIS OF SINGLE DEGREE OF FREEDOM SYSTEMS</li>
                    </ol>
                    <h5><b>Description:</b> Time History Analysis of Single Degree of Freedom Systems</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Quinones, S.; Duque, E.</h5>
                    <h5><b>Info:</b> SDOF-Dynamics</h5>
                    <h5>This application is avalible for registered users only</h5>
                    <h5>If you experience any problem or if you need assistance running this program please contact epduque@utpl.edu.ec</h5>
                </section>
                <!-- END CONTENT HEADER -->

                <!-- BEGIN SECTION CONTENT -->
                <section class="content">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">INPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <!-- BEGIN CONTENT LEFT -->
                                        <div class="col-md-4">
                                            <div class="grid">
                                                <div class="grid-header">
                                                    <i class="fa fa-bar-chart-o"></i>
                                                    <asp:Label ID="lblEsquemaMain" runat="server" class="grid-title lead" Text="OUTLINE"></asp:Label>
                                                    <div class="pull-right grid-tools">
                                                        <asp:LinkButton ID="ibtnLoadExample" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo">
                                                                Load Example
                                                                <i class="fa fa-play"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="grid-body text-center" style="width: 100%; height: 100%;">
                                                    <div style="width: 100%; height: 226px;">
                                                        <div class="image">
                                                            <asp:Image ID="FigMain" runat="server" ImageUrl="../Imagenes/General/Tools/Dinamica_1GDL_Tool1.png" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END CONTENT LEFT -->

                                        <!-- BEGIN CONTENT RIGHT -->
                                        <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                            <ul class="nav nav-tabs">
                                                <li class="active"><a href="#test1" data-toggle="tab">
                                                    <strong>
                                                        <asp:Label ID="lblProSis" runat="server" Text="PROPIEDADES DEL SISTEMA"></asp:Label></strong></a></li>
                                                <li><a href="#test2" data-toggle="tab">
                                                    <strong>
                                                        <asp:Label ID="lblTM" runat="server" Text="TIPO DE MATERIAL"></asp:Label></strong></a></li>
                                                <li><a href="#test3" data-toggle="tab">
                                                    <strong>
                                                        <asp:Label ID="lblTE" runat="server" Text="TIPO DE EXITACIÓN"></asp:Label></strong></a></li>
                                                <li><a href="#test4" data-toggle="tab">
                                                    <strong>
                                                        <asp:Label ID="lblAnalisis" runat="server" Text="ANALISIS"></asp:Label></strong></a></li>
                                            </ul>
                                            <div class="form-horizontal">
                                                <div class="tab-content">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1">
                                                        <div class="form-group">
                                                            <div class="col-sm-3"></div>
                                                            <div class="col-sm-6" style="padding-top: 10%; padding-bottom: 10%;">
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>T =</var></b></label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtT" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, numbers" TargetControlID="txtT"
                                                                            ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblT" runat="server" class="control-label" Text="Periodo [s]"></asp:Label>
                                                                    <asp:Label ID="llbFT" runat="server" class="control-label"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>m =</var></b></label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtM" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, numbers"
                                                                            TargetControlID="txtM" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblM" runat="server" class="control-label" Text="Mass [Tonne =kN.s^2/m =kN/g]"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>ξ =</var></b></label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtA" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom, numbers"
                                                                            TargetControlID="txtA" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblA" runat="server" class="control-label" Text="Damping [%]"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2" style="padding-top: 15px;">
                                                        <div class="form-group">
                                                            <div class="col-md-7">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblEscTM" runat="server" class="col-sm-2 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                    <div class="col-sm-5">
                                                                        <asp:DropDownList ID="DDLmatTyp" runat="server" AutoPostBack="True" class="form-control">
                                                                            <asp:ListItem Selected="True" Value="0">El&#225;stico</asp:ListItem>
                                                                            <asp:ListItem Value="1">Bilineal 1</asp:ListItem>
                                                                            <asp:ListItem Value="2">Bilineal 2</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <asp:Panel ID="panBlineal1" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tmvalue1">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Fy =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtFy" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblFyMat21" runat="server" class="control-label" Text="Fuerza de Fluencia [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>r =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtr" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblrMat21" runat="server" class="control-label" Text="Coeficiente Post-Fluencia"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:Panel ID="panBlineal2" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tmvalue2">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Fy =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtFy1" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblFyMat31" runat="server" class="control-label" Text="Fuerza de Fluencia [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>r =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtr1" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblrMat31" runat="server" class="control-label" Text="Coeficiente Post-Fluencia"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>R =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtRo" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender
                                                                                    ID="FilteredTextBoxExtender8" runat="server" FilterType="Custom, numbers" TargetControlID="txtRo"
                                                                                    ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblRoMat31" runat="server" class="col-sm-7 label-der" Text="Val. Recom: 10 a 20"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                            <div class="col-md-5">
                                                                <asp:Label ID="lblCT" runat="server" class="label-title-imge lead" Text="COMPORTAMIENTO TIPO"></asp:Label>
                                                                <hr />
                                                                <div style="width: 100%; height: 191px;">
                                                                    <div class="image">
                                                                        <asp:Image ID="FigMat1" runat="server" /><asp:Image ID="FigMat2"
                                                                            runat="server" /><asp:Image ID="FigMat3" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3" style="padding-top: 15px;">
                                                        <div class="form-group">
                                                            <div class="col-md-7">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblEscTE" runat="server" class="col-sm-2 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                    <div class="col-sm-6">
                                                                        <asp:DropDownList ID="DDLexiTyp" runat="server" AutoPostBack="True" class="form-control">
                                                                            <asp:ListItem Value="0">Funci&#243;n lineal</asp:ListItem>
                                                                            <asp:ListItem Value="1">Funci&#243;n trilineal</asp:ListItem>
                                                                            <asp:ListItem Value="2">Funci&#243;n sinusoidal</asp:ListItem>
                                                                            <asp:ListItem Value="3">Acelerograma</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <%--Value 1--%>
                                                                <asp:Panel ID="panFS" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tevalue0">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Po =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFo" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtFo" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblPo" runat="server" class="control-label" Text="Magnitud del impulso [kN/s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>w =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtWa" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtWa" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblFrecuenciaE" runat="server" class="control-label" Text="Frecuencia [rad/s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-8 text-center lead">
                                                                                P(t) = Po.Sin(w.t)
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <%--Value 2--%>
                                                                <asp:Panel ID="panFL" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tevalue2">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>I =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtI" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtI" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblI" runat="server" class="control-label" Text="Magnitud del impulso [kN/s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>DI =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDI" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtDI" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblDI" runat="server" class="control-label" Text="Duración del impulso [s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-8 text-center lead">
                                                                                Pmax = (I).(DI)
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <%--Value 3--%>
                                                                <asp:Panel ID="panFT" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tevalue3">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Pmax =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFmax" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtFmax" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblPmax" runat="server" class="control-label" Text="Carga máxima [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>t1 =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtT1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtT1" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblT1" runat="server" class="control-label" Text="Tiempo 1 [s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>t2 =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtT2" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtT2" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblT2" runat="server" class="control-label" Text="Tiempo 2 [s]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>t3 =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtT3" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtT3" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblT3" runat="server" class="control-label" Text="Tiempo 3 [s]"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <%--Value 4--%>
                                                                <asp:Panel ID="panAC" runat="server" Style="padding-top: 15px;">
                                                                    <div id="tevalue4">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-8">
                                                                                <asp:FileUpload ID="FUpLoadAC" runat="server" class="btn btn-warning" />
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <asp:LinkButton ID="ibtnLoadAce" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click" Height="33px">
                                                                                        <i class="fa fa-cloud-upload"></i>
                                                                                        Upload
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblNotaAce" runat="server" class="col-sm-12 text-justify small"
                                                                                Text="Nota: El archivo solo puede contener valores de aceleración. Verificar que al inicio de la columna no haya espacio ni tab. Si las aceleraciones estan en columnas deberán estar separadas por:"></asp:Label>
                                                                            <asp:DropDownList ID="DDLsepCol" runat="server" Visible="False" class="form-control">
                                                                                <asp:ListItem Value="0">Tabs</asp:ListItem>
                                                                                <asp:ListItem Value="1">Espacio</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblDace" runat="server" class="col-sm-8 control-label label-one" Text="Duración del acelerograma [s]"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtdAC" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtdAC" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblPasoAce" runat="server" class="col-sm-8 control-label label-one" Text="Paso [s]"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtpasoAC" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtpasoAC" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblFacAce" runat="server" class="col-sm-8 control-label label-one" Text="Factor de aceleración [m/s^2]"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtfacAC" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Custom, numbers"
                                                                                    TargetControlID="txtfacAC" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMensaje" runat="server" class="col-sm-12 text-justify small" Text=""></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                            <div class="col-md-5">
                                                                <asp:Label ID="lblEsqTE" runat="server" class="label-title-imge lead" Text="ESQUEMA"></asp:Label>
                                                                <hr />
                                                                <div style="width: 100%; height: 188px;">
                                                                    <div class="image">
                                                                        <asp:Image ID="FigExi1" runat="server" /><asp:Image ID="FigExi2"
                                                                            runat="server" /><asp:Image ID="FigExi3" runat="server" /><asp:Image ID="FigExi4" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST4 FORM -->
                                                    <div class="tab-pane" id="test4" style="padding-top: 5px;">
                                                        <div class="form-group">
                                                            <div class="col-md-2"></div>
                                                            <div class="col-md-7" style="padding-top: 10%; padding-bottom: 10%;">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDA" runat="server" class="col-sm-4 control-label" Text="Duración = "></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtDA" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="Filteredtextboxextender20" runat="server" FilterType="Custom, numbers"
                                                                            TargetControlID="txtDA" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <label class="col-sm-1 label-der lead" style="padding-top: 5px;">[s]</label>
                                                                    <div class="col-sm-1 control-label label-der">
                                                                        <asp:Label ID="lblMensCE" runat="server" class="badge bg-yellow" Text="Listo!!" Visible="False"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <div class="col-sm-7"></div>
                                                                        <asp:LinkButton ID="ibtnRun" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-sm-5">
                                                                        <asp:DropDownList ID="DDLborrarA" runat="server" class="form-control">
                                                                            <asp:ListItem Value="0">Analizar</asp:ListItem>
                                                                            <asp:ListItem Value="1">Borrar &#250;ltimo Analisis</asp:ListItem>
                                                                            <asp:ListItem Value="2">Borrar todos los analisis</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblError" runat="server" class="col-sm-12" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST4 FORM -->
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END CONTENT RIGHT -->
                                    </div>
                                </div>
                            </div>

                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">OUTPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                            <!-- BEGIN SECTION RESULT -->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-align-left"></i>
                                                        <asp:Label ID="lblRespMax" runat="server" class="grid-title lead" Text="RESPUESTA MAXIMA"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body" style="height: 540px">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label small"></label>
                                                                <asp:Label ID="lblNudo2" runat="server" class="col-sm-4 lead" Text="Nudo 2"></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>umax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXmax" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXmax" runat="server" class="col-sm-2 label-der small"></asp:Label></var>
                                                                <em>
                                                                    <asp:Label ID="lblRdespMax" runat="server" class="col-sm-4" Text="Desplazamiento máximo"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>ůmax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXomax" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXoMax" runat="server" class="col-sm-2 label-der small"></asp:Label></var>
                                                                <em>
                                                                    <asp:Label ID="lblRVeloMax" runat="server" class="col-sm-4" Text="Velocidad máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>ümax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXoomax" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXooMax" runat="server" class="col-sm-2 label-der small"></asp:Label></var>
                                                                <em>
                                                                    <asp:Label ID="lblRacelMax" runat="server" class="col-sm-4" Text="Velocidad máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label small"></label>
                                                                <asp:Label ID="lblEle1" runat="server" class="col-sm-4 lead" Text="Elemento 1"></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>Fmax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtFomax" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>kN</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblFomax" runat="server" class="col-sm-2 label-der small"></asp:Label></var>
                                                                <em>
                                                                    <asp:Label ID="lblRfuerzaMax" runat="server" class="col-sm-4" Text="Fuerza máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-offset-3 col-sm-8">
                                                                    <asp:LinkButton ID="ibtnDescRmax" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                        <i class="fa fa-download"></i>
                                                                        Download Answers
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION RESULT -->

                                            <!-- BEGIN SECTION GRAPHICS -->
                                            <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblGraficas" runat="server" class="grid-title lead" Text="GRAFICAS"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body" style="height: 540px">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label11" runat="server" class="col-sm-3 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                <div class="col-sm-6">
                                                                    <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                        <option>Ground acceleration (Only with acceleration record)</option>
                                                                        <option>Type of Excitation</option>
                                                                        <option>Relative displacement (Node 2)</option>
                                                                        <option>Relative velocity (Node 2)</option>
                                                                        <option>Relative acceleration (Node 2)</option>
                                                                        <option>Internal force (Element 1)</option>
                                                                        <option>Hysterisis (Element 1)</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group text-center">
                                                                <div class="col-md-12">
                                                                    <div id="graphics0" style="padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdAcSoil" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul1" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics1" style="padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdFuncionFuerza" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul2" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics2" style="padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdDespVsTime" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul3" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics3" style="padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdVeloVsTime" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul4" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics4" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdAceVsTime" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul5" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics5" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdForceVsTime" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul6" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics6" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div style="width: 86.68%; height: 440px; margin-left: 55px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="wcdFvsD" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnDownResul7" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                <i class="fa fa-download"></i>
                                                                                Download Answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION GRAPHICS -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- END SECTION CONTENT -->
            </aside>
            <!-- END MAIN CONTENT -->
        </div>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/Content/assets/js") %>
            <%: Scripts.Render("~/bundles/modernizr") %>
        </asp:PlaceHolder>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
    <!-- BEGIN JS PLUGIN -->
    <script type="text/javascript">
        /**
         * Seteamos con index cero el combo y la imagen
         * Autor: OneClick
        */

        //Hide all Graphics
        var arrGraphics = ["graphics0", "graphics1", "graphics2", "graphics3", "graphics4", "graphics5", "graphics6"];
        jQuery.each(arrGraphics, function (i, val) {
            $("#" + val).hide();
        });
        $("#graphics")[0].selectedIndex = 0;
        $("#graphics0").show();

        /**
         * Show and Hide Graphics
         * Autor: OneClick
         * @param {select}: Elemento select
         * @param {imgName}: Tipo imagen
        */
        function setImageGraphics(select, imgName) {
            //Disabled all Graphics
            jQuery.each(arrGraphics, function (i, val) {
                $("#" + val).hide();
            });
            $("#" + imgName + select.selectedIndex).show();
        }

        document.getElementById("wcdAcSoil").style.width = "";
        document.getElementById("wcdAcSoil").style.height = "";
        document.getElementById("wcdFuncionFuerza").style.width = "";
        document.getElementById("wcdFuncionFuerza").style.height = "";
        document.getElementById("wcdDespVsTime").style.width = "";
        document.getElementById("wcdDespVsTime").style.height = "";
        document.getElementById("wcdVeloVsTime").style.width = "";
        document.getElementById("wcdVeloVsTime").style.height = "";
        document.getElementById("wcdAceVsTime").style.width = "";
        document.getElementById("wcdAceVsTime").style.height = "";
        document.getElementById("wcdForceVsTime").style.width = "";
        document.getElementById("wcdForceVsTime").style.height = "";
        document.getElementById("wcdFvsD").style.width = "";
        document.getElementById("wcdFvsD").style.height = "";
    </script>
    <!-- END JS PLUGIN -->
</body>
</html>
