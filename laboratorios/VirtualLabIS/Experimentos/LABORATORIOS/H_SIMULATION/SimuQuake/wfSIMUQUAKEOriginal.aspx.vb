Imports System.IO
Imports Microsoft.VisualBasic

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
    Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_SimuQuake_wfSIMUQUAKE
        Inherits System.Web.UI.Page

#Region "VariablesGlobales"
        'variables del Usuario
        Private Shared intUserID As Integer
        Private Shared strUsername As String
        Private Shared strUserMail As String

        'Objetos
        Private Shared objFacade As Facade.VirtualLabIS.Facade.Cicha.ICicha
        Private objConst As [Global].Clases.VirtualLabIS.Common.Global.Clases.Constantes

        Private Shared bytIngRespuestaReal() As Byte
        Private Shared bytIngArchivoTCL() As Byte

        Private Shared bolBanderaIngRespuestaReal As Boolean = False
        Private Shared bolIngArchivoTCL As Boolean = False

        Private Shared strIdioma As String
        Private Shared getIdioma As String
        Private Shared booIndicador As Boolean
        Private Shared strPathFilesOUTSimuQuake As String
        Private Shared strFecha As String
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
        ''' Agrega eventos a los TextBox, estos codificados en JavaScript del lado del Cliente
        ''' para forzar al usuario a que ingrese solo valores numericos estos TextBox
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEstablecerAtributosAControles()
            'Parametros de la Simulacion Sismica
            Me.txtNumSimulaciones.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtDuracion.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumPuntEspectrales.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtTiempo1.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtTiempo2.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtPeriodoInicial.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtPeriodoFinal.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")

            'Parametros de la Espectro Target
            Me.txtFactorA.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtFactorV.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtAceleracionPerdCorto.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtAceleracionPerdPrim.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtPeriodoEsquina.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
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
            Session("strUsername") = MyBase.User.Identity.Name
            strUserMail = VirtualLabIS.Common.Global.Clases.Usuarios.User_Email
            Session("NomSismo") = Nothing
            Me.hiddIndicador.Value = 0
            strPathFilesSimuQuake = objConst.strPathFilesSimuQuake
            strPathFilesOUTSimuQuake = objConst.strPathFilesOUTSimuQuake
            booIndicador = True
            Session("intTime") = 0
            subEstablecerAtributosAControles()
        End Sub

        ''' <summary>
        ''' Habilita El control "timeSimular" para que inicie el "timeSimular_Tick" 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subActivarIndicador()
            Me.timeSimular.Enabled = True
            Me.timeSimular.Interval = 5000
            Me.imgIndicador.Visible = True
        End Sub

        ''' <summary>
        ''' InHabilita El control "timeSimular" y deja de llamar al "subGetFile"
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subDesActicarIndicador()
            Me.timeSimular.Enabled = False
            Me.imgIndicador.Visible = False
        End Sub

        ''' <summary>
        ''' Busca el archivo de resultados depositado por el Servicio en el servidor
        ''' Y si lo encuentra redirecciona a la página "wfSIMUQUAKE_VIEWER.aspx" para graficas estos resultados
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subGetFile()
            'Cuando Session("intTime") = 240 habran transcurrido 20 minutos
            Session("intTime") += 1
            strFecha = DateTime.Now.ToString("h:mm:ss")
            'Me.lblMensajes.Text = "Time: " & Session("intTime") & " y HORA [" & strFecha & "]"
            If (Session("intTime") < 240) Then
                'Me.lblMensajes.Text = strPathFilesOUTSimuQuake & Session("strUsername")
                If My.Computer.FileSystem.FileExists(strPathFilesOUTSimuQuake & Session("strUsername") & "_simuquakeout.txt") Then
                    subDesActicarIndicador()
                    Response.Redirect("~/VirtualLabIS/Experimentos/LABORATORIOS/H_SIMULATION/SimuQuake/wfSIMUQUAKE_VIEWER.aspx?idioma=es-ES&boolIndPage=true&nomSismo=" & Session("NomSismo") & "&username=" & Session("strUsername"))
                End If
            Else
                Me.lblMensajes.Text = "Sorry, the simulation can take more time. <br> The results will be sent to your mail"
                'Me.lblMensajes.Text = "Sorry Time: " & Session("intTime") & " y HORA [" & strFecha & "]"
                subDesActicarIndicador()
            End If
        End Sub
#End Region

#Region "Eventos Protegidos"
        ''' <summary>
        ''' Verifica si es la primera vez que se carga la página para inicializar todos los controles:
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Context.Request.IsAuthenticated = True Then
            If Not Page.IsPostBack Then
                    objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
                    '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                    'subCargarValoresControles_ES_EU()
                    subConstructor()
                End If
            'subSetIdiomaControles()
            'Else
            '    getIdioma = Request.Params("idioma")
            '    Response.BufferOutput = True
            '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
            'End If
        End Sub

        ''' <summary>
        ''' Se escribe el archivo de resultados e inicializa la inspección constante
        ''' en espera de que se deposite un archivo de resultados en el servidor
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdSimular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSimular.Click
            Session("strUsername") = MyBase.User.Identity.Name
            Me.cmdSimular.Enabled = False
            Me.lblMensajes.Text = "Run Simulate, wait please"
            subWriteFile_simuquakein(intUserID, Session("strUsername"), strUserMail)
            subActivarIndicador()
        End Sub

        ''' <summary>
        ''' Inicializa la inspección contante en espera de que el computación
        ''' disctribuida deposite en el servidor un archivo de resultados
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub timeSimular_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            subGetFile()
        End Sub
#End Region

#Region "MetodosBR simuquake"
        Private Shared strPathFilesSimuQuake As String
        Private Shared strPathFilesIn As String

        ''' <summary>
        ''' Escribe el archivo de entrada de datos.
        ''' </summary>
        ''' <param name="intUserID"></param>
        ''' <param name="strUserName"></param>
        ''' <param name="strUserMail"></param>
        ''' <remarks></remarks>
        Public Sub subWriteFile_simuquakein(ByVal intUserID As Integer, ByVal strUserName As String, ByVal strUserMail As String)
            Dim strFecha As String = Format(DateTime.Now, "dd-MM-yyyy_hh-mm-sstt")
            If My.Computer.FileSystem.FileExists(strPathFilesOUTSimuQuake & Session("strUsername") & "_simuquakeout.txt") Then
                My.Computer.FileSystem.DeleteFile(strPathFilesOUTSimuQuake & Session("strUsername") & "_simuquakeout.txt")
            End If
            Using archivoIn As StreamWriter = New StreamWriter(strPathFilesSimuQuake & strFecha & "_simuquakein.txt")
                'Nombre del experimento Virtual
                archivoIn.Write("simuquake" & Chr(13) & Chr(10))
                'Información del Usuario
                archivoIn.Write("INFORMATION_USER" & Chr(13) & Chr(10))
                archivoIn.Write("id: " & intUserID & Chr(13) & Chr(10))
                archivoIn.Write("name: " & strUserName & Chr(13) & Chr(10))
                archivoIn.Write("email: " & strUserMail & Chr(13) & Chr(10))
                archivoIn.Write("date created: " & strFecha & Chr(13) & Chr(10))
                'Parametros para la Simulación Sísmica
                Session("NomSismo") = Me.txtNomSismo.Text
                archivoIn.Write(Me.txtNomSismo.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtNumSimulaciones.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtDuracion.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtNumPuntEspectrales.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtTiempo1.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtTiempo2.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtPeriodoInicial.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtPeriodoFinal.Text & Chr(13) & Chr(10))
                'Parametros del Espectro Target
                archivoIn.Write(Me.txtFactorA.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtFactorV.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtAceleracionPerdCorto.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtAceleracionPerdPrim.Text & Chr(13) & Chr(10))
                archivoIn.Write(Me.txtPeriodoEsquina.Text & Chr(13) & Chr(10))
                archivoIn.Close()
            End Using
        End Sub
#End Region
    End Class


End Namespace

