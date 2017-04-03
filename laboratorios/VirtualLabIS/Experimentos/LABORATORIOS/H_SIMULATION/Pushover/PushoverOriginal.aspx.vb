Imports System.IO
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


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_Pushover_Pushover
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}
        Dim arrTextoEjes(,) As String = {{"DESPLAZAMIENTO", _
                                                          "DEFORMACIÓN ARRIBA", _
                                                          "DEFORMACION ABAJO", _
                                                          "DCR ARRIBA", _
                                                          "DCR ABAJO", _
                                                          "MOMENTO", _
                                                          "CURVATURA", _
                                                          "CORTE", _
                                                          "AXIAL", _
                                                          "INCREMENTO DE FUERZA"}, _
                                                        {"DISPLACEMENT", _
                                                          "STRAIN TOP", _
                                                          "STRAIN BOTTOM", _
                                                          "DCR TOP", _
                                                          "DCR BOTTOM", _
                                                          "MOMENT", _
                                                          "CURVATURE", _
                                                          "SHEAR", _
                                                          "AXIAL", _
                                                          "FORCE INCREMENT"}}
#End Region

#Region "Variables Globales"
        'MATENIMIENTO
        'Private Shared obj_Push As New Pushover
        'END MATENIMIENTO

        Private objFacade As Facade.VirtualLabIS.Facade.Columna.IColumna = New Facade.VirtualLabIS.Facade.Columna.Columna
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

        'GRAFICAS DE VIGAS
        Dim XYChart_Grafica_Pushover As XYChart = New XYChart(480, 390 - 90, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim XYChart_Grafica_StrainLeftEndTopBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_StrainLeftEndBottomBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_StrainRightEndTopBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_StrainRightEndBottomBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRLeftEndTopBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRLeftEndBottomBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRRightEndTopBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRRightEndBottom As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_MomentLeftEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_CurvatureLeftEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_MomentRightEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_CurvatureRightEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_ShearLeftEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_AxialLeftEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_ShearRightEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_AxialRightEndBeams As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico


        'GRAFICAS DE COLUMNAS
        Dim XYChart_Grafica_StrainLeftEndTopColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_StrainLeftEndBottomColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_StrainRightEndTopColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_StrainRightEndBottomColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRLeftEndTopColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRLeftEndBottomColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRRightEndTopColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_DCRRightEndBottomColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_MomentLeftEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_CurvatureLeftEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_MomentRightEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_CurvatureRightEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_ShearLeftEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_AxialLeftEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_ShearRightEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_AxialRightEndColumns As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico


        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Dim intAddLegend_Coord_x As Integer = 315
        Dim intAddLegend_Coord_y As Integer = 5
        Dim bolAddLegend_Bool As Boolean = False
        Dim strAddLegend_Font As String = "Arial Rounded MT Bold"
        Dim intAddLegend_FontSize As Integer = 8
        Shared getIdioma As String
        Dim graficaMC(50, 2) As Single


        Dim beamatrix(4, 8) As Object
        Dim cells(,) As Object
        Dim forcedisp(,) As Object
        Dim beamresponse(,,) As Object
        Dim colresponse(,,) As Object

        Dim pushover(6) As Object
        Dim materials(3) As Object
        Dim vectorx(3) As Object
        Dim vectory(3) As Object
        Dim colmatrix(6, 4) As Object
        Dim targetdisp As Single
        Dim nxaxes As Single
        Dim nzlevels As Single
        Dim ncols As Single
        Dim nvigas As Single
        Dim lateralpattern As String

        'Shared arrayDatosGraficaEstimCurvaturaFluenciaX As Double()
        'Shared arrayDatosGraficaEstimCurvaturaFluenciaY As Double()
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

            WebChartViewerPushover.Image = XYChart_Grafica_Pushover.makeWebImage(Chart.PNG)

            'GRAFICAS VIGAS
            WebChartViewerPushover.Image = XYChart_Grafica_Pushover.makeWebImage(Chart.PNG)
            WebChar11.Image = XYChart_Grafica_StrainLeftEndTopBeams.makeWebImage(Chart.PNG)
            WebChart12.Image = XYChart_Grafica_StrainLeftEndBottomBeams.makeWebImage(Chart.PNG)
            WebChart13.Image = XYChart_Grafica_StrainRightEndTopBeams.makeWebImage(Chart.PNG)
            WebChart14.Image = XYChart_Grafica_StrainRightEndBottomBeams.makeWebImage(Chart.PNG)
            WebChart21.Image = XYChart_Grafica_DCRLeftEndTopBeams.makeWebImage(Chart.PNG)
            WebChart22.Image = XYChart_Grafica_DCRLeftEndBottomBeams.makeWebImage(Chart.PNG)
            WebChart23.Image = XYChart_Grafica_DCRRightEndTopBeams.makeWebImage(Chart.PNG)
            WebChart24.Image = XYChart_Grafica_DCRRightEndBottom.makeWebImage(Chart.PNG)
            WebChart31.Image = XYChart_Grafica_MomentLeftEndBeams.makeWebImage(Chart.PNG)
            WebChart32.Image = XYChart_Grafica_CurvatureLeftEndBeams.makeWebImage(Chart.PNG)
            WebChart33.Image = XYChart_Grafica_MomentRightEndBeams.makeWebImage(Chart.PNG)
            WebChart34.Image = XYChart_Grafica_CurvatureRightEndBeams.makeWebImage(Chart.PNG)
            WebChart41.Image = XYChart_Grafica_ShearLeftEndBeams.makeWebImage(Chart.PNG)
            WebChart42.Image = XYChart_Grafica_AxialLeftEndBeams.makeWebImage(Chart.PNG)
            WebChart43.Image = XYChart_Grafica_ShearRightEndBeams.makeWebImage(Chart.PNG)
            WebChart44.Image = XYChart_Grafica_AxialRightEndBeams.makeWebImage(Chart.PNG)

            'GRAFICAS COLUMNAS
            WebChartC11.Image = XYChart_Grafica_StrainLeftEndTopColumns.makeWebImage(Chart.PNG)
            WebChartC12.Image = XYChart_Grafica_StrainLeftEndBottomColumns.makeWebImage(Chart.PNG)
            WebChartC13.Image = XYChart_Grafica_StrainRightEndTopColumns.makeWebImage(Chart.PNG)
            WebChartC14.Image = XYChart_Grafica_StrainRightEndBottomColumns.makeWebImage(Chart.PNG)
            WebChartC21.Image = XYChart_Grafica_DCRLeftEndTopColumns.makeWebImage(Chart.PNG)
            WebChartC22.Image = XYChart_Grafica_DCRLeftEndBottomColumns.makeWebImage(Chart.PNG)
            WebChartC23.Image = XYChart_Grafica_DCRRightEndTopColumns.makeWebImage(Chart.PNG)
            WebChartC24.Image = XYChart_Grafica_DCRRightEndBottomColumns.makeWebImage(Chart.PNG)
            WebChartC31.Image = XYChart_Grafica_MomentLeftEndColumns.makeWebImage(Chart.PNG)
            WebChartC32.Image = XYChart_Grafica_CurvatureLeftEndColumns.makeWebImage(Chart.PNG)
            WebChartC33.Image = XYChart_Grafica_MomentRightEndColumns.makeWebImage(Chart.PNG)
            WebChartC34.Image = XYChart_Grafica_CurvatureRightEndColumns.makeWebImage(Chart.PNG)
            WebChartC41.Image = XYChart_Grafica_ShearLeftEndColumns.makeWebImage(Chart.PNG)
            WebChartC42.Image = XYChart_Grafica_AxialLeftEndColumns.makeWebImage(Chart.PNG)
            WebChartC43.Image = XYChart_Grafica_ShearRightEndColumns.makeWebImage(Chart.PNG)
            WebChartC44.Image = XYChart_Grafica_AxialRightEndColumns.makeWebImage(Chart.PNG)
        End Sub


        Private Sub establecerPropCtrlGraficos()

            Dim intColorFondoFormulasGraficas As Integer = &HD6DAFF

            ' GRÁFICA NÚMERO#1   "Pushover"
            CrearGraficasXYChart(60, 10, 300, 250, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 9), "Arial Bold", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 9, 0, 3, XYChart_Grafica_Pushover)
            legendBox = XYChart_Grafica_Pushover.addLegend(380, 60, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent)

            ' GRÁFICA NÚMERO#2   "STRAIN LEFT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainLeftEndTopBeams)
            XYChart_Grafica_StrainLeftEndTopBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica1 As ChartDirector.TextBox = XYChart_Grafica_StrainLeftEndTopBeams.addText(130, 3, "TOP STRAIN", "", 10)
            txtBox_NombreGráfica1.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            '' GRÁFICA NÚMERO#3   "STRAIN LEFT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainLeftEndBottomBeams)
            XYChart_Grafica_StrainLeftEndBottomBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica2 As ChartDirector.TextBox = XYChart_Grafica_StrainLeftEndBottomBeams.addText(130, 3, "BOTTOM STRAIN", "", 10)
            txtBox_NombreGráfica2.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#4   "STRAIN RIGHT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainRightEndTopBeams)
            XYChart_Grafica_StrainRightEndTopBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica3 As ChartDirector.TextBox = XYChart_Grafica_StrainRightEndTopBeams.addText(130, 3, "TOP STRAIN", "", 10)
            txtBox_NombreGráfica3.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICA NÚMERO#5 "STRAIN RIGHT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainRightEndBottomBeams)
            XYChart_Grafica_StrainRightEndBottomBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica4 As ChartDirector.TextBox = XYChart_Grafica_StrainRightEndBottomBeams.addText(130, 3, "BOTTOM STRAIN", "", 10)
            txtBox_NombreGráfica4.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICA NÚMERO#6 "DCR LEFT END TOP BEAMS"      
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRLeftEndTopBeams)
            XYChart_Grafica_DCRLeftEndTopBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica5 As ChartDirector.TextBox = XYChart_Grafica_DCRLeftEndTopBeams.addText(130, 3, "TOP DCR", "", 10)
            txtBox_NombreGráfica5.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#7 "DCR LEFT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRLeftEndBottomBeams)
            XYChart_Grafica_DCRLeftEndBottomBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica6 As ChartDirector.TextBox = XYChart_Grafica_DCRLeftEndBottomBeams.addText(130, 3, "BOTTOM DCR", "", 10)
            txtBox_NombreGráfica6.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#8 "DCR RIGHT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRRightEndTopBeams)
            XYChart_Grafica_DCRRightEndTopBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica7 As ChartDirector.TextBox = XYChart_Grafica_DCRRightEndTopBeams.addText(130, 3, "TOP DCR", "", 10)
            txtBox_NombreGráfica7.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#9 "DCR RIGHT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRRightEndBottom)
            XYChart_Grafica_DCRRightEndBottom.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica8 As ChartDirector.TextBox = XYChart_Grafica_DCRRightEndBottom.addText(130, 3, "BOTTOM DCR", "", 10)
            txtBox_NombreGráfica8.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#10 "MOMENT LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 5), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_MomentLeftEndBeams)
            XYChart_Grafica_MomentLeftEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica9 As ChartDirector.TextBox = XYChart_Grafica_MomentLeftEndBeams.addText(130, 3, "MOMENT", "", 10)
            txtBox_NombreGráfica9.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#11 "CURVATURE LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 6), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_CurvatureLeftEndBeams)
            XYChart_Grafica_CurvatureLeftEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica10 As ChartDirector.TextBox = XYChart_Grafica_CurvatureLeftEndBeams.addText(130, 3, "CURVATURE", "", 10)
            txtBox_NombreGráfica10.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#12 "MOMENT RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 5), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_MomentRightEndBeams)
            XYChart_Grafica_MomentRightEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica11 As ChartDirector.TextBox = XYChart_Grafica_MomentRightEndBeams.addText(130, 3, "MOMENT", "", 10)
            txtBox_NombreGráfica11.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#13 "CURVATURE RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 6), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_CurvatureRightEndBeams)
            XYChart_Grafica_CurvatureRightEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica12 As ChartDirector.TextBox = XYChart_Grafica_CurvatureRightEndBeams.addText(130, 3, "CURVATURE", "", 10)
            txtBox_NombreGráfica12.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#14 "SHEAR LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 7), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_ShearLeftEndBeams)
            XYChart_Grafica_ShearLeftEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica13 As ChartDirector.TextBox = XYChart_Grafica_ShearLeftEndBeams.addText(130, 3, "SHEAR", "", 10)
            txtBox_NombreGráfica13.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#15 "AXIAL LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 8), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_AxialLeftEndBeams)
            XYChart_Grafica_AxialLeftEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica14 As ChartDirector.TextBox = XYChart_Grafica_AxialLeftEndBeams.addText(130, 3, "AXIAL", "", 10)
            txtBox_NombreGráfica14.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#16 "SHEAR RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 7), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_ShearRightEndBeams)
            XYChart_Grafica_ShearRightEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica15 As ChartDirector.TextBox = XYChart_Grafica_ShearRightEndBeams.addText(130, 3, "SHEAR", "", 10)
            txtBox_NombreGráfica15.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#17 "AXIAL RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 8), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_AxialRightEndBeams)
            XYChart_Grafica_AxialRightEndBeams.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica16 As ChartDirector.TextBox = XYChart_Grafica_AxialRightEndBeams.addText(130, 3, "AXIAL", "", 10)
            txtBox_NombreGráfica16.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)



            'GRAFICAS DE COLUMNAS
            ' GRÁFICA NÚMERO#18   "STRAIN LEFT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainLeftEndTopColumns)
            XYChart_Grafica_StrainLeftEndTopColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica21 As ChartDirector.TextBox = XYChart_Grafica_StrainLeftEndTopColumns.addText(130, 3, "TOP STRAIN", "", 10)
            txtBox_NombreGráfica21.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            '' GRÁFICA NÚMERO#19   "STRAIN LEFT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainLeftEndBottomColumns)
            XYChart_Grafica_StrainLeftEndBottomColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica22 As ChartDirector.TextBox = XYChart_Grafica_StrainLeftEndBottomColumns.addText(130, 3, "BOTTOM STRAIN", "", 10)
            txtBox_NombreGráfica22.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#20   "STRAIN RIGHT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainRightEndTopColumns)
            XYChart_Grafica_StrainRightEndTopColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica23 As ChartDirector.TextBox = XYChart_Grafica_StrainRightEndTopColumns.addText(130, 3, "TOP STRAIN", "", 10)
            txtBox_NombreGráfica23.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICA NÚMERO#21 "STRAIN RIGHT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_StrainRightEndBottomColumns)
            XYChart_Grafica_StrainRightEndBottomColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica24 As ChartDirector.TextBox = XYChart_Grafica_StrainRightEndBottomColumns.addText(130, 3, "BOTTOM STRAIN", "", 10)
            txtBox_NombreGráfica24.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICA NÚMERO#22 "DCR LEFT END TOP BEAMS"      
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRLeftEndTopColumns)
            XYChart_Grafica_DCRLeftEndTopColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica25 As ChartDirector.TextBox = XYChart_Grafica_DCRLeftEndTopColumns.addText(130, 3, "TOP DCR", "", 10)
            txtBox_NombreGráfica25.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#23 "DCR LEFT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRLeftEndBottomColumns)
            XYChart_Grafica_DCRLeftEndBottomColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica26 As ChartDirector.TextBox = XYChart_Grafica_DCRLeftEndBottomColumns.addText(130, 3, "BOTTOM DCR", "", 10)
            txtBox_NombreGráfica26.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#24 "DCR RIGHT END TOP BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRRightEndTopColumns)
            XYChart_Grafica_DCRRightEndTopColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica27 As ChartDirector.TextBox = XYChart_Grafica_DCRRightEndTopColumns.addText(130, 3, "TOP DCR", "", 10)
            txtBox_NombreGráfica27.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#25 "DCR RIGHT END BOTTOM BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_DCRRightEndBottomColumns)
            XYChart_Grafica_DCRRightEndBottomColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica28 As ChartDirector.TextBox = XYChart_Grafica_DCRRightEndBottomColumns.addText(130, 3, "BOTTOM DCR", "", 10)
            txtBox_NombreGráfica28.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#26 "MOMENT LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 5), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_MomentLeftEndColumns)
            XYChart_Grafica_MomentLeftEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica29 As ChartDirector.TextBox = XYChart_Grafica_MomentLeftEndColumns.addText(130, 3, "MOMENT", "", 10)
            txtBox_NombreGráfica29.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#27 "CURVATURE LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 6), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_CurvatureLeftEndColumns)
            XYChart_Grafica_CurvatureLeftEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica210 As ChartDirector.TextBox = XYChart_Grafica_CurvatureLeftEndColumns.addText(130, 3, "CURVATURE", "", 10)
            txtBox_NombreGráfica210.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#28 "MOMENT RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 5), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_MomentRightEndColumns)
            XYChart_Grafica_MomentRightEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica211 As ChartDirector.TextBox = XYChart_Grafica_MomentRightEndColumns.addText(130, 3, "MOMENT", "", 10)
            txtBox_NombreGráfica211.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#29 "CURVATURE RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 6), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_CurvatureRightEndColumns)
            XYChart_Grafica_CurvatureRightEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica212 As ChartDirector.TextBox = XYChart_Grafica_CurvatureRightEndColumns.addText(130, 3, "CURVATURE", "", 10)
            txtBox_NombreGráfica212.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#30 "SHEAR LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 7), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_ShearLeftEndColumns)
            XYChart_Grafica_ShearLeftEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica213 As ChartDirector.TextBox = XYChart_Grafica_ShearLeftEndColumns.addText(130, 3, "SHEAR", "", 10)
            txtBox_NombreGráfica213.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)

            ' GRÁFICO NÚMERO#31 "AXIAL LEFT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 8), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_AxialLeftEndColumns)
            XYChart_Grafica_AxialLeftEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica214 As ChartDirector.TextBox = XYChart_Grafica_AxialLeftEndColumns.addText(130, 3, "AXIAL", "", 10)
            txtBox_NombreGráfica214.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#32 "SHEAR RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 7), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_ShearRightEndColumns)
            XYChart_Grafica_ShearRightEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica215 As ChartDirector.TextBox = XYChart_Grafica_ShearRightEndColumns.addText(130, 3, "SHEAR", "", 10)
            txtBox_NombreGráfica215.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)


            ' GRÁFICO NÚMERO#33 "AXIAL RIGHT END BEAMS"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Arial Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 8), "Arial Bold", 8, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold", 8, 0, 3, XYChart_Grafica_AxialRightEndColumns)
            XYChart_Grafica_AxialRightEndColumns.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            Dim txtBox_NombreGráfica216 As ChartDirector.TextBox = XYChart_Grafica_AxialRightEndColumns.addText(130, 3, "AXIAL", "", 10)
            txtBox_NombreGráfica216.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)



        End Sub



#End Region

        Protected Overrides Sub InitializeCulture()
            'Asignación del idioma del experimento
            getIdioma = Request.Params("idioma")
            'Establece el idioma en los controles de los experimentos
            If getIdioma = "es-ES" Then
                idIdioma = 0
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES")
                'Este codigo es para mantener el punto como separador de decimales
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
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


            btnCargarEjemplo.Text = GetLocalResourceObject("btnCargarEjemplo.Text").ToString()
            btnGraficar.Text = GetLocalResourceObject("btnGraficar.Text").ToString()
            btnGraficarColumnas.Text = GetLocalResourceObject("btnGraficarColumnas.Text").ToString()
            btnGraficarVigas.Text = GetLocalResourceObject("btnGraficarVigas.Text").ToString()
            cbBeam1.Text = GetLocalResourceObject("cbBeam1.Text").ToString()
            cbBeam2.Text = GetLocalResourceObject("cbBeam2.Text").ToString()
            cbBeam3.Text = GetLocalResourceObject("cbBeam3.Text").ToString()
            cbBeam4.Text = GetLocalResourceObject("cbBeam4.Text").ToString()
            cbColumn1.Text = GetLocalResourceObject("cbColumn1.Text").ToString()
            cdColumn2.Text = GetLocalResourceObject("cdColumn2.Text").ToString()
            cdColumn3.Text = GetLocalResourceObject("cdColumn3.Text").ToString()
            cdColumn4.Text = GetLocalResourceObject("cdColumn4.Text").ToString()
            cdColumn5.Text = GetLocalResourceObject("cdColumn5.Text").ToString()
            cdColumn6.Text = GetLocalResourceObject("cdColumn6.Text").ToString()
            CheckBoxAllColumns.Text = GetLocalResourceObject("CheckBoxAllColumns.Text").ToString()
            CheckBoxSelectAll.Text = GetLocalResourceObject("CheckBoxSelectAll.Text").ToString()
            lblAlturaColumna.Text = GetLocalResourceObject("lblAlturaColumna.Text").ToString()
            lblBaseColumna.Text = GetLocalResourceObject("lblBaseColumna.Text").ToString()
            lblBeam1.Text = GetLocalResourceObject("lblBeam1.Text").ToString()
            lblBeam2.Text = GetLocalResourceObject("lblBeam2.Text").ToString()
            lblBeam3.Text = GetLocalResourceObject("lblBeam3.Text").ToString()
            lblBeam4.Text = GetLocalResourceObject("lblBeam4.Text").ToString()
            lblColumn1.Text = GetLocalResourceObject("lblColumn1.Text").ToString()
            lblColumn2.Text = GetLocalResourceObject("lblColumn2.Text").ToString()
            lblColumn3.Text = GetLocalResourceObject("lblColumn3.Text").ToString()
            lblColumn4.Text = GetLocalResourceObject("lblColumn4.Text").ToString()
            lblColumn5.Text = GetLocalResourceObject("lblColumn5.Text").ToString()
            lblColumn6.Text = GetLocalResourceObject("lblColumn6.Text").ToString()
            'lblBeam33.Text = GetLocalResourceObject("lblBeam33.Text").ToString()
            'lblBeam34.Text = GetLocalResourceObject("lblBeam34.Text").ToString()
            'lblBeam41.Text = GetLocalResourceObject("lblBeam41.Text").ToString()
            'lblBeam42.Text = GetLocalResourceObject("lblBeam42.Text").ToString()
            'lblBeam43.Text = GetLocalResourceObject("lblBeam43.Text").ToString()
            'lblBeam44.Text = GetLocalResourceObject("lblBeam44.Text").ToString()
            lblBeamNumber.Text = GetLocalResourceObject("lblBeamNumber.Text").ToString()
            lblBeamNumberC.Text = GetLocalResourceObject("lblBeamNumberC.Text").ToString()
            lblBeams.Text = GetLocalResourceObject("lblBeams.Text").ToString()
            lblColumnas.Text = GetLocalResourceObject("lblColumnas.Text").ToString()
            lblColumnsDraw.Text = GetLocalResourceObject("lblColumnsDraw.Text").ToString()
            lblColumnsResults.Text = GetLocalResourceObject("lblColumnsResults.Text").ToString()
            lblDatosAnálisis.Text = GetLocalResourceObject("lblDatosAnálisis.Text").ToString()
            lblDesplazamientoMeta.Text = GetLocalResourceObject("lblDesplazamientoMeta.Text").ToString()
            lblDraw.Text = GetLocalResourceObject("lblDraw.Text").ToString()
            lblFc.Text = GetLocalResourceObject("lblFc.Text").ToString()
            lblFrame.Text = GetLocalResourceObject("lblFrame.Text").ToString()
            lblFy.Text = GetLocalResourceObject("lblFy.Text").ToString()
            lblGeometryProperties.Text = GetLocalResourceObject("lblGeometryProperties.Text").ToString()
            lblGravityLoad.Text = GetLocalResourceObject("lblGravityLoad.Text").ToString()
            lblHStory1.Text = GetLocalResourceObject("lblHStory1.Text").ToString()
            lblHStory2.Text = GetLocalResourceObject("lblHStory2.Text").ToString()
            lblInputData1.Text = GetLocalResourceObject("lblInputData1.Text").ToString()
            lblLoads.Text = GetLocalResourceObject("lblLoads.Text").ToString()
            lblMaterialProperties.Text = GetLocalResourceObject("lblMaterialProperties.Text").ToString()
            lblPatronCarga.Text = GetLocalResourceObject("lblPatronCarga.Text").ToString()
            lblPushover.Text = GetLocalResourceObject("lblPushover.Text").ToString()
            lblRefuerzoCInferior.Text = GetLocalResourceObject("lblRefuerzoCInferior.Text").ToString()
            lblRefuerzoCSuperior.Text = GetLocalResourceObject("lblRefuerzoCSuperior.Text").ToString()
            lblRefuerzoDerecho.Text = GetLocalResourceObject("lblRefuerzoDerecho.Text").ToString()
            lblRefuerzoIzquierdo.Text = GetLocalResourceObject("lblRefuerzoIzquierdo.Text").ToString()
            lblRefuerzoLong.Text = GetLocalResourceObject("lblRefuerzoLong.Text").ToString()
            lblRefuerzoTransv.Text = GetLocalResourceObject("lblRefuerzoTransv.Text").ToString()
            lblRefuerzoTransversal.Text = GetLocalResourceObject("lblRefuerzoTransversal.Text").ToString()
            lblResults.Text = GetLocalResourceObject("lblResults.Text").ToString()
            lblSectionBase.Text = GetLocalResourceObject("lblSectionBase.Text").ToString()
            lblSectionHeight.Text = GetLocalResourceObject("lblSectionHeight.Text").ToString()
            lblSectionProperties.Text = GetLocalResourceObject("lblSectionProperties.Text").ToString()
            lblSpan1.Text = GetLocalResourceObject("lblSpan1.Text").ToString()
            lblSpan2.Text = GetLocalResourceObject("lblSpan2.Text").ToString()
            lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            lblTituloGeneral.Text = GetLocalResourceObject("lblTituloGeneral.Text").ToString()
            lblTituloSeccionProper.Text = GetLocalResourceObject("lblTituloSeccionProper.Text").ToString()
            lblVigas.Text = GetLocalResourceObject("lblVigas.Text").ToString()

            'lbl211.Text = GetLocalResourceObject("lblBeam11.Text").ToString()
            'lbl212.Text = GetLocalResourceObject("lblBeam12.Text").ToString()
            'lbl213.Text = GetLocalResourceObject("lblBeam13.Text").ToString()
            'lbl214.Text = GetLocalResourceObject("lblBeam14.Text").ToString()
            'lbl221.Text = GetLocalResourceObject("lblBeam21.Text").ToString()
            'lbl222.Text = GetLocalResourceObject("lblBeam22.Text").ToString()
            'lbl223.Text = GetLocalResourceObject("lblBeam23.Text").ToString()
            'lbl224.Text = GetLocalResourceObject("lblBeam24.Text").ToString()
            'lbl231.Text = GetLocalResourceObject("lblBeam31.Text").ToString()
            'lbl232.Text = GetLocalResourceObject("lblBeam32.Text").ToString()
            'lbl233.Text = GetLocalResourceObject("lblBeam33.Text").ToString()
            'lbl234.Text = GetLocalResourceObject("lblBeam34.Text").ToString()
            'lbl241.Text = GetLocalResourceObject("lblBeam41.Text").ToString()
            'lbl242.Text = GetLocalResourceObject("lblBeam42.Text").ToString()
            'lbl243.Text = GetLocalResourceObject("lblBeam43.Text").ToString()
            'lbl244.Text = GetLocalResourceObject("lblBeam44.Text").ToString()

            imgRutaTitulo.ImageUrl = GetLocalResourceObject("imgRutaTitulo.Text").ToString()
            imgPortico.ImageUrl = GetLocalResourceObject("imgPortico.Text").ToString()
            imgViga.ImageUrl = GetLocalResourceObject("imgViga.Text").ToString()
            imgColumn.ImageUrl = GetLocalResourceObject("imgColumn.Text").ToString()
            imgPortico2.ImageUrl = GetLocalResourceObject("imgPortico.Text").ToString()
            imgPortico3.ImageUrl = GetLocalResourceObject("imgPortico.Text").ToString()


        End Sub

        Sub obtenerDatos()

            nxaxes = 3
            nzlevels = 3
            ncols = 6
            nvigas = 4
            lateralpattern = Me.DropDownList1.SelectedValue.ToString
            targetdisp = Me.txtDesplazamientoMeta.Text
            pushover(0) = "C:/Inetpub/wwwroot/VLEE/Temp/Exp/Pushover/"
            pushover(1) = nxaxes
            pushover(2) = nzlevels
            pushover(3) = ncols
            pushover(4) = nvigas
            pushover(5) = lateralpattern
            pushover(6) = targetdisp
            vectorx(1) = 0
            vectorx(2) = Me.txtvano1.Text
            vectorx(3) = CInt(txtvano1.Text) + CInt(txtvano2.Text)
            vectory(1) = 0
            vectory(2) = Me.txtaltura1.Text
            vectory(3) = CDbl(Me.txtaltura1.Text) + CDbl(Me.txtaltura2.Text)
            materials(1) = Me.txtFc.Text
            materials(2) = Me.txtFyTrans1.Text
            materials(3) = 0.003
            colmatrix(1, 1) = Me.txtBaseC1.Text
            colmatrix(1, 2) = Me.txtHeightC1.Text
            colmatrix(1, 3) = Me.txtLongReinf1.Text
            colmatrix(1, 4) = Me.txtTransvReinfC1.Text
            colmatrix(2, 1) = Me.txtBaseC2.Text
            colmatrix(2, 2) = Me.txtHeightC2.Text
            colmatrix(2, 3) = Me.txtLongReinf2.Text
            colmatrix(2, 4) = Me.txtTransvReinfC2.Text
            colmatrix(3, 1) = Me.txtBaseC3.Text
            colmatrix(3, 2) = Me.txtHeightC3.Text
            colmatrix(3, 3) = Me.txtLongReinf3.Text
            colmatrix(3, 4) = Me.txtTransvReinfC3.Text
            colmatrix(4, 1) = Me.txtBaseC4.Text
            colmatrix(4, 2) = Me.txtHeightC4.Text
            colmatrix(4, 3) = Me.txtLongReinf4.Text
            colmatrix(4, 4) = Me.txtTransvReinfC4.Text
            colmatrix(5, 1) = Me.txtBaseC5.Text
            colmatrix(5, 2) = Me.txtHeightC5.Text
            colmatrix(5, 3) = Me.txtLongReinf5.Text
            colmatrix(5, 4) = Me.txtTransvReinfC5.Text
            colmatrix(6, 1) = Me.txtBaseC6.Text
            colmatrix(6, 2) = Me.txtHeightC6.Text
            colmatrix(6, 3) = Me.txtLongReinf6.Text
            colmatrix(6, 4) = Me.txtTransvReinfC6.Text
            beamatrix(1, 1) = Me.txtBaseB1.Text
            beamatrix(1, 2) = Me.txtHeightB1.Text
            beamatrix(1, 3) = Me.txtTopContinuous1.Text
            beamatrix(1, 4) = Me.txtBottomContinuous1.Text
            beamatrix(1, 5) = Me.txtReinfLeft1.Text
            beamatrix(1, 6) = Me.txtReinfRight1.Text
            beamatrix(1, 7) = Me.txtTransReinf1.Text
            beamatrix(1, 8) = Me.txtGravityLoad1.Text
            beamatrix(2, 1) = Me.txtBaseB2.Text
            beamatrix(2, 2) = Me.txtHeightB2.Text
            beamatrix(2, 3) = Me.txtTopContinuous2.Text
            beamatrix(2, 4) = Me.txtBottomContinuous2.Text
            beamatrix(2, 5) = Me.txtReinfLeft2.Text
            beamatrix(2, 6) = Me.txtReinfRight2.Text
            beamatrix(2, 7) = Me.txtTransReinf2.Text
            beamatrix(2, 8) = Me.txtGravityLoad2.Text
            beamatrix(3, 1) = Me.txtBaseB3.Text
            beamatrix(3, 2) = Me.txtHeightB3.Text
            beamatrix(3, 3) = Me.txtTopContinuous3.Text
            beamatrix(3, 4) = Me.txtBottomContinuous3.Text
            beamatrix(3, 5) = Me.txtReinfLeft3.Text
            beamatrix(3, 6) = Me.txtReinfRight3.Text
            beamatrix(3, 7) = Me.txtTransReinf3.Text
            beamatrix(3, 8) = Me.txtGravityLoad3.Text
            beamatrix(4, 1) = Me.txtBaseB4.Text
            beamatrix(4, 2) = Me.txtHeightB4.Text
            beamatrix(4, 3) = Me.txtTopContinuous4.Text
            beamatrix(4, 4) = Me.txtBottomContinuous4.Text
            beamatrix(4, 5) = Me.txtReinfLeft4.Text
            beamatrix(4, 6) = Me.txtReinfRight4.Text
            beamatrix(4, 7) = Me.txtTransReinf4.Text
            beamatrix(4, 8) = Me.txtGravityLoad4.Text

        End Sub

        Sub CargarEjemplo()

            Me.txtDesplazamientoMeta.Text = 0.2
            Me.txtvano1.Text = 1
            Me.txtvano2.Text = 3
            Me.txtaltura1.Text = 3.5
            Me.txtaltura2.Text = 3.5
            Me.txtFc.Text = 24
            Me.txtFyTrans1.Text = 420
            Me.txtBaseC1.Text = 0.5
            Me.txtHeightC1.Text = 0.5
            Me.txtLongReinf1.Text = "8D25"
            Me.txtTransvReinfC1.Text = "10@200"
            Me.txtBaseC2.Text = 0.5
            Me.txtHeightC2.Text = 0.5
            Me.txtLongReinf2.Text = "8D25"
            Me.txtTransvReinfC2.Text = "10@200"
            Me.txtBaseC3.Text = 0.5
            Me.txtHeightC3.Text = 0.5
            Me.txtLongReinf3.Text = "8D25"
            Me.txtTransvReinfC3.Text = "10@200"
            Me.txtBaseC4.Text = 0.5
            Me.txtHeightC4.Text = 0.5
            Me.txtLongReinf4.Text = "8D25"
            Me.txtTransvReinfC4.Text = "10@200"
            Me.txtBaseC5.Text = 0.5
            Me.txtHeightC5.Text = 0.5
            Me.txtLongReinf5.Text = "8D18"
            Me.txtTransvReinfC5.Text = "10@200"
            Me.txtBaseC6.Text = 0.5
            Me.txtHeightC6.Text = 0.5
            Me.txtLongReinf6.Text = "8D25"
            Me.txtTransvReinfC6.Text = "10@200"
            Me.txtBaseB1.Text = 0.3
            Me.txtHeightB1.Text = 0.5
            Me.txtTopContinuous1.Text = "2D16"
            Me.txtBottomContinuous1.Text = "2D16"
            Me.txtReinfLeft1.Text = "2D16"
            Me.txtReinfRight1.Text = "2D16"
            Me.txtTransReinf1.Text = "10@100"
            Me.txtGravityLoad1.Text = 30
            Me.txtBaseB2.Text = 0.3
            Me.txtHeightB2.Text = 0.5
            Me.txtTopContinuous2.Text = "2D14"
            Me.txtBottomContinuous2.Text = "2D16"
            Me.txtReinfLeft2.Text = "2D16"
            Me.txtReinfRight2.Text = "2D16"
            Me.txtTransReinf2.Text = "10@100"
            Me.txtGravityLoad2.Text = 30
            Me.txtBaseB3.Text = 0.3
            Me.txtHeightB3.Text = 0.5
            Me.txtTopContinuous3.Text = "2D14"
            Me.txtBottomContinuous3.Text = "2D16"
            Me.txtReinfLeft3.Text = "2D16"
            Me.txtReinfRight3.Text = "2D16"
            Me.txtTransReinf3.Text = "10@100"
            Me.txtGravityLoad3.Text = 30
            Me.txtBaseB4.Text = 0.3
            Me.txtHeightB4.Text = 0.5
            Me.txtTopContinuous4.Text = "2D16"
            Me.txtBottomContinuous4.Text = "2D16"
            Me.txtReinfLeft4.Text = "2D16"
            Me.txtReinfRight4.Text = "2D16"
            Me.txtTransReinf4.Text = "10@100"
            Me.txtGravityLoad4.Text = 30

        End Sub


        Protected Sub btnGraficar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficar.Click
            Limpiar()
            obtenerDatos()

            'MANTENIMIENTO
            'obj_Push.read_pushover(pushover)
            'obj_Push.read_materials(materials)
            'obj_Push.read_vectorx(vectorx)
            'obj_Push.read_vectory(vectory)
            'obj_Push.read_colmatrix(colmatrix)
            'obj_Push.read_beamatrix(beamatrix)
            'obj_Push.pushover()
            'forcedisp = obj_Push.return_forcedisp
            'END MATENIMIENTO

            subPresentarResultados()
            subGraficar()
            subCrearWebChartViewer()

            'For n As Integer = 0 To 100
            '    cells(50 + n, 1) = forcedisp(n, 0)
            '    cells(50 + n, 2) = forcedisp(n, 1)
            'Next
            'grafica2()
            'Resultados()
        End Sub

        Sub subPresentarResultados()

            'MANTENIMIENTO
            'forcedisp = obj_Push.return_forcedisp
            'beamresponse = obj_Push.return_beamresponse
            'colresponse = obj_Push.return_colresponse
            'END MATENIMIENTO

            'Figuras()
            'grafica2()


        End Sub



        'Cargar Resultados en Cajas de Texto
        'Sub Resultados()
        '    Dim Result As String = Nothing
        '    For i As Integer = 1 To 50
        '        matriz1(i, 1) = MCcurvesR(1, i, 1)
        '        matriz1(i, 2) = MCcurvesR(1, i, 2)
        '        matriz1(i, 3) = MCcurvesR(1, i, 3)
        '        matriz1(i, 4) = MCcurvesR(1, i, 4)
        '        matriz1(i, 5) = MCcurvesR(1, i, 5)
        '        matriz1(i, 6) = MCcurvesR(1, i, 6)



        '    Next

        '    Dim etiquetas() As String = {"Elastic Modulus of Concrete", _
        '                                 "Unconfined concrete strength", _
        '                                 "strain at unconfined concrete strength", _
        '                                 "ultimate unconfined strain (spalling)", _
        '                                 "confined concrete strength", _
        '                                 "strain at confined concrete strength", _
        '                                 "ultimate confined strain (spalling)", _
        '                                 "Elastic Modulus of Steel", _
        '                                 "Yield strengh of longitudinal reinforcement", _
        '                                 "Yield strain of longitudinal reinforcement", _
        '                                 "strain at begining of strain hardening", _
        '                                 "max strength of reinforment steel", _
        '                                 "strain at maximum strenght of reinforcement steel", _
        '                                 "Yield strengh of transverse reinforcement", _
        '                                 "ultimate strain of transverse reinforcement"}

        '    Dim etiquetasS() As String = {"Longitudinal steel ratio", _
        '                                  "transverse steel ratio", _
        '                                  "Axial Load Ratio", _
        '                                  "Inertia", _
        '                                  "Moment at first yield", _
        '                                  "Curvature at first yield", _
        '                                  "Nominal moment strength", _
        '                                  "Nominal yield curvature", _
        '                                  "Concrete strain at nominal moment strengh", _
        '                                  "Damage control moment", _
        '                                  "Damage control curvature", _
        '                                  "Second to first slope ratio"}


        '    Result = "-----------------------------------------------------------------------------" & Chr(13) & Chr(10) & Chr(13) & "UTPL-MC: Software for Moment Curvature analysis of reinforce concrete sections" & Chr(13) & Chr(10) & "Author: Vinicio Suarez, vasuarez@utpl.edu.ec" & Chr(13) & Chr(13) & Chr(10)
        '    Result = Result + Chr(13) & "MATERIAL PROPERTIES" & Chr(13)
        '    Result = Result + "======== ==========" & Chr(13)

        '    For i As Integer = 1 To 14
        '        Result = Result + etiquetas(i - 1) & Chr(13)
        '        For j As Integer = 1 To NumSections
        '            Result = Result & "SECTION " & j & Chr(9)
        '        Next
        '        Result = Result & Chr(13)
        '        For j As Integer = 1 To NumSections
        '            Result = Result + CStr(Round(materialpropertiesR(i, j), 3)) & Chr(9)
        '        Next
        '        Result = Result + Chr(13)
        '    Next

        '    Result = Result + Chr(13) & "SECTION PROPERTIES" & Chr(13)
        '    For i As Integer = 1 To 12
        '        Result = Result + etiquetas(i - 1) & Chr(13)
        '        For j As Integer = 1 To NumSections
        '            Result = Result & "SECTION " & j & Chr(9)
        '        Next
        '        Result = Result & Chr(13)
        '        For j As Integer = 1 To NumSections
        '            Result = Result + CStr(Round(sectionpropertiesR(i, j), 3)) & Chr(9)
        '        Next
        '        Result = Result + Chr(13)
        '    Next


        '    If NumSections >= 1 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 1" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz1(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz1(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 2 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 2" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz2(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz2(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 3 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 3" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz3(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz3(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 4 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 4" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz4(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz4(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 5 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 5" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz5(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz5(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 6 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 6" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz6(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz6(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 7 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 7" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz7(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz7(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 8 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 8" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz8(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz8(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections >= 9 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 9" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz9(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz9(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    If NumSections = 10 Then
        '        Result = Result + Chr(13) & Chr(13)
        '        Result = Result + "ANALYSIS MOMENT-CURVATURE SECCION 10" & Chr(13) & Chr(10)
        '        Result = Result + "Curvatura(1/m)" & Chr(9) & "Momento(kN.m)" & Chr(9) & "C(m)" & Chr(9) & Chr(9) & "ec" & Chr(9) & Chr(9) & "es" & Chr(9) & Chr(9) & "Mv(kN.m)" & Chr(13) & Chr(10)
        '        For i As Integer = 1 To 50
        '            Result = Result + CStr(Round(matriz10(i, 1), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 2), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 3), 3)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 4), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 5), 5)) & Chr(9) & Chr(9) & CStr(Round(matriz10(i, 6), 5)) & Chr(9)
        '            Result = Result + Chr(13) & Chr(10)
        '        Next
        '    End If

        '    Me.txtresult.Text = Result
        'End Sub

        'Sub Figuras()
        '    Dim ten As Single
        '    Dim n As Single
        '    Dim rt As Single
        '    Dim eyd As Single
        '    Dim fiy As Single
        '    Dim Eicr As Single
        '    Dim Myy As Single
        '    Dim Icrig As Single
        '    Dim pn As Single
        '    Dim phiD As Single
        '    Dim eec As Single
        '    Dim avgecc As Single
        '    Dim rhoo As Single
        '    Dim avgphiD As Single
        '    Dim avgeec As Single
        '    Dim aa As Single
        '    Dim bb As Single


        '    ReDim figura1(NumSections, 4)
        '    'figura 1. Curvatura de fluencia
        '    'figura1(ey/D , phiy, tendencia)
        '    ten = 0
        '    For n = 1 To NumSections
        '        rt = sectionpropertiesR(14, n) / 1000
        '        eyd = materialpropertiesR(10, n) / (2 * rt)
        '        fiy = sectionpropertiesR(8, n)
        '        ten = ten + fiy / eyd
        '        figura1(n, 1) = eyd
        '        figura1(n, 2) = fiy
        '    Next
        '    ten = ten / NumSections
        '    For n = 1 To NumSections
        '        figura1(n, 3) = ten * figura1(n, 1)
        '    Next
        '    figura1(1, 4) = ten

        '    'figura 2. Relacion entre resistencia y rigidez
        '    'figura2(EIcr , My, tendencia)
        '    ReDim figura2(NumSections, 4)
        '    ten = 0
        '    For n = 1 To NumSections
        '        Eicr = sectionpropertiesR(4, n) * materialpropertiesR(1, n) * 1000 'kN.m^2
        '        Myy = sectionpropertiesR(7, n)
        '        ten = ten + Myy / Eicr
        '        figura2(n, 1) = Eicr
        '        figura2(n, 2) = Myy
        '    Next
        '    ten = ten / NumSections
        '    For n = 1 To NumSections
        '        figura2(n, 3) = ten * figura2(n, 1)
        '    Next
        '    figura2(1, 4) = ten

        '    'figura 3. Relacion entre Ig/Icr vs rho
        '    'figura3(rho , Ig/icr, tendencia)
        '    ReDim figura3(NumSections, 4)
        '    ten = 0
        '    For n = 1 To NumSections
        '        rt = sectionpropertiesR(14, n) / 1000
        '        Icrig = sectionpropertiesR(4, n) / (PI * (rt * 2) ^ 4 / 64)
        '        rhoo = sectionpropertiesR(1, n)
        '        ten = ten + Icrig / rhoo
        '        figura3(n, 2) = Icrig
        '        figura3(n, 1) = rhoo
        '    Next
        '    ten = ten / NumSections
        '    For n = 1 To NumSections
        '        figura3(n, 3) = ten * figura3(n, 1)
        '    Next
        '    figura3(1, 4) = ten

        '    'figura 4. Relacion entre ec vs dphi
        '    'figura4(Dphi , ec, tendencia)
        '    ReDim figura4(NumSections, 50, 4)
        '    ten = 0
        '    avgSlope = 0
        '    ptns = 0
        '    For n = 1 To NumSections
        '        rt = materialpropertiesR(14, n) / 1000
        '        For pn = 1 To 50
        '            phiD = MCcurvesR(n, pn, 1) * (2 * rt)
        '            eec = MCcurvesR(n, pn, 4)
        '            If phiD > 0 Then avgSlope = avgSlope + (eec / phiD) : ptns = ptns + 1
        '            figura4(n, pn, 1) = phiD
        '            figura4(n, pn, 2) = eec
        '        Next
        '    Next
        '    avgSlope = avgSlope / ptns
        '    ten = avgSlope
        '    For pn = 1 To 50
        '        figura4(NumSections, pn, 3) = ten * figura4(NumSections, pn, 1)
        '    Next
        '    figura4(NumSections, 1, 4) = ten

        '    'figura 5. Relacion entre ec vs dphi
        '    'figura5(Dphi , ec, tendencia)
        '    ReDim figura5(NumSections, 50, 4)
        '    ten = 0
        '    avgSlope = 0
        '    ptns = 0
        '    For n = 1 To NumSections
        '        rt = materialpropertiesR(14, n) / 1000
        '        For pn = 1 To 50
        '            phiD = MCcurvesR(n, pn, 1) * (2 * rt)
        '            eec = MCcurvesR(n, pn, 5)
        '            If phiD > 0 Then avgSlope = avgSlope + (eec / phiD) : ptns = ptns + 1
        '            figura5(n, pn, 1) = phiD
        '            figura5(n, pn, 2) = eec
        '        Next
        '    Next
        '    avgSlope = avgSlope / ptns
        '    ten = avgSlope
        '    For pn = 1 To 50
        '        figura5(NumSections, pn, 3) = ten * figura5(NumSections, pn, 1)
        '    Next
        '    figura5(NumSections, 1, 4) = ten

        'End Sub

        Sub subGraficar()

            'GRAFICA PUSHOVER
            ''Arreglo de linea Push 
            Dim arrXLinePush(100) As Double
            Dim arrYLinePush(100) As Double

            ''Arreglo de linea StrainTopLeft
            Dim arrXLineStrainTopLeft(100) As Double
            Dim arrYLineStrainTopLeft1(100) As Double
            Dim arrYLineStrainTopLeft2(100) As Double
            Dim arrYLineStrainTopLeft3(100) As Double
            Dim arrYLineStrainTopLeft4(100) As Double

            ''Arreglo de linea StrainTopRight
            Dim arrXLineStrainTopRight(100) As Double
            Dim arrYLineStrainTopRight1(100) As Double
            Dim arrYLineStrainTopRight2(100) As Double
            Dim arrYLineStrainTopRight3(100) As Double
            Dim arrYLineStrainTopRight4(100) As Double

            ''Arreglo de linea StrainBottomLeft
            Dim arrXLineStrainBottomLeft(100) As Double
            Dim arrYLineStrainBottomLeft1(100) As Double
            Dim arrYLineStrainBottomLeft2(100) As Double
            Dim arrYLineStrainBottomLeft3(100) As Double
            Dim arrYLineStrainBottomLeft4(100) As Double

            ''Arreglo de linea StrainBottomRight
            Dim arrXLineStrainBottomRight(100) As Double
            Dim arrYLineStrainBottomRight1(100) As Double
            Dim arrYLineStrainBottomRight2(100) As Double
            Dim arrYLineStrainBottomRight3(100) As Double
            Dim arrYLineStrainBottomRight4(100) As Double


            ''Arreglo de linea DCRTopLeft
            Dim arrXLineDCRTopLeft(100) As Double
            Dim arrYLineDCRTopLeft1(100) As Double
            Dim arrYLineDCRTopLeft2(100) As Double
            Dim arrYLineDCRTopLeft3(100) As Double
            Dim arrYLineDCRTopLeft4(100) As Double

            ''Arreglo de linea DCRBottomLeft
            Dim arrXLineDCRBottomLeft(100) As Double
            Dim arrYLineDCRBottomLeft1(100) As Double
            Dim arrYLineDCRBottomLeft2(100) As Double
            Dim arrYLineDCRBottomLeft3(100) As Double
            Dim arrYLineDCRBottomLeft4(100) As Double

            ''Arreglo de linea DCRTopRight
            Dim arrXLineDCRTopRight(100) As Double
            Dim arrYLineDCRTopRight1(100) As Double
            Dim arrYLineDCRTopRight2(100) As Double
            Dim arrYLineDCRTopRight3(100) As Double
            Dim arrYLineDCRTopRight4(100) As Double

            ''Arreglo de linea DCRBotoomRight
            Dim arrXLineDCRBotoomRight(100) As Double
            Dim arrYLineDCRBotoomRight1(100) As Double
            Dim arrYLineDCRBotoomRight2(100) As Double
            Dim arrYLineDCRBotoomRight3(100) As Double
            Dim arrYLineDCRBotoomRight4(100) As Double

            ''Arreglo de linea MomentLeft
            Dim arrXLineMomentLeft(100) As Double
            Dim arrYLineMomentLeft1(100) As Double
            Dim arrYLineMomentLeft2(100) As Double
            Dim arrYLineMomentLeft3(100) As Double
            Dim arrYLineMomentLeft4(100) As Double

            ''Arreglo de linea CurvatureLeft
            Dim arrXLineCurvatureLeft(100) As Double
            Dim arrYLineCurvatureLeft1(100) As Double
            Dim arrYLineCurvatureLeft2(100) As Double
            Dim arrYLineCurvatureLeft3(100) As Double
            Dim arrYLineCurvatureLeft4(100) As Double

            ''Arreglo de linea MomentRight
            Dim arrXLineMomentRight(100) As Double
            Dim arrYLineMomentRight1(100) As Double
            Dim arrYLineMomentRight2(100) As Double
            Dim arrYLineMomentRight3(100) As Double
            Dim arrYLineMomentRight4(100) As Double

            ''Arreglo de linea CurvatureRight
            Dim arrXLineCurvatureRight(100) As Double
            Dim arrYLineCurvatureRight1(100) As Double
            Dim arrYLineCurvatureRight2(100) As Double
            Dim arrYLineCurvatureRight3(100) As Double
            Dim arrYLineCurvatureRight4(100) As Double

            ''Arreglo de linea ShearLeft
            Dim arrXLineShearLeft(100) As Double
            Dim arrYLineShearLeft1(100) As Double
            Dim arrYLineShearLeft2(100) As Double
            Dim arrYLineShearLeft3(100) As Double
            Dim arrYLineShearLeft4(100) As Double

            ''Arreglo de linea AxialLeft
            Dim arrXLineAxialLeft(100) As Double
            Dim arrYLineAxialLeft1(100) As Double
            Dim arrYLineAxialLeft2(100) As Double
            Dim arrYLineAxialLeft3(100) As Double
            Dim arrYLineAxialLeft4(100) As Double

            ''Arreglo de linea ShearRight
            Dim arrXLineShearRight(100) As Double
            Dim arrYLineShearRight1(100) As Double
            Dim arrYLineShearRight2(100) As Double
            Dim arrYLineShearRight3(100) As Double
            Dim arrYLineShearRight4(100) As Double

            ''Arreglo de linea AxialRight
            Dim arrXLineAxialRight(100) As Double
            Dim arrYLineAxialRight1(100) As Double
            Dim arrYLineAxialRight2(100) As Double
            Dim arrYLineAxialRight3(100) As Double
            Dim arrYLineAxialRight4(100) As Double



            'Extraccion de coordenadas para Pushover
            For n As Integer = 0 To 100
                arrXLinePush(n) = CDbl(forcedisp(n, 0))
                arrYLinePush(n) = CDbl(forcedisp(n, 1))
            Next

            'Extraccion de coordenadas para StrainTopLeft
            For n As Integer = 0 To 100
                arrXLineStrainTopLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineStrainTopLeft1(n) = CDbl(beamresponse(1, n, 7))
                arrYLineStrainTopLeft2(n) = CDbl(beamresponse(2, n, 7))
                arrYLineStrainTopLeft3(n) = CDbl(beamresponse(3, n, 7))
                arrYLineStrainTopLeft4(n) = CDbl(beamresponse(4, n, 7))
            Next

            'Extraccion de coordenadas para StrainTopRight
            For n As Integer = 0 To 100
                arrXLineStrainTopRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineStrainTopRight1(n) = CDbl(beamresponse(1, n, 15))
                arrYLineStrainTopRight2(n) = CDbl(beamresponse(2, n, 15))
                arrYLineStrainTopRight3(n) = CDbl(beamresponse(3, n, 15))
                arrYLineStrainTopRight4(n) = CDbl(beamresponse(4, n, 15))
            Next

            'Extraccion de coordenadas para StrainBottomLeft
            For n As Integer = 0 To 100
                arrXLineStrainBottomLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineStrainBottomLeft1(n) = CDbl(beamresponse(1, n, 8))
                arrYLineStrainBottomLeft2(n) = CDbl(beamresponse(2, n, 8))
                arrYLineStrainBottomLeft3(n) = CDbl(beamresponse(3, n, 8))
                arrYLineStrainBottomLeft4(n) = CDbl(beamresponse(4, n, 8))
            Next

            'Extraccion de coordenadas para StrainBottomRight
            For n As Integer = 0 To 100
                arrXLineStrainBottomRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineStrainBottomRight1(n) = CDbl(beamresponse(1, n, 16))
                arrYLineStrainBottomRight2(n) = CDbl(beamresponse(2, n, 16))
                arrYLineStrainBottomRight3(n) = CDbl(beamresponse(3, n, 16))
                arrYLineStrainBottomRight4(n) = CDbl(beamresponse(4, n, 16))
            Next

            'Extraccion de coordenadas para DCRTopLeft
            For n As Integer = 0 To 100
                arrXLineDCRTopLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineDCRTopLeft1(n) = CDbl(beamresponse(1, n, 1))
                arrYLineDCRTopLeft2(n) = CDbl(beamresponse(2, n, 1))
                arrYLineDCRTopLeft3(n) = CDbl(beamresponse(3, n, 1))
                arrYLineDCRTopLeft4(n) = CDbl(beamresponse(4, n, 1))
            Next

            'Extraccion de coordenadas para DCRBottomLeft
            For n As Integer = 0 To 100
                arrXLineDCRBottomLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineDCRBottomLeft1(n) = CDbl(beamresponse(1, n, 2))
                arrYLineDCRBottomLeft2(n) = CDbl(beamresponse(2, n, 2))
                arrYLineDCRBottomLeft3(n) = CDbl(beamresponse(3, n, 2))
                arrYLineDCRBottomLeft4(n) = CDbl(beamresponse(4, n, 2))
            Next

            'Extraccion de coordenadas para DCRTopRight
            For n As Integer = 0 To 100
                arrXLineDCRTopRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineDCRTopRight1(n) = CDbl(beamresponse(1, n, 9))
                arrYLineDCRTopRight2(n) = CDbl(beamresponse(2, n, 9))
                arrYLineDCRTopRight3(n) = CDbl(beamresponse(3, n, 9))
                arrYLineDCRTopRight4(n) = CDbl(beamresponse(4, n, 9))
            Next

            'Extraccion de coordenadas para DCRBottomRight
            For n As Integer = 0 To 100
                arrXLineDCRBotoomRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineDCRBotoomRight1(n) = CDbl(beamresponse(1, n, 10))
                arrYLineDCRBotoomRight2(n) = CDbl(beamresponse(2, n, 10))
                arrYLineDCRBotoomRight3(n) = CDbl(beamresponse(3, n, 10))
                arrYLineDCRBotoomRight4(n) = CDbl(beamresponse(4, n, 10))
            Next

            'Extraccion de coordenadas para MomentLeft
            For n As Integer = 0 To 100
                arrXLineMomentLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineMomentLeft1(n) = CDbl(beamresponse(1, n, 3))
                arrYLineMomentLeft2(n) = CDbl(beamresponse(2, n, 3))
                arrYLineMomentLeft3(n) = CDbl(beamresponse(3, n, 3))
                arrYLineMomentLeft4(n) = CDbl(beamresponse(4, n, 3))
            Next

            'Extraccion de coordenadas para CurvatureLeft
            For n As Integer = 0 To 100
                arrXLineCurvatureLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineCurvatureLeft1(n) = CDbl(beamresponse(1, n, 4))
                arrYLineCurvatureLeft2(n) = CDbl(beamresponse(2, n, 4))
                arrYLineCurvatureLeft3(n) = CDbl(beamresponse(3, n, 4))
                arrYLineCurvatureLeft4(n) = CDbl(beamresponse(4, n, 4))
            Next

            'Extraccion de coordenadas para MomentRight
            For n As Integer = 0 To 100
                arrXLineMomentRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineMomentRight1(n) = CDbl(beamresponse(1, n, 11))
                arrYLineMomentRight2(n) = CDbl(beamresponse(2, n, 11))
                arrYLineMomentRight3(n) = CDbl(beamresponse(3, n, 11))
                arrYLineMomentRight4(n) = CDbl(beamresponse(4, n, 11))
            Next

            'Extraccion de coordenadas para CurvatureRight
            For n As Integer = 0 To 100
                arrXLineCurvatureRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineCurvatureRight1(n) = CDbl(beamresponse(1, n, 12))
                arrYLineCurvatureRight2(n) = CDbl(beamresponse(2, n, 12))
                arrYLineCurvatureRight3(n) = CDbl(beamresponse(3, n, 12))
                arrYLineCurvatureRight4(n) = CDbl(beamresponse(4, n, 12))
            Next

            'Extraccion de coordenadas para ShearLeft
            For n As Integer = 0 To 100
                arrXLineShearLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineShearLeft1(n) = CDbl(beamresponse(1, n, 5))
                arrYLineShearLeft2(n) = CDbl(beamresponse(2, n, 5))
                arrYLineShearLeft3(n) = CDbl(beamresponse(3, n, 5))
                arrYLineShearLeft4(n) = CDbl(beamresponse(4, n, 5))
            Next

            'Extraccion de coordenadas para AxialLeft
            For n As Integer = 0 To 100
                arrXLineAxialLeft(n) = CDbl(beamresponse(1, n, 0))
                arrYLineAxialLeft1(n) = CDbl(beamresponse(1, n, 6))
                arrYLineAxialLeft2(n) = CDbl(beamresponse(2, n, 6))
                arrYLineAxialLeft3(n) = CDbl(beamresponse(3, n, 6))
                arrYLineAxialLeft4(n) = CDbl(beamresponse(4, n, 6))
            Next


            'Extraccion de coordenadas para ShearRight
            For n As Integer = 0 To 100
                arrXLineShearRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineShearRight1(n) = CDbl(beamresponse(1, n, 13))
                arrYLineShearRight2(n) = CDbl(beamresponse(2, n, 13))
                arrYLineShearRight3(n) = CDbl(beamresponse(3, n, 13))
                arrYLineShearRight4(n) = CDbl(beamresponse(4, n, 13))
            Next

            'Extraccion de coordenadas para AxialRight
            For n As Integer = 0 To 100
                arrXLineAxialRight(n) = CDbl(beamresponse(1, n, 0))
                arrYLineAxialRight1(n) = CDbl(beamresponse(1, n, 14))
                arrYLineAxialRight2(n) = CDbl(beamresponse(2, n, 14))
                arrYLineAxialRight3(n) = CDbl(beamresponse(3, n, 14))
                arrYLineAxialRight4(n) = CDbl(beamresponse(4, n, 14))
            Next
            '    'Extraccion datos de linea Bilineal
            '    arrXLineBilineal(0) = 0
            '    arrYLineBilineal(0) = 0
            '    arrXLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(8, 1))
            '    arrYLineBilineal(1) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 1))
            '    arrXLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(11, 1))
            '    arrYLineBilineal(2) = CDbl(objVLEE_AMC.Return_sectionproperties(7, 1))
            '    'Redimensionamiento de coordenas de lineas MC 
            '    ReDim Preserve arrXLineMC(48)
            '    ReDim Preserve arrYLineMC(48)
            '    'Linea Push

            Dim linePush As LineLayer
            linePush = XYChart_Grafica_Pushover.addLineLayer(arrYLinePush, colores(0), "Pushover")
            linePush.setXData(arrXLinePush)
            linePush.setLineWidth(2)

            If Me.cbBeam1.Checked = True Then
                Dim LineStrainTopLeft1 As LineLayer
                LineStrainTopLeft1 = XYChart_Grafica_StrainLeftEndTopBeams.addLineLayer(arrYLineStrainTopLeft1, colores(1), "Beam 1")
                LineStrainTopLeft1.setXData(arrXLineStrainTopLeft)
                LineStrainTopLeft1.setLineWidth(2)

                Dim LineStrainTopRight1 As LineLayer
                LineStrainTopRight1 = XYChart_Grafica_StrainRightEndTopBeams.addLineLayer(arrYLineStrainTopRight1, colores(1), "Beam 1")
                LineStrainTopRight1.setXData(arrXLineStrainTopRight)
                LineStrainTopRight1.setLineWidth(2)

                Dim LineStrainBottomLeft1 As LineLayer
                LineStrainBottomLeft1 = XYChart_Grafica_StrainLeftEndBottomBeams.addLineLayer(arrYLineStrainBottomLeft1, colores(1), "Beam 1")
                LineStrainBottomLeft1.setXData(arrXLineStrainBottomLeft)
                LineStrainBottomLeft1.setLineWidth(2)

                Dim LineStrainBottomRight1 As LineLayer
                LineStrainBottomRight1 = XYChart_Grafica_StrainRightEndBottomBeams.addLineLayer(arrYLineStrainBottomRight1, colores(1), "Beam 1")
                LineStrainBottomRight1.setXData(arrXLineStrainBottomRight)
                LineStrainBottomRight1.setLineWidth(2)

                Dim LineDCRTopLeft1 As LineLayer
                LineDCRTopLeft1 = XYChart_Grafica_DCRLeftEndTopBeams.addLineLayer(arrYLineDCRTopLeft1, colores(1), "Beam 1")
                LineDCRTopLeft1.setXData(arrXLineDCRTopLeft)
                LineDCRTopLeft1.setLineWidth(2)

                Dim LineDCRBottomLeft1 As LineLayer
                LineDCRBottomLeft1 = XYChart_Grafica_DCRLeftEndBottomBeams.addLineLayer(arrYLineDCRBottomLeft1, colores(1), "Beam 1")
                LineDCRBottomLeft1.setXData(arrXLineDCRBottomLeft)
                LineDCRBottomLeft1.setLineWidth(2)

                Dim LineDCRTopRight1 As LineLayer
                LineDCRTopRight1 = XYChart_Grafica_DCRRightEndTopBeams.addLineLayer(arrYLineDCRTopRight1, colores(1), "Beam 1")
                LineDCRTopRight1.setXData(arrXLineDCRTopRight)
                LineDCRTopRight1.setLineWidth(2)

                Dim LineDCRBotoomRight1 As LineLayer
                LineDCRBotoomRight1 = XYChart_Grafica_DCRRightEndBottom.addLineLayer(arrYLineDCRBotoomRight1, colores(1), "Beam 1")
                LineDCRBotoomRight1.setXData(arrXLineDCRBotoomRight)
                LineDCRBotoomRight1.setLineWidth(2)

                Dim LineMomentLeft1 As LineLayer
                LineMomentLeft1 = XYChart_Grafica_MomentLeftEndBeams.addLineLayer(arrYLineMomentLeft1, colores(1), "Beam 1")
                LineMomentLeft1.setXData(arrXLineMomentLeft)
                LineMomentLeft1.setLineWidth(2)

                Dim LineCurvatureLeft1 As LineLayer
                LineCurvatureLeft1 = XYChart_Grafica_CurvatureLeftEndBeams.addLineLayer(arrYLineCurvatureLeft1, colores(1), "Beam 1")
                LineCurvatureLeft1.setXData(arrXLineCurvatureLeft)
                LineCurvatureLeft1.setLineWidth(2)

                Dim LineMomentRight1 As LineLayer
                LineMomentRight1 = XYChart_Grafica_MomentRightEndBeams.addLineLayer(arrYLineMomentRight1, colores(1), "Beam 1")
                LineMomentRight1.setXData(arrXLineMomentRight)
                LineMomentRight1.setLineWidth(2)

                Dim LineCurvatureRight1 As LineLayer
                LineCurvatureRight1 = XYChart_Grafica_CurvatureRightEndBeams.addLineLayer(arrYLineCurvatureRight1, colores(1), "Beam 1")
                LineCurvatureRight1.setXData(arrXLineCurvatureRight)
                LineCurvatureRight1.setLineWidth(2)

                Dim LineShearLeft1 As LineLayer
                LineShearLeft1 = XYChart_Grafica_ShearLeftEndBeams.addLineLayer(arrYLineShearLeft1, colores(1), "Beam 1")
                LineShearLeft1.setXData(arrXLineShearLeft)
                LineShearLeft1.setLineWidth(2)

                Dim LineAxialLeft1 As LineLayer
                LineAxialLeft1 = XYChart_Grafica_AxialLeftEndBeams.addLineLayer(arrYLineAxialLeft1, colores(1), "Beam 1")
                LineAxialLeft1.setXData(arrXLineAxialLeft)
                LineAxialLeft1.setLineWidth(2)

                Dim LineShearRight1 As LineLayer
                LineShearRight1 = XYChart_Grafica_ShearRightEndBeams.addLineLayer(arrYLineShearRight1, colores(1), "Beam 1")
                LineShearRight1.setXData(arrXLineShearRight)
                LineShearRight1.setLineWidth(2)

                Dim LineAxialRight1 As LineLayer
                LineAxialRight1 = XYChart_Grafica_AxialRightEndBeams.addLineLayer(arrYLineAxialRight1, colores(1), "Beam 1")
                LineAxialRight1.setXData(arrXLineAxialRight)
                LineAxialRight1.setLineWidth(2)

            End If

            If Me.cbBeam2.Checked = True Then
                Dim LineStrainTopLeft2 As LineLayer
                LineStrainTopLeft2 = XYChart_Grafica_StrainLeftEndTopBeams.addLineLayer(arrYLineStrainTopLeft2, colores(2), "Beam 2")
                LineStrainTopLeft2.setXData(arrXLineStrainTopLeft)
                LineStrainTopLeft2.setLineWidth(2)

                Dim LineStrainTopRight2 As LineLayer
                LineStrainTopRight2 = XYChart_Grafica_StrainRightEndTopBeams.addLineLayer(arrYLineStrainTopRight2, colores(2), "Beam 2")
                LineStrainTopRight2.setXData(arrXLineStrainTopRight)
                LineStrainTopRight2.setLineWidth(2)

                Dim LineStrainBottomLeft2 As LineLayer
                LineStrainBottomLeft2 = XYChart_Grafica_StrainLeftEndBottomBeams.addLineLayer(arrYLineStrainBottomLeft2, colores(2), "Beam 2")
                LineStrainBottomLeft2.setXData(arrXLineStrainBottomLeft)
                LineStrainBottomLeft2.setLineWidth(2)

                Dim LineStrainBottomRight2 As LineLayer
                LineStrainBottomRight2 = XYChart_Grafica_StrainRightEndBottomBeams.addLineLayer(arrYLineStrainBottomRight2, colores(2), "Beam 2")
                LineStrainBottomRight2.setXData(arrXLineStrainBottomRight)
                LineStrainBottomRight2.setLineWidth(2)

                Dim LineDCRTopLeft2 As LineLayer
                LineDCRTopLeft2 = XYChart_Grafica_DCRLeftEndTopBeams.addLineLayer(arrYLineDCRTopLeft2, colores(2), "Beam 2")
                LineDCRTopLeft2.setXData(arrXLineDCRTopLeft)
                LineDCRTopLeft2.setLineWidth(2)

                Dim LineDCRBottomLeft2 As LineLayer
                LineDCRBottomLeft2 = XYChart_Grafica_DCRLeftEndBottomBeams.addLineLayer(arrYLineDCRBottomLeft2, colores(2), "Beam 2")
                LineDCRBottomLeft2.setXData(arrXLineDCRBottomLeft)
                LineDCRBottomLeft2.setLineWidth(2)

                Dim LineDCRTopRight2 As LineLayer
                LineDCRTopRight2 = XYChart_Grafica_DCRRightEndTopBeams.addLineLayer(arrYLineDCRTopRight2, colores(2), "Beam 2")
                LineDCRTopRight2.setXData(arrXLineDCRTopRight)
                LineDCRTopRight2.setLineWidth(2)

                Dim LineDCRBotoomRight2 As LineLayer
                LineDCRBotoomRight2 = XYChart_Grafica_DCRRightEndBottom.addLineLayer(arrYLineDCRBotoomRight2, colores(2), "Beam 2")
                LineDCRBotoomRight2.setXData(arrXLineDCRBotoomRight)
                LineDCRBotoomRight2.setLineWidth(2)

                Dim LineMomentLeft2 As LineLayer
                LineMomentLeft2 = XYChart_Grafica_MomentLeftEndBeams.addLineLayer(arrYLineMomentLeft2, colores(2), "Beam 2")
                LineMomentLeft2.setXData(arrXLineMomentLeft)
                LineMomentLeft2.setLineWidth(2)

                Dim LineCurvatureLeft2 As LineLayer
                LineCurvatureLeft2 = XYChart_Grafica_CurvatureLeftEndBeams.addLineLayer(arrYLineCurvatureLeft2, colores(2), "Beam 2")
                LineCurvatureLeft2.setXData(arrXLineCurvatureLeft)
                LineCurvatureLeft2.setLineWidth(2)

                Dim LineMomentRight2 As LineLayer
                LineMomentRight2 = XYChart_Grafica_MomentRightEndBeams.addLineLayer(arrYLineMomentRight2, colores(2), "Beam 2")
                LineMomentRight2.setXData(arrXLineMomentRight)
                LineMomentRight2.setLineWidth(2)

                Dim LineCurvatureRight2 As LineLayer
                LineCurvatureRight2 = XYChart_Grafica_CurvatureRightEndBeams.addLineLayer(arrYLineCurvatureRight2, colores(2), "Beam 2")
                LineCurvatureRight2.setXData(arrXLineCurvatureRight)
                LineCurvatureRight2.setLineWidth(2)

                Dim LineShearLeft2 As LineLayer
                LineShearLeft2 = XYChart_Grafica_ShearLeftEndBeams.addLineLayer(arrYLineShearLeft2, colores(2), "Beam 2")
                LineShearLeft2.setXData(arrXLineShearLeft)
                LineShearLeft2.setLineWidth(2)

                Dim LineAxialLeft2 As LineLayer
                LineAxialLeft2 = XYChart_Grafica_AxialLeftEndBeams.addLineLayer(arrYLineAxialLeft2, colores(2), "Beam 2")
                LineAxialLeft2.setXData(arrXLineAxialLeft)
                LineAxialLeft2.setLineWidth(2)

                Dim LineShearRight2 As LineLayer
                LineShearRight2 = XYChart_Grafica_ShearRightEndBeams.addLineLayer(arrYLineShearRight2, colores(2), "Beam 2")
                LineShearRight2.setXData(arrXLineShearRight)
                LineShearRight2.setLineWidth(2)

                Dim LineAxialRight2 As LineLayer
                LineAxialRight2 = XYChart_Grafica_AxialRightEndBeams.addLineLayer(arrYLineAxialRight2, colores(2), "Beam 2")
                LineAxialRight2.setXData(arrXLineAxialRight)
                LineAxialRight2.setLineWidth(2)
            End If

            If Me.cbBeam3.Checked = True Then
                Dim LineStrainTopLeft3 As LineLayer
                LineStrainTopLeft3 = XYChart_Grafica_StrainLeftEndTopBeams.addLineLayer(arrYLineStrainTopLeft3, colores(3), "Beam 3")
                LineStrainTopLeft3.setXData(arrXLineStrainTopLeft)
                LineStrainTopLeft3.setLineWidth(2)

                Dim LineStrainTopRight3 As LineLayer
                LineStrainTopRight3 = XYChart_Grafica_StrainRightEndTopBeams.addLineLayer(arrYLineStrainTopRight3, colores(3), "Beam 3")
                LineStrainTopRight3.setXData(arrXLineStrainTopRight)
                LineStrainTopRight3.setLineWidth(2)

                Dim LineStrainBottomLeft3 As LineLayer
                LineStrainBottomLeft3 = XYChart_Grafica_StrainLeftEndBottomBeams.addLineLayer(arrYLineStrainBottomLeft3, colores(3), "Beam 3")
                LineStrainBottomLeft3.setXData(arrXLineStrainBottomLeft)
                LineStrainBottomLeft3.setLineWidth(2)

                Dim LineStrainBottomRight3 As LineLayer
                LineStrainBottomRight3 = XYChart_Grafica_StrainRightEndBottomBeams.addLineLayer(arrYLineStrainBottomRight3, colores(3), "Beam 3")
                LineStrainBottomRight3.setXData(arrXLineStrainBottomRight)
                LineStrainBottomRight3.setLineWidth(2)

                Dim LineDCRTopLeft3 As LineLayer
                LineDCRTopLeft3 = XYChart_Grafica_DCRLeftEndTopBeams.addLineLayer(arrYLineDCRTopLeft3, colores(3), "Beam 3")
                LineDCRTopLeft3.setXData(arrXLineDCRTopLeft)
                LineDCRTopLeft3.setLineWidth(2)

                Dim LineDCRBottomLeft3 As LineLayer
                LineDCRBottomLeft3 = XYChart_Grafica_DCRLeftEndBottomBeams.addLineLayer(arrYLineDCRBottomLeft3, colores(3), "Beam 3")
                LineDCRBottomLeft3.setXData(arrXLineDCRBottomLeft)
                LineDCRBottomLeft3.setLineWidth(2)

                Dim LineDCRTopRight3 As LineLayer
                LineDCRTopRight3 = XYChart_Grafica_DCRRightEndTopBeams.addLineLayer(arrYLineDCRTopRight3, colores(3), "Beam 3")
                LineDCRTopRight3.setXData(arrXLineDCRTopRight)
                LineDCRTopRight3.setLineWidth(2)

                Dim LineDCRBotoomRight3 As LineLayer
                LineDCRBotoomRight3 = XYChart_Grafica_DCRRightEndBottom.addLineLayer(arrYLineDCRBotoomRight3, colores(3), "Beam 3")
                LineDCRBotoomRight3.setXData(arrXLineDCRBotoomRight)
                LineDCRBotoomRight3.setLineWidth(2)

                Dim LineMomentLeft3 As LineLayer
                LineMomentLeft3 = XYChart_Grafica_MomentLeftEndBeams.addLineLayer(arrYLineMomentLeft3, colores(3), "Beam 3")
                LineMomentLeft3.setXData(arrXLineMomentLeft)
                LineMomentLeft3.setLineWidth(2)

                Dim LineCurvatureLeft3 As LineLayer
                LineCurvatureLeft3 = XYChart_Grafica_CurvatureLeftEndBeams.addLineLayer(arrYLineCurvatureLeft3, colores(3), "Beam 3")
                LineCurvatureLeft3.setXData(arrXLineCurvatureLeft)
                LineCurvatureLeft3.setLineWidth(2)

                Dim LineMomentRight3 As LineLayer
                LineMomentRight3 = XYChart_Grafica_MomentRightEndBeams.addLineLayer(arrYLineMomentRight3, colores(3), "Beam 3")
                LineMomentRight3.setXData(arrXLineMomentRight)
                LineMomentRight3.setLineWidth(2)

                Dim LineCurvatureRight3 As LineLayer
                LineCurvatureRight3 = XYChart_Grafica_CurvatureRightEndBeams.addLineLayer(arrYLineCurvatureRight3, colores(3), "Beam 3")
                LineCurvatureRight3.setXData(arrXLineCurvatureRight)
                LineCurvatureRight3.setLineWidth(2)

                Dim LineShearLeft3 As LineLayer
                LineShearLeft3 = XYChart_Grafica_ShearLeftEndBeams.addLineLayer(arrYLineShearLeft3, colores(3), "Beam 3")
                LineShearLeft3.setXData(arrXLineShearLeft)
                LineShearLeft3.setLineWidth(2)

                Dim LineAxialLeft3 As LineLayer
                LineAxialLeft3 = XYChart_Grafica_AxialLeftEndBeams.addLineLayer(arrYLineAxialLeft3, colores(3), "Beam 3")
                LineAxialLeft3.setXData(arrXLineAxialLeft)
                LineAxialLeft3.setLineWidth(2)

                Dim LineShearRight3 As LineLayer
                LineShearRight3 = XYChart_Grafica_ShearRightEndBeams.addLineLayer(arrYLineShearRight3, colores(3), "Beam 3")
                LineShearRight3.setXData(arrXLineShearRight)
                LineShearRight3.setLineWidth(2)

                Dim LineAxialRight3 As LineLayer
                LineAxialRight3 = XYChart_Grafica_AxialRightEndBeams.addLineLayer(arrYLineAxialRight3, colores(3), "Beam 3")
                LineAxialRight3.setXData(arrXLineAxialRight)
                LineAxialRight3.setLineWidth(2)
            End If

            If Me.cbBeam4.Checked = True Then
                Dim LineStrainTopLeft4 As LineLayer
                LineStrainTopLeft4 = XYChart_Grafica_StrainLeftEndTopBeams.addLineLayer(arrYLineStrainTopLeft4, colores(4), "Beam 4")
                LineStrainTopLeft4.setXData(arrXLineStrainTopLeft)
                LineStrainTopLeft4.setLineWidth(2)

                Dim LineStrainTopRight4 As LineLayer
                LineStrainTopRight4 = XYChart_Grafica_StrainRightEndTopBeams.addLineLayer(arrYLineStrainTopRight4, colores(4), "Beam 4")
                LineStrainTopRight4.setXData(arrXLineStrainTopRight)
                LineStrainTopRight4.setLineWidth(2)

                Dim LineStrainBottomLeft4 As LineLayer
                LineStrainBottomLeft4 = XYChart_Grafica_StrainLeftEndBottomBeams.addLineLayer(arrYLineStrainBottomLeft4, colores(4), "Beam 4")
                LineStrainBottomLeft4.setXData(arrXLineStrainBottomLeft)
                LineStrainBottomLeft4.setLineWidth(2)

                Dim LineStrainBottomRight4 As LineLayer
                LineStrainBottomRight4 = XYChart_Grafica_StrainRightEndBottomBeams.addLineLayer(arrYLineStrainBottomRight4, colores(4), "Beam 4")
                LineStrainBottomRight4.setXData(arrXLineStrainBottomRight)
                LineStrainBottomRight4.setLineWidth(2)

                Dim LineDCRTopLeft4 As LineLayer
                LineDCRTopLeft4 = XYChart_Grafica_DCRLeftEndTopBeams.addLineLayer(arrYLineDCRTopLeft4, colores(4), "Beam 4")
                LineDCRTopLeft4.setXData(arrXLineDCRTopLeft)
                LineDCRTopLeft4.setLineWidth(2)

                Dim LineDCRBottomLeft4 As LineLayer
                LineDCRBottomLeft4 = XYChart_Grafica_DCRLeftEndBottomBeams.addLineLayer(arrYLineDCRBottomLeft4, colores(4), "Beam 4")
                LineDCRBottomLeft4.setXData(arrXLineDCRBottomLeft)
                LineDCRBottomLeft4.setLineWidth(2)

                Dim LineDCRTopRight4 As LineLayer
                LineDCRTopRight4 = XYChart_Grafica_DCRRightEndTopBeams.addLineLayer(arrYLineDCRTopRight4, colores(4), "Beam 4")
                LineDCRTopRight4.setXData(arrXLineDCRTopRight)
                LineDCRTopRight4.setLineWidth(2)

                Dim LineDCRBotoomRight4 As LineLayer
                LineDCRBotoomRight4 = XYChart_Grafica_DCRRightEndBottom.addLineLayer(arrYLineDCRBotoomRight4, colores(4), "Beam 4")
                LineDCRBotoomRight4.setXData(arrXLineDCRBotoomRight)
                LineDCRBotoomRight4.setLineWidth(2)

                Dim LineMomentLeft4 As LineLayer
                LineMomentLeft4 = XYChart_Grafica_MomentLeftEndBeams.addLineLayer(arrYLineMomentLeft4, colores(4), "Beam 4")
                LineMomentLeft4.setXData(arrXLineMomentLeft)
                LineMomentLeft4.setLineWidth(2)

                Dim LineCurvatureLeft4 As LineLayer
                LineCurvatureLeft4 = XYChart_Grafica_CurvatureLeftEndBeams.addLineLayer(arrYLineCurvatureLeft4, colores(4), "Beam 4")
                LineCurvatureLeft4.setXData(arrXLineCurvatureLeft)
                LineCurvatureLeft4.setLineWidth(2)

                Dim LineMomentRight4 As LineLayer
                LineMomentRight4 = XYChart_Grafica_MomentRightEndBeams.addLineLayer(arrYLineMomentRight4, colores(4), "Beam 4")
                LineMomentRight4.setXData(arrXLineMomentRight)
                LineMomentRight4.setLineWidth(2)

                Dim LineCurvatureRight4 As LineLayer
                LineCurvatureRight4 = XYChart_Grafica_CurvatureRightEndBeams.addLineLayer(arrYLineCurvatureRight4, colores(4), "Beam 4")
                LineCurvatureRight4.setXData(arrXLineCurvatureRight)
                LineCurvatureRight4.setLineWidth(2)

                Dim LineShearLeft4 As LineLayer
                LineShearLeft4 = XYChart_Grafica_ShearLeftEndBeams.addLineLayer(arrYLineShearLeft4, colores(4), "Beam 4")
                LineShearLeft4.setXData(arrXLineShearLeft)
                LineShearLeft4.setLineWidth(2)

                Dim LineAxialLeft4 As LineLayer
                LineAxialLeft4 = XYChart_Grafica_AxialLeftEndBeams.addLineLayer(arrYLineAxialLeft4, colores(4), "Beam 4")
                LineAxialLeft4.setXData(arrXLineAxialLeft)
                LineAxialLeft4.setLineWidth(2)

                Dim LineShearRight4 As LineLayer
                LineShearRight4 = XYChart_Grafica_ShearRightEndBeams.addLineLayer(arrYLineShearRight4, colores(4), "Beam 4")
                LineShearRight4.setXData(arrXLineShearRight)
                LineShearRight4.setLineWidth(2)

                Dim LineAxialRight4 As LineLayer
                LineAxialRight4 = XYChart_Grafica_AxialRightEndBeams.addLineLayer(arrYLineAxialRight4, colores(4), "Beam 4")
                LineAxialRight4.setXData(arrXLineAxialRight)
                LineAxialRight4.setLineWidth(2)


            End If


            '    'Extraccion de coordenadas para section 1 to NumSections
            '    arrXLineSection1(1) = CDbl(figura1(1, 1))
            '    arrYLineSection1(1) = CDbl(figura1(1, 2))
            '    arrXLineSection2(1) = CDbl(figura1(2, 1))
            '    arrYLineSection2(1) = CDbl(figura1(2, 2))
            '    arrXLineSection3(1) = CDbl(figura1(3, 1))
            '    arrYLineSection3(1) = CDbl(figura1(3, 2))

            '    Dim intColorFondoFormulasGraficas As Integer = &HD6DAFF

            '    ' -------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
            '    ' -------------------------------------------------------------------------------
            '    'LEYENDAS DEL GRÁFICO NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA"  
            '    Dim legendBox_EstimCurvaturaFluencia As LegendBox = XYChart_Grafica_EstimCurvaturaFluencia.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 60, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            '    legendBox_EstimCurvaturaFluencia.setBackground(Chart.Transparent)
            '    'Coeficiente de Relacion
            '    Dim txtBox_GraficaEstimCurvaturaFluencia As ChartDirector.TextBox = XYChart_Grafica_EstimCurvaturaFluencia.addText(140, 5, "<*block*>φ<*sub*>y<*/*> = " & FormatNumber(figura1(1, 4), 4) & "<*block*><*size=13*>Ω ε<*sub*>y<*/*> / D", "", 11, &H0)
            '    txtBox_GraficaEstimCurvaturaFluencia.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            '    'DATOS PARA GRAFICAR
            '    Dim arrayDatosGraficaEstimCurvaturaFluenciaX(NumSections) As Double
            '    Dim arrayDatosGraficaEstimCurvaturaFluenciaY(NumSections) As Double
            '    Dim arrayEstimCurvaturaFluenciaLineaTenciaX(NumSections) As Double
            '    Dim arrayEstimCurvaturaFluenciaLineaTenciaY(NumSections) As Double
            '    arrayEstimCurvaturaFluenciaLineaTenciaX(0) = 0
            '    arrayEstimCurvaturaFluenciaLineaTenciaY(0) = 0
            '    ' --------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
            '    ' --------------------------------------------------------------------------------
            '    'LEYENDAS DEL GRÁFICO NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ"  
            '    Dim legendBox_ResistenciaRigidez As LegendBox = XYChart_Grafica_ResistenciaRigidez.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            '    legendBox_ResistenciaRigidez.setBackground(Chart.Transparent)
            '    'Coeficiente de Relacion
            '    Dim txtBox_GraficaResistenciaRigidez As ChartDirector.TextBox = XYChart_Grafica_ResistenciaRigidez.addText(170, 5, "<*block*>M<*sub*>y<*/*> = " & FormatNumber(figura2(1, 4), 4) & " El<*sub*>cr<*/*>", "", 11)
            '    txtBox_GraficaResistenciaRigidez.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            '    Dim arrayDatosGraficaResistenciaRigidezX(NumSections) As Double
            '    Dim arrayDatosGraficaResistenciaRigidezY(NumSections) As Double
            '    'DATOS PARA GRAFICAR
            '    Dim arrayResistenciaRigidezLineaTenciaX(NumSections) As Double
            '    Dim arrayResistenciaRigidezLineaTenciaY(NumSections) As Double
            '    arrayResistenciaRigidezLineaTenciaX(0) = 0
            '    arrayResistenciaRigidezLineaTenciaY(0) = 0
            '    ' --------------------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
            '    ' --------------------------------------------------------------------------------------------------------------------
            '    'LEYENDAS DEL GRÁFICO NÚMERO#4 "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            '    Dim legendBox_InerciaGruesa_Agrietada As LegendBox = XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            '    legendBox_InerciaGruesa_Agrietada.setBackground(Chart.Transparent)
            '    'Coeficiente de Relacion
            '    Dim txtBox_GraficaInerciaGruesa_Agrietada As ChartDirector.TextBox = XYChart_Grafica_InerciaGruesa_Agrietada.addText(140, 5, "<*block*>Icr/Ig = " & FormatNumber(figura3(1, 4), 4) & " ρ + " & FormatNumber(0.0, 4), "", 11)
            '    txtBox_GraficaInerciaGruesa_Agrietada.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            '    'DATOS PARA GRAFICAS
            '    Dim arrayDatosGraficaInerciaGruesa_AgrietadaX(NumSections) As Double
            '    Dim arrayDatosGraficaInerciaGruesa_AgrietadaY(NumSections) As Double
            '    Dim arrayInerciaGruesa_AgrietadaLineaTenciaX(NumSections) As Double
            '    Dim arrayInerciaGruesa_AgrietadaLineaTenciaY(NumSections) As Double
            '    arrayInerciaGruesa_AgrietadaLineaTenciaX(0) = 0
            '    arrayInerciaGruesa_AgrietadaLineaTenciaY(0) = 0
            '    ' --------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
            '    ' --------------------------------------------------------------------------------------------------------
            '    'LEYENDAS DEL GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA"
            '    Dim legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            '    legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.setBackground(Chart.Transparent)
            '    'Coeficiente de Relacion
            '    Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addText(120, 5, "<*block*><*size=13*> ε<*sub*>c<*/*> = " & FormatNumber(figura4(NumSections, 1, 4), 4) & " DΦ ", "", 11)
            '    txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            '    'DATOS PARA GRAFICAS
            '    Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(0) = 0
            '    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(0) = 0
            '    ' ------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
            '    ' ------------------------------------------------------------------------------------------------------
            '    'LEYENDAS DEL GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA"
            '    Dim legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            '    legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES.setBackground(Chart.Transparent)
            '    'Coeficiente de Relacion
            '    Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addText(120, 5, "<*block*><*size=13*> ε<*sub*>c<*/*> = " & FormatNumber(figura5(NumSections, 1, 4), 4) & " DΦ ", "", 11)
            '    txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
            '    'DATOS PARA GRAFICAS
            '    Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    Dim arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(50) As Double 'Variables para las lineas promedio de la Gráficas # 5
            '    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(0) = 0
            '    arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(0) = 0

            '    'GRAFICA LOS PUNTOS PARA TODAS LAS FIGURAS
            '    For i As Integer = 1 To NumSections  'nsections
            '        ' -------------------------------------------------------------------------------
            '        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
            '        ' -------------------------------------------------------------------------------
            '        'Datos Linea de Tendencia
            '        arrayEstimCurvaturaFluenciaLineaTenciaX(i) = figura1(i, 1)
            '        arrayEstimCurvaturaFluenciaLineaTenciaY(i) = figura1(i, 3)
            '        'Coordenadas Puntos
            '        arrayDatosGraficaEstimCurvaturaFluenciaX(i) = figura1(i, 1)
            '        arrayDatosGraficaEstimCurvaturaFluenciaY(i) = figura1(i, 2)
            '        Dim scatterLayerGraficaEstimacionCurvaturaFluencia As ScatterLayer
            '        scatterLayerGraficaEstimacionCurvaturaFluencia = XYChart_Grafica_EstimCurvaturaFluencia.addScatterLayer(arrayDatosGraficaEstimCurvaturaFluenciaX, arrayDatosGraficaEstimCurvaturaFluenciaY, "Section " & i, Chart.DotDashLine, 7, colores(i))
            '        ' --------------------------------------------------------------------------------
            '        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
            '        ' --------------------------------------------------------------------------------
            '        'Datos Linea de Tendencia
            '        arrayResistenciaRigidezLineaTenciaX(i) = figura2(i, 1)
            '        arrayResistenciaRigidezLineaTenciaY(i) = figura2(i, 3)
            '        'Coordenadas Puntos
            '        arrayDatosGraficaResistenciaRigidezX(i) = figura2(i, 1)
            '        arrayDatosGraficaResistenciaRigidezY(i) = figura2(i, 2)
            '        Dim scatterLayerGraficaResistenciaRigidez As ScatterLayer
            '        scatterLayerGraficaResistenciaRigidez = XYChart_Grafica_ResistenciaRigidez.addScatterLayer(arrayDatosGraficaResistenciaRigidezX, arrayDatosGraficaResistenciaRigidezY, "Section " & i, Chart.DotDashLine, 7, colores(i))
            '        ' --------------------------------------------------------------------------------------------------------------------
            '        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
            '        ' --------------------------------------------------------------------------------------------------------------------
            '        'Datos Linea de Tendencia
            '        arrayInerciaGruesa_AgrietadaLineaTenciaX(i) = figura3(i, 1)
            '        arrayInerciaGruesa_AgrietadaLineaTenciaY(i) = figura3(i, 3)
            '        'Coordenadas Puntos
            '        arrayDatosGraficaInerciaGruesa_AgrietadaX(i) = figura3(i, 1)
            '        arrayDatosGraficaInerciaGruesa_AgrietadaY(i) = figura3(i, 2)
            '        Dim scatterLayerGraficaInerciaGruesa_Agrietada As ScatterLayer
            '        scatterLayerGraficaInerciaGruesa_Agrietada = XYChart_Grafica_InerciaGruesa_Agrietada.addScatterLayer(arrayDatosGraficaInerciaGruesa_AgrietadaX, arrayDatosGraficaInerciaGruesa_AgrietadaY, "Section " & i, Chart.DotDashLine, 7, colores(i))
            '        ' --------------------------------------------------------------------------------------------------------
            '        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
            '        ' --------------------------------------------------------------------------------------------------------
            '        'Coordenadas Puntos
            '        For j As Integer = 1 To 50  'nsections  
            '            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(j) = figura4(i, j, 1)
            '            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(j) = figura4(i, j, 2)
            '            arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC(j) = figura4(NumSections, j, 1)
            '            arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(j) = figura4(NumSections, j, 3)
            '        Next
            '        Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC As LineLayer 'Se gráfica con el conjunto de los 50 Datos
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, colores(i))
            '        legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.addKey("Section " & i, colores(i))
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC.setXData(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC)
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_EC.setLineWidth(1)
            '        ' ------------------------------------------------------------------------------------------------------
            '        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
            '        ' ------------------------------------------------------------------------------------------------------
            '        'Coordenadas Puntos
            '        For k As Integer = 1 To 50  'nsections  
            '            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(k) = figura5(i, k, 1)
            '            arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(k) = figura5(i, k, 2)
            '            arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES(k) = figura5(NumSections, k, 1)
            '            arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES(k) = figura5(NumSections, k, 3)
            '        Next
            '        Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES As LineLayer 'Se gráfica con el conjunto de los 50 Datos
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES, colores(i))
            '        legendBox_RelacionDeformacionUnitaria_Curvatura_Y_ES.addKey("Section " & i, colores(i))
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES.setXData(arrayDouGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES)
            '        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_ES.setLineWidth(1)
            '    Next

            '    ' -------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
            '    ' -------------------------------------------------------------------------------
            '    'AGREGA DE LA LINEA DE TENDENCIA 
            '    Dim lineTendenciaEstimacionCurvaturaFluencia As LineLayer
            '    lineTendenciaEstimacionCurvaturaFluencia = XYChart_Grafica_EstimCurvaturaFluencia.addLineLayer(arrayEstimCurvaturaFluenciaLineaTenciaY, colores(0))
            '    lineTendenciaEstimacionCurvaturaFluencia.setXData(arrayEstimCurvaturaFluenciaLineaTenciaX)
            '    lineTendenciaEstimacionCurvaturaFluencia.setLineWidth(2)
            '    ' --------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#3 "RELACION ENTRE RESISTENCIA Y RIGIDEZ" |
            '    ' --------------------------------------------------------------------------------
            '    'AGREGA DE LA LINEA DE TENDENCIA 
            '    Dim lineTendenciaResistenciaRigidez As LineLayer
            '    lineTendenciaResistenciaRigidez = XYChart_Grafica_ResistenciaRigidez.addLineLayer(arrayResistenciaRigidezLineaTenciaY, colores(0))
            '    lineTendenciaResistenciaRigidez.setXData(arrayResistenciaRigidezLineaTenciaX)
            '    lineTendenciaResistenciaRigidez.setLineWidth(2)
            '    ' --------------------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
            '    ' --------------------------------------------------------------------------------------------------------------------
            '    'AGREGA DE LA LINEA DE TENDENCIA 
            '    Dim lineTendenciaInerciaGruesa_AgrietadaLineaTencia As LineLayer
            '    lineTendenciaInerciaGruesa_AgrietadaLineaTencia = XYChart_Grafica_InerciaGruesa_Agrietada.addLineLayer(arrayInerciaGruesa_AgrietadaLineaTenciaY, colores(0))
            '    lineTendenciaInerciaGruesa_AgrietadaLineaTencia.setXData(arrayInerciaGruesa_AgrietadaLineaTenciaX)
            '    lineTendenciaInerciaGruesa_AgrietadaLineaTencia.setLineWidth(2)
            '    ' --------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
            '    ' --------------------------------------------------------------------------------------------------------
            '    'AGREGA DE LA LINEA DE TENDENCIA 
            '    Dim lineTendenciaDeformacionUnitaria_Concreto_Curvatura As LineLayer
            '    lineTendenciaDeformacionUnitaria_Concreto_Curvatura = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, colores(0))
            '    lineTendenciaDeformacionUnitaria_Concreto_Curvatura.setXData(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_EC)
            '    lineTendenciaDeformacionUnitaria_Concreto_Curvatura.setLineWidth(3)
            '    ' ------------------------------------------------------------------------------------------------------
            '    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA"  |
            '    ' ------------------------------------------------------------------------------------------------------
            '    'AGREGA DE LA LINEA DE TENDENCIA 
            '    'arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES
            '    Dim lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1 As LineLayer
            '    lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1 = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_ES, colores(0))
            '    lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1.setXData(arrayDouGraficaLineaTenciaRelacionDeformacionUnitaria_Concreto_Curvatura_X_ES)
            '    lineTendenciaDeformacionUnitaria_Concreto_CurvaturaES1.setLineWidth(3)

            '    subCrearWebChartViewer()

        End Sub
        Sub subGraficarColumnas()

            ''Arreglo de linea StrainTopLeft
            Dim CarrXLineStrainTopLeft(100) As Double
            Dim CarrYLineStrainTopLeft1(100) As Double
            Dim CarrYLineStrainTopLeft2(100) As Double
            Dim CarrYLineStrainTopLeft3(100) As Double
            Dim CarrYLineStrainTopLeft4(100) As Double
            Dim CarrYLineStrainTopLeft5(100) As Double
            Dim CarrYLineStrainTopLeft6(100) As Double

            ''Arreglo de linea StrainTopRight
            Dim CarrXLineStrainTopRight(100) As Double
            Dim CarrYLineStrainTopRight1(100) As Double
            Dim CarrYLineStrainTopRight2(100) As Double
            Dim CarrYLineStrainTopRight3(100) As Double
            Dim CarrYLineStrainTopRight4(100) As Double
            Dim CarrYLineStrainTopRight5(100) As Double
            Dim CarrYLineStrainTopRight6(100) As Double


            ''Arreglo de linea StrainBottomLeft
            Dim CarrXLineStrainBottomLeft(100) As Double
            Dim CarrYLineStrainBottomLeft1(100) As Double
            Dim CarrYLineStrainBottomLeft2(100) As Double
            Dim CarrYLineStrainBottomLeft3(100) As Double
            Dim CarrYLineStrainBottomLeft4(100) As Double
            Dim CarrYLineStrainBottomLeft5(100) As Double
            Dim CarrYLineStrainBottomLeft6(100) As Double

            ''Arreglo de linea StrainBottomRight
            Dim CarrXLineStrainBottomRight(100) As Double
            Dim CarrYLineStrainBottomRight1(100) As Double
            Dim CarrYLineStrainBottomRight2(100) As Double
            Dim CarrYLineStrainBottomRight3(100) As Double
            Dim CarrYLineStrainBottomRight4(100) As Double
            Dim CarrYLineStrainBottomRight5(100) As Double
            Dim CarrYLineStrainBottomRight6(100) As Double


            ''Arreglo de linea DCRTopLeft
            Dim CarrXLineDCRTopLeft(100) As Double
            Dim CarrYLineDCRTopLeft1(100) As Double
            Dim CarrYLineDCRTopLeft2(100) As Double
            Dim CarrYLineDCRTopLeft3(100) As Double
            Dim CarrYLineDCRTopLeft4(100) As Double
            Dim CarrYLineDCRTopLeft5(100) As Double
            Dim CarrYLineDCRTopLeft6(100) As Double

            ''Arreglo de linea DCRBottomLeft
            Dim CarrXLineDCRBottomLeft(100) As Double
            Dim CarrYLineDCRBottomLeft1(100) As Double
            Dim CarrYLineDCRBottomLeft2(100) As Double
            Dim CarrYLineDCRBottomLeft3(100) As Double
            Dim CarrYLineDCRBottomLeft4(100) As Double
            Dim CarrYLineDCRBottomLeft5(100) As Double
            Dim CarrYLineDCRBottomLeft6(100) As Double

            ''Arreglo de linea DCRTopRight
            Dim CarrXLineDCRTopRight(100) As Double
            Dim CarrYLineDCRTopRight1(100) As Double
            Dim CarrYLineDCRTopRight2(100) As Double
            Dim CarrYLineDCRTopRight3(100) As Double
            Dim CarrYLineDCRTopRight4(100) As Double
            Dim CarrYLineDCRTopRight5(100) As Double
            Dim CarrYLineDCRTopRight6(100) As Double

            ''Arreglo de linea DCRBotoomRight
            Dim CarrXLineDCRBotoomRight(100) As Double
            Dim CarrYLineDCRBotoomRight1(100) As Double
            Dim CarrYLineDCRBotoomRight2(100) As Double
            Dim CarrYLineDCRBotoomRight3(100) As Double
            Dim CarrYLineDCRBotoomRight4(100) As Double
            Dim CarrYLineDCRBotoomRight5(100) As Double
            Dim CarrYLineDCRBotoomRight6(100) As Double

            ''Arreglo de linea MomentLeft
            Dim CarrXLineMomentLeft(100) As Double
            Dim CarrYLineMomentLeft1(100) As Double
            Dim CarrYLineMomentLeft2(100) As Double
            Dim CarrYLineMomentLeft3(100) As Double
            Dim CarrYLineMomentLeft4(100) As Double
            Dim CarrYLineMomentLeft5(100) As Double
            Dim CarrYLineMomentLeft6(100) As Double

            ''Arreglo de linea CurvatureLeft
            Dim CarrXLineCurvatureLeft(100) As Double
            Dim CarrYLineCurvatureLeft1(100) As Double
            Dim CarrYLineCurvatureLeft2(100) As Double
            Dim CarrYLineCurvatureLeft3(100) As Double
            Dim CarrYLineCurvatureLeft4(100) As Double
            Dim CarrYLineCurvatureLeft5(100) As Double
            Dim CarrYLineCurvatureLeft6(100) As Double

            ''Arreglo de linea MomentRight
            Dim CarrXLineMomentRight(100) As Double
            Dim CarrYLineMomentRight1(100) As Double
            Dim CarrYLineMomentRight2(100) As Double
            Dim CarrYLineMomentRight3(100) As Double
            Dim CarrYLineMomentRight4(100) As Double
            Dim CarrYLineMomentRight5(100) As Double
            Dim CarrYLineMomentRight6(100) As Double

            ''Arreglo de linea CurvatureRight
            Dim CarrXLineCurvatureRight(100) As Double
            Dim CarrYLineCurvatureRight1(100) As Double
            Dim CarrYLineCurvatureRight2(100) As Double
            Dim CarrYLineCurvatureRight3(100) As Double
            Dim CarrYLineCurvatureRight4(100) As Double
            Dim CarrYLineCurvatureRight5(100) As Double
            Dim CarrYLineCurvatureRight6(100) As Double

            ''Arreglo de linea ShearLeft
            Dim CarrXLineShearLeft(100) As Double
            Dim CarrYLineShearLeft1(100) As Double
            Dim CarrYLineShearLeft2(100) As Double
            Dim CarrYLineShearLeft3(100) As Double
            Dim CarrYLineShearLeft4(100) As Double
            Dim CarrYLineShearLeft5(100) As Double
            Dim CarrYLineShearLeft6(100) As Double

            ''Arreglo de linea AxialLeft
            Dim CarrXLineAxialLeft(100) As Double
            Dim CarrYLineAxialLeft1(100) As Double
            Dim CarrYLineAxialLeft2(100) As Double
            Dim CarrYLineAxialLeft3(100) As Double
            Dim CarrYLineAxialLeft4(100) As Double
            Dim CarrYLineAxialLeft5(100) As Double
            Dim CarrYLineAxialLeft6(100) As Double

            ''Arreglo de linea ShearRight
            Dim CarrXLineShearRight(100) As Double
            Dim CarrYLineShearRight1(100) As Double
            Dim CarrYLineShearRight2(100) As Double
            Dim CarrYLineShearRight3(100) As Double
            Dim CarrYLineShearRight4(100) As Double
            Dim CarrYLineShearRight5(100) As Double
            Dim CarrYLineShearRight6(100) As Double

            ''Arreglo de linea AxialRight
            Dim CarrXLineAxialRight(100) As Double
            Dim CarrYLineAxialRight1(100) As Double
            Dim CarrYLineAxialRight2(100) As Double
            Dim CarrYLineAxialRight3(100) As Double
            Dim CarrYLineAxialRight4(100) As Double
            Dim CarrYLineAxialRight5(100) As Double
            Dim CarrYLineAxialRight6(100) As Double


            'Extraccion de coordenadas para StrainTopLeft
            For n As Integer = 0 To 100
                CarrXLineStrainTopLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineStrainTopLeft1(n) = CDbl(colresponse(1, n, 7))
                CarrYLineStrainTopLeft2(n) = CDbl(colresponse(2, n, 7))
                CarrYLineStrainTopLeft3(n) = CDbl(colresponse(3, n, 7))
                CarrYLineStrainTopLeft4(n) = CDbl(colresponse(4, n, 7))
                CarrYLineStrainTopLeft5(n) = CDbl(colresponse(5, n, 7))
                CarrYLineStrainTopLeft6(n) = CDbl(colresponse(6, n, 7))
            Next

            'Extraccion de coordenadas para StrainTopRight
            For n As Integer = 0 To 100
                CarrXLineStrainTopRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineStrainTopRight1(n) = CDbl(colresponse(1, n, 15))
                CarrYLineStrainTopRight2(n) = CDbl(colresponse(2, n, 15))
                CarrYLineStrainTopRight3(n) = CDbl(colresponse(3, n, 15))
                CarrYLineStrainTopRight4(n) = CDbl(colresponse(4, n, 15))
                CarrYLineStrainTopRight5(n) = CDbl(colresponse(5, n, 15))
                CarrYLineStrainTopRight6(n) = CDbl(colresponse(6, n, 15))
            Next

            'Extraccion de coordenadas para StrainBottomLeft
            For n As Integer = 0 To 100
                CarrXLineStrainBottomLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineStrainBottomLeft1(n) = CDbl(colresponse(1, n, 8))
                CarrYLineStrainBottomLeft2(n) = CDbl(colresponse(2, n, 8))
                CarrYLineStrainBottomLeft3(n) = CDbl(colresponse(3, n, 8))
                CarrYLineStrainBottomLeft4(n) = CDbl(colresponse(4, n, 8))
                CarrYLineStrainBottomLeft5(n) = CDbl(colresponse(5, n, 8))
                CarrYLineStrainBottomLeft6(n) = CDbl(colresponse(6, n, 8))
            Next

            'Extraccion de coordenadas para StrainBottomRight
            For n As Integer = 0 To 100
                CarrXLineStrainBottomRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineStrainBottomRight1(n) = CDbl(colresponse(1, n, 16))
                CarrYLineStrainBottomRight2(n) = CDbl(colresponse(2, n, 16))
                CarrYLineStrainBottomRight3(n) = CDbl(colresponse(3, n, 16))
                CarrYLineStrainBottomRight4(n) = CDbl(colresponse(4, n, 16))
                CarrYLineStrainBottomRight5(n) = CDbl(colresponse(5, n, 16))
                CarrYLineStrainBottomRight6(n) = CDbl(colresponse(6, n, 16))
            Next

            'Extraccion de coordenadas para DCRTopLeft
            For n As Integer = 0 To 100
                CarrXLineDCRTopLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineDCRTopLeft1(n) = CDbl(colresponse(1, n, 1))
                CarrYLineDCRTopLeft2(n) = CDbl(colresponse(2, n, 1))
                CarrYLineDCRTopLeft3(n) = CDbl(colresponse(3, n, 1))
                CarrYLineDCRTopLeft4(n) = CDbl(colresponse(4, n, 1))
                CarrYLineDCRTopLeft5(n) = CDbl(colresponse(5, n, 1))
                CarrYLineDCRTopLeft6(n) = CDbl(colresponse(6, n, 1))
            Next

            'Extraccion de coordenadas para DCRBottomLeft
            For n As Integer = 0 To 100
                CarrXLineDCRBottomLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineDCRBottomLeft1(n) = CDbl(colresponse(1, n, 2))
                CarrYLineDCRBottomLeft2(n) = CDbl(colresponse(2, n, 2))
                CarrYLineDCRBottomLeft3(n) = CDbl(colresponse(3, n, 2))
                CarrYLineDCRBottomLeft4(n) = CDbl(colresponse(4, n, 2))
                CarrYLineDCRBottomLeft5(n) = CDbl(colresponse(5, n, 2))
                CarrYLineDCRBottomLeft6(n) = CDbl(colresponse(6, n, 2))
            Next

            'Extraccion de coordenadas para DCRTopRight
            For n As Integer = 0 To 100
                CarrXLineDCRTopRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineDCRTopRight1(n) = CDbl(colresponse(1, n, 9))
                CarrYLineDCRTopRight2(n) = CDbl(colresponse(2, n, 9))
                CarrYLineDCRTopRight3(n) = CDbl(colresponse(3, n, 9))
                CarrYLineDCRTopRight4(n) = CDbl(colresponse(4, n, 9))
                CarrYLineDCRTopRight5(n) = CDbl(colresponse(5, n, 9))
                CarrYLineDCRTopRight6(n) = CDbl(colresponse(6, n, 9))
            Next

            'Extraccion de coordenadas para DCRBottomRight
            For n As Integer = 0 To 100
                CarrXLineDCRBotoomRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineDCRBotoomRight1(n) = CDbl(colresponse(1, n, 10))
                CarrYLineDCRBotoomRight2(n) = CDbl(colresponse(2, n, 10))
                CarrYLineDCRBotoomRight3(n) = CDbl(colresponse(3, n, 10))
                CarrYLineDCRBotoomRight4(n) = CDbl(colresponse(4, n, 10))
                CarrYLineDCRBotoomRight5(n) = CDbl(colresponse(3, n, 10))
                CarrYLineDCRBotoomRight6(n) = CDbl(colresponse(4, n, 10))
            Next

            'Extraccion de coordenadas para MomentLeft
            For n As Integer = 0 To 100
                CarrXLineMomentLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineMomentLeft1(n) = CDbl(colresponse(1, n, 3))
                CarrYLineMomentLeft2(n) = CDbl(colresponse(2, n, 3))
                CarrYLineMomentLeft3(n) = CDbl(colresponse(3, n, 3))
                CarrYLineMomentLeft4(n) = CDbl(colresponse(4, n, 3))
                CarrYLineMomentLeft5(n) = CDbl(colresponse(5, n, 3))
                CarrYLineMomentLeft6(n) = CDbl(colresponse(6, n, 3))
            Next

            'Extraccion de coordenadas para CurvatureLeft
            For n As Integer = 0 To 100
                CarrXLineCurvatureLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineCurvatureLeft1(n) = CDbl(colresponse(1, n, 4))
                CarrYLineCurvatureLeft2(n) = CDbl(colresponse(2, n, 4))
                CarrYLineCurvatureLeft3(n) = CDbl(colresponse(3, n, 4))
                CarrYLineCurvatureLeft4(n) = CDbl(colresponse(4, n, 4))
                CarrYLineCurvatureLeft5(n) = CDbl(colresponse(3, n, 4))
                CarrYLineCurvatureLeft6(n) = CDbl(colresponse(4, n, 4))
            Next

            'Extraccion de coordenadas para MomentRight
            For n As Integer = 0 To 100
                CarrXLineMomentRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineMomentRight1(n) = CDbl(colresponse(1, n, 11))
                CarrYLineMomentRight2(n) = CDbl(colresponse(2, n, 11))
                CarrYLineMomentRight3(n) = CDbl(colresponse(3, n, 11))
                CarrYLineMomentRight4(n) = CDbl(colresponse(4, n, 11))
                CarrYLineMomentRight5(n) = CDbl(colresponse(3, n, 11))
                CarrYLineMomentRight6(n) = CDbl(colresponse(4, n, 11))
            Next

            'Extraccion de coordenadas para CurvatureRight
            For n As Integer = 0 To 100
                CarrXLineCurvatureRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineCurvatureRight1(n) = CDbl(colresponse(1, n, 12))
                CarrYLineCurvatureRight2(n) = CDbl(colresponse(2, n, 12))
                CarrYLineCurvatureRight3(n) = CDbl(colresponse(3, n, 12))
                CarrYLineCurvatureRight4(n) = CDbl(colresponse(4, n, 12))
                CarrYLineCurvatureRight5(n) = CDbl(colresponse(3, n, 12))
                CarrYLineCurvatureRight6(n) = CDbl(colresponse(4, n, 12))
            Next

            'Extraccion de coordenadas para ShearLeft
            For n As Integer = 0 To 100
                CarrXLineShearLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineShearLeft1(n) = CDbl(colresponse(1, n, 5))
                CarrYLineShearLeft2(n) = CDbl(colresponse(2, n, 5))
                CarrYLineShearLeft3(n) = CDbl(colresponse(3, n, 5))
                CarrYLineShearLeft4(n) = CDbl(colresponse(4, n, 5))
                CarrYLineShearLeft5(n) = CDbl(colresponse(3, n, 5))
                CarrYLineShearLeft6(n) = CDbl(colresponse(4, n, 5))

            Next

            'Extraccion de coordenadas para AxialLeft
            For n As Integer = 0 To 100
                CarrXLineAxialLeft(n) = CDbl(colresponse(1, n, 0))
                CarrYLineAxialLeft1(n) = CDbl(colresponse(1, n, 6))
                CarrYLineAxialLeft2(n) = CDbl(colresponse(2, n, 6))
                CarrYLineAxialLeft3(n) = CDbl(colresponse(3, n, 6))
                CarrYLineAxialLeft4(n) = CDbl(colresponse(4, n, 6))
                CarrYLineAxialLeft5(n) = CDbl(colresponse(5, n, 6))
                CarrYLineAxialLeft6(n) = CDbl(colresponse(6, n, 6))
            Next


            'Extraccion de coordenadas para ShearRight
            For n As Integer = 0 To 100
                CarrXLineShearRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineShearRight1(n) = CDbl(colresponse(1, n, 13))
                CarrYLineShearRight2(n) = CDbl(colresponse(2, n, 13))
                CarrYLineShearRight3(n) = CDbl(colresponse(3, n, 13))
                CarrYLineShearRight4(n) = CDbl(colresponse(4, n, 13))
                CarrYLineShearRight5(n) = CDbl(colresponse(3, n, 13))
                CarrYLineShearRight6(n) = CDbl(colresponse(4, n, 13))
            Next

            'Extraccion de coordenadas para AxialRight
            For n As Integer = 0 To 100
                CarrXLineAxialRight(n) = CDbl(colresponse(1, n, 0))
                CarrYLineAxialRight1(n) = CDbl(colresponse(1, n, 14))
                CarrYLineAxialRight2(n) = CDbl(colresponse(2, n, 14))
                CarrYLineAxialRight3(n) = CDbl(colresponse(3, n, 14))
                CarrYLineAxialRight4(n) = CDbl(colresponse(4, n, 14))
                CarrYLineAxialRight5(n) = CDbl(colresponse(5, n, 14))
                CarrYLineAxialRight6(n) = CDbl(colresponse(6, n, 14))
            Next


            If Me.cbColumn1.Checked = True Then
                Dim CLineStrainTopLeft1 As LineLayer
                CLineStrainTopLeft1 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft1, colores(1), "Column 1")
                CLineStrainTopLeft1.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft1.setLineWidth(2)

                Dim CLineStrainTopRight1 As LineLayer
                CLineStrainTopRight1 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight1, colores(1), "Column 1")
                CLineStrainTopRight1.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight1.setLineWidth(2)

                Dim CLineStrainBottomLeft1 As LineLayer
                CLineStrainBottomLeft1 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft1, colores(1), "Column 1")
                CLineStrainBottomLeft1.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft1.setLineWidth(2)

                Dim CLineStrainBottomRight1 As LineLayer
                CLineStrainBottomRight1 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight1, colores(1), "Column 1")
                CLineStrainBottomRight1.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight1.setLineWidth(2)

                Dim CLineDCRTopLeft1 As LineLayer
                CLineDCRTopLeft1 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft1, colores(1), "Column 1")
                CLineDCRTopLeft1.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft1.setLineWidth(2)

                Dim CLineDCRBottomLeft1 As LineLayer
                CLineDCRBottomLeft1 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft1, colores(1), "Column 1")
                CLineDCRBottomLeft1.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft1.setLineWidth(2)

                Dim CLineDCRTopRight1 As LineLayer
                CLineDCRTopRight1 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight1, colores(1), "Column 1")
                CLineDCRTopRight1.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight1.setLineWidth(2)

                Dim CLineDCRBotoomRight1 As LineLayer
                CLineDCRBotoomRight1 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight1, colores(1), "Column 1")
                CLineDCRBotoomRight1.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight1.setLineWidth(2)

                Dim CLineMomentLeft1 As LineLayer
                CLineMomentLeft1 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft1, colores(1), "Column 1")
                CLineMomentLeft1.setXData(CarrXLineMomentLeft)
                CLineMomentLeft1.setLineWidth(2)

                Dim CLineCurvatureLeft1 As LineLayer
                CLineCurvatureLeft1 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft1, colores(1), "Column 1")
                CLineCurvatureLeft1.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft1.setLineWidth(2)

                Dim CLineMomentRight1 As LineLayer
                CLineMomentRight1 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight1, colores(1), "Column 1")
                CLineMomentRight1.setXData(CarrXLineMomentRight)
                CLineMomentRight1.setLineWidth(2)

                Dim CLineCurvatureRight1 As LineLayer
                CLineCurvatureRight1 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight1, colores(1), "Column 1")
                CLineCurvatureRight1.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight1.setLineWidth(2)

                Dim CLineShearLeft1 As LineLayer
                CLineShearLeft1 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft1, colores(1), "Column 1")
                CLineShearLeft1.setXData(CarrXLineShearLeft)
                CLineShearLeft1.setLineWidth(2)

                Dim CLineAxialLeft1 As LineLayer
                CLineAxialLeft1 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft1, colores(1), "Column 1")
                CLineAxialLeft1.setXData(CarrXLineAxialLeft)
                CLineAxialLeft1.setLineWidth(2)

                Dim CLineShearRight1 As LineLayer
                CLineShearRight1 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight1, colores(1), "Column 1")
                CLineShearRight1.setXData(CarrXLineShearRight)
                CLineShearRight1.setLineWidth(2)

                Dim CLineAxialRight1 As LineLayer
                CLineAxialRight1 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight1, colores(1), "Column 1")
                CLineAxialRight1.setXData(CarrXLineAxialRight)
                CLineAxialRight1.setLineWidth(2)

            End If

            If Me.cdColumn2.Checked = True Then
                Dim CLineStrainTopLeft2 As LineLayer
                CLineStrainTopLeft2 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft2, colores(2), "Column 2")
                CLineStrainTopLeft2.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft2.setLineWidth(2)

                Dim CLineStrainTopRight2 As LineLayer
                CLineStrainTopRight2 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight2, colores(2), "Column 2")
                CLineStrainTopRight2.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight2.setLineWidth(2)

                Dim CLineStrainBottomLeft2 As LineLayer
                CLineStrainBottomLeft2 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft2, colores(2), "Column 2")
                CLineStrainBottomLeft2.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft2.setLineWidth(2)

                Dim CLineStrainBottomRight2 As LineLayer
                CLineStrainBottomRight2 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight2, colores(2), "Column 2")
                CLineStrainBottomRight2.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight2.setLineWidth(2)

                Dim CLineDCRTopLeft2 As LineLayer
                CLineDCRTopLeft2 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft2, colores(2), "Column 2")
                CLineDCRTopLeft2.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft2.setLineWidth(2)

                Dim CLineDCRBottomLeft2 As LineLayer
                CLineDCRBottomLeft2 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft2, colores(2), "Column 2")
                CLineDCRBottomLeft2.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft2.setLineWidth(2)

                Dim CLineDCRTopRight2 As LineLayer
                CLineDCRTopRight2 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight2, colores(2), "Column 2")
                CLineDCRTopRight2.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight2.setLineWidth(2)

                Dim CLineDCRBotoomRight2 As LineLayer
                CLineDCRBotoomRight2 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight2, colores(2), "Column 2")
                CLineDCRBotoomRight2.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight2.setLineWidth(2)

                Dim CLineMomentLeft2 As LineLayer
                CLineMomentLeft2 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft2, colores(2), "Column 2")
                CLineMomentLeft2.setXData(CarrXLineMomentLeft)
                CLineMomentLeft2.setLineWidth(2)

                Dim CLineCurvatureLeft2 As LineLayer
                CLineCurvatureLeft2 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft2, colores(2), "Column 2")
                CLineCurvatureLeft2.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft2.setLineWidth(2)

                Dim CLineMomentRight2 As LineLayer
                CLineMomentRight2 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight2, colores(2), "Column 2")
                CLineMomentRight2.setXData(CarrXLineMomentRight)
                CLineMomentRight2.setLineWidth(2)

                Dim CLineCurvatureRight2 As LineLayer
                CLineCurvatureRight2 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight2, colores(2), "Column 2")
                CLineCurvatureRight2.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight2.setLineWidth(2)

                Dim CLineShearLeft2 As LineLayer
                CLineShearLeft2 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft2, colores(2), "Column 2")
                CLineShearLeft2.setXData(CarrXLineShearLeft)
                CLineShearLeft2.setLineWidth(2)

                Dim CLineAxialLeft2 As LineLayer
                CLineAxialLeft2 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft2, colores(2), "Column 2")
                CLineAxialLeft2.setXData(CarrXLineAxialLeft)
                CLineAxialLeft2.setLineWidth(2)

                Dim CLineShearRight2 As LineLayer
                CLineShearRight2 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight2, colores(2), "Column 2")
                CLineShearRight2.setXData(CarrXLineShearRight)
                CLineShearRight2.setLineWidth(2)

                Dim CLineAxialRight2 As LineLayer
                CLineAxialRight2 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight2, colores(2), "Column 2")
                CLineAxialRight2.setXData(CarrXLineAxialRight)
                CLineAxialRight2.setLineWidth(2)
            End If

            If Me.cdColumn3.Checked = True Then
                Dim CLineStrainTopLeft3 As LineLayer
                CLineStrainTopLeft3 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft3, colores(3), "Column 3")
                CLineStrainTopLeft3.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft3.setLineWidth(2)

                Dim CLineStrainTopRight3 As LineLayer
                CLineStrainTopRight3 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight3, colores(3), "Column 3")
                CLineStrainTopRight3.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight3.setLineWidth(2)

                Dim CLineStrainBottomLeft3 As LineLayer
                CLineStrainBottomLeft3 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft3, colores(3), "Column 3")
                CLineStrainBottomLeft3.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft3.setLineWidth(2)

                Dim CLineStrainBottomRight3 As LineLayer
                CLineStrainBottomRight3 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight3, colores(3), "Column 3")
                CLineStrainBottomRight3.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight3.setLineWidth(2)

                Dim CLineDCRTopLeft3 As LineLayer
                CLineDCRTopLeft3 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft3, colores(3), "Column 3")
                CLineDCRTopLeft3.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft3.setLineWidth(2)

                Dim CLineDCRBottomLeft3 As LineLayer
                CLineDCRBottomLeft3 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft3, colores(3), "Column 3")
                CLineDCRBottomLeft3.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft3.setLineWidth(2)

                Dim CLineDCRTopRight3 As LineLayer
                CLineDCRTopRight3 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight3, colores(3), "Column 3")
                CLineDCRTopRight3.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight3.setLineWidth(2)

                Dim CLineDCRBotoomRight3 As LineLayer
                CLineDCRBotoomRight3 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight3, colores(3), "Column 3")
                CLineDCRBotoomRight3.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight3.setLineWidth(2)

                Dim CLineMomentLeft3 As LineLayer
                CLineMomentLeft3 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft3, colores(3), "Column 3")
                CLineMomentLeft3.setXData(CarrXLineMomentLeft)
                CLineMomentLeft3.setLineWidth(2)

                Dim CLineCurvatureLeft3 As LineLayer
                CLineCurvatureLeft3 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft3, colores(3), "Column 3")
                CLineCurvatureLeft3.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft3.setLineWidth(2)

                Dim CLineMomentRight3 As LineLayer
                CLineMomentRight3 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight3, colores(3), "Column 3")
                CLineMomentRight3.setXData(CarrXLineMomentRight)
                CLineMomentRight3.setLineWidth(2)

                Dim CLineCurvatureRight3 As LineLayer
                CLineCurvatureRight3 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight3, colores(3), "Column 3")
                CLineCurvatureRight3.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight3.setLineWidth(2)

                Dim CLineShearLeft3 As LineLayer
                CLineShearLeft3 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft3, colores(3), "Column 3")
                CLineShearLeft3.setXData(CarrXLineShearLeft)
                CLineShearLeft3.setLineWidth(2)

                Dim CLineAxialLeft3 As LineLayer
                CLineAxialLeft3 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft3, colores(3), "Column 3")
                CLineAxialLeft3.setXData(CarrXLineAxialLeft)
                CLineAxialLeft3.setLineWidth(2)

                Dim CLineShearRight3 As LineLayer
                CLineShearRight3 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight3, colores(3), "Column 3")
                CLineShearRight3.setXData(CarrXLineShearRight)
                CLineShearRight3.setLineWidth(2)

                Dim CLineAxialRight3 As LineLayer
                CLineAxialRight3 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight3, colores(3), "Column 3")
                CLineAxialRight3.setXData(CarrXLineAxialRight)
                CLineAxialRight3.setLineWidth(2)
            End If

            If Me.cdColumn4.Checked = True Then
                Dim CLineStrainTopLeft4 As LineLayer
                CLineStrainTopLeft4 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft4, colores(4), "Column 4")
                CLineStrainTopLeft4.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft4.setLineWidth(2)

                Dim CLineStrainTopRight4 As LineLayer
                CLineStrainTopRight4 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight4, colores(4), "Column 4")
                CLineStrainTopRight4.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight4.setLineWidth(2)

                Dim CLineStrainBottomLeft4 As LineLayer
                CLineStrainBottomLeft4 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft4, colores(4), "Column 4")
                CLineStrainBottomLeft4.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft4.setLineWidth(2)

                Dim CLineStrainBottomRight4 As LineLayer
                CLineStrainBottomRight4 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight4, colores(4), "Column 4")
                CLineStrainBottomRight4.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight4.setLineWidth(2)

                Dim CLineDCRTopLeft4 As LineLayer
                CLineDCRTopLeft4 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft4, colores(4), "Column 4")
                CLineDCRTopLeft4.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft4.setLineWidth(2)

                Dim CLineDCRBottomLeft4 As LineLayer
                CLineDCRBottomLeft4 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft4, colores(4), "Column 4")
                CLineDCRBottomLeft4.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft4.setLineWidth(2)

                Dim CLineDCRTopRight4 As LineLayer
                CLineDCRTopRight4 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight4, colores(4), "Column 4")
                CLineDCRTopRight4.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight4.setLineWidth(2)

                Dim CLineDCRBotoomRight4 As LineLayer
                CLineDCRBotoomRight4 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight4, colores(4), "Column 4")
                CLineDCRBotoomRight4.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight4.setLineWidth(2)

                Dim CLineMomentLeft4 As LineLayer
                CLineMomentLeft4 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft4, colores(4), "Column 4")
                CLineMomentLeft4.setXData(CarrXLineMomentLeft)
                CLineMomentLeft4.setLineWidth(2)

                Dim CLineCurvatureLeft4 As LineLayer
                CLineCurvatureLeft4 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft4, colores(4), "Column 4")
                CLineCurvatureLeft4.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft4.setLineWidth(2)

                Dim CLineMomentRight4 As LineLayer
                CLineMomentRight4 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight4, colores(4), "Column 4")
                CLineMomentRight4.setXData(CarrXLineMomentRight)
                CLineMomentRight4.setLineWidth(2)

                Dim CLineCurvatureRight4 As LineLayer
                CLineCurvatureRight4 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight4, colores(4), "Column 4")
                CLineCurvatureRight4.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight4.setLineWidth(2)

                Dim CLineShearLeft4 As LineLayer
                CLineShearLeft4 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft4, colores(4), "Column 4")
                CLineShearLeft4.setXData(CarrXLineShearLeft)
                CLineShearLeft4.setLineWidth(2)

                Dim CLineAxialLeft4 As LineLayer
                CLineAxialLeft4 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft4, colores(4), "Column 4")
                CLineAxialLeft4.setXData(CarrXLineAxialLeft)
                CLineAxialLeft4.setLineWidth(2)

                Dim CLineShearRight4 As LineLayer
                CLineShearRight4 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight4, colores(4), "Column 4")
                CLineShearRight4.setXData(CarrXLineShearRight)
                CLineShearRight4.setLineWidth(2)

                Dim CLineAxialRight4 As LineLayer
                CLineAxialRight4 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight4, colores(4), "Column 4")
                CLineAxialRight4.setXData(CarrXLineAxialRight)
                CLineAxialRight4.setLineWidth(2)


            End If

            If Me.cdColumn5.Checked = True Then
                Dim CLineStrainTopLeft5 As LineLayer
                CLineStrainTopLeft5 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft5, colores(5), "Column 5")
                CLineStrainTopLeft5.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft5.setLineWidth(2)

                Dim CLineStrainTopRight5 As LineLayer
                CLineStrainTopRight5 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight5, colores(5), "Column 5")
                CLineStrainTopRight5.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight5.setLineWidth(2)

                Dim CLineStrainBottomLeft5 As LineLayer
                CLineStrainBottomLeft5 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft5, colores(5), "Column 5")
                CLineStrainBottomLeft5.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft5.setLineWidth(2)

                Dim CLineStrainBottomRight5 As LineLayer
                CLineStrainBottomRight5 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight5, colores(5), "Column 5")
                CLineStrainBottomRight5.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight5.setLineWidth(2)

                Dim CLineDCRTopLeft5 As LineLayer
                CLineDCRTopLeft5 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft5, colores(5), "Column 5")
                CLineDCRTopLeft5.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft5.setLineWidth(2)

                Dim CLineDCRBottomLeft5 As LineLayer
                CLineDCRBottomLeft5 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft5, colores(5), "Column 5")
                CLineDCRBottomLeft5.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft5.setLineWidth(2)

                Dim CLineDCRTopRight5 As LineLayer
                CLineDCRTopRight5 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight5, colores(5), "Column 5")
                CLineDCRTopRight5.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight5.setLineWidth(2)

                Dim CLineDCRBotoomRight5 As LineLayer
                CLineDCRBotoomRight5 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight5, colores(5), "Column 5")
                CLineDCRBotoomRight5.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight5.setLineWidth(2)

                Dim CLineMomentLeft5 As LineLayer
                CLineMomentLeft5 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft5, colores(5), "Column 5")
                CLineMomentLeft5.setXData(CarrXLineMomentLeft)
                CLineMomentLeft5.setLineWidth(2)

                Dim CLineCurvatureLeft5 As LineLayer
                CLineCurvatureLeft5 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft5, colores(5), "Column 5")
                CLineCurvatureLeft5.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft5.setLineWidth(2)

                Dim CLineMomentRight5 As LineLayer
                CLineMomentRight5 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight5, colores(5), "Column 5")
                CLineMomentRight5.setXData(CarrXLineMomentRight)
                CLineMomentRight5.setLineWidth(2)

                Dim CLineCurvatureRight5 As LineLayer
                CLineCurvatureRight5 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight5, colores(5), "Column 5")
                CLineCurvatureRight5.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight5.setLineWidth(2)

                Dim CLineShearLeft5 As LineLayer
                CLineShearLeft5 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft5, colores(5), "Column 5")
                CLineShearLeft5.setXData(CarrXLineShearLeft)
                CLineShearLeft5.setLineWidth(2)

                Dim CLineAxialLeft5 As LineLayer
                CLineAxialLeft5 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft5, colores(5), "Column 5")
                CLineAxialLeft5.setXData(CarrXLineAxialLeft)
                CLineAxialLeft5.setLineWidth(2)

                Dim CLineShearRight5 As LineLayer
                CLineShearRight5 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight5, colores(5), "Column 5")
                CLineShearRight5.setXData(CarrXLineShearRight)
                CLineShearRight5.setLineWidth(2)

                Dim CLineAxialRight5 As LineLayer
                CLineAxialRight5 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight5, colores(5), "Column 5")
                CLineAxialRight5.setXData(CarrXLineAxialRight)
                CLineAxialRight5.setLineWidth(2)


            End If
            If Me.cdColumn6.Checked = True Then
                Dim CLineStrainTopLeft6 As LineLayer
                CLineStrainTopLeft6 = XYChart_Grafica_StrainLeftEndTopColumns.addLineLayer(CarrYLineStrainTopLeft6, colores(8), "Column 6")
                CLineStrainTopLeft6.setXData(CarrXLineStrainTopLeft)
                CLineStrainTopLeft6.setLineWidth(2)

                Dim CLineStrainTopRight6 As LineLayer
                CLineStrainTopRight6 = XYChart_Grafica_StrainRightEndTopColumns.addLineLayer(CarrYLineStrainTopRight6, colores(8), "Column 6")
                CLineStrainTopRight6.setXData(CarrXLineStrainTopRight)
                CLineStrainTopRight6.setLineWidth(2)

                Dim CLineStrainBottomLeft6 As LineLayer
                CLineStrainBottomLeft6 = XYChart_Grafica_StrainLeftEndBottomColumns.addLineLayer(CarrYLineStrainBottomLeft6, colores(8), "Column 6")
                CLineStrainBottomLeft6.setXData(CarrXLineStrainBottomLeft)
                CLineStrainBottomLeft6.setLineWidth(2)

                Dim CLineStrainBottomRight6 As LineLayer
                CLineStrainBottomRight6 = XYChart_Grafica_StrainRightEndBottomColumns.addLineLayer(CarrYLineStrainBottomRight6, colores(8), "Column 6")
                CLineStrainBottomRight6.setXData(CarrXLineStrainBottomRight)
                CLineStrainBottomRight6.setLineWidth(2)

                Dim CLineDCRTopLeft6 As LineLayer
                CLineDCRTopLeft6 = XYChart_Grafica_DCRLeftEndTopColumns.addLineLayer(CarrYLineDCRTopLeft6, colores(8), "Column 6")
                CLineDCRTopLeft6.setXData(CarrXLineDCRTopLeft)
                CLineDCRTopLeft6.setLineWidth(2)

                Dim CLineDCRBottomLeft6 As LineLayer
                CLineDCRBottomLeft6 = XYChart_Grafica_DCRLeftEndBottomColumns.addLineLayer(CarrYLineDCRBottomLeft6, colores(8), "Column 6")
                CLineDCRBottomLeft6.setXData(CarrXLineDCRBottomLeft)
                CLineDCRBottomLeft6.setLineWidth(2)

                Dim CLineDCRTopRight6 As LineLayer
                CLineDCRTopRight6 = XYChart_Grafica_DCRRightEndTopColumns.addLineLayer(CarrYLineDCRTopRight6, colores(8), "Column 6")
                CLineDCRTopRight6.setXData(CarrXLineDCRTopRight)
                CLineDCRTopRight6.setLineWidth(2)

                Dim CLineDCRBotoomRight6 As LineLayer
                CLineDCRBotoomRight6 = XYChart_Grafica_DCRRightEndBottomColumns.addLineLayer(CarrYLineDCRBotoomRight6, colores(8), "Column 6")
                CLineDCRBotoomRight6.setXData(CarrXLineDCRBotoomRight)
                CLineDCRBotoomRight6.setLineWidth(2)

                Dim CLineMomentLeft6 As LineLayer
                CLineMomentLeft6 = XYChart_Grafica_MomentLeftEndColumns.addLineLayer(CarrYLineMomentLeft6, colores(8), "Column 6")
                CLineMomentLeft6.setXData(CarrXLineMomentLeft)
                CLineMomentLeft6.setLineWidth(2)

                Dim CLineCurvatureLeft6 As LineLayer
                CLineCurvatureLeft6 = XYChart_Grafica_CurvatureLeftEndColumns.addLineLayer(CarrYLineCurvatureLeft6, colores(8), "Column 6")
                CLineCurvatureLeft6.setXData(CarrXLineCurvatureLeft)
                CLineCurvatureLeft6.setLineWidth(2)

                Dim CLineMomentRight6 As LineLayer
                CLineMomentRight6 = XYChart_Grafica_MomentRightEndColumns.addLineLayer(CarrYLineMomentRight6, colores(8), "Column 6")
                CLineMomentRight6.setXData(CarrXLineMomentRight)
                CLineMomentRight6.setLineWidth(2)

                Dim CLineCurvatureRight6 As LineLayer
                CLineCurvatureRight6 = XYChart_Grafica_CurvatureRightEndColumns.addLineLayer(CarrYLineCurvatureRight6, colores(8), "Column 6")
                CLineCurvatureRight6.setXData(CarrXLineCurvatureRight)
                CLineCurvatureRight6.setLineWidth(2)

                Dim CLineShearLeft6 As LineLayer
                CLineShearLeft6 = XYChart_Grafica_ShearLeftEndColumns.addLineLayer(CarrYLineShearLeft6, colores(8), "Column 6")
                CLineShearLeft6.setXData(CarrXLineShearLeft)
                CLineShearLeft6.setLineWidth(2)

                Dim CLineAxialLeft6 As LineLayer
                CLineAxialLeft6 = XYChart_Grafica_AxialLeftEndColumns.addLineLayer(CarrYLineAxialLeft6, colores(8), "Column 6")
                CLineAxialLeft6.setXData(CarrXLineAxialLeft)
                CLineAxialLeft6.setLineWidth(2)

                Dim CLineShearRight6 As LineLayer
                CLineShearRight6 = XYChart_Grafica_ShearRightEndColumns.addLineLayer(CarrYLineShearRight6, colores(8), "Column 6")
                CLineShearRight6.setXData(CarrXLineShearRight)
                CLineShearRight6.setLineWidth(2)

                Dim CLineAxialRight6 As LineLayer
                CLineAxialRight6 = XYChart_Grafica_AxialRightEndColumns.addLineLayer(CarrYLineAxialRight6, colores(8), "Column 6")
                CLineAxialRight6.setXData(CarrXLineAxialRight)
                CLineAxialRight6.setLineWidth(2)


            End If

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
        Sub Limpiar()

        End Sub



        Protected Sub btnGraficarVigas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficarVigas.Click
            subPresentarResultados()
            subGraficar()
            subGraficarColumnas()
            subCrearWebChartViewer()
        End Sub

        Protected Sub btnGraficarColumnas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficarColumnas.Click
            subPresentarResultados()
            subGraficar()
            subGraficarColumnas()
            subCrearWebChartViewer()
        End Sub

        Protected Sub CheckBoxSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxSelectAll.CheckedChanged
            If CheckBoxSelectAll.Checked Then
                Me.cbBeam1.Checked = True
                Me.cbBeam2.Checked = True
                Me.cbBeam3.Checked = True
                Me.cbBeam4.Checked = True
                subPresentarResultados()
                subGraficarColumnas()
                subCrearWebChartViewer()
            Else
                Me.cbBeam1.Checked = False
                Me.cbBeam2.Checked = False
                Me.cbBeam3.Checked = False
                Me.cbBeam4.Checked = False
                subPresentarResultados()
                subGraficarColumnas()
                subCrearWebChartViewer()
            End If


        End Sub

        Protected Sub CheckBoxAllColumns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAllColumns.CheckedChanged
            If CheckBoxSelectAll.Checked Then
                Me.cbColumn1.Checked = True
                Me.cdColumn2.Checked = True
                Me.cdColumn3.Checked = True
                Me.cdColumn4.Checked = True
                Me.cdColumn5.Checked = True
                Me.cdColumn6.Checked = True
                subPresentarResultados()
                subGraficar()
                subCrearWebChartViewer()
            Else
                Me.cbColumn1.Checked = False
                Me.cdColumn2.Checked = False
                Me.cdColumn3.Checked = False
                Me.cdColumn4.Checked = False
                Me.cdColumn5.Checked = False
                Me.cdColumn6.Checked = False
                subPresentarResultados()
                subGraficar()
                subCrearWebChartViewer()
            End If


        End Sub

        Protected Sub cbBeam2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBeam2.CheckedChanged

        End Sub

        Protected Sub cbBeam4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBeam4.CheckedChanged

        End Sub

        Protected Sub cbColumn1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbColumn1.CheckedChanged

        End Sub

        Protected Sub cdColumn2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdColumn2.CheckedChanged

        End Sub
    End Class
End Namespace

