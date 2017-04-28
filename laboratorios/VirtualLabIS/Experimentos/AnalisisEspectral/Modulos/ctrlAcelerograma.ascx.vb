Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

Partial Class Modulos_ctrlAcelerograma
    Inherits System.Web.UI.UserControl

#Region "Constantes"
    Dim arrTextoErrores(,) As String = {{"¡El archivo tiene valores erroneos!. El archivo no ha sido cargado.", _
                                         "Datos insuficientes en el arhivo. El archivo no ha sido cargado!", _
                                         "Archivo cargado correctamente.", _
                                         "Ingrese la duración y el paso del acelerograma.", _
                                         "Seleccione un archivo para cargar.", _
                                         "¡Archivo no permitido!"}, _
                                        {"The file has erroneous values!. The file has not been loaded.", _
                                         "Isuficient data in the file", _
                                         "File loaded correctly.", _
                                         "Enter the duration and the step of the acceleration record.", _
                                         "Select a file to load.", _
                                         "This file isn't allowed load."}}

#End Region
#Region "Variables Globales"
    ' Dim savePath As String = "c:\temp\uploads\" 'Ejemplo de ruta absoluta....

    'Almacena la ruta donde se almacenara el archivo...
    Dim PathFileSave As String = Nothing

    'Almacena el nombre del archivo en sentido de las X
    Shared strFileSismoSentidoX As String = Nothing

    'Variables para almacenar los nombres de los archivos sismicos
    Shared strSismoX As String = Nothing
    Shared strSismoY As String = Nothing

    Shared strPathCompleto As String

    'Almacena los datos del modulo
    Shared strDatosEntrada(2) As String

    'Arreglo para almacenar los datos del sismo.
    Shared arrDatosInputFile() As Object
    
    'Variable que almacena el idioma de la pagina
    Dim idIdioma As Integer
#End Region

#Region "PROPIEDADES"
    
    Public ReadOnly Property getDatosIngresados() As String()
        Get
            strDatosEntrada(0) = tbDuracion.Text
            strDatosEntrada(1) = tbPaso.Text
            strDatosEntrada(2) = tbFactor.Text

            Return strDatosEntrada
        End Get
    End Property

    Public ReadOnly Property verEstadoControles() As Boolean
        Get
            Return functValidarControles()
        End Get
    End Property

    'Verifica que todos los campos de este modulo hayan sido ingresados por el usuario.
    Private Function functValidarControles() As Boolean
        If (hfArchivosSismo1.Value <> 0 And tbDuracion.Text <> "" And _
            tbPaso.Text <> "" And tbFactor.Text) Then
            Return True
        Else
            Return False
        End If
    End Function

    'Propiedad que establece la ruta donde se almacenaran los archivos
    Public Property setRuta() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Me.PathFileSave = value
        End Set
    End Property

    Public ReadOnly Property getDatosSismo() As Object()
        Get
            Return arrDatosInputFile
        End Get
    End Property

    Public Property setIdioma() As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)
            idIdioma = value
        End Set
    End Property

#End Region

#Region "Metodos Privados"
    'Presenta un mesaje de alerta de que se ha gurdado el arhivo...
    Private Sub MessageBox(ByVal strMsg As String)

        ' generate a popup message using javascript alert function
        ' dumped into a label with the string argument passed in
        ' to supply the alert box text
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
        & "window.alert(" & "'" & strMsg & "'" & ")</script>"

        ' add the label to the page to display the alert
        Page.Controls.Add(lbl)
    End Sub

    Private Function functCargarArchivo(ByVal ctrlFileUpload As FileUpload) As String
        Dim strMensaje As String = ""
        'Dim auxFileUpLoad As FileUpload = CType(Page.FindControl("fuSismoSentidoX"), FileUpload) 'Busca el control fuSismoSentidoX en el formulario del experimento...

        Try

            'Valida que se haya seleccionado un archivo en el control fileupload 
            If ctrlFileUpload.HasFile Then
                Dim sFileType As String
                sFileType = System.IO.Path.GetExtension(ctrlFileUpload.FileName) 'Obtiene la extención del archivo a cargar
                sFileType = sFileType.ToLower()

                If (sFileType = ".txt") Then
                    'ctrlFileUpload.SaveAs(MapPath(PathFileSave & ctrlFileUpload.FileName.ToString()))
                    ctrlFileUpload.SaveAs(PathFileSave & ctrlFileUpload.FileName.ToString())
                    strPathCompleto = PathFileSave & ctrlFileUpload.FileName.ToString()

                    strMensaje = analizarContenidoArchivo(ctrlFileUpload)
                Else
                    strMensaje = arrTextoErrores(idIdioma, 5)
                End If
            Else
                strMensaje = arrTextoErrores(idIdioma, 4)
            End If

        Catch ex As Exception
            'MessageBox(ex.Message.ToString())
            strMensaje = ex.Message.ToString()
        End Try

        Return strMensaje

    End Function


    ''' <summary>
    '''</summary>
    ''' <remarks>
    ''' Analiza el contenido del archivo, verificando lo siguiente:
    ''' - Que sean valore numericos, y que se encuentren en una sola columna.
    ''' - Duration / TimeStep = Number of lines in the file.
    ''' </remarks>
    ''' <history>
    ''' 	[lsantiago]	 Creado el 2k7-12-22	
    ''' </history>

    Private Function analizarContenidoArchivo(ByVal ctrlFileUpload As FileUpload) As String
        Dim numLineasFileInput As Integer = 0 'Número de lineas del archivo de entrada

        Using archivo As StreamReader = New StreamReader(PathFileSave & ctrlFileUpload.FileName.ToString())
            Dim line As String
            Do
                ReDim Preserve arrDatosInputFile(numLineasFileInput)
                line = archivo.ReadLine
                arrDatosInputFile(numLineasFileInput) = line
                numLineasFileInput = numLineasFileInput + 1
            Loop Until line Is Nothing
        End Using

        Try
            For i As Integer = 0 To numLineasFileInput - 1
                If Double.IsNaN(arrDatosInputFile(i)) Then
                    Return arrTextoErrores(idIdioma, 0)
                Else
                    'MessageBox(arrDatosInputFile(i))
                    Continue For
                End If
            Next
        Catch ex As Exception
            Return arrTextoErrores(idIdioma, 0)
        End Try

        Dim num_datos_posibles As Integer = (tbDuracion.Text / tbPaso.Text) + 1
        numLineasFileInput -= 1

        'En el caso de que el número de lineas del archivo sea menor al número de datos que deve contener el archivo
        'devolvera un error.
        If (numLineasFileInput < num_datos_posibles) Then Return arrTextoErrores(idIdioma, 1)
        'Retorna "File uploaded to VLEE server" si el archivo de sismos cumple con todos los requisitos
        Return arrTextoErrores(idIdioma, 2)
    End Function
#End Region


#Region "Eventos Manipulativos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strFileSismoSentidoX = fuAcelerograma.FileName.ToString()

        'Ahiere propiedades a los controles de los sismos, para
        'no permitir el ingreso de datos invalidos en los TextBox
        sub_ADHERIR_ATRIBUTOS_CONTROLES()

        'Establece el texto en los controles del acelerograma.
        subSetIdiomaControles()
    End Sub

    'Procedimiento que adhiere las propiedades de los controles para
    'no permitir el ingreso de datos invalidos en los TextBox
    Protected Sub sub_ADHERIR_ATRIBUTOS_CONTROLES()
        tbDuracion.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        tbPaso.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        tbFactor.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
    End Sub


    'Genera el evento para cargar el primer sismo
    Protected Sub btnSismoSentidoX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAcelerograma.Click

        If tbDuracion.Text <> "" And tbPaso.Text <> "" Then

            'Llama a la función para cargar el archivo sismico, tambien verifica los datos contenidos en el archivo.
            lblMessagesUploadFileSismoX.Text = functCargarArchivo(fuAcelerograma)

            'Almacenamiento del nombre del archivo de sismo en sentido de las X
            If (lblMessagesUploadFileSismoX.Text = arrTextoErrores(idIdioma, 2)) Then
                strSismoX = fuAcelerograma.FileName.ToString()

                'Permite leer el archivo sismico 
                hfArchivosSismo1.Value = 1

                'subLeerDatosSismo(tbSismo1, PathFileSave & fuAcelerograma.FileName.ToString())
            Else
                strSismoX = Nothing
            End If

        Else
            lblMessagesUploadFileSismoX.Text = arrTextoErrores(idIdioma, 3)
        End If

    End Sub

    'Procedimiento para leer los archivos sismicos y asignar los datos a un TextBox oculto
    'para luego desde el frmPrincipal del ITHA poder extraerlo.
    Sub subLeerDatosSismo(ByRef tb As TextBox, ByVal path As String) 'El path debe incluir hasta el nombre del archivo a cargar 
        If Not File.Exists(path) Then
            'Response.Write("<script>alert('¡Error al leer el archivo!');</script>")
            Return
        Else
            Dim leerTexto As String = File.ReadAllText(path, Encoding.UTF8)
            tb.Text = leerTexto
        End If
    End Sub

    Protected Sub subSetIdiomaControles()
        lblAcelerograma.Text = GetLocalResourceObject("lblAcelerograma.Text").ToString()
        lblDuracion.Text = GetLocalResourceObject("lblDuracion.Text").ToString()
        btnAcelerograma.Text = GetLocalResourceObject("btnAcelerograma.Text").ToString()
        lblPaso.Text = GetLocalResourceObject("lblPaso.Text").ToString()
        lblFactor.Text = GetLocalResourceObject("lblFactor.Text").ToString()
        img2.ImageUrl = GetLocalResourceObject("img2.Text").ToString()
        lblNoteAcelerograma.Text = GetLocalResourceObject("lblNoteAcelerograma.Text").ToString()
    End Sub

#End Region


End Class
