<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="wfAnalisisEspectral.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_Columna_wfAnalisisEspectral" %>


<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>


<%--Referencias a controles de Tipos de Exitacion--%>
<%@ Reference Control="Modulos/ctrlAcelerograma.ascx" %>
<%@ Reference Control="Modulos/ctrlCargaSinusoidal.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SPECTRUM</title>
    <%-- <script src="../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>--%>

    <webopt:BundleReference runat="server" Path="~/Content/assets/css" />
</head>
<body>
    <form id="frmMain" runat="server">
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <!-- BEGIN MAIN CONTENT -->
            <aside class="right-side">

                <!-- BEGIN CONTENT HEADER -->
                <div style="padding-left: 28px; background-color: #ffffff;">
                    <img src="../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>SPECTRUM</b></span>
                    <ol class="breadcrumb">
                        <li>SPECTRAL ANALYSIS OF EARTHQUAKE RECORDS AND HARMONIC FUNCTIONS</li>
                    </ol>
                    <h5><b>Description:</b> Spectral analysis of earthquake records and harmonic functions</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Quinonez, S.</h5>
                    <h5><b>Info:</b> Spectrum</h5>
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
                                            <div class="col-md-4" style="border-right: 1.0pt solid #dddddd;">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblTituloEsquemaColumna" runat="server" class="grid-title lead" Text="ESQUEMA"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center" style="width: 100%; height: 256px;">
                                                        <div style="width: 355px; height: 229px;">
                                                            <asp:Image ID="img1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/EN/1_EN.jpg" Width="100%" Height="100%" />
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
                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="PARAMETERS"></asp:Label></strong></a></li>
                                                    <li><a href="#test2" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblTituloMaterialProper" runat="server" Text="TIPO DE EXITACIÓN"></asp:Label></strong></a></li>
                                                    <li><a href="#test3" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAnalisis" runat="server" Text="ANALYSIS"></asp:Label></strong></a></li>
                                                </ul>
                                                <div class="tab-content" style="width: 100%; height: 256px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1" style="padding-top: 15px;">
                                                        <div class="col-md-8">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-sm-4" style="padding-left: 5px;">
                                                                        <label>
                                                                            <asp:RadioButton ID="rbAnalisisElastico" runat="server"  AutoPostBack="True" Checked="True" GroupName="gTipoAnalisis" />
                                                                            <asp:Label ID="lblAElastico" runat="server" Text="ANALISIS ELASTICO" class="label-radioButton"></asp:Label></label>
                                                                    </div>
                                                                    <div class="col-sm-1"></div>
                                                                    <div class="col-sm-5" style="padding-left: 35px;">
                                                                        <label>
                                                                            <asp:RadioButton ID="rbAnalisisInelastico" runat="server" GroupName="gTipoAnalisis"  AutoPostBack="True" />
                                                                            <asp:Label ID="lblAInelastico" runat="server" Text="ANALISIS INELASTICO" class="label-radioButton"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbPeriodo1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 label-der">
                                                                            <asp:Label ID="lblPeriodo1" runat="server" class="control-label small" Text="PERIODO 1(s)"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPeriodo1"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbPeriodo2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblPeriodo2" runat="server" class="control-label small" Text="PERIODO 2 (s)"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPeriodo2"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbNumPuntos" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblNumPuntos" runat="server" class="control-label small" Text="NÚMERO DE PUNTOS"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNumPuntos"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbMasa" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblMasa" runat="server" class="control-label small" Text="MASA (tonne)"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbMasa"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbDamping1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblDamping1" runat="server" class="control-label small" Text="DAMPING 1 %"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbDamping1"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbDamping2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblDamping2" runat="server" class="control-label small" Text="DAMPING 2 %"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbDamping2"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4 small">
                                                                            <asp:TextBox ID="tbNumCurvas" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblNumCurvas" runat="server" class="control-label small" Text="NÚMERO DE CURVAS"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbNumCurvas"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbDamping3" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblDamping3" runat="server" class="control-label small" Text="DAMPING %"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbDamping3"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbR1" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblR1" runat="server" class="control-label small" Text="R1"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbR1"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbR2" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblR2" runat="server" class="control-label small" Text="R2"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbR2"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbCoefRigidez" runat="server" class="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblCoefRigidez" runat="server" class="control-label small" Text="COEFICIENTE DE RIGIDEZ POST FLUENCIA"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbCoefRigidez"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <div class="col-sm-4">
                                                                            <asp:TextBox ID="tbNumCurvas2" runat="server" class="form-control small"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-8 small label-der">
                                                                            <asp:Label ID="lblNumCurvas2" runat="server" class="control-label small" Text="NUMERO DE CURVAS"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbNumCurvas2"
                                                                                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Label ID="lblTituloEsquemaColumna123" runat="server" class="label-title-imge lead" Text="SECTION"></asp:Label>
                                                            <hr />
                                                            <div style="width: 245px; height: 191px;">
                                                                <asp:Image ID="img2" runat="server" ImageUrl="~/VirtualLabis/Varios/Archivos/Imagenes/Dinamica/ES/6_ES.jpg" width="100%" height="100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2" style="padding-top: 15px;">
                                                        <div class="col-md-7">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-6">
                                                                        <label>
                                                                            <asp:RadioButton ID="rbCargaSinusoidal" runat="server"  AutoPostBack="True" Checked="True" GroupName="gTipoAnalisis" />
                                                                            <asp:Label ID="lblCargaSinusoidal" runat="server" Text="FUNCION DE CARGA SINUSOIDAL" class="label-radioButton"></asp:Label></label>
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <label>
                                                                            <asp:RadioButton ID="rbAcelerograma" runat="server" GroupName="gTipoAnalisis"  AutoPostBack="True" />
                                                                            <asp:Label ID="lblAcelerograma" runat="server" Text="ACELEROGRAMA" class="label-radioButton"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:Label ID="lblEsqTE" runat="server" class="label-title-imge lead" Text="OUTLINE"></asp:Label>
                                                            <hr />
                                                            <div style="width: 0px; height: 0px;">
                                                                <asp:Image ID="img3" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/ES/7_ES.jpg" Width="100%" Height="100%" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <asp:PlaceHolder ID="phTipoExitacion" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST2 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3">
                                                        <div class="col-md-3" style="padding-top: 90px;"></div>
                                                        <div class="col-md-7" style="padding-top: 90px;">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST3 FORM -->
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
                                        <h4 class="panel-title text-center">OUTPUT</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <!-- BEGIN SECTION GRAPHICS -->
                                            <div class="col-md-12 text-center">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblGraficas" runat="server" class="grid-title lead" Text="GRAPHICS"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <div class="col-sm-2"></div>
                                                                <asp:Label ID="Label14" runat="server" class="col-sm-3 control-label label-one" Text="Select:"></asp:Label>
                                                                <div class="col-sm-3">
                                                                    <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                        <option>Acceleration Spectra</option>
                                                                        <option>Velocity Spectra</option>
                                                                        <option>Displacement Spectra</option>
                                                                        <option>Ductility Spectra</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-sm-12 text-center" style="padding-top: 10px;">
                                                                    <div id="graphics0" style="width: 100%; height: 100%;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="WebChartViewer1" runat="server" Style="position: static"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnGetResult1" runat="server" class="btn btn-warning">
                                                                                <i class="fa fa-download"></i>
                                                                                Download answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics1" style="width: 100%; height: 100%;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="WebChartViewer2" runat="server" Style="position: static"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnGetResult2" runat="server" class="btn btn-warning">
                                                                                <i class="fa fa-download"></i>
                                                                                Download answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics2" style="width: 100%; height: 100%;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="WebChartViewer3" runat="server" Style="position: static"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnGetResult3" runat="server" class="btn btn-warning">
                                                                                <i class="fa fa-download"></i>
                                                                                Download answers
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        
                                                                    </div>
                                                                    <div id="graphics3" style="width: 100%; height: 100%;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:WebChartViewer ID="WebChartViewer4" runat="server" Style="position: static"></chart:WebChartViewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:LinkButton ID="btnGetResult4" runat="server" class="btn btn-warning">
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
        var arrGraphics = ["graphics0", "graphics1", "graphics2", "graphics3"];
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
