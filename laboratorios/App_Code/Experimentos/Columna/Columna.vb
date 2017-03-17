Imports Microsoft.VisualBasic

Namespace VirtualLabIS.Common.Global.Clases
    Public Class Columna
        Shared intUserID As Integer

        Private intExpColumna_Id As Integer
        Public Shared Property User_Id() As Integer
            Get
                Return intUserID
            End Get
            Set(ByVal value As Integer)
                intUserID = value
            End Set
        End Property

    End Class
End Namespace
