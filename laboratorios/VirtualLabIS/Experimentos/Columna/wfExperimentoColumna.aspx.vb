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
Imports System.Globalization
Imports DotNetNuke
Imports DotNetNuke.Services.Localization

Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_Columna_wfExperimentoColumna
        Inherits System.Web.UI.Page

#Region "Constantes"
        'Alpha Rojo Verde Azul   - AA RR GG BB son los componentes que pueden ir desde 00 - FF (0 -255)
        Dim colores() As Integer = {&HFF0000, &H22AAFF, &H336622, &H44CCAA, &H551188, &H66EE44, &H77FF77, &H8899AA, &H9944BB, &HAA8822, &HDD8866, &H22EEEE, &HDDAABB}
#End Region

#Region "Variables Globales"
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
        Dim XYChart_Grafica_MomentoCurvatura As XYChart = New XYChart(intAnchoGraficas - 75, intAltoGraficas - 90, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
        Dim XYChart_Grafica_EstimCurvaturaFluencia As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el segundo gráfico
        Dim XYChart_Grafica_ResistenciaRigidez As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_InerciaGruesa_Agrietada As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_InercGruesAgriet_Real_Calculada As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas - 10, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        Dim XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el tercer gráfico
        'Variables para configurar las Leyendas que se agregan a las Gráficas
        Dim intAddLegend_Coord_x As Integer = 315
        Dim intAddLegend_Coord_y As Integer = 5
        Dim bolAddLegend_Bool As Boolean = False
        Dim strAddLegend_Font As String = "Arial Rounded MT Bold"
        Dim intAddLegend_FontSize As Integer = 8
        Shared getIdioma As String
#End Region

#Region "Metodos Privados"

        'Private Sub subGraficarWithThread()
        '    Dim ThreadExeAMC As Thread = New Thread(AddressOf subGraficar)
        '    ThreadExeAMC.Start()
        'End Sub

        ''' <summary>
        ''' Inicializa los controles gráficos, ejecuta el AMC, grafica los resultados del AMC y agrega los controles gráficos a la página
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subGraficar()
            If subEjecutarAnalisisMC() Then
                subAsignarEstandaresAnalisis()
            End If
            establecerPropCtrlGraficos()
            subGenerarGraficas()
            subCrearWebChartViewer()
            subMantenerDatosFlashAnimation()
            subAsignarPropiedadesMateriales()
        End Sub

        ''' <summary>
        ''' Ejecuta el "Análisis Momento Curvatura" dado los parametros de Diseño, llamando al método "Analisis_MomentoCurvatura" 
        ''' de la Capa BL, a travez de la Capa Facade. Cada vez que se Ejecuta un análisis, se agregan los datos en el DataTable 
        ''' "dtColumna" en nuevas filas. Solamente desde aqui se crean nuevos registros en el DataTable, solamente desde aqui se 
        ''' controlan la creacion de nuevos Datos.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function subEjecutarAnalisisMC() As Boolean
            'No decrementar <Session("NumeroIteracionesAMC")> porque es el ID de la Columna
            Session("NumeroIteracionesAMC") += 1 'Es el contador para el numero de lineas en el 1er grafico
            intNumeroIteracionesAMC = Session("NumeroIteracionesAMC")
            drColumna = Session("dtColumna").NewCOLUMNARow
            Dim intColumna_Id As Integer = intNumeroIteracionesAMC
            Dim intColumna_Dise_Secuencia As Integer = 0 'Se lo controla con el "dtColumna.Count" que retorna el # de filas insertadas actualmente en el DataTable
            Dim intExpColumna_Id As Integer = 1
            Dim intAxialLoad As Integer = CInt(txtAxialLoad.Text) * 1000
            Dim booBandera As Boolean = objFacade.Analisis_MomentoCurvatura(intColumna_Id, _
                                            intExpColumna_Id, _
                                            intColumna_Dise_Secuencia, _
                                            txtSectionDiameter.Text, _
                                            txtConvertLB.Text, _
                                            txtLongBarDiameter.Text, _
                                            txtNumberLongBars.Text, _
                                            txtTransverseReinfDiam.Text, _
                                            ddTipo.SelectedValue.ToString, _
                                            txtSpacingTransSteel.Text, _
                                            txtConcrComprStrength.Text, _
                                            txtLongRYS.Text, _
                                            txtTransRYS.Text, _
                                            txtLongRMX.Text, _
                                            intAxialLoad.ToString, _
                                            Session("dtColumna"), drColumna)
            If booBandera Then
                Return True
            Else
                'Si Existen Errores en la DLL del Análisis Momento Curvatura se presentara un Mensaje en JavaScript
                'informando del error generado
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                Dim cstext1 As String = "alert('¡An error arose in the MOMENT CURVATURE RESPONSE! \n\nThis is due to that the parameters of \nhave been entered incorrectly \n\nYou can be helped with: INDICATORS DESING AND ANALYSIS');"
                Dim cs As ClientScriptManager = Page.ClientScript
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                Return False
            End If
        End Function

        ''' <summary>
        ''' Método único que grafica los resultados del AMC
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
        Private Sub subGenerarGraficas()
            Try
                dtColumna = Session("dtColumna")
                intNumeroIteracionesAMC = dtColumna.Count
                subMostrarBottonReport() 'Por lo menos debe haber una Íteración o Análisis para se pueda generar el reporte.
                If intNumeroIteracionesAMC > 0 Then
                    '------ Pendiente Optimizar Codigo -------
                    numLinea = dtColumna.Count - 1
                    Dim auxcolores() As Double = Session("Colores2G")
                    ReDim Preserve auxcolores(numLinea)
                    auxcolores(numLinea) = numLinea
                    Session("Colores2G") = auxcolores
                    Dim contColors As Integer = 0
                    '-----------------------------------------
                    Dim intCoeficiente As Double = 0 'El el Coeficiente de las Ecuaciones de cada gráfica
                    Dim intConstante As Double = 0 'El el Coeficiente de las Ecuaciones de cada gráfica
                    ' -------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
                    ' -------------------------------------------------------------------------------
                    'LEYENDAS DEL GRÁFICO NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA"  
                    Dim legendBox_EstimCurvaturaFluencia As LegendBox = XYChart_Grafica_EstimCurvaturaFluencia.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 60, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_EstimCurvaturaFluencia.setBackground(Chart.Transparent)
                    'DATOS PARA GRAFICAR
                    Dim arrayDatosGraficaEstimCurvaturaFluenciaX As Double() = objFacade.ObtenerDatosGraficaEstmCuvtauraFluenciaX(dtColumna)
                    Dim arrayDatosGraficaEstimCurvaturaFluenciaY As Double() = objFacade.ObtenerDatosGraficaEstmCuvtauraFluenciaY(dtColumna)
                    ' ---------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#3  "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ" |
                    ' ---------------------------------------------------------------------------------
                    'LEYENDAS DEL GRÁFICO NÚMERO#3 "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ"
                    Dim legendBox_ResistenciaRigidez As LegendBox = XYChart_Grafica_ResistenciaRigidez.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_ResistenciaRigidez.setBackground(Chart.Transparent)
                    'DATOS PARA GRAFICAR
                    Dim arrayDatosGraficaResistenciaRigidezX As Double() = objFacade.ObtenerDatosGraficaResistenciaRigidezX(dtColumna)
                    Dim arrayDatosGraficaResistenciaRigidezY As Double() = objFacade.ObtenerDatosGraficaResistenciaRigidezY(dtColumna)
                    ' --------------------------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
                    ' --------------------------------------------------------------------------------------------------------------------
                    'LEYENDAS DEL GRÁFICO NÚMERO#4 "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
                    Dim legendBox_InerciaGruesa_Agrietada As LegendBox = XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_InerciaGruesa_Agrietada.setBackground(Chart.Transparent)
                    'DATOS PARA GRAFICAS
                    Dim arrayDatosGraficaInerciaGruesa_AgrietadaX As Double() = objFacade.ObtenerDatosGraficaInerciaGruesa_AgrietadaX(dtColumna)
                    Dim arrayDatosGraficaInerciaGruesa_AgrietadaY As Double() = objFacade.ObtenerDatosGraficaInerciaGruesa_AgrietadaY(dtColumna)
                    ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5  "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA" |
                    ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                    'LEYENDAS Y PUNTOS DEL QUINTO GRAFICO
                    Dim legendBox_InercGruesAgriet_Real_Calculada As LegendBox = XYChart_Grafica_InercGruesAgriet_Real_Calculada.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_InercGruesAgriet_Real_Calculada.setBackground(Chart.Transparent)
                    'DATOS PARA LA GRAFICA
                    Dim arrayDatosGraficaInercGruesAgriet_Real_CalculadaX As Double() = objFacade.ObtenerDatosGraficaInercGruesAgriet_Real_CalculadaX(dtColumna)
                    'Dim arrayDatosGraficaInercGruesAgriet_Real_CalculadaY As Double() = objFacade.ObtenerDatosGraficaInercGruesAgriet_Real_CalculadaY(dtColumna)
                    Dim arrayDatosGraficaInercGruesAgriet_Real_CalculadaY As Double() = arrayDatosGraficaInerciaGruesa_AgrietadaY
                    'Variables Gráficas # 6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" 
                    Dim arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC(98) As Double 'Variables para las lineas promedio de la Gráficas # 6
                    Dim legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.setBackground(Chart.Transparent)
                    'Variables Gráficas # 7 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" 
                    Dim arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Acero_Curvatura_Y_ES(98) As Double 'Variables para las lineas promedio de la Gráficas # 7
                    Dim legendBox_RelacionDeformacionUnitaria_Curvatura_7_ES As LegendBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(intAddLegend_Coord_x + 75, intAddLegend_Coord_y + 65, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
                    legendBox_RelacionDeformacionUnitaria_Curvatura_7_ES.setBackground(Chart.Transparent)
                    Dim arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC(98) As Double

                    Dim drColumna As DataRow
                    For Each drColumna In dtColumna.Rows
                        If contColors > 12 Then 'Si los colores superan los 12, se inicializan en el rojo 
                            contColors = 0
                        End If
                        ' ----------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#1 "ANÁLISIS MOMENTO CURVATURA" |
                        ' ----------------------------------------------------------------------
                        'Datos de Diseño de la Columna MAS los indicadores del AMC
                        Dim arrayStrDatosDesigner_Indicadores_AMC() As String = New String() {objFacade.ObtenerDatosDesignerGraficaMomenCurv(drColumna(dtColumna.COLUMNA_IDColumn.ColumnName), drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), Session("dtColumna")) _
                                                                                                             + " " + _
                                                                                                             objFacade.ObtenerIndicadoresAMC(drColumna(dtColumna.COLUMNA_IDColumn.ColumnName), drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), Session("dtColumna"))}
                        ' -------------------------------------------
                        '| CURVA del 1er grafico "Momento Curvatura" |
                        ' -------------------------------------------
                        'Matriz para la Gráfica Número#1, de la CURVA "MOMENTO" es un conjunto de 98 Datos
                        Dim douMatrizFileOutAMC(,) As Double = objFacade.ObtenerMatrizResultadosAMC(drColumna(dtColumna.COLUMNA_IDColumn.ColumnName), drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), Session("dtColumna"))
                        Dim arrayDouDatosGraficaMomenCurv_CURVA_Y() As Double = objFacade.ObtenerColumnaMatrizAMC(1, douMatrizFileOutAMC)
                        Dim arrayDouDatosGraficaMomenCurv_CURVA_X() As Double = objFacade.ObtenerColumnaMatrizAMC(0, douMatrizFileOutAMC)
                        Dim linLayerGraficaMomentoCurvatura_Curva As LineLayer 'Se gráfica con el conjunto de los 98 Datos
                        linLayerGraficaMomentoCurvatura_Curva = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrayDouDatosGraficaMomenCurv_CURVA_Y, colores(contColors), "Analysis " & CStr(drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName)))
                        linLayerGraficaMomentoCurvatura_Curva.setXData(arrayDouDatosGraficaMomenCurv_CURVA_X)
                        linLayerGraficaMomentoCurvatura_Curva.setLineWidth(1)
                        linLayerGraficaMomentoCurvatura_Curva.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' -------------------------------------------
                        '| LINEA del 1er grafico "Momento Curvatura" |
                        ' -------------------------------------------
                        'Datos para Gráfica Número#1, de la LINEA de las coordenadas {[0,0] [x1,y1] [x2,y2]}
                        Dim arrayDatosGraficaMomenCurv_Linea() As Double = objFacade.ObtenerDatosGraficaMomenCurv_Linea(drColumna(dtColumna.COLUMNA_IDColumn.ColumnName), drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), Session("dtColumna"))
                        Dim arrayDatosGraficaMomenCurv_Linea_CoordenadasY As Double() = New Double() {arrayDatosGraficaMomenCurv_Linea(1), arrayDatosGraficaMomenCurv_Linea(3), arrayDatosGraficaMomenCurv_Linea(5)}
                        Dim arrayDatosGraficaMomenCurv_Linea_CoordenadasX As Double() = New Double() {arrayDatosGraficaMomenCurv_Linea(0), arrayDatosGraficaMomenCurv_Linea(2), arrayDatosGraficaMomenCurv_Linea(4)}
                        Dim linLayerGraficaMomentoCurvatura_Linea As LineLayer 'Se gráfica solo con 3 grupos de Datos
                        linLayerGraficaMomentoCurvatura_Linea = XYChart_Grafica_MomentoCurvatura.addLineLayer(arrayDatosGraficaMomenCurv_Linea_CoordenadasY, colores(contColors))
                        linLayerGraficaMomentoCurvatura_Linea.setXData(arrayDatosGraficaMomenCurv_Linea_CoordenadasX)
                        linLayerGraficaMomentoCurvatura_Linea.setLineWidth(1)
                        linLayerGraficaMomentoCurvatura_Linea.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' -------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
                        ' -------------------------------------------------------------------------------
                        Dim scatterLayerGraficaEstimacionCurvaturaFluencia As ScatterLayer
                        legendBox_EstimCurvaturaFluencia.addKey("Analysis " & drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), colores(contColors))
                        scatterLayerGraficaEstimacionCurvaturaFluencia = XYChart_Grafica_EstimCurvaturaFluencia.addScatterLayer(arrayDatosGraficaEstimCurvaturaFluenciaX, New ArrayMath(arrayDatosGraficaEstimCurvaturaFluenciaY).selectEQZ( _
                                         New ArrayMath(auxcolores).sub(contColors).result(), Chart.NoValue).result(), "", Chart.DotDashLine, 7, colores(contColors))
                        scatterLayerGraficaEstimacionCurvaturaFluencia.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' ---------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#3  "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ" |
                        ' ---------------------------------------------------------------------------------
                        Dim scatterLayerGraficaResistenciaRigidez As ScatterLayer
                        legendBox_ResistenciaRigidez.addKey("Analysis " & drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), colores(contColors))
                        scatterLayerGraficaResistenciaRigidez = XYChart_Grafica_ResistenciaRigidez.addScatterLayer(arrayDatosGraficaResistenciaRigidezX, New ArrayMath(arrayDatosGraficaResistenciaRigidezY).selectEQZ( _
                             New ArrayMath(auxcolores).sub(contColors).result(), Chart.NoValue).result(), "", Chart.DotDashLine, 7, colores(contColors))
                        scatterLayerGraficaResistenciaRigidez.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' --------------------------------------------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
                        ' --------------------------------------------------------------------------------------------------------------------
                        Dim scatterLayerGraficaInerciaGruesa_Agrietada As ScatterLayer
                        legendBox_InerciaGruesa_Agrietada.addKey("Analysis " & drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), colores(contColors))
                        scatterLayerGraficaInerciaGruesa_Agrietada = XYChart_Grafica_InerciaGruesa_Agrietada.addScatterLayer(arrayDatosGraficaInerciaGruesa_AgrietadaX, New ArrayMath(arrayDatosGraficaInerciaGruesa_AgrietadaY).selectEQZ( _
                             New ArrayMath(auxcolores).sub(contColors).result(), Chart.NoValue).result(), "", Chart.DotDashLine, 7, colores(contColors))
                        scatterLayerGraficaInerciaGruesa_Agrietada.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5  "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA" |
                        ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                        legendBox_InercGruesAgriet_Real_Calculada.addKey("Analysis " & drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName), colores(contColors))
                        Dim scatterLayerGraficaInercGruesAgriet_Real_Calculada As ScatterLayer
                        scatterLayerGraficaInercGruesAgriet_Real_Calculada = XYChart_Grafica_InercGruesAgriet_Real_Calculada.addScatterLayer(arrayDatosGraficaInercGruesAgriet_Real_CalculadaX, New ArrayMath(arrayDatosGraficaInercGruesAgriet_Real_CalculadaY).selectEQZ( _
                             New ArrayMath(auxcolores).sub(contColors).result(), Chart.NoValue).result(), "", Chart.DotDashLine, 7, colores(contColors))
                        scatterLayerGraficaInercGruesAgriet_Real_Calculada.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' --------------------------------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" |
                        ' --------------------------------------------------------------------------------------------------------
                        Dim arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_X() As Double = objFacade.ObtenerColumnaMatrizAMC(0, douMatrizFileOutAMC)
                        objFacade.ObtenerDatosGraficaRelacionDeformacionUnitaria_Curvatura_X(arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_X, drColumna(dtColumna.COLUMNA_DISE_DIAMETROSSECCIONColumn.ColumnName))
                        Dim arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_EC() As Double = objFacade.ObtenerColumnaMatrizAMC(3, douMatrizFileOutAMC)
                        Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_EC As LineLayer 'Se gráfica con el conjunto de los 98 Datos
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_EC = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_EC)
                        legendBox_RelacionDeformacionUnitaria_Curvatura_Y_EC.addKey("Analysis " & CStr(drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName)), colores(contColors))
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_EC.setXData(arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_X)
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_EC.setLineWidth(1)
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_EC.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' ----------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#6 DATOS PARA LA LINEA PROMEDIO |
                        ' ----------------------------------------------------------------------
                        objFacade.ObtenerSumaArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_EC)
                        objFacade.ObtenerSumaArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC, arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_X)
                        ' -----------------------------------------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#7 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" |
                        ' -----------------------------------------------------------------------------------------------------
                        Dim arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_ES() As Double = objFacade.ObtenerColumnaMatrizAMC(4, douMatrizFileOutAMC)
                        Dim linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_ES As LineLayer 'Se gráfica con el conjunto de los 98 Datos
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_ES = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_ES)
                        legendBox_RelacionDeformacionUnitaria_Curvatura_7_ES.addKey("Analysis " & CStr(drColumna(dtColumna.COLUMNA_DISE_SECUENCIAColumn.ColumnName)), colores(contColors))

                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_ES.setXData(arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_X)
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_ES.setLineWidth(1)
                        linLayerGraficaRelacionDeformacionUnitaria_Curvatura_6_ES.addExtraField(arrayStrDatosDesigner_Indicadores_AMC)
                        ' ----------------------------------------------------------------------
                        '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#7 DATOS PARA LA LINEA PROMEDIO |
                        ' ----------------------------------------------------------------------
                        objFacade.ObtenerSumaArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Acero_Curvatura_Y_ES, arrayDouDatosGraficaRelacionDeformacionUnitaria_Curvatura_Y_ES)

                        contColors += 1
                    Next drColumna
                    Dim intColorFondoFormulasGraficas As Integer = &HD6DAFF
                    ' -------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#2 "ESTIMACIÓN DE CURVATURA DE FLUENCIA" |
                    ' -------------------------------------------------------------------------------
                    'AGREGA DE LA LINEA DE TENDENCIA Y FORMULA DEL SEGUNDO GRÁFICO
                    Dim linea_Tendencia2doGrafico As LineLayer
                    Dim arrayDatosGraficaEstimCurvaturaFluenciaREGRESION_LINEAL As Double() = objFacade.Regresion(arrayDatosGraficaEstimCurvaturaFluenciaX, arrayDatosGraficaEstimCurvaturaFluenciaY, intConstante, intCoeficiente)
                    linea_Tendencia2doGrafico = XYChart_Grafica_EstimCurvaturaFluencia.addLineLayer(arrayDatosGraficaEstimCurvaturaFluenciaREGRESION_LINEAL, &HAC)
                    linea_Tendencia2doGrafico.setXData(arrayDatosGraficaEstimCurvaturaFluenciaX)
                    Dim txtBox_GraficaEstimCurvaturaFluencia As ChartDirector.TextBox = XYChart_Grafica_EstimCurvaturaFluencia.addText(140, 5, "<*block*>φ<*sub*>y<*/*> = " & FormatNumber(intCoeficiente, 4) & "<*block*><*size=13*>Ω ε<*sub*>y<*/*> / D", "", 11, &H0)
                    txtBox_GraficaEstimCurvaturaFluencia.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
                    ' ---------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#3  "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ" |
                    ' ---------------------------------------------------------------------------------
                    'AGREGA DE LA LINEA DE TENDENCIA Y FORMULA DEL TERCER GRÁFICO
                    Dim linea_Tendencia3erGrafico As LineLayer
                    Dim arrayDatosGraficaResistenciaRigidezREGRESION_LINEAL As Double() = objFacade.Regresion(arrayDatosGraficaResistenciaRigidezX, arrayDatosGraficaResistenciaRigidezY, intConstante, intCoeficiente)
                    linea_Tendencia3erGrafico = XYChart_Grafica_ResistenciaRigidez.addLineLayer(arrayDatosGraficaResistenciaRigidezREGRESION_LINEAL, &HAC)
                    linea_Tendencia3erGrafico.setXData(arrayDatosGraficaResistenciaRigidezX)
                    Dim strCurvaturaFluencia As String = Microsoft.VisualBasic.Format(dtColumna(dtColumna.Count - 1)(dtColumna.COLUMNA_ANAL_CURVATURAFLUENCIAColumn.ColumnName), "#0.000")
                    'Agrega de Formula en la Parte superior
                    Dim txtBox_GraficaResistenciaRigidez As ChartDirector.TextBox = XYChart_Grafica_ResistenciaRigidez.addText(170, 5, "<*block*>M<*sub*>y<*/*> = " & strCurvaturaFluencia & " El<*sub*>cr<*/*>", "", 11)
                    txtBox_GraficaResistenciaRigidez.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
                    ' --------------------------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#4  "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO" |
                    ' --------------------------------------------------------------------------------------------------------------------
                    'AGREGA DE LA LINEA DE TENDENCIA Y FORMULA DEL CUARTO GRAFICO
                    Dim linea_Tendencia4toGrafico As LineLayer
                    Dim arrayDatosGraficaEstimacionCurvaturaFluenciaREGRESION_LINEAL As Double() = objFacade.Regresion(arrayDatosGraficaInerciaGruesa_AgrietadaX, arrayDatosGraficaInerciaGruesa_AgrietadaY, intConstante, intCoeficiente)
                    linea_Tendencia4toGrafico = XYChart_Grafica_InerciaGruesa_Agrietada.addLineLayer(arrayDatosGraficaEstimacionCurvaturaFluenciaREGRESION_LINEAL, &HAC)
                    linea_Tendencia4toGrafico.setXData(arrayDatosGraficaInerciaGruesa_AgrietadaX)
                    'Agrega de Formula en la Parte superior
                    Dim txtBox_GraficaInerciaGruesa_Agrietada As ChartDirector.TextBox = XYChart_Grafica_InerciaGruesa_Agrietada.addText(140, 5, "<*block*>Icr/Ig = " & FormatNumber(intCoeficiente, 4) & " ρ + " & FormatNumber(intConstante, 4), "", 11)
                    txtBox_GraficaInerciaGruesa_Agrietada.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
                    ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICO NÚMERO#5  "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA" |
                    ' -----------------------------------------------------------------------------------------------------------------------------------------------------
                    'AGREGA DE LA LINEA DE TENDENCIA DEL QUINTO GRAFICO
                    Dim linea_Tendencia5toGrafico As LineLayer
                    Dim arrayDatosGraficaInercGruesAgriet_Real_CalculadaREGRESION_LINEAL As Double() = objFacade.Regresion(arrayDatosGraficaInercGruesAgriet_Real_CalculadaX, arrayDatosGraficaInercGruesAgriet_Real_CalculadaY, intConstante, intCoeficiente)
                    linea_Tendencia5toGrafico = XYChart_Grafica_InercGruesAgriet_Real_Calculada.addLineLayer(arrayDatosGraficaInercGruesAgriet_Real_CalculadaY, &HAC)
                    linea_Tendencia5toGrafico.setXData(arrayDatosGraficaInercGruesAgriet_Real_CalculadaX)
                    ' --------------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO  Y CURVATURA" |
                    ' --------------------------------------------------------------------------------------------------------                 
                    'Se Agrega la "LINEA PROMEDIO" 
                    objFacade.ObtenerPromedioArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, intNumeroIteracionesAMC)
                    objFacade.ObtenerPromedioArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC, intNumeroIteracionesAMC)
                    Dim linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_6_EC As LineLayer
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_6_EC = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLineLayer(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, colores(2), "MEAN")
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_6_EC.setXData(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC)
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_6_EC.setLineWidth(3)
                    Dim arrayDatosGraficaRelacionDeformacionUnitaria_Curvatura_EC_REGRESION_LINEAL As Double() = objFacade.Regresion(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC, arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_Curvatura_Y_EC, intConstante, intCoeficiente)
                    'Agrega de Formula en la Parte superior
                    'Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addText(120, 5, "<*block*>E<*sub*>c<*/*> = " & FormatNumber(intCoeficiente, 4) & " DΦ + " & FormatNumber(intConstante, 4), "", 11)
                    Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addText(120, 5, "<*block*><*size=13*> ε<*sub*>c<*/*> = " & FormatNumber(intCoeficiente, 4) & " DΦ ", "", 11)
                    txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_EC.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
                    ' -----------------------------------------------------------------------------------------------------
                    '| LEVANTAMIENTO GRÁFICO: GRÁFICA NÚMERO#7 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" |
                    ' -----------------------------------------------------------------------------------------------------
                    'Se Agrega la "LINEA PROMEDIO" 
                    objFacade.ObtenerPromedioArreglosDeDatosGraficaRelacionDeformacionUnitaria_Curvatura(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Acero_Curvatura_Y_ES, intNumeroIteracionesAMC)
                    Dim linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_7_ES As LineLayer
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_7_ES = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLineLayer(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Acero_Curvatura_Y_ES, colores(2), "MEAN")
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_7_ES.setXData(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC)
                    linLayerPromedio_GraficaRelacionDeformacionUnitaria_Curvatura_7_ES.setLineWidth(3)
                    'Agrega de Formula en la Parte superior
                    Dim arrayDatosGraficaRelacionDeformacionUnitaria_Curvatura_ES_REGRESION_LINEAL As Double() = objFacade.Regresion(arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Concreto_ACERO_Curvatura_X_EC, arrayDouPromedioDeDatosGraficaRelacionDeformacionUnitaria_Acero_Curvatura_Y_ES, intConstante, intCoeficiente)
                    'Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addText(120, 5, "<*block*>E<*sub*>s<*/*> = " & FormatNumber(intCoeficiente, 4) & " DΦ + " & FormatNumber(intConstante, 4), "", 11)
                    Dim txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES As ChartDirector.TextBox = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addText(120, 5, "<*block*><*size=13*> ε<*sub*>s<*/*> = " & FormatNumber(intCoeficiente, 4) & " DΦ ", "", 11)
                    txtBox_GraficaRelacionDeformacionUnitaria_Curvatura_ES.setBackground(intColorFondoFormulasGraficas, intColorFondoFormulasGraficas, 1)
                End If
            Catch ex As Exception
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the Graphic rising")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
        End Sub

        ''' <summary>
        ''' Agrega eventos a los TextBox y Buttons, estos codificados en JavaScript del lado del Cliente
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEstablecerAtributosAControles()
            'Valida que el formato sea correcto, no permite 22.22.22 ni letras hhhfgh
            txtSectionDiameter.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtSectionDiameter);")
            txtConvertLB.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtConvertLB);")
            txtLongBarDiameter.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtLongBarDiameter);")
            txtNumberLongBars.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtNumberLongBars);")
            txtTransverseReinfDiam.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtTransverseReinfDiam);")
            txtSpacingTransSteel.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtSpacingTransSteel);")
            txtConcrComprStrength.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtConcrComprStrength);")
            txtLongRYS.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtLongRYS);")
            txtTransRYS.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtTransRYS);")
            txtLongRMX.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtLongRMX);")
            txtAxialLoad.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.txtAxialLoad);")

            'Permitir solo ingreso de números
            txtSectionDiameter.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtConvertLB.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtLongBarDiameter.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtNumberLongBars.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtTransverseReinfDiam.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtSpacingTransSteel.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtConcrComprStrength.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtLongRYS.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtTransRYS.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtLongRMX.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            txtAxialLoad.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")

            'Atributos para obtener los estandares de la columna:
            txtSectionDiameter.Attributes.Add("onChange", "establecerEstandares();")
            txtConvertLB.Attributes.Add("onChange", "establecerEstandares();")
            txtLongBarDiameter.Attributes.Add("onChange", "establecerEstandares();")
            txtNumberLongBars.Attributes.Add("onChange", "establecerEstandares();")
            txtTransverseReinfDiam.Attributes.Add("onChange", "establecerEstandares();")
            txtSpacingTransSteel.Attributes.Add("onChange", "establecerEstandares();")
            txtConcrComprStrength.Attributes.Add("onChange", "establecerEstandares();")
            txtLongRYS.Attributes.Add("onChange", "establecerEstandares();")
            txtTransRYS.Attributes.Add("onChange", "establecerEstandares();")
            txtLongRMX.Attributes.Add("onChange", "establecerEstandares();")
            txtAxialLoad.Attributes.Add("onChange", "establecerEstandares();")

            btnGraficar.Attributes.Add("onClick", "return simular();")
            btnLimpiar.Attributes.Add("onClick", "limpiar();")
            btnCargarEjemplo.Attributes.Add("onClick", "cargarEjemplo();")
        End Sub

        ''' <summary>
        ''' Agrega los controles Gráficos a la Página Web.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCrearWebChartViewer()
            WebChartViewer1.Image = XYChart_Grafica_MomentoCurvatura.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_MomentoCurvatura") = WebChartViewer1.Image
            'Creacion de un mapa de imagen para las leyendas del 1er gráfico.
            Dim legendImageMap As String = legendBox.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'")
            WebChartViewer1.ImageMap = XYChart_Grafica_MomentoCurvatura.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer2.Image = XYChart_Grafica_EstimCurvaturaFluencia.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_EstimCurvaturaFluencia") = WebChartViewer2.Image
            WebChartViewer2.ImageMap = XYChart_Grafica_EstimCurvaturaFluencia.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer3.Image = XYChart_Grafica_ResistenciaRigidez.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_ResistenciaRigidez") = WebChartViewer3.Image
            WebChartViewer3.ImageMap = XYChart_Grafica_ResistenciaRigidez.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer4.Image = XYChart_Grafica_InerciaGruesa_Agrietada.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_InerciaGruesa_Agrietada") = WebChartViewer4.Image
            WebChartViewer4.ImageMap = XYChart_Grafica_InerciaGruesa_Agrietada.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer5.Image = XYChart_Grafica_InercGruesAgriet_Real_Calculada.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_InercGruesAgriet_Real_Calculada") = WebChartViewer5.Image
            WebChartViewer5.ImageMap = XYChart_Grafica_InercGruesAgriet_Real_Calculada.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer6.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC") = WebChartViewer6.Image
            WebChartViewer6.ImageMap = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
            WebChartViewer7.Image = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.makeWebImage(Chart.PNG)
            Session("XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES") = WebChartViewer7.Image
            WebChartViewer7.ImageMap = XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.getHTMLImageMap("javascript:getDatos('{dsField0}');", " ", _
                "title='Press to see the entered data!'") + legendImageMap
        End Sub

        ''' <summary>
        ''' Visualiza en el Esquema de la columna (control animado Flash) los Parámetros de Diseño ingresados
        ''' esto lo hace de forma dinámica, del lado del cliente y del servidor.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subMantenerDatosFlashAnimation()
            Try
                Flash1Exp.setMovieVariable("diametro", txtSectionDiameter.Text & " mm")
                Flash1Exp.setMovieVariable("drt", " # " & txtTransverseReinfDiam.Text & " " & Chr(64) & " " & txtSpacingTransSteel.Text & " mm")
                Flash1Exp.setMovieVariable("drl", txtNumberLongBars.Text & " # " & txtLongBarDiameter.Text & " mm")
                Flash1Exp.setMovieVariable("recubrimiento", txtConvertLB.Text & " mm")
            Catch ex As Exception
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the maintenance of the Animación Flash")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
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
            ' GRÁFICA NÚMERO#1   "ANÁLISIS MOMENTO CURVATURA"
            CrearGraficasXYChart(60, 5, 250, 250, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "MOMENT(kN-m)", "Arial Bold Italic", 9, 0, 3, "CURVATURE (1/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_MomentoCurvatura)
            legendBox = XYChart_Grafica_MomentoCurvatura.addLegend(intAddLegend_Coord_x, intAddLegend_Coord_y, bolAddLegend_Bool, strAddLegend_Font, intAddLegend_FontSize)
            legendBox.setBackground(Chart.Transparent)
            ' GRÁFICA NÚMERO#2   "ESTIMACIÓN DE CURVATURA DE FLUENCIA"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "Φy (1/m)", "Arial Bold Italic", 9, 0, 3, "<*block*><*size=13*> ε<*sub*>y<*/*> / D (1/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_EstimCurvaturaFluencia)
            XYChart_Grafica_EstimCurvaturaFluencia.addLegend(50, 50, False, "Times New Roman Bold Italic", 12).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#3   "RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ"
            'CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "FLEXURAL STRENGTH  My (kN/m)", "Arial Bold Italic", 9, 0, 3, "CRACKED FLEXURAL STIFFNESS Elcr (kN/m<*super*>2)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_ResistenciaRigidez)
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "FLEXURAL STRENGTH  My (kN-m)", "Arial Bold Italic", 9, 0, 3, "CRACKED FLEXURAL STIFFNESS Elcr (kN/m)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_ResistenciaRigidez)
            XYChart_Grafica_ResistenciaRigidez.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#4   "RELACIÓN ENTRE INERCIA GRUESA / INERCIA AGRIETADA Y LA CUANTÍA DE ACERO"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> ", "Arial Bold Italic", 9, 0, 3, " ρ (%)", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InerciaGruesa_Agrietada)
            XYChart_Grafica_InerciaGruesa_Agrietada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICO NÚMERO#5   "RELACIÓN DE LA INERCIA GRUESA / INERCIA AGRIETADA REAL Y LA INERCIA GRUESA / INERCIA AGRIETADA CALCULADA"
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> from M-C", "Arial Bold Italic", 9, 0, 3, "<*block*>I<*sub*><*size=10*>cr<*/*> / I<*sub*><*size=10*>g<*/*> Kowalsky", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_InercGruesAgriet_Real_Calculada)
            XYChart_Grafica_InercGruesAgriet_Real_Calculada.addLegend(50, 50, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICA NÚMERO#6 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL CONCRETO Y CURVATURA" Ec
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>c<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC)
            XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            ' GRÁFICA NÚMERO#7 "RELACIÓN ENTRE DEFORMACIÓN UNITARIA DEL ACERO Y CURVATURA" Es        ''' </summary>
            CrearGraficasXYChart(60, 40, 320, 300, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC, "", "Times New Roman Bold", 16, 0, 0, 0, "<*block*><*size=13*> ε<*sub*>s<*/*>", "Arial Bold Italic", 9, 0, 3, "DΦ", "Arial Bold Italic", 9, 0, 3, XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES)
            XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES.addLegend(380, 85, False, "Arial Bold", 9).setBackground(Chart.Transparent)
            'Para Cuidar el Formato de las Graficas, las leyendas solamente pueden escribirse hasta 17
            Dim intA As Integer = Session("dtColumna").Count
            If Session("dtColumna").Count > 16 Then
                btnGraficar.Enabled = False
                btnCargarEjemplo.Enabled = False
            Else
                btnGraficar.Enabled = True
                btnCargarEjemplo.Enabled = True
            End If
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
        ''' limpia TODOS los Controles de tipo TEXTBOX del Formulario
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subLimpiarControles()
            txtSectionDiameter.Text = Nothing
            txtConvertLB.Text = Nothing
            txtLongBarDiameter.Text = Nothing
            txtNumberLongBars.Text = Nothing
            txtTransverseReinfDiam.Text = Nothing
            txtSpacingTransSteel.Text = Nothing
            txtConcrComprStrength.Text = Nothing
            txtLongRYS.Text = Nothing
            txtTransRYS.Text = Nothing
            txtLongRMX.Text = Nothing
            txtAxialLoad.Text = Nothing

            txtLongRR.Text = Nothing
            txtTransRR.Text = Nothing
            txtAxialLoadRatio.Text = Nothing
            tbModuloElasticidadAcero.Text = Nothing
            tbModuloElasticidadConcreto.Text = Nothing
            tbDeformacionFluenciaAceroLongitudinal.Text = Nothing
            tbMomentoPrimeraFluencia.Text = Nothing
            tbPrimeraCurvaturaFluencia.Text = Nothing
            tbMomentoNominal.Text = Nothing
            tbCurvaturaFluencia.Text = Nothing
            tbInerciaGruesa.Text = Nothing
            tbIncerciaAgrietada.Text = Nothing
            tbIcrIg.Text = Nothing
        End Sub

        ''' <summary>
        ''' Elimina una columna determinada (datos de Diseño y Análisis), del dataTable
        ''' mas no de la DB, para ello utiliza el valor asignado al Campo oculto "hiddNumTest"
        ''' el cual contiene el ID de la Columna.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEliminarColumna()
            Try
                Dim intColumna_id As Integer = hiddNumTest.Value
                objFacade.EliminarColumna(hiddNumTest.Value, 0, Session("dtColumna"))
                objFacade.ActualizarSecuencia(hiddNumTest.Value, 0, Session("dtColumna"))
                establecerPropCtrlGraficos()
                subGenerarGraficas()
                subCrearWebChartViewer()
                subLimpiarControles()
                intNumeroIteracionesAMC = Session("dtColumna").count
            Catch ex As Exception
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the Delete Analysis")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
        End Sub

        ''' <summary>
        ''' Muestra los Indicadores del Análisis en los controles de tipo TEXTBOX
        ''' despues de ejecutar el análisis.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarEstandaresAnalisis()
            Try
                Dim strDatosDesigner_Indicadores_AMC() As String = Split(objFacade.ObtenerIndicadoresAMC(Session("NumeroIteracionesAMC"), 0, Session("dtColumna")), " ", 7, CompareMethod.Text)
                tbMomentoPrimeraFluencia.Text = strDatosDesigner_Indicadores_AMC(0)
                tbPrimeraCurvaturaFluencia.Text = strDatosDesigner_Indicadores_AMC(1)
                tbMomentoNominal.Text = strDatosDesigner_Indicadores_AMC(2)
                tbCurvaturaFluencia.Text = strDatosDesigner_Indicadores_AMC(3)
                tbInerciaGruesa.Text = strDatosDesigner_Indicadores_AMC(4)
                tbIncerciaAgrietada.Text = strDatosDesigner_Indicadores_AMC(5)
                tbIcrIg.Text = strDatosDesigner_Indicadores_AMC(6)
            Catch ex As Exception
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the bring up to date of the Standards of Analysis")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
        End Sub

        ''' <summary>
        ''' Asigna el valor de las tres Propiedades de los Materiales aplicando sus respectivas formulas:
        ''' Modulo de Elasticidad del Acero = 2000 (Es una CONSTANTE)
        ''' Modulo de Elasticidad del Concreto = 4700 √ Resistencia a la Compresión del Concreto. ó 4700√f'ce
        ''' Deformacion de Fluencia del Acero Longitudinal = fy / Es
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subAsignarPropiedadesMateriales()
            objConstDTO = New [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
            Me.tbModuloElasticidadAcero.Text = objConstDTO.MODUL_ELASTICIDAD_ACERO
            Me.tbModuloElasticidadConcreto.Text = 4700 * Math.Sqrt(CDbl(Me.txtConcrComprStrength.Text)).ToString
            Me.tbDeformacionFluenciaAceroLongitudinal.Text = Math.Round((CDbl(Me.txtLongRYS.Text) / CDbl(objConstDTO.MODUL_ELASTICIDAD_ACERO)), 4)
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
                dtColumna = New DTO.dsColumna.COLUMNADataTable
                Session("dtColumna") = dtColumna
                Session("dtColumna").Clear()
                subEstablecerAtributosAControles()
                establecerPropCtrlGraficos()
                subCrearWebChartViewer()
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' Agrega al DataTable "dtGraficas" de tipo "GRAFICAS" del DataSet "dsColumna" una nueva fila o registro
        ''' Para cada experimento existiran "n = 7" Graficas de Garficación de resultados.
        ''' </summary>
        ''' <param name="intGraficas_Id">Identificador único del gráfico, valor arbitrario ya que es de tipo IDENTITY en la DB
        ''' (auntogenerado al insertar una nueva filao registro) </param>
        ''' <param name="intExpColumna_Id">Identificador único del "ExpColumna", este se obtendra una vez insertado un nuevo "ExpColumna"
        ''' ya que en la DB es de tipo IDENTITY</param>
        ''' <param name="strGraficas_Nombre">Nombre de la Gráfica</param>
        ''' <param name="bytGraficas_Imagen">Arreglo de Byte el cual contiene la imagen</param>
        ''' <param name="drGraficas">DataRow de tipo grGraficas</param>
        ''' <param name="dtGraficas">DataTable de tipo dtGraficas de tipo GRAFICAS del DataSet COLUMNA</param>
        ''' <remarks></remarks>
        ''' <history>
        ''' [pdirene]	Creado 2k7-12-07  
        ''' </history>
        Private Sub subAgregarROW_dsGraficas(ByVal intGraficas_Id As Integer, ByVal intExpColumna_Id As Integer, ByVal strGraficas_Nombre As String, ByVal bytGraficas_Imagen() As Byte, ByRef drGraficas As DTO.dsColumna.GRAFICASRow, ByRef dtGraficas As DTO.dsColumna.GRAFICASDataTable)
            drGraficas(dtGraficas.GRAFICAS_IDColumn) = intGraficas_Id 'El Graficas_Id es alvitrario ya que este se autogenera en el SQL
            drGraficas(dtGraficas.EXPCOLUMNA_IDColumn) = intExpColumna_Id
            drGraficas(dtGraficas.GRAFICAS_NOMBREColumn) = strGraficas_Nombre
            drGraficas(dtGraficas.GRAFICAS_IMAGENColumn) = bytGraficas_Imagen
            dtGraficas.AddGRAFICASRow(drGraficas)
        End Sub


        ''' <summary>
        ''' Llama la metodo "subAgregarROW_dsGraficas" para agregar cada una de las Gráficas Estadisticas generadas, esto lo hace 
        ''' en el DataTable dtGraficas de tipo GRAFICAS del DataSet "dsColumna", a su vez retorna este DataTable con los datos agregados
        ''' para que sean posteriormente escritos en la DB
        ''' </summary>
        ''' <returns>DataTable "dtGraficas" lleno, de tipo "GRAFICAS" del DataSet COLUMNA</returns>
        ''' <remarks></remarks>
        ''' <history>
        ''' [pdirene]	Creado 2k7-12-07  
        ''' </history>
        Private Function fuctGetGraficasEstadisticas() As DTO.dsColumna.GRAFICASDataTable
            Dim dtGraficas As DTO.dsColumna.GRAFICASDataTable = New DTO.dsColumna.GRAFICASDataTable
            Dim drGraficas As DTO.dsColumna.GRAFICASRow
            Try
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(1, 1, "MOMENT CURVATURE RESPONSE", Session("XYChart_Grafica_MomentoCurvatura").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(2, 1, "YIELD CURVATURE ASSESSMENT", Session("XYChart_Grafica_EstimCurvaturaFluencia").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(3, 1, "RELATION BETWEEN STRENGTH AND STIFFNESS", Session("XYChart_Grafica_ResistenciaRigidez").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(4, 1, "CRACKED TO GROSS INERTIA RATIO AND LONGITUDINAL STEEL RATIO", Session("XYChart_Grafica_InerciaGruesa_Agrietada").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(5, 1, "EVALUATION OF MODEL FOR ASSESMENT OF lcr/lg", Session("XYChart_Grafica_InercGruesAgriet_Real_Calculada").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(6, 1, "RELATION BETWEEN CONCRETE STRAIN AND CURVATURE", Session("XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_EC").image, drGraficas, dtGraficas)
                drGraficas = dtGraficas.NewGRAFICASRow
                subAgregarROW_dsGraficas(7, 1, "RELATION BETWEEN STEEL STRAIN AND CURVATURE", Session("XYChart_Grafica_RelacionDeformacionUnitariaCurvatura_ES").image, drGraficas, dtGraficas)
            Catch ex As Exception
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the Creation of the Graphic Controls")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
            Return dtGraficas
        End Function


        ''' <summary>
        ''' Inserta en la DB un nuevo registro o fila en las Tablas "EXPCOLUMNA" "COLUMNA" "GRAFICAS"
        ''' para generar un reporte.
        ''' </summary>
        ''' <remarks></remarks>
        ''' <history>
        ''' [pdirene]	Creado 2k7-12-07  
        ''' </history>
        Private Sub subGenerarInforme_Insertar_ExpColumna_Columna_Graficas()
            'Se perimitira que los usuarios ingresen el nombre del Experimento columna
            'en una etapa posterior
            Dim strExpColumna_nombre As String = "MOMENT-CURVATURE OF CIRCULAR REINFORCED CONCRETE COLUMNS"
            Dim dateExpColumna_FechaCreacion As Date = Now 'Obtiene la fecha actual del sistema
            Try
                objFacade.Insertar_ExpColumna_Columna_Graficas(Session("intUserID"), intExpColumna_Id, strExpColumna_nombre, dateExpColumna_FechaCreacion, Session("dtColumna"), fuctGetGraficasEstadisticas)
                GetExpColumnaID = intExpColumna_Id
            Catch ex As SqlClient.SqlException
                Response.BufferOutput = True
                ex.Data.Add("InfoExtra", "Generated error from the Insert of the DataTables in the DB")
                VirtualLabIS.Common.Global.Clases.Varios.exError = ex
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/ErrorPage.aspx")
            End Try
            Dim instanceServer As HttpServerUtility = Me.Server()
            Dim path As String = "~/VirtualLabIS/Reportes/Columna/wfReportColumnaAMC.aspx"
            instanceServer.Transfer(path)
        End Sub

        ''' <summary>
        ''' Muestra y oculta los Mensajes de REGISTRO al sitio Web.
        ''' Para que los Usuario puedan generar el Reporte del ExpVirtual, deben estar antes Registrados
        ''' en el caso que no lo esten se les muestra un mensaje de y un Link indicandole que se deben
        ''' Registrar y/o Logear.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subMostrarMensajeRegistro_Reporte()
            'Pregunta si se autentico
            If Request.IsAuthenticated = True Then
                Session("intUserID") = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id
                lblMensajeRegistrarse.Visible = False
                hplRegistrarse.Visible = False
            Else
                btnInforme.Enabled = False
                lblMensajeRegistrarse.Visible = True
                hplRegistrarse.Visible = True
                lblMensajeRegistrarse.Text = "If you want to see the REPORT, please register"
                hplRegistrarse.Text = "REGISTER HERE"
                hplRegistrarse.NavigateUrl = "~/Default.aspx"
            End If
        End Sub

        ''' <summary>
        ''' Deshabiliza el Boton para ver el informe en caso de que no existan datos en el Data Table "dtColumna"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subMostrarBottonReport()
            btnInforme.Enabled = True
            If (intNumeroIteracionesAMC > 0) And (Request.IsAuthenticated = True) Then
                btnInforme.Enabled = True
            Else
                btnInforme.Enabled = False
            End If
        End Sub

        Private Sub subInicializarIdiomaTextoControles()


            'Etiquetas de la cabecera del Experimento "Análisis Momento Curvatura"
            Me.imgRutaTitulo.ImageUrl = Localization.GetString("imgRutaTitulo.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloExp.Text = Localization.GetString("lblTituloExp.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'BLOQUE DE DATOS DE ENTRADA
            '==========================
            'Propiedades de la Sección
            Me.lblInputData1.Text = Localization.GetString("lblInputData1.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloSeccionProper.Text = Localization.GetString("lblTituloSeccionProper.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblSectionDiameter.Text = Localization.GetString("lblSectionDiameter.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblConvertLB.Text = Localization.GetString("lblConvertLB.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblLongBarDiameter.Text = Localization.GetString("lblLongBarDiameter.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblNumberLongBars.Text = Localization.GetString("lblNumberLongBars.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTransverseReinfDiam.Text = Localization.GetString("lblTransverseReinfDiam.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTipo.Text = Localization.GetString("lblTipo.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblSpacingTransSteel.Text = Localization.GetString("lblSpacingTransSteel.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Propiedades de los Materiale de Construcción
            Me.lblTituloMaterialProper.Text = Localization.GetString("lblTituloMaterialProper.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblConcrComprStrength.Text = Localization.GetString("lblConcrComprStrength.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblLongRYS.Text = Localization.GetString("lblLongRYS.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTransRYS.Text = Localization.GetString("lblTransRYS.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblLongRMX.Text = Localization.GetString("lblLongRMX.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblAxialLoad.Text = Localization.GetString("lblAxialLoad.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblModuloElasticidadAcero.Text = Localization.GetString("lblModuloElasticidadAcero.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblModuloElasticidadConcreto.Text = Localization.GetString("lblModuloElasticidadConcreto.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblDeformacionFluenciaAceroLongitudinal.Text = Localization.GetString("lblDeformacionFluenciaAceroLongitudinal.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Controles Esquema de la Sección, Links y Botones
            Me.lblTituloEsquemaColumna.Text = Localization.GetString("lblTituloEsquemaColumna.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.btnGraficar.Text = Localization.GetString("btnGraficar.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.btnCargarEjemplo.Text = Localization.GetString("btnCargarEjemplo.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.btnLimpiar.Text = Localization.GetString("btnLimpiar.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.btnInforme.Text = Localization.GetString("btnInforme.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblMensajeRegistrarse.Text = Localization.GetString("lblMensajeRegistrarse.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.hplRegistrarse.Text = Localization.GetString("hplRegistrarse.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'BLOQUE DE GRAFICAS DE RESULTADOS
            '================================
            'Resultados del Análisis Momento Curvatura "Gráfica 0"
            Me.lblResults.Text = Localization.GetString("lblResults.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblAnalysis.Text = Localization.GetString("lblAnalysis.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloAnalysisIndex.Text = Localization.GetString("lblTituloAnalysisIndex.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblLongRR.Text = Localization.GetString("lblLongRR.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTransRR.Text = Localization.GetString("lblTransRR.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblAxialLoadRatio.Text = Localization.GetString("lblAxialLoadRatio.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblAnalysisResult.Text = Localization.GetString("lblAnalysisResult.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblMomentoPrimeraFluencia.Text = Localization.GetString("lblMomentoPrimeraFluencia.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblPrimeraCurvaturaFluencia.Text = Localization.GetString("lblPrimeraCurvaturaFluencia.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblMomentoNominal.Text = Localization.GetString("lblMomentoNominal.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblCurvaturaFluencia.Text = Localization.GetString("lblCurvaturaFluencia.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblInerciaGruesa.Text = Localization.GetString("lblInerciaGruesa.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblIncerciaAgrietada.Text = Localization.GetString("lblIncerciaAgrietada.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblIcrIg.Text = Localization.GetString("lblIcrIg.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.btnEliminarTest.Text = Localization.GetString("btnEliminarTest.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloMCR.Text = Localization.GetString("lblTituloMCR.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 1: FIG. 1 ESTIMACIÓN DE LA CURVATURA DE FLUENCIA" 
            Me.lblTituloFig1.Text = Localization.GetString("lblTituloFig1.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloTeoria1.Text = Localization.GetString("lblTituloTeoria.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTeoria1.Text = Localization.GetString("lblTeoria1.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 2: FIG 2. RELACIÓN ENTRE RESISTENCIA Y RIGIDEZ"
            Me.lblTituloFig2.Text = Localization.GetString("lblTituloFig2.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloTeoria2.Text = Localization.GetString("lblTituloTeoria.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTeoria2.Text = Localization.GetString("lblTeoria2.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 3:FIG 3. RELACIÓN ENTRE INERCIA GRUESA  Y AGRIETADA VS. CUANTIA DEL ACERO LONGITUDINAL"
            Me.lblTituloFig3.Text = Localization.GetString("lblTituloFig3.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloTeoria3.Text = Localization.GetString("lblTituloTeoria.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTeoria3.Text = Localization.GetString("lblTeoria3.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 4: FIG 4. EVALUACIÓN DEL MODELO PARA ESTIMACIÓN DE Icr/Ig "
            Me.lblTituloFig4.Text = Localization.GetString("lblTituloFig4.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloTeoria4.Text = Localization.GetString("lblTituloTeoria.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTeoria4.Text = Localization.GetString("lblTeoria4.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 5: FIG 5. RELACIÓN ENTRE DEFORMACIÓN DEL CONCRETO Y CURVATURA "
            Me.lblTituloFig5.Text = Localization.GetString("lblTituloFig5.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTituloTeoria5.Text = Localization.GetString("lblTituloTeoria.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            Me.lblTeoria5.Text = Localization.GetString("lblTeoria5.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
            'Resultados del Análisis Momento Curvatura "Gráfica 6: FIG 6. RELACIÓN ENTRE DEFORMACIÓN DEL ACERO Y CURVATURA"
            Me.lblTituloFig6.Text = Localization.GetString("lblTituloFig6.Text", Localization.GetResourceFile(Me, "wfExperimentoColumna.aspx"))
        End Sub

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
        ''' Este procedimiento establece el idioma de la pagina Los posibles valores que se 
        ''' pueden setear para el idioma son: es-ES y en
        ''' Metodo compatible "Protected Overrides Sub InitializeCulture()"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subInitializeCulture()
            'Asignación del idioma del experimento
            getIdioma = Request.Params("idioma")
            'Establece el idioma en los controles de los experimentos
            If getIdioma = "es-ES" Then
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-ES")
            Else
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
                Exit Sub
            End If
        End Sub

        ''' <summary>
        ''' Verifica si es la primera vez que se carga la página para inicializar todos los controles:
        ''' gráficos, de datos, referencias, etc.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                'If Request.IsAuthenticated = True Then
                '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                subInitializeCulture()
                    subInicializarIdiomaTextoControles()
                    dtColumna = New DTO.dsColumna.COLUMNADataTable
                    Session("dtColumna") = dtColumna
                    subEstablecerAtributosAControles()
                    establecerPropCtrlGraficos()
                    subCrearWebChartViewer()
                    subMostrarMensajeRegistro_Reporte()
                'Else
                '    getIdioma = Request.Params("idioma")
                '    Response.BufferOutput = True
                '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
                'End If
            End If
        End Sub

        ''' <summary>
        ''' Mediante JavaScritp se cargar los Parametros de Diseño de la Columna en el controles TEXTBOX del lado del cliente
        ''' Ejecuta el Análisis Momento Curvatura muestra los estandares del AMC y Actualiza el control Flash Dinamico.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnCargarEjemplo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarEjemplo.Click
            If funcSesionExpirada() Then
                subGraficar()
            End If
        End Sub

        ''' <summary>
        ''' Ejecuta el Análisis Momento Curvatura una vez que el usuario a ingresado los parametros de Diseño de la Columna
        ''' muestra los estandares del AMC y Actualiza el control Flash Dinamico.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnGraficar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGraficar.Click
            If funcSesionExpirada() Then
                subGraficar()
            End If
        End Sub

        ''' <summary>
        ''' Limpia Todos los controles gráficos, TextBox, referencias y datos del DataTable dtColumna (Variables de sesión)
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
            Session("dtColumna").Clear()
            intNumeroIteracionesAMC = Session("dtColumna").count
            establecerPropCtrlGraficos()
            subCrearWebChartViewer()
            subMostrarBottonReport()
            subLimpiarControles()
        End Sub

        ''' <summary>
        ''' Elimina los datos de Diseño y Análisis de una iteración deternminada (El DataTable dtColumna)
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnEliminarTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarTest.Click
            If funcSesionExpirada() Then
                subEliminarColumna()
            End If
        End Sub

        ''' <summary>
        ''' Para Generar el Informe primero se insertan en la DB los siguiente DataTables correspondientes a las tablas
        ''' "EXPCOLUMNA" (dtExpColumna) "COLUMNA" (dtColumna) "GRAFICAS" (dtgraficas)
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnInforme_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInforme.Click
            If funcSesionExpirada() Then
                subGenerarInforme_Insertar_ExpColumna_Columna_Graficas()
            End If
        End Sub
#End Region

    End Class
End Namespace

