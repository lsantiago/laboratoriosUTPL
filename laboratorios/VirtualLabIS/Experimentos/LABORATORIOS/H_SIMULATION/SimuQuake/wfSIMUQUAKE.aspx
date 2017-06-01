<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="wfSIMUQUAKE.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_wfSIMUQUAKE"%>

<%@ Register Assembly="ASPNetFlash" Namespace="ASPNetFlash" TagPrefix="ASPNetFlash" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>

<%--Tipos de Especimenes--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIMUQUAKE</title>
    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
    <script src="../../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>SIMUQUAKE</b></span>
                    <ol class="breadcrumb">
                        <li>ARTIFICIAL EARTHQUAKE GENERATION</li>
                    </ol>
                    <h5><b>Description:</b> Artificial Earthquake Generation</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Quinonez, S.; Duque, E.</h5>
                    <h5><b>Info:</b> SIMUQUAKE</h5>
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
                                                            <asp:LinkButton ID="ibtnLoadExample" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo" >
                                                                Load Sample
                                                                <i class="fa fa-play"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="FigMain" runat="server" ImageUrl="~/Imagenes/General/Tools/Dinamica_2GDL_Tool2.bmp" Width="290px" Height="220px" />
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
                                                            <asp:Label ID="lblTituloParamSimul" runat="server" Text="SIMULATED EARTHQUAKE PARAMETERS"></asp:Label></strong></a></li>
                                                    <li><a href="#test2" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblTituloTarget" runat="server" Text="TARGET SPECTRUM PARAMETERS"></asp:Label></strong></a></li>
                                                    <li><a href="#test3" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="Label1" runat="server" Text="MATCHING PERIOD RANGE"></asp:Label></strong></a></li>
                                                    <li><a href="#test4" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAnalisis" runat="server" Text="ANALISIS"></asp:Label></strong></a></li>
                                                </ul>
                                                <div class="tab-content" style="width: 100%; height: 250px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1">
                                                        <div class="col-md-7">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblNomSismo" runat="server" class="col-sm-8 control-label small label-one" Text="NUMBER OF EARTHQUAKES TO BE SIMULATED"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtNomSismo" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNumSimulaciones"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblNumSimulaciones" runat="server" class="col-sm-8 control-label small label-one" Text="NUMBER OF EARTHQUAKES TO BE SIMULATED"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtNumSimulaciones" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumSimulaciones"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblDuracion" runat="server" class="col-sm-8 control-label small label-one" Text="DURATION (s)"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtDuracion" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDuracion"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblTiempo1" runat="server" class="col-sm-8 control-label small label-one" Text="TIME 1 (s) FOR DEFINITION OF EARTHQUAKE ENVELOPE."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtTiempo1" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTiempo1"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblTiempo2" runat="server" class="col-sm-8 control-label small label-one" Text="TIME 2 (s) FOR DEFINITION OF EARTHQUAKE ENVELOPE."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtTiempo2" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTiempo2"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div id="chart-line" style="width: 100%; height: 100%;">
                                                                    <asp:Label ID="lblNomFig" runat="server" class="label-title-imge lead" Text="TARGET SPECTRUM PARAMETERS"></asp:Label>
                                                                <hr />
                                                                <asp:Image ID="imgFig1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/SIMUQUAKE/FigEarthquakeParameter-EN.gif" Width="290px" Height="190px" />
                                                            </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2">
                                                        <div class="col-md-7">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblFactorA" runat="server" class="col-sm-8 control-label small label-one" Text="FA FACTOR."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtFactorA" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFactorA"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblFactorV" runat="server" class="col-sm-8 control-label small label-one" Text="FV FACTOR."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtFactorV" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFactorV"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblAceleracionPerdCorto" runat="server" class="col-sm-8 control-label small label-one" Text="Ss SHORT PERIOD SPECTRAL ACCELERATION (M/S^2)."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtAceleracionPerdCorto" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAceleracionPerdCorto"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblAceleracionPerdPrim" runat="server" class="col-sm-8 control-label small label-one" Text="S1 ONE PERIOD SPECTRAL ACCELERATION (M/S^2)."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtAceleracionPerdPrim" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAceleracionPerdPrim"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblPeriodoEsquina" runat="server" class="col-sm-8 control-label small label-one" Text="CORNER PERIOD, TC (s)."></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtPeriodoEsquina" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPeriodoEsquina"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div id="chart-line" style="width: 100%; height: 100%;">
                                                                <asp:Label ID="lblNomFig2" runat="server" class="label-title-imge lead" Text="TARGET SPECTRUM PARAMETERS"></asp:Label>
                                                                <hr />
                                                                <asp:Image ID="imgFig2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/SIMUQUAKE/FigTargetSpectrumPar-EN.gif" Width="290px" Height="190px" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3">
                                                        <div class="col-md-8">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblPeriodoInicial" runat="server" class="col-sm-8 control-label small label-one" Text="MATCH FROM (s)"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtPeriodoInicial" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPeriodoInicial"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblPeriodoFinal" runat="server" class="col-sm-8 control-label small label-one" Text="MATCH TO (s)"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtPeriodoFinal" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPeriodoFinal"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblNumPuntEspectrales" runat="server" class="col-sm-8 control-label small label-one" Text="NUMBER OF SPECTRAL POINTS AT WHICH SPECTRUM IS MATCHED"></asp:Label>
                                                                    <div class="col-sm-3">
                                                                        <asp:TextBox ID="txtNumPuntEspectrales" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumPuntEspectrales"
                                                                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST4 FORM -->
                                                    <div class="tab-pane" id="test4">
                                                        <div class="col-md-2" style="padding-top: 50px;"></div>
                                                        <div class="col-md-7" style="padding-top: 50px;">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-12 text-center">
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
																			<ContentTemplate>
																				<div style="text-align: center">
																				    <div class="form-group">
																						<asp:Label ID="lblMensajes" runat="server" CssClass="Funcionalidad-Mensajes-Links" Font-Size="Small"></asp:Label>
																					</div>
																					<div class="form-group">
																						<asp:Image ID="imgIndicador" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/ajax-loader.gif" Visible="False" />
																					</div>
																					<div class="form-group">
																						<asp:Timer ID="timeSimular" runat="server" Enabled="False"  Interval="5000" OnTick="timeSimular_Tick"></asp:Timer>
																					</div>
																				</div>
																			</ContentTemplate>
																		</asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2"></label>
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="cmdSimular" runat="server" class="btn btn-warning btn-radius" >
                                                                            GENERATE
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2"></label>
                                                                    <asp:HiddenField ID="hiddIndicador" runat="server" />
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
                                        <h4 class="panel-title text-center">OUTPUTS</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">		
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
