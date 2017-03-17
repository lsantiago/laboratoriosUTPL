
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Math
Imports ChartDirector
Imports VirtualLabIS.DTO
Imports VirtualLabIS.Facade
Imports System.Data
Imports System.Threading

Imports System.Web.UI.HtmlControls

Imports DotNetNuke.Entities.Tabs
Imports DotNetNuke.Security.Permissions
Imports DotNetNuke.UI.Skins
Imports DotNetNuke.UI.Utilities


Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_wfSIMUQUAKE_VIEWER
        Inherits System.Web.UI.Page

#Region "VariablesGlobales"
        'variables del Usuario
        Private Shared intUserID As Integer
        Private Shared strUsername As String
        Private Shared strUserMail As String
        'Objetos
        Private ctrlGrafcSismo As ASP.virtuallabis_experimentos_laboratorios_h_simulation_simuquake_modulografcsismo_ctrlgraficsismos_ascx
        Private ctrlGraficAcelDespSpectral As ASP.virtuallabis_experimentos_laboratorios_h_simulation_simuquake_modulografcsismo_ctrlgraficaceldespspectral_ascx
        Private Shared objConst As [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
        'Variables
        Private Shared bytFileIn() As Byte
        Private Shared bolBanderaFileSismo As Boolean
        Private Shared strIdioma As String
        Private Shared getIdioma As String
        'Matriz tridimencional para el <Target Sprectrum> y <los Sísmos>
        Private Shared bouArrayTargetSpecSismos(,,) As Double
        'Array undimencional para los registros sísmicos, dentro del ciclo se redincionan
        Private Shared bouArraySismos(,) As Double
        Private Shared boolIndicador, boolIndicador2, boolIndPage As Boolean
        Private Shared strPathFilesSimuQuake As String
        Private Shared strPathFilesSimuQuakeFileOut As String
        Private Shared strNombreFileOut As String
        Private Shared intNumSismosGlobal As Integer
        Private Shared strNomSismo As String
#End Region

#Region "Inicialización de Idioma y Controles"
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

        ''' <summary>
        ''' Agrega propiedades uy atributos a los controles de la página
        ''' para ejecutar codigo JavaScript del lado del cliente.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub subEstablecerPropiedadesCtrl()
            Me.cmdVerGrafc.Attributes.Add("onClick", "cmdVerGrafc_onclick();")

        End Sub
#End Region

#Region "RecorrerArchivoSismicoDeResultados"

        ''' <summary>
        ''' Recorre el archivo de entrada y filtra los datos para obtener una matriz tridimencional con: 
        ''' "intNumSismos" Número de Sísmos, 
        ''' "intNumPuntEspect" Número de Puntos Espectrales y 
        ''' "3" Columnas de este bloque de datos
        ''' Estas matricez corresponden el bloque de datos del "Target Spectrum" y al de los "Promedios Sísmicos"
        ''' </summary>
        ''' <param name="charArray">Arreglos de Caracteres del archivo de entrada</param>
        ''' <param name="intNumSismos">Número de Sísmos en el archivo de antrada</param>
        ''' <param name="intNumPuntEspect">Número de Puntos Espectrales</param>
        ''' <returns>Matriz tridimencional con los bloques para el "Target Spectrum" y los "Promedios Sísmicos"</returns>
        ''' <remarks></remarks>
        Public Function fucObtenerMatrizTargetSpectrum(ByVal charArray() As Char, ByVal intNumSismos As Integer, ByVal intNumPuntEspect As Integer) As Double(,,)
            Dim provider As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
            provider.NumberDecimalSeparator = "."

            'Matrices tridimencionales para el <Target Sprectrum> y <los Sísmos>
            Dim strArrayTargetSpecSismos(intNumPuntEspect - 1, 2) As String
            Dim bouArrayTargetSpecSismos(intNumSismos, intNumPuntEspect - 1, 2) As Double
            Dim x As Integer = 0 'Fila
            Dim y As Integer = 0 'Columna

            'Variables para recorrer el archivo de entrada
            Dim intContSismosTarg As Integer = 0
            Dim intContSismos As Integer = 0
            Dim intContChar As Integer = 0
            Dim intCodASCII As Integer = 0

            'Recorre el archivo de entrada para recoger los datos para las matrices <Target Sprectrum> y <Sísmos>
            'y para los arreglos de los registros sísmicos.
            While intContSismosTarg <= intNumSismos
                'Avance <intContChar> hasta que halle cadena "Period" que es en donde empieza el bloque de datos "Target Spectrum"
                intContChar += 1
                intCodASCII = Asc(charArray(intContChar))
                If (intCodASCII = 10) Then
                    '-----------------------------
                    '| BLOQUE DE DATOS <PERIODO> |
                    '-----------------------------
                    Dim strPeriod As String = charArray(intContChar + 1) + charArray(intContChar + 2) + charArray(intContChar + 3) + charArray(intContChar + 4) + charArray(intContChar + 5) + charArray(intContChar + 6)
                    If (strPeriod = "Period") Then
                        'Avance <intContChar> hasta hallar el fin de la cadena
                        Do
                            intContChar += 1
                        Loop Until Asc(charArray(intContChar)) = 10
                        intContChar += 1
                        x = 0
                        y = 0
                        ReDim strArrayTargetSpecSismos(intNumPuntEspect - 1, 2)
                        While (x < intNumPuntEspect)
                            intCodASCII = Asc(charArray(intContChar))
                            Select Case intCodASCII
                                'intCodASCII = 9.  Espacio. Simbolo ASCII=TAB
                                'intCodASCII = 32.  Espacio en blanco. Simbolo (espacio)
                                Case 9, 32
                                    y += 1
                                Case 13 'intCodASCII = 13. Simbolo ASCII=CR
                                Case 10 'intCodASCII = 10. Simbolo ASCII=LF
                                    x += 1
                                    y = 0
                                Case Else
                                    strArrayTargetSpecSismos(x, y) += charArray(intContChar)
                            End Select
                            intContChar += 1
                        End While

                        'Obtiene una Matriz tipo Duoble a partir de la Matriz tipo String
                        Dim intLenght As Integer = UBound(strArrayTargetSpecSismos, 1)
                        For i As Integer = 0 To intLenght
                            For j As Integer = 0 To 2
                                bouArrayTargetSpecSismos(intContSismosTarg, i, j) = Convert.ToDouble(strArrayTargetSpecSismos(i, j), provider)
                            Next
                        Next
                        intContChar += 1
                        intContSismosTarg += 1
                    End If
                End If
            End While
            Return bouArrayTargetSpecSismos
        End Function

        ''' <summary>
        ''' Recorre el archivo de entrada y filtra los datos para obtener una matriz bidimencional con: 
        ''' "intNumSismos" Número de Sísmos, 
        ''' "intNPTS" Número de Puntos Sísmicos
        ''' Estas matricez corresponden el bloque de datos de los "Registros Sísmicos"
        ''' </summary>
        ''' <param name="charArray">Arreglos de Caracteres del archivo de entrada</param>
        ''' <param name="intNumSismos">Número de Sísmos en el archivo de antrada</param>
        ''' <returns>Matriz bidimencional con los Registros Sísmicos</returns>
        ''' <remarks></remarks>
        Public Function fucObtenerMatrizSismos(ByVal charArray() As Char, ByVal intNumSismos As Integer) As Double(,)
            Dim provider As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
            provider.NumberDecimalSeparator = "."

            'Array undimencional para los registros sísmicos, dentro del ciclo se redincionan
            Dim strArraySismos() As String
            Dim bouArraySismos(,) As Double
            Dim x As Integer = 0 'Fila
            Dim y As Integer = 0 'Columna
            'Variables para recorrer el archivo de entrada
            Dim intContSismos As Integer = 0
            Dim intContChar As Integer = 0
            Dim intCodASCII As Integer = 0

            'Recorre el archivo de entrada para recoger los datos para las matrices <Target Sprectrum> y <Sísmos>
            'y para los arreglos de los registros sísmicos.
            While intContSismos < intNumSismos
                'Avance <intContChar> hasta que halle cadena "Period" que es en donde empieza el bloque de datos "Target Spectrum"
                intContChar += 1
                intCodASCII = Asc(charArray(intContChar))
                If (intCodASCII = 10) Then
                    '---------------------------
                    '| BLOQUE DE DATOS <SISMO> |
                    '---------------------------
                    Dim strNPTS As String = charArray(intContChar + 1) + charArray(intContChar + 2) + charArray(intContChar + 3) + charArray(intContChar + 4) + charArray(intContChar + 5) + charArray(intContChar + 6)
                    If (strNPTS = "NPTS= ") Then
                        'Obtiene el valor para el <NPTS>
                        Dim strNPTS_Aux As String = Nothing
                        intContChar += 6
                        Do
                            intContChar += 1
                            intCodASCII = Asc(charArray(intContChar))
                            strNPTS_Aux += charArray(intContChar)
                        Loop While ((intCodASCII >= 48) And (intCodASCII <= 57)) 'Hasta hallar caracteres numéricos
                        Dim intNPTS As Double = Convert.ToDouble(strNPTS_Aux, provider)
                        'Avance <intContChar> hasta hallar el fin de la cadena
                        Do
                            intContChar += 1
                        Loop Until Asc(charArray(intContChar)) = 10

                        'Para los Registros Sísmicos
                        ReDim strArraySismos(intNPTS - 1)
                        ReDim Preserve bouArraySismos(intNumSismos - 1, intNPTS - 1)
                        intContChar += 1
                        x = 0
                        y = 0
                        'Obtiene una matriz de String con los <intNPTS> registros Sísmicos
                        While (y < intNPTS)
                            intCodASCII = Asc(charArray(intContChar))
                            Select Case intCodASCII
                                'intCodASCII = 9.  Espacio. Simbolo ASCII=TAB
                                'intCodASCII = 32.  Espacio en blanco. Simbolo (espacio)
                                Case 9, 32
                                    'Avance <intContChar> hasta hallar el fin de la cadena
                                    Do
                                        intContChar += 1
                                    Loop Until (Asc(charArray(intContChar + 1)) <> 32)
                                    y += 1
                                Case 13 'intCodASCII = 13. Simbolo ASCII=CR
                                Case 10 'intCodASCII = 10. Simbolo ASCII=LF
                                    y += 1
                                Case Else
                                    strArraySismos(y) += charArray(intContChar)
                            End Select
                            intContChar += 1
                        End While

                        'Obtiene una Matriz tipo Duoble a partir de la Matriz tipo String con los <intNPTS> registros Sísmicos
                        Dim intLenght As Integer = UBound(strArraySismos, 1)
                        For i As Integer = 0 To intLenght
                            bouArraySismos(intContSismos, i) = Convert.ToDouble(strArraySismos(i), provider)
                        Next
                        intContChar += 1
                        intContSismos += 1
                    End If
                End If
            End While
            Return bouArraySismos
        End Function

        ''' <summary>
        ''' Filtra el archivo de entrada y obtiene varias matrices las que corresponden a al "Target Spectrum"
        ''' a los "Sismos" y a los "Registros Sismicos"
        ''' </summary>
        ''' <param name="bytFile">Arreglo de Byte</param>
        ''' <remarks></remarks>
        Public Sub subObtenerMatrizesDoubles_ArrayByt(ByVal bytFile() As Byte)
            Dim provider As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
            provider.NumberDecimalSeparator = "."
            'Convierte una arreglo de Bytes en una cadena
            Dim strCadenaArchivo As String = System.Text.ASCIIEncoding.ASCII.GetString(bytFile)
            'Convierte una cadena en un arreglo de Char
            Dim charArray() As Char = strCadenaArchivo.ToCharArray
            'Almacena los datos para Graficar los datos de la Experimentación Real.
            Dim x As Integer = 0 'Fila
            Dim y As Integer = 0 'Columna
            Dim z As Integer = 0 'Columna
            Dim intCodASCII, intNumSismos As Integer

            'Obtiene el Numero de Sismo en el archivo
            For i As Integer = 0 To charArray.Length - 5
                intCodASCII = Asc(charArray(i))
                Select Case intCodASCII
                    Case 10 'intCodASCII = 10. Simbolo ASCII=LF
                        Dim strNPTSSismos As String = charArray(i + 1) + charArray(i + 2) + charArray(i + 3) + charArray(i + 4)
                        If (strNPTSSismos = "NPTS") Then
                            intNumSismos += 1
                        End If
                End Select
            Next

            'Variables para recorrer el archivo de entrada
            Dim intContChar As Integer = 0
            Dim intNumPuntEspect As Integer = 0
            Dim doolIndicador As Boolean = True

            'Obtiene el número de Puntos Espectrales
            While doolIndicador
                'Avance <intContChar> hasta que halle cadena "Period" que es en donde empieza el bloque de datos "Target Spectrum"
                intContChar += 1
                intCodASCII = Asc(charArray(intContChar))
                If (intCodASCII = 10) Then
                    Dim strPeriod As String = charArray(intContChar + 1) + charArray(intContChar + 2) + charArray(intContChar + 3) + charArray(intContChar + 4) + charArray(intContChar + 5) + charArray(intContChar + 6)
                    If (strPeriod = "Period") Then
                        'Avance <intContChar> hasta hallar el fin de la cadena
                        Do
                            intContChar += 1
                        Loop Until Asc(charArray(intContChar)) = 10
                        ''Obtiene el numero de filas que contiene el bloque de datos "TARGET SPECTRUM"
                        ''Codigos ASCCI
                        ''10: Especial <LF>
                        ''13: Especial <CR>
                        ''32: Espacio < >
                        ''46: Punto <.>
                        ''45: Punto <->
                        ''48 al 57: <0123456789>
                        ''69: E Mayuscula <E>
                        Dim intContTarget As Integer = intContChar
                        Do
                            intContTarget += 1
                            intCodASCII = Asc(charArray(intContTarget))
                            If intCodASCII = 10 Then
                                intNumPuntEspect += 1
                                intCodASCII = Asc(charArray(intContTarget + 1))
                                'Si el siguiente caracter no es un número
                                If Not ((intCodASCII >= 48) And (intCodASCII <= 57)) Then Exit Do
                            End If
                        Loop Until False
                        Exit While
                    End If
                End If
            End While
            intNumSismosGlobal = intNumSismos
            'Matrices tridimencionales para el <Target Sprectrum> y <los Sísmos>
            bouArrayTargetSpecSismos = fucObtenerMatrizTargetSpectrum(charArray, intNumSismos, intNumPuntEspect)

            'Array undimencional para los registros sísmicos, dentro del ciclo se redincionan
            bouArraySismos = fucObtenerMatrizSismos(charArray, intNumSismos)
        End Sub
#End Region

#Region "GenerarGraficasDinamicamente"
        ''' <summary>
        ''' Remueve y agrega dinamicamente el control de usuario "ctrlGraficSismos" 
        ''' en un PlaceHolder, Actualizando estos controles cada vez que se recarga 
        ''' la pagina.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub subAddctrlGraficSismos()
            Me.phlWcvSismo.Controls.Remove(ctrlGrafcSismo)
            ctrlGrafcSismo = New ASP.virtuallabis_experimentos_laboratorios_h_simulation_simuquake_modulografcsismo_ctrlgraficsismos_ascx
            Me.phlWcvSismo.Controls.Add(ctrlGrafcSismo)
            ctrlGrafcSismo.subConstruirGraficas(bouArraySismos)
        End Sub

        ''' <summary>
        ''' Remueve y agrega dinamicamente el control de usuario "ctrlgraficaceldespspectral" 
        ''' en un PlaceHolder, Actualizando estos controles cada vez que se recarga 
        ''' la pagina.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub subAddctrlGraficAcelDespSpectral()
            'Agrega la Gráfica "ACELERACION ESPECTRAL"
            Me.phlAcelerEspectral.Controls.Remove(ctrlGraficAcelDespSpectral)
            ctrlGraficAcelDespSpectral = New ASP.virtuallabis_experimentos_laboratorios_h_simulation_simuquake_modulografcsismo_ctrlgraficaceldespspectral_ascx
            Me.phlAcelerEspectral.Controls.Add(ctrlGraficAcelDespSpectral)
            ctrlGraficAcelDespSpectral.subConstruirGraficas(bouArrayTargetSpecSismos, 1)
            'Agrega la Gráfica "DESPLAZAMIENTO ESPECTRAL"
            Me.phlDesplazEspectral.Controls.Remove(ctrlGraficAcelDespSpectral)
            ctrlGraficAcelDespSpectral = New ASP.virtuallabis_experimentos_laboratorios_h_simulation_simuquake_modulografcsismo_ctrlgraficaceldespspectral_ascx
            Me.phlDesplazEspectral.Controls.Add(ctrlGraficAcelDespSpectral)
            ctrlGraficAcelDespSpectral.subConstruirGraficas(bouArrayTargetSpecSismos, 2)
        End Sub

        ''' <summary>
        ''' Busca el archivo de texto "Respuesta de simulacion real" = "fupSismoEntrada"
        ''' En la ruta donde el Servicio lo copio como resultado de la ejecucion Distribuida.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subBuscarArchivoRespuestaReal()
            Dim strMensaje As String = ""
            bolBanderaFileSismo = False
         
            'Valida que se haya seleccionado un archivo en el control fileupload 
            'If fupSismoEntrada.HasFile Then
            If My.Computer.FileSystem.FileExists(strPathFilesSimuQuakeFileOut) Then
                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo(strPathFilesSimuQuakeFileOut)
                strNombreFileOut = infoReader.Name()
                Dim fileLen As Integer
                fileLen = infoReader.Length
                ReDim bytFileIn(fileLen)
                bytFileIn = My.Computer.FileSystem.ReadAllBytes(strPathFilesSimuQuakeFileOut)
                strMensaje = "File uploaded to VLEE server. <br> For view the charts Clip in VIEW CHART button"
                Me.fupSismoEntrada.Enabled = False
                Me.cmdSismoEntrada.Enabled = False
                Me.cmdVerGrafc.Enabled = True
                bolBanderaFileSismo = True
            Else
                strMensaje = "File NO Existe!."
                bolBanderaFileSismo = False
            End If
            Me.lblMensajes.Text = strMensaje
        End Sub

        ''' <summary>
        ''' Valida y carga el archivo de texto "Respuesta de simulacion real" = "fupSismoEntrada"
        ''' y muetra mensajes personalizados dependiento de error generado
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCargarArchivoRespuestaReal()
            Dim strMensaje As String = ""
            bolBanderaFileSismo = False
            'Valida que se haya seleccionado un archivo en el control fileupload 
            If fupSismoEntrada.HasFile Then
                Dim sFileType As String
                sFileType = System.IO.Path.GetExtension(fupSismoEntrada.FileName) 'Obtiene la extención del archivo a cargar
                strNombreFileOut = fupSismoEntrada.FileName
                sFileType = sFileType.ToLower()
                If (sFileType = ".txt") Then
                    Dim fileLen As Integer
                    Dim myStream As System.IO.Stream
                    fileLen = Me.fupSismoEntrada.PostedFile.ContentLength
                    ReDim bytFileIn(fileLen)
                    myStream = Me.fupSismoEntrada.FileContent
                    myStream.Read(bytFileIn, 0, fileLen)
                    strMensaje = "File uploaded to VLEE server. <br> For view the charts Clip in VIEW CHART button"
                    Me.fupSismoEntrada.Enabled = False
                    Me.cmdSismoEntrada.Enabled = False
                    Me.cmdVerGrafc.Enabled = True
                    bolBanderaFileSismo = True
                Else
                    strMensaje = "Not file allowed!."
                    bolBanderaFileSismo = False
                End If
            Else
                strMensaje = "Select one file to upload."
                bolBanderaFileSismo = False
            End If
            Me.lblMensajes.Text = strMensaje
        End Sub

        ''' <summary>
        ''' Parametriza, configura, ahiera y muestra en la pagina las graficas generadas
        ''' CUANDO EXISTE UN REDIRECIONAMIENTO DESDE LA PAGINA "wfSIMUQUAKE.aspx"
        ''' Metodo que grafica los resultados para el caso de Redireccionamiento
        ''' desde la pagina "wfSIMUQUAKE.aspx"
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub subVerGrafcRedirect()
            strNomSismo = Request.Params("nomSismo") 'Nombre que se le asigna al archivo al momento de descargalo
            strUsername = Request.Params("username")
            strPathFilesSimuQuakeFileOut = objConst.strPathFilesOUTSimuQuake & strUsername & "_simuquakeout.txt"
            subBuscarArchivoRespuestaReal()
            Try
                If bolBanderaFileSismo Then
                    subObtenerMatrizesDoubles_ArrayByt(bytFileIn)
                    subAddctrlGraficSismos()
                    subAddctrlGraficAcelDespSpectral()
                    boolIndicador = True
                    Me.lblMensajes.Text = Nothing
                    Dim int As Integer = (Session("intTime") * 5) / 60
                    Dim intMinutos As Integer = Math.Truncate((Session("intTime") * 5) / 60)
                    Dim intSegundos As Integer = (Session("intTime") * 5) - (60 * intMinutos)
                    Me.lblMensajesFiles.Text = "To download the results file  [" & strNomSismo & "] do CLICK"
                    Me.lblInformacion.Text = "The simulation takes approximately " & intMinutos & " minutes and " & intSegundos & " seconds"
                    Me.cmdVerGrafc.Enabled = False
                    Me.lbDownload.Visible = True
                    Me.imgDownload.Visible = True
                End If
            Catch ex As Exception
                Me.lblMensajes.Text = "Error in the result file"
            End Try

        End Sub
#End Region

#Region "Metodos Privados"
        ''' <summary>
        ''' Inicializa variables la primera vez que se carga la página
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subConstructor()
            objConst = New [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes
            intUserID = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id
            strUserMail = VirtualLabIS.Common.Global.Clases.Usuarios.User_Email
            strPathFilesSimuQuakeFileOut = objConst.strPathFilesOUTSimuQuake & strUsername & "_simuquakeout.txt"
            strPathFilesSimuQuake = objConst.strPathFilesSimuQuake
        End Sub
#End Region

#Region "Eventos Protegidos"
        ''' <summary>
        ''' Verifica si es la primera vez que se carga la página para inicializar todos los controles:
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Request.IsAuthenticated = True Then
                '------------------------------------------------------------------------
                'Artificio: 
                'Al aherir las graficas WebChartView dinamicamente, el metodo "Page_Load" 
                'vuelve a cargarse y se debe volver a construir las Graficas
                If (boolIndicador And bolBanderaFileSismo) Then
                    subAddctrlGraficSismos()
                    subAddctrlGraficAcelDespSpectral()
                    'If Not boolIndPage Then subAddctrlGraficAcelDespSpectral()
                End If
                '------------------------------------------------------------------------

                If Not Page.IsPostBack Then
                    '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                    'subCargarValoresControles_ES_EU()
                    subEstablecerPropiedadesCtrl()
                    subConstructor()
                    If Not CBool(Me.hiddIndicador.Value) Then
                        Me.phlWcvSismo.Controls.Clear()
                        Me.phlAcelerEspectral.Controls.Clear()
                        Me.phlDesplazEspectral.Controls.Clear()
                        bolBanderaFileSismo = False
                        boolIndicador = False
                    End If
                    'Si este pagina es llamado desde la pagina <wfSIMUQUAKE.aspx>
                    'Inicializa la variable <boolIndPage> para cargar directamente
                    'el archivo de entrada.
                    Try
                        boolIndPage = Request.Params("boolIndPage")
                    Catch ex As Exception
                        boolIndPage = False
                    End Try
                    If boolIndPage Then
                        subVerGrafcRedirect()
                    End If
                End If
            Else
                getIdioma = Request.Params("idioma")
                Response.BufferOutput = True
                Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
           End If
        End Sub

        ''' <summary>
        ''' Carga el archivo Sismico de entrada
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdSismoEntrada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSismoEntrada.Click
            subCargarArchivoRespuestaReal()
        End Sub

        ''' <summary>
        ''' Parametriza, configura, ahiera y muestra en la pagina las graficas generadas
        ''' CUANDO SE CARGA UN ARCHIVO DESDE ESTA INTERFACE
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdVerGrafc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerGrafc.Click
            Try
                If bolBanderaFileSismo Then
                    subObtenerMatrizesDoubles_ArrayByt(bytFileIn)
                    subAddctrlGraficSismos()
                    subAddctrlGraficAcelDespSpectral()
                    boolIndicador = True
                    Me.lblMensajes.Text = Nothing
                    Me.cmdVerGrafc.Enabled = False
                    Me.lbDownload.Visible = False
                    Me.imgDownload.Visible = False
                End If
            Catch ex As Exception
                Me.lblMensajes.Text = "Error in the result file"
            End Try
        End Sub

        ''' <summary>
        ''' Evento de Clip para descargar el archivo de texto de resultados.
        ''' Se envian parámetros como: el nombre de la carpeta, nombre del archivo
        ''' Fisico y nombre asignado del archivo de salida al instante de descargar.
        ''' la página ASPX que permite esta descarga y la que resive los parametros es:
        ''' /VLEE/downloadFiles.aspx
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbDownload.Click
            Page.Response.Redirect("~/downloadFiles.aspx?folder=" & "simuquake" & _
                                   "&file=" & strNombreFileOut & "&nombre=" & strNomSismo & ".txt")
        End Sub
#End Region


    End Class
End Namespace
