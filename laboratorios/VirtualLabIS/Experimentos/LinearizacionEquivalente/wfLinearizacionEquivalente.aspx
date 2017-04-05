<%@ Page Language="VB" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="wfLinearizacionEquivalente.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_LinearizacionEquivalente_wfLinearizacionEquivalente"%>

<%@ Register Src="Modulos/ctrlAcelerograma.ascx" TagName="ctrlAcelerograma" TagPrefix="uc1" %>
<%@ Register Src="Modulos/ctrlAcelerograma.ascx" TagName="ctrlAcelerograma" TagPrefix="uc2" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>



<%--<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<%@ Register Src="~/VirtualLabIS/Experimentos/LinearizacionEquivalente/Modulos/ctrlAcelerograma.ascx" TagPrefix="uc2" TagName="ctrlAcelerograma" %>--%>



<%--Referencias a controles de Tipos de Exitacion--%>
<%@ Reference Control="Modulos/ctrlAcelerograma.ascx" %>



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
                    <img src="../../../Content/Images/Portal/barraPosicion.jpg" />
                </div>
                <section class="content-header">
                    <i class="fa fa-align-left"></i>
                    <span><b>LINEARIZATION</b></span>
                    <ol class="breadcrumb">
                        <li>STUDY OF LINEARIZATION METHODS FOR SEISMIC DESIGN</li>
                    </ol>
                    <h5><b>Description:</b> Study of Linearization Methods for Seismic Design</h5>
                    <h5><b>Authors:</b> Suarez, V.A.; Quinonez, S.</h5>
                    <h5><b>Info:</b>Linearization</h5>
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
                                                        <asp:Label ID="lblTituloEsquemaColumna" runat="server" class="grid-title lead" Text="SECTION"></asp:Label>
                                                        <div class="pull-right grid-tools">
                                                            <%--<asp:LinkButton ID="ibtnLoadExample" runat="server" class="btn btn-warning btn-radius btn-xs button-Carga-Ejemplo" OnClick="btnDownResul1_Click">
                                                                            Cargar Ejemplo
                                                                            <i class="fa fa-play"></i>
                                                            </asp:LinkButton>--%>
                                                        </div>
                                                    </div>
                                                    <div class="grid-body text-center">
                                                        <div id="chart-line" style="width: 100%; height: 100%;">
                                                            <asp:Image ID="img1" runat="server" ImageUrl="~/VirtualLab/Varios/Archivos/Imagenes/Dinamica/ES/1_ES.jpg" Width="290px" Height="220px" />
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
                                                            <asp:Label ID="lblTituloSeccionProper" runat="server" Text="PARAMETROS"></asp:Label></strong></a></li>
                                                    <li><a href="#test2" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAcelerograma" runat="server" Text="ACCELERATION RECORD"></asp:Label></strong></a></li>
                                                    <li><a href="#test3" data-toggle="tab">
                                                        <strong>
                                                            <asp:Label ID="lblAnalisis" runat="server" Text="ANALISIS"></asp:Label></strong></a></li>
                                                </ul>
                                                <div class="tab-content" style="width: 100%; height: 250px;">
                                                    <!-- BEGIN TEST1 FORM -->
                                                    <div class="tab-pane active" id="test1">
                                                        <div class="col-md-1"></div>
                                                        <div class="col-md-11">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtPeriodo" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 label-der">
                                                                        <asp:Label ID="lblPeriodo" runat="server" class="control-label small" Text="PERIODO T(s)"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rfvPeriodo" runat="server" ControlToValidate="txtPeriodo"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtCoefRigPFluen" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-5 label-der">
                                                                        <asp:Label ID="lblAcelInicial" runat="server" class="control-label small" Text="MASS PROPORTIONAL DAMPING ξ(%)"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rfvAcelInicial" runat="server" ControlToValidate="txtCoefRigPFluen"
                                                                                                ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtMasa" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 label-der">
                                                                        <asp:Label ID="lblMasa" runat="server" class="control-label small" Text="MASA M(tonne)"></asp:Label>
                                                                       <asp:RequiredFieldValidator ID="rfvMasa" runat="server" ControlToValidate="txtMasa"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtMasaProporcional" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-5 label-der">
                                                                        <asp:Label ID="lblMasaProporcional" runat="server" class="control-label small" Text="AMORTIGUAMIENTO PROPORCIONAL A LA MASA ξ(%)"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rfvMasaProporcional" runat="server" ControlToValidate="txtMasaProporcional"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="txtFuerzaFluecia" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 label-der">
                                                                        <asp:Label ID="lblFuerzaFluecia" runat="server" class="control-label small" Text="FUERZA DE FLUENCIA Fy(kN)"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rfvFuerzaFluecia" runat="server" ControlToValidate="txtFuerzaFluecia"
                                                                                                    ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <asp:TextBox ID="tbDuctilidad" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-5 label-der">
                                                                        <asp:Label ID="lblDuctilidad" runat="server" class="control-label small" Text="AMORTIGUAMIENTO PROPORCIONAL A LA MASA ξ(%)"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="rfvDuctilidad" runat="server" ControlToValidate="tbDuctilidad"
                                                                                                ErrorMessage="*" Style="position: static">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- END TEST1 FORM -->

                                                    <!-- BEGIN TEST2 FORM -->
                                                    <div class="tab-pane" id="test2">
                                                        <uc1:ctrlAcelerograma ID="CtrlAcelerograma1" runat="server" />
                                                    </div>
                                                    <!-- END TEST3 FORM -->

                                                    <!-- BEGIN TEST3 FORM -->
                                                    <div class="tab-pane" id="test3" style="padding-top: 15px;">
                                                        <div class="col-md-2" style="padding-top: 50px;"></div>
                                                        <div class="col-md-7" style="padding-top: 50px;">
                                                            <div class="form-horizontal" role="form">
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="btnGraficar" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="btnBorrarUltimoTest" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-4 text-right">
                                                                        <asp:LinkButton ID="btnBorrarTodosTests" runat="server" class="btn btn-warning btn-radius">
                                                                            <i class="fa fa-play"></i>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-sm-12">
                                                                        <asp:Label ID="lblResultados" runat="server" CssClass="Funcionalidad-subtitulo" class="control-label" Text="RESULTADOS" Visible="False"></asp:Label>
                                                                    </div>
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
                                            <!-- BEGIN SECTION GRAPHICS -->
                                            <div class="col-md-12 text-center">
                                                <div class="grid">
                                                    <div class="grid-header">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <asp:Label ID="lblGraficas" runat="server" class="grid-title lead" Text="GRAFICAS"></asp:Label>
                                                        <div class="pull-right grid-tools"></div>
                                                    </div>
                                                    <div class="grid-body">
                                                        <div class="form-horizontal" role="form">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label14" runat="server" class="col-sm-3 control-label label-one" Text="Seleccionar:"></asp:Label>
                                                                <div class="col-sm-7">
                                                                    <select id="graphics" class="form-control" onchange="setImageGraphics(this, 'graphics');">
                                                                        <option>Strength reduction factor vs. ductility</option>
                                                                        <option>Displacement coefficient vs. ductility</option>
                                                                        <option>Equivalent viscous damping vs. ductility</option>
                                                                        <option>Period lengthening vs. ductility</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="col-md-12 text-center">
                                                                    <div id="graphics0" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:webchartviewer id="WebChartViewer1" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnGetResult1" runat="server" class="btn btn-warning">
                                                                                    <i class="fa fa-download"></i>
                                                                            </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics1" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:webchartviewer id="WebChartViewer2" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnGetResult2" runat="server" class="btn btn-warning">
                                                                                    <i class="fa fa-download"></i>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics2" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:webchartviewer id="WebChartViewer3" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnGetResult3" runat="server" class="btn btn-warning">
                                                                                    <i class="fa fa-download"></i>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div id="graphics3" style="width: 100%; height: 100%; padding-top: 10px;">
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <chart:webchartviewer id="WebChartViewer4" runat="server" style="position: static" BorderColor="White" SelectionBorderColor="Transparent"></chart:webchartviewer>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-sm-12 text-center">
                                                                                <asp:LinkButton ID="btnGetResult4" runat="server" class="btn btn-warning">
                                                                                    <i class="fa fa-download"></i>
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