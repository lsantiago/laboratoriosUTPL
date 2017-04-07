<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="Dinamica_2GDL1.aspx.vb" Inherits="VirtualLabIS_Experimentos_Dinamica_2GDL_Tool1_Dinamica_2GDL1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../../Content/Images/Portal/barraPosicion.jpg" />

                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>2DOF-Dynamics</b></span>
                    <div class="pull-right grid-tools" style="padding-right: 10px;">
                        <img src="../../../../Content/Images/Portal/bannerSecundario.png" />
                    </div>

                    <ol class="breadcrumb">
                        <li>TIME HISTORY ANALYSIS OF TWO DEGREES OF FREEDOM SYSTEMS</li>
                    </ol>

                    <h5><b>Description:</b> Time history analysis of two degrees of freedom systems</h5>
                    <h5><b>Authors:</b> Viñán, A.R.; Suarez, V.A</h5>
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
                                        <div class="row">

                                            <!-- BEGIN CONTENT LEFT -->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblEsquemaMain" runat="server" class="grid-title lead" Text="ESQUEMA"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                            <asp:LinkButton ID="ibtnLoadExample" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo">
                                                                Cargar Ejemplo
                                                                <i class="fa fa-play"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center" style="width: 100%; height: 256px;">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="FigMain" runat="server" ImageUrl="~/Imagenes/General/Tools/Dinamica_2GDL_Tool1.png" Width="100%" Height="100%" />
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
                                                <div class="tab-content" style="width: 100%; height: 256px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1" style="padding-top: 40px;">
                                                        <div class="col-md-2"></div>
                                                        <div class="col-md-9">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <label class="col-sm-2"></label>
                                                                    <asp:Label ID="lblNudo2" runat="server" class="col-sm-2 lead" Style="padding-right: 0px;" Text="Nudo 2"></asp:Label>
                                                                    <asp:Label ID="lblNudo3" runat="server" class="col-sm-3 lead" Text="Nudo 3"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>m =</var></b></label>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtM1" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtM1" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtM2" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtM2" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblM" runat="server" class="control-label" Text="Masa [Tonnes]"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2"></label>
                                                                    <asp:Label ID="lblEle1" runat="server" class="col-sm-2 lead" Style="padding-right: 0px;" Text="Elemento 1"></asp:Label>
                                                                    <asp:Label ID="lblEle2" runat="server" class="col-sm-3 lead" Text="Elemento 2"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>k =</var></b></label>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtK1" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtK1" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtK2" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtK2" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblk" runat="server" class="control-label" Text="Rigidez [kN/m]"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label label-one">
                                                                        <b>
                                                                            <var>c =</var></b></label>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtC1" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtC1" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtC2" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtC2" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label ID="lblc" runat="server" class="control-label" Text="Coeficiente de amortiguamiento [kN*s/m]"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2" style="padding-top: 15px;">
                                                        <div class="col-md-7">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblEscTM" runat="server" class="col-sm-2 control-label label-one" Text="Escoger:"></asp:Label>
                                                                    <div class="col-sm-7">
                                                                        <asp:DropDownList ID="DDLmatTyp" runat="server" class="form-control" onclick="HideCtrlsTipoMaterial();">
                                                                            <asp:ListItem Selected="True" Value="0">El&#225;stico</asp:ListItem>
                                                                            <asp:ListItem Value="1">Bilineal 1</asp:ListItem>
                                                                            <asp:ListItem Value="2">Bilineal 2</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <asp:Panel ID="panBlineal1" runat="server" style="padding-top: 15px;">
                                                                    <div id="tmvalue1">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2"></label>
                                                                            <asp:Label ID="lblEle11" runat="server" class="col-sm-3 text-center lead" Text="Elemento 1"></asp:Label>
                                                                            <asp:Label ID="lblEle21" runat="server" class="col-sm-3 text-center lead" Text="Elemento 1"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Fy =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtFy1" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy2" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtFy2" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblFyMat21" runat="server" class="control-label" Text="Fuerza de fluencia [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>r =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtr1" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr2" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtr2" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblrMat21" runat="server" class="col-sm-4 label-der" Text="Coeficiente Post-Fluencia"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:Panel ID="panBlineal2" runat="server" style="padding-top: 15px;">
                                                                    <div id="tmvalue2">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2"></label>
                                                                            <asp:Label ID="lblEle12" runat="server" class="col-sm-3 text-center lead" Text="Elemento 1"></asp:Label>
                                                                            <asp:Label ID="lblEle22" runat="server" class="col-sm-3 text-center lead" Text="Elemento 2"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Fy =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy1M3" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtFy1M3" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFy2M3" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtFy2M3" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblFyMat31" runat="server" class="control-label" Text="Fuerza de Fluencia [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>r =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr1M3" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtr1M3" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtr2M3" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtr2M3" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblrMat31" runat="server" class="col-sm-4 label-der" Text="Coeficiente Post-Fluencia"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>R =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtRo1" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtRo1" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtRo2" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtRo2" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblRoMat31" runat="server" class="col-sm-4 label-der" Text="Val. Recom: 10 a 20"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div id="chart-line" style="width: 250px; height: 210px;">
                                                                <asp:Label ID="lblCT" runat="server" class="label-title-imge lead" Text="COMPORTAMIENTO TIPO"></asp:Label>
                                                                <hr />
                                                                <div style="width: 342px; height: 201px;">
                                                                    <asp:Image ID="FigMat1" runat="server" Width="100%" Height="100%" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3" style="padding-top: 15px;">
                                                        <div class="col-md-7">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblEscTE" runat="server" class="col-sm-2 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                    <div class="col-sm-7">
                                                                        <asp:DropDownList ID="DDLexiTyp" runat="server" class="form-control" onclick="HideCtrlsTipoExcitation()">
                                                                            <asp:ListItem Value="0">Funci&#243;n lineal</asp:ListItem>
                                                                            <asp:ListItem Value="1">Funci&#243;n trilineal</asp:ListItem>
                                                                            <asp:ListItem Value="2">Funci&#243;n sinusoidal</asp:ListItem>
                                                                            <asp:ListItem Value="3">Acelerograma</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <%--Value 1--%>
                                                                <asp:Panel ID="panFL" runat="server" style="padding-top: 15px;">
                                                                    <div id="tevalue0">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>I =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtI" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txtI" FilterType="Custom, numbers" ValidChars=".">
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
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" TargetControlID="txtDI" FilterType="Custom, numbers" ValidChars=".">
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
                                                                <%--Value 2--%>
                                                                <asp:Panel ID="panFT" runat="server" style="padding-top: 15px;">
                                                                    <div id="tevalue1">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Pmax =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFmax" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" TargetControlID="txtFmax" FilterType="Custom, numbers" ValidChars=".">
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
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" TargetControlID="txtT1" FilterType="Custom, numbers" ValidChars=".">
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
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtT2" FilterType="Custom, numbers" ValidChars=".">
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
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" TargetControlID="txtt3" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblT3" runat="server" class="control-label" Text="Tiempo 3 [s]"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <%--Value 3--%>
                                                                <asp:Panel ID="panFS" runat="server" style="padding-top: 15px;">
                                                                    <div id="tevalue2">
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>Po =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtFo" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" TargetControlID="txtFo" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                            <asp:Label ID="lblPo" runat="server" class="control-label" Text="Amplitud [kN]"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="col-sm-2 control-label label-one">
                                                                                <b>
                                                                                    <var>w =</var></b></label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtWa" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtWa" FilterType="Custom, numbers" ValidChars=".">
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
                                                                <%--Value 4--%>
                                                                <asp:Panel ID="panAC" runat="server" style="padding-top: 15px;">
                                                                    <div id="tevalue3">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-8">
                                                                                <asp:FileUpload ID="FUpLoadAC" runat="server" class="btn btn-warning" />
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <asp:LinkButton ID="ImageButton2" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click" Style="height: 33px;">
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
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" TargetControlID="txtdAC" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblPasoAce" runat="server" class="col-sm-8 control-label label-one" Text="Paso [s]"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtpasoAC" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" TargetControlID="txtpasoAC" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblFacAce" runat="server" class="col-sm-8 control-label label-one" Text="Factor de aceleración [m/s^2]"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtfacAC" runat="server" class="form-control"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" TargetControlID="txtfacAC" FilterType="Custom, numbers" ValidChars=".">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMensaje" runat="server" class="col-sm-12 text-justify small" Text=""></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:Label ID="lblEsqTE" runat="server" class="label-title-imge lead" Text="ESQUEMA"></asp:Label>
                                                            <hr />
                                                            <div id="chart-line" style="width: 300px; height: 187px;">
                                                                <asp:Image ID="FigExi1" runat="server" Width="100%" Height="100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST4 FORM -->
                                                    <div class="tab-pane" id="test4" style="padding-top: 15px;">
                                                        <div class="col-md-2" style="padding-top: 50px;"></div>
                                                        <div class="col-md-7" style="padding-top: 50px;">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDA" runat="server" class="col-sm-4 control-label" Text="Duración = "></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtDA" runat="server" class="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server" TargetControlID="txtDA" FilterType="Custom, numbers" ValidChars=".">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <p class="lead">[s]</p>
                                                                    <asp:Label ID="lblMensCE" runat="server" class="badge bg-yellow" Text="Listo!!" Visible="False"></asp:Label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="ImageButton1" runat="server" class="btn btn-warning btn-radius" OnClick="ImageButton1_Click">
                                                                                    <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <asp:DropDownList ID="DDLborrarA" runat="server" class="form-control">
                                                                            <asp:ListItem Value="0">Analizar</asp:ListItem>
                                                                            <asp:ListItem Value="1">Borrar &#250;ltimo Analisis</asp:ListItem>
                                                                            <asp:ListItem Value="2">Borrar todos los analisis</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST4 FORM -->
                                                </div>
                                            </div>
                                            <!-- END CONTENT RIGHT -->
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">OUPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <!-- BEGIN SECTION RESULT -->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-align-left"></i>
                                                        <asp:Label ID="lblRespMax" runat="server" class="grid-title lead" Text="RESPUESTA MAXIMA"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body" style="height: 560px">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label small"></label>
                                                                <asp:Label ID="lblNudo21" runat="server" class="col-sm-4 lead" Text="Nudo 2"></asp:Label>
                                                                <asp:Label ID="lblNudo31" runat="server" class="col-sm-4 text-center lead" Text="Nudo 3"></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <em>
                                                                    <asp:Label ID="lblRdespMax" runat="server" class="col-sm-6" Text="Desplazamiento máximo"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>umax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXmax1" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXmax1" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXmax2" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXmax2" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                            </div>
                                                            <div class="form-group">
                                                                <em>
                                                                    <asp:Label ID="lblRVeloMax" runat="server" class="col-sm-6" Text="Velocidad máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>ůmax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXomax1" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXoMax1" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXoMax2" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXoMax2" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                            </div>
                                                            <div class="form-group">
                                                                <em>
                                                                    <asp:Label ID="lblRacelMax" runat="server" class="col-sm-6" Text="Aceleración máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>ümax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXoomax1" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s^2</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXooMax1" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtXooMax2" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>m/s^2</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblXooMax2" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label small"></label>
                                                                <asp:Label ID="lblEle13" runat="server" class="col-sm-4 lead" Text="Elemento 1"></asp:Label>
                                                                <asp:Label ID="lblEle23" runat="server" class="col-sm-4 text-center lead" Text="Elemento 2"></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <em>
                                                                    <asp:Label ID="lblRfuerzaMax" runat="server" class="col-sm-6" Text="Fuerza máxima"></asp:Label></em>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2"></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtFomax1" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>kN</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblFomax1" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtFomax2" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>kN</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblFoMax2" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Label ID="lblEle26" runat="server" class="col-sm-6 lead" Text="Elemento 1"></asp:Label>
                                                                <asp:Label ID="lblEle27" runat="server" class="col-sm-6 lead" Text="Elemento 2"></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label label-one">
                                                                    <b>
                                                                        <var>Fmax =</var></b></label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtFomax3" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>kN</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblFomax3" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtFomax4" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <label class="col-sm-1 label-der small">
                                                                    <var>kN</var></label>
                                                                <var>
                                                                    <asp:Label ID="lblFomax4" runat="server" class="col-sm-1 label-der small"></asp:Label></var>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-offset-3 col-sm-8">
                                                                    <asp:LinkButton ID="ImageButton14" runat="server" class="btn btn-warning" OnClick="ImageButton14_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
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
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label11" runat="server" class="col-sm-3 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                <div class="col-sm-7">
                                                                    <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                        <option>Ground acceleration (Only with acceleration record)</option>
                                                                        <option>Type of Excitation</option>
                                                                        <option>Relative displacement (Node 2)</option>
                                                                        <option>Relative displacement (Node 3)</option>
                                                                        <option>Relative velocity (Node 2)</option>
                                                                        <option>Relative velocity (Node 3)</option>
                                                                        <option>Relative acceleration (Node 2)</option>
                                                                        <option>Relative acceleration (Node 3)</option>
                                                                        <option>Internal force (Element 1)</option>
                                                                        <option>Internal force (Element 2)</option>
                                                                        <option>Internal force (Damper element 1)</option>
                                                                        <option>Internal force (Damper element 2)</option>
                                                                        <option>Hysterisis (Element 1)</option>
                                                                        <option>Hysterisis (Element 2)</option>
                                                                        <option>Hysterisis (Damper element 1)</option>
                                                                        <option>Hysterisis (Damper element 2)</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-md-12 text-center">
                                                                    <div id="graphics0" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdAcSoil" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul1" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics1" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdFuncionFuerza" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul2" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics2" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdDespVsTime1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul3" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics3" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdDespVsTime2" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul4" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics4" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdVeloVsTime1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul5" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics5" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdVeloVsTime2" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul6" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics6" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdAceVsTime1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul7" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics7" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdAceVsTime2" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul8" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics8" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdForceVsTime1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul9" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics9" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdForceVsTime2" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul10" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics10" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdForceVsTime3" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul13" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics11" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdForceVsTime4" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul14" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div id="graphics12" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdFvsD1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul11" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics13" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdFvsD2" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul12" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics14" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdFvsD3" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul15" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics15" style="width: 100%; height: 100%; padding-top: 15px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="wcdFvsD4" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnDownResul16" runat="server" class="btn btn-warning" OnClick="btnDownResul1_Click">
                                                                                    <i class="fa fa-download"></i>
                                                                                    Download answers
                                                                                </asp:LinkButton>
                                                                            </div>
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
                    </div>
                </section>
                <!-- END SECTION CONTENT -->
            </aside>
            <!-- END MAIN CONTENT -->
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/Content/assets/js") %>
            <%: Scripts.Render("~/Content/assets/js/2GDL1") %>
            <%: Styles.Render("~/Content/assets/css") %>
            <%--<%: Scripts.Render("~/bundles/modernizr") %>--%>
        </asp:PlaceHolder>
    </form>
    <!-- BEGIN JS PLUGIN -->
    <script type="text/javascript">
        /**
         * Seteamos con index cero el combo y la imagen
         * Autor: OneClick
        */

        //Hide all Graphics
        var arrGraphics = ["graphics0", "graphics1", "graphics2", "graphics3", "graphics4", "graphics5", "graphics6", "graphics7", "graphics8", "graphics9", "graphics10", "graphics11", "graphics12", "graphics13", "graphics14", "graphics15"];
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
    </script>
    <!-- END JS PLUGIN -->
</body>
</html>
