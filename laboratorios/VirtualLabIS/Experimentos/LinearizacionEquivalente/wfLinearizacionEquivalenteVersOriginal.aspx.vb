Imports System.IO
Imports Microsoft.VisualBasic.OpenAccess
Imports System.Math
Imports ChartDirector
Imports System.Data
Imports VLEE_RD
Imports System.Threading

Imports System.Globalization




Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LinearizacionEquivalente_wfLinearizacionEquivalente
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Arreglo de colores para las lineas de los graficos
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}

        'Arreglo para alerta en casos de existir error al momento de correr el experimento
        Dim arrAlertaRUN(,) As String = {{"¡Ocurrio un error en la fase de simulación!"}, _
                                        {"It happened an error in the simulation phase!"}}

        'Arreglo para los ejes de los graficos
        Dim arrTextoEjes(,) As String = {{"DUCTILIDAD", _
                                          "R (Fe/Fi)", _
                                          "C (Δi/Δe)", _
                                          "AMORTIGUAMIENTO EQUIVALENTE (%)", _
                                          "Teff/T"}, _
                                        {"DUCTILITY", _
                                         "R (Fe/Fi)", _
                                         "C (Δi/Δe)", _
                                         "EQUIVALENT DAMPING ξ(%)", _
                                         "Teff/T"}}

        

        'Arreglo de Titulos de Experimentos
        Dim arrTextoTitulosExperimentos(,) As String = {{"REDUCCIÓN DE FUERZA vs. DUCTILIDAD", _
                                                   "COEFICIENTE DE DESPLAZAMIENTO vs DUCTILIDAD", _
                                                   "AMORTIGUAMIENTO VISCOSO EQUIVALENTE vs. DUCTILIDAD", _
                                                   "ALARGAMIENTO DE PERIODO vs. DUCTILIDAD"}, _
                                                   {"STRENGTH REDUCTION FACTOR vs. DUCTILITY", _
                                                   "DISPLACEMENT COEFFICIENT vs. DUCTILITY", _
                                                   "EQUIVALENT VISCOUS DAMPING vs. DUCTILITY", _
                                                   "PERIOD LENGTHENING vs. DUCTILITY"}}

#End Region

#Region "Variables Globales"



        Dim legendBox As LegendBox
        Dim intNumeroIteracionesAMC As Integer
        Public intExpColumna_Id As Integer = 0
        ' Create a XYChart object of size 450 x 450 pixels
        Dim intAnchoGraficas As Integer = 955
        Dim intAltoGraficas As Integer = 390
        Dim intColorFondo As Integer = &HEFEFEE
        Dim XYChart_Grafica_R As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim XYChart_Grafica_Di As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_Damping As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_Teff As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        
        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Dim intAddLegend_Coord_x As Integer = 315
        Dim intAddLegend_Coord_y As Integer = 5
        Dim bolAddLegend_Bool As Boolean = False
        Dim strAddLegend_Font As String = "Arial Rounded MT Bold"
        Dim intAddLegend_FontSize As Integer = 8


        'Datos de entrada del experimento
        Dim file_in(30) As Object

        'Referencia a la DLL Respuesta Dinamica de Sistemas de 1GL
        'Private Shared obj_RD As VLEE_RD.VLEE_RD_DynamicSolver

        'Referencia al codigo de Dinamic en .Net 2005
        Private Shared obj_RD_New As New Dinamica

        'SubDirectorio donde se encuentran los modulos para la definición de la SubEstructura
        Dim strPathCtrlsUsuario As String = "Modulos/" 'SubDirectorio donde se encuentran los modulos para la definición de la SubEstructura

        'Ruta donde se almacena el archivo sismico.
        Shared RutaGeneralArchivosResultados As String = "C:/Inetpub/wwwroot/VLEE/Temp/Exp/LinearizacionEquivalente/"


        'Variable para el control del idioma
        Shared getIdioma As String
        'Identifica el id del idioma del navegador
        Shared idIdioma As Integer


        'Arreglos para almacenar resultados obtenido de la DLL
        Shared arr_lparameters(,) As Object
        Shared intNumPuntos As Integer

        'Almacena el número de lineas dentro de los WebChart
        Shared numLinea As Integer

        'Arreglos para almacenar resultados obtenidos de la DLL
        Shared arr_auxDuct(,) As Double
        Shared arr_auxR(,) As Double
        Shared arr_auxDi(,) As Double
        Shared arr_auxDamping(,) As Double
        Shared arr_auxTeff(,) As Double

        'Arreglo para almacenar el numero de puntos de cada linea
        Shared arr_NumPuntosInputFile(50, 0) As Integer

#End Region

#Region "Metodos Privados"


        ''' <summary>
        ''' Asigna el texto a los controles de la pagina de acuerdo al idioma en el que se cargue.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarIdiomaACtrls()
            'TITULOS GENERALES DEL EXPERIMENTO
            imgTituloLaboratorio.ImageUrl = GetLocalResourceObject("urlTitulo.Text").ToString()
            lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            img1.ImageUrl = GetLocalResourceObject("img1.Text").ToString()
            'TITULOS DE GRAFICOS
            lblTituloFig4.Text = GetLocalResourceObject("lblTituloFig4.Text").ToString()
            lblTituloFig3.Text = GetLocalResourceObject("lblTituloFig3.Text").ToString()
            lblTituloFig2.Text = GetLocalResourceObject("lblTituloFig2.Text").ToString()
            lblTituloFig1.Text = GetLocalResourceObject("lblTituloFig1.Text").ToString()

            lblResultados.Text = GetLocalResourceObject("lblResultados.Text").ToString()

            'PARAMETROS DE ENTRADA
            lblTituloSeccionProper.Text = GetLocalResourceObject("lblTituloSeccionProper.Text").ToString()
            lblPeriodo.Text = GetLocalResourceObject("lblPeriodo.Text").ToString()
            lblMasaProporcional.Text = GetLocalResourceObject("lblMasaProporcional.Text").ToString()
            lblMasa.Text = GetLocalResourceObject("lblMasa.Text").ToString()
            lblFuerzaFluecia.Text = GetLocalResourceObject("lblFuerzaFluecia.Text").ToString()
            lblDuctilidad.Text = GetLocalResourceObject("lblDuctilidad.Text").ToString()
            lblAcelInicial.Text = GetLocalResourceObject("lblAcelInicial.Text").ToString()

            'CONTROL DE EJECUCION
            btnGraficar.Text = GetLocalResourceObject("btnGraficar.Text").ToString()
            btnBorrarUltimoTest.Text = GetLocalResourceObject("btnBorrarUltimoTest.Text").ToString()
            btnBorrarTodosTests.Text = GetLocalResourceObject("btnBorrarTodosTests.Text").ToString()

            'Botones de descarga
            btnGetResult1.Text = GetLocalResourceObject("btnGetResult1.Text").ToString()
            btnGetResult2.Text = GetLocalResourceObject("btnGetResult2.Text").ToString()
            btnGetResult3.Text = GetLocalResourceObject("btnGetResult3.Text").ToString()
            btnGetResult4.Text = GetLocalResourceObject("btnGetResult4.Text").ToString()
        End Sub


        ''' <summary>
        ''' Agrega eventos a los TextBox y Buttons, estos codificados en JavaScript del lado del Cliente
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEstablecerAtributosAControles()
            'Valida que el formato sea correcto, no permite 22.22.22 ni letras hhhfgh
            txtPeriodo.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtPeriodo);")
            txtMasa.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtMasa);")
            txtFuerzaFluecia.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtFuerzaFluecia);")
            txtCoefRigPFluen.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtCoefRigPFluen);")
            txtMasaProporcional.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtMasaProporcional);")
            tbDuctilidad.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbDuctilidad);")

            'Permitir solo ingreso de números
            txtPeriodo.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtMasa.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtFuerzaFluecia.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtCoefRigPFluen.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtMasaProporcional.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbDuctilidad.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")

            'Valida que se haya ingresado todos los parametros
            ' btnGraficar.Attributes.Add("onClick", "return simular();")
        End Sub

        ''' <summary>
        ''' Agrega los controles Gráficos a la Página Web.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCrearWebChartViewer()
            WebChartViewer1.Image = XYChart_Grafica_R.makeWebImage(Chart.PNG)
            
            WebChartViewer2.Image = XYChart_Grafica_Di.makeWebImage(Chart.PNG)
            
            WebChartViewer3.Image = XYChart_Grafica_Damping.makeWebImage(Chart.PNG)
            
            WebChartViewer4.Image = XYChart_Grafica_Teff.makeWebImage(Chart.PNG)
            
        End Sub


        ''' <summary>
        ''' Crear los controles gráficos WebChartView, parametrizando los titulos, tamaño, etc.
        ''' Las Graficas son siete, ellas son:
        ''' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
        ''' GRÁFICA NÚMERO#2   "ESTIMACIÓN DE CURVATURA DE FLUENCIA"
        ''' GRÁFICO NÚMERO#3   "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ"
        ''' GRÁFICO NÚMERO#4   "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
        ''' GRÁFICO NÚMERO#5   "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA"
        ''' GRÁFICA NÚMERO#6   "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" Ec
        ''' GRÁFICA NÚMERO#7   "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" Es        
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub establecerPropCtrlGraficos()
            ' GRÁFICA NÚMERO#1   "ACELERACION DEL SUELO"
            CrearGraficasXYChart(50, 8, 850, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, " ", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_R)
            XYChart_Grafica_R.addLegend(894, 20, False, "Arial Bold", 9).setBackground(Chart.Transparent)

            ' GRÁFICA NÚMERO#2   "FUNCIÓN DE CARGA"
            CrearGraficasXYChart(50, 8, 850, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, " ", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_Di)
            XYChart_Grafica_Di.addLegend(894, 20, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#3   "DESPLAZAMIENTO RELATIVO"
            CrearGraficasXYChart(50, 8, 850, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, " ", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_Damping)
            XYChart_Grafica_Damping.addLegend(894, 20, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#4   "VELOCIDAD RELATIVA"
            CrearGraficasXYChart(50, 8, 850, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, " ", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_Teff)
            XYChart_Grafica_Teff.addLegend(894, 20, False, "Arial Bold", 9).setBackground(Chart.Transparent)
        End Sub

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
        ''' Permite validar si la sesión del usuario aun esta activa antes de ejecutar cualquier proceso, 
        ''' en el caso contrario borra todos los datos del DataTable "dtColumna" y reinicializa todos los controles:
        ''' gráficos, de datos, referencias, etc.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function funcSesionExpirada() As Boolean
            If Session.Item("dtColumna") Is Nothing Then
                '---------Para cuando Experira la Session------------
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                Dim cstext1 As String = "alert('¡EXPIRED SESSION! \n\nAll the data will be erased, \nonly stays the last ones shown');"
                Dim cs As ClientScriptManager = Page.ClientScript
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                '----------------------------------------------------
                'dtColumna = New DTO.dsColumna.COLUMNADataTable
                'Session("dtColumna") = dtColumna
                Session("dtColumna").Clear()
                subEstablecerAtributosAControles()
                establecerPropCtrlGraficos()
                subCrearWebChartViewer()
                Return False
            Else
                Return True
            End If
        End Function
#End Region

#Region "Eventos Protegidos"
        ''' <summary>
        ''' Verifica si es la primera vez que se carga la página para inicializar todos los controles:
        ''' gráficos, de datos, referencias, etc.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Request.IsAuthenticated = True Then
            If Not Page.IsPostBack Then
                    'Creacion del objeto para la interaccion con la DLL de Respuesta Dinamica
                    'obj_RD = New VLEE_RD.VLEE_RD_DynamicSolver

                    '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                    subEstablecerAtributosAControles()
                    establecerPropCtrlGraficos()
                    subAsignarIdiomaACtrls()
                    subCrearWebChartViewer()

                    'Setea el idioma en el control del acelerograma
                    CtrlAcelerograma1.setIdioma = idIdioma
                End If
            'Else
            '    Response.BufferOutput = True
            '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx" & "?idioma=" & getIdioma)
            'End If
        End Sub



        ''' <summary>
        ''' Ejecuta el Análisis Momento Curvatura una vez que el usuario a ingresado los parametros de Diseño de la Columna
        ''' muestra los estandares del AMC y Actualiza el control Flash Dinamico.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnGraficar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficar.Click
            Try
                getDatosInterfaz()
                getResultados()
                subGraficar()
                numLinea += 1
            Catch ex As Exception
                Response.Write("<script>alert('" + arrAlertaRUN(idIdioma, 0) + "')</script>")
            End Try
            
        End Sub


        ''' <summary>
        ''' Obtiene los datos de la interfaz para enviarlos a la DLL
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub getDatosInterfaz()
            'Parametros del experimento
            file_in(1) = txtPeriodo.Text
            file_in(2) = txtMasa.Text
            file_in(3) = txtFuerzaFluecia.Text
            file_in(4) = txtCoefRigPFluen.Text
            file_in(5) = txtMasaProporcional.Text
            file_in(6) = tbDuctilidad.Text
            file_in(7) = CtrlAcelerograma1.getDatosIngresados(0)
            file_in(8) = CtrlAcelerograma1.getDatosIngresados(1)

            'Envio de parametros a la DLL
            obj_RD_New.pasagacceleration(CtrlAcelerograma1.getDatosSismo)
            obj_RD_New.linearization(file_in)
        End Sub


        ''' <summary>
        ''' Obtiene los resultados de la DLL
        ''' </summary>
        ''' <remarks></remarks>
        Sub getResultados()
            'Datos para las graficas
            intNumPuntos = obj_RD_New.return_npoints - 1 'En la DLL los arreglos de resultados empiezan en 1

            'Almacena el numero de puntos de la linea
            arr_NumPuntosInputFile(numLinea, 0) = intNumPuntos

            'Redimensionamiento de la matriz 
            ReDim arr_lparameters(5000, 4)
            
            'Conversion de formato de los vectores para las graficas
            For i As Integer = 0 To intNumPuntos
                For j As Integer = 0 To 4
                    arr_lparameters(i, j) = CDbl(obj_RD_New.return_lparameters(i + 1, j + 1))
                Next
            Next
        End Sub

        ''' <summary>
        ''' Grafica los resultados obtenidos de la DLL
        ''' </summary>
        ''' <remarks></remarks>
        Sub subGraficar()
            establecerPropCtrlGraficos()

            Dim contColores As Integer = 0

            'Arreglo de lineas - Espectro de aceleracion
            Dim lineR As LineLayer
            'Arreglo de lineas - Espectro de velocidad
            Dim lineDi As LineLayer
            'Arreglo de lineas - Espectro de desplazamiento
            Dim lineDamping As LineLayer
            'Arreglo de lineas - Espectro de ductilidad
            Dim lineTeff As LineLayer

            ReDim Preserve arr_auxDuct(50000, numLinea)
            ReDim Preserve arr_auxR(50000, numLinea)
            ReDim Preserve arr_auxDi(50000, numLinea)
            ReDim Preserve arr_auxDamping(50000, numLinea)
            ReDim Preserve arr_auxTeff(50000, numLinea)

            'Asignación de datos de lparameter a los vectores auxiliares para las lineas de los graficos.
            For i As Integer = 0 To intNumPuntos
                arr_auxDuct(i, numLinea) = arr_lparameters(i, 0)
                arr_auxR(i, numLinea) = arr_lparameters(i, 1)
                arr_auxDi(i, numLinea) = arr_lparameters(i, 2)
                arr_auxDamping(i, numLinea) = arr_lparameters(i, 3)
                arr_auxTeff(i, numLinea) = arr_lparameters(i, 4)
            Next


            For i As Integer = 0 To numLinea
                'Reinicia el contador de colores
                If contColores > 12 Then contColores = 0
                'Espectro de R
                lineR = XYChart_Grafica_R.addLineLayer(subExtraerDatosMatriz(arr_auxR, i), colores(contColores), "Test " & i + 1)
                lineR.setXData(subExtraerDatosMatriz(arr_auxDuct, i))
                lineR.setLineWidth(2)
                'Espectro de Di/Dc
                lineDi = XYChart_Grafica_Di.addLineLayer(subExtraerDatosMatriz(arr_auxDi, i), colores(contColores), "Test " & i + 1)
                lineDi.setXData(subExtraerDatosMatriz(arr_auxDuct, i))
                lineDi.setLineWidth(2)
                'Espectro de Eq. Damping
                lineDamping = XYChart_Grafica_Damping.addLineLayer(subExtraerDatosMatriz(arr_auxDamping, i), colores(contColores), "Test " & i + 1)
                lineDamping.setXData(subExtraerDatosMatriz(arr_auxDuct, i))
                lineDamping.setLineWidth(2)
                'Espectro de Teff/T
                lineTeff = XYChart_Grafica_Teff.addLineLayer(subExtraerDatosMatriz(arr_auxTeff, i), colores(contColores), "Test " & i + 1)
                lineTeff.setXData(subExtraerDatosMatriz(arr_auxDuct, i))
                lineTeff.setLineWidth(2)
                contColores += 1
            Next
            
            'Generación de imagenenes
            WebChartViewer1.Image = XYChart_Grafica_R.makeWebImage(Chart.PNG)
            WebChartViewer2.Image = XYChart_Grafica_Di.makeWebImage(Chart.PNG)
            WebChartViewer3.Image = XYChart_Grafica_Damping.makeWebImage(Chart.PNG)
            WebChartViewer4.Image = XYChart_Grafica_Teff.makeWebImage(Chart.PNG)
        End Sub

        'Funcion que extrae arreglo de matriz
        Function subExtraerDatosMatriz(ByVal Matriz(,) As Double, ByVal numl As Integer) As Double()
            Dim arrayAux(arr_NumPuntosInputFile(numl, 0)) As Double
            For i As Integer = 0 To arr_NumPuntosInputFile(numl, 0)
                arrayAux(i) = Matriz(i, numl)
            Next
            Return arrayAux
        End Function


        ''' <summary>
        ''' Establecimiento del idioma de la pagina
        ''' </summary>
        ''' <remarks>
        ''' Los posibles que se pueden setear para el idioma son: es-EC y en-US
        ''' </remarks>
        Protected Overrides Sub InitializeCulture()

            'Asignación del idioma del experimento
            'OJO CON ESTE CAMBIO SOLO ESTA ASI PARA PRUEBAS.
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



#End Region

        Sub presentarEspacioGrafico()
            establecerPropCtrlGraficos()
            subCrearWebChartViewer()
        End Sub


        Protected Sub btnBorrarUltimoTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrarUltimoTest.Click
            If numLinea > 0 Then
                numLinea = numLinea - 2
                ReDim Preserve arr_auxDuct(50000, numLinea)
                ReDim Preserve arr_auxR(50000, numLinea)
                ReDim Preserve arr_auxDi(50000, numLinea)
                ReDim Preserve arr_auxDamping(50000, numLinea)
                ReDim Preserve arr_auxTeff(50000, numLinea)
              
                'numLinea += 1
                subGraficar()
                numLinea += 1
            Else
                presentarEspacioGrafico()
            End If
        End Sub

        Protected Sub btnGetResult1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetResult1.Click, _
        btnGetResult2.Click, _
        btnGetResult3.Click, _
        btnGetResult4.Click
            Dim ge As GenExcell = New GenExcell
            'Variable que almacena el valor de linea que tiene mas puntos
            Dim maxPuntosEnLinea As Integer
            maxPuntosEnLinea = getMaxValue()

            'No enviamos la respuesta hasta que hemos terminado de procesar todo
            Response.Buffer = True

            'Ponemos el tipo de la respuesta al valor adecuado
            Response.ContentType = "application/vnd.ms-excel"

            Select Case CType(sender, Button).ID
                Case "btnGetResult1"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 0) & ".xls")
                    Response.Write(ge.DoExcell(arr_auxDuct, arr_auxR, maxPuntosEnLinea, numLinea - 1, arrTextoTitulosExperimentos(idIdioma, 0), arrTextoEjes(idIdioma, 0), arrTextoEjes(idIdioma, 1), arr_NumPuntosInputFile).ToString)
                Case "btnGetResult2"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 1) & ".xls")
                    Response.Write(ge.DoExcell(arr_auxDuct, arr_auxDi, maxPuntosEnLinea, numLinea - 1, arrTextoTitulosExperimentos(idIdioma, 1), arrTextoEjes(idIdioma, 0), arrTextoEjes(idIdioma, 2), arr_NumPuntosInputFile).ToString)
                Case "btnGetResult3"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 2) & ".xls")
                    Response.Write(ge.DoExcell(arr_auxDuct, arr_auxDamping, maxPuntosEnLinea, numLinea - 1, arrTextoTitulosExperimentos(idIdioma, 2), arrTextoEjes(idIdioma, 0), arrTextoEjes(idIdioma, 3), arr_NumPuntosInputFile).ToString)
                Case "btnGetResult4"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 3) & ".xls")
                    Response.Write(ge.DoExcell(arr_auxDuct, arr_auxTeff, maxPuntosEnLinea, numLinea - 1, arrTextoTitulosExperimentos(idIdioma, 3), arrTextoEjes(idIdioma, 0), arrTextoEjes(idIdioma, 4), arr_NumPuntosInputFile).ToString)
            End Select


            ' Enviamos los datos al cliente
            Response.End()
        End Sub

        'Obtener linea con el maximo numero de puntos.
        Function getMaxValue() As Integer
            Dim intMaxValue As Integer
            intMaxValue = arr_NumPuntosInputFile(0, 0)

            For i As Integer = 0 To 50
                If intMaxValue < arr_NumPuntosInputFile(i, 0) Then
                    intMaxValue = arr_NumPuntosInputFile(i, 0)
                End If
            Next

            Return intMaxValue
        End Function
        Protected Sub btnBorrarTodosTests_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrarTodosTests.Click
            numLinea = 0

            presentarEspacioGrafico()
        End Sub
    End Class
End Namespace

