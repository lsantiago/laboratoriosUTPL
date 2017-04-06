<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfColumRect.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Parameter_ColumnRect_wfColumRect"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MC-PARAMETER RECTANGULAR COLUMN</title>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
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
                    <span><b>M-C PARAMETER : RECTANGULAR COLUMNS</b></span>
                    <ol class="breadcrumb">
                        <li>PARAMETER STUDY OF MOMENT-CURVATURE RESPONSE OF RC-SECTIONS</li>
                    </ol>
                    <h5><b>Description:</b> Parameter study of Moment-Curvature response of circular and rectangular sections</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Ayala, A.</h5>
                    <h5><b>Info:</b> MC-Parameter</h5>
                    <h5>This application is avalible for registered users only</h5>
                    <h5>If you experience any problem or if you need assistance running this program please contact vasuarez@utpl.edu.ec</h5>
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
                                                    <div class="grid-body text-center">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Experimentos/LABORATORIOS/imagenes/MCColumna Retangular.jpg" Width="290px" Height="220px" />
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
                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="SECTION PROPERTIES"></asp:Label></strong></a></li>
                                                </ul>
                                                <div class="tab-content" style="width: 100%; height: 250px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1">
                                                        <div class="col-md-1" style="padding-top: 50px;"></div>
                                                        <div class="col-md-7" style="padding-top: 50px;">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblNumSecciones" runat="server" class="col-sm-6 control-label small" Text="NUMBER OF SECTIONS TO ANALYZE:"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtNumberSections" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-6"></label>
                                                                    <div class="col-sm-5">
                                                                        <button type="button" class="md-trigger btn btn-warning" data-modal="modal-1">Input data</button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-6"></label>
                                                                    <div class="col-sm-5">
                                                                        <button type="button" class="md-trigger btn btn-warning" data-modal="modal-2">Material properties</button>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-6"></label>
                                                                    <div class="col-sm-6">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius" >
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="md-modal md-effect-8" id="modal-1">
                                                                    <div class="md-content modal-content" style="height: 540px; width: 950px;">
                                                                        <div class="modal-header">
                                                                            <h4 class="modal-title" id="myModalLabel27"><asp:Label ID="lblInputData1" runat="server" CssClass="Funcionalidad-titulo"></asp:Label></h4>
                                                                        </div>
                                                                        <div class="modal-body" style="height: 420px; overflow: auto;">
                                                                                <div class="form-horizontal" role="form">
                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-2 control-label small label-one"><b>SECTION NUMBER:</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>1</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>2</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>3</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>4</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>5</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>6</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>7</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>8</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>9</b></label>
                                                                                        <label class="col-sm-1 text-center small"><b>10</b></label>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblSectionBase" runat="server" class="col-sm-2 control-label small label-one" Text="SECTION BASE B (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBase10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblSectionHeight" runat="server" class="col-sm-2 control-label small label-one" Text="SECTION HEIGHT H (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtHeight10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblCoverTopBottom" runat="server" class="col-sm-2 control-label small label-one" Text="COVER UP TO TOP AND BOTTOM REBAR CENTRE r´ (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtcoverTopBottom10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblCoverLateral" runat="server" class="col-sm-2 control-label small label-one" Text="COVER UP TO LATERAL REBAR CENTRE r (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtCoverLateral10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNumBars" runat="server" class="col-sm-2 control-label small label-one" Text="# BARS OF TOP AND BOTTOM STEEL"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBarsTopBottom10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblDiamTopBottom" runat="server" class="col-sm-2 control-label small label-one" Text="DIAMETER BARS OF TOP AND BOTTOM STEEL"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamTopBottom10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNumBarsLateral" runat="server" class="col-sm-2 control-label small label-one" Text="# BARS OF LATERAL STEEL"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumBarsLateral10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblDiamLateral" runat="server" class="col-sm-2 control-label small label-one" Text="DIAMETER BARS OF LATERAL STEEL"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamLateral10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNumLegsX" runat="server" class="col-sm-2 control-label small label-one" Text="# OF STIRRUPS LEGS RESISTING SHEAR IN X DIRECTION"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsX10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNumLegsY" runat="server" class="col-sm-2 control-label small label-one" Text="# OF STIRRUPS LEGS RESISTING SHEAR IN Y DIRECTION"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtNumStirrupsY10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblDiamStirrups" runat="server" class="col-sm-2 control-label small label-one" Text="DIAMETER OF STIRRUPS (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtDiamStirrups10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblSpacingStirrups" runat="server" class="col-sm-2 control-label small label-one" Text="SPACING OF STIRRUPS (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtSpacingStirrups10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblBiaxialAngle" runat="server" class="col-sm-2 control-label small label-one" Text="BIAXIAL ANGLE (Θ)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtBiaxial10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblAxialLoad" runat="server" class="col-sm-2 control-label small label-one" Text="AXIAL LOAD (kN)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtAxialLoad10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                        <b>
                                                                                            <asp:Label ID="lblShearSpan" runat="server" class="col-sm-2 control-label small label-one" Text="SHEAR SPAN (mm)"></asp:Label></b>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan1" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan2" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan3" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan4" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan5" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan6" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan7" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan8" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan9" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox ID="txtShearSpan10" runat="server" class="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                        </div>
                                                                        <div class="modal-footer">
                                                                            <div class="btn-group">
                                                                                <button type="button" class="btn btn-default md-close" data-dismiss="modal">Close</button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="md-modal md-effect-8" id="modal-2">
                                                                    <div class="md-content modal-content" style="width: 950px;">
                                                                        <div class="modal-header">
                                                                            <h4 class="modal-title" id="myModalLabel27"><asp:Label ID="lblTituloMaterialProper" runat="server" CssClass="Funcionalidad-subtitulo"></asp:Label></h4>
                                                                        </div>
                                                                        <div class="modal-body">
                                                                            <div class="form-horizontal" role="form">
                                                                                <div class="form-group">
                                                                                    <b>
                                                                                        <asp:Label ID="Label27" runat="server" class="col-sm-2 control-label small label-one" Text="SECTION NUMBER:"></asp:Label></b>
                                                                                    <label class="col-sm-1 text-center small"><b>1</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>2</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>3</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>4</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>5</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>6</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>7</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>8</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>9</b></label>
                                                                                    <label class="col-sm-1 text-center small"><b>10</b></label>
                                                                                </div>
                                                                                <div class="form-group">
                                                                                    <b><asp:Label ID="lblFc" runat="server" class="col-sm-2 control-label small label-one" Text="CONCRETE COMPRESSIVE STRENGTH (MPa)"></asp:Label></b>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc1" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc2" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc3" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc4" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc5" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc6" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc7" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc8" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc9" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtfc10" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group">
                                                                                    <b><asp:Label ID="lblFy" runat="server" class="col-sm-2 control-label small label-one" Text="LONG STEEL YIELDING STRESS (MPa)"></asp:Label></b>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong1" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong2" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong3" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong4" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong5" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong6" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong7" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong8" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong9" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyLong10" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group">
                                                                                    <b><asp:Label ID="lblFytrans" runat="server" class="col-sm-2 control-label small label-one" Text="TRANSVERSE STEEL YIELDING STRESS (MPa)"></asp:Label></b>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans1" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans2" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans3" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans4" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans5" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans6" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans7" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans8" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans9" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtFyTrans10" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group">
                                                                                    <b><asp:Label ID="lblSteelRatio" runat="server" class="col-sm-2 control-label small label-one" Text="STEEL HARDENING RATIO"></asp:Label></b>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio1" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio2" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio3" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio4" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio5" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio6" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio7" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio8" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio9" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox ID="txtSteelRatio10" runat="server" class="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="modal-footer">
                                                                            <div class="btn-group">
                                                                                <button type="button" class="btn btn-default md-close" data-dismiss="modal">Close</button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->
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
                                            <!-- BEGIN SECTION RESULT LEFT-->
                                            <div class="col-md-4">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="Label1" runat="server" class="grid-title lead" Text="MOMENT-CURVATURE RESPONSE"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Imagenes/General/Tools/Dinamica_2GDL_Tool2.bmp" Width="290px" Height="220px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END SECTION RESULT LEFT-->

                                            <!-- BEGIN SECTION GRAPHICS -->
                                            <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblGraficas" runat="server" class="grid-title lead" Text="GRAFICAS"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form" style="width: 100%; height: 420px;">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label11" runat="server" class="col-sm-3 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                <div class="col-sm-7">
                                                                    <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                        <option>Moment-curvature response</option>
                                                                        <option>Yield curvature assessment</option>
                                                                        <option>Relation between strength and stiffness</option>
                                                                        <option>Cracked to gross inertia ratio vs. longitudinal steel ratio</option>
                                                                        <option>Relation between concrete strain and curvature</option>
                                                                        <option>Relation between steel strain and curvature</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-md-12 text-center">
                                                                    <div id="graphics0" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics1" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="col-sm-8">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12 text-center">
                                                                                    <chart:WebChartViewer ID="WebChartViewer2" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Label ID="lblFigura2" runat="server" class="text-justify"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics2" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="col-sm-8">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12 text-center">
                                                                                    <chart:webchartviewer id="WebChartViewer3" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Label ID="lblFigura3" runat="server" class="text-justify"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics3" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="col-sm-8">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12 text-center">
                                                                                    <chart:webchartviewer id="WebChartViewer4" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Label ID="lblFigura4" runat="server" class="text-justify"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics4" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="col-sm-8">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12 text-center">
                                                                                    <chart:webchartviewer id="WebChartViewer5" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Label ID="lblFigura5" runat="server" class="text-justify"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics5" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="col-sm-8">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12 text-center">
                                                                                    <chart:webchartviewer id="WebChartViewer6" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Label ID="lblFigura6" runat="server" class="text-justify"></asp:Label>
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
                            
                            <!-- BEGIN ANALYSIS OUTPUT -->
                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">ANALYSIS OUTPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="panel-group" id="accordion">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">MC-Parameter
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapseOne" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <p><asp:TextBox ID="txtresult" runat="server" Height="600px" TextMode="MultiLine" Width="800px" CssClass="texto-interno-pequeno"></asp:TextBox></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
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
        var arrGraphics = ["graphics0", "graphics1", "graphics2", "graphics3", "graphics4", "graphics5", "graphics6", "graphics7", "graphics8", "graphics9", "graphics10", "graphics11"];
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
