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
    Partial Class VirtualLabIS_Experimentos_CICHA_wfExperimentoCICHA
        Inherits System.Web.UI.Page

#Region "VariablesGlobales"
        'Objetos
        Private Shared ctrlSpecimenCircular As ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimencircular_ascx
        Private Shared ctrlSpecimenRectangular As ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimenrectangular_ascx
        Private Shared objFacade As Facade.VirtualLabIS.Facade.Cicha.ICicha
        Private Shared dsCICHA As DTO.dsCicha
        Private Shared dtCICHA_ESPC_CIR As DTO.dsCicha.CICHA_ESPC_CIRDataTable
        Private Shared drCICHA_ESPC_CIR As DTO.dsCicha.CICHA_ESPC_CIRRow
        Private Shared dtCICHA_ESPC_REC As DTO.dsCicha.CICHA_ESPC_RECDataTable
        Private Shared drCICHA_ESPC_REC As DTO.dsCicha.CICHA_ESPC_RECRow
        'Dim dataReader As IDataReader 'DataReader para CICHA_ESPC_CIR u CICHA_ESPC_REC
        'Dim dread_CICHA_ESPC_CIR As IDataReader
        'Variables
        Private Shared bytIngRespuestaReal() As Byte
        Private Shared bytIngArchivoTCL() As Byte

        Private Shared bolBanderaIngRespuestaReal As Boolean = False
        Private Shared bolIngArchivoTCL As Boolean = False

        Shared RutaGeneralArchivosResultados As String = "C:/Inetpub/wwwroot/VLEE/Temp/Exp/Cicha/"
        Private Shared strIdioma As String

        Public Shared getIdioma As String
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
            Else
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
                Exit Sub
            End If
        End Sub

        ''' <summary>
        ''' Procedimiento para establecer el idioma a los controles
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub subSetIdiomaControles()
            Me.imgRutaTitulo.ImageUrl = GetLocalResourceObject("imgRutaTitulo.Text").ToString()
            Me.lblTituloExp.Text = GetLocalResourceObject("lblTituloExp.Text").ToString()
            Me.lblSelectTest.Text = GetLocalResourceObject("lblSelectTest.Text").ToString()
            Me.lblTipoSeccion.Text = GetLocalResourceObject("lblTipoSeccion.Text").ToString()
            Me.lblTestSpec.Text = GetLocalResourceObject("lblTestSpec.Text").ToString()
            Me.cmdIrExp.Text = GetLocalResourceObject("cmdIrExp.Text").ToString()
            Me.cmdNuevoSpecimen.Text = GetLocalResourceObject("cmdNuevoSpecimen.Text").ToString()
        End Sub
#End Region


#Region "Gestiona Global para <ctrlSpecimenCircular> y <ctrlSpecimenRectangular>"

        ''' <summary>
        ''' Inicializa los controles para la edicion e ingreso de valores del nuevo especimen
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subNuevoSpecimen()
            'Control Cargar archivos de simulación.
            Me.lblFiles.Visible = True
            Me.lblIngRespuestaReal.Visible = True
            Me.fupIngRespuestaReal.Visible = True
            Me.cmdIngRespuestaReal.Visible = True
            Me.lblIngRespuestaRealEstado.Visible = True
            Me.lblIngArchivoTCL.Visible = True
            Me.fupIngArchivoTCL.Visible = True
            Me.cmdIngArchivoTCL.Visible = True
            Me.lblIngArchivoTCLEstado.Visible = True
            Me.cmdEliminarSpecimen.Visible = True
            Me.cmdGuardarSpecimen.Visible = True
            Me.tblFiles.Visible = True
            'Info del Especimen, se apagna por que no se ingresan estos datos para el new Specimen
            Me.lblTestSpec.Visible = False
            Me.ddlSpecimen.Visible = False
            Me.cmdIrExp.Enabled = False
            If Me.radCircular.Checked Then
                'Crea la referencia para el control de Usuario <ctrlSpecimenCircular>
                ctrlSpecimenCircular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimencircular_ascx
                Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenCircular)
                'Me.phlCotrolesSpecimenes.Controls.Add(New LiteralControl("<hr style=""position: static"" />"))
                ctrlSpecimenCircular.setHabilitarCtrl = True
                Me.dtCICHA_ESPC_CIR = New DTO.dsCicha.CICHA_ESPC_CIRDataTable
                Session("dtCicha_SPEC_CIR") = Me.dtCICHA_ESPC_CIR
            Else
                If Me.radRectangular.Checked Then
                    ctrlSpecimenRectangular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimenrectangular_ascx
                    Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenRectangular)
                    'Me.phlCotrolesSpecimenes.Controls.Add(New LiteralControl("<hr style=""position: static"" />"))
                    ctrlSpecimenRectangular.setHabilitarCtrl = True
                    Me.dtCICHA_ESPC_REC = New DTO.dsCicha.CICHA_ESPC_RECDataTable
                    Session("dtCicha_SPEC_REC") = Me.dtCICHA_ESPC_REC
                End If
            End If
        End Sub

        ''' <summary>
        ''' Cuandos los especimentes se muestrar para solo lectura, los controles que descargan 
        ''' los archivos se esconden.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subApagarControlesFileLoad()
            'Control Cargar archivos de simulación.
            Me.lblIngRespuestaReal.Visible = False
            Me.fupIngRespuestaReal.Visible = False
            Me.cmdIngRespuestaReal.Visible = False
            Me.lblIngRespuestaRealEstado.Visible = False
            Me.lblIngArchivoTCL.Visible = False
            Me.fupIngArchivoTCL.Visible = False
            Me.cmdIngArchivoTCL.Visible = False
            Me.lblIngArchivoTCLEstado.Visible = False
            Me.tblFiles.Visible = False
        End Sub

        ''' <summary>
        ''' cada vez que se carga la pagina, los botones se desactivara. La activacion de estos
        ''' botones depende de los eventos que se vayan generando en los mismos.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subActivarDesBotones()
            subApagarControlesFileLoad()
            Me.lblIngRespuestaRealEstado.Text = Nothing
            Me.lblMensajeError2.Text = Nothing
            Me.lblIngArchivoTCLEstado.Text = Nothing
            Me.cmdNuevoSpecimen.Enabled = False
            Me.cmdEliminarSpecimen.Enabled = False
            Me.cmdGuardarSpecimen.Enabled = False
            Me.cmdIrExp.Enabled = False
            Me.cmdEliminarSpecimen.Visible = False
            Me.cmdGuardarSpecimen.Visible = False
        End Sub

        ''' <summary>
        ''' Devuelve verdadero si los archivos "Respuesta Real.txt" y "ArchivoTCL" de cargaron correctamente
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fucCargarArchivosCorrecto() As Boolean
            Dim bolBandera As Boolean = False
            If (bolIngArchivoTCL And bolBanderaIngRespuestaReal) Then
                bolBandera = True
            End If
            Return bolBandera
        End Function


        ''' <summary>
        ''' Valida y carga el archivo de texto "Respuesta de simulacion real" = "fupIngRespuestaReal"
        ''' y muetra mensajes personalizados dependiento de error generado
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCargarArchivoRespuestaReal()
            Dim strMensaje As String = ""
            bolBanderaIngRespuestaReal = False
            'Valida que se haya seleccionado un archivo en el control fileupload 
            If fupIngRespuestaReal.HasFile Then
                Dim sFileType As String
                sFileType = System.IO.Path.GetExtension(fupIngRespuestaReal.FileName) 'Obtiene la extención del archivo a cargar
                sFileType = sFileType.ToLower()
                If (sFileType = ".txt") Then
                    Dim fileLen As Integer
                    Dim myStream As System.IO.Stream
                    fileLen = Me.fupIngRespuestaReal.PostedFile.ContentLength
                    ReDim bytIngRespuestaReal(fileLen)
                    myStream = Me.fupIngRespuestaReal.FileContent
                    myStream.Read(bytIngRespuestaReal, 0, fileLen)
                    strMensaje = "File uploaded to VLEE server."
                    bolBanderaIngRespuestaReal = True
                Else
                    strMensaje = "Not file allowed!."
                    bolBanderaIngRespuestaReal = False
                End If
            Else
                strMensaje = "Select one file to upload."
                bolBanderaIngRespuestaReal = False
            End If
            Me.lblIngRespuestaRealEstado.Text = strMensaje
        End Sub


        ''' <summary>
        ''' Valida y caraga el "Archivo de Código TCL" = "fupIngArchivoTCL"
        ''' muestra mensajes personalizados dependiendo del error generado.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subCargarArchivoSimulacionTCL()
            Dim strMensaje As String = ""
            bolIngArchivoTCL = False
            'Valida que se haya seleccionado un archivo en el control fileupload 
            If fupIngArchivoTCL.HasFile Then
                Dim sFileType As String
                sFileType = System.IO.Path.GetExtension(fupIngArchivoTCL.FileName) 'Obtiene la extención del archivo a cargar
                sFileType = sFileType.ToLower()
                If (sFileType = ".tcl") Then
                    Dim fileLen As Integer
                    Dim myStream As System.IO.Stream
                    fileLen = Me.fupIngArchivoTCL.PostedFile.ContentLength
                    ReDim bytIngArchivoTCL(fileLen)
                    myStream = Me.fupIngArchivoTCL.FileContent
                    myStream.Read(bytIngArchivoTCL, 0, fileLen)
                    strMensaje = "File uploaded to VLEE server."
                    bolIngArchivoTCL = True
                Else
                    strMensaje = "Not file allowed!."
                    bolIngArchivoTCL = False
                End If
            Else
                strMensaje = "Select one file to upload."
                bolIngArchivoTCL = False
            End If
            Me.lblIngArchivoTCLEstado.Text = strMensaje
        End Sub

        ''' <summary>
        ''' Envia guardar en la DB los datos del especimen "Circular" ó "Circular"
        ''' segun se de el caso.
        ''' </summary>
        ''' <remarks></remarks>
        Sub subGuardarSpecimen()
            If Me.radCircular.Checked Then
                subGuardarSpecimenCir()
            Else
                If Me.radRectangular.Checked Then
                    subGuardarSpecimenRec()
                End If
            End If
        End Sub

        Private Sub subMostrarInfoSpecimen()
            If Me.radCircular.Checked Then
                subMostrarInfoSpecimenCircular()
            Else
                If Me.radRectangular.Checked Then
                    subMostrarInfoSpecimenRectangular()
                End If
            End If
        End Sub

        Private Sub subIrSetup()
            If Me.radCircular.Checked Then
                Response.Redirect("~/VirtualLabIS/Experimentos/CICHA/wfExperimentoCICHA_SETUP.aspx?idioma=" + strIdioma + "&especimen=Circular")
            Else
                If Me.radRectangular.Checked Then
                    Response.Redirect("~/VirtualLabIS/Experimentos/CICHA/wfExperimentoCICHA_SETUP.aspx?idioma=" + strIdioma + "&especimen=Rectangular")
                End If
            End If
        End Sub

#End Region

#Region "Metodos, Control de Usuario: <ctrlSpecimenCircular>"

        '''' <summary>
        '''' USANDO un DataReader Llena el Control DropDownList "ddlSpecimen" con los nombres de los 
        '''' especimenes de tipo circular
        '''' </summary>
        '''' <remarks></remarks>
        'Private Sub subLlenarListaNombreSpec()
        '    objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
        '    With objFacade
        '        dataReader = .subObtener_CICHA_ESPC_CIR_CICHA_ESPC_REC("CICHA_ESPC_CIR")
        '        Using dataReader
        '            While (dataReader.Read())
        '                Dim strNombreSpecDB = dataReader("CICHA_ESPC_CIR_NOMBRE").ToString()
        '                Dim intOrdenSpecDB = dataReader("CICHA_ESPC_CIR_NOMBRE").ToString()
        '                Me.ddlSpecimen.Items.Add(New ListItem(strNombreSpecDB, intOrdenSpecDB))
        '            End While
        '        End Using
        '    End With
        'End Sub

        ''' <summary>
        ''' Invia a GUARDAR el specimen circular nuevo ingresado validando 
        ''' de se han ingresado los archivos "RESPUESTA REAL" Y "TCL" correctamente
        ''' y mostrando mensajes de error personalisados.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subGuardarSpecimenCir()
            Dim strMensajeError As String = Nothing
            Try
                Dim intOrden As Integer = 0 'Orden del Specimen Circular
                Dim intCichaSpecCir_ID As Integer = 0 'ID del Specimen Circular
                Dim booIndicador As Boolean
                If (fucCargarArchivosCorrecto()) Then
                    dtCICHA_ESPC_CIR = Session("dtCicha_SPEC_CIR")
                    dtCICHA_ESPC_CIR.Clear()
                    drCICHA_ESPC_CIR = dtCICHA_ESPC_CIR.NewCICHA_ESPC_CIRRow
                    'Capturamos en el Data Table "dtCICHA_ESPC_CIR" los valores ingresados de este especimen desde el control de usuario
                    Session("dtCicha_SPEC_CIR") = ctrlSpecimenCircular.fucAsignarValoresControles(dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
                    dtCICHA_ESPC_CIR = Session("dtCicha_SPEC_CIR")
                    'Agregamos los archivos al Data Table "Especimen Circular"
                    drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_RESPUESTAREALColumn) = Me.bytIngRespuestaReal
                    drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_ARCHIVOTCLColumn) = Me.bytIngArchivoTCL
                    dtCICHA_ESPC_CIR.AddCICHA_ESPC_CIRRow(drCICHA_ESPC_CIR)
                    'objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
                    booIndicador = objFacade.AgregarCicha_Espc_Cir(intCichaSpecCir_ID, intOrden, dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
                    If booIndicador Then
                        strMensajeError = "Successful: Stored Specimen Circular # <" & intOrden & ">"
                    Else
                        strMensajeError = "Error"
                    End If
                Else
                    strMensajeError = "Error to load files"
                End If
            Catch ex As SqlClient.SqlException
                strMensajeError = ex.Message
            Catch ex As Exception
                strMensajeError = "Error to save data"
            End Try
            Me.lblMensajeError2.Text = strMensajeError
        End Sub

        ''' <summary>
        ''' Llena el Control DropDownList "ddlSpecimen" con los nombres de los 
        ''' especimenes de tipo circular
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subLlenarListaNombreSpecCir()
            Dim dsCICHA_AUX As System.Data.DataSet
            'objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
            dsCICHA = New DTO.dsCicha
            Me.ddlSpecimen.Items.Clear()
            Dim strNombreSpecDB = "<Select Item>"
            Dim intIDSpecDB = -1
            Me.ddlSpecimen.Items.Add(New ListItem(strNombreSpecDB, intIDSpecDB))
            With objFacade
                .subObtener_CICHA_ESPC_CIR(dsCICHA)
                dsCICHA_AUX = dsCICHA
                dtCICHA_ESPC_CIR = dsCICHA_AUX.Tables("CICHA_ESPC_CIR") ' New dsCicha.CICHA_ESPC_CIRDataTable ' dsCicha.CICHA_ESPC_CIRDataTable
                Session("dtCICHA_ESPC_CIR") = dtCICHA_ESPC_CIR 'Para enviar al Control de Usuario "ctrlSpecimenCircular" a mostrar los datos de esta tabla
                For Each drCICHA_ESPC_CIR In dtCICHA_ESPC_CIR.Rows
                    strNombreSpecDB = drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_NOMBREColumn.ColumnName)
                    intIDSpecDB = drCICHA_ESPC_CIR(dtCICHA_ESPC_CIR.CICHA_ESPC_CIR_IDColumn.ColumnName)
                    Me.ddlSpecimen.Items.Add(New ListItem(strNombreSpecDB, intIDSpecDB))
                Next
            End With
        End Sub

        ''' <summary>
        ''' Busca en el DataTable el especimen seleccionado con el CICHA_ESPC_CIR_ID y 
        ''' envia a adherir el Control de Usuario "ctrlSpecimenCircular" con estos datos.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub subMostrarInfoSpecimenCircular()
            Session("dtCICHA_ESPC_CIR") = dtCICHA_ESPC_CIR
            Session("drCICHA_ESPC_CIR") = dtCICHA_ESPC_CIR.FindByCICHA_ESPC_CIR_ID(Me.ddlSpecimen.SelectedValue)
            Me.lblTestSpec.Visible = True
            Me.ddlSpecimen.Visible = True
            Me.cmdIrExp.Enabled = True
            'Crea la referencia para el control de Usuario <ctrlSpecimenCircular>
            ctrlSpecimenCircular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimencircular_ascx
            Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenCircular)
            'Session("dtCicha_SPEC_CIR") = ctrlSpecimenCircular.fucAsignarValoresControles(dtCICHA_ESPC_CIR, drCICHA_ESPC_CIR)
            'ctrlSpecimenCircular.subMostrarInfoSpecimenCircular(Session("dtCICHA_ESPC_CIR"), drCICHA_ESPC_CIR_AUX)
            ctrlSpecimenCircular.subMostrarInfoSpecimenCircular(Session("dtCICHA_ESPC_CIR"), Session("drCICHA_ESPC_CIR"))
            ctrlSpecimenCircular.setHabilitarCtrl = False
        End Sub

#End Region

#Region "Metodos, Control de Usuario: <ctrlSpecimenRectangular>"
        ''' <summary>
        ''' Invia a GUARDAR el specimen circular nuevo ingresado validando 
        ''' de se han ingresado los archivos "RESPUESTA REAL" Y "TCL" correctamente
        ''' y mostrando mensajes de error personalisados.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subGuardarSpecimenRec()
            Dim strMensajeError As String = Nothing
            Try
                Dim intOrden As Integer = 0 'Orden del Specimen Circular
                Dim intCichaSpecRec_ID As Integer = 0 'ID del Specimen Circular
                Dim booIndicador As Boolean
                If (fucCargarArchivosCorrecto()) Then
                    dtCICHA_ESPC_REC = Session("dtCicha_SPEC_REC")
                    dtCICHA_ESPC_REC.Clear()
                    drCICHA_ESPC_REC = dtCICHA_ESPC_REC.NewCICHA_ESPC_RECRow
                    'Capturamos en el Data Table "dtCICHA_ESPC_CIR" los valores ingresados de este especimen desde el control de usuario
                    Session("dtCicha_SPEC_REC") = ctrlSpecimenRectangular.fucAsignarValoresControles(dtCICHA_ESPC_REC, drCICHA_ESPC_REC)
                    'Session("dtCicha_SPEC_REC") y Session("dtCicha_SPEC_REC") Se usarán para mostrar los datos en la página
                    'del experimento
                    dtCICHA_ESPC_REC = Session("dtCicha_SPEC_REC")
                    'Agregamos los archivos al Data Table "Especimen Circular"
                    drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RESPUESTAREALColumn) = Me.bytIngRespuestaReal
                    drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ARCHIVOTCLColumn) = Me.bytIngArchivoTCL
                    dtCICHA_ESPC_REC.AddCICHA_ESPC_RECRow(drCICHA_ESPC_REC)
                    'objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
                    booIndicador = objFacade.funCicha_AgregarCicha_Spec_Rec(intCichaSpecRec_ID, intOrden, dtCICHA_ESPC_REC, drCICHA_ESPC_REC)
                    If booIndicador Then
                        strMensajeError = "Successful: Stored Specimen Circular # <" & intOrden & ">"
                    Else
                        strMensajeError = "Error"
                    End If
                Else
                    strMensajeError = "Error to load files"
                End If
            Catch ex As SqlClient.SqlException
                strMensajeError = ex.Message
            Catch ex As Exception
                strMensajeError = "Error to save data"
            End Try
            Me.lblMensajeError2.Text = strMensajeError
        End Sub

        ''' <summary>
        ''' Llena el Control DropDownList "ddlSpecimen" con los nombres de los 
        ''' especimenes de tipo circular
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subLlenarListaNombreSpecRec()
            Dim dsCICHA_AUX As System.Data.DataSet
            'objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
            dsCICHA = New DTO.dsCicha
            Me.ddlSpecimen.Items.Clear()
            Dim strNombreSpecDB = "<Select Item>"
            Dim intIDSpecDB = -1
            Me.ddlSpecimen.Items.Add(New ListItem(strNombreSpecDB, intIDSpecDB))
            With objFacade
                .subCicha_ObtenerDataSpecRec(dsCICHA)
                dsCICHA_AUX = dsCICHA
                dtCICHA_ESPC_REC = dsCICHA_AUX.Tables("CICHA_ESPC_REC")
                Session("dtCICHA_ESPC_REC") = dtCICHA_ESPC_REC 'Para enviar al Control de Usuario "ctrlSpecimenRectangular" a mostrar los datos de esta tabla
                For Each drCICHA_ESPC_REC In dtCICHA_ESPC_REC.Rows
                    strNombreSpecDB = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NOMBREColumn.ColumnName)
                    intIDSpecDB = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_IDColumn.ColumnName)
                    Me.ddlSpecimen.Items.Add(New ListItem(strNombreSpecDB, intIDSpecDB))
                Next
            End With
        End Sub

        ''' <summary>
        ''' Busca en el DataTable el especimen seleccionado con el CICHA_ESPC_REC_ID y 
        ''' envia a adherir el Control de Usuario "ctrlSpecimenRectangular" con estos datos.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub subMostrarInfoSpecimenRectangular()
            Session("dtCICHA_ESPC_REC") = dtCICHA_ESPC_REC
            Session("drCICHA_ESPC_REC") = dtCICHA_ESPC_REC.FindByCICHA_ESPC_REC_ID(Me.ddlSpecimen.SelectedValue)
            Me.lblTestSpec.Visible = True
            Me.ddlSpecimen.Visible = True
            Me.cmdIrExp.Enabled = True
            'Crea la referencia para el control de Usuario <ctrlSpecimenCircular>
            ctrlSpecimenRectangular = New ASP.virtuallabis_experimentos_cicha_modulos_ctrlspecimenrectangular_ascx
            Me.phlCotrolesSpecimenes.Controls.Add(ctrlSpecimenRectangular)
            ctrlSpecimenRectangular.subMostrarInfoSpecimenRectangular(dtCICHA_ESPC_REC, Session("drCICHA_ESPC_REC"))
            ctrlSpecimenRectangular.setHabilitarCtrl = False
        End Sub

#End Region

#Region "Eventos Protegidos"

        ''' <summary>
        ''' Verifica si es la primera vez que se carga la página para inicializar todos los controles:
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Request.IsAuthenticated = True Then
            '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
            subActivarDesBotones()
                If Not Page.IsPostBack Then
                    objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
                    '-------- INICIALIZACION DE CONTROLES Y VARIABLES --------
                    'subCargarValoresControles_ES_EU()
                    Me.hiddIndicador.Value = 0
                Else
                    If Me.hiddIndicador.Value = 1 Then 'Se hizo clip en el boton NEW
                        If radCircular.Checked Then
                            subNuevoSpecimen()
                        Else
                            If radRectangular.Checked Then
                                subNuevoSpecimen()
                            End If
                        End If
                        Me.cmdGuardarSpecimen.Enabled = True
                    End If
                End If
                subSetIdiomaControles()
            'Else
            '    getIdioma = Request.Params("idioma")
            '    Response.BufferOutput = True
            '    Response.Redirect("~/VirtualLabIS/Varios/Paginas/RedirectPage.aspx?idioma=" & getIdioma)
            'End If
        End Sub

        Protected Sub cmdIrExp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIrExp.Click
            subIrSetup()
        End Sub

        ''' <summary>
        ''' Evento generado cuando se selecciona un Especimen de tipo CIRCULAR
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub radCircular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCircular.CheckedChanged
            Me.phlCotrolesSpecimenes.Controls.Clear()
            subActivarDesBotones()
            subLlenarListaNombreSpecCir()
            Me.hiddIndicador.Value = 0 'Para no mostrar los controles de Usuario <ctrlSpecimenCircular>, <ctrlSpecimenRectangular>
            Me.cmdNuevoSpecimen.Enabled = True
        End Sub

        ''' <summary>
        ''' Evento generado cuando se selecciona un Especimen de tipo RECTANGULAR
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub radRectangular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radRectangular.CheckedChanged
            Me.phlCotrolesSpecimenes.Controls.Clear()
            subActivarDesBotones()
            subLlenarListaNombreSpecRec()
            Me.hiddIndicador.Value = 0 'Para no mostrar los controles de Usuario <ctrlSpecimenCircular>, <ctrlSpecimenRectangular>
            Me.cmdNuevoSpecimen.Enabled = True
        End Sub

        ''' <summary>
        ''' Evento generado cuando se desea ingresar un nuevo registro de especimen
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdNuevoSpecimen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevoSpecimen.Click
            subNuevoSpecimen()
            Me.hiddIndicador.Value = 1 'Para prender <cmdGuardarSpecimen> 
            Me.cmdGuardarSpecimen.Enabled = True
        End Sub


        ''' <summary>
        ''' Evento generado para almecenar el registro del especimen en la DB
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdGuardarSpecimen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardarSpecimen.Click
            subGuardarSpecimen()
        End Sub

        ''' <summary>
        ''' Evento generado para cagar a memoria el "Archivo de simulacion REAL"
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdIngRespuestaReal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIngRespuestaReal.Click
            subCargarArchivoRespuestaReal()
            Me.cmdGuardarSpecimen.Enabled = True
        End Sub

        ''' <summary>
        ''' Evento generado para cargar a memoria el "Archivo de Codigo TCL"
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub cmdIngArchivoTCL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIngArchivoTCL.Click
            subCargarArchivoSimulacionTCL()
            Me.cmdGuardarSpecimen.Enabled = True
        End Sub

        ''' <summary>
        ''' Evento generado al cambiar el texto de la lista de nombres de Especimenes
        ''' tipo circular.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub ddlSpecimen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSpecimen.SelectedIndexChanged
            subMostrarInfoSpecimen()
        End Sub

#End Region

    End Class
End Namespace

