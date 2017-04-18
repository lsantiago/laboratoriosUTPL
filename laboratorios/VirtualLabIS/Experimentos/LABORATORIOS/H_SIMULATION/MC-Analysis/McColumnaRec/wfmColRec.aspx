<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfmColRec.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Analysis_McColumnaRec_wfmColRec"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MC-ANALYSIS RECTANGULAR COLUMN</title>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>RC-ANALYSIS: RECTANGULAR COLUMN</b></span>
                    <ol class="breadcrumb">
                        <li>MOMENT-CURVATURE AND SHEAR CAPACITY OF RC SECTIONS</li>
                    </ol>
                    <h5><b>Description:</b> Moment-Curvature and Shear Capacity analysis of RC sections</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Ayala, A.</h5>
                    <h5><b>Info:</b> RC-Analysis</h5>
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
                                            <div class="col-md-4" style="border-right: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblEsquemaMain" runat="server" class="grid-title lead" Text="ESQUEMA"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                            <asp:LinkButton ID="btnCargarEjemplo" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo" >
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
                                            <div class="col-md-8">
                                                <ul class="nav nav-tabs">
                                                    <li class="active"><a href="#test1" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblTituloSeccionProper" runat="server"></asp:Label>
                                                        </strong></a></li>
                                                    <li><a href="#test2" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblTituloMaterialProper" runat="server"></asp:Label></strong></a></li>
                                                    <li><a href="#test3" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAnalisis" runat="server" Text="ANALISIS"></asp:Label></strong></a></li>
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
                                                                        <asp:Label ID="lblcover1" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtcoverTopBottom" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblcover2" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtCoverLateral" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblLongBarDiameter1" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtDiamTopBottom" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumberLongBars1" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumberTopBottom" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblLongBarDiameter2" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtDiamLateral" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumberLongBars2" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumberLateral" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblLongBarDiameter3" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumLegsX" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblNumberLongBars3" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtNumberLegsY" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblestribosX" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtDiamEstr" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblestribosY" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtSpacingEstr" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblShearSpan" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtShearSpan" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblAxialLoad" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtAxialLoad" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblAngle" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtAngle" runat="server" class="form-control"></asp:TextBox>
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
                                                                    <asp:Label ID="lblLongRYS" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtfyLong" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblTransRYS" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtfyTrans" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblindEnd" runat="server"  class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtratioSteel" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDmode" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:DropDownList ID="ddmode" runat="server" class="form-control">
                                                                            <asp:ListItem Selected="True" Value="uniaxial">uniaxial</asp:ListItem>
                                                                            <asp:ListItem Value="biaxial">biaxial</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-8">
                                                                        <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                            <option>Concrete Model</option>
                                                                            <option>Steel Model</option>
                                                                        </select>
                                                                    </div>
                                                                    <div class="col-sm-4"></div>
                                                                </div>
                                                                <hr />
                                                                <div style="width: 100%; height: 100%;">
                                                                    <div id="graphics0" class="col-sm-11" style="padding-left: 0px">
                                                                        <asp:Image ID="imgModeloConcreto" runat="server" Width="300px" Height="190px" />
                                                                    </div>
                                                                    <div id="graphics1" class="col-sm-11" style="padding-left: 0px">
                                                                        <asp:Image ID="imgModeloAcero" runat="server" Width="300px" Height="190px" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3" style="padding-top: 70px;">
                                                        <div class="col-md-4"></div>
                                                        <div class="col-md-4">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius" >
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->
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
                                        <div class="row">
                                            <!-- BEGIN SECTION RESULT LEFT-->
                                            <div class="col-md-4" style="border-right: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblTituloMCR" runat="server" class="grid-title lead"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center">
                                                        <div id="chart-line" style="width: 100%; height: 260px;">
                                                            <chart:WebChartViewer ID="WebChartViewer1" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION RESULT LEFT-->

                                            <!-- BEGIN SECTION RESULT RIGHT -->
                                            <div class="col-md-8">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblAnalysis" runat="server" class="grid-title lead"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form" style="width: 100%; height: 270px;">
                                                            <div class="form-group">
                                                                <div class="col-md-12 text-center">
                                                                    <div class="col-sm-5">
                                                                        <asp:Label ID="Label2" runat="server" class="lead" Text="ANALYSIS INDEXES"></asp:Label>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblLongRR" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgCargaAxial" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroLongitudinalAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtLongRR" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblTransRR" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgAceroTrans" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_CuantiaAceroTransversalAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtTransRR" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblAxialLoadRatio" runat="server" class="col-sm-6 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgPorcCargaAxial" runat="server" class="col-sm-2 label-one" ImageUrl="../../../../../Varios/Archivos/Imagenes/Columna/Ecuaciones/ID_RazonCargaAxialAMC.png" />
                                                                            <div class="col-sm-4">
                                                                                <asp:TextBox ID="txtAxialLoadRatio" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-7">
                                                                        <asp:Label ID="lblAnalysisResult" runat="server" class="lead"></asp:Label>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMomentoPrimeraFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgMomentoPrimeraFluencia" runat="server" class="col-sm-2" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraMomentoFluencia.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtMomentoPrimeraFluencia" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblPrimeraCurvaturaFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgPrimeraCurvaturaFluencia" runat="server" class="col-sm-2" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_PrimeraCurvaturaFluenciaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbPrimeraCurvaturaFluencia" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblMomentoNominal" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgMomentoNominal" runat="server" class="col-sm-2" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_MomentoNominalAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbMomentoNominal" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblCurvaturaFluencia" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="Image4" runat="server" class="col-sm-2" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_CurvaturaFluenciaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbCurvaturaFluencia" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblIncerciaAgrietada" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                            <asp:Image ID="imgAgrietada" runat="server" class="col-sm-2" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Columna/Ecuaciones/IA_InerciaAgrietadaAMC.png" />
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="tbIncerciaAgrietada" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lbldefConc" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDefMomNom" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblDamConMom" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDamageControl" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblDamageControl" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtDamCon" runat="server" class="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblSlopeRatio" runat="server" class="col-sm-9 control-label small label-one"></asp:Label>
                                                                            <div class="col-sm-3">
                                                                                <asp:TextBox ID="txtSlopeRatio" runat="server" class="form-control"></asp:TextBox>
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
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">RC-Analysis
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapseOne" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <p><asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="800px" CssClass="form-control"></asp:TextBox></p>
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
        var arrGraphics = ["graphics0", "graphics1", "graphics2"];
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
