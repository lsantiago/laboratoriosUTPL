Imports Microsoft.VisualBasic

Namespace VirtualLabIS.Common.Global.Clases
    Public Class Varios
        Shared ex As Exception

        Private intExpColumna_Id As Integer
        Public Shared Property exError() As Exception
            Get
                Return ex
            End Get
            Set(ByVal ex_Mensaje As Exception)
                ex = ex_Mensaje
            End Set
        End Property

    End Class
End Namespace
