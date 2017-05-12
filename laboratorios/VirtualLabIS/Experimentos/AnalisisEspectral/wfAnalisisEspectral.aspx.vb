'Version 1.0.1
Imports System.IO
Imports Microsoft.VisualBasic.OpenAccess
Imports System.Math
Imports ChartDirector
Imports System.Data
Imports VLEE_RD
Imports System.Threading

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports System.Globalization


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_Columna_wfAnalisisEspectral
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}

        'Arreglo para alerta en casos de existir error al momento de correr el experimento
        Dim arrAlertaRUN(,) As String = {{"¡Ocurrio un error en la fase de simulación!"}, _
                                        {"It happened an error in the simulation phase!"}}

        'Arreglo para los ejes de los graficos
        Dim arrTextoEjes(,) As String = {{"PERIODO (s)", _
                                          "ACELERACIÓN (m/s <*super*>2)", _
                                          "VELOCIDAD (m/s)", _
                                          "DESPLAZAMIENTO (m)", _
                                          "DUCTILIDAD"}, _
                                        {"PERIOD (s)", _
                                         "ACCELERATION (m/s <*super*>2)", _
                                         "VELOCITY m/s", _
                                         "DISPLACEMENT SPECTRA (m)", _
                                         "DUCTILITY SPECTRA"}}

        Dim arrTextoEjesReporte(,) As String = {{"PERIODO (s)", _
                                                  "ACELERACIÓN (m/s^2)", _
                                                  "VELOCIDAD (m/s)", _
                                                  "DESPLAZAMIENTO (m)", _
                                                  "DUCTILIDAD"}, _
                                                {"PERIOD (s)", _
                                                 "ACCELERATION (m/s^2)", _
                                                 "VELOCITY m/s", _
                                                 "DISPLACEMENT SPECTRA (m)", _
                                                 "DUCTILITY SPECTRA"}}


        'Arreglo de Titulos de Experimentos
        Dim arrTextoTitulosExperimentos(,) As String = {{"ESPECTRO DE ACELERACIÓN", _
                                                   "ESPECTRO DE VELOCIDAD", _
                                                   "ESPECTRO DE DESPLAZAMIENTO", _
                                                   "ESPECTRO DE DUCTILIDAD"}, _
                                                   {"ACCELERATION SPECTRA", _
                                                   "VELOCITY SPECTRA", _
                                                   "DISPLACEMENT SPECTRA", _
                                                   "DUCTILITY SPECTRA"}}
#End Region

#Region "Variables Globales"
        Dim numLinea As Integer
        Dim legendBox As LegendBox
        Dim intNumeroIteracionesAMC As Integer
        Public intExpColumna_Id As Integer = 0
        ' Create a XYChart object of size 450 x 450 pixels
        Dim intAnchoGraficas As Integer = 800
        Dim intAltoGraficas As Integer = 390
        Dim intColorFondo As Integer = &HEFEFEE
        Dim XYChart_Grafica_EspectroAceleracion As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim XYChart_Grafica_EspectroVelocidad As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_EspectroDesplazamiento As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_EspectroDuctilidad As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        
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

        'Arreglos para almacenar resultados obtenido de la DLL
        Shared arr_Aspectrum(,) As Double
        Shared arr_Vspectrum(,) As Double
        Shared arr_Dspectrum(,) As Double
        Shared arr_dductility(,) As Double
        Shared arr_period() As Double
        Shared intNumPuntos As Integer
        Shared intNumCurves As Integer

        'Arreglos auxiliares para datos de graficas
        Dim arr_auxAspectrum() As Double
        Dim arr_auxVspectrum() As Double
        Dim arr_auxDspectrum() As Double
        Dim arr_auxdductility() As Double



#Region "ARREGLOS PARA ALMACENAR DATOS DE LOS TIPOS DE EXITACION"

        'Fucion de carga sinusoidal
        Private Shared ctrlCargaSinusoidal(0) As ASP.virtuallabis_experimentos_analisisespectral_modulos_ctrlcargasinusoidal_ascx
        'Acelerograma
        Private Shared ctrlAcelerograma(0) As ASP.virtuallabis_experimentos_analisisespectral_modulos_ctrlacelerograma_ascx
#End Region

        'SubDirectorio donde se encuentran los modulos para la definición de la SubEstructura
        Dim strPathCtrlsUsuario As String = "Modulos/" 'SubDirectorio donde se encuentran los modulos para la definición de la SubEstructura

        'Ruta donde se almacena el archivo sismico.
        Shared RutaGeneralArchivosResultados As String = "C:/Inetpub/wwwroot/VLEE/Temp/Exp/AnalisisEspectral/"
        'C:\inetpub\wwwroot\VLEE\Temp\Exp\AnalisisEspectral

        'Variable para el control del idioma
        Shared getIdioma As String
        'Identifica el id del idioma del navegador
        Shared idIdioma As Integer
#End Region

#Region "Metodos Privados"


        ''' <summary>
        ''' Ejecuta el "Análisis Momento Curvatura" dado los parametros de Diseño, llamando al método "Analisis_MomentoCurvatura" 
        ''' de la Capa BL, a travez de la Capa Facade. Cada vez que se Ejecuta un análisis, se agregan los datos en el DataTable 
        ''' "dtColumna" en nuevas filas. Solamente desde aqui se crean nuevos registros en el DataTable, solamente desde aqui se 
        ''' controlan la creacion de nuevos Datos.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function subEjecutarAnalisisMC() As Boolean
            ''No decrementar <Session("NumeroIteracionesAMC")> porque es el ID de la Columna
            'Session("NumeroIteracionesAMC") += 1 'Es el contador para el numero de lineas en el 1er grafico
            'intNumeroIteracionesAMC = Session("NumeroIteracionesAMC")
            'drColumna = Session("dtColumna").NewCOLUMNARow
            'Dim intColumna_Id As Integer = intNumeroIteracionesAMC
            'Dim intColumna_Dise_Secuencia As Integer = 0 'Se lo controla con el "dtColumna.Count" que retorna el # de filas insertadas actualmente en el DataTable
            'Dim intExpColumna_Id As Integer = 1
            'Dim booBandera As Boolean = objFacade.Analisis_MomentoCurvatura(intColumna_Id, _
            '                                intExpColumna_Id, _
            '                                intColumna_Dise_Secuencia, _
            '                                txtSectionDiameter.Text, _
            '                                txtConvertLB.Text, _
            '                                txtLongBarDiameter.Text, _
            '                                txtNumberLongBars.Text, _
            '                                txtTransverseReinfDiam.Text, _
            '                                ddTipo.SelectedValue.ToString, _
            '                                txtSpacingTransSteel.Text, _
            '                                txtConcrComprStrength.Text, _
            '                                txtLongRYS.Text, _
            '                                txtTransRYS.Text, _
            '                                txtLongRMX.Text, _
            '                                txtAxialLoad.Text, _
            '                                Session("dtColumna"), drColumna)
            'If booBandera Then
            '    Return True
            'Else
            '    'Si Existen Errores en la DLL del Análisis Momento Curvatura se presentara un Mensaje en JavaScript
            '    'informando del error generado
            '    Dim csname1 As String = "PopupScript"
            '    Dim cstype As Type = Me.GetType()
            '    Dim cstext1 As String = "alert('¡An error arose in the MOMENT CURVATURE RESPONSE! \n\nThis is due to that the parameters of \nhave been entered incorrectly \n\nYou can be helped with: INDICATORS DESING AND ANALYSIS');"
            '    Dim cs As ClientScriptManager = Page.ClientScript
            '    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            '    Return False
            'End If
        End Function

      

        ''' <summary>
        ''' Agrega eventos a los TextBox y Buttons, estos codificados en JavaScript del lado del Cliente
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEstablecerAtributosAControles()
            ''Valida que el formato sea correcto, no permite 22.22.22 ni letras hhhfgh
            tbPeriodo1.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbPeriodo1);")
            tbPeriodo2.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain. tbPeriodo2);")
            tbNumPuntos.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbNumPuntos);")
            tbDamping1.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbDamping1);")
            tbDamping2.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbDamping2);")
            tbNumCurvas.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbNumCurvas);")
            tbDamping3.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbDamping3);")
            tbR1.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbR1);")
            tbR2.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbR2);")
            tbCoefRigidez.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbCoefRigidez);")
            tbNumCurvas2.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbNumCurvas2);")

            'Permitir solo ingreso de números
            tbPeriodo1.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbPeriodo2.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbNumPuntos.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbDamping1.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbDamping2.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbNumCurvas.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbDamping3.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbR1.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbR2.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbCoefRigidez.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            tbNumCurvas2.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        End Sub

        ''' <summary>
        ''' Agrega los controles Gráficos a la Página Web.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCrearWebChartViewer()


            WebChartViewer1.Image = XYChart_Grafica_EspectroAceleracion.makeWebImage(Chart.PNG)




            WebChartViewer2.Image = XYChart_Grafica_EspectroVelocidad.makeWebImage(Chart.PNG)

            WebChartViewer3.Image = XYChart_Grafica_EspectroDesplazamiento.makeWebImage(Chart.PNG)

            WebChartViewer4.Image = XYChart_Grafica_EspectroDuctilidad.makeWebImage(Chart.PNG)

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
            ' GRÁFICA NÚMERO#1   "ESPECTRO ACELERACION"
            CrearGraficasXYChart(60, 5, 800, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 1), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EspectroAceleracion)
            legendBox = XYChart_Grafica_EspectroAceleracion.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent)
            ' GRÁFICA NÚMERO#2   "ESPECTRO VELOCIDAD"
            CrearGraficasXYChart(60, 40, 800, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 2), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EspectroVelocidad)
            XYChart_Grafica_EspectroVelocidad.addLegend(50, 50, False, "Times New Roman Bold Italic", 12).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#3   "ESPECTRO DESPLAZAMIENTO"
            CrearGraficasXYChart(60, 40, 800, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 3), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EspectroDesplazamiento)
            XYChart_Grafica_EspectroDesplazamiento.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#4   "ESPECTRO DUCTILIDAD"
            CrearGraficasXYChart(60, 40, 800, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, arrTextoEjes(idIdioma, 4), "Arial Bold Italic", 9, 0, 3, arrTextoEjes(idIdioma, 0), "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EspectroDuctilidad)
            XYChart_Grafica_EspectroDuctilidad.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
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

#Region "Propiedades Publicas"
        Public Property GetExpColumnaID() As Integer
            Get
                Return intExpColumna_Id
            End Get
            Set(ByVal value As Integer)
                intExpColumna_Id = value
            End Set
        End Property
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
                    'obj_RD_New = New VLEE_RD.VLEE_RD_DynamicSolver

                    '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                    subEstablecerAtributosAControles()
                    establecerPropCtrlGraficos()
                    subCrearWebChartViewer()
                    subAsignarIdiomaACtrls()
                End If


                'CONTROL DE CAMBIO PARA TIPO DE ANALISIS
                If rbAnalisisElastico.Checked Then
                tbDamping1.Visible = True
                tbDamping2.Visible = True
                tbNumCurvas.Visible = True
                lblDamping1.Visible = True
                lblDamping2.Visible = True
                lblNumCurvas.Visible = True

                tbDamping3.Visible = False
                tbR1.Visible = False
                tbR2.Visible = False
                tbCoefRigidez.Visible = False
                tbNumCurvas2.Visible = False
                lblDamping3.Visible = False
                lblR1.Visible = False
                lblR2.Visible = False
                lblCoefRigidez.Visible = False
                lblNumCurvas2.Visible = False
                img2.Visible = True
                'img3.Visible = False

                RequiredFieldValidator9.Enabled = False
                RequiredFieldValidator10.Enabled = False
                RequiredFieldValidator11.Enabled = False
                RequiredFieldValidator12.Enabled = False
                RequiredFieldValidator13.Enabled = False

                RequiredFieldValidator6.Enabled = True
                RequiredFieldValidator7.Enabled = True
                RequiredFieldValidator8.Enabled = True


            ElseIf rbAnalisisInelastico.Checked Then
                tbDamping3.Visible = True
                tbR1.Visible = True
                tbR2.Visible = True
                tbCoefRigidez.Visible = True
                tbNumCurvas2.Visible = True
                lblDamping3.Visible = True
                lblR1.Visible = True
                lblR2.Visible = True
                lblCoefRigidez.Visible = True
                lblNumCurvas2.Visible = True

                tbDamping1.Visible = False
                tbDamping2.Visible = False
                tbNumCurvas.Visible = False
                lblDamping1.Visible = False
                lblDamping2.Visible = False
                lblNumCurvas.Visible = False
                img2.Visible = False
                'img3.Visible = True

                RequiredFieldValidator9.Enabled = True
                RequiredFieldValidator10.Enabled = True
                    RequiredFieldValidator11.Enabled = True
                    RequiredFieldValidator12.Enabled = True
                    RequiredFieldValidator13.Enabled = True

                    RequiredFieldValidator6.Enabled = False
                    RequiredFieldValidator7.Enabled = False
                    RequiredFieldValidator8.Enabled = False
                End If

                'Limpia los controles seleccionados por el usuario
                phTipoExitacion.Controls.Clear()

                If rbAcelerograma.Checked Then
                    ctrlAcelerograma(0) = CType(LoadControl(strPathCtrlsUsuario + "ctrlAcelerograma.ascx"),
                                                     ASP.virtuallabis_experimentos_analisisespectral_modulos_ctrlacelerograma_ascx)
                    ctrlAcelerograma(0).setRuta = RutaGeneralArchivosResultados
                    'Asignación del idioma a los controles del modulo del acelerograma.
                    ctrlAcelerograma(0).setIdioma = idIdioma
                    phTipoExitacion.Controls.Add(ctrlAcelerograma(0))
                ElseIf rbCargaSinusoidal.Checked Then
                    ctrlCargaSinusoidal(0) = CType(LoadControl(strPathCtrlsUsuario + "ctrlCargaSinusoidal.ascx"), _
                                                                     ASP.virtuallabis_experimentos_analisisespectral_modulos_ctrlcargasinusoidal_ascx)
                    phTipoExitacion.Controls.Add(ctrlCargaSinusoidal(0))

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
            Catch ex As Exception
                Response.Write("<script>alert('" + arrAlertaRUN(idIdioma, 0) + "')</script>")
            End Try
        End Sub


        Protected Sub getDatosInterfaz()
            If rbAnalisisElastico.Checked Then
                If rbCargaSinusoidal.Checked Then
                    'Response.Write("<script>alert('Vibracion Libre')</script>")
                    file_in(0) = ctrlCargaSinusoidal(0).getDatosIngresados(0)
                    file_in(1) = ctrlCargaSinusoidal(0).getDatosIngresados(2)
                    file_in(2) = ctrlCargaSinusoidal(0).getDatosIngresados(1)
                    file_in(3) = tbPeriodo1.Text
                    file_in(4) = tbPeriodo2.Text
                    file_in(5) = tbNumPuntos.Text
                    file_in(6) = tbMasa.Text
                    file_in(7) = tbDamping1.Text
                    file_in(8) = tbDamping2.Text
                    file_in(9) = tbNumCurvas.Text
                    obj_RD_New.spectralanalysissine(file_in)
                ElseIf rbAcelerograma.Checked Then
                    file_in(0) = "Modificar esto."
                    file_in(1) = ctrlAcelerograma(0).getDatosIngresados(2)
                    file_in(2) = ctrlAcelerograma(0).getDatosIngresados(0)
                    file_in(3) = ctrlAcelerograma(0).getDatosIngresados(1)
                    file_in(4) = tbPeriodo1.Text
                    file_in(5) = tbPeriodo2.Text
                    file_in(6) = tbNumPuntos.Text
                    file_in(7) = tbMasa.Text
                    file_in(8) = tbDamping1.Text
                    file_in(9) = tbDamping2.Text
                    file_in(10) = tbNumCurvas.Text

                    obj_RD_New.pasagacceleration(ctrlAcelerograma(0).getDatosSismo)
                    obj_RD_New.spectralanalysiseq(file_in)
                End If

            ElseIf rbAnalisisInelastico.Checked Then
                If rbCargaSinusoidal.Checked Then
                    'Response.Write("<script>alert('Vibracion Libre')</script>")
                    file_in(0) = ctrlCargaSinusoidal(0).getDatosIngresados(0)
                    file_in(1) = ctrlCargaSinusoidal(0).getDatosIngresados(2)
                    file_in(2) = ctrlCargaSinusoidal(0).getDatosIngresados(1)
                    file_in(3) = tbPeriodo1.Text
                    file_in(4) = tbPeriodo2.Text
                    file_in(5) = tbNumPuntos.Text
                    file_in(6) = tbMasa.Text
                    file_in(7) = tbR1.Text
                    file_in(8) = tbR2.Text
                    file_in(9) = tbNumCurvas2.Text
                    file_in(9) = tbCoefRigidez.Text
                    file_in(9) = tbDamping3.Text
                    obj_RD_New.spectralanalysissine_nonlinear(file_in)
                ElseIf rbAcelerograma.Checked Then
                    file_in(0) = "Modificar esto."
                    file_in(1) = ctrlAcelerograma(0).getDatosIngresados(2)
                    file_in(2) = ctrlAcelerograma(0).getDatosIngresados(0)
                    file_in(3) = ctrlAcelerograma(0).getDatosIngresados(1)
                    file_in(4) = tbPeriodo1.Text
                    file_in(5) = tbPeriodo2.Text
                    file_in(6) = tbNumPuntos.Text
                    file_in(7) = tbMasa.Text
                    file_in(8) = tbR1.Text
                    file_in(9) = tbR2.Text
                    file_in(10) = tbNumCurvas2.Text
                    file_in(11) = tbCoefRigidez.Text
                    file_in(12) = tbDamping3.Text

                    obj_RD_New.pasagacceleration(ctrlAcelerograma(0).getDatosSismo)
                    obj_RD_New.inelasticspectrum(file_in)
                End If
            End If



        End Sub

        Sub getResultados()
            'Datos para las graficas
            intNumPuntos = obj_RD_New.return_npointsspectrum
            intNumCurves = obj_RD_New.return_ncurves

            'Redimensionamiento de vectores de graficos


            ReDim arr_Aspectrum(intNumPuntos, intNumCurves)
            ReDim arr_Vspectrum(intNumPuntos, intNumCurves)
            ReDim arr_Dspectrum(intNumPuntos, intNumCurves)
            ReDim arr_dductility(intNumPuntos, intNumCurves)
            ReDim arr_period(intNumPuntos)


            'Conversion de formato de los vectores para las graficas
            For i As Integer = 0 To intNumPuntos
                arr_period(i) = CDbl(obj_RD_New.return_period(i))
                For j As Integer = 0 To intNumCurves
                    arr_Aspectrum(i, j) = CDbl(obj_RD_New.return_Aspectrum(i, j))
                    arr_Vspectrum(i, j) = CDbl(obj_RD_New.return_Vspectrum(i, j))
                    arr_Dspectrum(i, j) = CDbl(obj_RD_New.return_Dspectrum(i, j))
                    arr_dductility(i, j) = CDbl(obj_RD_New.return_ductility(i, j))
                Next
            Next

            'Response.Write("<script>alert('" & arr_Dhistory(intNumPuntos).ToString & "')</script>")

        End Sub

        Sub subGraficar()
            establecerPropCtrlGraficos()

            Dim contColors As Integer = 0

            'Arreglo de lineas - Espectro de aceleracion
            Dim lineEA(intNumCurves) As LineLayer
            'Arreglo de lineas - Espectro de velocidad
            Dim lineEV(intNumCurves) As LineLayer
            'Arreglo de lineas - Espectro de desplazamiento
            Dim lineED(intNumCurves) As LineLayer
            'Arreglo de lineas - Espectro de ductilidad
            Dim lineEDuct(intNumCurves) As LineLayer

            ReDim arr_auxAspectrum(intNumPuntos)
            ReDim arr_auxVspectrum(intNumPuntos)
            ReDim arr_auxDspectrum(intNumPuntos)
            ReDim arr_auxdductility(intNumPuntos)

            For i As Integer = 0 To intNumCurves
                For i2 As Integer = 0 To intNumPuntos
                    arr_auxAspectrum(i2) = arr_Aspectrum(i2, i)
                    arr_auxVspectrum(i2) = arr_Vspectrum(i2, i)
                    arr_auxDspectrum(i2) = arr_Dspectrum(i2, i)
                    arr_auxdductility(i2) = arr_dductility(i2, i)
                Next

                If contColors > 12 Then 'Si los colores superan los 12, se inicializan en el rojo 
                    contColors = 0
                End If

                'Espectro de aceleracion
                lineEA(i) = XYChart_Grafica_EspectroAceleracion.addLineLayer(arr_auxAspectrum, colores(contColors))
                lineEA(i).setXData(arr_period)
                lineEA(i).setLineWidth(2)
                'Espectro de velocidad
                lineEV(i) = XYChart_Grafica_EspectroVelocidad.addLineLayer(arr_auxVspectrum, colores(contColors))
                lineEV(i).setXData(arr_period)
                lineEV(i).setLineWidth(2)
                'Espectro de desplazamiento
                lineED(i) = XYChart_Grafica_EspectroDesplazamiento.addLineLayer(arr_auxDspectrum, colores(contColors))
                lineED(i).setXData(arr_period)
                lineED(i).setLineWidth(2)
                'Espectro de ductilidad
                lineEDuct(i) = XYChart_Grafica_EspectroDuctilidad.addLineLayer(arr_auxdductility, colores(contColors))
                lineEDuct(i).setXData(arr_period)
                lineEDuct(i).setLineWidth(2)
                contColors += 1
            Next

            'Creacion de imagenenes
            WebChartViewer1.Image = XYChart_Grafica_EspectroAceleracion.makeWebImage(Chart.PNG)
            WebChartViewer2.Image = XYChart_Grafica_EspectroVelocidad.makeWebImage(Chart.PNG)
            WebChartViewer3.Image = XYChart_Grafica_EspectroDesplazamiento.makeWebImage(Chart.PNG)
            WebChartViewer4.Image = XYChart_Grafica_EspectroDuctilidad.makeWebImage(Chart.PNG)
        End Sub

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


        ''' <summary>
        ''' Asigna el texto a los controles de la pagina de acuerdo al idioma en el que se cargue.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarIdiomaACtrls()
            'TITULOS GENERALES DEL EXPERIMENTO
            'imgTituloLaboratorio.ImageUrl = GetLocalResourceObject("urlTitulo.Text").ToString()
            'lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            lblTituloEsquemaColumna.Text = GetLocalResourceObject("lblTituloEsquemaColumna.Text").ToString()
            img1.ImageUrl = GetLocalResourceObject("img1.Text").ToString()
            img2.ImageUrl = GetLocalResourceObject("img2.Text").ToString()
            'img3.ImageUrl = GetLocalResourceObject("img3.Text").ToString()
            'TITULOS DE GRAFICOS
            'lblTituloFig4.Text = GetLocalResourceObject("lblTituloFig4.Text").ToString()
            'lblTituloFig3.Text = GetLocalResourceObject("lblTituloFig3.Text").ToString()
            'lblTituloFig2.Text = GetLocalResourceObject("lblTituloFig2.Text").ToString()
            'lblTituloFig1.Text = GetLocalResourceObject("lblTituloFig1.Text").ToString()

            'lblResultados.Text = = GetLocalResourceObject("lblResultados.Text").ToString()

            'PARAMETROS DE ENTRADA
            lblTituloSeccionProper.Text = GetLocalResourceObject("lblTituloSeccionProper.Text").ToString()
            lblPeriodo1.Text = GetLocalResourceObject("lblPeriodo1.Text").ToString()
            lblPeriodo2.Text = GetLocalResourceObject("lblPeriodo2.Text").ToString()
            lblNumPuntos.Text = GetLocalResourceObject("lblNumPuntos.Text").ToString()
            lblMasa.Text = GetLocalResourceObject("lblMasa.Text").ToString()
            lblAElastico.Text = GetLocalResourceObject("lblAElastico.Text").ToString()
            lblDamping1.Text = GetLocalResourceObject("lblDamping1.Text").ToString()
            lblNumCurvas.Text = GetLocalResourceObject("lblNumCurvas.Text").ToString()
            lblAInelastico.Text = GetLocalResourceObject("lblAInelastico.Text").ToString()
            lblDamping3.Text = GetLocalResourceObject("lblDamping3.Text").ToString()
            lblR1.Text = GetLocalResourceObject("lblR1.Text").ToString()
            lblR2.Text = GetLocalResourceObject("lblR2.Text").ToString()
            lblCoefRigidez.Text = GetLocalResourceObject("lblCoefRigidez.Text").ToString()
            lblNumCurvas2.Text = GetLocalResourceObject("lblNumCurvas2.Text").ToString()
            lblTituloMaterialProper.Text = GetLocalResourceObject("lblTituloMaterialProper.Text").ToString()
            lblCargaSinusoidal.Text = GetLocalResourceObject("lblCargaSinusoidal.Text").ToString()
            lblAcelerograma.Text = GetLocalResourceObject("lblAcelerograma.Text").ToString()

            'CONTROL DE EJECUCION
            btnGraficar.Text = GetLocalResourceObject("btnGraficar.Text").ToString()

            'CONTROLES DE DESCARGA
            btnGetResult1.Text = GetLocalResourceObject("btnGetResult1.Text").ToString()
            btnGetResult2.Text = GetLocalResourceObject("btnGetResult2.Text").ToString()
            btnGetResult3.Text = GetLocalResourceObject("btnGetResult3.Text").ToString()
            btnGetResult4.Text = GetLocalResourceObject("btnGetResult4.Text").ToString()

        End Sub

#End Region

        Sub presentarEspacioGrafico()
            establecerPropCtrlGraficos()
            subCrearWebChartViewer()
        End Sub

        Protected Sub rbAnalisisElastico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAnalisisElastico.CheckedChanged
            presentarEspacioGrafico()
        End Sub

        Protected Sub rbAnalisisInelastico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAnalisisInelastico.CheckedChanged
            presentarEspacioGrafico()
        End Sub

        Protected Sub rbCargaSinusoidal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCargaSinusoidal.CheckedChanged
            presentarEspacioGrafico()
        End Sub

        Protected Sub rbAcelerograma_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAcelerograma.CheckedChanged
            presentarEspacioGrafico()
        End Sub

        Protected Sub btnGetResult1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetResult1.Click,
                btnGetResult2.Click,
                btnGetResult3.Click,
                btnGetResult4.Click
            Dim ge As GenExcell = New GenExcell
            'No enviamos la respuesta hasta que hemos terminado de procesar todo
            Response.Buffer = True

            'Ponemos el tipo de la respuesta al valor adecuado
            Response.ContentType = "application/vnd.ms-excel"

            Select Case CType(sender, Button).ID
                Case "btnGetResult1"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 0) & ".xls")
                    Response.Write(ge.DoExcell2(arr_period, arr_Aspectrum, intNumPuntos, intNumCurves, arrTextoTitulosExperimentos(idIdioma, 0), arrTextoEjesReporte(idIdioma, 0), arrTextoEjesReporte(idIdioma, 1)).ToString)
                Case "btnGetResult2"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 1) & ".xls")
                    Response.Write(ge.DoExcell2(arr_period, arr_Vspectrum, intNumPuntos, intNumCurves, arrTextoTitulosExperimentos(idIdioma, 1), arrTextoEjesReporte(idIdioma, 0), arrTextoEjesReporte(idIdioma, 2)).ToString)
                Case "btnGetResult3"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 2) & ".xls")
                    Response.Write(ge.DoExcell2(arr_period, arr_Dspectrum, intNumPuntos, intNumCurves, arrTextoTitulosExperimentos(idIdioma, 2), arrTextoEjesReporte(idIdioma, 0), arrTextoEjesReporte(idIdioma, 3)).ToString)
                Case "btnGetResult4"
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrTextoTitulosExperimentos(idIdioma, 3) & ".xls")
                    Response.Write(ge.DoExcell2(arr_period, arr_dductility, intNumPuntos, intNumCurves, arrTextoTitulosExperimentos(idIdioma, 3), arrTextoEjesReporte(idIdioma, 0), arrTextoEjesReporte(idIdioma, 4)).ToString)
            End Select


            ' Enviamos los datos al cliente
            Response.End()


        End Sub
    End Class
End Namespace

