﻿Imports System.IO
Imports Microsoft.VisualBasic.OpenAccess
Imports System.Math
Imports ChartDirector
Imports VirtualLabIS.DTO
Imports VirtualLabIS.Facade
Imports System.Data
Imports System.Threading

Imports DotNetNuke.Entities.Tabs
Imports DotNetNuke.Security.Permissions
Imports DotNetNuke.UI.Skins
Imports DotNetNuke.UI.Utilities

'Imports VLEE_AMC150


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_DesignColumnCir_wfmCirCol
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}
        Dim arrTextoEjes(,) As String = {{"MOMENTO (kN-m)", _
                                          "CURVATURA (1/m)"}, _
                                        {"MOMENT(kN-m)", _
                                         "CURVATURE (1/m)"}}
        Dim arrTextoResultados(,) As String = {{"RC-Diseño", _
                                           "Análisis Momento Curvatura Secciones de Concreto Reforzado", _
                                           "Autor: Vinicio Suarez, vasuarez@utpl.edu.ec", _
                                           "RESULTADOS DEL ANÁLISIS", _
                                           "PROPIEDADES DE LOS MATERIALES", _
                                           "Módulo de Elasticidad del Concreto", _
                                           "Resistencia a la compresión del Concreto", _
                                           "Deformación en la Resistencia a la Compresión del Concreto no Confinado", _
                                           "Deformación última del concreto no confinado (agrietamiento)", _
                                           "Resistencia del concreto confinado  (Modelo de Mander)", _
                                           "Deformación en la Resistnecia a la Compresión del Concreto Confinado(Modelo de Mander)", _
                                           "Deformación última del concreto confinado (Modelo de Mander)", _
                                           "Módulo Elástico del Acero", _
                                           "Esfuerzo de Fluencia del Acero Longitudinal", _
                                           "Deformación de Fluencia del Acero Longitudinal", _
                                           "Deformación al comienzo del endurecimiento de deformación", _
                                           "Resistencia máxima del refuerzo longitudinal", _
                                           "Deformación en la resistencia máxima del acero de refuerzo", _
                                           "Esfuerzo de fluencia del acero transversal", _
                                           "Deformación última del refuerzo transversal", _
                                           "PROPIEDADES DE LA SECCIÓN", _
                                           "Cuantía de acero longitudinal", _
                                           "Cuantía de acero transversal", _
                                           "Relación de Carga Axial", _
                                           "Momento de Inercia (tomado de la pendiente del diagrama M-C bilineal)", _
                                           "Momento en la primera fluencia", _
                                           "Curvatura en la primera fluencia", _
                                           "Resistencia de Momento Nominal", _
                                           "Curvatura Nominal de Fluencia", _
                                           "Deformación del Concreto en la Resistencia de Momento Nominal", _
                                           "Momento de Control de Daño", _
                                           "Curvatura de Control de Daño", _
                                           "Coeficiente de Rigidez flexural Pos Fluencia", _
                                           "RESULTADOS DEL ANÁLISIS MOMENTO CURVATURA", _
                                           """c"" es la profundidad del eje neutro", _
                                           """ec"" es la deformación del concreto", _
                                           """es"" es la deformación del acero", _
                                           """Mv"" es la demanda de momento para desarrollar resistencia al corte calculada  con el modelo UCSD modificado", _
                                           "Curvatura(1/m)	Momento (kN.m)	c (m)		ec		es		Mv(kN-m) ", _
                                           "Resultados del Análisis Momento Curvatura "}, _
                                       {"RC-Diseño", _
                                           "Moment Curvature Analysis of Reinforced Concrete Sections", _
                                           "Author: Vinicio Suarez, vasuarez@utpl.edu.ec", _
                                           "ANALYSIS OUTPUT", _
                                           "MATERIAL PROPERTIES", _
                                           "Elastic Modulus of Concrete", _
                                           "Unconfined concrete strength", _
                                           "Strain at unconfined concrete strength", _
                                           "Ultimate unconfined strain (spalling)", _
                                           "Confined concrete strength  (Mander’s model)", _
                                           "Strain at confined concrete strength (Mander’s model)", _
                                           "Ultimate confined strain (Mander’s model)", _
                                           "Elastic Modulus of Steel", _
                                           "Yield strength of longitudinal reinforcement", _
                                           "Yield strain of longitudinal reinforcement", _
                                           "Strain at beginning of strain hardening ", _
                                           "Max strength of longitudinal reinforcement steel", _
                                           "Strain at maximum strength of reinforcement steel", _
                                           "Yield strength of transverse reinforcement", _
                                           "Ultimate strain of transverse reinforcement", _
                                           "SECTION PROPERTIES", _
                                           "Longitudinal steel ratio", _
                                           "Transverse steel ratio", _
                                           "Axial Load Ratio", _
                                           "Moment of Inertia (taken from the slope of the bi-linear M-C diagram)", _
                                           "Moment at first yield", _
                                           "Curvature at first yield", _
                                           "Nominal moment strength", _
                                           "Nominal yield curvature", _
                                           "Concrete strain at nominal moment strength", _
                                           "Damage control moment", _
                                           "Damage control curvature", _
                                           "Post yield flexural stiffness coefficient", _
                                           "MOMENT CURVATURE ANALYSIS OUTPUT", _
                                           """c"" is the neutral axis depth", _
                                           """ec"" is the concrete strain", _
                                           """es"" is the steel strain", _
                                           """Mv"" is the moment demand to develop shear strength computed with the modified UCSD model", _
                                           "Curvature(1/m)	Moment (kN.m)	c (m)		ec		es		Mv(kN-m)", _
                                           "Moment Curvature Analysis Results"}}
        Dim arrTextoResultadosDesign(,) As String = {{"RC-Diseño: Software para el Diseño de Secciones de Concreto Reforzado", _
                                           "Autor: Vinicio Suarez, vasuarez@utpl.edu.ec", _
                                           "DISEÑO DE Columnas Circulares", _
                                           "Factor de Reducción de Resistencia por Flexión", _
                                           "Factor de Reducción de Resistencia por Corte", _
                                           "Demanda de Cortante Último Basado en el Momento de Sobre-Resistencia (Se usa un factor de sobre-resistencia de 1.25)", _
                                           "Contribución del Concreto en la Resistencia a Corte", _
                                           "Contribución del Refuerzo en la Resistencia a Corte", _
                                           "Diámetro de los Estribos", _
                                           "Deformación de Diseño del Concreto", _
                                           "Deformación Máxima de Tensión ", _
                                           "Profundidad del Eje Neutro ", _
                                           "Diámetro Requerido para el Refuerzo Longitudinal"}, _
                                       {"RC-Design: Software for design of reinforce concrete sections", _
                                           "Author: Vinicio Suarez, vasuarez@utpl.edu.ec", _
                                           "CIRCULAR COLUMN DESIGN", _
                                           "Strength reduction factor for flexure", _
                                           "Strength reduction factor for shear", _
                                           "Ultimate shear demand based on moment over-strength (an over-strength factor of 1.25 is used)", _
                                           "Concrete contribution to shear resistance", _
                                           "Reinforcement contribution to shear resistance", _
                                           "Diameter of stirrup bar", _
                                           "Concrete design strain", _
                                           "Maximum tensile strain", _
                                           "Neutral axis depth ", _
                                           "Requiered diameter of longitudinal reinforcemen"}}
#End Region

#Region "Variables Globales"
        'Private Shared objVLEE_AMC As VLEE_AMC150.VLEE_AMC150_CMain
        Private Shared objVLEE_AMC As MomentoCurvatura = New MomentoCurvatura
        Private objConstDTO As [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
        Private dtColumna As DTO.dsColumna.COLUMNADataTable
        Private drColumna As DTO.dsColumna.COLUMNARow
        Dim numLinea As Integer
        Dim legendBox As LegendBox
        Dim intNumeroIteracionesAMC As Integer
        Public intExpColumna_Id As Integer = 0
        ' Create a XYChart object of size 450 x 450 pixels
        Dim intAnchoGraficas As Integer = 546
        Dim intAltoGraficas As Integer = 226
        Dim intColorFondo As Integer = &HFFFFFF
        Dim XYChart_Grafica_MomentoCurvatura As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        'Dim XYChart2_Grafica2_MomentoNegativo As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas - 90, intColorFondo, intColorFondo, 0) 'XYChart para el gráfico del momento negativo  


        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Dim intAddLegend_Coord_x As Integer = 315
        Dim intAddLegend_Coord_y As Integer = 5
        Dim bolAddLegend_Bool As Boolean = False
        Dim strAddLegend_Font As String = "Arial Rounded MT Bold"
        Dim intAddLegend_FontSize As Integer = 8
        Shared getIdioma As String
        Dim materialpropertiesR(30, 10) As Object
        Dim sectionpropertiesR(30, 10) As Object
        Dim MCcurvesR(10, 100, 10) As Object
        Dim file_in(10) As Object
        Dim designresultR(30) As Object
        Dim graficaMC(50, 2) As Single
        Dim matriz1(50, 6) As Double
        Dim matriz2(50, 6) As Double
        Shared arrayDatosGraficaEstimCurvaturaFluenciaX As Double()
        Shared arrayDatosGraficaEstimCurvaturaFluenciaY As Double()

        Shared idIdioma As Integer
#End Region
#Region "Configuracion de gráficos"
        ''' <summary>
        ''' Método generico para Crear WebChartView parametrizados. 
        ''' </summary>
        ''' <param name="setPlotArea_x">Coordenada a la izquierda del área interna del gráfico</param>
        ''' <param name="setPlotArea_y">Coordenada de la parte superior del área interna del gráfico</param>
        ''' <param name="setPlotArea_width">Ancho del área interna del gráfico</param>
        ''' <param name="setPlotArea_height">Alto del área interna del gráfico</param>
        ''' <param name="setPlotArea_bgColor">Color de fondo del área interna del gráfico</param>
        ''' <param name="setPlotArea_altBgColor">Segundo color de fondo del área interna del gráfico</param>
        ''' <param name="setPlotArea_edgeColor">Color del borde del área interna del gráfico</param>
        ''' <param name="setPlotArea_hGridColor">Color del Grid horizontal</param>
        ''' <param name="setPlotArea_vGridColor">color del Grid Vertical</param>
        ''' <param name="addTitle_text">Titulo del Gráfico</param>
        ''' <param name="addTitle_font">Tipo de letra del Titulo del Gráfic</param>
        ''' <param name="addTitle_fontSize">Tamaño del titulo del Gráfico</param>
        ''' <param name="addTitle_fontColor">Color del titulo del Gráfico</param>
        ''' <param name="addTitle_bgColor">Color de fondo del titulo del Gráfico</param>
        ''' <param name="addTitle_edgeColor">Segundo color de fondo del titulo del Gráfico</param>
        ''' <param name="yAxis_setTitle_text">Texto para el rotulo del Eje de las Y</param>
        ''' <param name="yAxis_setTitle_font">Tipo de letra del Eje de las Y</param>
        ''' <param name="yAxis_setTitle_fontSize">Tamaño de letra del Eje de las Y</param>
        ''' <param name="yAxis_setTitle_fontColor">Color de fondo del Eje de las Y</param>
        ''' <param name="yAxis_setWidth_width">Ancho de las lineas del Eje de las Y</param>
        ''' <param name="xAxis_setTitle_text">Texto para el rotulo del Eje de las X</param>
        ''' <param name="xAxis_setTitle_font">Tipo de letra del Eje de las X</param>
        ''' <param name="xAxis_setTitle_fontSize">Tamaño de letra del Eje de las X</param>
        ''' <param name="xAxis_setTitle_fontColor">Color de fondo del Eje de las X</param>
        ''' <param name="xAxis_setWidth_width">Ancho de las lineas del Eje de las X</param>
        ''' <param name="grfGrafica">Variable de Tipo ChartDirector.XYChart el cual contendra el gráfico</param>
        ''' <remarks></remarks>
        Private Sub CrearGraficasXYChart(ByVal setPlotArea_x As Integer, ByVal setPlotArea_y As Integer, _
                                    ByVal setPlotArea_width As Integer, ByVal setPlotArea_height As Integer, _
                                    ByVal setPlotArea_bgColor As Integer, ByVal setPlotArea_altBgColor As Integer, _
                                    ByVal setPlotArea_edgeColor As Integer, ByVal setPlotArea_hGridColor As Integer, _
                                    ByVal setPlotArea_vGridColor As Integer, _
                                    ByVal addTitle_text As String, ByVal addTitle_font As String, _
                                    ByVal addTitle_fontSize As Double, ByVal addTitle_fontColor As Integer, _
                                    ByVal addTitle_bgColor As Integer, ByVal addTitle_edgeColor As Integer, _
                                    ByVal yAxis_setTitle_text As String, ByVal yAxis_setTitle_font As String, _
                                    ByVal yAxis_setTitle_fontSize As Double, ByVal yAxis_setTitle_fontColor As Integer, _
                                    ByVal yAxis_setWidth_width As Integer, _
                                    ByVal xAxis_setTitle_text As String, ByVal xAxis_setTitle_font As String, _
                                    ByVal xAxis_setTitle_fontSize As Double, ByVal xAxis_setTitle_fontColor As Integer, _
                                    ByVal xAxis_setWidth_width As Integer, _
                                    ByRef grfGrafica As XYChart)

            'grfGrafica.setRoundedFrame(222, 0, 0, 0, 0)
            grfGrafica.setPlotArea(setPlotArea_x, setPlotArea_y, setPlotArea_width, setPlotArea_height, setPlotArea_bgColor, setPlotArea_altBgColor, setPlotArea_edgeColor, setPlotArea_hGridColor, setPlotArea_vGridColor)
            grfGrafica.addTitle(addTitle_text, addTitle_font, addTitle_fontSize)
            grfGrafica.yAxis().setTitle(yAxis_setTitle_text, yAxis_setTitle_font, yAxis_setTitle_fontSize)
            grfGrafica.yAxis().setWidth(yAxis_setWidth_width)
            grfGrafica.xAxis().setTitle(xAxis_setTitle_text, xAxis_setTitle_font, xAxis_setTitle_fontSize)
            grfGrafica.xAxis().setWidth(xAxis_setWidth_width)

        End Sub

        ''' <summary>
        ''' Agrega los controles Gráficos a la Página Web.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCrearWebChartViewer()
            WebChartViewer1.Image = XYChart_Grafica_MomentoCurvatura.makeWebImage(Chart.PNG)
            'WebChartViewer2.Image = XYChart2_Grafica2_MomentoNegativo.makeWebImage(Chart.PNG)
        End Sub

        ''' <summary>
        ''' Crear los controles gráficos WebChartView, parametrizando los titulos, tamaño, etc.
        ''' Las Graficas son siete, ellas son:
        ''' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub establecerPropCtrlGraficos()
            ' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA(POSITIVO)"
            CrearGraficasXYChart(60, 5, 260, 180, &HFFFFFF, -1, -1, &HFFFFFF, &HFFFFFF, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 0), "Arial", 10, 0, 1, arrTextoEjes(idIdioma, 1), "Arial", 10, 0, 1, XYChart_Grafica_MomentoCurvatura)
            legendBox = XYChart_Grafica_MomentoCurvatura.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent)
        End Sub


#End Region

        ''' <summary>
        ''' Este procedimiento establece el idioma de la pagina Los posibles valores que se 
        ''' pueden setear para el idioma son: es-ES y en
        ''' Metodo compatible "Protected Overrides Sub InitializeCulture()"
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub InitializeCulture()
            'Asignación del idioma del experimento
            getIdioma = Request.Params("idioma")
            'Establece el idioma en los controles de los experimentos
            If getIdioma = "es-ES" Then
                idIdioma = 0
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-ES")
            Else
                idIdioma = 1
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
                Exit Sub
            End If
        End Sub

        ''' <summary>
        ''' Asigna el texto a los controles de la pagina de acuerdo al idioma en el que se cargue.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarIdiomaACtrls()
            'INPUT DATA

            lblTransRR.Text = GetLocalResourceObject("lblTransRR.Text").ToString()
            lblTransFy.Text = GetLocalResourceObject("lblTransFy.Text").ToString()
            lblTituloSeccionProper.Text = GetLocalResourceObject("lblTituloSeccionProper.Text").ToString()
            lblTituloMaterialProper.Text = GetLocalResourceObject("lblTituloMaterialProper.Text").ToString()
            'lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            lblTituloEsquemaColumna.Text = GetLocalResourceObject("lblTituloEsquemaColumna.Text").ToString()
            lblTituloAnalysisIndex.Text = GetLocalResourceObject("lblTituloAnalysisIndex.Text").ToString()
            'lblTitle.Text = GetLocalResourceObject("lblTitle.Text").ToString()
            'lblSteelModel.Text = GetLocalResourceObject("lblSteelModel.Text").ToString()
            lblSpacingStirrups.Text = GetLocalResourceObject("lblSpacingStirrups.Text").ToString()
            lblSlopeRatio.Text = GetLocalResourceObject("lblSlopeRatio.Text").ToString()
            lblShearSpan.Text = GetLocalResourceObject("lblShearSpan.Text").ToString()
            lblPrimeraCurvaturaFluencia.Text = GetLocalResourceObject("lblPrimeraCurvaturaFluencia.Text").ToString()
            'lblMomentResponse.Text = GetLocalResourceObject("lblMomentResponse.Text").ToString()
            lblMomentoPrimeraFluencia.Text = GetLocalResourceObject("lblMomentoPrimeraFluencia.Text").ToString()
            lblMomentoNominal.Text = GetLocalResourceObject("lblMomentoNominal.Text").ToString()
            lblMoment.Text = GetLocalResourceObject("lblMoment.Text").ToString()
            'lblMCResults.Text = GetLocalResourceObject("lblMCResults.Text").ToString()
            lblMCResponse.Text = GetLocalResourceObject("lblMCResponse.Text").ToString()
            lblLongRR.Text = GetLocalResourceObject("lblLongRR.Text").ToString()
            lblLongFy.Text = GetLocalResourceObject("lblLongFy.Text").ToString()
            lblIncerciaAgrietada.Text = GetLocalResourceObject("lblIncerciaAgrietada.Text").ToString()
            lblDiameterStirrup.Text = GetLocalResourceObject("lblDiameterStirrup.Text").ToString()
            lblDiameterLongitudinal.Text = GetLocalResourceObject("lblDiameterLongitudinal.Text").ToString()
            lblDesignResults.Text = GetLocalResourceObject("lblDesignResults.Text").ToString()
            lblDesignForces.Text = GetLocalResourceObject("lblDesignForces.Text").ToString()
            lbldefConc.Text = GetLocalResourceObject("lbldefConc.Text").ToString()
            lblDamConMom.Text = GetLocalResourceObject("lblDamConMom.Text").ToString()
            lblDamageControl.Text = GetLocalResourceObject("lblDamageControl.Text").ToString()
            lblCurvaturaFluencia.Text = GetLocalResourceObject("lblCurvaturaFluencia.Text").ToString()
            lblCoverLateral.Text = GetLocalResourceObject("lblCoverLateral.Text").ToString()
            'lblConcreteModel.Text = GetLocalResourceObject("lblConcreteModel.Text").ToString()
            lblConcrComprStrength.Text = GetLocalResourceObject("lblConcrComprStrength.Text").ToString()
            lblbase.Text = GetLocalResourceObject("lblbase.Text").ToString()
            lblAxialLoadRatio.Text = GetLocalResourceObject("lblAxialLoadRatio.Text").ToString()
            lblAxialLoad.Text = GetLocalResourceObject("lblAxialLoad.Text").ToString()
            lblAnalysisResults.Text = GetLocalResourceObject("lblAnalysisResults.Text").ToString()
            lblAnalysisResult.Text = GetLocalResourceObject("lblAnalysisResult.Text").ToString()
            lblAnalysisIndexes.Text = GetLocalResourceObject("lblAnalysisIndexes.Text").ToString()
            lblAnalysis.Text = GetLocalResourceObject("lblAnalysis.Text").ToString()
            lblaltura.Text = GetLocalResourceObject("lblaltura.Text").ToString()
            btnGraficar.Text = GetLocalResourceObject("btnGraficar.Text").ToString()
            btnCargarEjemplo.Text = GetLocalResourceObject("btnCargarEjemplo.Text").ToString()
            imgModeloConcreto.ImageUrl = GetLocalResourceObject("imgModeloConcreto.Text").ToString()
            imgModeloAcero.ImageUrl = GetLocalResourceObject("imgModeloAcero.Text").ToString()

            'imgRutaTitulo.ImageUrl = GetLocalResourceObject("imgRutaTitulo.Text").ToString()
        End Sub

        Sub obtenerDatos()

            file_in(1) = Me.txtdiameter.Text
            file_in(2) = Me.txtConcrComprStrength.Text
            file_in(3) = Me.txtfyLong.Text
            file_in(4) = Me.txtfyTrans.Text
            file_in(5) = CDbl(Me.txtShearSpan.Text) / 1000
            file_in(6) = Me.txtMoment.Text
            file_in(7) = Me.txtAxialLoad.Text
            file_in(8) = Me.txtNumBars.Text
            file_in(9) = Me.txtSpacingStirrups.Text
            file_in(10) = Me.txtcoverRebar.Text

        End Sub
        Sub subGraficarPositivo()
            'Arreglo de linea MC 
            Dim arrXLineMC(50) As Double
            Dim arrYLineMC(50) As Double

            'Arreglo de linea Bilineal
            Dim arrXLineCorte(50) As Double
            Dim arrYLineCorte(50) As Double

            'Arreglo de linea Corte
            Dim arrXLineBilineal(2) As Double
            Dim arrYLineBilineal(2) As Double

            'Extraccion de coordenadas para graficar
            For i As Integer = 1 To 50
                arrXLineMC(i) = CDbl(MCcurvesR(1, i, 1))
                arrYLineMC(i) = CDbl(MCcurvesR(1, i, 2))
            Next

            For i As Integer = 1 To 50
                arrXLineCorte(i) = CDbl(MCcurvesR(1, i, 1))
                arrYLineCorte(i) = CDbl(MCcurvesR(1, i, 6))
            Next

            'Extraccion datos de linea de corte
            arrXLineBilineal(0) = 0
            arrYLineBilineal(0) = 0

            arrXLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 1))
            arrYLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 1))

            arrXLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 1))
            arrYLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 1))

            'Redimensionamiento de coordenas de lineas MC y blilineal
            ReDim Preserve arrXLineMC(48)
            ReDim Preserve arrYLineMC(48)

            ReDim Preserve arrXLineCorte(48)
            ReDim Preserve arrYLineCorte(48)


            'Linea mc
            Dim lineMC As LineLayer
            lineMC = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC, colores(0), "MC")
            lineMC.setXData(arrXLineMC)
            lineMC.setLineWidth(2)

            'Linea de corte
            Dim lineCorte As LineLayer
            lineCorte = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineCorte, colores(1), "Shear")
            lineCorte.setXData(arrXLineCorte)
            lineCorte.setLineWidth(2)

            'Linea bilineal
            Dim lineBilineal As LineLayer
            lineBilineal = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal, colores(2), "Bilineal")
            lineBilineal.setXData(arrXLineBilineal)
            lineBilineal.setLineWidth(2)

            'Creacion de imagen
            WebChartViewer1.Image = XYChart_Grafica_MomentoCurvatura.makeWebImage(Chart.PNG)
        End Sub
        'Sub subGraficarNegativo()
        '    'Arreglo de linea MC 
        '    Dim arrXLineMC2(50) As Double
        '    Dim arrYLineMC2(50) As Double

        '    'Arreglo de linea Bilineal
        '    Dim arrXLineCorte2(50) As Double
        '    Dim arrYLineCorte2(50) As Double

        '    'Arreglo de linea Corte
        '    Dim arrXLineBilineal2(2) As Double
        '    Dim arrYLineBilineal2(2) As Double

        '    'Extraccion de coordenadas para graficar
        '    For i As Integer = 1 To 50
        '        arrXLineMC2(i) = CDbl(MCcurvesR(2, i, 1))
        '        arrYLineMC2(i) = CDbl(MCcurvesR(2, i, 2))
        '    Next

        '    For i As Integer = 1 To 50
        '        arrXLineCorte2(i) = CDbl(MCcurvesR(2, i, 1))
        '        arrYLineCorte2(i) = CDbl(MCcurvesR(2, i, 6))
        '    Next

        '    'Extraccion datos de linea de corte
        '    arrXLineBilineal2(0) = 0
        '    arrYLineBilineal2(0) = 0

        '    arrXLineBilineal2(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 2))
        '    arrYLineBilineal2(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 2))

        '    arrXLineBilineal2(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 2))
        '    arrYLineBilineal2(2) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 2))

        '    'Redimensionamiento de coordenas de lineas MC y blilineal
        '    ReDim Preserve arrXLineMC2(48)
        '    ReDim Preserve arrYLineMC2(48)

        '    ReDim Preserve arrXLineCorte2(48)
        '    ReDim Preserve arrYLineCorte2(48)


        '    'Linea mc
        '    Dim lineMC2 As LineLayer
        '    lineMC2 = XYChart2_Grafica2_MomentoNegativo.addLineLayer(arrYLineMC2, colores(0), "MC")
        '    lineMC2.setXData(arrXLineMC2)
        '    lineMC2.setLineWidth(2)

        '    'Linea de corte
        '    Dim lineCorte2 As LineLayer
        '    lineCorte2 = XYChart2_Grafica2_MomentoNegativo.addLineLayer(arrYLineCorte2, colores(1), "Corte")
        '    lineCorte2.setXData(arrXLineCorte2)
        '    lineCorte2.setLineWidth(2)

        '    'Linea bilineal
        '    Dim lineBilineal2 As LineLayer
        '    lineBilineal2 = XYChart2_Grafica2_MomentoNegativo.addLineLayer(arrYLineBilineal2, colores(2), "Bilineal")
        '    lineBilineal2.setXData(arrXLineBilineal2)
        '    lineBilineal2.setLineWidth(2)

        '    'Creacion de imagen
        '    WebChartViewer2.Image = XYChart2_Grafica2_MomentoNegativo.makeWebImage(Chart.PNG)
        'End Sub
        Sub Resultados()


            Dim strdesignresult As String = Nothing
            strdesignresult = arrTextoResultadosDesign(idIdioma, 0) & Chr(13) & _
            arrTextoResultadosDesign(idIdioma, 1) & Chr(13) & _
            Chr(13) & Chr(10) & "  " & _
            Chr(13) & Chr(10) & "-----------------------------------------------------------" & _
            arrTextoResultadosDesign(idIdioma, 2) & Chr(13) & _
            Chr(13) & Chr(10) & "  " _
            & arrTextoResultadosDesign(idIdioma, 3) & Chr(13) _
            & Round(designresultR(1), 4) & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 4) & Chr(13) _
            & Round(designresultR(2), 4) & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 5) & Chr(13) _
            & Round(designresultR(3), 4) & " " & "kN" & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 6) & Chr(13) _
            & Round(designresultR(4), 4) & " " & "kN" & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 7) & Chr(13) _
            & Round(designresultR(5), 4) & " " & "kN" & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 8) & Chr(13) _
            & Round(designresultR(6), 4) & " " & "mm" & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 9) & Chr(13) _
            & Round(designresultR(7), 4) & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 10) & Chr(13) _
            & Round(designresultR(8), 4) & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 11) & Chr(13) _
            & Round(designresultR(9), 4) & " " & "mm" & Chr(13) _
            & arrTextoResultadosDesign(idIdioma, 12) & Chr(13) _
            & Round(designresultR(10), 4) & " " & "mm"

            Me.TextBox1.Text = strdesignresult

            'Enviar Resultados a Cajas de Texto Momento Curvatura
            'MOMENTO POSITIVO
            Me.txtLongRR1.Text = Round(sectionpropertiesR(1, 1) * 100, 4)
            Me.txtTransRR1.Text = Round(sectionpropertiesR(2, 1) * 100, 4)
            Me.txtAxialLoadRatio1.Text = Round(sectionpropertiesR(3, 1) * 100, 4)
            Me.txtMomentoPrimeraFluencia1.Text = Round(sectionpropertiesR(5, 1), 4)
            Me.tbPrimeraCurvaturaFluencia1.Text = Round(sectionpropertiesR(6, 1), 4)
            Me.tbMomentoNominal1.Text = Round(sectionpropertiesR(7, 1), 4)
            Me.tbCurvaturaFluencia1.Text = Round(sectionpropertiesR(8, 1), 4)
            Me.tbIncerciaAgrietada1.Text = Round(sectionpropertiesR(4, 1), 4)
            Me.txtDefMomNom1.Text = Round(sectionpropertiesR(9, 1), 4)
            Me.txtDamageControl1.Text = Round(sectionpropertiesR(10, 1), 4)
            Me.txtDamCon1.Text = Round(sectionpropertiesR(11, 1), 4)
            Me.txtSlopeRatio1.Text = Round(sectionpropertiesR(12, 1), 4)



            'Enviar Resultados a Cajas de Texto Diseño
            Me.txtDiameterLongitudinal.Text = designresultR(10)
            Me.txtDiameterStirrup.Text = designresultR(6)


            'reporte
            Dim Result As String = Nothing
            Result = arrTextoResultados(idIdioma, 0) & Chr(13) & _
            arrTextoResultados(idIdioma, 1) & Chr(13) & _
            arrTextoResultados(idIdioma, 2) & Chr(13) & _
            Chr(13) & Chr(10) & "  " & _
            Chr(13) & Chr(10) & "-----------------------------------------------------------" & _
            Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 3) & Chr(13) & _
            Chr(13) & Chr(10) & "  " & _
            arrTextoResultados(idIdioma, 4) & Chr(13) & _
            Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 5) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(1, 1), 2) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 6) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(2, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 7) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(3, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 8) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(4, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 9) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(5, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 10) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(6, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 11) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(7, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 12) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(8, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 13) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(9, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 14) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(10, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 15) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(11, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 16) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(12, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 17) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(13, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 18) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(14, 1), 4) & " " & "MPa" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 19) _
            & Chr(13) & Chr(10) & Round(materialpropertiesR(15, 1), 4) _
            & Chr(13) & Chr(10) & " " _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 20) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 21) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(1, 1) * 100, 4) & " " & "%" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 22) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(2, 1) * 100, 4) & " " & "%" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 23) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(3, 1) * 100, 4) & " " & "%" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 24) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(4, 1), 4) & " " & "m^4" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 25) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(5, 1), 4) & " " & "kN-m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 26) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(6, 1), 4) & " " & "1/m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 27) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(7, 1), 4) & " " & "kN-m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 28) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(8, 1), 4) & " " & "1/m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 29) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(9, 1), 4) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 30) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(10, 1), 4) & " " & "kN-m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 31) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(11, 1), 4) & " " & "1/m" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 32) _
            & Chr(13) & Chr(10) & Round(sectionpropertiesR(12, 1), 4) _
            & Chr(13) & Chr(10) & " " _
            & Chr(13) & Chr(10) & "-----------------------------------------------------------------------------" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 33) _
            & Chr(13) & Chr(10) & " " _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 34) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 35) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 36) _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 37) _
            & Chr(13) & Chr(10) & " " _
            & Chr(13) & Chr(10) & "-----------------------------------------------------------------------------" _
            & Chr(13) & Chr(10) & arrTextoResultados(idIdioma, 39) _
            & Chr(13) & Chr(10) & " " _
            & Chr(13) & Chr(10) & ""



            For i As Integer = 1 To 50
                matriz1(i, 1) = MCcurvesR(1, i, 1)
                matriz1(i, 2) = MCcurvesR(1, i, 2)
                matriz1(i, 3) = MCcurvesR(1, i, 3)
                matriz1(i, 4) = MCcurvesR(1, i, 4)
                matriz1(i, 5) = MCcurvesR(1, i, 5)
                matriz1(i, 6) = MCcurvesR(1, i, 6)
            Next



            Dim strResultados As String = Nothing
            strResultados = strResultados + Result
            strResultados = strResultados + arrTextoResultados(idIdioma, 38) & Chr(13) & Chr(10)
            For i As Integer = 1 To 50
                strResultados = strResultados + CStr(Round(matriz1(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 3), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 6), 5)) & Chr(9)
                strResultados = strResultados + Chr(13) & Chr(10)

            Next
            Me.txtresult.Text = strResultados

         
        End Sub

        Protected Sub btnGraficar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficar.Click

            obtenerDatos()
            objVLEE_AMC.readinput_design_circol(file_in)
            objVLEE_AMC.design_circol()
            'resultados
            designresultR = objVLEE_AMC.Return_Designresult
            materialpropertiesR = objVLEE_AMC.Return_materialproperties
            sectionpropertiesR = objVLEE_AMC.Return_sectionproperties
            MCcurvesR = objVLEE_AMC.Return_MCcurves

            'Leer resultados y enviarlos a cajas de texto
            Resultados()

            'graficar curvas momento-curvatura
            subGraficarPositivo()
            'subGraficarNegativo()

        End Sub

        Protected Sub btnCargarEjemplo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarEjemplo.Click

            subGraficarPositivo()


            Me.txtdiameter.Text = 600
            Me.txtConcrComprStrength.Text = 24
            Me.txtfyLong.Text = 420
            Me.txtfyTrans.Text = 420
            Me.txtShearSpan.Text = 2500
            Me.txtMoment.Text = 440
            Me.txtAxialLoad.Text = 900
            Me.txtNumBars.Text = 12
            Me.txtSpacingStirrups.Text = 150
            Me.txtcoverRebar.Text = 50

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Request.IsAuthenticated = True Then
            '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
            'objVLEE_AMC = New VLEE_AMC150.VLEE_AMC150_CMain
            establecerPropCtrlGraficos()
                If Not Page.IsPostBack Then
                    WebChartViewer1.Image = XYChart_Grafica_MomentoCurvatura.makeWebImage(Chart.PNG)
                End If
                subAsignarIdiomaACtrls()
            'Else
            '    getIdioma = Request.Params("idioma")
            '    Response.BufferOutput = True
            '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
            'End If
        End Sub


    End Class
End Namespace

