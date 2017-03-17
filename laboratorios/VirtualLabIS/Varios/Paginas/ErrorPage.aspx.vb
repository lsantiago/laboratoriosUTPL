Imports VirtualLabIS.Common.Global.Clases

Namespace VirtualLabIS.VLEE
    Partial Class VirtualLabIS_Varios_ErrorPage
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim strExtraInfo As String = Varios.exError.Data.Item("InfoExtra")
            lblMensajeError.Text = strExtraInfo & "<br/>" & "DESCRIPTION:"
            lblMensajeErrorDetalle.Text = Varios.exError.Message.ToString()
        End Sub
    End Class
End Namespace
