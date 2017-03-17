Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Data



Public Class GenExcell

    Dim w As StringWriter

    'Arreglos y variables para almacenar datos de resultados de las simulaciones
    Dim y(,) As Double, x(,) As Double
    Dim arrX() As Double

    Dim intNumPuntos As Integer, intNumLineas As Integer

    Dim strTitulo As String, strNameEjeX As String, strNameEjeY As String

    'Arreglo de que almacena el numero de puntos de cada linea
    Dim arrNumPuntosPorLinea(,) As Integer


    'Cuando se envia una arreglo y una matriz
    Public Function DoExcell2(ByVal x() As Double, ByVal y(,) As Double, ByVal intNumPuntos As Integer, ByVal intNumLineas As Integer, ByVal strTitulo As String, ByVal strNameEjeX As String, ByVal strNameEjeY As String) As StringWriter
        Me.y = y
        Me.arrX = x
        Me.intNumPuntos = intNumPuntos
        Me.intNumLineas = intNumLineas
        Me.strTitulo = strTitulo
        Me.strNameEjeX = strNameEjeX
        Me.strNameEjeY = strNameEjeY

        'Dim fs As FileStream = New FileStream(ruta, FileMode.Create, FileAccess.ReadWrite)
        w = New StringWriter
        EscribeCabecera()

        NewEscribirLineas2()

        EscribePiePagina()
        Return w
        w.Close()
    End Function


    'Solo cuando se envian matrices
    Public Function DoExcell(ByVal x(,) As Double, ByVal y(,) As Double, ByVal intNumPuntos As Integer, ByVal intNumLineas As Integer, ByVal strTitulo As String, ByVal strNameEjeX As String, ByVal strNameEjeY As String, ByVal arrNumPuntosPorLinea(,) As Integer) As StringWriter
        Me.y = y
        Me.x = x
        Me.intNumPuntos = intNumPuntos
        Me.intNumLineas = intNumLineas
        Me.strTitulo = strTitulo
        Me.strNameEjeX = strNameEjeX
        Me.strNameEjeY = strNameEjeY

        Me.arrNumPuntosPorLinea = arrNumPuntosPorLinea


        'Dim fs As FileStream = New FileStream(ruta, FileMode.Create, FileAccess.ReadWrite)
        w = New StringWriter
        EscribeCabecera()

        NewEscribirLineas()

        EscribePiePagina()
        Return w
        w.Close()
    End Function


    'Cuando recibe la clase un arreglo y ua matriz como parametros
    Public Sub NewEscribirLineas2()
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "


        'Etiquetas de ejes.
        w.Write("<tr>")
        For i As Integer = 0 To intNumLineas - 1
            'If i = 0 Then w.Write("<td></td><td{0}{1}></td>", bgColor, fontColor) Else w.Write("<td{0}{1}></td>", bgColor, fontColor)
            w.Write("<td></td><td >{0}</td><td >{1}</td>", strNameEjeX, strNameEjeY)
        Next
        w.Write("</tr>")


        'Presentacion de datos.
        For i As Integer = 0 To intNumPuntos
            w.Write("<tr >")
            For j As Integer = 1 To intNumLineas
                w.Write("<td></td><td bgcolor=""Gainsboro"">{0}</td>", arrX(i))
                w.Write("<td bgcolor=""Gainsboro"">{0}</td>", y(i, j))
            Next
            w.Write("</tr>")
        Next
    End Sub


    Public Sub NewEscribirLineas()
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "

        'Etiquetas de test.
        w.Write("<tr>")
        For i As Integer = 0 To intNumLineas
            'If i = 0 Then w.Write("<td></td><td{0}{1}></td>", bgColor, fontColor) Else w.Write("<td{0}{1}></td>", bgColor, fontColor)
            w.Write("<td></td><td{0}{1}></td>", bgColor, fontColor)
            w.Write("<td {1}{2}>{0}</td>", "Test " & i + 1, bgColor, fontColor)
        Next
        w.Write("</tr>")

        'Etiquetas de ejes.
        w.Write("<tr>")
        For i As Integer = 0 To intNumLineas
            'If i = 0 Then w.Write("<td></td><td{0}{1}></td>", bgColor, fontColor) Else w.Write("<td{0}{1}></td>", bgColor, fontColor)
            w.Write("<td></td><td >{0}</td><td >{1}</td>", strNameEjeX, strNameEjeY)
        Next
        w.Write("</tr>")


        'Presentacion de datos.
        For i As Integer = 0 To intNumPuntos
            w.Write("<tr >")
            For j As Integer = 0 To intNumLineas
                If i > arrNumPuntosPorLinea(j, 0) Then
                    w.Write("<td></td><td></td><td></td>")
                Else
                    w.Write("<td></td><td bgcolor=""Gainsboro"">{0}</td><td bgcolor=""Gainsboro"">{1}</td>", x(i, j), y(i, j))
                End If
            Next
            w.Write("</tr>")
        Next
    End Sub



    Public Sub EscribeCabecera()
        Dim html As StringBuilder = New StringBuilder
        html.Append("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN "">")
        html.Append("<html>")
        html.Append("<head>")
        html.Append("<title>www.utpl.edu.ec/vlee</title>")
        html.Append("<meta http-equiv= ""Content-Type "" content=""text/html; charset=UTF-8"" />")
        html.Append("</head>")
        html.Append("<body>")
        html.Append("<p>")
        html.Append("<table>")
        html.Append("<tr style=""font-weight:bold;font-size: 12px;color: white;"">")
        html.Append("<td bgcolor=""Orange"">" & strTitulo & "</td>")
        'html.Append("<td bgcolor=""Blue""></td>")

        html.Append("</tr>")
        html.Append("<tr style=""font-weight:bold;font-size: 12px;color: white;""></td>")
        w.Write(html.ToString())
    End Sub




    Public Sub EscribePiePagina()
        Dim html As StringBuilder = New StringBuilder()
        html.Append("</table>")
        html.Append("</p>")
        html.Append("</body>")
        html.Append("</html>")
        w.Write(html.ToString())
    End Sub


End Class
