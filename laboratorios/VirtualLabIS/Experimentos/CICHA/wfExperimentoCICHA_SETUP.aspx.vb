Imports System.IO
Imports Microsoft.VisualBasic.OpenAccess
Imports System.Math
Imports ChartDirector
Imports AjaxControlToolkit
Imports VirtualLabIS.DTO
Imports VirtualLabIS.Facade
Imports System.Data
Imports System.Threading

Imports DotNetNuke.Entities.Tabs
Imports DotNetNuke.Security.Permissions

Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_CICHA_wfExperimentoCICHA_SETUP
        Inherits System.Web.UI.Page

#Region "VariablesGlobales"
        'variables del Usuario
        Private Shared intUserID As Integer
        Private Shared strUsername As String
        'Objetos
        Private Shared ctrlSpecimenCircular As ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimencircular_ascx
        Private Shared ctrlSpecimenRectangular As ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimenrectangular_ascx
        Private Shared objFacade As Facade.VirtualLabIS.Facade.Cicha.ICicha
        Private Shared objConstDTO As [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
        Private Shared dsCICHA As DTO.dsCicha
        Private Shared dtCICHA_ESPC_CIR As DTO.dsCicha.CICHA_ESPC_CIRDataTable
        Private Shared drCICHA_ESPC_CIR As DTO.dsCicha.CICHA_ESPC_CIRRow
        Private Shared dtCICHA_ESPC_REC As DTO.dsCicha.CICHA_ESPC_RECDataTable
        Private Shared drCICHA_ESPC_REC As DTO.dsCicha.CICHA_ESPC_RECRow
        Private Shared dtCICHA_EXP_ESPC As DTO.dsCicha.CICHA_EXP_ESPCDataTable
        Private Shared drCICHA_EXP_ESPC As DTO.dsCicha.CICHA_EXP_ESPCRow
        Private Shared intNumeroIteracion As Integer 'Las veces que hace clip en RUN
        Private Shared strTipoSpec As String
        Private Shared strIdioma As String
        Private Shared idIdioma As Integer

        'Variables para parametrizas los gráficos 
        Dim legendBox As LegendBox
        Private intAnchoGraficas As Integer = 570
        Private intAltoGraficas As Integer = 430
        Private intColorFondo As Integer = &HEFEFEE
        Private XYChart_Grafica_Simula As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas - 90, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim colores() As Integer = {&H808080, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}
        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Dim intAddLegend_Coord_x As Integer = 400
        Dim intAddLegend_Coord_y As Integer = 5
        Dim bolAddLegend_Bool As Boolean = False
        Dim strAddLegend_Font As String = "Arial Rounded MT Bold"
        Dim intAddLegend_FontSize As Integer = 8
        'Variable para las graficas de resultados
        Private Shared arrayDatosGrafSimulX As Double()
        Private Shared arrayDatosGrafSimulY As Double()
        Private Shared objArrayObjetFileSimulation(,) As Object
        Private Shared intLimArrayGraficas As Integer
        Dim arrAlertaRUN(,) As String = {{"¡Ocurrio un error en la fase de simulación!"}, _
            {"It happened an error in the simulation phase!"}}

#End Region

#Region "Idioma"
        ''' <summary>
        ''' Este procedimiento establece el idioma de la pagina Los posibles valores que se 
        ''' pueden setear para el idioma son: es-ES y en
        ''' Metodo compatible "Protected Overrides Sub InitializeCulture()"
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub InitializeCulture()
            'Asignación del idioma del experimento
            strIdioma = Request.Params("idioma")
            'Establece el idioma en los controles de los experimentos
            If strIdioma = "es-ES" Then
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-ES")
                idIdioma = 0
            Else
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
                idIdioma = 1
                Exit Sub
            End If
        End Sub

        ''' <summary>
        ''' Procedimiento para establecer el idioma a los controles
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub subSetIdiomaControles()
            'strIdioma
            Me.imgRutaTitulo.ImageUrl = GetLocalResourceObject("imgRutaTitulo.Text").ToString()
            Me.lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            Me.lblParamModel.Text = GetLocalResourceObject("lblParamModel.Text").ToString()
            Me.lblParametros.Text = GetLocalResourceObject("lblParametros.Text").ToString()
            Me.lblFibrasSeccion.Text = GetLocalResourceObject("lblFibrasSeccion.Text").ToString()

            Me.lblParchesConctConfinado.Text = GetLocalResourceObject("lblParchesConctConfinado.Text").ToString()
            Me.lblParchesConctNoConfinado.Text = GetLocalResourceObject("lblParchesConctNoConfinado.Text").ToString()

            If (strTipoSpec = "Circular") Then
                'Me.lblCoreCircunfer_Y.Text = GetLocalResourceObject("lblCoreCircunfer_Y.Text_Cir").ToString()
                'Me.lblCoreRadial_Z.Text = GetLocalResourceObject("lblCoreRadial_Z.Text_Cir").ToString()
                'Me.lblCoverCircunfer_Y.Text = GetLocalResourceObject("lblCoverCircunfer_Y.Text_Cir").ToString()
                'Me.lblCoverRadial_Z.Text = GetLocalResourceObject("lblCoverRadial_Z.Text_Cir").ToString()
                Me.lblCoreCircunfer_Y.Text = GetLocalResourceObject("lblCoreCircunfer_Y.Text").ToString()
                Me.lblCoreRadial_Z.Text = GetLocalResourceObject("lblCoreRadial_Z.Text").ToString()
                Me.lblCoverCircunfer_Y.Text = GetLocalResourceObject("lblCoverCircunfer_Y.Text").ToString()
                Me.lblCoverRadial_Z.Text = GetLocalResourceObject("lblCoverRadial_Z.Text").ToString()

                'Imgenes de las Fibras o Parches
                Me.imgAyudaParchesConctConfinado1.ImageUrl = GetLocalResourceObject("imgAyudaParchesConctConfinado1.ImageUrl_Cir").ToString()
                Me.imgAyudaParchesConctNoConfinado.ImageUrl = GetLocalResourceObject("imgAyudaParchesConctNoConfinado.ImageUrl_Cir").ToString()
            Else
                Me.lblCoreCircunfer_Y.Text = GetLocalResourceObject("lblCoreCircunfer_Y.Text").ToString()
                Me.lblCoreRadial_Z.Text = GetLocalResourceObject("lblCoreRadial_Z.Text").ToString()
                Me.lblCoverCircunfer_Y.Text = GetLocalResourceObject("lblCoverCircunfer_Y.Text").ToString()
                Me.lblCoverRadial_Z.Text = GetLocalResourceObject("lblCoverRadial_Z.Text").ToString()
                'Imgenes de las Fibras o Parches
                Me.imgAyudaParchesConctConfinado1.ImageUrl = GetLocalResourceObject("imgAyudaParchesConctConfinado1.ImageUrl").ToString()
                Me.imgAyudaParchesConctNoConfinado.ImageUrl = GetLocalResourceObject("imgAyudaParchesConctNoConfinado.ImageUrl").ToString()
            End If
            Me.lblElementosSeccion.Text = GetLocalResourceObject("lblElementosSeccion.Text").ToString()
            Me.lblNumSubElementos.Text = GetLocalResourceObject("lblNumSubElementos.Text").ToString()
            Me.lblNumPuntosInters.Text = GetLocalResourceObject("lblNumPuntosInters.Text").ToString()
            Me.lblModeloMateriales.Text = GetLocalResourceObject("lblModeloMateriales.Text").ToString()
            Me.lblModeloAcero.Text = GetLocalResourceObject("lblModeloAcero.Text").ToString()
            Me.lblConsiderar.Text = GetLocalResourceObject("lblConsiderar.Text").ToString()
            Me.ckbPenetracDeform.Text = GetLocalResourceObject("ckbPenetracDeform.Text").ToString()
            Me.ckbEfectPDelta.Text = GetLocalResourceObject("ckbEfectPDelta.Text").ToString()

            Me.cmdSimular.Text = GetLocalResourceObject("cmdSimular.Text").ToString()
            Me.cmdEliminarTest.Text = GetLocalResourceObject("cmdEliminarTest.Text").ToString()
            Me.cmdLimpiar.Text = GetLocalResourceObject("cmdLimpiar.Text").ToString()

            'Ayudas
            Me.lblAyudaFibrasSeccion.Text = GetLocalResourceObject("lblAyudaFibrasSeccion.Text").ToString()
            Me.lblAyudaParchesConctConfinado.Text = GetLocalResourceObject("lblAyudaParchesConctConfinado.Text").ToString()
            Me.lblAyudaParchesConctNoConfinado.Text = GetLocalResourceObject("lblAyudaParchesConctNoConfinado.Text").ToString()
            Me.lblAyudaElementosSeccion.Text = GetLocalResourceObject("lblAyudaElementosSeccion.Text").ToString()
            Me.lblAyudaModeloMaterialesAcero.Text = GetLocalResourceObject("lblAyudaModeloMaterialesAcero.Text").ToString()
            Me.lblAyudaModeloMaterialesAcero1.Text = GetLocalResourceObject("lblAyudaModeloMaterialesAcero1.Text").ToString()
            Me.lblAyudaModeloMaterialesAcero2.Text = GetLocalResourceObject("lblAyudaModeloMaterialesAcero2.Text").ToString()
            Me.lblAyudaModeloMaterialesConcreto1.Text = GetLocalResourceObject("lblAyudaModeloMaterialesConcreto1.Text").ToString()
            Me.lblAyudaModeloMaterialesConcreto2.Text = GetLocalResourceObject("lblAyudaModeloMaterialesConcreto2.Text").ToString()
            Me.lblAyudaModeloMaterialesConcreto3.Text = GetLocalResourceObject("lblAyudaModeloMaterialesConcreto3.Text").ToString()
            Me.lblAyudaModeloMaterialesConcreto4.Text = GetLocalResourceObject("lblAyudaModeloMaterialesConcreto4.Text").ToString()
            Me.lblAyudaConsiderar.Text = GetLocalResourceObject("lblAyudaConsiderar.Text").ToString()
            Me.lblLinksGraficaCore.Text = GetLocalResourceObject("lblLinksGraficaCore.Text").ToString()
            Me.lblLinksGraficaCover.Text = GetLocalResourceObject("lblLinksGraficaCover.Text").ToString()
            Me.lblLinksGraficaElementosSeccion.Text = GetLocalResourceObject("lblLinksGraficaElementosSeccion.Text").ToString()
            Me.lblTituloFigElementosSeccion.Text = GetLocalResourceObject("lblTituloFigElementosSeccion.Text").ToString()

            Me.lblTituloFigModeloMaterialesAcero1.Text = GetLocalResourceObject("lblTituloFigModeloMaterialesAcero1.Text").ToString()
            Me.lblTituloFigModeloMaterialesAcero2.Text = GetLocalResourceObject("lblTituloFigModeloMaterialesAcero2.Text").ToString()
            Me.lblTituloFigModeloMaterialesConcreto1.Text = GetLocalResourceObject("lblTituloFigModeloMaterialesConcreto1.Text").ToString()
            Me.lblTituloFigModeloMaterialesConcreto2.Text = GetLocalResourceObject("lblTituloFigModeloMaterialesConcreto2.Text").ToString()
            Me.lblTituloFigModeloMaterialesConcreto3.Text = GetLocalResourceObject("lblTituloFigModeloMaterialesConcreto3.Text").ToString()

            Me.imgElementosSeccion.ImageUrl = GetLocalResourceObject("imgElementosSeccion.ImageUrl").ToString()

            Me.lblSliderExtPlayUnidades.Text = GetLocalResourceObject("lblSliderExtPlayUnidades.Text").ToString()
            'Tabla de Instruciones
            Me.lblInstrucciones.Text = GetLocalResourceObject("lblInstrucciones.Text").ToString()
            Me.lblInstruccionesTodas.Text = GetLocalResourceObject("lblInstruccionesTodas.Text").ToString()


        End Sub
#End Region

#Region "Control Gráfico WebChartView"

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
        Private Sub establecerPropCtrlGraficos()
            ' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
            CrearGraficasXYChart(50, 8, 350, 280, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, Nothing, "Times New Roman Bold", 16, 0, 0, 0, "FORCE (MN)", "Arial Bold Italic", 9, 0, 3, 20, -1, "DISPLACEMENT (mm)", "Arial Bold Italic", 9, 0, 3, 20, -1, XYChart_Grafica_Simula)
            legendBox = XYChart_Grafica_Simula.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent, Chart.Transparent)
        End Sub


#End Region

        Private Sub subEstablecerControlesPage()
            cmdSimular.Attributes.Add("onClick", "funDesHabilitarBorones();")
        End Sub

        ''' <summary>
        ''' Busca en el DataTable el especimen seleccionado con el CICHA_ESPC_CIR_ID y 
        ''' envia a adherir el Control de Usuario "ctrlSpecimenCircular" con estos datos.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function fucMostrarInfoSpecimen() As Double
            Dim boolIndicador As Boolean = False
            Dim compareResult As Integer = String.Compare(strTipoSpec, "Circular", True)
            If (compareResult = 0) Then
                Try
                    ctrlSpecimenCircular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimencircular_ascx
                    Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenCircular)
                    dtCICHA_ESPC_CIR = Session("dtCICHA_ESPC_CIR")
                    drCICHA_ESPC_CIR = Session("drCICHA_ESPC_CIR")
                    ctrlSpecimenCircular.subMostrarInfoSpecimenCircular(dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
                    ctrlSpecimenCircular.setHabilitarCtrl = False
                    boolIndicador = True
                Catch ex As Exception
                End Try
            Else
                compareResult = String.Compare(strTipoSpec, "Rectangular", True)
                If (compareResult = 0) Then
                    Try
                        ctrlSpecimenRectangular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimenrectangular_ascx
                        Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenRectangular)
                        dtCICHA_ESPC_REC = Session("dtCICHA_ESPC_REC")
                        drCICHA_ESPC_REC = Session("drCICHA_ESPC_REC")
                        ctrlSpecimenRectangular.subMostrarInfoSpecimenRectangular(dtCICHA_ESPC_REC, drCICHA_ESPC_REC)
                        ctrlSpecimenRectangular.setHabilitarCtrl = False
                        boolIndicador = True
                    Catch ex As Exception
                    End Try
                End If
            End If
            Return boolIndicador
        End Function

        ''' <summary>
        ''' Agrega al DataTable "CICHA_EXP_ESPC" del DataSet "dsChica" un registro para la simulación. 
        ''' Los valores depende del tipo de especimen parametrizado en la pagina anterior(wfExperimentoCICHA.aspx).
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAgregarCichaExpSpec()
            drCICHA_EXP_ESPC = dtCICHA_EXP_ESPC.NewCICHA_EXP_ESPCRow
            intNumeroIteracion = intNumeroIteracion + 1
            Dim intModeloAcero As Integer = Me.ddlModeloAcero.SelectedValue
            Dim intModeloConcreto As Integer = Me.ddlModeloConcreto.SelectedValue
            Dim intPenetracDeform As Integer = 0
            Dim intEfectPdelta As Integer = 0
            If Me.ckbPenetracDeform.Checked Then
                intPenetracDeform = 1
            End If
            If Me.ckbEfectPDelta.Checked Then
                intEfectPdelta = 1
            End If
            objFacade.subAgregar_ExpEspc(intNumeroIteracion, _
                                         1, _
                                         Me.txtCoreCircunfer_Y.Text, _
                                         Me.txtCoreRadial_Z.Text, _
                                         Me.txtCoverCircunfer_Y.Text, _
                                         Me.txtCoverRadial_Z.Text, _
                                         Me.txtNumSubElementos.Text, _
                                         Me.txtNumPuntosInters.Text, _
                                         intModeloAcero, _
                                         intModeloConcreto, _
                                         intPenetracDeform, _
                                         intEfectPdelta, _
                                         dtCICHA_EXP_ESPC, _
                                         drCICHA_EXP_ESPC)
        End Sub

        ''' <summary>
        ''' Escribe el Archivo o Arreglo de datos para las simulaciones. Parametrizacion de la Simulacion y del
        ''' Especimen. Y EJECUTA el Analisis de Columnas de Hormigon Armado.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEscribirArchivoSimulacion()
            Dim compareResult As Integer = String.Compare(strTipoSpec, "Circular", True)
            Dim intTipoSpec As Integer
            Dim intOrdenSeccion As Integer
            Dim strNombreSpec As String
            'Provisionales
            Dim file_in_Simul(9) As Object     'File of entry for Analysis Pushover
            Dim file_in_Spec_Cir(10) As Object 'File of entry for specimen with circular section
            Dim file_in_Spec_Rec(15) As Object 'File of entry for specimen with rectangular section
            If (compareResult = 0) Then
                intTipoSpec = 1
                intOrdenSeccion = drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_ORDENColumn)
                strNombreSpec = drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_NOMBREColumn)
                objFacade.subEscribirArchivoSimulacion(intUserID, strUsername, intTipoSpec, intOrdenSeccion, file_in_Simul, dtCICHA_EXP_ESPC, drCICHA_EXP_ESPC)
                objFacade.subWriteFile_InfSpec_SpecTCL_CIRCULAR(intUserID, strUsername, file_in_Spec_Cir, dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
                Dim booIndicador As Boolean = objFacade.fucAnalisis_CICHA(intUserID, strUsername, file_in_Simul, file_in_Spec_Cir, strNombreSpec)
                If Not booIndicador Then
                    Me.txtMensaje.Value = "Simulation error"
                End If
                'objFacade.subEscribirArchivoSimulacion(intUserID, strUserName, intTipoSpec, intOrdenSeccion, dtCICHA_EXP_ESPC, drCICHA_EXP_ESPC)
                'objFacade.subWriteFile_InfSpec_RespReal_SpecTCL_CIRCULAR(intUserID, strUserName, dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
            Else 'El una seccion Rectangular
                intTipoSpec = 2
                intOrdenSeccion = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ORDENColumn)
                strNombreSpec = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NOMBREColumn)
                objFacade.subEscribirArchivoSimulacion(intUserID, strUsername, intTipoSpec, intOrdenSeccion, file_in_Simul, dtCICHA_EXP_ESPC, drCICHA_EXP_ESPC)
                objFacade.subWriteFile_InfSpec_SpecTCL_RECTANGULAR(intUserID, strUsername, file_in_Spec_Rec, dtCICHA_ESPC_REC, drCICHA_ESPC_REC)
                Dim booIndicador As Boolean = objFacade.fucAnalisis_CICHA(intUserID, strUsername, file_in_Simul, file_in_Spec_Rec, strNombreSpec)
                If Not booIndicador Then
                    Me.txtMensaje.Value = "Simulation error"
                End If
                'objFacade.subEscribirArchivoSimulacion(intUserID, strUsername, intTipoSpec, intOrdenSeccion, dtCICHA_EXP_ESPC, drCICHA_EXP_ESPC)
                'objFacade.subWriteFile_InfSpec_RespReal_SpecTCL_RECTANGULAR(intUserID, strUsername, dtCICHA_ESPC_REC, drCICHA_ESPC_REC)
            End If
        End Sub

        ''' <summary>
        ''' Se llama solo al cargar por primera vez la pagina.
        ''' Se obtiene asigna a un arreglo Global los resultados de la Experimentacion Real de un Specimen dado.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subObtenerDatosExpReal()
            Dim compareResult As Integer = String.Compare(strTipoSpec, "Circular", True)
            Dim bytFileRespuestReal As Double(,)
            If (compareResult = 0) Then
                bytFileRespuestReal = objFacade.fucObtenerMatrizDouble_ArrayByt(drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_RESPUESTAREALColumn))
                'bytFileRespuestReal = fucObtenerMatrizDouble_ArrayByt(drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_RESPUESTAREALColumn))
                arrayDatosGrafSimulX = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(0, bytFileRespuestReal))
                arrayDatosGrafSimulY = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(1, bytFileRespuestReal))
            Else
                bytFileRespuestReal = objFacade.fucObtenerMatrizDouble_ArrayByt(drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RESPUESTAREALColumn))
                arrayDatosGrafSimulX = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(0, bytFileRespuestReal))
                arrayDatosGrafSimulY = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(1, bytFileRespuestReal))
            End If
            Me.hiddIndicador.Value = UBound(arrayDatosGrafSimulX)
        End Sub

        ''' <summary>
        ''' Metodo generico para graficar los resultados Reales y Simulados por OpenSees.
        ''' </summary>
        ''' <param name="arrayDatosGrafSimulacionX">Arreglo de valores en X</param>
        ''' <param name="arrayDatosGrafSimulacionY">Arreglo de valores en Y</param>
        ''' <param name="intLimArrayBloque">Numero de elementos del bloque de datos a Graficar</param>
        ''' <param name="intColor">Color de la Linea a asignar</param>
        ''' <param name="strNombreLinea">Nombre de la Linea a Asignar</param>
        ''' <remarks></remarks>
        Private Sub subGraficarExpReal(ByVal arrayDatosGrafSimulacionX As Double(), ByVal arrayDatosGrafSimulacionY As Double(), ByVal intLimArrayBloque As Integer, ByVal intColor As Integer, ByVal strNombreLinea As String)
            ReDim Preserve arrayDatosGrafSimulacionX(intLimArrayBloque)
            ReDim Preserve arrayDatosGrafSimulacionY(intLimArrayBloque)
            Dim linLayerGrafSimul As LineLayer = XYChart_Grafica_Simula.addLineLayer2() 'Se gráfica con el conjunto de los 98 Datos
            linLayerGrafSimul = XYChart_Grafica_Simula.addLineLayer(arrayDatosGrafSimulacionY, colores(intColor), strNombreLinea)
            linLayerGrafSimul.setXData(arrayDatosGrafSimulacionX)
            linLayerGrafSimul.setLineWidth(1)
            Dim arrayStrDatosDesigner_Indicadores_AMC() As Double = New Double(5) {1, 2, 3, 4, 5, 6}
            linLayerGrafSimul.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)

        End Sub

        'Public Function fucObtenerFileSimulacion(ByVal intUserID As Integer, ByVal strUserName As String, ByRef file_in_Simul As Object, ByVal strNomSpec As String) As Byte()
        '    Dim strPathFilesIn As String
        '    Dim strPathFilesExec As String
        '    Dim strPathFilesOut As String
        '    Dim strPathFilesCicha As String
        '    Dim bytFileRespuestReal As Double(,)

        '    objConstDTO = New [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
        '    strPathFilesCicha = objConstDTO.strPathFilesCicha

        '    strPathFilesOut = strPathFilesCicha & intUserID & "_" & strUserName & "/files_out/"
        '    strPathFilesExec = strPathFilesCicha & intUserID & "_" & strUserName & "/files_exe/"
        '    strPathFilesIn = strPathFilesCicha & intUserID & "_" & strUserName & "/files_in/"

        '    Dim bytFileSimulTCL As Byte()
        '    Dim streFileRestReal_Simul As Stream

        '    Dim strPathFilesCicha_aux As String = Replace(strPathFilesOut, "/", "\")

        '    streFileRestReal_Simul = File.Open(strPathFilesCicha_aux & "SimulacionOpensees.out", FileMode.Open, FileAccess.Read)
        '    Dim intLenght As Integer = streFileRestReal_Simul.Length
        '    streFileRestReal_Simul.Close()


        '    Dim binReader As New BinaryReader(File.Open(strPathFilesCicha_aux & "SimulacionOpensees.out", FileMode.Open))
        '    If binReader.PeekChar() <> -1 Then
        '        bytFileSimulTCL = binReader.ReadBytes(intLenght - 2)
        '        binReader.Close()
        '    End If
        '    Return bytFileSimulTCL
        'End Function

        'bytFileRespuestReal = objFacade.fucObtenerMatrizDouble_ArrayByt(bytFileSimulTCL)

        ''' <summary>
        ''' Obtiene el archivo de Simulacion generado por OpenSees y los asigna a una Matriz de objetos
        ''' la cual contendra los datos de las graficas en X y en Y
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub fucObtenerFileSimulacion()
            Dim bytFileSimulTCL As Byte()
            Dim douMatrizFileSimulacion(,) As Double
            Dim boolIndicador As Boolean
            bytFileSimulTCL = objFacade.fucObtenerFileSimulacion(intUserID, strUsername, boolIndicador)
            If boolIndicador Then
                douMatrizFileSimulacion = objFacade.fucObtenerMatrizDouble_ArrayByt(bytFileSimulTCL)
                If (UBound(douMatrizFileSimulacion, 1) >= arrayDatosGrafSimulX.Length - 30) Then
                    'Adhire el archivo de los Resultados de la Simulacion el DataTable Specimen
                    drCICHA_EXP_ESPC(dtCICHA_EXP_ESPC.CICHA_EXP_ESPC_RESPUESTASIMULADAColumn) = bytFileSimulTCL
                    dtCICHA_EXP_ESPC.AddCICHA_EXP_ESPCRow(drCICHA_EXP_ESPC)
                    subAsignarArrayObjetFileSimulation()
                    Me.txtMensaje.Value = "¡Press PLAY for viewing Results!"
                End If
            Else
                Me.txtMensaje.Value = "Simulation error"
            End If
        End Sub

        ''' <summary>
        ''' Obtenido el archivo de Rasultados de la Simulacion, se extrae en una Matriz de Objetos los valores para
        ''' X,Y para la graficas. Esto es con la finalidad de optimizar codigo y llamar a la recuperacion de los resultados
        ''' simulados una Unica vez. Es decir al hacer clip en el cmdSimular
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarArrayObjetFileSimulation()
            ReDim objArrayObjetFileSimulation(dtCICHA_EXP_ESPC.Count, 2)
            Dim intFila As Integer = 0
            For Each drCICHA_EXP_ESPC In dtCICHA_EXP_ESPC.Rows
                Dim douMatrizFileSimulacion(,) As Double = objFacade.fucObtenerMatrizDouble_ArrayByt(drCICHA_EXP_ESPC(dtCICHA_EXP_ESPC.CICHA_EXP_ESPC_RESPUESTASIMULADAColumn))
                Dim arrayDouDatos_XYChart_Grafica_Simula_Y() As Double = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(0, douMatrizFileSimulacion))
                Dim arrayDouDatos_XYChart_Grafica_Simula_X() As Double = objFacade.fucObtenerArray_Metro_Milimetro(objFacade.fucObtenerArray_Matriz(1, douMatrizFileSimulacion))
                objArrayObjetFileSimulation(intFila, 0) = arrayDouDatos_XYChart_Grafica_Simula_X
                objArrayObjetFileSimulation(intFila, 1) = arrayDouDatos_XYChart_Grafica_Simula_Y
                intFila += 1
            Next
        End Sub

        ''' <summary>
        ''' LLama iterativamente a "subGraficarExpReal" por para simulacion que se vaya ejecutando y va ahiriendo
        ''' a la graficas de los resultados una nueva linea.
        ''' </summary>
        ''' <param name="intLimArrayBloque"></param>
        ''' <remarks></remarks>
        Private Sub subGenerarGraficasSimulacion(ByVal intLimArrayBloque As Integer)
            If (dtCICHA_EXP_ESPC.Count > 0) Then
                Dim contColors As Integer = 0
                Dim intLimArrayObjetFileSimulation As Integer = UBound(objArrayObjetFileSimulation, 1) - 1
                For i As Integer = 0 To intLimArrayObjetFileSimulation
                    If contColors > 12 Then 'Si los colores superan los 12, se inicializan en el rojo 
                        contColors = 1
                    Else
                        contColors += 1
                    End If
                    subGraficarExpReal(objArrayObjetFileSimulation(i, 0), objArrayObjetFileSimulation(i, 1), intLimArrayGraficas, contColors, "Simulation " & contColors)
                Next
            End If
        End Sub

        Private Sub subEliminarSimulacion(ByRef intExpEspc_Id As Integer)
            Dim drCICHA_EXP_ESPC As DataRow = dtCICHA_EXP_ESPC.FindByCICHA_EXP_ESPC_ID(intExpEspc_Id)
            dtCICHA_EXP_ESPC.Rows.Remove(drCICHA_EXP_ESPC)
            subAsignarArrayObjetFileSimulation()
            intExpEspc_Id = intExpEspc_Id - 1
        End Sub

        Private Sub subLimpiar()
            dtCICHA_EXP_ESPC.Clear()
        End Sub

        Private Sub subActualizarBotonDelete()
            If intNumeroIteracion > 0 Then
                Me.cmdEliminarTest.Enabled = True
                If strIdioma = "es-ES" Then
                    Me.cmdEliminarTest.Text = "ELIMINAR ANALISIS " + CStr(intNumeroIteracion)
                Else
                    Me.cmdEliminarTest.Text = "DELETE ANALYSIS " + CStr(intNumeroIteracion)
                End If
            Else
                Me.cmdEliminarTest.Enabled = False
                If strIdioma = "es-ES" Then
                    Me.cmdEliminarTest.Text = "ELIMINAR ANALISIS"
                Else
                    Me.cmdEliminarTest.Text = "DELETE ANALYSIS"
                End If
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim boolIndicador As Boolean = True
            'Actualiza la Grafica en el Boton PLAY y PAUSE
            If WebChartViewer.IsStreamRequest(Page) Then
                intLimArrayGraficas += 3
                If intLimArrayGraficas < UBound(arrayDatosGrafSimulX) Then
                    establecerPropCtrlGraficos()
                    subGraficarExpReal(arrayDatosGrafSimulX, arrayDatosGrafSimulY, intLimArrayGraficas, 0, "Exp. Real")
                    subGenerarGraficasSimulacion(intLimArrayGraficas)
                    Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
                    Me.wcvGraficasSimula.StreamChart()
                Else
                    intLimArrayGraficas = 0
                    boolIndicador = False
                End If
            End If
            'Actualiza la Grafica en el boton STOP
            If WebChartViewer.IsPartialUpdateRequest(Page) Then
                intLimArrayGraficas = 0
                establecerPropCtrlGraficos()
                Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
                Me.wcvGraficasSimula.PartialUpdateChart()
            End If

            Me.phlCotrolesSpecimenes.Controls.Clear()
            If Not Page.IsPostBack And (boolIndicador) Then
                strTipoSpec = Request.Params("especimen")
                strIdioma = Request.Params("idioma")
                subSetIdiomaControles()
                objConstDTO = New [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
                intUserID = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id
                'LA SIGUIENTE VARIABLE POR PRESENTAR PROBLEMAS AL MOMENTO DE EJECUTAR EL EXPERIMENTO.
                'strUsername = VirtualLabIS.Common.Global.Clases.Usuarios.Username
                strUsername = VirtualLabIS.Common.Global.Clases.Usuarios.User_Name
                intNumeroIteracion += 1
                dtCICHA_EXP_ESPC = New DTO.dsCicha.CICHA_EXP_ESPCDataTable
                objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
                intNumeroIteracion = 0
                '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                If fucMostrarInfoSpecimen() Then
                    establecerPropCtrlGraficos()
                    subEstablecerControlesPage()
                    subObtenerDatosExpReal()
                    subGraficarExpReal(arrayDatosGrafSimulX, arrayDatosGrafSimulY, UBound(arrayDatosGrafSimulX, 1), 0, "Exp. Real")
                    Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
                Else
                    Response.Redirect("wfExperimentoCICHA.aspx?idioma=" & strIdioma)
                End If
            Else
                fucMostrarInfoSpecimen()
            End If

        End Sub

        Protected Sub cmdSimular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSimular.Click
            Me.txtMensaje.Value = ""
            establecerPropCtrlGraficos()
            Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
            subAgregarCichaExpSpec()
            subEscribirArchivoSimulacion()
            fucObtenerFileSimulacion()
            subActualizarBotonDelete()
        End Sub

        Protected Sub cmdEliminarTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEliminarTest.Click
            subEliminarSimulacion(intNumeroIteracion)
            establecerPropCtrlGraficos()
            subGraficarExpReal(arrayDatosGrafSimulX, arrayDatosGrafSimulY, UBound(arrayDatosGrafSimulX, 1), 0, "Exp. Real")
            subActualizarBotonDelete()
            Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
        End Sub

        Protected Sub cmdLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
            subLimpiar()
            establecerPropCtrlGraficos()
            subGraficarExpReal(arrayDatosGrafSimulX, arrayDatosGrafSimulY, UBound(arrayDatosGrafSimulX, 1), 0, "Exp. Real")
            intNumeroIteracion = 0
            subActualizarBotonDelete()
            Me.wcvGraficasSimula.Image = XYChart_Grafica_Simula.makeWebImage(Chart.PNG)
        End Sub

    End Class
End Namespace

