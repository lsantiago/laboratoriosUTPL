
Partial Class Modulos_ctrlCargaSinusoidal
    Inherits System.Web.UI.UserControl
    Dim numCtrl As String
    Dim nomCtrl As String
    Dim strDatosEntrada(2) As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            tbCargaMaxima.Text = ""
            tbFrecuencia.Text = ""
            tbDuracExitacion.Text = ""
        End If
        sub_ADHERIR_ATRIBUTOS_CONTROLES()
        'Asignación del texto en idioma Ingles o Español
        subSetIdiomaControles()
    End Sub


    Protected Sub sub_ADHERIR_ATRIBUTOS_CONTROLES()
        'Valida que el formato sea correcto, no permite 22.22.22 ni letras hhhfgh
        tbCargaMaxima.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbCargaMaxima);")
        tbFrecuencia.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbFrecuencia);")
        tbDuracExitacion.Attributes.Add("onBlur", "formatoCorrecto(document.frmMain.tbDuracExitacion);")

        'Permite solo ingreso de números
        tbCargaMaxima.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        tbFrecuencia.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        tbDuracExitacion.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
    End Sub

    Public ReadOnly Property getDatosIngresados() As String()
        Get
            strDatosEntrada(0) = tbCargaMaxima.Text
            strDatosEntrada(1) = tbFrecuencia.Text
            strDatosEntrada(2) = tbDuracExitacion.Text
            Return strDatosEntrada
        End Get
    End Property

    Public ReadOnly Property verEstadoControles() As String
        Get
            Return functValidarControles()
        End Get
    End Property

    Private Function functValidarControles()
        If (tbCargaMaxima.Text <> "" And _
            tbFrecuencia.Text <> "" And tbDuracExitacion.Text <> "") Then
            Return True
        Else
            Return False
        End If
    End Function



    Protected Sub subSetIdiomaControles()
        img2.ImageUrl = GetLocalResourceObject("img2.Text").ToString()
        'lblFuncionCargaLineal.Text = GetLocalResourceObject("lblFuncionCargaLineal.Text").ToString()
        lblCargaMaxima.Text = GetLocalResourceObject("lblCargaMaxima.Text").ToString()
        lblFrecuencia.Text = GetLocalResourceObject("lblFrecuencia.Text").ToString()
        lblDuracExitacion.Text = GetLocalResourceObject("lblDuracExitacion.Text").ToString()
    End Sub
End Class
