Imports ChartDirector
Imports AjaxControlToolkit


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_ModuloGrafcSismo_ctrlGraficSismos
        Inherits System.Web.UI.UserControl

        'Private objFacade As Facade.VirtualLabIS.Facade.Cicha.ICicha

#Region "VariablesGlobales"
        '-----------------------------------------------------------------------------------------------
        'Variables para parametrizas los gráficos 
        Private Shared legendBox As LegendBox
        Private Shared intAnchoGraficas As Integer = 500
        Private Shared intAltoGraficas As Integer = 360
        Private Shared intColorFondo As Integer = &HEFEFEE
        'Public XYChart_Grafica_Sismo As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas - 90, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Private Shared XYChart_Grafica_Sismo() As XYChart
        'Public wcvSismo As ChartDirector.WebChartViewer = New ChartDirector.WebChartViewer
        Private Shared wcvSismo() As WebChartViewer
        Private Shared colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB, &H0}
        'Private Shared colores() As Integer = {&H808080, &H9CAEC3, &H73846E, &HB6C9C4, &H9A8273, &H5F7F6A, &HA8A73B, &H8899AA, &HB69BC1, &HAA8822, &HDD8866, &H55C134, &HDDAABB}
        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Private Shared intAddLegend_Coord_x As Integer = 400
        Private Shared intAddLegend_Coord_y As Integer = 120
        Private Shared bolAddLegend_Bool As Boolean = False
        Private Shared strAddLegend_Font As String = "Arial Rounded MT Bold"
        Private Shared intAddLegend_FontSize As Integer = 8
        '-----------------------------------------------------------------------------------------------

        'Objetos
        Private Shared objConstDTO As [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
        'Variables
        Private Shared bolBanderaFileSismo As Boolean
        Private Shared strIdioma As String
        Private Shared getIdioma As String
        Private Shared boolIndicador As Boolean
        Private Shared intTmp As Integer
#End Region

#Region "Idiomas"
        '        ''' <summary>
        '        ''' Este procedimiento establece el idioma de la pagina Los posibles valores que se 
        '        ''' pueden setear para el idioma son: es-ES y en
        '        ''' Metodo compatible "Protected Overrides Sub InitializeCulture()"
        '        ''' </summary>
        '        ''' <remarks></remarks>
        '        Protected Overrides Sub InitializeCulture()
        '            'Asignación del idioma del experimento
        '            strIdioma = Request.Params("idioma")
        '            'Establece el idioma en los controles de los experimentos
        '            If strIdioma = "es-ES" Then
        '                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES")
        '                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-ES")
        '            Else
        '                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en")
        '                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
        '                Exit Sub
        '            End If
        '        End Sub

        '        ''' <summary>
        '        ''' Procedimiento para establecer el idioma a los controles
        '        ''' </summary>
        '        ''' <remarks></remarks>
        '        Protected Sub subSetIdiomaControles()
        '            Me.imgRutaTitulo.ImageUrl = Localization.GetString("imgRutaTitulo.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.lblTituloExp.Text = Localization.GetString("lblTituloExp.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.lblSelectTest.Text = Localization.GetString("lblSelectTest.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.lblTipoSeccion.Text = Localization.GetString("lblTipoSeccion.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.lblTestSpec.Text = Localization.GetString("lblTestSpec.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.cmdIrExp.Text = Localization.GetString("cmdIrExp.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '            Me.cmdNuevoSpecimen.Text = Localization.GetString("cmdNuevoSpecimen.Text", Localization.GetResourceFile(Me, "wfExperimentoCICHA.aspx"))
        '        End Sub

#End Region

#Region "Parametrización de Graficas WebChartView"

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
                                    ByVal yAxis_setTickDensityMajorTickSpacing As Integer, _
                                    ByVal yAxis_setTickDensityMinorTickSpacing As Integer, _
                                    ByVal xAxis_setTitle_text As String, ByVal xAxis_setTitle_font As String, _
                                    ByVal xAxis_setTitle_fontSize As Double, ByVal xAxis_setTitle_fontColor As Integer, _
                                    ByVal xAxis_setWidth_width As Integer, _
                                    ByVal xAxis_setTickDensityMajorTickSpacing As Integer, _
                                    ByVal xAxis_setTickDensityMinorTickSpacing As Integer, _
                                    ByRef grfGrafica As XYChart)
            grfGrafica.setRoundedFrame(222, 0, 0, 0, 0)
            grfGrafica.setPlotArea(setPlotArea_x, setPlotArea_y, setPlotArea_width, setPlotArea_height, setPlotArea_bgColor, setPlotArea_altBgColor, setPlotArea_edgeColor, setPlotArea_hGridColor, setPlotArea_vGridColor)
            grfGrafica.addTitle(addTitle_text, addTitle_font, addTitle_fontSize)
            grfGrafica.yAxis().setTitle(yAxis_setTitle_text, yAxis_setTitle_font, yAxis_setTitle_fontSize)
            grfGrafica.yAxis().setWidth(yAxis_setWidth_width)
            'grfGrafica.yAxis().setTickDensity(yAxis_setTickDensityMajorTickSpacing, yAxis_setTickDensityMinorTickSpacing) 
            grfGrafica.xAxis().setTitle(xAxis_setTitle_text, xAxis_setTitle_font, xAxis_setTitle_fontSize)
            grfGrafica.xAxis().setTickDensity(xAxis_setTickDensityMajorTickSpacing, xAxis_setTickDensityMinorTickSpacing) 'Zoom = + ó - a las lineas graficadas
            grfGrafica.xAxis().setWidth(xAxis_setWidth_width)
            grfGrafica.setClipping()
        End Sub

        ''' <summary>
        ''' Crear los controles gráficos WebChartView, parametrizando los titulos, tamaño, etc.
        ''' Las Graficas son siete, ellas son:
        ''' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub establecerPropCtrlGraficos(ByRef grfGrafica As XYChart)
            ' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
            CrearGraficasXYChart(50, 8, 350, 280, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, Nothing, "Times New Roman Bold", 16, 0, 0, 0, "ACELERATION (m/s^2)", "Arial Bold Italic", 9, 0, 3, 20, -1, "TIME (s)", "Arial Bold Italic", 9, 0, 3, 20, -1, grfGrafica)
            legendBox = grfGrafica.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent, Chart.Transparent)
        End Sub

        ''' <summary>
        ''' Metodo generico para graficar el archivo de entrada Sismico
        ''' </summary>
        ''' <param name="arrayDatosGrafSismoX">Arreglo de valores en X</param>
        ''' <param name="arrayDatosGrafSismoY">Arreglo de valores en Y</param>
        ''' <param name="intColor">Color de la Linea a asignar</param>
        ''' <param name="strNombreLinea">Nombre de la Linea a Asignar</param>
        ''' <remarks></remarks>
        Public Sub subGraficarExpReal(ByVal arrayDatosGrafSismoX As Double(), ByVal arrayDatosGrafSismoY As Double(), ByVal intColor As Integer, ByVal strNombreLinea As String, ByRef grfGrafica As XYChart)
            'ReDim Preserve arrayDatosGrafSismoX(intLimArrayBloque)
            'ReDim Preserve arrayDatosGrafSismoY(intLimArrayBloque)
            Dim linLayerGrafSimul As LineLayer = grfGrafica.addLineLayer2() 'Se gráfica con el conjunto de los 98 Datos
            linLayerGrafSimul = grfGrafica.addLineLayer(arrayDatosGrafSismoY, colores(intColor), strNombreLinea)
            linLayerGrafSimul.setXData(arrayDatosGrafSismoX)
            linLayerGrafSimul.setLineWidth(1)
        End Sub

#End Region

#Region "GenerarGraficasDinamicamente"

        ''' <summary>
        ''' Recorre las matrices que contienen los datos de resultados y crea dinamicamente
        ''' las graficas, configurandolas y agregandolas dinamicamente a una tabla.
        ''' </summary>
        ''' <param name="bouArraySismos">Array undimencional para los registros sísmicos, dentro del ciclo se redincionan</param>
        ''' <remarks></remarks>
        Public Sub subConstruirGraficas(ByVal bouArraySismos(,) As Double)
            Dim intNumSismos As Integer = UBound(bouArraySismos, 1)
            Dim intNPTS As Integer = UBound(bouArraySismos, 2)
            Dim arrayDatosGrafSismoX(intNPTS) As Double
            Dim arrayDatosGrafSismoY(intNPTS) As Double

            ReDim Preserve XYChart_Grafica_Sismo(intNumSismos)
            ReDim Preserve wcvSismo(intNumSismos)
            'XYChart_Grafica_Sismo(intNumSismos) = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
            'wcvSismo(intNumSismos) = New WebChartViewer

            For i As Integer = 0 To intNumSismos
                XYChart_Grafica_Sismo(i) = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
                wcvSismo(i) = New WebChartViewer
                Dim intTime As Double = 0.0
                For j As Integer = 0 To intNPTS
                    arrayDatosGrafSismoX(j) = intTime
                    intTime += 0.01
                Next
                For j As Integer = 0 To intNPTS
                    arrayDatosGrafSismoY(j) = bouArraySismos(i, j)
                Next
                'Establece las propiedades de cada WebChartView creado dinamicamente
                establecerPropCtrlGraficos(XYChart_Grafica_Sismo(i))
                'A la grafica construida enel paso anterior, se le agrega los datos del sísmo
                subGraficarExpReal(arrayDatosGrafSismoX, arrayDatosGrafSismoY, i, "Earthquake " & i + 1, XYChart_Grafica_Sismo(i))
                'Se construye la imagen
                wcvSismo(i).Image = XYChart_Grafica_Sismo(i).makeWebImage(Chart.PNG)
                'Se agrega la imagen "wcvSismo" a la tabla
                subAddWcvSismos(wcvSismo(i))
            Next
        End Sub

        ''' <summary>
        ''' Adehire dinamicamente filas y columnasa un tabla y en esta
        ''' cada gráfica generada.
        ''' </summary>
        ''' <param name="wcvSismo">Control WebChartView que contiene la imagen</param>
        ''' <remarks></remarks>
        Public Sub subAddWcvSismos(ByRef wcvSismo As WebChartViewer)
            'Codigo de Test 
            'Dim grfGrafica1 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0)
            'Dim wcvSismo1 As WebChartViewer = New WebChartViewer
            'establecerPropCtrlGraficos(grfGrafica1)
            'wcvSismo1.Image = grfGrafica1.makeWebImage(Chart.PNG)
            Dim row As HtmlTableRow
            Dim cell As HtmlTableCell
            row = New HtmlTableRow()
            cell = New HtmlTableCell()
            cell.Controls.Add(wcvSismo)
            row.Cells.Add(cell)
            Me.tblGraficSismos.Rows.Add(row)
        End Sub

#End Region

    End Class
End Namespace
