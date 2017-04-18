<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfmRecCol.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_DesignColumnRec_wfmRecCol" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MC-DESIGN RECTANGULAR COLUMN</title>

    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form id="frmMain" runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>RC-DESIGN : RECTANGULAR COLUMNS</b></span>
                    <ol class="breadcrumb">
                        <li>DESIGN OF RC SECTIONS</li>
                    </ol>
                    <h5><b>Description:</b> Design of Reinforced Concrete Sections</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Ayala, A.</h5>
                    <h5><b>Info:</b> RC-Design</h5>
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
                                        <h4 class="panel-title text-center">INPUTS</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <!-- BEGIN CONTENT LEFT -->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblTituloEsquemaColumna" runat="server" class="grid-title lead" Text="ESQUEMA"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                            <asp:LinkButton ID="btnCargarEjemplo" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo">
                                                                            Cargar Ejemplo
                                                                            <i class="fa fa-play"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center" style="width: 100%; height: 256px;">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/MCColumna Retangular.jpg" Width="100%" Height="100%" />
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
                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="SECTION PROPERTIES"></asp:Label></strong></a></li>
                                                    <li><a href="#test2" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblMaterialProperties" runat="server" Text="MATERIAL PROPERTIES"></asp:Label></strong></a></li>
                                                    <li><a href="#test3" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblDesignForces" runat="server" Text="DESIGN FORCES"></asp:Label></strong></a></li>
                                                    <li><a href="#test4" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAnalisis" runat="server" Text="ANALYSIS DATA"></asp:Label></strong></a></li>
                                                </ul>
                                                <div class="tab-content" style="width: 100%; height: 256px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1" style="padding-top: 15px;">
                                                        <div class="col-md-12">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="col-sm-6">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblbase" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtbase" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblaltura" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtaltura" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblcoverTopBottom" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtcoverTopBottom" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblCoverLateral" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtcoverlateral" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumBarsTopBottom" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumBarsTopBottom" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumberLateral" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumberLateralBars" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumStirrups" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumberStirrupsX" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblLateralBars" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumStirrupsY" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblSpacingStirrups" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtSpacingStirrups" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblShearSpan" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtShearSpan" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
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
                                                                    <asp:Label ID="lblConcrComprStrength" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtConcrComprStrength" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblLongFy" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtfyLong" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblTransFy" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtfyTrans" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-8">
                                                                        <select id="graphicsMP" class="form-control" onchange="setImageGraphics(this, 'graphicsMP');">
                                                                            <option>Concrete Model</option>
                                                                            <option>Steel Model</option>
                                                                        </select>
                                                                    </div>
                                                                    <div class="col-sm-4"></div>
                                                                </div>
                                                                <hr />
                                                                <div style="width: 100%; height: 100%;">
                                                                    <div id="graphicsMP0" class="col-sm-11" style="width: 315px; height: 187px; padding-left: 0px">
                                                                        <asp:Image ID="imgModeloConcreto" runat="server" width="300px" height="190px" />
                                                                    </div>
                                                                    <div id="graphicsMP1" class="col-sm-11" style="width: 315px; height: 187px; padding-left: 0px">
                                                                        <asp:Image ID="imgModeloAcero" runat="server" width="100%" height="100%" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3" style="padding-top: 60px;">
                                                        <div class="col-md-2"></div>
                                                        <div class="col-md-5">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblAxialLoad" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-4">
                                                                        <asp:TextBox ID="txtAxialLoad" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblMoment" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-4">
                                                                        <asp:TextBox ID="txtMoment" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblAngle" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-4">
                                                                        <asp:TextBox ID="txtangle" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST4 FORM -->
                                                    <div class="tab-pane" id="test4" style="padding-top: 60px;">
                                                        <div class="col-md-3"></div>
                                                        <div class="col-md-9">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-2"></div>
                                                                    <div class="col-sm-4">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label11" runat="server" class="col-sm-2 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                    <div class="col-sm-4">
                                                                        <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphicsR');">
                                                                            <option>ANALYSIS</option>
                                                                            <option>DESIGN RESULTSri</option>
                                                                        </select>
                                                                    </div>
                                                                    <div id="moment">
                                                                        <div class="col-sm-7">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST4 FORM -->
                                                </div>
                                                <!-- END CONTENT RIGHT -->
                                            </div>
                                            <!-- END CONTENT RIGHT -->
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">OUTPUTS</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div id="graphicsR0">
                                            <!-- BEGIN SECTION RESULT LEFT MOMENT-CURVATURE RESULTS-->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblMCResponse" runat="server" class="grid-title lead"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center" style="width: 100%; height: 300px;">
                                                        <div id="chart-line" style="width: 100%; height: 100%">
                                                            <chart:WebChartViewer ID="WebChartViewer1" runat="server" BorderColor="White" SelectionBorderColor="Transparent" Style="position: static" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION RESULT LEFT-->

                                            <!-- BEGIN SECTION RESULT RIGHT MOMENT-CURVATURE RESULTS-->
                                            <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblAnalysis" runat="server" class="grid-title lead" Text="ANALYSIS"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form" style="width: 100%; height: 300px;">
                                                            <div class="form-group">
                                                                <div class="col-md-12 text-center">
                                                                    <div class="col-sm-5">
                                                                        <asp:Label ID="lblAnalysisIndex" runat="server" class="lead" Text="ANALYSIS"></asp:Label>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblLongRR" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgCargaAxial" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtLongRR1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblTransRR" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgAceroTrans" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtTransRR1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblAxialLoadRatio" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgPorcCargaAxial" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtAxialLoadRatio1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-7">
                                                                        <asp:Label ID="lblAnalysisResults" runat="server" class="lead" Text="ANALISIS RESULTS"></asp:Label>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMomentoPrimeraFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgMomentoPrimeraFluencia" runat="server" class="col-sm-2 label-one" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtMomentoPrimeraFluencia1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblPrimeraCurvaturaFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgPrimeraCurvaturaFluencia" runat="server" class="col-sm-2 label-one" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbPrimeraCurvaturaFluencia1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMomentoNominal" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgMomentoNominal" runat="server" class="col-sm-2 label-one" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbMomentoNominal1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblCurvaturaFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="Image4" runat="server" class="col-sm-2 label-one" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbCurvaturaFluencia1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblIncerciaAgrietada" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgAgrietada" runat="server" class="col-sm-2 label-one" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbIncerciaAgrietada1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lbldefConc" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDefMomNom1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblDamConMom" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDamageControl1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblDamageControl" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDamCon1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblSlopeRatio" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtSlopeRatio1" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION RESULT RIGHT -->
                                        </div>
                                        <div id="graphicsR1" class="row">
                                            <!-- BEGIN DESIGN RESULTSri-->
                                            <div class="col-md-12">
                                                <div class="grid">
                                                <div class="grid-header">
                                                    <i class="fa fa-bar-chart-o"></i>
                                                    <asp:Label ID="lblDesignResults" runat="server" class="grid-title lead" Text="ANALYSIS"></asp:Label>
                                                    <div class="pull-right grid-tools"></div>
                                                </div>
                                                <div class="grid-body">
                                                    <div class="form-horizontal" role="form">
                                                        <div class="form-group">
                                                            <div class="col-sm-2"></div>
                                                                <div class="col-sm-6">
                                                                <div class="form-group">
                                                                    <b><asp:Label ID="lblTituloAnalysisIndex" runat="server" class="col-sm-8 control-label small label-one"></asp:Label></b>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDiameterTop" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtDiameterLongitudinal" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDiameterStirrup" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtDiameterStirrup" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-12">
                                                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>
                                            <!-- END DESIGN RESULTSri -->
                                    </div>
                                    </div>
                                </div>
                            </div>

                            <!-- BEGIN ANALYSIS OUTPUT -->
                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">ANALYSIS OUTPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <!-- BEGIN COLLAPSIBLE GROUP ITEMS -->
                                            <div class="col-md-12">
                                                <div class="panel-group" id="accordion">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">RC-Design
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapseOne" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <p>
                                                                    <asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="100%" class="form-control"></asp:TextBox></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END COLLAPSIBLE GROUP ITEM -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END ANALYSIS OUTPUT -->
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
    </form>
    <!-- BEGIN JS PLUGIN -->
    <script type="text/javascript">
        /**
         * Seteamos con index cero el combo y la imagen
         * Autor: OneClick
        */

        //Hide all Graphics
        var arrGraphics = ["graphicsMP0", "graphicsMP1", "graphicsR0", "graphicsR1"];
        jQuery.each(arrGraphics, function (i, val) {
            $("#" + val).hide();
        });
        $("#graphicsMP")[0].selectedIndex = 0;
        $("#graphicsMP0").show();
        $("#graphics")[0].selectedIndex = 0;
        $("#graphicsR0").show();

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

