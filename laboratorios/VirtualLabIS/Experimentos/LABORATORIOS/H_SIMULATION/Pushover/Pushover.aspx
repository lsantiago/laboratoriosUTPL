<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Pushover.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_Pushover_Pushover" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PUSHOVER</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
    <script src="../../../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script src="../../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript">function TABLE1_onclick() {

    }

    </script>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>PUSHOVER ANALYSIS: FRAMES FORMED BY TWO STORIES AND TWO SPANS</b></span>
                    <ol class="breadcrumb">
                        <li>PUSHOVER ANALISIS FOR FRAMES</li>
                    </ol>
                    <h5><b>Description:</b> Frames formed by two stories and two spans pushover analisis for frames</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Quinonez, S.; Duque, E.</h5>
                    <h5><b>Info:</b> Push-Frame</h5>
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
                                        <%--<div class="row">--%>
                                        <!-- BEGIN CONTENT LEFT -->
                                        <div class="col-md-4">
                                            <div class="grid">
                                                <div class="grid-header">
                                                    <i class="fa fa-bar-chart-o"></i>
                                                    <asp:Label ID="lblEsquemaMain" runat="server" class="grid-title lead" Text="OUTLINE"></asp:Label>
                                                    <div class="pull-right grid-tools">
                                                        <asp:LinkButton ID="btnCargarEjemplo" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo">
                                                                Cargar Ejemplo
                                                                <i class="fa fa-play"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="grid-body text-center" style="width: 100%; height: 400px;">
                                                    <div class="form-horizontal" role="form">
                                                        <div id="picture0" style="width: 100%; height: 320px">
                                                            <div class="image">
                                                                <asp:Image ID="imgPortico" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div id="picture1">
                                                            <div class="form-group">
                                                                <div class="col-sm-3"></div>
                                                                <div class="col-sm-6">
                                                                    <select id="graphicsColumns" class="form-control" onchange="setImageGraphics(this, 'graphicsColumns');">
                                                                        <option>Concrete Model</option>
                                                                        <option>Steel Model</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <hr />
                                                            <div class="form-group">
                                                                <div id="graphicsColumns0" class="text-center" style="width: 100%; height: 320px">
                                                                    <div class="image">
                                                                        <asp:Image ID="imgColumn" runat="server" ImageUrl="../../imagenes/ESQUEMA%20COLUMNA-EN.jpg" />
                                                                    </div>
                                                                </div>
                                                                <div id="graphicsColumns1" class="text-center" style="width: 100%; height: 320px">
                                                                    <div class="image">
                                                                        <asp:Image ID="Image5" runat="server" ImageUrl="../../imagenes/CORTE%20COLUMNA.jpg" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div id="picture2" role="form">
                                                            <div class="form-group">
                                                                <div class="col-sm-3"></div>
                                                                <div class="col-sm-6">
                                                                    <select id="graphicsBeams" class="form-control" onchange="setImageGraphics(this, 'graphicsBeams');">
                                                                        <option>Concrete Model</option>
                                                                        <option>Steel Model</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <hr />
                                                            <div class="form-group">
                                                                <div id="graphicsBeams0" class="text-center" style="width: 100%; height: 320px">
                                                                    <div class="image">
                                                                        <asp:Image ID="imgViga" runat="server" ImageUrl="../../imagenes/ESQUEMA%20VIGA-EN.jpg" />
                                                                    </div>
                                                                </div>
                                                                <div id="graphicsBeams1" class="text-center" style="width: 100%; height: 320px">
                                                                    <div class="image">
                                                                        <asp:Image ID="Image4" runat="server" ImageUrl="../../imagenes/CORTE%20VIGA.jpg" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END CONTENT LEFT -->

                                        <!-- BEGIN CONTENT RIGHT -->
                                        <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                            <ul class="nav nav-tabs">
                                                <li class="active"><a href="#test1" data-toggle="tab" onclick="a_onClick(0, 'picture')">
                                                    <strong>
                                                        <asp:Label ID="lblGeometryProperties" runat="server" Text="GEOMETRY PROPERTIES" Style="font-size: 0.9em;"></asp:Label></strong></a></li>
                                                <li><a href="#test2" data-toggle="tab" onclick="a_onClick(1, 'picture')">
                                                    <strong>
                                                        <asp:Label ID="lblTM" runat="server" Text="PROPERTIES OF COLUMNS" Style="font-size: 0.9em;"></asp:Label></strong></a></li>
                                                <li><a href="#test3" data-toggle="tab" onclick="a_onClick(2, 'picture')">
                                                    <strong>
                                                        <asp:Label ID="lblTE" runat="server" Text="PROPERTIES OF BEAMS" Style="font-size: 0.9em;"></asp:Label></strong></a></li>
                                                <li><a href="#test4" data-toggle="tab" onclick="a_onClick(0, 'picture')">
                                                    <strong>
                                                        <asp:Label ID="lblMaterialProperties" runat="server" Text="MATERIAL PROPERTIES" Style="font-size: 0.9em;"></asp:Label></strong></a></li>
                                                <li><a href="#test5" data-toggle="tab" onclick="a_onClick(0, 'picture')">
                                                    <strong>
                                                        <asp:Label ID="lblDatosAnálisis" runat="server" Text="ANALYSIS" Style="font-size: 0.9em;"></asp:Label></strong></a></li>
                                            </ul>
                                            <div class="form-horizontal" role="form">
                                                <div class="tab-content">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1">
                                                        <div class="form-group">
                                                            <div class="col-md-2"></div>
                                                            <div class="col-md-6" style="padding-top: 15%; padding-bottom: 18.5%;">
                                                                <div class="form-horizontal" role="form">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblSpan1" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtvano1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblSpan2" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtvano2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblHStory1" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtaltura1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblHStory2" runat="server" class="col-sm-8 control-label small label-one"></asp:Label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtaltura2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2">
                                                        <div class="form-group">
                                                            <div class="col-md-12" style="padding-top: 6%; padding-bottom: 21%;">
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <label class="col-sm-12 control-label small label-one"></label>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <label class="col-sm-2 small label-one">Column1</label>
                                                                        <label class="col-sm-2 small label-one">Column2</label>
                                                                        <label class="col-sm-2 small label-one">Column3</label>
                                                                        <label class="col-sm-2 small label-one">Column4</label>
                                                                        <label class="col-sm-2 small label-one">Column5</label>
                                                                        <label class="col-sm-2 small label-one">Column6</label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:Label ID="lblBaseColumna" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC1" runat="server" class="col-sm-2 form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC5" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtBaseC6" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:Label ID="lblAlturaColumna" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC5" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtHeightC6" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:Label ID="lblRefuerzoLong" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf5" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtLongReinf6" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4">
                                                                        <asp:Label ID="lblRefuerzoTransv" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-8">
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC5" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox ID="txtTransvReinfC6" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3">
                                                        <div class="form-group text-center">
                                                            <div class="col-md-12" style="padding-top: 5px">
                                                                <div class="form-group text-center">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-sm-4">
                                                                        <asp:Label ID="lblTituloSeccionProper" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <label class="col-sm-3 small text-center">Beam1</label>
                                                                        <label class="col-sm-3 small text-center">Beam2</label>
                                                                        <label class="col-sm-3 small text-center">Beam3</label>
                                                                        <label class="col-sm-3 small text-center">Beam4</label>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group text-center">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblSectionBase" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBaseB1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBaseB2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBaseB3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBaseB4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblSectionHeight" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtHeightB1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtHeightB2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtHeightB3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtHeightB4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblRefuerzoCSuperior" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTopContinuous1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTopContinuous2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTopContinuous3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTopContinuous4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblRefuerzoCInferior" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBottomContinuous1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBottomContinuous2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBottomContinuous3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtBottomContinuous4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblRefuerzoIzquierdo" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfLeft1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfLeft2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfLeft3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfLeft4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblRefuerzoDerecho" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfRight1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfRight2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfRight3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtReinfRight4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblRefuerzoTransversal" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTransReinf1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTransReinf2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTransReinf3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtTransReinf4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-sm-4 text-center">
                                                                        <asp:Label ID="lblLoads" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-sm-6 text-center">
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="lblGravityLoad" runat="server" class="col-sm-12 control-label small label-one"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtGravityLoad1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtGravityLoad2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtGravityLoad3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox ID="txtGravityLoad4" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST4 FORM -->
                                                    <div class="tab-pane" id="test4">
                                                        <div class="form-group">
                                                            <div class="col-md-7" style="padding-top: 15px;">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblFc" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtFc" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblFy" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtFyTrans1" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-5" style="padding-top: 15px; padding-bottom: 13.3%">
                                                                <div class="form-group">
                                                                    <div class="col-sm-7">
                                                                        <select id="graphicsMP" class="form-control" onchange="setImageGraphics(this, 'graphicsMP');">
                                                                            <option>Concrete Model</option>
                                                                            <option>Steel Model</option>
                                                                        </select>
                                                                    </div>
                                                                    <div class="col-sm-4"></div>
                                                                </div>
                                                                <hr />
                                                                <div class="form-group">
                                                                    <div id="graphicsMP0" style="width: 100%; height: 220px">
                                                                        <div class="image">
                                                                            <asp:Image ID="imgMP1" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphicsMP1" style="width: 100%; height: 220px">
                                                                        <div class="image">
                                                                            <asp:Image ID="imgMP2" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST4 FORM -->

                                                    <!-- BEGIN TEST5 FORM -->
                                                    <div class="tab-pane" id="test5">
                                                        <div class="form-group">
                                                            <div class="col-md-5" style="padding-top: 8.4%;">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblPatronCarga" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-5">
                                                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                                                            <asp:ListItem>Triangular</asp:ListItem>
                                                                            <asp:ListItem>Uniform</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDesplazamientoMeta" runat="server" class="col-sm-7 control-label small label-one"></asp:Label>
                                                                    <div class="col-sm-5">
                                                                        <asp:TextBox ID="txtDesplazamientoMeta" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" style="padding-top: 20px;">
                                                                    <label class="col-sm-4"></label>
                                                                    <div class="col-sm-8 text-center">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius">
                                                                            RUN PUSHOVER ANALYSIS
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-7" style="padding-top: 15px; padding-bottom: 10.5%;">
                                                                <%--<div>--%>
                                                                <div class="image">
                                                                    <chart:WebChartViewer ID="WebChartViewerPushover" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                </div>
                                                                <%--</div>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST5 FORM -->
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END CONTENT RIGHT -->
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-group" style="margin-bottom: 0px;">
                                <div class="panel panel-primary" style="border-bottom: none;">
                                    <div class="panel-heading">
                                        <h4 class="panel-title text-center">OUTPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <%--<div class="row">--%>
                                        <!-- BEGIN SECTION RESULT LEFT-->
                                        <div class="col-md-4">
                                            <div class="grid">
                                                <div class="grid-header">
                                                    <i class="fa fa-bar-chart-o"></i>
                                                    <asp:Label ID="Label1" runat="server" class="grid-title lead" Text="OUTLINE"></asp:Label>
                                                    <div class="pull-right grid-tools">
                                                    </div>
                                                </div>
                                                <div class="grid-body text-center">
                                                    <div style="width: 100%; height: 260px">
                                                        <div class="image">
                                                            <asp:Image ID="imgPortico2" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END SECTION RESULT LEFT-->

                                        <!-- BEGIN SECTION RESULT -->
                                        <div class="col-md-8" style="border-left: 1.0pt solid #dddddd;">
                                            <div class="grid">
                                                <div class="grid-header">
                                                    <i class="fa fa-bar-chart-o"></i>
                                                    <asp:Label ID="lblResults" runat="server" class="grid-title lead"></asp:Label>
                                                    <div class="pull-right grid-tools"></div>
                                                </div>
                                                <div class="grid-body">
                                                    <div class="form-horizontal" role="form">
                                                        <div class="form-group">
                                                            <asp:Label ID="Label11" runat="server" class="col-sm-3 control-label label-one" Text="Select:"></asp:Label>
                                                            <div class="col-sm-3">
                                                                <select id="graphics" class="form-control" onchange="setImageGraphicsResult(this, 'graphics');">
                                                                    <option>Beam</option>
                                                                    <option>Column</option>
                                                                </select>
                                                            </div>
                                                            <asp:Label ID="Label3" runat="server" class="col-sm-2 control-label label-one" Text="Select:"></asp:Label>
                                                            <div class="col-sm-3">
                                                                <select id="graphicsR" class="form-control" onchange="setImageResult(this, 'graphicsR');">
                                                                    <option>Strain</option>
                                                                    <option>Dcr</option>
                                                                    <option>Moment</option>
                                                                    <option>Shear</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-md-12 text-center">
                                                                <div id="graphics0" class="col-sm-10">
                                                                    <div class="form-group">
                                                                        <div class="col-sm-12">
                                                                            <asp:Label ID="lblDraw" runat="server" class="col-sm-12 control-label label-one" Style="margin-left: 0px" Text="Select the beams for wich you want to plot resources. Then press the 'PLOT RESULTS' button"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-7">
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="CheckBoxSelectAll" runat="server" AutoPostBack="True" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cbBeam1" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cbBeam2" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cbBeam3" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cbBeam4" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-5">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-4" style="padding-top: 70px;">
                                                                                    <asp:LinkButton ID="btnGraficarVigas" runat="server" class="btn btn-warning btn-radius">
                                                                                    PLOT RESULTS
                                                                                    <i class="fa fa-play"></i>
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="graphics1" class="col-sm-10">
                                                                    <div class="form-group">
                                                                        <div class="col-sm-12 text-left">
                                                                            <asp:Label ID="lblColumnsDraw" runat="server" class="col-sm-12 control-label label-one" Text="Select the columns for wich you want to plot resources. Then press the 'PLOT RESULTS' button"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-7">
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="CheckBoxAllColumns" runat="server" AutoPostBack="True" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cbColumn1" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cdColumn2" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cdColumn3" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cdColumn4" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cdColumn5" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                            <div class="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="cdColumn6" runat="server" />
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-5">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-4" style="padding-top: 70px;">
                                                                                    <asp:LinkButton ID="btnGraficarColumnas" runat="server" class="btn btn-warning btn-radius">
                                                                                    PLOT RESULTS
                                                                                    <i class="fa fa-play"></i>
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
                                            </div>
                                        </div>
                                        <!-- END SECTION RESULT -->
                                        <%--</div>--%>
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
                                        <div id="graphics00" class="row">
                                            <div class="col-md-6">
                                                <div class="panel-group" id="accordion1">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">LEFT END
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapse1" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <div class="row">
                                                                    <div class="col-sm-6 text-center">
                                                                        <div id="graphicsRBeam0" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <asp:Image ID="Image1" runat="server" />
                                                                                    <chart:WebChartViewer ID="WebChar11" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam1" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart21" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam2" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="form-group">
                                                                                    <chart:WebChartViewer ID="WebChart31" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam3" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="form-group">
                                                                                    <chart:WebChartViewer ID="WebChart41" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-6 text-center">
                                                                        <div id="graphicsRBeam00" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <asp:Image ID="Image2" runat="server" />
                                                                                    <chart:WebChartViewer ID="WebChart12" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam11" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart22" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam22" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="form-group">
                                                                                    <chart:WebChartViewer ID="WebChart32" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam33" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart42" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="panel-group" id="accordion2">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">RIGHT END
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapse2" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <div class="row">
                                                                    <div class="col-sm-6">
                                                                        <div id="graphicsRBeam000" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <asp:Image ID="Image3" runat="server" />
                                                                                    <chart:WebChartViewer ID="WebChart13" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam111" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart23" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam222" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart33" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam333" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart43" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <div id="graphicsRBeam0000" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <asp:Image ID="Image6" runat="server" />
                                                                                    <chart:WebChartViewer ID="WebChart14" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam1111" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart24" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam2222" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart34" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRBeam3333" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChart44" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="graphics11" class="row">
                                            <div class="col-md-6">
                                                <div class="panel-group" id="accordion3">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">LEFT END
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapse3" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <div class="row">
                                                                    <div class="col-sm-6 text-center">
                                                                        <div id="graphicsRColumn0" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC11" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn1" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC21" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn2" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC31" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn3" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC41" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <div id="graphicsRColumn00" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC12" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn11" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC22" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn22" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC32" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn33" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC42" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="panel-group" id="accordion4">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h4 class="panel-title">
                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">RIGHT END
                                                                </a>
                                                            </h4>
                                                        </div>
                                                        <div id="collapse4" class="panel-collapse collapse">
                                                            <div class="panel-body">
                                                                <div class="row">
                                                                    <div class="col-sm-6">
                                                                        <div id="graphicsRColumn000" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC13" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC23" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn222" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC33" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn333" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC43" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <div id="graphicsRColumn0000" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC14" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn1111" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC24" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn2222" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC34" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div id="graphicsRColumn3333" class="form-group">
                                                                            <div style="width: 100%; height: 220px;">
                                                                                <div class="image">
                                                                                    <chart:WebChartViewer ID="WebChartC44" runat="server" Style="position: static" BorderColor="White" SelectionBorderColor="Transparent" Width="250px" Height="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
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


        //Hide all pictures
        var arrPicture = ["picture0", "picture1", "picture2"];
        jQuery.each(arrPicture, function (i, val) {
            $("#" + val).hide();
        });
        $("#picture0").show();

        //Hide all pictures
        var arrGraphics = ["graphicsColumns0", "graphicsColumns1", "graphicsBeams0", "graphicsBeams1", "graphicsMP0", "graphicsMP1", "graphics0", "graphics1", "graphics00", "graphics11"];
        jQuery.each(arrGraphics, function (i, val) {
            $("#" + val).hide();
        });
        $("#graphicsColumns")[0].selectedIndex = 0;
        $("#graphicsColumns0").show();
        $("#graphicsBeams")[0].selectedIndex = 0;
        $("#graphicsBeams0").show();
        $("#graphicsMP")[0].selectedIndex = 0;
        $("#graphicsMP0").show();
        $("#graphics")[0].selectedIndex = 0;
        $("#graphics0").show();
        $("#graphics00").show();

        //Disabled all Graphics
        var arrGraphicsR = ["arrGraphicsRBeam0", "arrGraphicsRBeam00", "arrGraphicsRBeam000", "arrGraphicsRBeam0000", "arrGraphicsRBeam1", "arrGraphicsRBeam11", "arrGraphicsRBeam111", "arrGraphicsRBeam1111", "arrGraphicsR2", "arrGraphicsRBeam22", "arrGraphicsRBeam222", "arrGraphicsRBeam2222", "arrGraphicsRBeam3", "arrGraphicsRBeam33", "arrGraphicsRBeam333", "arrGraphicsRBeam3333", "arrGraphicsRColumn1", "arrGraphicsRColumn11", "arrGraphicsRColumn111", "arrGraphicsRColumn1111", "arrGraphicsRColumn2", "arrGraphicsRColumn22", "arrGraphicsRColumn222", "arrGraphicsRColumn2222", "arrGraphicsRColumn3", "arrGraphicsRColumn33", "arrGraphicsRColumn333", "arrGraphicsRColumn3333", "arrGraphicsRColumn4", "arrGraphicsRColumn44", "arrGraphicsRColumn444", "arrGraphicsRColumn4444"];
        jQuery.each(arrGraphicsR, function (i, val) {
            $("#" + val).hide();
        });
        $("#graphicsR")[0].selectedIndex = 0;
        $("#graphicsRBeam0").show();
        $("#graphicsRBeam00").show();
        $("#graphicsRBeam000").show();
        $("#graphicsRBeam0000").show();


        /**
         * Show image change tab
         * Autor: OneClick
         * @param {tab}: Elemento select
         * @param {pictureName}: Tipo imagen
        */
        function a_onClick(tab, pictureName) {
            //Disabled all Graphics
            jQuery.each(arrPicture, function (i, val) {
                $("#" + val).hide();
            });
            $("#" + pictureName + tab).show();
        };

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
        };

        /**
         * Show and Hide Graphics Result
         * Autor: OneClick
         * @param {select}: Elemento select
         * @param {imgName}: Tipo imagen
        */
        function setImageGraphicsResult(select, imgName) {
            //Disabled all Graphics
            jQuery.each(arrGraphics, function (i, val) {
                $("#" + val).hide();
            });
            $("#" + imgName + select.selectedIndex).show();
            $("#" + imgName + select.selectedIndex + select.selectedIndex).show();

            jQuery.each(arrGraphicsR, function (i, val) {
                $("#" + val).hide();
            });
            $("#graphicsR")[0].selectedIndex = 0;
            $("#graphicsRBeam0").show();
            $("#graphicsRBeam00").show();
            $("#graphicsRBeam000").show();
            $("#graphicsRBeam0000").show();
        };

        /**
         * Show and Hide Graphics of Result
         * Autor: OneClick
         * @param {select}: Elemento select
         * @param {imgName}: Tipo imagen
        */
        function setImageResult(select, imgName) {
            //Disabled all Graphics
            var arrGraphicsR = ["arrGraphicsR0", "arrGraphicsR00", "arrGraphicsR000", "arrGraphicsR0000", "arrGraphicsR1", "arrGraphicsR11", "arrGraphicsR111", "arrGraphicsR1111", "arrGraphicsR2", "arrGraphicsR22", "arrGraphicsR222", "arrGraphicsR2222", "arrGraphicsR3", "arrGraphicsR33", "arrGraphicsR333", "arrGraphicsR3333", "arrGraphicsR4", "arrGraphicsR44", "arrGraphicsR444", "arrGraphicsR4444", "arrGraphicsR5", "arrGraphicsR55", "arrGraphicsR555", "arrGraphicsR5555", "arrGraphicsR6", "arrGraphicsR66", "arrGraphicsR666", "arrGraphicsR6666", "arrGraphicsR7", "arrGraphicsR77", "arrGraphicsR777", "arrGraphicsR7777"];
            jQuery.each(arrGraphicsR, function (i, val) {
                $("#" + val).hide();
            });

            if ($("#graphics").val() === "Beam") {
                $("#" + imgName + $("#graphics").val() + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex + select.selectedIndex + select.selectedIndex).show();
            }

            if ($("#graphics").val() === "Column") {
                $("#" + imgName + $("#graphics").val() + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex + select.selectedIndex).show();
                $("#" + imgName + $("#graphics").val() + select.selectedIndex + select.selectedIndex + select.selectedIndex + select.selectedIndex).show();
            }
        }

        document.getElementById("WebChartViewerPushover").style.width = "";
        document.getElementById("WebChartViewerPushover").style.height = "";
        document.getElementById("WebChar11").style.width = "";
        document.getElementById("WebChar11").style.height = "";
        document.getElementById("WebChart21").style.width = "";
        document.getElementById("WebChart21").style.height = "";
        document.getElementById("WebChart31").style.width = "";
        document.getElementById("WebChart31").style.height = "";
        document.getElementById("WebChart41").style.width = "";
        document.getElementById("WebChart41").style.height = "";
        document.getElementById("WebChart12").style.width = "";
        document.getElementById("WebChart12").style.height = "";
        document.getElementById("WebChart22").style.width = "";
        document.getElementById("WebChart22").style.height = "";
        document.getElementById("WebChart32").style.width = "";
        document.getElementById("WebChart32").style.height = "";
        document.getElementById("WebChart42").style.width = "";
        document.getElementById("WebChart42").style.height = "";
        document.getElementById("WebChart13").style.width = "";
        document.getElementById("WebChart13").style.height = "";
        document.getElementById("WebChart23").style.width = "";
        document.getElementById("WebChart23").style.height = "";
        document.getElementById("WebChart33").style.width = "";
        document.getElementById("WebChart33").style.height = "";
        document.getElementById("WebChart43").style.width = "";
        document.getElementById("WebChart43").style.height = "";
        document.getElementById("WebChart14").style.width = "";
        document.getElementById("WebChart14").style.height = "";
        document.getElementById("WebChart24").style.width = "";
        document.getElementById("WebChart24").style.height = "";
        document.getElementById("WebChart34").style.width = "";
        document.getElementById("WebChart34").style.height = "";
        document.getElementById("WebChart44").style.width = "";
        document.getElementById("WebChart44").style.height = "";
        document.getElementById("WebChartC11").style.width = "";
        document.getElementById("WebChartC11").style.height = "";
        document.getElementById("WebChartC21").style.width = "";
        document.getElementById("WebChartC21").style.height = "";
        document.getElementById("WebChartC31").style.width = "";
        document.getElementById("WebChartC31").style.height = "";
        document.getElementById("WebChartC41").style.width = "";
        document.getElementById("WebChartC41").style.height = "";
        document.getElementById("WebChartC12").style.width = "";
        document.getElementById("WebChartC12").style.height = "";
        document.getElementById("WebChartC22").style.width = "";
        document.getElementById("WebChartC22").style.height = "";
        document.getElementById("WebChartC32").style.width = "";
        document.getElementById("WebChartC32").style.height = "";
        document.getElementById("WebChartC42").style.width = "";
        document.getElementById("WebChartC42").style.height = "";
    </script>
    <!-- END JS PLUGIN -->
</body>
</html>

