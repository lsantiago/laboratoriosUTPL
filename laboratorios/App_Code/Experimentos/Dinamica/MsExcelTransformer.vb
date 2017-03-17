Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO


Public Class MsExcelTransformer
    Dim _pathToExcelXslTemplate As String

   

    Public Sub New(ByVal pathToExcelXslTemplate As String)
        _pathToExcelXslTemplate = pathToExcelXslTemplate
    End Sub

    Public Sub SendExcelStreamToClient(ByVal Ds As dataset, ByVal response As System.Web.HttpResponse)
        Try

            Dim xslTrans As XslTransform = New XslTransform()
            'Dim xslTrans As XslCompiledTransform = New XslCompiledTransform()

            'Cargamos nuestro XML que genera el DataSet
            Dim doc As XmlDataDocument = New XmlDataDocument(Ds)

            'Cargamos la plantilla de Excel que hemos creado
            xslTrans.Load(_pathToExcelXslTemplate)

            'Creamos un XPathNavigator que usaremos en la transformación
            Dim nav As XPathNavigator = doc.CreateNavigator()

            ' Transformamos y enviamos los datos                
            response.AddHeader("content-disposition", "attachment; filename=Testeo.xls")
            response.ContentType = "application/vnd.ms-excel"
            response.Charset = String.Empty
            xslTrans.Transform(nav, Nothing, response.OutputStream, Nothing)

            response.Flush()
            response.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
