Imports System.IO
Imports Microsoft.VisualBasic.OpenAccess
Imports System.Math
Imports ChartDirector
Imports VirtualLabIS.DTO
Imports VirtualLabIS.Facade
Imports System.Data
Imports System.Threading
Imports System.Globalization

Imports DotNetNuke.Entities.Tabs
Imports DotNetNuke.Security.Permissions
Imports DotNetNuke.UI.Skins
Imports DotNetNuke.UI.Utilities

'Imports VLEE_AMC150


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Parameter_Beam_wfBeam
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}
        Dim arrTextoEjes(,) As String = {{"MOMENTO (kN-m)", _
                                                          "CURVATURA (1/m)", _
                                                          "FUERZA DE FLEXION My(kN-m)", _
                                                          "RIGIDEZ DE FLEXION AGRIETADA EIcr(kN/m)"}, _
                                                        {"MOMENT(kN-m)", _
                                                         "CURVATURE (1/m)", _
                                                         "FLEXURAL STRENGTH My(kN-m)", _
                                                         "CRACKED FLEXURAL STIFFNESS EIcr(kN/m)"}}
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
        Dim intAnchoGraficas As Integer = 480
        Dim intAltoGraficas As Integer = 390
        Dim intColorFondo As Integer = &HEFEFEE

        Dim XYChart_Grafica_MomentoCurvatura As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas - 90, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim XYChart_Grafica_EstimCurvaturaFluencia As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_ResistenciaRigidez As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_InerciaGruesa_Agrietada As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico


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
        Dim Pfile_in(300, 10) As Object
        Dim graficaMC(50, 2) As Single
        Dim matriz1(50, 6) As Double
        Dim matriz2(50, 6) As Double
        Dim matriz3(50, 6) As Double
        Dim matriz4(50, 6) As Double
        Dim matriz5(50, 6) As Double
        Dim matriz6(50, 6) As Double
        Dim matriz7(50, 6) As Double
        Dim matriz8(50, 6) As Double
        Dim matriz9(50, 6) As Double
        Dim matriz10(50, 6) As Double
        Dim NumSections As Integer

        Dim avgSlope As Double
        Dim ptns As Double

        Dim figura1 As Object
        Dim figura2 As Object
        Dim figura3 As Object
        Dim figura4 As Object
        Dim figura5 As Object


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
            grfGrafica.setRoundedFrame(222, 0, 0, 0, 0)
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
            WebChartViewer2.Image = XYChart_Grafica_EstimCurvaturaFluencia.makeWebImage(Chart.PNG)
            WebChartViewer3.Image = XYChart_Grafica_ResistenciaRigidez.makeWebImage(Chart.PNG)
            WebChartViewer4.Image = XYChart_Grafica_InerciaGruesa_Agrietada.makeWebImage(Chart.PNG)
            WebChartViewer5.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.makeWebImage(Chart.PNG)
            WebChartViewer6.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.makeWebImage(Chart.PNG)
            'WebChartViewer2.Image = XYChart_Grafica_ResistenciaRigidez.makeWebImage(Chart.PNG)
            'WebChartViewer3.Image = XYChart_Grafica_InerciaGruesa_Agrietada.makeWebImage(Chart.PNG)
            'WebChartViewer4.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.makeWebImage(Chart.PNG)
            'WebChartViewer5.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.makeWebImage(Chart.PNG)

        End Sub

        ''' <summary>
        ''' Crear los controles gráficos WebChartView, parametrizando los titulos, tamaño, etc.
        ''' Las Graficas son siete, ellas son:
        ''' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub establecerPropCtrlGraficos()
            ' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
            CrearGraficasXYChart(60, 5, 250, 250, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 1), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_MomentoCurvatura)
            legendBox = XYChart_Grafica_MomentoCurvatura.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent)

            ' GRÁFICA NÚMERO#2   "ESTIMACION DE LA CURVATURA DE FLUENCIA"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "Φy (1/m)", "Arial Bold Italic", 9, 0, 3, "<*block*><*size=13*> ε<*sub*>y<*/*> / D (1/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EstimCurvaturaFluencia)
            XYChart_Grafica_EstimCurvaturaFluencia.addLegend(50, 50, False, "Times New Roman Bold Italic", 12).setBackground(Chart.Transparent)

            '' GRÁFICA NÚMERO#3   "RELACION ENTRE RESISTENCIA Y RIGIDEZ"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 3), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_ResistenciaRigidez)
            XYChart_Grafica_ResistenciaRigidez.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)

            ' GRÁFICO NÚMERO#4   "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> ", "Arial Bold Italic", 9, 0, 3, " ρ (%)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InerciaGruesa_Agrietada)
            XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)

            ' GRÁFICA NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" Ec
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>c<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC)
            XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)

            ' GRÁFICA NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" Es       
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>s<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES)
            XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)



            '' GRÁFICO NÚMERO#4   "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> ", "Arial Bold Italic", 9, 0, 3, " ρ (%)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InerciaGruesa_Agrietada)
            'XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)

            '' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
            'CrearGraficasXYChart(60, 5, 250, 250, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "MOMENT(kN-m)", "Arial Bold Italic", 9, 0, 3, "CURVATURE (1/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_MomentoCurvatura)
            'legendBox = XYChart_Grafica_MomentoCurvatura.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            'legendBox.setBackground(Chart.Transparent)
            '' GRÁFICA NÚMERO#2   "ESTIMACIÓN DE CURVATURA DE FLUENCIA"
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "Φy (1/m)", "Arial Bold Italic", 9, 0, 3, "ε<*sub*>y<*/*> / D (1/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EstimCurvaturaFluencia)
            'XYChart_Grafica_EstimCurvaturaFluencia.addLegend(50, 50, False, "Times New Roman Bold Italic", 12).setBackground(Chart.Transparent)
            '' GRÁFICO NÚMERO#3   "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ"
            ''CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "FLEXURAL STRENGTH  My (kN/m)", "Arial Bold Italic", 9, 0, 3, "CRACKED FLEXURAL STIFFNESS Elcr (kN/m<*super*>2)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_ResistenciaRigidez)
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "FLEXURAL STRENGTH  My (kN-m)", "Arial Bold Italic", 9, 0, 3, "CRACKED FLEXURAL STIFFNESS Elcr (kN/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_ResistenciaRigidez)
            'XYChart_Grafica_ResistenciaRigidez.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            '' GRÁFICO NÚMERO#4   "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> ", "Arial Bold Italic", 9, 0, 3, " ρ (%)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InerciaGruesa_Agrietada)
            'XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            '' GRÁFICO NÚMERO#5   "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA"
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> from M-C", "Arial Bold Italic", 9, 0, 3, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> Kowalsky", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InercGruesAgriet_Real_Calculada)
            'XYChart_Grafica_InercGruesAgriet_Real_Calculada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            '' GRÁFICA NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" Ec
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>c<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC)
            'XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            '' GRÁFICA NÚMERO#7 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" Es        ''' </summary>
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>s<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES)
            'XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)

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

            btnCargarEjemplo.Text = GetLocalResourceObject("btnCargarEjemplo.Text").ToString()
            btnGraficar.Text = GetLocalResourceObject("btnGraficar.Text").ToString()
            lblFc.Text = GetLocalResourceObject("lblFc.Text").ToString()
            lblFyLong.Text = GetLocalResourceObject("lblFyLong.Text").ToString()
            lblFyTrans.Text = GetLocalResourceObject("lblFyTrans.Text").ToString()
            lblSteelRatio.Text = GetLocalResourceObject("lblSteelRatio.Text").ToString()
            lblTituloMaterialProper.Text = GetLocalResourceObject("lblTituloMaterialProper.Text").ToString()
            lblInputData1.Text = GetLocalResourceObject("lblInputData1.Text").ToString()
            lblNumeroSecciones.Text = GetLocalResourceObject("lblNumeroSecciones.Text").ToString()
            lblSectionNumber.Text = GetLocalResourceObject("lblSectionNumber.Text").ToString()
            lblCoverBottom.Text = GetLocalResourceObject("lblCoverBottom.Text").ToString()
            lblCoverTop.Text = GetLocalResourceObject("lblCoverTop.Text").ToString()
            lblDiamBottom.Text = GetLocalResourceObject("lblDiamBottom.Text").ToString()
            lblDiamLateral.Text = GetLocalResourceObject("lblDiamLateral.Text").ToString()
            lblDiamStirrups.Text = GetLocalResourceObject("lblDiamStirrups.Text").ToString()
            lblDiamTop.Text = GetLocalResourceObject("lblDiamTop.Text").ToString()
            lblNumBarsBottom.Text = GetLocalResourceObject("lblNumBarsBottom.Text").ToString()
            lblNumBarsTop.Text = GetLocalResourceObject("lblNumBarsTop.Text").ToString()
            lblNumLateral.Text = GetLocalResourceObject("lblNumLateral.Text").ToString()
            lblSectionBase.Text = GetLocalResourceObject("lblSectionBase.Text").ToString()
            lblSectionHeight.Text = GetLocalResourceObject("lblSectionHeight.Text").ToString()
            lblShearSpan.Text = GetLocalResourceObject("lblShearSpan.Text").ToString()
            lblSpacingStirrups.Text = GetLocalResourceObject("lblSpacingStirrups.Text").ToString()
            lblStirrupsX.Text = GetLocalResourceObject("lblStirrupsX.Text").ToString()
            lblStirrupsY.Text = GetLocalResourceObject("lblStirrupsY.Text").ToString()
            lblTituloSeccionProper.Text = GetLocalResourceObject("lblTituloSeccionProper.Text").ToString()
            lblFigura2.Text = GetLocalResourceObject("lblFigura2.Text").ToString()
            lblFigura3.Text = GetLocalResourceObject("lblFigura3.Text").ToString()
            lblFigura4.Text = GetLocalResourceObject("lblFigura4.Text").ToString()
            lblFigura5.Text = GetLocalResourceObject("lblFigura5.Text").ToString()
            lblFigura6.Text = GetLocalResourceObject("lblFigura6.Text").ToString()
            lblResults.Text = GetLocalResourceObject("lblResults.Text").ToString()
            lblTituloFig1.Text = GetLocalResourceObject("lblTituloFig1.Text").ToString()
            lblTituloFig2.Text = GetLocalResourceObject("lblTituloFig2.Text").ToString()
            lblTituloFig3.Text = GetLocalResourceObject("lblTituloFig3.Text").ToString()
            lblTituloFig5.Text = GetLocalResourceObject("lblTituloFig5.Text").ToString()
            lblTituloFig6.Text = GetLocalResourceObject("lblTituloFig6.Text").ToString()
            lblTituloMCR.Text = GetLocalResourceObject("lblTituloMCR.Text").ToString()
            lblSeccion.Text = GetLocalResourceObject("lblSeccion.Text").ToString()
            lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            lblTituloGeneral.Text = GetLocalResourceObject("lblTituloGeneral.Text").ToString()

            imgRutaTitulo.ImageUrl = GetLocalResourceObject("imgRutaTitulo.Text").ToString()
        End Sub

        Sub obtenerDatos()

            Dim booIndicador As Boolean
            NumSections = Me.txtNumberSections.Text
            NumSections = Me.txtNumberSections.Text

            Pfile_in(1, 1) = Me.txtBase1.Text       ' section base (mm)
            Pfile_in(2, 1) = Me.txtHeight1.Text        ' section height (mm)
            Pfile_in(3, 1) = Me.txtfc1.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 1) = Me.txtFyLong1.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 1) = Me.txtSteelRatio1.Text       ' steel hardening ratio
            Pfile_in(6, 1) = Me.txtFyTrans1.Text       ' transverse steel yielding stress (MPa)
            Pfile_in(7, 1) = CDbl(Me.txtShearSpan1.Text) / 1000         ' shear span (m)
            Pfile_in(8, 1) = Me.txtBarsTop1.Text          ' # bars of top steel
            Pfile_in(9, 1) = Me.txtDiamTop1.Text          ' diameter bars of top steel
            Pfile_in(10, 1) = Me.txtNumBarsBottom1.Text         ' # bars of bottom steel
            Pfile_in(11, 1) = Me.txtDiamBottom1.Text          ' diameter bars of bottom steel
            Pfile_in(12, 1) = Me.txtNumBarsLateral1.Text          ' # bars of lateral steel
            Pfile_in(13, 1) = Me.txtDiamLateral1.Text          ' diameter bars of lateral steel
            Pfile_in(14, 1) = Me.txtNumStirrupsX1.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 1) = Me.txtNumStirrupsY1.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 1) = Me.txtDiamStirrups1.Text          ' diameter of stirrups
            Pfile_in(17, 1) = Me.txtSpacingStirrups1.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 1) = Me.txtcoverTopBottom1.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 1) = Me.txtCoverLateral1.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 1) = "uniaxial" ' ductility mode
            Pfile_in(21, 1) = 180 ' rotation

            Pfile_in(1, 2) = Me.txtBase2.Text       ' section base (mm)
            Pfile_in(2, 2) = Me.txtHeight2.Text        ' section height (mm)
            Pfile_in(3, 2) = Me.txtfc2.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 2) = Me.txtFyLong2.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 2) = Me.txtSteelRatio2.Text       ' steel hardening ratio
            Pfile_in(6, 2) = Me.txtFyTrans2.Text       ' transverse steel yielding stress (MPa)
            Pfile_in(7, 2) = CDbl(Me.txtShearSpan2.Text) / 1000         ' shear span (m)
            Pfile_in(8, 2) = Me.txtBarsTop2.Text          ' # bars of top steel
            Pfile_in(9, 2) = Me.txtDiamTop2.Text          ' diameter bars of top steel
            Pfile_in(10, 2) = Me.txtNumBarsBottom2.Text         ' # bars of bottom steel
            Pfile_in(11, 2) = Me.txtDiamBottom2.Text          ' diameter bars of bottom steel
            Pfile_in(12, 2) = Me.txtNumBarsLateral2.Text          ' # bars of lateral steel
            Pfile_in(13, 2) = Me.txtDiamLateral2.Text          ' diameter bars of lateral steel
            Pfile_in(14, 2) = Me.txtNumStirrupsX2.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 2) = Me.txtNumStirrupsY2.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 2) = Me.txtDiamStirrups2.Text          ' diameter of stirrups
            Pfile_in(17, 2) = Me.txtSpacingStirrups2.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 2) = Me.txtcoverTopBottom2.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 2) = Me.txtCoverLateral2.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 2) = "uniaxial" ' ductility mode
            Pfile_in(21, 2) = 180 ' rotation

            Pfile_in(1, 3) = Me.txtBase3.Text       ' section base (mm)
            Pfile_in(2, 3) = Me.txtHeight3.Text        ' section height (mm)
            Pfile_in(3, 3) = Me.txtfc3.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 3) = Me.txtFyLong3.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 3) = Me.txtSteelRatio3.Text       ' steel hardening ratio
            Pfile_in(6, 3) = Me.txtFyTrans3.Text       ' transverse steel yielding stress (MPa)
            Pfile_in(7, 3) = CDbl(Me.txtShearSpan3.Text) / 1000         ' shear span (m)
            Pfile_in(8, 3) = Me.txtBarsTop3.Text          ' # bars of top steel
            Pfile_in(9, 3) = Me.txtDiamTop3.Text          ' diameter bars of top steel
            Pfile_in(10, 3) = Me.txtNumBarsBottom3.Text         ' # bars of bottom steel
            Pfile_in(11, 3) = Me.txtDiamBottom3.Text          ' diameter bars of bottom steel
            Pfile_in(12, 3) = Me.txtNumBarsLateral3.Text          ' # bars of lateral steel
            Pfile_in(13, 3) = Me.txtDiamLateral3.Text          ' diameter bars of lateral steel
            Pfile_in(14, 3) = Me.txtNumStirrupsX3.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 3) = Me.txtNumStirrupsY3.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 3) = Me.txtDiamStirrups3.Text          ' diameter of stirrups
            Pfile_in(17, 3) = Me.txtSpacingStirrups3.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 3) = Me.txtcoverTopBottom3.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 3) = Me.txtCoverLateral3.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 3) = "uniaxial" ' ductility mode
            Pfile_in(21, 3) = 180 ' rotation


            Pfile_in(1, 4) = Me.txtBase4.Text       ' section base (mm)
            Pfile_in(2, 4) = Me.txtHeight4.Text        ' section height (mm)
            Pfile_in(3, 4) = Me.txtfc4.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 4) = Me.txtFyLong4.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 4) = Me.txtSteelRatio4.Text       ' steel hardening ratio
            Pfile_in(6, 4) = Me.txtFyTrans4.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan4.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan4.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 4) = Me.txtBarsTop4.Text          ' # bars of top steel
            Pfile_in(9, 4) = Me.txtDiamTop4.Text          ' diameter bars of top steel
            Pfile_in(10, 4) = Me.txtNumBarsBottom4.Text         ' # bars of bottom steel
            Pfile_in(11, 4) = Me.txtDiamBottom4.Text          ' diameter bars of bottom steel
            Pfile_in(12, 4) = Me.txtNumBarsLateral4.Text          ' # bars of lateral steel
            Pfile_in(13, 4) = Me.txtDiamLateral4.Text          ' diameter bars of lateral steel
            Pfile_in(14, 4) = Me.txtNumStirrupsX4.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 4) = Me.txtNumStirrupsY4.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 4) = Me.txtDiamStirrups4.Text          ' diameter of stirrups
            Pfile_in(17, 4) = Me.txtSpacingStirrups4.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 4) = Me.txtcoverTopBottom4.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 4) = Me.txtCoverLateral4.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 4) = "uniaxial" ' ductility mode
            Pfile_in(21, 4) = 180 ' rotation

            Pfile_in(1, 5) = Me.txtBase5.Text       ' section base (mm)
            Pfile_in(2, 5) = Me.txtHeight5.Text        ' section height (mm)
            Pfile_in(3, 5) = Me.txtfc5.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 5) = Me.txtFyLong5.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 5) = Me.txtSteelRatio5.Text       ' steel hardening ratio
            Pfile_in(6, 5) = Me.txtFyTrans5.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan5.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan5.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 5) = Me.txtBarsTop5.Text          ' # bars of top steel
            Pfile_in(9, 5) = Me.txtDiamTop5.Text          ' diameter bars of top steel
            Pfile_in(10, 5) = Me.txtNumBarsBottom5.Text         ' # bars of bottom steel
            Pfile_in(11, 5) = Me.txtDiamBottom5.Text          ' diameter bars of bottom steel
            Pfile_in(12, 5) = Me.txtNumBarsLateral5.Text          ' # bars of lateral steel
            Pfile_in(13, 5) = Me.txtDiamLateral5.Text          ' diameter bars of lateral steel
            Pfile_in(14, 5) = Me.txtNumStirrupsX5.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 5) = Me.txtNumStirrupsY5.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 5) = Me.txtDiamStirrups5.Text          ' diameter of stirrups
            Pfile_in(17, 5) = Me.txtSpacingStirrups5.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 5) = Me.txtcoverTopBottom5.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 5) = Me.txtCoverLateral5.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 5) = "uniaxial" ' ductility mode
            Pfile_in(21, 5) = 180 ' rotation

            Pfile_in(1, 6) = Me.txtBase6.Text       ' section base (mm)
            Pfile_in(2, 6) = Me.txtHeight6.Text        ' section height (mm)
            Pfile_in(3, 6) = Me.txtfc6.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 6) = Me.txtFyLong6.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 6) = Me.txtSteelRatio6.Text       ' steel hardening ratio
            Pfile_in(6, 6) = Me.txtFyTrans6.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan6.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan6.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 6) = Me.txtBarsTop6.Text          ' # bars of top steel
            Pfile_in(9, 6) = Me.txtDiamTop6.Text          ' diameter bars of top steel
            Pfile_in(10, 6) = Me.txtNumBarsBottom6.Text         ' # bars of bottom steel
            Pfile_in(11, 6) = Me.txtDiamBottom6.Text          ' diameter bars of bottom steel
            Pfile_in(12, 6) = Me.txtNumBarsLateral6.Text          ' # bars of lateral steel
            Pfile_in(13, 6) = Me.txtDiamLateral6.Text          ' diameter bars of lateral steel
            Pfile_in(14, 6) = Me.txtNumStirrupsX6.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 6) = Me.txtNumStirrupsY6.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 6) = Me.txtDiamStirrups6.Text          ' diameter of stirrups
            Pfile_in(17, 6) = Me.txtSpacingStirrups6.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 6) = Me.txtcoverTopBottom6.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 6) = Me.txtCoverLateral6.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 6) = "uniaxial" ' ductility mode
            Pfile_in(21, 6) = 180 ' rotation

            Pfile_in(1, 7) = Me.txtBase7.Text       ' section base (mm)
            Pfile_in(2, 7) = Me.txtHeight7.Text        ' section height (mm)
            Pfile_in(3, 7) = Me.txtfc7.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 7) = Me.txtFyLong7.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 7) = Me.txtSteelRatio7.Text       ' steel hardening ratio
            Pfile_in(6, 7) = Me.txtFyTrans7.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan7.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan7.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 7) = Me.txtBarsTop7.Text          ' # bars of top steel
            Pfile_in(9, 7) = Me.txtDiamTop7.Text          ' diameter bars of top steel
            Pfile_in(10, 7) = Me.txtNumBarsBottom7.Text         ' # bars of bottom steel
            Pfile_in(11, 7) = Me.txtDiamBottom7.Text          ' diameter bars of bottom steel
            Pfile_in(12, 7) = Me.txtNumBarsLateral7.Text          ' # bars of lateral steel
            Pfile_in(13, 7) = Me.txtDiamLateral7.Text          ' diameter bars of lateral steel
            Pfile_in(14, 7) = Me.txtNumStirrupsX7.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 7) = Me.txtNumStirrupsY7.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 7) = Me.txtDiamStirrups7.Text          ' diameter of stirrups
            Pfile_in(17, 7) = Me.txtSpacingStirrups7.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 7) = Me.txtcoverTopBottom7.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 7) = Me.txtCoverLateral7.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 7) = "uniaxial" ' ductility mode
            Pfile_in(21, 7) = 180 ' rotation

            Pfile_in(1, 8) = Me.txtBase8.Text       ' section base (mm)
            Pfile_in(2, 8) = Me.txtHeight8.Text        ' section height (mm)
            Pfile_in(3, 8) = Me.txtfc8.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 8) = Me.txtFyLong8.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 8) = Me.txtSteelRatio8.Text       ' steel hardening ratio
            Pfile_in(6, 8) = Me.txtFyTrans8.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan8.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan8.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 8) = Me.txtBarsTop8.Text          ' # bars of top steel
            Pfile_in(9, 8) = Me.txtDiamTop8.Text          ' diameter bars of top steel
            Pfile_in(10, 8) = Me.txtNumBarsBottom8.Text         ' # bars of bottom steel
            Pfile_in(11, 8) = Me.txtDiamBottom8.Text          ' diameter bars of bottom steel
            Pfile_in(12, 8) = Me.txtNumBarsLateral8.Text          ' # bars of lateral steel
            Pfile_in(13, 8) = Me.txtDiamLateral8.Text          ' diameter bars of lateral steel
            Pfile_in(14, 8) = Me.txtNumStirrupsX8.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 8) = Me.txtNumStirrupsY8.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 8) = Me.txtDiamStirrups8.Text          ' diameter of stirrups
            Pfile_in(17, 8) = Me.txtSpacingStirrups8.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 8) = Me.txtcoverTopBottom8.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 8) = Me.txtCoverLateral8.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 8) = "uniaxial" ' ductility mode
            Pfile_in(21, 8) = 180 ' rotation

            Pfile_in(1, 9) = Me.txtBase9.Text       ' section base (mm)
            Pfile_in(2, 9) = Me.txtHeight9.Text        ' section height (mm)
            Pfile_in(3, 9) = Me.txtfc9.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 9) = Me.txtFyLong9.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 9) = Me.txtSteelRatio9.Text       ' steel hardening ratio
            Pfile_in(6, 9) = Me.txtFyTrans9.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan9.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan9.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 9) = Me.txtBarsTop9.Text          ' # bars of top steel
            Pfile_in(9, 9) = Me.txtDiamTop9.Text          ' diameter bars of top steel
            Pfile_in(10, 9) = Me.txtNumBarsBottom9.Text         ' # bars of bottom steel
            Pfile_in(11, 9) = Me.txtDiamBottom9.Text          ' diameter bars of bottom steel
            Pfile_in(12, 9) = Me.txtNumBarsLateral9.Text          ' # bars of lateral steel
            Pfile_in(13, 9) = Me.txtDiamLateral9.Text          ' diameter bars of lateral steel
            Pfile_in(14, 9) = Me.txtNumStirrupsX9.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 9) = Me.txtNumStirrupsY9.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 9) = Me.txtDiamStirrups9.Text          ' diameter of stirrups
            Pfile_in(17, 9) = Me.txtSpacingStirrups9.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 9) = Me.txtcoverTopBottom9.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 9) = Me.txtCoverLateral9.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 9) = "uniaxial" ' ductility mode
            Pfile_in(21, 9) = 180 ' rotation

            Pfile_in(1, 10) = Me.txtBase10.Text       ' section base (mm)
            Pfile_in(2, 10) = Me.txtHeight10.Text        ' section height (mm)
            Pfile_in(3, 10) = Me.txtfc10.Text         ' concrete compressive strength (MPa)
            Pfile_in(4, 10) = Me.txtFyLong10.Text       ' long steel yielding stress (MPa)
            Pfile_in(5, 10) = Me.txtSteelRatio10.Text       ' steel hardening ratio
            Pfile_in(6, 10) = Me.txtFyTrans10.Text       ' transverse steel yielding stress (MPa)

            booIndicador = Me.txtShearSpan10.Text IsNot Nothing

            If booIndicador = False Then
                Pfile_in(7, 4) = CDbl(Me.txtShearSpan10.Text) / 1000         ' shear span (m)
            End If

            Pfile_in(8, 10) = Me.txtBarsTop10.Text          ' # bars of top steel
            Pfile_in(9, 10) = Me.txtDiamTop10.Text          ' diameter bars of top steel
            Pfile_in(10, 10) = Me.txtNumBarsBottom10.Text         ' # bars of bottom steel
            Pfile_in(11, 10) = Me.txtDiamBottom10.Text          ' diameter bars of bottom steel
            Pfile_in(12, 10) = Me.txtNumBarsLateral10.Text          ' # bars of lateral steel
            Pfile_in(13, 10) = Me.txtDiamLateral10.Text          ' diameter bars of lateral steel
            Pfile_in(14, 10) = Me.txtNumStirrupsX10.Text          ' # of stirrup legs resisting shear in x direction
            Pfile_in(15, 10) = Me.txtNumStirrupsY10.Text          ' # of stirrup legs resisting shear in y direction
            Pfile_in(16, 10) = Me.txtDiamStirrups10.Text          ' diameter of stirrups
            Pfile_in(17, 10) = Me.txtSpacingStirrups10.Text        ' spacing of stirrups (mm)
            Pfile_in(18, 10) = Me.txtcoverTopBottom10.Text          ' cover up to top and bottom rebar centre(mm)
            Pfile_in(19, 10) = Me.txtCoverLateral10.Text          ' cover up to lateral rebar centre(mm)
            Pfile_in(20, 10) = "uniaxial" ' ductility mode
            Pfile_in(21, 10) = 180 ' rotation


        End Sub

        Sub CargarEjemplo()

            Me.txtNumberSections.Text = 3 'Number of sections to analize

            Me.txtBase1.Text = 300       ' section base (mm)
            Me.txtHeight1.Text = 500        ' section height (mm)
            Me.txtfc1.Text = 24         ' concrete compressive strength (MPa)
            Me.txtFyLong1.Text = 420       ' long steel yielding stress (MPa)
            Me.txtSteelRatio1.Text = 1.35       ' steel hardening ratio
            Me.txtFyTrans1.Text = 420       ' transverse steel yielding stress (MPa)
            Me.txtShearSpan1.Text = 2000         ' shear span (m)
            Me.txtBarsTop1.Text = 4          ' # bars of top steel
            Me.txtDiamTop1.Text = 22          ' diameter bars of top steel
            Me.txtNumBarsBottom1.Text = 4         ' # bars of bottom steel
            Me.txtDiamBottom1.Text = 12          ' diameter bars of bottom steel
            Me.txtNumBarsLateral1.Text = 0          ' # bars of lateral steel
            Me.txtDiamLateral1.Text = 0          ' diameter bars of lateral steel
            Me.txtNumStirrupsX1.Text = 2          ' # of stirrup legs resisting shear in x direction
            Me.txtNumStirrupsY1.Text = 2          ' # of stirrup legs resisting shear in y direction
            Me.txtDiamStirrups1.Text = 10          ' diameter of stirrups
            Me.txtSpacingStirrups1.Text = 300        ' spacing of stirrups (mm)
            Me.txtcoverTopBottom1.Text = 50          ' cover up to top and bottom rebar centre(mm)
            Me.txtCoverLateral1.Text = 50          ' cover up to lateral rebar centre(mm)


            Me.txtBase2.Text = 300       ' section base (mm)
            Me.txtHeight2.Text = 500        ' section height (mm)
            Me.txtfc2.Text = 24         ' concrete compressive strength (MPa)
            Me.txtFyLong2.Text = 420       ' long steel yielding stress (MPa)
            Me.txtSteelRatio2.Text = 1.35       ' steel hardening ratio
            Me.txtFyTrans2.Text = 420       ' transverse steel yielding stress (MPa)
            Me.txtShearSpan2.Text = 2000         ' shear span (m)
            Me.txtBarsTop2.Text = 6          ' # bars of top steel
            Me.txtDiamTop2.Text = 22          ' diameter bars of top steel
            Me.txtNumBarsBottom2.Text = 4         ' # bars of bottom steel
            Me.txtDiamBottom2.Text = 12          ' diameter bars of bottom steel
            Me.txtNumBarsLateral2.Text = 0          ' # bars of lateral steel
            Me.txtDiamLateral2.Text = 0          ' diameter bars of lateral steel
            Me.txtNumStirrupsX2.Text = 2          ' # of stirrup legs resisting shear in x direction
            Me.txtNumStirrupsY2.Text = 2          ' # of stirrup legs resisting shear in y direction
            Me.txtDiamStirrups2.Text = 10          ' diameter of stirrups
            Me.txtSpacingStirrups2.Text = 300        ' spacing of stirrups (mm)
            Me.txtcoverTopBottom2.Text = 50          ' cover up to top and bottom rebar centre(mm)
            Me.txtCoverLateral2.Text = 50          ' cover up to lateral rebar centre(mm)


            Me.txtBase3.Text = 300       ' section base (mm)
            Me.txtHeight3.Text = 500        ' section height (mm)
            Me.txtfc3.Text = 24         ' concrete compressive strength (MPa)
            Me.txtFyLong3.Text = 420       ' long steel yielding stress (MPa)
            Me.txtSteelRatio3.Text = 1.35       ' steel hardening ratio
            Me.txtFyTrans3.Text = 420       ' transverse steel yielding stress (MPa)
            Me.txtShearSpan3.Text = 2000         ' shear span (m)
            Me.txtBarsTop3.Text = 8          ' # bars of top steel
            Me.txtDiamTop3.Text = 22          ' diameter bars of top steel
            Me.txtNumBarsBottom3.Text = 4         ' # bars of bottom steel
            Me.txtDiamBottom3.Text = 12          ' diameter bars of bottom steel
            Me.txtNumBarsLateral3.Text = 0           ' # bars of lateral steel
            Me.txtDiamLateral3.Text = 0          ' diameter bars of lateral steel
            Me.txtNumStirrupsX3.Text = 2          ' # of stirrup legs resisting shear in x direction
            Me.txtNumStirrupsY3.Text = 2          ' # of stirrup legs resisting shear in y direction
            Me.txtDiamStirrups3.Text = 10          ' diameter of stirrups
            Me.txtSpacingStirrups3.Text = 300        ' spacing of stirrups (mm)
            Me.txtcoverTopBottom3.Text = 50          ' cover up to top and bottom rebar centre(mm)
            Me.txtCoverLateral3.Text = 50          ' cover up to lateral rebar centre(mm)


        End Sub


        Protected Sub btnGraficar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficar.Click
            obtenerDatos()
            subPresentarResultados()

            'grafica2()
            Resultados()
        End Sub

        Sub subPresentarResultados()

            For n As Integer = 1 To NumSections  'NumSections
                objVLEE_AMC.readnsection(n)
                objVLEE_AMC.readinput_MC_beam_Parameter(Pfile_in)
                objVLEE_AMC.MC_beam()
            Next
            'resultados
            materialpropertiesR = objVLEE_AMC.Return_materialproperties
            sectionpropertiesR = objVLEE_AMC.Return_sectionproperties
            MCcurvesR = objVLEE_AMC.Return_MCcurves

            subGraficar()
            Figuras()
            grafica2()



        End Sub



        'Cargar Resultados en Cajas de Texto
        Sub Resultados()
            Dim Result As String = Nothing
            For i As Integer = 1 To 50
                matriz1(i, 1) = MCcurvesR(1, i, 1)
                matriz1(i, 2) = MCcurvesR(1, i, 2)
                matriz1(i, 3) = MCcurvesR(1, i, 3)
                matriz1(i, 4) = MCcurvesR(1, i, 4)
                matriz1(i, 5) = MCcurvesR(1, i, 5)
                matriz1(i, 6) = MCcurvesR(1, i, 6)

                matriz2(i, 1) = MCcurvesR(2, i, 1)
                matriz2(i, 2) = MCcurvesR(2, i, 2)
                matriz2(i, 3) = MCcurvesR(2, i, 3)
                matriz2(i, 4) = MCcurvesR(2, i, 4)
                matriz2(i, 5) = MCcurvesR(2, i, 5)
                matriz2(i, 6) = MCcurvesR(2, i, 6)

                matriz3(i, 1) = MCcurvesR(3, i, 1)
                matriz3(i, 2) = MCcurvesR(3, i, 2)
                matriz3(i, 3) = MCcurvesR(3, i, 3)
                matriz3(i, 4) = MCcurvesR(3, i, 4)
                matriz3(i, 5) = MCcurvesR(3, i, 5)
                matriz3(i, 6) = MCcurvesR(3, i, 6)

                matriz4(i, 1) = MCcurvesR(4, i, 1)
                matriz4(i, 2) = MCcurvesR(4, i, 2)
                matriz4(i, 3) = MCcurvesR(4, i, 3)
                matriz4(i, 4) = MCcurvesR(4, i, 4)
                matriz4(i, 5) = MCcurvesR(4, i, 5)
                matriz4(i, 6) = MCcurvesR(4, i, 6)

                matriz5(i, 1) = MCcurvesR(5, i, 1)
                matriz5(i, 2) = MCcurvesR(5, i, 2)
                matriz5(i, 3) = MCcurvesR(5, i, 3)
                matriz5(i, 4) = MCcurvesR(5, i, 4)
                matriz5(i, 5) = MCcurvesR(5, i, 5)
                matriz5(i, 6) = MCcurvesR(5, i, 6)

                matriz6(i, 1) = MCcurvesR(6, i, 1)
                matriz6(i, 2) = MCcurvesR(6, i, 2)
                matriz6(i, 3) = MCcurvesR(6, i, 3)
                matriz6(i, 4) = MCcurvesR(6, i, 4)
                matriz6(i, 5) = MCcurvesR(6, i, 5)
                matriz6(i, 6) = MCcurvesR(6, i, 6)

                matriz7(i, 1) = MCcurvesR(7, i, 1)
                matriz7(i, 2) = MCcurvesR(7, i, 2)
                matriz7(i, 3) = MCcurvesR(7, i, 3)
                matriz7(i, 4) = MCcurvesR(7, i, 4)
                matriz7(i, 5) = MCcurvesR(7, i, 5)
                matriz7(i, 6) = MCcurvesR(7, i, 6)

                matriz8(i, 1) = MCcurvesR(8, i, 1)
                matriz8(i, 2) = MCcurvesR(8, i, 2)
                matriz8(i, 3) = MCcurvesR(8, i, 3)
                matriz8(i, 4) = MCcurvesR(8, i, 4)
                matriz8(i, 5) = MCcurvesR(8, i, 5)
                matriz8(i, 6) = MCcurvesR(8, i, 6)

                matriz9(i, 1) = MCcurvesR(9, i, 1)
                matriz9(i, 2) = MCcurvesR(9, i, 2)
                matriz9(i, 3) = MCcurvesR(9, i, 3)
                matriz9(i, 4) = MCcurvesR(9, i, 4)
                matriz9(i, 5) = MCcurvesR(9, i, 5)
                matriz9(i, 6) = MCcurvesR(9, i, 6)

                matriz10(i, 1) = MCcurvesR(10, i, 1)
                matriz10(i, 2) = MCcurvesR(10, i, 2)
                matriz10(i, 3) = MCcurvesR(10, i, 3)
                matriz10(i, 4) = MCcurvesR(10, i, 4)
                matriz10(i, 5) = MCcurvesR(10, i, 5)
                matriz10(i, 6) = MCcurvesR(10, i, 6)

            Next

            Dim etiquetas(,) As String = {{"Módulo de Elasticidad del Concreto (MPA)", _
                                         "Resistencia del Concreto no Confinado (MPA)", _
                                         "Deformación Unitaria del Concreto no Confinado", _
                                         "Deformación Última del Concreto no Confinado (Agrietamiento)", _
                                         "Resistencia del Concreto Confinado  (Modelo de Mander) (MPA)", _
                                         "Deformación Unitaria del Concreto COnfinado (Modelo de Mander)", _
                                         "Deformación Última del Concreto (Modelo de Mander)", _
                                         "Módulo de Elasticidad del Acero (MPA)", _
                                         "Esfuerzo de Fluencia del Acero Longitudinal (MPA)", _
                                         "Deformación de Fluencia del Acero Longitudinal", _
                                         "Deformación al principio del Endurecimiento de Deformación", _
                                         "Resistencia Máxima del Acero de Refuerzo (MPA)", _
                                         "Deformación en la Máxima Resistencia del Acero de Refuerzo", _
                                         "Esfuerzo de Fluencia del Refuerzo Transversal (MPA)", _
                                         "Deformación Última del Refuerzo Transversal"}, _
                                    {"Elastic Modulus of Concrete (MPA)", _
                                         "Unconfined concrete strength (MPA)", _
                                         "Strain at unconfined concrete strength", _
                                         "Ultimate unconfined strain (spalling)", _
                                         "Confined concrete strength  (Mander’s model) (MPA)", _
                                         "Strain at confined concrete strength (Mander’s model)", _
                                         "Ultimate confined strain (Mander’s model)", _
                                         "Elastic Modulus of Steel (MPA)", _
                                         "Yield strengh of longitudinal reinforcement (MPA)", _
                                         "Yield strain of longitudinal reinforcement", _
                                         "Strain at begining of strain hardening", _
                                         "Max strength of reinforment steel (MPA)", _
                                         "Strain at maximum strenght of reinforcement steel", _
                                         "Yield strengh of transverse reinforcement (MPA)", _
                                         "Ultimate strain of transverse reinforcement"}}

            Dim etiquetasS(,) As String = {{"Cuantía de Acero Longitudinal", _
                                          "Cuantía de Acero Transversal", _
                                          "Relación de Carga Axial", _
                                          "Momento de Inercia (Tomado de la pendiente del diagrama M-C bi-linear)(m^4)", _
                                          "Momento de Primera Fluencia(kN-m)", _
                                          "Curvatura de Primera Fluencia(1/m)", _
                                          "Momento Nominal(kN-m)", _
                                          "Curvatura Nominal de Fluencia(1/m)", _
                                          "Deformación del Concreto en el Momento Nominal", _
                                          "Momento de control de Daño(kN/m)", _
                                          "Curvatura de Control de Daño(1/m)", _
                                          "Coeficiente de Rigidez de Fexión Pos Fluencia", _
                                          "PROPIEDADES DE LOS MATERIALES", _
                                          "SECCIÓN", _
                                          "PROPIEDADES DE LA SECCIÓN", _
                                          "ANÁLISIS MOMENTO CURVATURA DE LA SECCIÓN: ", _
                                          """c"" es la profundidad del eje neutro" & Chr(13) & """ec"" es la deformación del concreto" & Chr(13) & """es"" es la deformación del acero" & Chr(13) & """Mv"" es la demanda de momento para desarrollar resistencia al corte calculada  con el modelo UCSD modificado" & Chr(13) & " Curvatura(1/m)	Momento (kN.m)	c (m)		ec		es		Mv(kN-m)", _
                                          "RC-Paramétrico" & Chr(13) & "Análisis Momento Curvatura de Secciones de Concreto Reforzado" & Chr(13) & "Autor: Vinicio Suarez, vasuarez@utpl.edu.ec" & Chr(13) & Chr(13) & "RESULTADOS DEL ANÁLISIS" & Chr(13)}, _
                                        {"Longitudinal steel ratio", _
                                          "transverse steel ratio", _
                                          "Axial Load Ratio", _
                                          "Moment of Inertia (taken from the slope of the bi-linear M-C diagram)(m^4)", _
                                          "Moment at first yield (kN-m)", _
                                          "Curvature at first yield(1/m)", _
                                          "Nominal moment strength(kN-m)", _
                                          "Nominal yield curvature(1/m)", _
                                          "Concrete strain at nominal moment strengh", _
                                          "Damage control moment(kN/m)", _
                                          "Damage control curvature(1/m)", _
                                          "Post yield flexural stiffness coefficient", _
                                          "MATERIAL PROPERTIES", _
                                          "SECTION", _
                                          "SECTION PROPERTIES", _
                                          "ANALYSIS MOMENT-CURVATURE SECCION: ", _
                                          """c"" is the neutral axis depth" & Chr(13) & """ec"" is the concrete strain" & Chr(13) & """es"" is the steel strain" & Chr(13) & """Mv"" is the moment demand to develop shear strength computed with the modified UCSD model" & Chr(13) & " Curvature(1/m)	Moment (kN.m)	c (m)		ec		es		Mv(kN-m)", _
                                          "RC-Parameter" & Chr(13) & "Moment Curvature Analysis of Reinforced Concrete Sections" & Chr(13) & "Author: Vinicio Suarez, vasuarez@utpl.edu.ec" & Chr(13) & Chr(13) & "ANALYSIS OUTPUT" & Chr(13)}}



            Result = etiquetasS(idIdioma, 17) & Chr(13) & Chr(13) & Chr(10)
            Result = Result + Chr(13) & etiquetasS(idIdioma, 12) & Chr(13)
            Result = Result + "======== ==========" & Chr(13)

            For i As Integer = 1 To 14
                Result = Result + etiquetas(idIdioma, i - 1) & Chr(13)
                For j As Integer = 1 To NumSections
                    Result = Result & etiquetasS(idIdioma, 13) & " " & j & Chr(9)
                Next
                Result = Result & Chr(13)
                For j As Integer = 1 To NumSections
                    Result = Result + CStr(Round(materialpropertiesR(i, j), 3)) & Chr(9)
                Next
                Result = Result + Chr(13)
            Next

            Result = Result + Chr(13) & etiquetasS(idIdioma, 14) & Chr(13)
            For i As Integer = 1 To 12
                Result = Result + etiquetasS(idIdioma, i - 1) & Chr(13)
                For j As Integer = 1 To NumSections
                    Result = Result & etiquetasS(idIdioma, 13) & " " & j & Chr(9)
                Next
                Result = Result & Chr(13)
                For j As Integer = 1 To NumSections
                    Result = Result + CStr(Round(sectionpropertiesR(i, j), 3)) & Chr(9)
                Next
                Result = Result + Chr(13)
            Next


            If NumSections >= 1 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "1" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz1(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 2 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "2" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz2(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 3 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "3" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz3(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 4 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "4" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz4(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 5 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "5" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz5(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 6 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "6" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz6(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 7 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "7" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz7(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 8 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "8" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz8(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections >= 9 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "9" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz9(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            If NumSections = 10 Then
                Result = Result + Chr(13) & Chr(13)
                Result = Result + etiquetasS(idIdioma, 15) & "10" & Chr(13) & Chr(10)
                Result = Result + etiquetasS(idIdioma, 16) & Chr(13) & Chr(10)
                For i As Integer = 1 To 50
                    Result = Result + CStr(Round(matriz10(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 6), 5)) & Chr(9)
                    Result = Result + Chr(13) & Chr(10)
                Next
            End If

            Me.txtresult.Text = Result
        End Sub

        Sub Figuras()
            Dim ten As Single
            Dim n As Single
            Dim rt As Single
            Dim eyd As Single
            Dim fiy As Single
            Dim Eicr As Single
            Dim Myy As Single
            Dim Icrig As Single
            Dim pn As Single
            Dim phiD As Single
            Dim eec As Single
            Dim avgecc As Single
            Dim rhoo As Single
            Dim avgphiD As Single
            Dim avgeec As Single
            Dim aa As Single
            Dim bb As Single


            ReDim figura1(NumSections, 4)
            'figura 1. Curvatura de fluencia
            'figura1(ey/D , phiy, tendencia)
            ten = 0
            For n = 1 To NumSections
                rt = sectionpropertiesR(14, n) / 1000
                eyd = materialpropertiesR(10, n) / (2 * rt)
                fiy = sectionpropertiesR(8, n)
                ten = ten + fiy / eyd
                figura1(n, 1) = eyd
                figura1(n, 2) = fiy
            Next
            ten = ten / NumSections
            For n = 1 To NumSections
                figura1(n, 3) = ten * figura1(n, 1)
            Next
            figura1(1, 4) = ten

            'figura 2. Relacion entre resistencia y rigidez
            'figura2(EIcr , My, tendencia)
            ReDim figura2(NumSections, 4)
            ten = 0
            For n = 1 To NumSections
                Eicr = sectionpropertiesR(4, n) * materialpropertiesR(1, n) * 1000 'kN.m^2
                Myy = sectionpropertiesR(7, n)
                ten = ten + Myy / Eicr
                figura2(n, 1) = Eicr
                figura2(n, 2) = Myy
            Next
            ten = ten / NumSections
            For n = 1 To NumSections
                figura2(n, 3) = ten * figura2(n, 1)
            Next
            figura2(1, 4) = ten

            'figura 3. Relacion entre Ig/Icr vs rho
            'figura3(rho , Ig/icr, tendencia)
            ReDim figura3(NumSections, 4)
            ten = 0
            For n = 1 To NumSections
                rt = sectionpropertiesR(14, n) / 1000
                Icrig = sectionpropertiesR(4, n) / (PI * (rt * 2) ^ 4 / 64)
                rhoo = sectionpropertiesR(1, n)
                ten = ten + Icrig / rhoo
                figura3(n, 2) = Icrig
                figura3(n, 1) = rhoo
            Next
            ten = ten / NumSections
            For n = 1 To NumSections
                figura3(n, 3) = ten * figura3(n, 1)
            Next
            figura3(1, 4) = ten

            'figura 4. Relacion entre ec vs dphi
            'figura4(Dphi , ec, tendencia)
            ReDim figura4(NumSections, 50, 4)
            ten = 0
            avgSlope = 0
            ptns = 0
            For n = 1 To NumSections
                rt = materialpropertiesR(14, n) / 1000
                For pn = 1 To 50
                    phiD = MCcurvesR(n, pn, 1) * (2 * rt)
                    eec = MCcurvesR(n, pn, 4)
                    If phiD > 0 Then avgSlope = avgSlope + (eec / phiD) : ptns = ptns + 1
                    figura4(n, pn, 1) = phiD
                    figura4(n, pn, 2) = eec
                Next
            Next
            avgSlope = avgSlope / ptns
            ten = avgSlope
            For pn = 1 To 50
                figura4(NumSections, pn, 3) = ten * figura4(NumSections, pn, 1)
            Next
            figura4(NumSections, 1, 4) = ten

            'figura 5. Relacion entre ec vs dphi
            'figura5(Dphi , ec, tendencia)
            ReDim figura5(NumSections, 50, 4)
            ten = 0
            avgSlope = 0
            ptns = 0
            For n = 1 To NumSections
                rt = materialpropertiesR(14, n) / 1000
                For pn = 1 To 50
                    phiD = MCcurvesR(n, pn, 1) * (2 * rt)
                    eec = MCcurvesR(n, pn, 5)
                    If phiD > 0 Then avgSlope = avgSlope + (eec / phiD) : ptns = ptns + 1
                    figura5(n, pn, 1) = phiD
                    figura5(n, pn, 2) = eec
                Next
            Next
            avgSlope = avgSlope / ptns
            ten = avgSlope
            For pn = 1 To 50
                figura5(NumSections, pn, 3) = ten * figura5(NumSections, pn, 1)
            Next
            figura5(NumSections, 1, 4) = ten

        End Sub

        Sub subGraficar()



            'GRAFICA MOMENTO CURVATURA
            'Arreglo de linea MC 
            Dim arrXLineMC(50) As Double
            Dim arrYLineMC(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal(2) As Double
            Dim arrYLineBilineal(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC(i) = CDbl(MCcurvesR(1, i, 1))
                arrYLineMC(i) = CDbl(MCcurvesR(1, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal(0) = 0
            arrYLineBilineal(0) = 0
            arrXLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 1))
            arrYLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 1))
            arrXLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 1))
            arrYLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 1))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC(48)
            ReDim Preserve arrYLineMC(48)
            'Linea mc
            If NumSections >= 1 Then
                Dim lineMC As LineLayer
                lineMC = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC, colores(1), "Section 1")
                lineMC.setXData(arrXLineMC)
                lineMC.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal As LineLayer
            lineBilineal = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal, colores(1))
            lineBilineal.setXData(arrXLineBilineal)
            lineBilineal.setLineWidth(2)


            'Grafica Número 2
            'Arreglo de linea MC 
            Dim arrXLineMC2(50) As Double
            Dim arrYLineMC2(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal2(2) As Double
            Dim arrYLineBilineal2(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC2(i) = CDbl(MCcurvesR(2, i, 1))
                arrYLineMC2(i) = CDbl(MCcurvesR(2, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal2(0) = 0
            arrYLineBilineal2(0) = 0
            arrXLineBilineal2(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 2))
            arrYLineBilineal2(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 2))
            arrXLineBilineal2(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 2))
            arrYLineBilineal2(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 2))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC2(48)
            ReDim Preserve arrYLineMC2(48)
            'Linea mc
            If NumSections >= 2 Then
                Dim lineMC2 As LineLayer
                lineMC2 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC2, colores(2), "Section 2")
                lineMC2.setXData(arrXLineMC2)
                lineMC2.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal2 As LineLayer
            lineBilineal2 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal2, colores(2))
            lineBilineal2.setXData(arrXLineBilineal2)
            lineBilineal2.setLineWidth(2)


            'Grafica Número 3
            'Arreglo de linea MC 
            Dim arrXLineMC3(50) As Double
            Dim arrYLineMC3(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal3(2) As Double
            Dim arrYLineBilineal3(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC3(i) = CDbl(MCcurvesR(3, i, 1))
                arrYLineMC3(i) = CDbl(MCcurvesR(3, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal3(0) = 0
            arrYLineBilineal3(0) = 0
            arrXLineBilineal3(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 3))
            arrYLineBilineal3(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 3))
            arrXLineBilineal3(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 3))
            arrYLineBilineal3(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 3))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC3(48)
            ReDim Preserve arrYLineMC3(48)
            'Linea mc
            If NumSections >= 3 Then
                Dim lineMC3 As LineLayer
                lineMC3 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC3, colores(3), "Section 3")
                lineMC3.setXData(arrXLineMC3)
                lineMC3.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal3 As LineLayer
            lineBilineal3 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal3, colores(3))
            lineBilineal3.setXData(arrXLineBilineal3)
            lineBilineal3.setLineWidth(2)


            'Grafica Número 4
            'Arreglo de linea MC 
            Dim arrXLineMC4(50) As Double
            Dim arrYLineMC4(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal4(2) As Double
            Dim arrYLineBilineal4(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC4(i) = CDbl(MCcurvesR(4, i, 1))
                arrYLineMC4(i) = CDbl(MCcurvesR(4, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal4(0) = 0
            arrYLineBilineal4(0) = 0
            arrXLineBilineal4(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 4))
            arrYLineBilineal4(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 4))
            arrXLineBilineal4(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 4))
            arrYLineBilineal4(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 4))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC4(48)
            ReDim Preserve arrYLineMC4(48)
            'Linea mc
            If NumSections >= 4 Then
                Dim lineMC4 As LineLayer
                lineMC4 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC4, colores(4), "Section 4")
                lineMC4.setXData(arrXLineMC4)
                lineMC4.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal4 As LineLayer
            lineBilineal4 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal4, colores(4))
            lineBilineal4.setXData(arrXLineBilineal4)
            lineBilineal4.setLineWidth(2)


            'Grafica Número 5
            'Arreglo de linea MC 
            Dim arrXLineMC5(50) As Double
            Dim arrYLineMC5(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal5(2) As Double
            Dim arrYLineBilineal5(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC5(i) = CDbl(MCcurvesR(5, i, 1))
                arrYLineMC5(i) = CDbl(MCcurvesR(5, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal5(0) = 0
            arrYLineBilineal5(0) = 0
            arrXLineBilineal5(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 5))
            arrYLineBilineal5(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 5))
            arrXLineBilineal5(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 5))
            arrYLineBilineal5(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 5))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC5(48)
            ReDim Preserve arrYLineMC5(48)
            'Linea mc
            If NumSections >= 5 Then
                Dim lineMC5 As LineLayer
                lineMC5 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC5, colores(5), "Section 5")
                lineMC5.setXData(arrXLineMC5)
                lineMC5.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal5 As LineLayer
            lineBilineal5 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal5, colores(5))
            lineBilineal5.setXData(arrXLineBilineal5)
            lineBilineal5.setLineWidth(2)


            'Grafica Número 6
            'Arreglo de linea MC 
            Dim arrXLineMC6(50) As Double
            Dim arrYLineMC6(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal6(2) As Double
            Dim arrYLineBilineal6(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC6(i) = CDbl(MCcurvesR(6, i, 1))
                arrYLineMC6(i) = CDbl(MCcurvesR(6, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal6(0) = 0
            arrYLineBilineal6(0) = 0
            arrXLineBilineal6(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 6))
            arrYLineBilineal6(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 6))
            arrXLineBilineal6(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 6))
            arrYLineBilineal6(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 6))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC6(48)
            ReDim Preserve arrYLineMC6(48)
            'Linea mc
            If NumSections >= 6 Then
                Dim lineMC6 As LineLayer
                lineMC6 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC6, colores(6), "Section 6")
                lineMC6.setXData(arrXLineMC6)
                lineMC6.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal6 As LineLayer
            lineBilineal6 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal6, colores(6))
            lineBilineal6.setXData(arrXLineBilineal6)
            lineBilineal6.setLineWidth(2)


            'Grafica Número 7
            'Arreglo de linea MC 
            Dim arrXLineMC7(50) As Double
            Dim arrYLineMC7(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal7(2) As Double
            Dim arrYLineBilineal7(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC7(i) = CDbl(MCcurvesR(7, i, 1))
                arrYLineMC7(i) = CDbl(MCcurvesR(7, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal7(0) = 0
            arrYLineBilineal7(0) = 0
            arrXLineBilineal7(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 7))
            arrYLineBilineal7(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 7))
            arrXLineBilineal7(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 7))
            arrYLineBilineal7(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 7))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC7(48)
            ReDim Preserve arrYLineMC7(48)
            'Linea mc
            If NumSections >= 7 Then
                Dim lineMC7 As LineLayer
                lineMC7 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC7, colores(7), "Section7")
                lineMC7.setXData(arrXLineMC7)
                lineMC7.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal7 As LineLayer
            lineBilineal7 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal7, colores(7))
            lineBilineal7.setXData(arrXLineBilineal7)
            lineBilineal7.setLineWidth(2)


            'Grafica Número 8
            'Arreglo de linea MC 
            Dim arrXLineMC8(50) As Double
            Dim arrYLineMC8(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal8(2) As Double
            Dim arrYLineBilineal8(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC8(i) = CDbl(MCcurvesR(8, i, 1))
                arrYLineMC8(i) = CDbl(MCcurvesR(8, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal8(0) = 0
            arrYLineBilineal8(0) = 0
            arrXLineBilineal8(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 8))
            arrYLineBilineal8(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 8))
            arrXLineBilineal8(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 8))
            arrYLineBilineal8(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 8))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC8(48)
            ReDim Preserve arrYLineMC8(48)
            'Linea mc
            If NumSections >= 8 Then
                Dim lineMC8 As LineLayer
                lineMC8 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC8, colores(8), "Section 8")
                lineMC8.setXData(arrXLineMC8)
                lineMC8.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal8 As LineLayer
            lineBilineal8 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal8, colores(8))
            lineBilineal8.setXData(arrXLineBilineal8)
            lineBilineal8.setLineWidth(2)

            'Grafica Número 9
            'Arreglo de linea MC 
            Dim arrXLineMC9(50) As Double
            Dim arrYLineMC9(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal9(2) As Double
            Dim arrYLineBilineal9(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC9(i) = CDbl(MCcurvesR(9, i, 1))
                arrYLineMC9(i) = CDbl(MCcurvesR(9, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal9(0) = 0
            arrYLineBilineal9(0) = 0
            arrXLineBilineal9(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 9))
            arrYLineBilineal9(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 9))
            arrXLineBilineal9(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 9))
            arrYLineBilineal9(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 9))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC9(48)
            ReDim Preserve arrYLineMC9(48)
            'Linea mc
            If NumSections >= 9 Then
                Dim lineMC9 As LineLayer
                lineMC9 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC9, colores(9), "Section 9")
                lineMC9.setXData(arrXLineMC9)
                lineMC9.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal9 As LineLayer
            lineBilineal9 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal9, colores(9))
            lineBilineal9.setXData(arrXLineBilineal9)
            lineBilineal9.setLineWidth(2)

            'Grafica Número 10
            'Arreglo de linea MC 
            Dim arrXLineMC10(50) As Double
            Dim arrYLineMC10(50) As Double
            ''Arreglo de linea Bilineal
            Dim arrXLineBilineal10(2) As Double
            Dim arrYLineBilineal10(2) As Double
            'Extraccion de coordenadas para MC
            For i As Integer = 1 To 50
                arrXLineMC10(i) = CDbl(MCcurvesR(10, i, 1))
                arrYLineMC10(i) = CDbl(MCcurvesR(10, i, 2))
            Next
            'Extraccion datos de linea Bilineal
            arrXLineBilineal10(0) = 0
            arrYLineBilineal10(0) = 0
            arrXLineBilineal10(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 10))
            arrYLineBilineal10(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 10))
            arrXLineBilineal10(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 10))
            arrYLineBilineal10(2) = CDbl(objVLEE_AMC.Return_sectionproperties(10, 10))
            'Redimensionamiento de coordenas de lineas MC 
            ReDim Preserve arrXLineMC10(48)
            ReDim Preserve arrYLineMC10(48)
            'Linea mc
            If NumSections >= 10 Then
                Dim lineMC10 As LineLayer
                lineMC10 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineMC10, colores(10), "Section 10")
                lineMC10.setXData(arrXLineMC10)
                lineMC10.setLineWidth(2)
            End If

            'Linea bilineal
            Dim lineBilineal10 As LineLayer
            lineBilineal10 = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrYLineBilineal10, colores(10))
            lineBilineal10.setXData(arrXLineBilineal10)
            lineBilineal10.setLineWidth(2)

            'Creacion de imagen
            WebChartViewer1.Image = XYChart_Grafica_MomentoCurvatura.makeWebImage(Chart.PNG)
        End Sub

        Sub grafica2()
            'Arreglo de linea Tendencia 
            Dim arrXLineTendencia(50) As Double
            Dim arrYLineTendencia(50) As Double
            ''Arreglo de lineas de secciones
            Dim arrXLineSection1(1) As Double
            Dim arrYLineSection1(1) As Double
            Dim arrXLineSection2(1) As Double
            Dim arrYLineSection2(1) As Double
            Dim arrXLineSection3(1) As Double
            Dim arrYLineSection3(1) As Double
            Dim arrXLineSection4(1) As Double
            Dim arrYLineSection4(1) As Double
            Dim arrXLineSection5(1) As Double
            Dim arrYLineSection5(1) As Double
            Dim arrXLineSection6(1) As Double
            Dim arrYLineSection6(1) As Double
            Dim arrXLineSection7(1) As Double
            Dim arrYLineSection7(1) As Double
            Dim arrXLineSection8(1) As Double
            Dim arrYLineSection8(1) As Double
            Dim arrXLineSection9(1) As Double
            Dim arrYLineSection9(1) As Double
            Dim arrXLineSection10(1) As Double
            Dim arrYLineSection10(1) As Double

            'Extraccion de coordenadas para section 1 to NumSections
            arrXLineSection1(1) = CDbl(figura1(1, 1))
            arrYLineSection1(1) = CDbl(figura1(1, 2))
            arrXLineSection2(1) = CDbl(figura1(2, 1))
            arrYLineSection2(1) = CDbl(figura1(2, 2))
            arrXLineSection3(1) = CDbl(figura1(3, 1))
            arrYLineSection3(1) = CDbl(figura1(3, 2))

            Dim intColorFondoFormulasGraficas As Integer = &HD6DAFF

            ' -------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
            ' -------------------------------------------------------------------------------
            'LEYENDAS DEL GRÁFICO NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA"  
            Dim legendBox_EstimCurvaturaFluencia As LegendBox = XYChart_Grafica_EstimCurvaturaFluencia.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 60, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox_EstimCurvaturaFluencia.setBackground(Chart.Transparent)
            'Coeficiente de Relacion
            Dim txtBox_GraficaEstimCurvaturaFluencia As ChartDirector.TextBox = XYChart_Grafica_EstimCurvaturaFluencia.addText(140, 5, "<*block*>φ<*sub*>y<*/*> = " & FormatNumber(figura1(1, 4), 4) & "<*block*><*size=13*> ε<*sub*>y<*/*> / D", "", 11, &H0)
            txtBox_GraficaEstimCurvaturaFluencia.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            'DATOS PARA GRAFICAR
            Dim arrayDatosGraficaEstimCurvaturaFluenciaX(NumSections) As Double
            Dim arrayDatosGraficaEstimCurvaturaFluenciaY(NumSections) As Double
            Dim arrayEstimCurvaturaFluenciaLineaTenciaX(NumSections) As Double
            Dim arrayEstimCurvaturaFluenciaLineaTenciaY(NumSections) As Double
            arrayEstimCurvaturaFluenciaLineaTenciaX(0) = 0
            arrayEstimCurvaturaFluenciaLineaTenciaY(0) = 0
            ' --------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
            ' --------------------------------------------------------------------------------
            'LEYENDAS DEL GRÁFICO NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ"  
            Dim legendBox_ResistenciaRigidez As LegendBox = XYChart_Grafica_ResistenciaRigidez.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox_ResistenciaRigidez.setBackground(Chart.Transparent)
            'Coeficiente de Relacion
            Dim txtBox_GraficaResistenciaRigidez As ChartDirector.TextBox = XYChart_Grafica_ResistenciaRigidez.addText(170, 5, "<*block*>M<*sub*>y<*/*> = " & FormatNumber(figura2(1, 4), 4) & " El<*sub*>cr<*/*>", "", 11)
            txtBox_GraficaResistenciaRigidez.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            Dim arrayDatosGraficaResistenciaRigidezX(NumSections) As Double
            Dim arrayDatosGraficaResistenciaRigidezY(NumSections) As Double
            'DATOS PARA GRAFICAR
            Dim arrayResistenciaRigidezLineaTenciaX(NumSections) As Double
            Dim arrayResistenciaRigidezLineaTenciaY(NumSections) As Double
            arrayResistenciaRigidezLineaTenciaX(0) = 0
            arrayResistenciaRigidezLineaTenciaY(0) = 0
            ' --------------------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
            ' --------------------------------------------------------------------------------------------------------------------
            'LEYENDAS DEL GRÁFICO NÚMERO#4 "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            Dim legendBox_InerciaGruesa_Agrietada As LegendBox = XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox_InerciaGruesa_Agrietada.setBackground(Chart.Transparent)
            'Coeficiente de Relacion
            Dim txtBox_GraficaInerciaGruesa_Agrietada As ChartDirector.TextBox = XYChart_Grafica_InerciaGruesa_Agrietada.addText(140, 5, "<*block*>Icr/Ig = " & FormatNumber(figura3(1, 4), 4) & " ρ + " & FormatNumber(0.0, 4), "", 11)
            txtBox_GraficaInerciaGruesa_Agrietada.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            'DATOS PARA GRAFICAS
            Dim arrayDatosGraficaInerciaGruesa_AgrietadaX(NumSections) As Double
            Dim arrayDatosGraficaInerciaGruesa_AgrietadaY(NumSections) As Double
            Dim arrayInerciaGruesa_AgrietadaLineaTenciaX(NumSections) As Double
            Dim arrayInerciaGruesa_AgrietadaLineaTenciaY(NumSections) As Double
            arrayInerciaGruesa_AgrietadaLineaTenciaX(0) = 0
            arrayInerciaGruesa_AgrietadaLineaTenciaY(0) = 0
            ' --------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
            ' --------------------------------------------------------------------------------------------------------
            'LEYENDAS DEL GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA"
            Dim legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.setBackground(Chart.Transparent)
            'Coeficiente de Relacion
            Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addText(120, 5, "<*block*><*size=13*> ε<*sub*>c<*/*> = " & FormatNumber(figura4(NumSections, 1, 4), 4) & " DΦ ", "", 11)
            txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            'DATOS PARA GRAFICAS
            Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(0) = 0
            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(0) = 0
            ' ------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
            ' ------------------------------------------------------------------------------------------------------
            'LEYENDAS DEL GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA"
            Dim legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES.setBackground(Chart.Transparent)
            'Coeficiente de Relacion
            Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addText(120, 5, "<*block*><*size=13*> ε<*sub*>s<*/*> = " & FormatNumber(figura5(NumSections, 1, 4), 4) & " DΦ ", "", 11)
            txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            'DATOS PARA GRAFICAS
            Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(0) = 0
            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(0) = 0

            'GRAFICA LOS PUNTOS PARA TODAS LAS FIGURAS
            For i As Integer = 1 To NumSections  'nsections
                ' -------------------------------------------------------------------------------
                '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
                ' -------------------------------------------------------------------------------
                'Datos Linea de Tendencia
                arrayEstimCurvaturaFluenciaLineaTenciaX(i) = figura1(i, 1)
                arrayEstimCurvaturaFluenciaLineaTenciaY(i) = figura1(i, 3)
                'Coordenadas Puntos
                arrayDatosGraficaEstimCurvaturaFluenciaX(i) = figura1(i, 1)
                arrayDatosGraficaEstimCurvaturaFluenciaY(i) = figura1(i, 2)
                Dim scatterLayerGraficaEstimacionCurvaturaFluencia As ScatterLayer
                scatterLayerGraficaEstimacionCurvaturaFluencia = XYChart_Grafica_EstimCurvaturaFluencia.addScatterLayer(arrayDatosGraficaEstimCurvaturaFluenciaX, arrayDatosGraficaEstimCurvaturaFluenciaY, "Section " & i, Chart.DotDashLine, 7, colores(i))
                ' --------------------------------------------------------------------------------
                '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
                ' --------------------------------------------------------------------------------
                'Datos Linea de Tendencia
                arrayResistenciaRigidezLineaTenciaX(i) = figura2(i, 1)
                arrayResistenciaRigidezLineaTenciaY(i) = figura2(i, 3)
                'Coordenadas Puntos
                arrayDatosGraficaResistenciaRigidezX(i) = figura2(i, 1)
                arrayDatosGraficaResistenciaRigidezY(i) = figura2(i, 2)
                Dim scatterLayerGraficaResistenciaRigidez As ScatterLayer
                scatterLayerGraficaResistenciaRigidez = XYChart_Grafica_ResistenciaRigidez.addScatterLayer(arrayDatosGraficaResistenciaRigidezX, arrayDatosGraficaResistenciaRigidezY, "Section " & i, Chart.DotDashLine, 7, colores(i))
                ' --------------------------------------------------------------------------------------------------------------------
                '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
                ' --------------------------------------------------------------------------------------------------------------------
                'Datos Linea de Tendencia
                arrayInerciaGruesa_AgrietadaLineaTenciaX(i) = figura3(i, 1)
                arrayInerciaGruesa_AgrietadaLineaTenciaY(i) = figura3(i, 3)
                'Coordenadas Puntos
                arrayDatosGraficaInerciaGruesa_AgrietadaX(i) = figura3(i, 1)
                arrayDatosGraficaInerciaGruesa_AgrietadaY(i) = figura3(i, 2)
                Dim scatterLayerGraficaInerciaGruesa_Agrietada As ScatterLayer
                scatterLayerGraficaInerciaGruesa_Agrietada = XYChart_Grafica_InerciaGruesa_Agrietada.addScatterLayer(arrayDatosGraficaInerciaGruesa_AgrietadaX, arrayDatosGraficaInerciaGruesa_AgrietadaY, "Section " & i, Chart.DotDashLine, 7, colores(i))
                ' --------------------------------------------------------------------------------------------------------
                '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
                ' --------------------------------------------------------------------------------------------------------
                'Coordenadas Puntos
                For j As Integer = 1 To 50  'nsections  
                    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(j) = figura4(i, j, 1)
                    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(j) = figura4(i, j, 2)
                    arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(j) = figura4(NumSections, j, 1)
                    arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(j) = figura4(NumSections, j, 3)
                Next
                Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC As LineLayer 'Se gráfica con el conjunto de los 50 Datos
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, colores(i))
                legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.addKey("Section " & i, colores(i))
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC.setXData(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC)
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC.setLineWidth(1)
                ' ------------------------------------------------------------------------------------------------------
                '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
                ' ------------------------------------------------------------------------------------------------------
                'Coordenadas Puntos
                For k As Integer = 1 To 50  'nsections  
                    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(k) = figura5(i, k, 1)
                    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(k) = figura5(i, k, 2)
                    arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(k) = figura5(NumSections, k, 1)
                    arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(k) = figura5(NumSections, k, 3)
                Next
                Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES As LineLayer 'Se gráfica con el conjunto de los 50 Datos
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES, colores(i))
                legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES.addKey("Section " & i, colores(i))
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES.setXData(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES)
                linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES.setLineWidth(1)
            Next

            ' -------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
            ' -------------------------------------------------------------------------------
            'AGREGA DE LA LINEA DE TENDENCIA 
            Dim lineTendenciaEstimacionCurvaturaFluencia As LineLayer
            lineTendenciaEstimacionCurvaturaFluencia = XYChart_Grafica_EstimCurvaturaFluencia.addLineLayer(arrayEstimCurvaturaFluenciaLineaTenciaY, colores(0))
            lineTendenciaEstimacionCurvaturaFluencia.setXData(arrayEstimCurvaturaFluenciaLineaTenciaX)
            lineTendenciaEstimacionCurvaturaFluencia.setLineWidth(2)
            ' --------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
            ' --------------------------------------------------------------------------------
            'AGREGA DE LA LINEA DE TENDENCIA 
            Dim lineTendenciaResistenciaRigidez As LineLayer
            lineTendenciaResistenciaRigidez = XYChart_Grafica_ResistenciaRigidez.addLineLayer(arrayResistenciaRigidezLineaTenciaY, colores(0))
            lineTendenciaResistenciaRigidez.setXData(arrayResistenciaRigidezLineaTenciaX)
            lineTendenciaResistenciaRigidez.setLineWidth(2)
            ' --------------------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
            ' --------------------------------------------------------------------------------------------------------------------
            'AGREGA DE LA LINEA DE TENDENCIA 
            Dim lineTendenciaInerciaGruesa_AgrietadaLineaTencia As LineLayer
            lineTendenciaInerciaGruesa_AgrietadaLineaTencia = XYChart_Grafica_InerciaGruesa_Agrietada.addLineLayer(arrayInerciaGruesa_AgrietadaLineaTenciaY, colores(0))
            lineTendenciaInerciaGruesa_AgrietadaLineaTencia.setXData(arrayInerciaGruesa_AgrietadaLineaTenciaX)
            lineTendenciaInerciaGruesa_AgrietadaLineaTencia.setLineWidth(2)
            ' --------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
            ' --------------------------------------------------------------------------------------------------------
            'AGREGA DE LA LINEA DE TENDENCIA 
            Dim lineTendenciaDeformacionUnitaria_Concreto_Curvatura As LineLayer
            lineTendenciaDeformacionUnitaria_Concreto_Curvatura = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, colores(0))
            lineTendenciaDeformacionUnitaria_Concreto_Curvatura.setXData(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC)
            lineTendenciaDeformacionUnitaria_Concreto_Curvatura.setLineWidth(3)
            ' ------------------------------------------------------------------------------------------------------
            '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
            ' ------------------------------------------------------------------------------------------------------
            'AGREGA DE LA LINEA DE TENDENCIA 
            'arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES
            Dim lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1 As LineLayer
            lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1 = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES, colores(0))
            lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1.setXData(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES)
            lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1.setLineWidth(3)

            subCrearWebChartViewer()

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Request.IsAuthenticated = True Then
            '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
            establecerPropCtrlGraficos()
                If Not Page.IsPostBack Then
                    'objVLEE_AMC = New VLEE_AMC150.VLEE_AMC150_CMain
                    subCrearWebChartViewer()
                End If
                subAsignarIdiomaACtrls()
            'Else
            '    getIdioma = Request.Params("idioma")
            '    Response.BufferOutput = True
            '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
            'End If
        End Sub

        Protected Sub btnCargarEjemplo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarEjemplo.Click
            CargarEjemplo()
            subCrearWebChartViewer()
        End Sub


        Protected Sub txtresult_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtresult.TextChanged

        End Sub
    End Class
End Namespace

