Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports General

Public Class GenerarExcell
    REM Nombre de la tabla html
    Dim w As StringWriter
    Sub EscribeCabecera(ByVal Titulo As String)
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
        html.Append("<td bgcolor=""Orange"">" & Titulo & "</td>")
        'html.Append("<td bgcolor=""Blue""></td>")

        html.Append("</tr>")
        html.Append("<tr style=""font-weight:bold;font-size: 12px;color: white;""></td>")
        w.Write(html.ToString())
    End Sub
    Sub EscribePiePagina()
        Dim html As StringBuilder = New StringBuilder()
        html.Append("</table>")
        html.Append("</p>")
        html.Append("</body>")
        html.Append("</html>")
        w.Write(html.ToString())
    End Sub
    REM Cuando envio las matrices de resultados
    Public Function DoExcell(ByVal MGeneral(,,) As Double, ByVal Titulo As String, ByVal NameEjex As String, ByVal NameEjey As String, ByVal NDatos() As Integer, ByVal NumeroDeserie As Integer)
        Dim i, u As Integer
        On Error Resume Next
        NumeroDeserie = NumeroDeserie - 1
        Dim NombreElemento(NumeroDeserie)
        REM Creo una tabla de html
        w = New StringWriter
        REM Escribo el titulo de la tabla html
        EscribeCabecera(Titulo)
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "
        Dim NumMaxDatos = 0
        w.Write("<tr>")
        For u = 0 To NumeroDeserie
            If NumMaxDatos < NDatos(u) + 1 Then
                NumMaxDatos = NDatos(u)
            End If
            NombreElemento(u) = "Test " & (u + 1)
            w.Write("<td></td><td{0}{1}></td>", bgColor, fontColor)
            w.Write("<td {1}{2}>{0}</td>", NombreElemento(u), bgColor, fontColor)
            w.Write("<td></td>")
        Next
        w.Write("<tr>")
        For u = 0 To NumeroDeserie
            REM Nombre de los ejes de la tabla html
            w.Write("<td></td><td >{0}</td><td >{1}</td>", NameEjex, NameEjey)
            w.Write("<td>")
        Next
        w.Write("<tr>")
        i = 0
        Do
            For u = 0 To NumeroDeserie
                If NDatos(u) + 1 = i Or NDatos(u) + 1 < i Then
                    w.Write("<td><td><td>")
                Else
                    w.Write("<td></td><td bgcolor=""Gainsboro"">{0}</td><td bgcolor=""Gainsboro"">{1}</td>", MGeneral(i, 0, u), MGeneral(i, 1, u))
                End If
                w.Write("<td>")
            Next
            If NumMaxDatos = i Then Exit Do
            w.Write("</tr>")
            i += 1
        Loop
        EscribePiePagina()
        Return w
        w.Close()
    End Function
    REM Cuando Envia respuesta maxima Dinamica 1GDL Tool1
    Public Function DoExcellRespMax_1GDL_Tool1(ByVal MGeneral(,) As Double, ByVal Titulo As String, ByVal NumeroDeserie As Integer, ByVal idioma As String)
        Dim i, u As Integer
        On Error Resume Next
        NumeroDeserie = NumeroDeserie - 1
        ReDim NombreElemento(NumeroDeserie)
        REM Creo una tabla de html
        w = New StringWriter
        EscribeCabecera(Titulo)
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "
        Dim NumMaxDatos = 0
        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        If idioma = "ES" Then
            w.Write("</td><td bgcolor=""CornflowerBlue"" style=""font-size: 10px;color: white;"">{0}", "RESPUESTA MAXIMA")
        ElseIf idioma = "EN" Then
            w.Write("</td><td bgcolor=""CornflowerBlue"" style=""font-size: 10px;color: white;"">{0}", "MAXIMUM ANSWER ")

        End If
               w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")


        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", Nudo1)
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Green"">{0}", Elemento1)
      
        w.Write("</td><td bgcolor=""Green"">{0}", " ")
        w.Write("<tr>")
        w.Write("<td><td>")
        For j As Integer = 0 To 7
            If j = 0 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey1)
            ElseIf j = 1 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex1)
            ElseIf j = 2 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey2)
            ElseIf j = 3 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex2)
            ElseIf j = 4 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey3)
            ElseIf j = 5 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex3)
            ElseIf j = 6 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 7 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)
            End If

        Next
        w.Write("<tr>")
        For u = 0 To NumeroDeserie
            w.Write("<td></td><td bgcolor=""Blue"">{0}", "Test" & u + 1)
            For j As Integer = 0 To 7
                w.Write(" <td bgcolor=""Gainsboro"">{0}", MGeneral(j, u))
            Next
            w.Write("<tr>")
        Next
        EscribePiePagina()
        Return w
        w.Close()
    End Function
    Public Function DoExcellRespMax_2GDL_Tool1(ByVal MGeneral(,) As Double, ByVal Titulo As String, ByVal NumeroDeserie As Integer, ByVal Idioma As String)
        Dim i, u As Integer
        On Error Resume Next
        NumeroDeserie = NumeroDeserie - 1
        ReDim NombreElemento(NumeroDeserie)
        REM Creo una tabla de html
        w = New StringWriter
        EscribeCabecera(Titulo)
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "
        Dim NumMaxDatos = 0
        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"" style=""font-size: 10px;color: white;"">{0}", titRM)

        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")


        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", Nudo1)
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Green"">{0}", ElementoR1)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")
        w.Write("</td><td bgcolor=""Green"">{0}", ElementoA1)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")

        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")

        w.Write("</td><td bgcolor=""Blue"">{0}", Nudo2)

        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")

        w.Write("</td><td bgcolor=""Green"">{0}", ElementoR2)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")
        w.Write("</td><td bgcolor=""Green"">{0}", ElementoA2)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")
        w.Write("<tr>")
        w.Write("<td><td>")
        For j As Integer = 0 To 19
            If j = 0 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey1)
            ElseIf j = 1 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex1)
            ElseIf j = 2 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey2)
            ElseIf j = 3 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex2)
            ElseIf j = 4 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey3)
            ElseIf j = 5 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex3)
            ElseIf j = 6 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 7 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)
            ElseIf j = 8 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 9 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)

            ElseIf j = 10 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey1)
            ElseIf j = 11 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex1)
            ElseIf j = 12 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey2)
            ElseIf j = 13 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex2)
            ElseIf j = 14 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey3)
            ElseIf j = 15 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex3)
            ElseIf j = 16 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 17 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)
            ElseIf j = 18 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 19 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)
            End If

        Next
        w.Write("<tr>")
        For u = 0 To NumeroDeserie
            w.Write("<td></td><td bgcolor=""Blue"">{0}", "Test" & u + 1)
            For j As Integer = 0 To 19
                w.Write(" <td bgcolor=""Gainsboro"">{0}", MGeneral(j, u))
            Next
            w.Write("<tr>")
        Next
        EscribePiePagina()
        Return w
        w.Close()
    End Function
    Public Function DoExcellRespMax_2GDL_Tool2(ByVal MGeneral(,) As Double, ByVal Titulo As String, ByVal NumeroDeserie As Integer, ByVal Idioma As String)
        Dim i, u As Integer
        On Error Resume Next
        NumeroDeserie = NumeroDeserie - 1
        ReDim NombreElemento(NumeroDeserie)
        REM Creo una tabla de html
        w = New StringWriter
        EscribeCabecera(Titulo)
        Dim bgColor As String = "", fontColor = ""
        bgColor = " bgcolor=""CornflowerBlue"" "
        fontColor = " style=""font-size: 10px;color: white;"" "
        Dim NumMaxDatos = 0
        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")

        w.Write("</td><td bgcolor=""CornflowerBlue"" style=""font-size: 10px;color: white;"">{0}", titRM)


        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")
        w.Write("</td><td bgcolor=""CornflowerBlue"">{0}", " ")


        w.Write("<tr>")
        w.Write("<td><td>")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", Nudo1)
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Green"">{0}", Elemento1)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")

        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")

        w.Write("</td><td bgcolor=""Blue"">{0}", Nudo2)

        w.Write("</td><td bgcolor=""Blue"">{0}", " ")
        w.Write("</td><td bgcolor=""Blue"">{0}", " ")

        w.Write("</td><td bgcolor=""Green"">{0}", Elemento2)
        w.Write("</td><td bgcolor=""Green"">{0}", " ")
        w.Write("<tr>")
        w.Write("<td><td>")
        For j As Integer = 0 To 15
            If j = 0 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey1)
            ElseIf j = 1 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex1)
            ElseIf j = 2 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey2)
            ElseIf j = 3 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex2)
            ElseIf j = 4 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey3)
            ElseIf j = 5 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex3)
            ElseIf j = 6 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 7 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)

            ElseIf j = 8 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey1)
            ElseIf j = 9 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex1)
            ElseIf j = 10 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey2)
            ElseIf j = 11 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex2)
            ElseIf j = 12 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey3)
            ElseIf j = 13 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex3)
            ElseIf j = 14 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejey4)
            ElseIf j = 15 Then
                w.Write(" <td bgcolor=""CornflowerBlue"" >{0}", ejex4)
            End If

        Next
        w.Write("<tr>")
        For u = 0 To NumeroDeserie
            w.Write("<td></td><td bgcolor=""Blue"">{0}", "Test" & u + 1)
            For j As Integer = 0 To 15
                w.Write(" <td bgcolor=""Gainsboro"">{0}", MGeneral(j, u))
            Next
            w.Write("<tr>")
        Next
        EscribePiePagina()
        Return w
        w.Close()
    End Function
End Class

