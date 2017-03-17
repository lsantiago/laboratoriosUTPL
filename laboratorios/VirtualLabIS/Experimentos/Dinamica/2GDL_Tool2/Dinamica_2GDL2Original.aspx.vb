Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports ChartDirector
Imports System.Text
Imports System.Data
Imports System.Math
Imports General
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.Globalization

Partial Class VirtualLabIS_Experimentos_Dinamica_2GDL_Tool2_Dinamica_2GDL2
    Inherits System.Web.UI.Page
   
#Region "VARIABLES"
    REM PARA EXPERIMENTO 2S-PORCH_______________________________________________________________________________________
    REM NUMERO DE SERIE
    Dim nserie2Gtool2, nserieAS2Gtool2 As Integer
    REM TODOS LOS ANALISIS
    Dim MGDesp1X(100000, 1, 0), MGVelo1X(100000, 1, 0), MGAce1X(100000, 1, 0), MGForce1X(100000, 1, 0), MGFvsD1X(100000, 1, 0) As Double
    Dim MGDesp2X(100000, 1, 0), MGVelo2X(100000, 1, 0), MGAce2X(100000, 1, 0), MGForce2X(100000, 1, 0), MGFvsD2X(100000, 1, 0) As Double

    REM TIPO DE EXCITACIÓN
    Dim MGExiTypXX(100000, 1, 0), MExiTypXX(,) As Double
    REM ACELERACION DEL SUELO
    Dim MGacSoilXX(100000, 1, 0), MacSoilXX(,) As Double
    Dim MRM_2G_tool2(15, 0) As Double

    REM NUMERO DE DATOS
    Dim NDG1X(), NDG2X(), NDEXX(), NDAcSoilXX() As Integer





    Dim dAC, pasoAC, facAC As Double
    REM TIPO DE MATERIAL:
    Public Fy, r, E, Ro, cR1, cR2 As String
    REM TIPO DE EXCITACION:
    REM Lineal
    REM TriLineal
    Public Fmax As Object
    Public t1, t2, t3 As Double
    REM Sinusoidal
    Public Fo, wa As String

    Dim GEN As General = New General
    REM RECOLECTA TODOS LOS DATOS
    Public VectorDatos(25) As Object
    Public PasoQ As Double

    REM variable para el idioma 
    Shared getIdioma As String
    Public u As Integer
    Dim I, DI
    REM DATOS GENERALES:
    Public m1, m2, k1, k2, c1, c2, TagMaterial1, TagMaterial2, TagMaterial11, TagMaterial12, TagMaterial21, TagMaterial22
    Public Damp1, Damp2, H1, H2, EI1, EI2
    REM TIPO DE MATERIAL:
    Public Fy1, r1, Fy2, r2, E1, E2, Ro1, Ro2 As String
    REM Nombres de los archivos de resulatdos
    Dim namefileD1, namefileV1, namefileA1, namefileF1, namefileD2, namefileV2, namefileA2, namefileF2 As String
    Public MDesp1(,), MVelo1(,), MAce1(,), MForce1(,), MFvsD1(,) As Double
    Public MDesp2(,), MVelo2(,), MAce2(,), MForce2(,), MFvsD2(,) As Double
    Dim UbicFiguras As String
    Dim UbicFiguraMain As String
    REM para escribir tcl
    Public NameTool As String
    REM DIRECTORIOS
    Public DirUsuarioFDE, DirUsuarioResulatdos, DirUsuarioAcelerogramas, DirBat As String
    REM para leer respuestas
    Public DirUsuarioReadResultados, DirBatRun As String
    Public DirTCL, NameTcl, DirACE As String

#Region "VARIABLES PARA DESCRIPCIÓN"
    REM Titulos
    Public Tit1Gtool1 As String

    Public Tit2Gtool1 As String
    Public Tit2Gtool2 As String

    Public titLoadExample As String
    Public ProSis As String
    Public namefileRM As String
    Public EsquemaMain As String
    Public titMaterial As String
    Public titExi As String
    Public titCtipo As String
    Public titAnal As String
    Public titFy As String
    Public titr As String
    Public titRo As String
    Public titI As String
    Public titDI As String
    Public titPmax As String
    Public titt1 As String
    Public titt2 As String
    Public titt3 As String
    Public titPo As String
    Public titW As String
    Public titDA As String
    REM Para acelerograma
    Public titDAce As String
    Public titPace As String
    Public titfacAce As String
    Public notaAce As String

    REM Resp Max
    Public titRMD As String
    Public titRMV As String
    Public titRMA As String
    Public titRMF As String

    REM NOMBRES DE LOS GRAFICOS
    Public titGRAF As String
    Public NombreGraficoAS2 As String
    Public ejeyAS As String
    Public NombreGraficoExi As String
    Public ejexExi As String
    Public ejeyExi As String

    Public NombreGrafico1 As String
    Public NombreGrafico1b As String

    Public ejex1 As String
    Public ejey1 As String

    Public NombreGrafico2 As String
    Public NombreGrafico2b As String
    Public ejex2 As String
    Public ejey2 As String

    Public NombreGrafico3 As String
    Public NombreGrafico3b As String

    Public ejex3 As String
    Public ejey3 As String

    Public NombreGrafico4 As String
    Public NombreGrafico4b As String

    Public ejex4 As String
    Public ejey4 As String

    Public NombreGrafico5 As String
    Public NombreGrafico5b As String

    Public ejex5 As String
    Public ejey5 As String
    REM TOOL2
    Public NombreGrafico11 As String
    Public NombreGrafico21 As String

    Public NombreGrafico12 As String
    Public NombreGrafico22 As String

    Public NombreGrafico13 As String
    Public NombreGrafico23 As String

    Public NombreGrafico14 As String
    Public NombreGrafico24 As String

    Public NombreGrafico15 As String
    Public NombreGrafico25 As String
    REM para los Nudos y elementos
    Public Nudo1, Nudo2, Elemento1, Elemento2 As String
    Public DownAns As String
#Region "Variables Valores Extremos"
    REM Respuesta maxima
    Public xmax, xomax, xoomax, Fomax As Double
    Public txmax, txomax, txoomax, tFomax As Double
    REM Respuesta maxima
    Public xmax1, xomax1, xoomax1, Fomax1, Fomax3 As Double
    Public xmax2, xomax2, xoomax2, Fomax2, Fomax4 As Double


    Public txmax1, txomax1, txoomax1, tFomax1, tFomax3 As Double
    Public txmax2, txomax2, txoomax2, tFomax2, tFomax4 As Double

#End Region


#End Region
    Public Sub NameNyE2GTOOL2(ByVal id)
        If id = "ES" Then
            Nudo1 = "Piso 1"
            Elemento1 = "Columnas Piso 1"
            Nudo2 = "Piso 2"
            Elemento2 = "Columnas Piso 2"

        ElseIf id = "EN" Then
            Nudo1 = "Story 1"
            Elemento1 = "Columns Story 1"
            Nudo2 = "Story 2"
            Elemento2 = "Columns Story 2"
        End If
    End Sub
#End Region
#Region "CONTROL DE ERRORES"
    Public Sub VerificarDatos()
        VectorDatos(0) = 1
        VectorDatos(1) = Me.txtM1.Text
        VectorDatos(2) = Me.txtM2.Text
        If Val(VectorDatos(1)) = 0 Or Val(VectorDatos(2)) = 0 Then
            If ID = "ES" Then
                MensError = "¡La masa no puede ser cero!"
            Else
                MensError = "The mass can not be zero!"
            End If
            HayError = True
            GoTo mensaje
        End If
        VectorDatos(3) = Me.txtH1.Text
        VectorDatos(4) = Me.txtH2.Text
        VectorDatos(5) = Me.txtA1.Text
        VectorDatos(6) = Me.txtA2.Text
        VectorDatos(7) = Me.txtDA.Text

        Select Case Me.DDLmatTyp.SelectedValue
            Case 0
                REM ELASTICO
                VectorDatos(8) = 1
                VectorDatos(9) = 1
                VectorDatos(10) = 1
                VectorDatos(11) = 1
                VectorDatos(12) = 1
                VectorDatos(13) = 1
                VectorDatos(14) = 1
                VectorDatos(15) = 1

            Case 1
                REM Bilineal 1
                VectorDatos(8) = Me.txtFy1.Text
                VectorDatos(9) = Me.txtr1.Text
                VectorDatos(10) = Me.txtFy2.Text
                VectorDatos(11) = Me.txtr2.Text
                VectorDatos(12) = 1
                VectorDatos(13) = 1
                VectorDatos(14) = 1
                VectorDatos(15) = 1

            Case 2
                REM Bilineal 2
                VectorDatos(8) = Me.txtFy1M3.Text
                VectorDatos(9) = Me.txtr1M3.Text
                VectorDatos(10) = Me.txtRo1.Text
                VectorDatos(11) = Me.txtFy2M3.Text
                VectorDatos(12) = Me.txtr2M3.Text
                VectorDatos(13) = Me.txtRo2.Text
                VectorDatos(14) = "0.925"
                VectorDatos(15) = "0.15"

        End Select



        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                REM Función Lineal
                VectorDatos(16) = Me.txtI.Text
                VectorDatos(17) = Me.txtDI.Text
                VectorDatos(18) = 1
            Case 1
                REM 
                VectorDatos(16) = Me.txtFmax.Text
                VectorDatos(17) = Me.txtT1.Text
                VectorDatos(18) = 1
            Case 2
                REM EXCITACION: Función Sinusoidal"
                VectorDatos(16) = Me.txtFo.Text
                VectorDatos(17) = Me.txtWa.Text
                VectorDatos(18) = 1
            Case 3
                REM Acelerograma
                VectorDatos(16) = Me.txtdAC.Text
                VectorDatos(17) = Me.txtpasoAC.Text
                VectorDatos(18) = Me.txtfacAC.Text
        End Select



        For i As Integer = 0 To 18
            If VectorDatos(i) = Nothing Then
                If ID = "ES" Then
                    MensError2 = "Error: Faltan datos"
                ElseIf ID = "EN" Then
                    MensError2 = "Error: Missing data"
                End If

                HayError2 = True
                GoTo mensaje
            Else
                If IsNumeric(VectorDatos(i)) = False Then

                    If ID = "ES" Then
                        MensError2 = "Error: Datos incorrectos"
                    ElseIf ID = "EN" Then
                        MensError2 = "Error: Incorrect data"
                    End If
                    HayError2 = True
                    GoTo Mensaje
                End If

            End If

        Next
mensaje:
        If HayError2 = False Then
            Select Case Me.DDLexiTyp.SelectedValue
                Case 3
                    If AceLoad = False Then


                        If ID = "ES" Then
                            lblMensaje.Text = "Error: Aún no se carga acelerograma"
                        ElseIf ID = "EN" Then
                            lblMensaje.Text = "Error: Accelerogram is not loaded yet"
                        End If
                        HayError2 = True
                    End If
            End Select
        End If
        Me.lblError.Visible = True
        Me.lblError.Text = MensError2

    End Sub


#End Region
#Region "PARA GRAFICAR"
    Dim XYChart_Grafica1 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica2 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico

    Dim XYChart_Grafica3 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica4 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica5 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica6 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica7 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica8 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica9 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica10 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica11 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica12 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico

    Public Sub GraficarTodo()
        nserie2Gtool2 = ViewState("ns3") : nserieAS2Gtool2 = ViewState("nsAS3")
        MGDesp1X = Session("MGDesp1XS") : MGVelo1X = Session("MGVelo1XS") : MGAce1X = Session("MGAce1XS") : MGForce1X = Session("MGForce1XS") : MGFvsD1X = Session("MGFvsD1XS")
        MGDesp2X = Session("MGDesp2XS") : MGVelo2X = Session("MGVelo2XS") : MGAce2X = Session("MGAce2XS") : MGForce2X = Session("MGForce2XS") : MGFvsD2X = Session("MGFvsD2XS")
        MGExiTypXX = Session("MGExiTypXXS") : MGacSoilXX = Session("MGacSoilXXS")
        NDG1X = ViewState("NDG1XS") : NDG2X = ViewState("NDG2XS") : NDEXX = ViewState("NDEXXS") : NDAcSoilXX = ViewState("NDAcSoilXXS")

        On Error Resume Next
        REM grafico la aceleración del suelo
        Call GEN.subGraficarXY(XYChart_Grafica1, MGacSoilXX, wcdAcSoil, NombreGraficoAS2, ejexExi, ejeyAS, True, NDAcSoilXX, nserieAS2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica2, MGExiTypXX, wcdFuncionFuerza, NombreGraficoExi, ejexExi, ejeyExi, True, NDEXX, nserie2Gtool2)

        REM Grafica Desplazamiento Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica3, MGDesp1X, wcdDespVsTime1, NombreGrafico11, ejex1, ejey1, True, NDG1X, nserie2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica4, MGDesp2X, wcdDespVsTime2, NombreGrafico21, ejex1, ejey1, True, NDG2X, nserie2Gtool2)

        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica5, MGVelo1X, wcdVeloVsTime1, NombreGrafico12, ejex2, ejey2, True, NDG1X, nserie2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica6, MGVelo2X, wcdVeloVsTime2, NombreGrafico22, ejex2, ejey2, True, NDG2X, nserie2Gtool2)
        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica7, MGAce1X, wcdAceVsTime1, NombreGrafico13, ejex3, ejey3, True, NDG1X, nserie2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica8, MGAce2X, wcdAceVsTime2, NombreGrafico23, ejex3, ejey3, True, NDG2X, nserie2Gtool2)

        REM Grafica Fuerza Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica9, MGForce1X, wcdForceVsTime1, NombreGrafico14, ejex4, ejey4, True, NDG1X, nserie2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica10, MGForce2X, wcdForceVsTime2, NombreGrafico24, ejex4, ejey4, True, NDG2X, nserie2Gtool2)

        REM Grafica Fuerza Vs.Desplazamiento
        Call GEN.subGraficarXY(XYChart_Grafica11, MGFvsD1X, wcdFvsD1, NombreGrafico15, ejex5, ejey5, False, NDG1X, nserie2Gtool2)
        Call GEN.subGraficarXY(XYChart_Grafica12, MGFvsD2X, wcdFvsD2, NombreGrafico25, ejex5, ejey5, False, NDG2X, nserie2Gtool2)
        REM Redimensiono las matrices para que almacenen el siguiente futuro analisis
        YaHayGrafico1 = True

        ViewState("ns3") = ViewState("ns3") + 1
        nserie2Gtool2 = ViewState("ns3")
        Call ReDimMat()
    End Sub
#End Region
#Region "Escritura de TCL"

    Public Sub inputDatosG()
        m1 = CStr(Me.txtM1.Text) REM Masa
        m2 = CStr(Me.txtM2.Text) REM Masa
        H1 = CStr(Me.txtH1.Text) REM Masa
        H2 = CStr(Me.txtH2.Text) REM Masa
        EI1 = CStr(Me.txtEI1.Text) REM Masa
        EI2 = CStr(Me.txtEI2.Text) REM Masa
        Damp1 = CStr(Me.txtA1.Text) REM Masa
        Damp2 = CStr(Me.txtA2.Text) REM Masa
        DA = CStr(Me.txtDA.Text) REM Duracion del analisis
        On Error Resume Next
        REM Matriz de duraciones de todos los analisis
        ReDim Preserve MDA(nserie2Gtool2)
        MDA(nserie2Gtool2) = DA
    End Sub

    ''' <summary>
    ''' Es el procedimeinto principal
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Main()
        NameTcl = NameTool & usuario & ".tcl"
        Dim CrearArchivo As String = DirTCL & NameTcl
        WriteFile2GDLTool2(DirTCL, NameTcl)
    End Sub


    ''' <summary>
    ''' Escribe el archivo
    ''' </summary>
    ''' <param name="UbicacionFile"></param>
    ''' <param name="NombreFile"></param>
    ''' <remarks></remarks>
    Public Sub WriteFile2GDLTool2(ByVal UbicacionFile As String, ByVal NombreFile As String)
        Dim I, DI
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFile & NombreFile)
        REM Hago uso del archivo
        Using w As StreamWriter = File.AppendText(UbicacionFile & NombreFile)

            REM Etiqueta del ejercicio
            w.WriteLine("######################################################################################")
            w.WriteLine("#" & NombreFile & "                                                                  #")
            w.WriteLine("#Analisis dinamico de  una estructura en dos grados de libertad                      #")
            w.WriteLine("#Unidades: kN, m, s                                                                  #")
            w.WriteLine("######################################################################################")
            w.WriteLine("{0} {1}", "wipe", ";# Este comando borra todos los objetos existentes en el interpretador Tcl")
            REM HASTA AQUI PREPARO A OPENSEES PARA EL ANALISIS
            REM DEFINO CONSTANTES EN OPENSEES
            w.WriteLine("#DEFINICION DE CONSTANTES")
            w.WriteLine("set pi [expr acos(-1.0)]")
            REM AHORA RECEPTO LOS DATOS PARA USARLOS EN OPENSEES
            REM DATOS GENERALES: m1,m2,k1,k2,c1,c2,DA 
            Call inputDatosG()
            w.WriteLine("#RECEPCION DE DATOS ##################################################################")
            w.WriteLine("{0} {1} {2}", "set m1", m1, ";#Masa1")
            w.WriteLine("{0} {1} {2}", "set m2", m2, ";#Masa2")
            w.WriteLine("{0} {1} {2}", "set H1", H1, ";#Separación piso a piso 1")
            w.WriteLine("{0} {1} {2}", "set H2", H2, ";#Separación piso a piso 2")
            w.WriteLine("{0} {1} {2}", "set EI1", EI1, ";#Producto rigidez por inercia del piso 1")
            w.WriteLine("{0} {1} {2}", "set EI2", EI2, ";#Producto rigidez por inercia del piso 2")
            w.WriteLine("{0} {1} {2}", "set Damp1", Damp1, ";#Amortiguamiento 1 en %")
            w.WriteLine("{0} {1} {2}", "set Damp2", Damp2, ";#Amortiguamiento 2 en %")
            w.WriteLine("set damp1 [expr $Damp1*pow(100,-1)]")
            w.WriteLine("set damp2 [expr $Damp2*pow(100,-1)]")
            w.WriteLine("set k1 [expr 24*$EI1/pow($H1,3)]")
            w.WriteLine("set k2 [expr 24*$EI2/pow($H2,3)]")
            w.WriteLine("{0} {1} {2}", "set duracionA", DA, ";#Duracion del analisis")
            REM CREACION DEL MODELO
            w.WriteLine("#EMPIEZO A CREAR EL MODELO ###########################################################")
            w.WriteLine("model basic -ndm 2 -ndf 2      ;# 2 dimenciones; 2 Grados de Libertad (GDL) por nudo")
            w.WriteLine("# Se define la geometría -------------------------------------------------------------")
            w.WriteLine("# Coordenadas de los nudos")
            w.WriteLine("#    n x y")
            w.WriteLine("node 1 0 0")
            w.WriteLine("node 2 1 0")
            w.WriteLine("node 3 2 0")
            w.WriteLine("node 4 3 0")
            w.WriteLine("# Se empotra el nudo 1")
            w.WriteLine("#   n 1 2 ")
            w.WriteLine("fix 1 1 1")
            w.WriteLine("fix 2 0 1 ")
            w.WriteLine("fix 3 0 1 ")
            w.WriteLine("fix 4 0 1 ")
            w.WriteLine("# Se asigna una masa en Tonne (kN/g) al nudo 2 Y 3 en la dirección X")
            w.WriteLine("#    n  1   2")
            w.WriteLine("mass 2 $m1 1e-6")
            w.WriteLine("mass 3 $m2 1e-6")
            w.WriteLine("mass 4 1e-6 1e-6")
            w.WriteLine("# Definicion de Elementos   ------------------------------------------------------")
            w.WriteLine("# Se crea un elemento truss entre los nudos 1 y 2")
            w.WriteLine("# Al elemento elástico se le asigna un area de 1 m2")
            w.WriteLine("#Los modulos de elasticidad E son igual a K ya que A=1 y L=1")
            w.WriteLine("set E1 $k1")
            w.WriteLine("set E2 $k2")
            REM ESCRIBIR SEGUN EL TIPO DE MATERIAL ESCOGIDO
            w.WriteLine(" ")
            Select Case Me.DDLmatTyp.SelectedValue
                Case 0
                    REM Ealstico
                    w.WriteLine("{0} {1} {2}", "set TagMaterial1", 11, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial2", 12, ";#Etiqueta")
                    w.WriteLine("# MATERIAL: Elastico")
                    w.WriteLine("uniaxialMaterial Elastic  $TagMaterial1 $E1")
                    w.WriteLine("uniaxialMaterial Elastic  $TagMaterial2 $E2")
                Case 1
                    REM Bilineal 1
                    w.WriteLine("# MATERIAL: Bilineal 1")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial1", 21, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial2", 22, ";#Etiqueta")
                    Fy1 = Me.txtFy1.Text
                    r1 = Me.txtr1.Text
                    Fy2 = Me.txtFy2.Text
                    r2 = Me.txtr2.Text
                    w.WriteLine("{0} {1} {2}", "set Fy1", Fy1, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r1", r1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Fy2", Fy2, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r2", r2, ";#Coeficiente")
                    w.WriteLine("uniaxialMaterial Steel01 $TagMaterial1 $Fy1 $E1 $r1")
                    w.WriteLine("uniaxialMaterial Steel01 $TagMaterial2 $Fy2 $E2 $r2")
                Case 2
                    REM Bilineal 2
                    w.WriteLine("# MATERIAL: Bilineal 2")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial1", 31, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial2", 32, ";#Etiqueta")
                    Fy1 = Me.txtFy1M3.Text
                    r1 = Me.txtr1M3.Text
                    Ro1 = Me.txtRo1.Text
                    Fy2 = Me.txtFy2M3.Text
                    r2 = Me.txtr2M3.Text
                    Ro2 = Me.txtRo2.Text
                    cR1 = "0.925"
                    cR2 = "0.15"
                    w.WriteLine("{0} {1} {2}", "set Fy1", Fy1, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r1", r1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Ro1", Ro1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Fy2", Fy2, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r2", r2, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Ro2", Ro2, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set cR1", cR1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set cR2", cR2, ";#Coeficiente")
                    w.WriteLine("uniaxialMaterial Steel02 $TagMaterial1 $Fy1 $E1 $r1 $Ro1 $cR1 $cR2")
                    w.WriteLine("uniaxialMaterial Steel02 $TagMaterial2 $Fy2 $E2 $r2 $Ro2 $cR1 $cR2")
            End Select
            w.WriteLine("#DEFINO EL ELEMENTO")
            w.WriteLine("#             nele ni nj  Area TagMaterial")
            w.WriteLine("element truss 1 1  2 1  $TagMaterial1")
            w.WriteLine("element truss 2 2  3 1  $TagMaterial2")
            w.WriteLine("element truss 3 3  4 1  $TagMaterial2")
            w.WriteLine("#MODELO CREADO")
            w.WriteLine(" ")
            REM HASTA AQUI
            w.WriteLine("#VIBRACIÓN FORZADA ############################")
            Select Case Me.DDLexiTyp.SelectedValue
                Case 0
                    REM Función Lineal
                    GEN.WritefCargaL(DirUsuarioFDE, "FacDforceCL.txt")
                    w.WriteLine("# EXCITACION: Función Lineal")
                    I = Me.txtI.Text
                    DI = Me.txtDI.Text
                    w.WriteLine("{0} {1} {2}", "set Impulso", I, ";#Impulso")
                    w.WriteLine("{0} {1} {2}", "set DuracionImp", DI, ";#Duración del impulso")
                    w.WriteLine("set Fmax [expr $Impulso*$DuracionImp]")
                    w.WriteLine("#Aplico la funcion de carga")
                    w.WriteLine("#Se aplicará la carga a intervalos iguales de tiempo")
                    w.WriteLine("# t0 F0 t1 F1")
                    w.WriteLine("#0  0  DI Fmax")
                    w.WriteLine("set time1 $DuracionImp")
                    w.WriteLine("set dt $time1")
                    w.WriteLine()
                    w.WriteLine("set fileName " & """" & DirUsuarioFDE & "FacDforceCL.txt""")
                    w.WriteLine("set serie1  ""Series -dt $dt -filePath $fileName""")
                    w.WriteLine("pattern Plain 1 $serie1 {")
                    w.WriteLine("#     node Fx Fy")
                    w.WriteLine("load 2 $Fmax 0")
                    w.WriteLine("load 3 $Fmax 0")
                    w.WriteLine("}")
                    w.WriteLine("#LA CARGA FUE DEFINIDA###########################################################")
                Case 1
                    REM Bilineal 1
                    w.WriteLine("# EXCITACION: Función Trilineal")
                    Fmax = Me.txtFmax.Text
                    t1 = Me.txtT1.Text
                    t2 = Me.txtT2.Text
                    t3 = Me.txtT3.Text
                    PasoQ = t3 / 7000
                    REM Escribo los factores de carga trilineal
                    GEN.WriteCargaT(CDbl(Fmax), t1, t2, t3, DirUsuarioFDE, "FacDforceCT.txt")
                    w.WriteLine("{0} {1} {2}", "set Fmax", Fmax, ";#Fuerza maxima")
                    w.WriteLine("{0} {1} {2}", "set time1", PasoQ, ";#Intervalo de tiempo")
                    w.WriteLine("set dt $time1")
                    w.WriteLine("set fileName """ & DirUsuarioFDE & "FacDforceCT.txt""")
                    w.WriteLine("set serie1 ""Series -dt $dt -filePath $fileName""")
                    w.WriteLine("pattern Plain 1 $serie1 {")
                    w.WriteLine("#     node Fx Fy")
                    w.WriteLine("load 2 $Fmax 0")
                    w.WriteLine("load 3 $Fmax 0")
                    w.WriteLine("}")
                Case 2
                    REM Bilineal 1
                    w.WriteLine("# EXCITACION: Función Sinusoidal")
                    Fo = Me.txtFo.Text
                    wa = Me.txtWa.Text
                    w.WriteLine("{0} {1} {2}", "set Fo", Fo, ";#Fuerza maxima")
                    w.WriteLine("{0} {1} {2}", "set wa", wa, ";#Frecuencia de exitacion")
                    w.WriteLine("set Ta [expr 2*$pi*pow($wa,-1)]")
                    w.WriteLine("set tFinish $duracionA")
                    w.WriteLine("set serie3 ""Sine 0 $tFinish $Ta 0 1""")
                    w.WriteLine("pattern Plain 1 $serie3 {")
                    w.WriteLine("#     node Fx Fy")
                    w.WriteLine("load 2 $Fo 0")
                    w.WriteLine("load 3 $Fo 0")
                    w.WriteLine("}")

                Case 3
                    REM Bilineal 1
                    w.WriteLine("# EXCITACION: Acelerograma")
                    REM Call subLeerAcelerograma()
                    w.WriteLine("set fileName """ & DirUsuarioAcelerogramas & "Acelerograma.txt""")
                    dAC = Me.txtdAC.Text
                    pasoAC = Me.txtpasoAC.Text
                    facAC = Me.txtfacAC.Text
                    w.WriteLine("{0} {1} {2}", "set dAC", dAC, ";#Duracion del acelerograma")
                    w.WriteLine("{0} {1} {2}", "set pasoAC", pasoAC, ";#Incremento de tiempo")
                    w.WriteLine("{0} {1} {2}", "set facAC", facAC, ";#Factor de aceleración")
                    w.WriteLine("set acc ""Series -dt $pasoAC -filePath $fileName  -factor $facAC""")
                    w.WriteLine("pattern UniformExcitation 1 1 -accel $acc")
            End Select
            w.WriteLine("# AMORTIGUAMIENTO")
            w.WriteLine("set lambda1 $damp1 ;# amortiguamiento asignado al primer modo de vibración")
            w.WriteLine("set lambda2 $damp2 ;# amortiguamiento asignado al segundo modo de vibración")
            w.WriteLine("set eigenvalues [eigen 2] ;# Obtenemos los valores propios de los primeros 2 modos de vibracion")
            w.WriteLine("set omega1 [expr sqrt([lindex $eigenvalues 0])] ;# Las frecuencias de vibracion son la raiz cuadrada de los valores propios")
            w.WriteLine("set omega2 [expr sqrt([lindex $eigenvalues 1])] ;# Los valores propios estan en una lista, el comando lindex extrae elementos de la lista")
            w.WriteLine("set T1 [expr 2.0*$pi*pow($omega1,-1)] ;# Periodo del primer modo de vibración")
            w.WriteLine("set T2 [expr 2.0*$pi*pow($omega2,-1)] ;# Periodo del segundo modo de vibracion")
            w.WriteLine("set alpha [expr (2*$omega1*$omega2*($omega1*$lambda2-$omega2*$lambda1))/($omega1**2-$omega2**2)]")
            w.WriteLine("set beta [expr 2*($omega1*$lambda1-$omega2*$lambda2)/($omega1**2-$omega2**2)]")
            w.WriteLine("set pasoA [expr $T2*pow(30,-1)]")
            w.WriteLine("set npuntos [format ""%.0f"" [ expr $duracionA*pow($pasoA,-1)]]")
            REM REALIZO EL ANALISIS DINAMICO:
            w.WriteLine(" ")
            w.WriteLine(" #REALIZO EL ANALISIS DINAMICO")
            w.WriteLine("constraints Plain")
            w.WriteLine("numberer Plain")
            w.WriteLine("system BandGeneral")
            w.WriteLine("test NormDispIncr 1.0e-5 6")
            w.WriteLine("algorithm Newton")
            w.WriteLine("integrator Newmark 0.5 0.25 $alpha $beta 0 0")
            w.WriteLine("analysis Transient")
            w.WriteLine("#Guardo los resultados: GDL 1")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Desplazamiento1.out " & " -time -node 2 -dof 1 disp")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Velocidad1.out " & " -time -node 2 -dof 1 vel")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Aceleracion1.out " & " -time -node 2 -dof 1 accel")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza1.out " & " -time -ele 1  localForce")
            w.WriteLine("#Guardo los resultados: GDL 2")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Desplazamiento2.out " & " -time -node 3 -dof 1 disp")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Velocidad2.out " & " -time -node 3 -dof 1 vel")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Aceleracion2.out " & " -time -node 3 -dof 1 accel")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza2.out " & " -time -ele 2  localForce")
            w.WriteLine("#Pido los resultados segun la duración del analisis")
            w.WriteLine("analyze $npuntos $pasoA")
            w.WriteLine("exit")
            w.Flush()
            REM Close the writer and underlying file.
            w.Close()
        End Using
    End Sub
#End Region
#Region "EVENTOS PROTEGIDOS"
    ''' <summary>
    ''' CUANDO INICIA LA HERRAMIENTA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InicioTool()
        REM Detecto el usuario
        usuario = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id.ToString

        REM Creo un directorio para el usuario__________________________________
        REM Nombre de la herramienta
        NameTool = "Din2GDLtool2"
        REM creo directorio
        DirUsuarioFDE = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/FactoresDE/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioFDE)
        DirUsuarioResulatdos = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Resultados2Gtool2/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioResulatdos)
        DirUsuarioAcelerogramas = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Acelerogramas/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioAcelerogramas)
        DirBat = "C:/vlee/Dinamica/" & usuario & "/BATCHS/"
        My.Computer.FileSystem.CreateDirectory(DirBat)
        REM ubicacion de los TCL
        DirTCL = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\"
        DirUsuarioReadResultados = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Resultados2Gtool2\"
        DirBatRun = "C:\vlee\Dinamica\" & usuario & "\BATCHS\"
        DirACE = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Acelerogramas\"

        REM ______________________________________________________________________
    End Sub
    ''' <summary>
    ''' Boton ejecutar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Select Case Me.DDLborrarA.SelectedValue
            Case 0
                Call RunDinamica2GDLTool2()
        End Select
        nserie2Gtool2 = ViewState("ns3")
        If YaHayGrafico1 = True And nserie2Gtool2 >= 0 Then
            PrepararMarco()
            Select Case Me.DDLborrarA.SelectedValue
                Case 1
                    If YaHayGraficoAS2 = True And nserieAS2Gtool2 >= 0 Then
                        ViewState("nsAS3") = ViewState("nsAS3") - 1
                        nserieAS2Gtool2 = ViewState("nsAS3")
                        ReDim Preserve NDAcSoilXX(nserieAS2Gtool2)
                        Me.DDLborrarA.SelectedIndex = 0
                    End If
                    ViewState("ns3") = ViewState("ns3") - 2
                    nserie2Gtool2 = ViewState("ns3")
                    REM GRAFICO LOS RESULTADOS
                    Call ReDimMat()
                    REM ClearData()
                    Call GraficarTodo()

                    If nserie2Gtool2 >= 0 Then
                        YaHayGrafico1 = True
                    Else
                        YaHayGrafico1 = False
                    End If
                    nserieAS2Gtool2 = ViewState("nsAS3")
                    If nserieAS2Gtool2 >= 0 Then
                        YaHayGraficoAS1 = True
                    Else
                        YaHayGraficoAS1 = False
                    End If

                    Me.DDLborrarA.SelectedIndex = 0
                Case 2
                    ViewState("ns3") = 0
                    ViewState("nsAS3") = -1
                    nserie2Gtool2 = ViewState("ns3")
                    nserieAS2Gtool2 = ViewState("nsAS3")
                    Me.DDLborrarA.SelectedIndex = 0
                    YaHayGrafico1 = False
                    Call EncerarMat()
                    Call ClearData()
                    Call PrepararMarco()

            End Select

        End If
    End Sub
    ''' <summary>
    ''' Cargar acelerogramas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Call CargarFile()
    End Sub
    ''' <summary>
    ''' llama a ejecutar
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RunDinamica2GDLTool2()
        Me.lblMensCE.Visible = False
        Call VerificarDatos()
        If HayError2 = True Then
            PrepararMarco()
            HayError2 = False
            Exit Sub
        Else
            Me.lblError.Text = Nothing
        End If
        Call Main()
        REM EN ESTA PARTE SE CREA UN BATCH PARA EJECUTAR LA HERRAMIENTA_____
        REM Creo los batchs segun la necesidad
        Dim UbFileExe As String = "C:\vlee\"
        Dim nameExe As String = "OpenSees(210).exe"
        Dim nameBat As String = NameTool & usuario & ".bat"
        Dim nameFullFileRun As String = DirTCL & NameTcl
        Dim CrearArchivo As String = DirBat & nameBat
        REM Hago uso del archivo
        GEN.WriteBAT(UbFileExe, nameExe, DirBat, nameBat, nameFullFileRun)
        REM En este momento se debe mandar a ejecutar el TCL
        Process.Start(DirBatRun & nameBat).WaitForExit(True)
        REM ___________________________________________________
        namefileD1 = "Desplazamiento1.out"
        namefileV1 = "Velocidad1.out"
        namefileA1 = "Aceleracion1.out"
        namefileF1 = "Fuerza1.out"
        namefileD2 = "Desplazamiento2.out"
        namefileV2 = "Velocidad2.out"
        namefileA2 = "Aceleracion2.out"
        namefileF2 = "Fuerza2.out"
        On Error Resume Next
        Call subLeerResultados1(namefileD1, namefileV1, namefileA1, namefileF1)
        Call subLeerResultados2(namefileD2, namefileV2, namefileA2, namefileF2)
        REM Mostrar respuestas
        Call DispRespMax()
        REM Preparo las matrices que serán graficadas
        Call PrepararMatrices()
        REM grafico las matrices
        Call GraficarTodo()
    End Sub
    ''' <summary>
    ''' Preparo las patallas para grafica
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrepararMarco()
        establecerPropCtrlGraficos(XYChart_Grafica1, NombreGraficoAS2, ejexExi, ejeyAS)
        wcdAcSoil.Image = XYChart_Grafica1.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica2, NombreGraficoExi, ejexExi, ejeyExi)
        wcdFuncionFuerza.Image = XYChart_Grafica2.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica3, NombreGrafico11, ejex1, ejey1)
        wcdDespVsTime1.Image = XYChart_Grafica3.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica4, NombreGrafico21, ejex1, ejey1)
        wcdDespVsTime2.Image = XYChart_Grafica4.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica5, NombreGrafico12, ejex2, ejey2)
        wcdVeloVsTime1.Image = XYChart_Grafica5.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica6, NombreGrafico22, ejex2, ejey2)
        wcdVeloVsTime2.Image = XYChart_Grafica6.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica7, NombreGrafico13, ejex3, ejey3)
        wcdAceVsTime1.Image = XYChart_Grafica7.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica8, NombreGrafico23, ejex3, ejey3)
        wcdAceVsTime2.Image = XYChart_Grafica8.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica9, NombreGrafico14, ejex4, ejey4)
        wcdForceVsTime1.Image = XYChart_Grafica9.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica10, NombreGrafico24, ejex4, ejey4)
        wcdForceVsTime2.Image = XYChart_Grafica10.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica11, NombreGrafico15, ejex5, ejey5)
        wcdFvsD1.Image = XYChart_Grafica11.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica12, NombreGrafico25, ejex5, ejey5)
        wcdFvsD2.Image = XYChart_Grafica12.makeWebImage(Chart.PNG)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "2S-Porch"
        Call InicioTool()
        ReDimMat()
        REM Detecto el idioma con el que estamos trabajando
        getIdioma = Request.Params("idioma")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
        If getIdioma = "es-ES" Then
            ID = "ES"
        Else
            ID = "EN"

        End If
        Call DescripciónSegunId(Me.DDLmatTyp, Me.DDLexiTyp, Me.DDLborrarA, ID)
        Call NombresLabelsTitulos()
        Call NombresLabelsDescarga()
        If Not Page.IsPostBack Then

            HayError2 = False
            ViewState("ns3") = 0
            nserie2Gtool2 = ViewState("ns3")
            ViewState("nsAS3") = -1
            nserieAS2Gtool2 = ViewState("nsAS3")
            tmaxA = 0
            facStepA = 50
            Me.FigMat1.Visible = True
            Me.FigMat2.Visible = False
            Me.FigMat3.Visible = False

            Me.panBlineal1.Visible = False
            Me.panBlineal2.Visible = False

            Me.panFL.Visible = True : Me.FigExi1.Visible = True
            Me.panFT.Visible = False : Me.FigExi2.Visible = False
            Me.panFS.Visible = False : Me.FigExi3.Visible = False
            Me.panAC.Visible = False : Me.FigExi4.Visible = False
        End If
        If Not Page.IsPostBack Then
            Call PrepararMarco()
            EncerarMat()
        End If
    End Sub
    Protected Sub DDLmattyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLmatTyp.SelectedIndexChanged
        Call PrepararMarco()
        Select Case Me.DDLmatTyp.SelectedValue
            Case 0
                REM Elastico
                Me.FigMat1.Visible = True
                Me.FigMat2.Visible = False
                Me.FigMat3.Visible = False
                Me.panBlineal1.Visible = False
                Me.panBlineal2.Visible = False

            Case 1
                REM Bilineal 1
                Me.FigMat2.Visible = True
                Me.FigMat1.Visible = False
                Me.FigMat3.Visible = False
                Me.panBlineal1.Visible = True
                Me.panBlineal2.Visible = False
            Case 2
                REM Bilineal 2
                Me.FigMat3.Visible = True
                Me.FigMat1.Visible = False
                Me.FigMat2.Visible = False
                Me.panBlineal2.Visible = True
                Me.panBlineal1.Visible = False
        End Select
    End Sub
    Protected Sub DDLexityp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLexiTyp.SelectedIndexChanged
        PrepararMarco()
        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                REM Funcion Lineal
                Me.panFL.Visible = True : Me.FigExi1.Visible = True
                Me.panFT.Visible = False : Me.FigExi2.Visible = False
                Me.panFS.Visible = False : Me.FigExi3.Visible = False
                Me.panAC.Visible = False : Me.FigExi4.Visible = False
            Case 1
                REM Funcion triLineal
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                Me.panFT.Visible = True : Me.FigExi2.Visible = True
                Me.panFS.Visible = False : Me.FigExi3.Visible = False
                Me.panAC.Visible = False : Me.FigExi4.Visible = False
            Case 2
                REM Funcion sinusoidal
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                Me.panFT.Visible = False : Me.FigExi2.Visible = False
                Me.panFS.Visible = True : Me.FigExi3.Visible = True
                Me.panAC.Visible = False : Me.FigExi4.Visible = False
            Case 3
                REM Acelerograma
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                Me.panFT.Visible = False : Me.FigExi2.Visible = False
                Me.panFS.Visible = False : Me.FigExi3.Visible = False
                Me.panAC.Visible = True : Me.FigExi4.Visible = True
        End Select
    End Sub
    Public Sub CargarFile()
        On Error Resume Next
        Call GEN.subCargarArchivo(FUpLoadAC, lblMensaje, txtpasoAC, txtdAC, DDLsepCol, ID, DirACE)
        REM Call CargarAcelerograma(FUpLoadAC, lblMensaje)
        Call PrepararMarco()
    End Sub
#End Region
#Region "LECTURA DE RESULTADOS"

    ''' <summary>
    ''' Lee los resultados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subLeerResultados1(ByVal nameFileD As String, ByVal nameFileV As String, ByVal nameFileA As String, ByVal nameFileF As String)
        Dim UbicacionFile As String
        UbicacionFile = DirUsuarioReadResultados
        Dim nfilas As Integer
        nfilas = 0 : nColumnas = 0
        REM Abro el archivo para calcular el número de filas y columnas totales
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileD)
            Dim strLine As String = archivo.ReadLine 'Se lee una Linea
            nColumnas = strLine.Split(" ").GetUpperBound(0)
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim strLineaAux() As String = strLine.Split(" ")
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using
        nColumnas = nColumnas - 1

        REM Redimensiono la matriz Acelerograma con el numero de lineas y numero de columnas
        ReDim MDesp1(nfilas, nColumnas)
        ReDim MVelo1(nfilas, nColumnas)
        ReDim MAce1(nfilas, nColumnas)
        ReDim MForce1(nfilas, nColumnas)
        ReDim MFvsD1(nfilas, nColumnas)
        MDesp1(0, 0) = 0
        MDesp1(0, 1) = 0
        MVelo1(0, 0) = 0
        MVelo1(0, 1) = 0
        MAce1(0, 0) = 0
        MAce1(0, 1) = 0
        MForce1(0, 0) = 0
        MForce1(0, 1) = 0
        MFvsD1(0, 0) = 0
        MFvsD1(0, 1) = 0

        xmax1 = 0 : xomax1 = 0 : xoomax1 = 0 : Fomax1 = 0
        REM LEO EL ARCHIVO DE DESPLAZAMIENTOS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileD)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MDesp1(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xmax1) < Abs(CDbl(MDesp1(nfilas, 1))) Then
                    txmax1 = Abs(CDbl(MDesp1(nfilas, 0)))
                    xmax1 = Abs(CDbl(MDesp1(nfilas, 1)))

                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE VELOCIDADES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileV)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MVelo1(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xomax1) < Abs(CDbl(MVelo1(nfilas, 1))) Then
                    txomax1 = Abs(CDbl(MVelo1(nfilas, 0)))
                    xomax1 = Abs(CDbl(MVelo1(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE ACELERACIONES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileA)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MAce1(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xoomax1) < Abs(CDbl(MAce1(nfilas, 1))) Then
                    txoomax1 = Abs(CDbl(MAce1(nfilas, 0)))
                    xoomax1 = Abs(CDbl(MAce1(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE FUERZAS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileF)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MForce1(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(Fomax1) < Abs(CDbl(MForce1(nfilas, 1))) Then
                    tFomax1 = Abs(CDbl(MForce1(nfilas, 0)))
                    Fomax1 = Abs(CDbl(MForce1(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using


    End Sub
    ''' <summary>
    ''' Lee los resultados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subLeerResultados2(ByVal nameFileD As String, ByVal nameFileV As String, ByVal nameFileA As String, ByVal nameFileF As String)
        Dim UbicacionFile As String
        UbicacionFile = DirUsuarioReadResultados
        Dim nfilas As Integer
        nfilas = 0 : nColumnas = 0
        REM Abro el archivo para calcular el número de filas y columnas totales
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileD)
            Dim strLine As String = archivo.ReadLine 'Se lee una Linea
            nColumnas = strLine.Split(" ").GetUpperBound(0)
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim strLineaAux() As String = strLine.Split(" ")
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using
        nColumnas = nColumnas - 1

        REM Redimensiono la matriz Acelerograma con el numero de lineas y numero de columnas
        ReDim MDesp2(nfilas, nColumnas)
        ReDim MVelo2(nfilas, nColumnas)
        ReDim MAce2(nfilas, nColumnas)
        ReDim MForce2(nfilas, nColumnas)
        ReDim MFvsD2(nfilas, nColumnas)
        MDesp2(0, 0) = 0
        MDesp2(0, 1) = 0
        MVelo2(0, 0) = 0
        MVelo2(0, 1) = 0
        MAce2(0, 0) = 0
        MAce2(0, 1) = 0
        MForce2(0, 0) = 0
        MForce2(0, 1) = 0
        MFvsD2(0, 0) = 0
        MFvsD2(0, 1) = 0

        xmax2 = 0 : xomax2 = 0 : xoomax2 = 0 : Fomax2 = 0
        REM LEO EL ARCHIVO DE DESPLAZAMIENTOS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileD)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MDesp2(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xmax2) < Abs(CDbl(MDesp2(nfilas, 1))) Then
                    txmax2 = Abs(CDbl(MDesp2(nfilas, 0)))
                    xmax2 = Abs(CDbl(MDesp2(nfilas, 1)))

                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE VELOCIDADES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileV)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MVelo2(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xomax2) < Abs(CDbl(MVelo2(nfilas, 1))) Then
                    txomax2 = Abs(CDbl(MVelo2(nfilas, 0)))
                    xomax2 = Abs(CDbl(MVelo2(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE ACELERACIONES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileA)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MAce2(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xoomax2) < Abs(CDbl(MAce2(nfilas, 1))) Then
                    txoomax2 = Abs(CDbl(MAce2(nfilas, 0)))
                    xoomax2 = Abs(CDbl(MAce2(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE FUERZAS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFileF)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MForce2(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(Fomax2) < Abs(CDbl(MForce2(nfilas, 1))) Then
                    tFomax2 = Abs(CDbl(MForce2(nfilas, 0)))
                    Fomax2 = Abs(CDbl(MForce2(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using


    End Sub
    Public Sub DispRespMax()
        Me.txtXmax1.Text = Round(xmax1, 4) : Me.lblXmax1.Text = "(" & Round(txmax1, 2) & " s)"
        Me.txtXomax1.Text = Round(xomax1, 4) : Me.lblXoMax1.Text = "(" & Round(txomax1, 2) & " s)"
        Me.txtXoomax1.Text = Round(xoomax1, 4) : Me.lblXooMax1.Text = "(" & Round(txoomax1, 2) & " s)"
        Me.txtFomax1.Text = Round(Fomax1, 4) : Me.lblFomax1.Text = "(" & Round(tFomax1, 2) & " s)"

        Me.txtXmax2.Text = Round(xmax2, 4) : Me.lblXmax2.Text = "(" & Round(txmax2, 2) & " s)"
        Me.txtXoMax2.Text = Round(xomax2, 4) : Me.lblXoMax2.Text = "(" & Round(txomax2, 2) & " s)"
        Me.txtXooMax2.Text = Round(xoomax2, 4) : Me.lblXooMax2.Text = "(" & Round(txoomax2, 2) & " s)"
        Me.txtFomax2.Text = Round(Fomax2, 4) : Me.lblFoMax2.Text = "(" & Round(tFomax2, 2) & " s)"
        MRM_2G_tool2 = Session("MRM_2G_tool2S")
        ReDim Preserve MRM_2G_tool2(15, nserie2Gtool2)
        For j As Integer = 0 To 15
            If j = 0 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xmax1
            ElseIf j = 1 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txmax1
            ElseIf j = 2 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xomax1
            ElseIf j = 3 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txomax1
            ElseIf j = 4 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xoomax1
            ElseIf j = 5 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txoomax1
            ElseIf j = 6 Then
                MRM_2G_tool2(j, nserie2Gtool2) = Fomax1
            ElseIf j = 7 Then
                MRM_2G_tool2(j, nserie2Gtool2) = tFomax1
            ElseIf j = 8 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xmax2
            ElseIf j = 9 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txmax2
            ElseIf j = 10 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xomax2
            ElseIf j = 11 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txomax2
            ElseIf j = 12 Then
                MRM_2G_tool2(j, nserie2Gtool2) = xoomax2
            ElseIf j = 13 Then
                MRM_2G_tool2(j, nserie2Gtool2) = txoomax2
            ElseIf j = 14 Then
                MRM_2G_tool2(j, nserie2Gtool2) = Fomax2
            ElseIf j = 15 Then
                MRM_2G_tool2(j, nserie2Gtool2) = tFomax2
            End If

        Next j
        Session("MRM_2G_tool2S") = MRM_2G_tool2
    End Sub

#End Region
#Region "PREPARAR MATRICES"
    Public Sub PrepararMatrices()
        Dim I, DI
        nserie2Gtool2 = ViewState("ns3") : nserieAS2Gtool2 = ViewState("nsAS3")
        MGDesp1X = Session("MGDesp1XS") : MGVelo1X = Session("MGVelo1XS") : MGAce1X = Session("MGAce1XS") : MGForce1X = Session("MGForce1XS") : MGFvsD1X = Session("MGFvsD1XS")
        MGDesp2X = Session("MGDesp2XS") : MGVelo2X = Session("MGVelo2XS") : MGAce2X = Session("MGAce2XS") : MGForce2X = Session("MGForce2XS") : MGFvsD2X = Session("MGFvsD2XS")

        NDG1X = ViewState("NDG1XS") : NDG2X = ViewState("NDG2XS") : NDEXX = ViewState("NDEXXS")
       
       
        ReDim Preserve NDG1X(nserie2Gtool2)
        ReDim Preserve NDG2X(nserie2Gtool2)

        ReDim Preserve NDEXX(nserie2Gtool2) REM Numero de datos de exitación
        ViewState("NDEXXS") = NDEXX
        NDG1X(nserie2Gtool2) = CDbl(MDesp1.GetUpperBound(0))
        NDG2X(nserie2Gtool2) = CDbl(MDesp2.GetUpperBound(0))
        ViewState("NDG1XS") = NDG1X : ViewState("NDG2XS") = NDG2X

        For u = 0 To NDG1X(nserie2Gtool2)
            MFvsD1(u, 0) = MDesp1(u, 1)
            MFvsD1(u, 1) = MForce1(u, 1)
            For j As Integer = 0 To 1
                MGDesp1X(u, j, nserie2Gtool2) = MDesp1(u, j)
                MGVelo1X(u, j, nserie2Gtool2) = MVelo1(u, j)
                MGAce1X(u, j, nserie2Gtool2) = MAce1(u, j)
                MGForce1X(u, j, nserie2Gtool2) = MForce1(u, j)
                MGFvsD1X(u, j, nserie2Gtool2) = MFvsD1(u, j)
            Next
        Next
        For u = 0 To NDG2X(nserie2Gtool2)
            MFvsD2(u, 0) = MDesp2(u, 1) - MDesp1(u, 1)
            MFvsD2(u, 1) = MForce2(u, 1)
            For j As Integer = 0 To 1
                MGDesp2X(u, j, nserie2Gtool2) = MDesp2(u, j)
                MGVelo2X(u, j, nserie2Gtool2) = MVelo2(u, j)
                MGAce2X(u, j, nserie2Gtool2) = MAce2(u, j)
                MGForce2X(u, j, nserie2Gtool2) = MForce2(u, j)
                MGFvsD2X(u, j, nserie2Gtool2) = MFvsD2(u, j)
            Next
        Next
        Session("MGDesp1XS") = MGDesp2X : Session("MGVelo1XS") = MGVelo1X : Session("MGAce1XS") = MGAce1X : Session("MGForce1XS") = MGForce1X : Session("MGFvsD1XS") = MGFvsD1X
        Session("MGDesp2XS") = MGDesp1X : Session("MGVelo2XS") = MGVelo2X : Session("MGAce2XS") = MGAce2X : Session("MGForce2XS") = MGForce2X : Session("MGFvsD2XS") = MGFvsD2X

        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                I = Me.txtI.Text
                DI = Me.txtDI.Text
                ReDim MExiTypXX(1, 1)
                MExiTypXX(0, 0) = 0
                MExiTypXX(0, 1) = 0
                MExiTypXX(1, 0) = DI
                MExiTypXX(1, 1) = I * DI
                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Función de fuerza lineal"
                ElseIf ID = "EN " Then
                    NombreGraficoExi = "Excitation: Linear force functio"
                End If
            Case 1
                Fmax = Me.txtFmax.Text
                t1 = Me.txtT1.Text
                t2 = Me.txtT2.Text
                t3 = Me.txtT3.Text
                ReDim MExiTypXX(3, 1)
                MExiTypXX(0, 0) = 0
                MExiTypXX(0, 1) = 0
                MExiTypXX(1, 0) = t1
                MExiTypXX(1, 1) = Fmax
                MExiTypXX(2, 0) = t2
                MExiTypXX(2, 1) = Fmax
                MExiTypXX(3, 0) = t3
                MExiTypXX(3, 1) = 0
                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Función de fuerza trilineal"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Tri-linear force function"
                End If
            Case 2
                Fo = Me.txtFo.Text
                wa = Me.txtWa.Text
                Dim pi As Double = 4 * Atan(1)
                Dim Ta, Dexi, PasoExi As Double
                Dim Ndexi As Integer
                Ndexi = 0
                Ta = (2 * pi) / wa
                PasoExi = Ta / 200
                Dexi = 0
                Do While Dexi <= DA
                    Dexi += PasoExi
                    Ndexi += 1
                Loop
                ReDim MExiTypXX(Ndexi, 1)
                Ndexi = 0
                Dexi = 0
                Do While Ndexi <= MExiTypXX.GetUpperBound(0)
                    MExiTypXX(Ndexi, 0) = Dexi
                    MExiTypXX(Ndexi, 1) = Fo * Sin(wa * Dexi)
                    Ndexi += 1
                    Dexi += PasoExi
                Loop
                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Función de fuerza armónica"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Harmonic function force"
                End If
            Case 3
                dAC = Me.txtdAC.Text
                pasoAC = Me.txtpasoAC.Text
                facAC = Me.txtfacAC.Text
                Dim Dexi As Double
                Dim Ndexi As Integer
                Ndexi += dAC / pasoAC

                ReDim MExiTypXX(Ndexi, 1)
                ReDim MacSoilXX(Ndexi, 1)

                Dexi = 0
                Ndexi = 0
                Do While Ndexi <= MExiTypXX.GetUpperBound(0)
                    MExiTypXX(Ndexi, 0) = Dexi
                    MacSoilXX(Ndexi, 0) = Dexi
                    Dexi += pasoAC
                    Ndexi += 1
                Loop
                On Error Resume Next
                Dim ncAce As Integer = (Acelerograma.GetUpperBound(0) + 1) * (Acelerograma.GetUpperBound(1) + 1)
                For nf As Integer = 0 To ncAce
                    For nc As Integer = 0 To Acelerograma.GetUpperBound(1)
                        MacSoilXX(nf, 1) = Acelerograma(nf, nc) * facAC
                        MExiTypXX(nf, 1) = Acelerograma(nf, nc) * facAC * (-10)
                        If nf = Ndexi Then Exit For
                    Next
                    If nf = Ndexi Then Exit For
                Next
                YaHayGraficoAS2 = True
                ViewState("nsAS3") = ViewState("nsAS3") + 1
                nserieAS2Gtool2 = ViewState("nsAS3")
                NDAcSoilXX = ViewState("NDAcSoilXXS")
                ReDim Preserve NDAcSoilXX(nserieAS2Gtool2)
                NDAcSoilXX(nserieAS2Gtool2) = CDbl(MacSoilXX.GetUpperBound(0))
                ViewState("NDAcSoilXXS") = NDAcSoilXX
                MGacSoilXX = Session("MGacSoilXXS")
                ReDim Preserve MGacSoilXX(100000, 1, nserieAS2Gtool2)
                Session("MGacSoilXXS") = MGacSoilXX
                MGacSoilXX = Session("MGacSoilXXS")
                For u = 0 To NDAcSoilXX(nserieAS2Gtool2)
                    For j As Integer = 0 To 1
                        REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                        MGacSoilXX(u, j, nserieAS2Gtool2) = MacSoilXX(u, j)
                    Next
                Next
                Session("MGacSoilXXS") = MGacSoilXX
                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Acelerograma"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Acceleration record"
                End If

        End Select

        NDEXX(nserie2Gtool2) = CDbl(MExiTypXX.GetUpperBound(0))
        ViewState("NDEXXS") = NDEXX
        MGExiTypXX = Session("MGExiTypXXS")
        NDEXX = ViewState("NDEXXS")
        For u = 0 To NDEXX(nserie2Gtool2)
            For j As Integer = 0 To 1
                REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                MGExiTypXX(u, j, nserie2Gtool2) = MExiTypXX(u, j)
            Next
        Next
        Session("MGExiTypXXS") = MGExiTypXX
    End Sub

    Public Sub EncerarMat()
        ViewState("ns3") = 0 : ViewState("nsAS3") = -1
        nserie2Gtool2 = ViewState("ns3") : nserieAS2Gtool2 = ViewState("nsAS3")

        ReDim MDA(nserie2Gtool2)
        ReDim NDEXX(nserie2Gtool2)
        ReDim NDAcSoilXX(nserieAS2Gtool2)
        ReDim NDG1X(nserie2Gtool2)
        ReDim NDG2X(nserie2Gtool2)
        ReDim MGDesp1X(100000, 1, nserie2Gtool2), MGVelo1X(100000, 1, nserie2Gtool2), MGAce1X(100000, 1, nserie2Gtool2), MGForce1X(100000, 1, nserie2Gtool2), MGFvsD1X(100000, 1, nserie2Gtool2)
        ReDim MGDesp2X(100000, 1, nserie2Gtool2), MGVelo2X(100000, 1, nserie2Gtool2), MGAce2X(100000, 1, nserie2Gtool2), MGForce2X(100000, 1, nserie2Gtool2), MGFvsD2X(100000, 1, nserie2Gtool2)
        ReDim MDesp1(0, 0), MVelo1(0, 0), MAce1(0, 0), MForce1(0, 0), MFvsD1(0, 0)
        ReDim MDesp2(0, 0), MVelo2(0, 0), MAce2(0, 0), MForce2(0, 0), MFvsD2(0, 0)

        ReDim MGExiTypXX(100000, 1, nserie2Gtool2)
        ReDim MExiTypXX(0, 0)
        ReDim MGacSoilXX(100000, 1, nserieAS2Gtool2)
        ReDim MacSoilXX(0, 0)
        Session("MGDesp1XS") = MGDesp2X : Session("MGVelo1XS") = MGVelo1X : Session("MGAce1XS") = MGAce1X : Session("MGForce1XS") = MGForce1X : Session("MGFvsD1XS") = MGFvsD1X
        Session("MGDesp2XS") = MGDesp1X : Session("MGVelo2XS") = MGVelo2X : Session("MGAce2XS") = MGAce2X : Session("MGForce2XS") = MGForce2X : Session("MGFvsD2XS") = MGFvsD2X
        Session("MGExiTypXXS") = MGExiTypXX : Session("MGacSoilXXS") = MGacSoilXX
        ViewState("NDG1XS") = NDG1X : ViewState("NDG2XS") = NDG2X : ViewState("NDEXXS") = NDEXX : ViewState("NDAcSoilXXS") = NDAcSoilXX

    End Sub

    Public Sub ReDimMat()
        nserie2Gtool2 = ViewState("ns3") : nserieAS2Gtool2 = ViewState("nsAS3")
        MGDesp1X = Session("MGDesp1XS") : MGVelo1X = Session("MGVelo1XS") : MGAce1X = Session("MGAce1XS") : MGForce1X = Session("MGForce1XS") : MGFvsD1X = Session("MGFvsD1XS")
        MGDesp2X = Session("MGDesp2XS") : MGVelo2X = Session("MGVelo2XS") : MGAce2X = Session("MGAce2XS") : MGForce2X = Session("MGForce2XS") : MGFvsD2X = Session("MGFvsD2XS")
        MGExiTypXX = Session("MGExiTypXXS") : MGacSoilXX = Session("MGacSoilXXS")
        NDG1X = ViewState("NDG1XS") : NDG2X = ViewState("NDG2XS") : NDEXX = ViewState("NDEXXS") : NDAcSoilXX = ViewState("NDAcSoilXXS")
        ReDim Preserve MDA(nserie2Gtool2)
        ReDim Preserve NDEXX(nserie2Gtool2)
        ReDim Preserve NDAcSoilXX(nserieAS2Gtool2)
        ReDim Preserve NDG1X(nserie2Gtool2)
        ReDim Preserve NDG2X(nserie2Gtool2)
        ReDim Preserve MGDesp1X(100000, 1, nserie2Gtool2), MGVelo1X(100000, 1, nserie2Gtool2), MGAce1X(100000, 1, nserie2Gtool2), MGForce1X(100000, 1, nserie2Gtool2), MGFvsD1X(100000, 1, nserie2Gtool2)
        ReDim Preserve MGDesp2X(100000, 1, nserie2Gtool2), MGVelo2X(100000, 1, nserie2Gtool2), MGAce2X(100000, 1, nserie2Gtool2), MGForce2X(100000, 1, nserie2Gtool2), MGFvsD2X(100000, 1, nserie2Gtool2)
        ReDim Preserve MGExiTypXX(100000, 1, nserie2Gtool2)
        ReDim Preserve MGacSoilXX(100000, 1, nserieAS2Gtool2)
        Session("MGDesp1XS") = MGDesp2X : Session("MGVelo1XS") = MGVelo1X : Session("MGAce1XS") = MGAce1X : Session("MGForce1XS") = MGForce1X : Session("MGFvsD1XS") = MGFvsD1X
        Session("MGDesp2XS") = MGDesp1X : Session("MGVelo2XS") = MGVelo2X : Session("MGAce2XS") = MGAce2X : Session("MGForce2XS") = MGForce2X : Session("MGFvsD2XS") = MGFvsD2X
        Session("MGExiTypXXS") = MGExiTypXX : Session("MGacSoilXXS") = MGacSoilXX
        ViewState("NDG1XS") = NDG1X : ViewState("NDG2XS") = NDG2X : ViewState("NDEXXS") = NDEXX : ViewState("NDAcSoilXXS") = NDAcSoilXX

    End Sub

#End Region
#Region "DESCARGAR RESULTADOS"
    Public Sub DescargarResp(ByVal MGeneral(,,) As Double, ByVal Titulo As String, ByVal NameEjex As String, ByVal NameEjey As String, ByVal NDatos() As Integer, ByVal NumeroDeserie As Integer)
        Dim ge As GenerarExcell = New GenerarExcell
        'No enviamos la respuesta hasta que hemos terminado de procesar todo
        Response.Buffer = True
        'Ponemos el tipo de la respuesta al valor adecuado
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment; filename=" & Titulo & ".xls")
        REM Escribo la tabla html y luego la tranformo a una Hoja de excel
        Response.Write(ge.DoExcell(MGeneral, Titulo, NameEjex, NameEjey, NDatos, NumeroDeserie))
        Response.End()
    End Sub
    ''' <summary>
    ''' Descargamos las respuestas de las graficas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Protected Sub btnDownResul1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDownResul1.Click, _
       btnDownResul2.Click, btnDownResul3.Click, btnDownResul4.Click, btnDownResul5.Click, btnDownResul6.Click, _
       btnDownResul7.Click, btnDownResul8.Click, btnDownResul9.Click, btnDownResul10.Click, btnDownResul11.Click, btnDownResul12.Click
        nserie2Gtool2 = ViewState("ns3") : nserieAS2Gtool2 = ViewState("nsAS3")
        MGDesp1X = Session("MGDesp1XS") : MGVelo1X = Session("MGVelo1XS") : MGAce1X = Session("MGAce1XS") : MGForce1X = Session("MGForce1XS") : MGFvsD1X = Session("MGFvsD1XS")
        MGDesp2X = Session("MGDesp2XS") : MGVelo2X = Session("MGVelo2XS") : MGAce2X = Session("MGAce2XS") : MGForce2X = Session("MGForce2XS") : MGFvsD2X = Session("MGFvsD2XS")
        MGExiTypXX = Session("MGExiTypXXS") : MGacSoilXX = Session("MGacSoilXXS")
        NDG1X = ViewState("NDG1XS") : NDG2X = ViewState("NDG2XS") : NDEXX = ViewState("NDEXXS") : NDAcSoilXX = ViewState("NDAcSoilXXS")

        Select Case CType(sender, ImageButton).ID
            Case "btnDownResul1"
                REM grafico la aceleración del suelo
                Call DescargarResp(MGacSoilXX, NombreGraficoAS2, ejexExi, ejeyAS, NDAcSoilXX, nserieAS2Gtool2)
            Case "btnDownResul2"
                REM Historia de exitación
                Call DescargarResp(MGExiTypXX, NombreGraficoExi, ejexExi, ejeyExi, NDEXX, nserie2Gtool2)
            Case "btnDownResul3"
                REM Archivo Desplazamiento Vs.Tiempo
                Call DescargarResp(MGDesp1X, NombreGrafico11, ejex1, ejey1, NDG1X, nserie2Gtool2)
            Case "btnDownResul4"
                REM Archivo Desplazamiento Vs.Tiempo
                Call DescargarResp(MGDesp2X, NombreGrafico21, ejex1, ejey1, NDG2X, nserie2Gtool2)
            Case "btnDownResul5"
                REM Archivo Velocidad Vs.Tiempo
                Call DescargarResp(MGVelo1X, NombreGrafico12, ejex2, ejey2, NDG1X, nserie2Gtool2)
            Case "btnDownResul6"
                REM Archivo Velocidad Vs.Tiempo
                Call DescargarResp(MGVelo2X, NombreGrafico22, ejex2, ejey2, NDG2X, nserie2Gtool2)
            Case "btnDownResul7"
                REM Archivo Aceleración Vs.Tiempo
                Call DescargarResp(MGAce1X, NombreGrafico13, ejex3, ejey3, NDG1X, nserie2Gtool2)
            Case "btnDownResul8"
                REM Archivo Aceleración Vs.Tiempo
                Call DescargarResp(MGAce2X, NombreGrafico23, ejex3, ejey3, NDG2X, nserie2Gtool2)
            Case "btnDownResul9"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce1X, NombreGrafico14, ejex4, ejey4, NDG1X, nserie2Gtool2)
            Case "btnDownResul10"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce2X, NombreGrafico24, ejex4, ejey4, NDG2X, nserie2Gtool2)
            Case "btnDownResul11"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD1X, NombreGrafico15, ejex5, ejey5, NDG1X, nserie2Gtool2)
            Case "btnDownResul12"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD2X, NombreGrafico25, ejex5, ejey5, NDG2X, nserie2Gtool2)
        End Select

    End Sub
    ''' <summary>
    ''' Descargamos todas la respuestas maximas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton14_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton14.Click
        Dim ge As GenerarExcell = New GenerarExcell
        'No enviamos la respuesta hasta que hemos terminado de procesar todo
        Response.Buffer = True
        'Ponemos el tipo de la respuesta al valor adecuado
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment; filename=" & namefileRM & ".xls")
        REM Escribo la tabla html y luego la tranformo a una Hoja de excel
        nserie2Gtool2 = ViewState("ns3")
        MRM_2G_tool2 = Session("MRM_2G_tool2S")
        Response.Write(ge.DoExcellRespMax_2GDL_Tool2(MRM_2G_tool2, namefileRM, nserie2Gtool2, ID))
        Response.End()
    End Sub
#End Region
#Region "DESCRIBIR VARIABLES"
    Public Sub DescripciónSegunId(ByVal ListaTM As DropDownList, ByVal ListaTE As DropDownList, ByVal ListaRUN As DropDownList, ByVal Idioma As String)
        If Idioma = "ES" Then

            Tit2Gtool2 = "ANÁLISIS DINÁMICO DE UN PORTICO SIMPLE DE DOS PISOS"
            titLoadExample = "Cargar ejemplo"
            namefileRM = "Respuestas máximas"
            REM NOMBRES DE LOS GRAFICOS_________________________________________________
            titGRAF = "GRÁFICAS"
            NombreGraficoAS2 = "Aceleración del suelo (Solo con acelerograma)"
            ejeyAS = "Aceleración [m /s^2]"
            NombreGraficoExi = "Tipo de excitación"
            ejexExi = "Tiempo [s]"
            ejeyExi = "Fuerza externa [kN]"
            NombreGrafico2 = "Desplazamiento relativo (Piso 1)"
            NombreGrafico1b = "Desplazamiento relativo (Piso 2)"
            ejex1 = "Tiempo [s]"
            ejey1 = "Desplazamiento [m]"
            NombreGrafico2 = "Velocidad relativa (Piso 1)"
            NombreGrafico2b = "Velocidad relativa (Piso 2)"
            ejex2 = "Tiempo [s]"
            ejey2 = "Velocidad [m/s]"
            NombreGrafico3 = "Aceleración relativa (Piso 1)"
            NombreGrafico3b = "Aceleración relativa (Piso 2)"
            ejex3 = "Tiempo [s]"
            ejey3 = "Aceleración [m/s2]"
            NombreGrafico4 = "Fuerza relativa (Columnas Piso 1)"
            NombreGrafico4b = "Fuerza relativa (Columnas Piso 2)"
            ejex4 = "Tiempo [s]"
            ejey4 = "Fuerza interna [kN]"
            NombreGrafico5 = "Histerisis (Columnas Piso 1)"
            NombreGrafico5b = "Histerisis (Columnas Piso 2)"
            ejex5 = "Desplazamiento [m]"
            ejey5 = "Fuerza interna [kN]"

            REM TOOL2
            NombreGrafico11 = "Desplazamiento relativo (Piso 1)"
            NombreGrafico21 = "Desplazamiento relativo (Piso 2)"
            NombreGrafico12 = "Velocidad relativa (Piso 1)"
            NombreGrafico22 = "Velocidad relativa (Piso 2)"
            NombreGrafico13 = "Aceleración relativa (Piso 1)"
            NombreGrafico23 = "Aceleración relativa (Piso 2)"
            NombreGrafico14 = "Fuerza interna (Columnas Piso 1)"
            NombreGrafico24 = "Fuerza interna (Columnas Piso 2)"
            NombreGrafico15 = "Histerisis (Columnas Piso 1)"
            NombreGrafico25 = "Histerisis (Columnas Piso 2)"
            REM ______________________________________________________________________
            REM OPCIONES DE LOS CONTROLES
            REM Tipo de material
            ListaTM.Items.Item(0).Text = "Elástico"
            ListaTM.Items.Item(1).Text = "Bilineal 1"
            ListaTM.Items.Item(2).Text = "Bilineal 2"
            REM Tipo de exitación
            ListaTE.Items.Item(0).Text = "Función de fuerza lineal"
            ListaTE.Items.Item(1).Text = "Función de fuerza trilineal"
            ListaTE.Items.Item(2).Text = "Función de fuerza armónica"
            ListaTE.Items.Item(3).Text = "Acelerograma"
            REM Lista de analisis
            ListaRUN.Items.Item(0).Text = "Analizar"
            ListaRUN.Items.Item(1).Text = "Borrar el último análisis"
            ListaRUN.Items.Item(2).Text = "Borrar todos los análisis"
            REM para los labels de descarga
            DownAns = "Descargar resultados"
            ProSis = "PROPIEDADES DEL SISTEMA"
            EsquemaMain = "ESQUEMA"
            titMaterial = "TIPO DE MATERIAL"
            titExi = "TIPO DE EXCITACIÓN"
            titCtipo = "COMPORTAMIENTO TIPO"
            titAnal = "ANALISIS"
            titFy = "Fuerza de fluencia [kN]"
            titr = "Coeficiente post-fluencia"
            titRo = "Control de transición del estado elástico al plástico (Recomendado entre: 10 y 20)"
            titI = "Magnitud del impulso [kN/s]"
            titDI = "Duración del impulso [s]"
            titPmax = "Carga máxima [kN]"
            titt1 = "tiempo 1 [s]"
            titt2 = "tiempo 2 [s]"
            titt3 = "tiempo 3 [s]"
            titPo = "Amplitud máxima [kN]"
            titW = "Frecuencia [rad/s]"
            titDA = "Duración:"
            titDAce = "Duración del acelerograma [s]"
            titPace = "Paso del acelerograma [s]"
            titfacAce = "Factor de aceleración [m/s^2]"
            notaAce = "Nota: El archivo solo puede contener valores de aceleración. Verificar que al inicio de la columna no haya espacio ni tab. Si las aceleraciones estan en columnas deberán estar separadas por Tabs."
            titRM = "RESPUESTA MÁXIMA"
            titRMD = "Desplazamiento"
            titRMV = "Velocidad"
            titRMA = "Aceleración"
            titRMF = "Fuerza interna"


        ElseIf Idioma = "EN" Then
            Tit2Gtool2 = "DYNAMIC ANALYSIS OF A TWO-STORY SIMPLE FRAME"
            titLoadExample = "Load example"
            namefileRM = "Maximum response"
            REM NOMBRES DE LOS GRAFICOS______________________________________________________________
            NombreGraficoAS2 = "Ground acceleration (Only with acceleration record)"
            ejeyAS = "Acceleration [m/s^2]"
            NombreGraficoExi = "Type of Excitation"
            ejexExi = "Time [s]"
            ejeyExi = "External force [kN]"
            REM NOMBRES DE LOS GRAFICOS
            titGRAF = "GRAPHICS"
            NombreGrafico2 = "Relative displacement (Story 1)"
            NombreGrafico1b = "Relative displacement (Story 2)"
            ejex1 = "Time [s]"
            ejey1 = "Displacement [m]"
            NombreGrafico2 = "Relative velocity (Story 1)"
            NombreGrafico2b = "Relative velocity (Story 2)"
            ejex2 = "Time [s]"
            ejey2 = "Velocity [m/s]"
            NombreGrafico3 = "Relative acceleration (Story 1)"
            NombreGrafico3b = "Relative acceleration (Story 2)"
            ejex3 = "Time [s]"
            ejey3 = "Acceleration [m/s^2]"
            NombreGrafico4 = "Internal force(Columns Story 1)"
            NombreGrafico4b = "Internal force (Columns Story 2)"
            ejex4 = "Time [s]"
            ejey4 = "Internal force [kN]"
            NombreGrafico5 = "Hysterisis (Columns Story 1)"
            NombreGrafico5b = "Hysterisis (Columns Story 2)"
            ejex5 = "Displacement [m]"
            ejey5 = "Internal force [kN]"
            REM TOOL2
            NombreGrafico11 = "Relative displacement (Story 1)"
            NombreGrafico21 = "Relative displacement(Story  2)"
            NombreGrafico12 = "Relative velocity (Story 1)"
            NombreGrafico22 = "Relative velocity (Story 2)"
            NombreGrafico13 = "Relative acceleration (Story 1)"
            NombreGrafico23 = "Relative acceleration (Story 2)"
            NombreGrafico14 = "Internal force (Columns Story 1)"
            NombreGrafico24 = "Internal force (Columns Story 2)"
            NombreGrafico15 = "Hysterisis (Columns Story 1)"
            NombreGrafico25 = "Hysterisis (Columns Story 2)"
            REM ________________________________________________________________________________________()
            REM tipo de material
            ListaTM.Items.Item(0).Text = "Elastic"
            ListaTM.Items.Item(1).Text = "Bilinear 1"
            ListaTM.Items.Item(2).Text = "Bilinear 2"
            REM Tipo de exitación
            ListaTE.Items.Item(0).Text = "Linear force function"
            ListaTE.Items.Item(1).Text = "Tri-linear force function"
            ListaTE.Items.Item(2).Text = "Harmornic force function"
            ListaTE.Items.Item(3).Text = "Acceleration record"
            REM
            ListaRUN.Items.Item(0).Text = "Analyze"
            ListaRUN.Items.Item(1).Text = "Clear last analysis"
            ListaRUN.Items.Item(2).Text = "Clear all analysis"
            REM 
            DownAns = "Download answers"

            ProSis = "SYSTEM PROPERTIES"
            EsquemaMain = "OUTLINE"
            titMaterial = "TYPE OF MATERIAL"
            titExi = "TYPE OF EXCITATION"
            titCtipo = "BEHAVIOR TYPE"
            titAnal = "ANALYSIS"
            titFy = "Yield strength [kN]"
            titr = "Post yield stiffness coefficient"
            titRo = "Control of transition from elastic to plastic state (Recommended between: 10 and 20)"
            titI = "Magnitude of impulse [kN/s]"
            titDI = "Duration of impulse [s]"
            titPmax = "Maximum load [kN]"
            titt1 = "time 1 [s]"
            titt2 = "time 2 [s]"
            titt3 = "time 3 [s]"
            titPo = "Maximum amplitude [kN]"
            titW = "Frequency [rad/s]"
            titDA = "Duration:"

            titDAce = "Duration of acceleration record[s]"
            titPace = "Step of acceleration record [s]"
            titfacAce = "Factor of acceleration [m/s^2]"
            notaAce = "Note:The file can only contain values of acceleration. Verify that the start of the column is no space or tab. If the accelerations are in columns should be separated by Tabs."
            REM 
            titRM = "MAXIMUM RESPONSE"
            titRMD = "Displacement"
            titRMV = "Velocity"
            titRMA = "Acceleration"
            titRMF = "Internal force"
        End If

    End Sub
    Public Sub NombresLabelsDescarga()
        lblDR1.Text = DownAns
        lblDR2.Text = DownAns
        lblDR3.Text = DownAns
        lblDR4.Text = DownAns
        lblDR5.Text = DownAns
        lblDR6.Text = DownAns
        lblDR7.Text = DownAns
        lblDr8.Text = DownAns
        lblDR9.Text = DownAns
        lblDR10.Text = DownAns
        lblDR11.Text = DownAns
        lblDR12.Text = DownAns
        lblDR13.Text = DownAns
        Dim base, altura As Single
        base = 35
        altura = 30
        DimFiguras(btnDownResul1, base, altura)
        DimFiguras(btnDownResul2, base, altura)
        DimFiguras(btnDownResul3, base, altura)
        DimFiguras(btnDownResul4, base, altura)
        DimFiguras(btnDownResul5, base, altura)
        DimFiguras(btnDownResul6, base, altura)
        DimFiguras(btnDownResul7, base, altura)
        DimFiguras(btnDownResul8, base, altura)
        DimFiguras(btnDownResul9, base, altura)
        DimFiguras(btnDownResul10, base, altura)
        DimFiguras(btnDownResul11, base, altura)
        DimFiguras(btnDownResul12, base, altura)
        DimFiguras(ImageButton14, base, altura)
        DimFiguras(ibtnLoadExample, 30, 25)
    End Sub
    Public Sub NombresLabelsTitulos()
        Me.lblNameTool.Text = "2S-Porch"
        Me.lblLoadExample.Text = titLoadExample
        Me.lblTitulo2GDLtool2.Text = Tit2Gtool2
        Me.lblGraficas.Text = titGRAF
        lblProSis.Text = ProSis
        lblEsquemaMain.Text = EsquemaMain
        lblTM.Text = titMaterial
        lblEsqTE.Text = EsquemaMain
        lblCT.Text = titCtipo
        lblAnalisis.Text = titAnal
        Me.lblFyMat21.Text = titFy
        Me.lblFyMat31.Text = titFy
        Me.lblrMat21.Text = titr
        Me.lblrMat31.Text = titr
        Me.lblRoMat31.Text = titRo
        Me.lblI.Text = titI
        Me.lblDI.Text = titDI
        Me.lblPmax.Text = titPmax
        Me.lblT1.Text = titt1
        Me.lblT2.Text = titt2
        Me.lblT3.Text = titt3
        Me.lblPo.Text = titPo
        Me.lblFrecuenciaE.Text = titW
        Me.lblDA.Text = titDA
        Me.lblDace.Text = titDAce
        Me.lblPasoAce.Text = titPace
        Me.lblFacAce.Text = titfacAce
        Me.lblNotaAce.Text = notaAce
        Me.lblRespMax.Text = titRM
        Me.lblRdespMax.Text = titRMD
        Me.lblRVeloMax.Text = titRMV
        Me.lblRacelMax.Text = titRMA
        Me.lblRfuerzaMax.Text = titRMF
        Call NameNyE2GTOOL2(ID)
        Me.lblPiso1.Text = Nudo1
        Me.lblNudo21.Text = Nudo1
        Me.lblPiso2.Text = Nudo2
        Me.lblNudo31.Text = Nudo2

        Me.lblEle11.Text = Elemento1
        Me.lblEle12.Text = Elemento1
        Me.lblEle13.Text = Elemento1
        Me.lblEle21.Text = Elemento2
        Me.lblEle22.Text = Elemento2
        Me.lblEle23.Text = Elemento2


        If ID = "ES" Then
            REM Titulo del laboratorio segun ID
            Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-ES.png"

            titLoadExample = "Cargar ejemplo"
            REM Esquema Principal
            UbicFiguraMain = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/Tools/"
            Me.FigMain.ImageUrl = UbicFiguraMain & "Dinamica_2GDL_Tool2.bmp"
            REM Figuras de los materiales
            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónES/"
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_ES.bmp"
            Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_ES.bmp"
            Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_ES.bmp"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_ES.bmp"
            Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_ES.bmp"
            Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_ES.bmp"
            Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_ES.bmp"

            Me.lblM.Text = "Masa  [Tonne =kN.s^2/m =kN/g]"
            Me.lblH.Text = "Altura entre pisos [m]"
            Me.lblEI.Text = "Rigidez [kN.m^2]"
            Me.lblA.Text = "Amortiguamiento [%]"
            Me.lblDV.Text = "Definir vibración:"
            Me.lblEscTM.Text = "Seleccionar:"
            Me.lblEscTE.Text = "Seleccionar:"


        ElseIf ID = "EN" Then
            REM Titulo del laboratorio segun ID
            Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png"

            titLoadExample = "Load example"
            REM Main Outline
            UbicFiguraMain = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/Tools/"
            Me.FigMain.ImageUrl = UbicFiguraMain & "Dinamica_2GDL_Tool2_EN.bmp"
            REM Figuras de los materiales
            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónEN/"
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_EN.bmp"
            Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_EN.bmp"
            Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_EN.bmp"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_EN.bmp"
            Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_EN.bmp"
            Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_EN.bmp"
            Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_EN.bmp"
            Me.lblM.Text = "Mass  [Tonne =kN.s^2/m =kN/g]"
            Me.lblH.Text = "Height between floors [m]"
            Me.lblEI.Text = "Stiffness [kN.m^2]"
            Me.lblA.Text = "Damping [%]"
            Me.lblDV.Text = "Define vibration:"
            Me.lblEscTM.Text = "Select:"
            Me.lblEscTE.Text = "Select:"

        End If
        REM Dimensiones de los graficos de materiales y exitación
        DimFiguras(FigMat1, 300, 300)
        DimFiguras(FigMat2, 300, 300)
        DimFiguras(FigMat3, 300, 300)
        DimFiguras(FigExi1, 300, 300)
        DimFiguras(FigExi2, 300, 300)
        DimFiguras(FigExi3, 300, 300)
        DimFiguras(FigExi4, 300, 300)
    End Sub
    REM NOMBRES DE LOS GRAFICOS

#End Region
#Region "CARGAR EJEMPLO"
    Public Sub LoadExample()
        REM Caso 1GTool1
        Me.txtM1.Text = 10
        Me.txtM2.Text = 9
        Me.txtH1.Text = 3
        Me.txtH2.Text = 2.5
        Me.txtEI1.Text = 5000
        Me.txtEI2.Text = 4000
        Me.txtA1.Text = 4
        Me.txtA2.Text = 5


        Me.txtDA.Text = 20

        Dim Fy, r, Ro
        Dim I, DI, Pmax, t1, t2, t3, Pomax, w, Dace, Pace, face
        Fy = 200
        r = 0.02
        Ro = 14

        I = 10
        DI = 11

        Pmax = 100
        t1 = 3
        t2 = 5
        t3 = 7

        Pomax = 70
        w = 10

        Dace = 10
        Pace = 0.01
        face = 9.81
        Select Case Me.DDLmatTyp.SelectedValue
            Case 0
                Select Case Me.DDLexiTyp.SelectedValue
                    Case 0
                        Me.txtI.Text = I
                        Me.txtDI.Text = DI
                    Case 1
                        Me.txtFmax.Text = Pmax
                        Me.txtT1.Text = t1
                        Me.txtT2.Text = t2
                        Me.txtT3.Text = t3
                    Case 2
                        Me.txtFo.Text = Pomax
                        Me.txtWa.Text = w
                    Case 3
                        Me.txtdAC.Text = Dace
                        Me.txtpasoAC.Text = Pace
                        Me.txtfacAC.Text = face
                        If ID = "ES" Then
                            Me.lblMensaje.Text = "Cargue un acelerograma por favor"
                            'MsgBox("Cargue un acelerograma por favor", MsgBoxStyle.Information, "INFORMACION")
                        ElseIf ID = "EN" Then
                            Me.lblMensaje.Text = "Please load Acceleration record"
                            '    MsgBox("Please load Acceleration record", MsgBoxStyle.Information, "INFORMATION")
                        End If
                End Select
            Case 1
                Me.txtFy1.Text = Fy
                Me.txtr1.Text = r
                Me.txtFy2.Text = Fy - 100
                Me.txtr2.Text = r

                Select Case Me.DDLexiTyp.SelectedValue
                    Case 0
                        Me.txtI.Text = I
                        Me.txtDI.Text = DI
                    Case 1
                        Me.txtFmax.Text = Pmax
                        Me.txtT1.Text = t1
                        Me.txtT2.Text = t2
                        Me.txtT3.Text = t3
                    Case 2
                        Me.txtFo.Text = Pomax
                        Me.txtWa.Text = w
                    Case 3
                        Me.txtdAC.Text = Dace
                        Me.txtpasoAC.Text = Pace
                        Me.txtfacAC.Text = face
                        If ID = "ES" Then
                            Me.lblMensaje.Text = "Cargue un acelerograma por favor"
                            'MsgBox("Cargue un acelerograma por favor", MsgBoxStyle.Information, "INFORMACION")
                        ElseIf ID = "EN" Then
                            Me.lblMensaje.Text = "Please load Acceleration record"
                            '    MsgBox("Please load Acceleration record", MsgBoxStyle.Information, "INFORMATION")
                        End If
                End Select
            Case 2
                Me.txtFy1M3.Text = Fy
                Me.txtr1M3.Text = r
                Me.txtFy2M3.Text = Fy - 100
                Me.txtr2M3.Text = r
                Me.txtRo1.Text = Ro + 2
                Me.txtRo2.Text = Ro

                Select Case Me.DDLexiTyp.SelectedValue
                    Case 0
                        Me.txtI.Text = I
                        Me.txtDI.Text = DI
                    Case 1
                        Me.txtFmax.Text = Pmax
                        Me.txtT1.Text = t1
                        Me.txtT2.Text = t2
                        Me.txtT3.Text = t3
                    Case 2
                        Me.txtFo.Text = Pomax
                        Me.txtWa.Text = w
                    Case 3
                        Me.txtdAC.Text = Dace
                        Me.txtpasoAC.Text = Pace
                        Me.txtfacAC.Text = face
                        If ID = "ES" Then
                            Me.lblMensaje.Text = "Cargue un acelerograma por favor"
                            'MsgBox("Cargue un acelerograma por favor", MsgBoxStyle.Information, "INFORMACION")
                        ElseIf ID = "EN" Then
                            Me.lblMensaje.Text = "Please load Acceleration record"
                            '    MsgBox("Please load Acceleration record", MsgBoxStyle.Information, "INFORMATION")
                        End If
                End Select


        End Select
        lblMensCE.Visible = True
        If ID = "ES" Then
            lblMensCE.Text = "LISTO!!"
            Me.lblLoadExample.Text = "Ejemplo cargado:"
        ElseIf ID = "EN" Then
            lblMensCE.Text = "OK!!"
            Me.lblLoadExample.Text = "Loaded example:"
        End If
        Me.lblError.Visible = False
        PrepararMarco()
    End Sub

    Protected Sub ibtnLoadExample_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnLoadExample.Click
        Call LoadExample()

    End Sub
#End Region
#Region "ENCERAR DATOS"
    Public Sub ClearData()
        REM Caso 1GTool1
        Me.txtM1.Text = Nothing
        Me.txtM2.Text = Nothing
        Me.txtH1.Text = Nothing
        Me.txtH2.Text = Nothing
        Me.txtEI1.Text = Nothing
        Me.txtEI2.Text = Nothing
        Me.txtA1.Text = Nothing
        Me.txtA2.Text = Nothing


        Me.txtDA.Text = Nothing

        Dim Fy, r, Ro
        Dim I, DI, Pmax, t1, t2, t3, Pomax, w, Dace, Pace, face
        Fy = Nothing
        r = Nothing
        Ro = Nothing

        I = Nothing
        DI = Nothing

        Pmax = Nothing
        t1 = Nothing
        t2 = Nothing
        t3 = Nothing

        Pomax = Nothing
        w = Nothing

        Dace = Nothing
        Pace = Nothing
        face = Nothing
       
        Me.txtI.Text = I
        Me.txtDI.Text = DI

        Me.txtFmax.Text = Pmax
        Me.txtT1.Text = t1
        Me.txtT2.Text = t2
        Me.txtT3.Text = t3

        Me.txtFo.Text = Pomax
        Me.txtWa.Text = w

        Me.txtdAC.Text = Dace
        Me.txtpasoAC.Text = Pace
        Me.txtfacAC.Text = face
        

        Me.txtFy1.Text = Fy
        Me.txtr1.Text = r
        Me.txtFy2.Text = Fy
        Me.txtr2.Text = r

        
        Me.txtFy1M3.Text = Fy
        Me.txtr1M3.Text = r
        Me.txtFy2M3.Text = Fy
        Me.txtr2M3.Text = r
        Me.txtRo1.Text = Ro
        Me.txtRo2.Text = Ro

        txtXmax1.Text = Nothing
        txtXomax1.Text = Nothing
        txtXoomax1.Text = Nothing
        txtFomax1.Text = Nothing
        lblXmax1.Text = Nothing
        lblXoMax1.Text = Nothing
        lblXooMax1.Text = Nothing
        lblFomax1.Text = Nothing

        txtXmax2.Text = Nothing
        txtXoMax2.Text = Nothing
        txtXooMax2.Text = Nothing
        txtFomax2.Text = Nothing
        lblXmax2.Text = Nothing
        lblXoMax2.Text = Nothing
        lblXooMax2.Text = Nothing
        lblFoMax2.Text = Nothing
       
        lblMensCE.Visible = False

        PrepararMarco()
        Me.lblMensCE.Visible = False
    End Sub

#End Region


End Class
