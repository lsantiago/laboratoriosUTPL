Imports Microsoft.VisualBasic

Namespace VirtualLabIS.Common.Global.Clases
    Public Class Portales
        Shared intPortalId As Integer

        Public Shared Property PortalId() As Integer
            Get
                Return intPortalId
            End Get
            Set(ByVal value As Integer)
                intPortalId = value
            End Set
        End Property

    End Class
End Namespace