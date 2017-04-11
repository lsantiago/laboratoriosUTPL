Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.OpenAccess
Imports System
Imports System.IO
Imports ChartDirector
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.Web
Imports System.Threading

Public Class General
#Region "VARIABLES GLOBALES"
    REM Variables para parametrizas los gráficos________________________________________________________________________
    Public Shared legendBox As LegendBox
    Public Shared intAnchoGraficas As Integer = 785
    Public Shared intAltoGraficas As Integer = 440
    'Public Shared intColorFondo As Integer = &HEFEFFF REM RGB(10, 20, 30) &HFF0000, &H22AAFF
    Public Shared intColorFondo As Integer = &HFFFFFF
    Public Shared colores() As Integer = {&H2471A3, &HA93226, &H2E4053, &HF1C40F, &H797D7F, &H196F3D, &H5499C7, &HCD6155, &HDC7633, &HA569BD, &HF1948A, &H1A5276, &H873600, &H626567, &H5D6D7E, RGB(225, 100, 120), RGB(84, 96, 250), &HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB, &H0, &HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB, &H0}
    Public Shared intAddLegend_Coord_x As Integer = 400
    Public Shared intAddLegend_Coord_y As Integer = 200
    Public Shared bolAddLegend_Bool As Boolean = False
    Public Shared strAddLegend_Font As String = "Times New Roman Bold"
    Public Shared intAddLegend_FontSize As Integer = 8
    REM ________________________________________________________________________________________________________________
    Public Shared sepuedegraficar As Boolean = False
    Public Shared Acelerograma(,) As Object
    Public Shared AceLoad As Boolean
    REM Para controlar errores Tool1
    Public Shared YaHayGrafico As Boolean = False
    Public Shared MensError As String
    Public Shared HayError As Boolean
    REM Para controlar errores  Tool2
    Public Shared YaHayGrafico1 As Boolean = False
    Public Shared YaHayGraficoAS1 As Boolean = False
    Public Shared MensError1 As String
    Public Shared HayError1 As Boolean
    REM Para controlar errores  Tool3
    Public Shared YaHayGrafico2 As Boolean = False
    Public Shared YaHayGraficoAS2 As Boolean = False
    Public Shared MensError2 As String
    Public Shared HayError2 As Boolean

    Public Shared facStepA As Double
    Public Shared tmaxA As Double
    Public Shared T, DA
    REM DATOS GENERALES:
    Public Shared m, A, TagMaterial
    REM Esto reconocerá el idioma con el que se trabajará
    Public Shared ID As String
    Public Shared usuario
    REM PARA LA LECTURA DE RESULTADOS___________________________________________________________________________________
    Public Shared nLineas As Integer  'Número de lineas del archivo de entrada
    Public Shared nColumnas As Integer 'Número de columnas del archivo de entrada
    Public Shared NombreElemento() As String
    REM ALMACENA EL NUMERO DE DAOS PARA EL GRAFICO DE TODOS LOS ANALISIS
    REM ________________________________________________________________________________________________________________

    REM ALMACENA EN UN VECTOR LAS DURACIONES DE TODOS LOS ANALISIS
    Public Shared MDA(0) As Double
    Public Shared ejeyAS As String
    Public Shared ejexExi As String
    Public Shared ejeyExi As String
    Public Shared ejex1 As String
    Public Shared ejey1 As String
    Public Shared ejex2 As String
    Public Shared ejey2 As String
    Public Shared ejex3 As String
    Public Shared ejey3 As String
    Public Shared ejex4 As String
    Public Shared ejey4 As String
    Public Shared ejex5 As String
    Public Shared ejey5 As String
    Public Shared titRM As String
    REM para los Nudos y elementos
    Public Shared Nudo1, Nudo2, Elemento1, Elemento2, ElementoR1, ElementoR2, ElementoA1, ElementoA2 As String
#End Region
#Region "PARAMETRIZACION DEL WebChartView"
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
    Public Shared Sub CrearGraficasXYChart(ByVal setPlotArea_x As Integer, ByVal setPlotArea_y As Integer, _
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
        'grfGrafica.setRoundedFrame(222, 0, 0, 40, 40)
        REM grfGrafica.setPlotArea(setPlotArea_x, setPlotArea_y, setPlotArea_width, setPlotArea_height, setPlotArea_bgColor, setPlotArea_altBgColor, setPlotArea_edgeColor, setPlotArea_hGridColor, setPlotArea_vGridColor)
        grfGrafica.setPlotArea(setPlotArea_x, setPlotArea_y, setPlotArea_width, setPlotArea_height, setPlotArea_bgColor, setPlotArea_altBgColor, setPlotArea_edgeColor, setPlotArea_hGridColor, setPlotArea_vGridColor).set4QBgColor(&HFFFFFF, &HFFFFFF, &HFFFFFF, &HFFFFFF)
        grfGrafica.addTitle(addTitle_text, addTitle_font, addTitle_fontSize)
        grfGrafica.yAxis().setTitle(yAxis_setTitle_text, yAxis_setTitle_font, yAxis_setTitle_fontSize)
        grfGrafica.yAxis().setWidth(yAxis_setWidth_width)
        grfGrafica.xAxis().setTitle(xAxis_setTitle_text, xAxis_setTitle_font, xAxis_setTitle_fontSize)
        grfGrafica.xAxis().setTickDensity(xAxis_setTickDensityMajorTickSpacing, xAxis_setTickDensityMinorTickSpacing) 'Zoom = + ó - a las lineas graficadas
        grfGrafica.xAxis().setWidth(xAxis_setWidth_width)
        grfGrafica.setClipping()
    End Sub

    ''' <summary>
    ''' Crear los controles gráficos WebChartView, parametrizando los titulos, tamaño, etc.
    ''' Las Graficas son siete, ellas son:
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub establecerPropCtrlGraficos(ByRef grfGrafica As XYChart, ByVal NombreGrafico As String, ByVal ejex As String, ByVal ejey As String)
        REM GRÁFICA N 
        'CrearGraficasXYChart(70, 60, 610, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, NombreGrafico, "Times New Roman Bold", 16, 0, 0, 0, ejey, "Arial Bold Italic", 11, 0, 1, 20, -1, ejex, "Arial Bold Italic", 11, 0, 1, 20, -1, grfGrafica)
        CrearGraficasXYChart(70, 60, 610, 300, &HFFFFFF, -1, -1, &HFFFFFF, &HFFFFFF, "", "Times New Roman Bold", 16, 0, 0, 0, ejey, "Arial", 11, 0, 1, 20, -1, ejex, "Arial", 11, 0, 1, 20, -1, grfGrafica)
        'grfGrafica.addTitle(NombreGrafico, "Times New Roman Bold Italic", 15, &HFFFFFF).setBackground(&H88, 0, _
        'Chart.glassEffect())
        grfGrafica.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize).setBackground(Chart.Transparent)
    End Sub
#End Region
#Region "GRAFICA"
    Public Sub subGraficarXY(ByRef grfGrafica As XYChart, ByVal MGeneral(,,) As Double, ByVal pantalla As Object, ByVal NameGrafic As String, ByVal NameEjex As String, ByVal NameEjey As String, ByVal Pmax As Boolean, ByVal NDatos() As Integer, ByVal NumeroDeserie As Integer)
        Dim i, u As Integer
        Dim Cxmax(0), Cymax(0) As Double
        Dim arrDatosInputFileX() As Double
        Dim arrDatosInputFileY() As Double
        On Error Resume Next
        Dim NombreElemento(NumeroDeserie)
        REM ESTABLEZCO LAS PROPIEDADES DE TODOS LOS GRAFICOS
        establecerPropCtrlGraficos(grfGrafica, NameGrafic, NameEjex, NameEjey)
        For u = 0 To NumeroDeserie
            ReDim arrDatosInputFileX(0)
            ReDim arrDatosInputFileY(0)
            NombreElemento(u) = "Test " & (u + 1)
            Cxmax(0) = 0 : Cymax(0) = 0
            i = 0
            Do
                REM Almaceno los datos del ejex y el ejey
                arrDatosInputFileX(i) = MGeneral(i, 0, u)
                arrDatosInputFileY(i) = MGeneral(i, 1, u)
                If Abs(arrDatosInputFileY(i)) > Abs(Cymax(0)) Then
                    Cxmax(0) = arrDatosInputFileX(i)
                    Cymax(0) = arrDatosInputFileY(i)
                End If
                If NDatos(u) = i Then Exit Do
                i += 1
                ReDim Preserve arrDatosInputFileX(i)
                ReDim Preserve arrDatosInputFileY(i)
            Loop
            REM Realizo la grafica de la u-enesima serie

            Dim linLayerXY As LineLayer = grfGrafica.addLineLayer2()
            linLayerXY = grfGrafica.addLineLayer(arrDatosInputFileY, colores(u), NombreElemento(u))
            linLayerXY.setXData(arrDatosInputFileX)
            Dim AMC() As Double = New Double(4) {1, 2, 3, 4, 5}

            linLayerXY.addExtraField(AMC)
            linLayerXY.setLineWidth(2)

            If Pmax = True Then
                REM el punto max
                Dim layerPmax As LineLayer
                layerPmax = grfGrafica.addScatterLayer(Cxmax, Cymax, "Max", Chart.CircleShape, 12, RGB(0, 250, 250), colores(u))
            Else
                grfGrafica.setAxisAtOrigin(Chart.XYAxisAtOrigin)
            End If
            grfGrafica.addLegend(690, 40)

        Next

        REM Muestro la grafica
        pantalla.Image = grfGrafica.makeWebImage(Chart.PNG)
    End Sub

#End Region
#Region "TRATAMIENTO DE ARCHIVOS"
    ''' <summary>
    ''' Valida y carga el archivo de texto a travez del control "fuFileIn"
    ''' y muetra mensajes personalizados dependiento de error generado 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subCargarArchivo(ByVal NameUpLoad As FileUpload, ByVal LabelMens As Label, ByVal pasoACE As Object, ByVal DurAcce As Object, ByVal ColSep As DropDownList, ByVal ID As String, ByVal UbiSave As String)
        Dim strMensaje As String = Nothing
        On Error Resume Next
        'Ruta de los directorios
        Dim strPathFilesIn As String = "C:/vlee/Dinamica/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(strPathFilesIn) 'Crea el directorio para  los archivos de la simulación
        'Valida que se haya seleccionado un archivo en el control fileupload 
        If NameUpLoad.HasFile Then
            Dim sFileType As String
            sFileType = System.IO.Path.GetExtension(NameUpLoad.FileName) 'Obtiene la extención del archivo a cargar
            sFileType = sFileType.ToLower()
            If (sFileType = ".txt") Then
                NameUpLoad.SaveAs(strPathFilesIn & "Acelerograma.txt") 'Almacenamiento del archivo
                If ID = "ES" Then
                    strMensaje = "LISTO: ¡El archivo se cargó correctamente!"
                ElseIf ID = "EN" Then
                    strMensaje = "OK: The file is loaded correctly!!"
                End If
                AceLoad = True
                LabelMens.Visible = True
                LabelMens.ForeColor = Drawing.Color.Blue
                LabelMens.Text = strMensaje

                Call subLeerAcelerograma(LabelMens, pasoACE, DurAcce, ColSep, ID, UbiSave)
            Else
                If ID = "ES" Then
                    strMensaje = "ERROR: Debe cargar un archivo de texto. Tamaño: <= 4 MB."
                ElseIf ID = "EN" Then
                    strMensaje = "ERROR: You must upload a text file. Size: <= 4 MB."
                End If

                LabelMens.ForeColor = Drawing.Color.Red
                LabelMens.Text = strMensaje 'Muestra el mensaje de error.
            End If
        Else
            If ID = "ES" Then
                strMensaje = "ERROR: Por favor selecione un archivo para Cargar <br> para proceder al analisis"
            ElseIf ID = "EN" Then
                strMensaje = "ERROR: Please select a file to upload <br> to proceed to the analysis"
            End If
            LabelMens.ForeColor = Drawing.Color.Red
            LabelMens.Text = strMensaje 'Muestra el mensaje de error.
        End If

    End Sub

    ''' <summary>
    ''' Abre y lee el archivo cargado y almacena linea por linea en un arreglo.
    ''' </summary>
    ''' <remarks></remarks>
    Sub subLeerAcelerograma(ByVal LabelMens As Label, ByVal pasoACE As Object, ByVal DurAcce As Object, ByVal ColSep As DropDownList, ByVal ID As String, ByVal UbiSave As String)
        On Error Resume Next
        nLineas = 0 : nColumnas = 0
        Dim strMensaje As String = Nothing
        Dim PuedeCargarAce As Boolean = False
        REM Abro el archivo para calcular el número de filas y columnas totales
        Using archivo As StreamReader = New StreamReader("C:/vlee/Dinamica/Acelerograma.txt")
            Dim strLine As String = archivo.ReadLine 'Se lee una Linea
            Select Case ColSep.SelectedValue
                Case 0
                    nColumnas = strLine.Split(Chr(9)).GetUpperBound(0)
                Case 1
                    nColumnas = strLine.Split(" ").GetUpperBound(0)
            End Select

            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                nLineas = nLineas + 1
                strLine = archivo.ReadLine
            End While
        End Using


        nLineas = nLineas - 1
        REM Redimensiono la matriz Acelerograma con el numero de lineas y numero de columnas
        ReDim Acelerograma(nLineas, nColumnas)
        Dim NdatosD As Integer = nLineas * (nColumnas + 1)
        nLineas = 0
        REM Abro el archivo nuevamente para recolectar los datos
        Using archivo As StreamReader = New StreamReader("C:/vlee/Dinamica/Acelerograma.txt")
            Dim j As Integer
            Dim strLine As String = archivo.ReadLine 'Se lee una Linea
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Select Case ColSep.SelectedValue
                    Case 0
                        Dim strLineaAux() As String = strLine.Split(Chr(9))
                        For j = 0 To nColumnas
                            Acelerograma(nLineas, j) = strLineaAux.GetValue(j)
                            If nLineas < 10 Then
                                If IsNumeric((Acelerograma(nLineas, j))) = False Then
                                    If ID = "ES" Then
                                        strMensaje = "ERROR: El archivo debe contener valores numéricos"

                                    ElseIf ID = "EN" Then
                                        strMensaje = "ERROR: The file should contain numerical values"
                                    End If
                                    PuedeCargarAce = False
                                    Exit Sub
                                ElseIf IsNumeric(Acelerograma(nLineas, j)) = True Then
                                    PuedeCargarAce = True
                                End If
                            End If
                        Next

                        nLineas = nLineas + 1
                        strLine = archivo.ReadLine
                    Case 1
                        Dim strLineaAux() As String = strLine.Split(" ")
                        For j = 0 To nColumnas
                            Acelerograma(nLineas, j) = strLineaAux.GetValue(j)
                            If nLineas < 50 Then
                                If IsNumeric((Acelerograma(nLineas, j))) = False Then
                                    If ID = "ES" Then
                                        strMensaje = "ERROR: El archivo debe contener valores numéricos"
                                    ElseIf ID = "EN" Then
                                        strMensaje = "ERROR: The file should contain numerical values"
                                    End If
                                    PuedeCargarAce = False
                                End If
                            End If
                        Next

                        nLineas = nLineas + 1
                        strLine = archivo.ReadLine
                End Select
            End While
            REM Redimensiono la matriz Acelerograma con el numero de lineas y numero de columnas
        End Using
        If PuedeCargarAce = False Then
            LabelMens.ForeColor = Drawing.Color.Red
            LabelMens.Text = strMensaje
            Exit Sub
        End If
        If IsNumeric(DurAcce.text) = True And IsNumeric(pasoACE.text) = True Then
            Dim NdatosN As Integer
            NdatosN = (CDbl(DurAcce.text) / CDbl(pasoACE.text)) + 1
            If NdatosD < NdatosN Then
                PuedeCargarAce = False
                If ID = "ES" Then
                    strMensaje = "ERROR: El número de datos debe ser > o = a Duración/Paso + 1. Osea: " & NdatosN & " datos. <br> Solo tienes: " & NdatosD & " datos. Cambie el paso"
                ElseIf ID = "EN" Then
                    strMensaje = "ERROR: The number of data must be> or = to Time / Step+ 1. Bone:" & NdatosN & " data. <br>  Just: " & NdatosD & " data. Change the step"
                End If
                LabelMens.ForeColor = Drawing.Color.Red
                LabelMens.Text = strMensaje
                Exit Sub
            End If
        Else
            PuedeCargarAce = False

            If ID = "ES" Then
                strMensaje = "ERROR: Ingrese los datos del acelerograma <br> Paso,Duración y Factor de celeración"

            ElseIf ID = "EN" Then
                strMensaje = "ERROR: Enter accelerogram data <br> Step, Duratión  and Factor of acceleration"
            End If
            LabelMens.ForeColor = Drawing.Color.Red
            LabelMens.Text = strMensaje
            Exit Sub
        End If

        Call subAlmAcelerograma(nLineas - 1, nColumnas, ColSep, UbiSave)
    End Sub
    ''' <summary>
    ''' Almacena el acelerograma
    ''' </summary>
    ''' <remarks></remarks>
    Sub subAlmAcelerograma(ByVal nfilas As Integer, ByVal ncolumnas As Integer, ByVal colsep As DropDownList, ByVal UbiSave As String)
        On Error Resume Next
        Dim UbicacionFile, nameFile As String
        UbicacionFile = UbiSave
        nameFile = "Acelerograma.txt"
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFile & nameFile)
        REM Hago uso del archivo
        Using wac As StreamWriter = File.AppendText(UbicacionFile & nameFile)
            Dim Linea As String
            Linea = ""
            For nf As Integer = 0 To nfilas
                For nc As Integer = 0 To ncolumnas
                    REM wac.WriteLine(Acelerograma(nf, nc))
                    If nc = 0 Then
                        Linea = Acelerograma(nf, nc)
                    Else
                        Select Case colsep.SelectedValue
                            Case 0
                                Linea = Linea & Chr(9) & Acelerograma(nf, nc)
                            Case 1
                                Linea = Linea & " " & Acelerograma(nf, nc)
                        End Select

                    End If
                Next
                wac.WriteLine(Linea)
                Linea = ""
            Next
        End Using
    End Sub
    REM DIMENSION DE FIGURAS
    Public Shared Sub DimFiguras(ByVal Imagen As Object, ByVal ancho As Single, ByVal altura As Single)
        Imagen.Width = ancho
        Imagen.Height = altura
    End Sub

#End Region
#Region "ESCRITURA DE ARCHIVO FACTORES DE CARGA PARA OPENSEES"
    REM CARGA LINEAL
    Public Sub WritefCargaL(ByVal UbicacionFile As String, ByVal NombreFile As String)
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFile & NombreFile)
        REM Hago uso del archivo
        Using w As StreamWriter = File.AppendText(UbicacionFile & NombreFile)
            w.WriteLine(0)
            w.WriteLine(1)
            ' Update the underlying file.
            w.Flush()
            ' Close the writer and underlying file.
            w.Close()
        End Using

    End Sub
    REM CARGA TRILINEAL
    Public Sub WriteCargaT(ByVal Pmax As Double, ByVal t1 As Double, ByVal t2 As Double, ByVal t3 As Double, ByVal UbicacionFile As String, ByVal NombreFile As String)
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFile & NombreFile)
        REM Hago uso del archivo
        Dim P(), facP(), incT As Double
        Dim nPt As Integer
        Dim paso As Double
        REM Determino las pendientes de la función trilineal
        Dim pend1, pend2, pend3
        REM Determino las pendientes de la función trilineal
        pend1 = Pmax / t1
        pend2 = 0
        pend3 = Pmax / (t2 - t3)
        incT = 0
        paso = t3 / 7000
        nPt = 0
        Do While incT <= t3
            incT = incT + paso
            nPt = nPt + 1
        Loop
        ReDim P(nPt)
        ReDim facP(nPt)
        incT = 0
        nPt = 0
        Do While incT <= t3
            If incT <= t1 And incT > 0 Then
                P(nPt) = pend1 * incT + 0
            ElseIf incT <= t2 And incT > t1 Then
                P(nPt) = pend2 * (incT - t1) + Pmax
            ElseIf incT < t3 And incT > t2 Then
                P(nPt) = pend3 * (incT - t2) + Pmax
            End If
            facP(nPt) = P(nPt) / Pmax
            incT = incT + paso
            nPt = nPt + 1
        Loop
        Using w As StreamWriter = File.AppendText(UbicacionFile & NombreFile)
            For i As Integer = 0 To nPt
                w.WriteLine(facP(i))
            Next i
            ' Update the underlying file.
            w.Flush()
            ' Close the writer and underlying file.
            w.Close()
        End Using


    End Sub

#End Region
#Region "ESCRITURA DE LOS BATS"
    Public Sub WriteBAT(ByVal UbicacionFileExe As String, ByVal nameExe As String, ByVal UbicacionFileBat As String, ByVal NombreFileBat As String, ByVal NombreFullFileRun As String)
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFileBat & NombreFileBat)
        REM Hago uso del archivo
        Using w As StreamWriter = File.AppendText(UbicacionFileBat & NombreFileBat)
            w.WriteLine("{0} {1}", "cd", UbicacionFileExe)
            w.WriteLine("echo off")
            w.WriteLine("cls")
            w.WriteLine("{0} {1}", """" & nameExe & """", """" & NombreFullFileRun & """")
            w.Flush()
            ' Close the writer and underlying file.
            w.Close()
        End Using

    End Sub

#End Region
End Class



