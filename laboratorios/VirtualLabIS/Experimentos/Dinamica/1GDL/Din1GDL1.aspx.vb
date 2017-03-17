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





Partial Class VirtualLabIS_Experimentos_Dinamica_1GDL_Din1GDL1
    Inherits System.Web.UI.Page
#Region "VARIABLES"
    Dim YaHayGraficoAS As Boolean
    REM TIPO DE MATERIAL:
    Public Fy, r, E, Ro, cR1, cR2 As String
    REM TIPO DE EXCITACION:
    REM Lineal
    REM TriLineal
    Public Fmax As Object
    Public t1, t2, t3 As Double
    REM Sinusoidal
    Public Fo, wa As String
    REM Acelerograma
    Public Shared dAC, pasoAC, facAC As String
    REM Numero de test
    Dim nserie1Gtool1, nserieAS1Gtool1 As Integer
    REM Dim MGDesp(100000, 1, 0), MGVelo(100000, 1, 0), MGAce(100000, 1, 0), MGForce(100000, 1, 0), MGFvsD(100000, 1, 0) As Double
    REM NUMERO DE DATOS
    Dim NDG(), NDE(), NDAcSoil() As Integer
    Dim MGDesp(100000, 1, 0), MGVelo(100000, 1, 0), MGAce(100000, 1, 0), MGForce(100000, 1, 0), MGFvsD(100000, 1, 0) As Double
    REM TIPO DE EXCITACIÓN
    Dim MGExiTyp(100000, 1, 0), MExiTyp(,) As Double
    REM ACELERACION DEL SUELO
    Dim MGacSoil(100000, 1, 0), MacSoil(,) As Double
    REM RESPUESTA MAXIMA
    Dim MRespMax(7, 0) As Double
    Dim GEN As General = New General
    REM RECOLECTA TODOS LOS DATOS
    Public VectorDatos(25) As Object
    Public PasoQ As Double
    Public NameTool As String
    Dim I, DI As Double
    Public u As Integer
    Dim namefileD, namefileV, namefileA, namefileF As String
    REM ANALISIS ACTUAL
    Public MDesp(,), MVelo(,), MAce(,), MForce(,), MFvsD(,) As Double
    REM Matriz de respuestas maximas
    Dim UbicFiguras As String
    Dim UbicFiguraMain As String
    REM DIRECTORIOS
    REM para escribir tcl
    Public DirUsuarioFDE, DirUsuarioResulatdos, DirUsuarioAcelerogramas, DirBat As String
    REM para leer respuestas
    Public DirUsuarioReadResultados, DirBatRun As String
    Public DirTCL, NameTcl, DirACE As String
    REM ________________________________
    REM iDIOMA
    Shared getIdioma As String

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
    Public titRM As String
    Public titRMD As String
    Public titRMV As String
    Public titRMA As String
    Public titRMF As String

    REM NOMBRES DE LOS GRAFICOS
    Public titGRAF As String
    Public NombreGraficoAS As String

    Public NombreGraficoExi As String


    Public NombreGrafico1 As String
    Public NombreGrafico1b As String


    Public NombreGrafico2 As String
    Public NombreGrafico2b As String

    Public NombreGrafico3 As String
    Public NombreGrafico3b As String
    Public NombreGrafico4 As String
    Public NombreGrafico4b As String

    Public NombreGrafico5 As String
    Public NombreGrafico5b As String
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
#End Region
#Region "CONTROL DE ERRORES"

    Public Sub VerificarDatos()
        MensError = ""
        HayError = False
        VectorDatos(0) = Me.txtT.Text
        VectorDatos(1) = Me.txtM.Text
        If Val(VectorDatos(1)) = 0 Then
            If ID = "ES" Then
                MensError = "¡La masa no puede ser cero!"
            Else
                MensError = "The mass can not be zero!"
            End If
            HayError = True
            GoTo mensaje
        End If

        VectorDatos(2) = Me.txtA.Text
        VectorDatos(3) = Me.txtDA.Text
        Select Case Me.DDLmatTyp.SelectedValue
            Case 0
                REM ELASTICO
                VectorDatos(4) = 1
                VectorDatos(5) = 1
                VectorDatos(6) = 1
                VectorDatos(7) = 1
                VectorDatos(8) = 1
            Case 1
                REM Bilineal 1
                VectorDatos(4) = Me.txtFy.Text
                VectorDatos(5) = Me.txtr.Text
                VectorDatos(6) = 1
                VectorDatos(7) = 1
                VectorDatos(8) = 1

            Case 2
                REM Bilineal 2
                VectorDatos(4) = Me.txtFy1.Text
                VectorDatos(5) = Me.txtr1.Text
                VectorDatos(6) = Me.txtRo.Text
                VectorDatos(7) = "0.925"
                VectorDatos(8) = "0.15"

        End Select



        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                REM Función Lineal
                VectorDatos(9) = Me.txtI.Text
                VectorDatos(10) = Me.txtDI.Text
                VectorDatos(11) = 1
                VectorDatos(12) = 1
            Case 1
                REM 
                VectorDatos(9) = Me.txtFmax.Text
                VectorDatos(10) = Me.txtT1.Text
                VectorDatos(11) = Me.txtT2.Text
                VectorDatos(12) = Me.txtT3.Text

            Case 2
                REM EXCITACION: Función Sinusoidal"
                VectorDatos(9) = Me.txtFo.Text
                VectorDatos(10) = Me.txtWa.Text
                VectorDatos(11) = 1
                VectorDatos(12) = 1
            Case 3
                REM Acelerograma
                VectorDatos(9) = Me.txtdAC.Text
                VectorDatos(10) = Me.txtpasoAC.Text
                VectorDatos(11) = Me.txtfacAC.Text
                VectorDatos(12) = 1
        End Select

        For i As Integer = 0 To 12
            If VectorDatos(i) = Nothing Then
                If ID = "ES" Then
                    MensError = "Error: Faltan datos"
                ElseIf ID = "EN" Then
                    MensError = "Error: Missing data"
                End If


            Else
                If IsNumeric(VectorDatos(i)) = False Then
                    If ID = "ES" Then
                        MensError = "Error: Datos incorrectos"
                    ElseIf ID = "EN" Then
                        MensError = "Error: Incorrect data"
                    End If
                    HayError = True
                    GoTo mensaje
                End If

            End If

        Next

mensaje:
        If HayError = False Then
            Select Case Me.DDLexiTyp.SelectedValue
                Case 3
                    If AceLoad = False Then
                        If ID = "ES" Then
                            lblMensaje.Text = "Error: Aún no se carga acelerograma"
                        ElseIf ID = "EN" Then
                            lblMensaje.Text = "Error: Accelerogram is not loaded yet"
                        End If
                        HayError = True
                    End If
            End Select
        End If
        Me.lblError.Visible = True
        Me.lblError.Text = MensError

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
    Public Sub GraficarTodo()
        nserie1Gtool1 = ViewState("ns1")
        nserieAS1Gtool1 = ViewState("nsAS1")

        REM GRAFICO LOS RESULTADOS
        On Error Resume Next
        REM Grafica Desplazamiento Vs.Tiempo
        MGDesp = Session("MGDespS") : MGVelo = Session("MGVeloS") : MGAce = Session("MGAceS") : MGForce = Session("MGForceS") : MGFvsD = Session("MGFvsDS")
        MGExiTyp = Session("MGExiTypS") : MGacSoil = Session("MGacSoilS")
        NDG = ViewState("NDG_S") : NDE = ViewState("NDES") : NDAcSoil = ViewState("NDAcSoilS")

        Call GEN.subGraficarXY(XYChart_Grafica1, MGDesp, wcdDespVsTime, NombreGrafico1, ejex1, ejey1, True, NDG, nserie1Gtool1)
        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica2, MGVelo, wcdVeloVsTime, NombreGrafico2, ejex2, ejey2, True, NDG, nserie1Gtool1)
        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica3, MGAce, wcdAceVsTime, NombreGrafico3, ejex3, ejey3, True, NDG, nserie1Gtool1)
        REM Grafica Fuerza Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica4, MGForce, wcdForceVsTime, NombreGrafico4, ejex4, ejey4, True, NDG, nserie1Gtool1)
        REM Grafica Fuerza Vs.Desplazamiento
        Call GEN.subGraficarXY(XYChart_Grafica5, MGFvsD, wcdFvsD, NombreGrafico5, ejex5, ejey5, False, NDG, nserie1Gtool1)


        Call GEN.subGraficarXY(XYChart_Grafica6, MGExiTyp, wcdFuncionFuerza, NombreGraficoExi, ejexExi, ejeyExi, True, NDE, nserie1Gtool1)
        REM grafico la aceleración del suelo
        Call GEN.subGraficarXY(XYChart_Grafica7, MGacSoil, wcdAcSoil, NombreGraficoAS, ejexExi, ejeyAS, True, NDAcSoil, nserieAS1Gtool1)


        YaHayGrafico = True
        ViewState("ns1") = ViewState("ns1") + 1
        RedimMat()

    End Sub
#End Region
#Region "Escritura de TCL"
    ''' <summary>
    ''' Es el procedimeinto principal
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Main()
        NameTcl = NameTool & usuario & ".tcl"
        Dim CrearArchivo As String = DirTCL & NameTcl
        WriteFile(DirTCL, NameTcl)
    End Sub
    ''' <summary>
    ''' Escribe el archivo
    ''' </summary>
    ''' <param name="UbicacionFile"></param>
    ''' <param name="NombreFile"></param>
    ''' <remarks></remarks>

    Public Sub WriteFile(ByVal UbicacionFile As String, ByVal NombreFile As String)
        REM Borro el archivo que ya estaba creado:
        Dim CrearArchivo As String = UbicacionFile & NombreFile
        File.Delete(UbicacionFile & NombreFile)
        REM Hago uso del archivo
        Using w As StreamWriter = File.AppendText(UbicacionFile & NombreFile)
            REM Etiqueta del ejercicio
            w.WriteLine("######################################################################################")
            w.WriteLine("#" & NombreFile & "                                                                  #")
            w.WriteLine("#Analisis dinamico de  una estructura en solo grado de libertad 1GDL                 #")
            w.WriteLine("#Unidades: kN, m, s                                                                  #")
            w.WriteLine("######################################################################################")
            w.WriteLine("{0} {1}", "wipe", ";# Este comando borra todos los objetos existentes en el interpretador Tcl")
            REM HASTA AQUI PREPARO A OPENSEES PARA EL ANALISIS
            REM DEFINO CONSTANTES EN OPENSEES
            w.WriteLine("#DEFINICION DE CONSTANTES")
            w.WriteLine("set pi [expr acos(-1.0)]")
            REM AHORA RECEPTO LOS DATOS PARA USARLOS EN OPENSEES
            REM DATOS GENERALES: T, m , A, DA 
            Dim T, m, A, DA
            Call inputDatosG()
            T = ViewState("Ts")
            m = ViewState("ms")
            A = ViewState("As")
            DA = ViewState("DAs")
            w.WriteLine("#RECEPCION DE DATOS ##################################################################")
            w.WriteLine("{0} {1} {2}", "set T", T, ";#Periodo")
            w.WriteLine("{0} {1} {2}", "set m", m, ";#Masa")
            w.WriteLine("{0} {1} {2}", "set Damp", A, ";#Amortiguamiento")
            w.WriteLine("set damp [expr $Damp*pow(100,-1)]")
            w.WriteLine("{0} {1} {2}", "set duracionA", DA, ";#Duración del analisis")
            REM CREACION DEL MODELO
            w.WriteLine("#EMPIEZO A CREAR EL MODELO ###########################################################")
            w.WriteLine("model basic -ndm 2 -ndf 2      ;# 2 dimenciones; 2 Grados de Libertad (GDL) por nudo")
            w.WriteLine("# Se define la geometría -------------------------------------------------------------")
            w.WriteLine("# Coordenadas de los nudos")
            w.WriteLine("#    n x y")
            w.WriteLine("node 1 0 0")
            w.WriteLine("node 2 1 0")
            w.WriteLine("# Se empotra el nudo 1 ")
            w.WriteLine("#   n 1 2 ")
            w.WriteLine("fix 1 1 1")
            w.WriteLine("fix 2 0 1 ")
            w.WriteLine("# Se asigna una masa en Tonne (kN/g) al nudo 2 en la dirección X")
            w.WriteLine("#    n  1   2")
            w.WriteLine("mass 2 $m 1e-6")
            w.WriteLine("# Definicion de Elementos   ------------------------------------------------------")
            w.WriteLine("# Se crea un elemento truss entre los nudos 1 y 2")
            w.WriteLine("# Al elemento elástico se le asigna un area de 1 m2")
            w.WriteLine("#Calculo el modulo de elasticidad")
            w.WriteLine("set E [expr (4*$m *pow($pi,2))/(pow($T,2))]")

            REM ESCRIBIR SEGUN EL TIPO DE MATERIAL ESCOGIDO
            w.WriteLine(" ")
            Select Case Me.DDLmatTyp.SelectedValue
                Case 0
                    REM Bilineal 1
                    w.WriteLine("{0} {1} {2}", "set TagMaterial", 0, ";#Etiqueta")
                    w.WriteLine("# MATERIAL: Elastico")
                    w.WriteLine("uniaxialMaterial Elastic  $TagMaterial $E")
                Case 1
                    REM Bilineal 1
                    w.WriteLine("# MATERIAL: Bilineal 1")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial", 1, ";#Etiqueta")
                    Dim Fy, r
                    Fy = Me.txtFy.Text
                    r = Me.txtr.Text
                    w.WriteLine("{0} {1} {2}", "set Fy", Fy, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r", r, ";#Coeficiente")
                    w.WriteLine("uniaxialMaterial Steel01 $TagMaterial $Fy $E $r")
                Case 2
                    REM Bilineal 1
                    w.WriteLine("# MATERIAL: Bilineal 2")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial", 2, ";#Etiqueta")
                    Dim Fy, r
                    Fy = Me.txtFy1.Text
                    r = Me.txtr1.Text
                    Ro = Me.txtRo.Text
                    cR1 = "0.925"
                    cR2 = "0.15"
                    w.WriteLine("{0} {1} {2}", "set Fy", Fy, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r", r, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Ro", Ro, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set cR1", cR1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set cR2", cR2, ";#Coeficiente")
                    w.WriteLine("uniaxialMaterial Steel02 $TagMaterial $Fy $E $r $Ro $cR1 $cR2")
            End Select
            w.WriteLine("#Defino el elemento")
            w.WriteLine("#             nele ni nj  Area TagMaterial")
            w.WriteLine("element truss 1 1  2 1  $TagMaterial")
            w.WriteLine("#MODELO CREADO")
            w.WriteLine(" ")
            w.WriteLine("#VIBRACIÓN FORZADA ############################")
            w.WriteLine(" set pasoA [expr $T*pow(30,-1)]")
            Select Case Me.DDLexiTyp.SelectedValue
                Case 0
                    GEN.WritefCargaL(DirUsuarioFDE, "FacDforceCL.txt")
                    REM Función Lineal
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
                    w.WriteLine("}")
                    w.WriteLine("#LA CARGA FUE DEFINIDA###########################################################")

                Case 1
                    REM Bilineal 1
                    w.WriteLine("# EXCITACION: Función Trilineal")
                    Fmax = Me.txtFmax.Text
                    Dim t2, t3
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
                    w.WriteLine("}")
                Case 3
                    REM Bilineal 1
                    w.WriteLine("# EXCITACION: Acelerograma")
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

            REM REALIZO EL ANALISIS DINAMICO:
            w.WriteLine(" ")
            w.WriteLine(" #REALIZO EL ANALISIS DINAMICO")
            w.WriteLine("constraints Plain")
            w.WriteLine("numberer Plain")
            w.WriteLine("system BandGeneral")
            w.WriteLine("test NormDispIncr 1.0e-5 6")
            w.WriteLine("algorithm Newton")
            w.WriteLine("set alphaM [expr 4*$pi*$damp*pow($T,-1)]")
            w.WriteLine("integrator Newmark 0.5 0.25 $alphaM 0 0 0")
            w.WriteLine("analysis Transient")
            w.WriteLine("#Guardo los resultados")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Desplazamiento.out " & " -time -node 2 -dof 1 disp")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Velocidad.out " & " -time -node 2 -dof 1 vel")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Aceleracion.out " & " -time -node 2 -dof 1 accel")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza.out " & " -time -ele 1  localForce")
            w.WriteLine("#Pido los resultados segun la duración del analisis")
            w.WriteLine("set npuntos [format ""%.0f"" [ expr $duracionA*pow($pasoA,-1)]]")
            w.WriteLine("analyze $npuntos $pasoA")
            w.WriteLine("exit")
            REM Update the underlying file.
            w.Flush()
            REM Close the writer and underlying file.
            w.Close()
        End Using


    End Sub

#End Region
#Region "EVENTOS PROTEGIDOS"
    ''' <summary>
    ''' CUANDO SE INICIA LA HERRAMIENTA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InicioTool()
        REM Creo un directorio para el usuario__________________________________
        REM Detecto el usuario
        usuario = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id.ToString
        REM Nombre de la herramienta
        NameTool = "Din1GDL"
        REM creo directorio
        DirUsuarioFDE = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/FactoresDE/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioFDE)
        DirUsuarioResulatdos = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Resultados/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioResulatdos)
        DirUsuarioAcelerogramas = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Acelerogramas/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioAcelerogramas)
        DirBat = "C:/vlee/Dinamica/" & usuario & "/BATCHS/"
        My.Computer.FileSystem.CreateDirectory(DirBat)

        REM ubicacion de los TCL
        DirTCL = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\"
        DirUsuarioReadResultados = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Resultados\"
        DirBatRun = "C:\vlee\Dinamica\" & usuario & "\BATCHS\"
        DirACE = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Acelerogramas\"
        REM ______________________________________________________________________
    End Sub
    ''' <summary>
    ''' Ejecutamos la herramienta Dinamica 1GDL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ibtnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ibtnRun.Click
        lblMensCE.Visible = False
        nserie1Gtool1 = ViewState("ns1")
        Select Case Me.DDLborrarA.SelectedValue
            Case 0
                Call RunDinamica1GDL_Tool1()
        End Select
        If YaHayGrafico = True And nserie1Gtool1 >= 0 Then
            Select Case Me.DDLborrarA.SelectedValue
                Case 1
                    ViewState("ns1") = ViewState("ns1") - 2
                    nserie1Gtool1 = ViewState("ns1")
                    YaHayGraficoAS = ViewState("siGAS")
                    If YaHayGraficoAS = True And nserieAS1Gtool1 >= 0 Then
                        ViewState("nsAS1") = ViewState("nsAS1") - 1
                        nserieAS1Gtool1 = ViewState("ns1")
                        ReDim Preserve NDAcSoil(nserieAS1Gtool1)
                    End If
                    PrepararMarco()
                    RedimMat()
                    REM ClearData()
                    GraficarTodo()
                    If nserieAS1Gtool1 >= 0 Then
                        ViewState("siGAS") = True
                    Else
                        ViewState("siGAS") = False
                    End If
                    If nserie1Gtool1 >= 0 Then
                        YaHayGrafico = True

                    Else
                        YaHayGrafico = False
                    End If
                    Me.DDLborrarA.SelectedIndex = 0
                Case 2
                    ViewState("nsAS1") = -1
                    nserie1Gtool1 = ViewState("nsAS1")
                    ViewState("ns1") = 0
                    nserie1Gtool1 = ViewState("ns1")
                    Me.DDLborrarA.SelectedIndex = 0
                    YaHayGrafico = False
                    ViewState("siGAS") = False
                    Call EncerarMat()
                    Call ClearData()
                    Call PrepararMarco()
            End Select

        End If


    End Sub
    ''' <summary>
    ''' Cargamos un acelerograma
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ibtnLoadAce_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ibtnLoadAce.Click
        Call CargarFile()
    End Sub
    ''' <summary>
    ''' Descargamos las respuestas maxima
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ibtnDescRmax_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ibtnDescRmax.Click
        Dim ge As GenerarExcell = New GenerarExcell
        'No enviamos la respuesta hasta que hemos terminado de procesar todo
        Response.Buffer = True
        'Ponemos el tipo de la respuesta al valor adecuado
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment; filename=" & namefileRM & ".xls")
        REM Escribo la tabla html y luego la tranformo a una Hoja de excel
        MRespMax = Session("MRespMaxR")
        Response.Write(ge.DoExcellRespMax_1GDL_Tool1(MRespMax, namefileRM, nserie1Gtool1, ID))
        Response.End()
    End Sub
    Protected Sub txtT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT.TextChanged
        Dim T
        T = txtT.Text
        If IsNumeric(T) = True Then
            If ID = "ES" Then
                Me.llbFT.Text = "Frecuencia = " & Round((1 / T), 2) & " Hz"
            ElseIf ID = "EN" Then
                Me.llbFT.Text = "Frequency = " & Round((1 / T), 2) & " Hz"
            End If
        End If
    End Sub
    ''' <summary>
    ''' Llama al procediemiento principal
    ''' </summary>

    Public Sub RunDinamica1GDL_Tool1()
        VerificarDatos()
        If HayError = True Then
            PrepararMarco()
            HayError = False
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

        REM Establesco los nombres de los ficheros a leer
        namefileD = "Desplazamiento.out"
        namefileV = "Velocidad.out"
        namefileA = "Aceleracion.out"
        namefileF = "Fuerza.out"
        On Error Resume Next
        Call subLeerResultados(namefileD, namefileV, namefileA, namefileF)
        REM Mostrar respuestas MAXIMAS
        Call DispRespMax()
        Call PrepararMatrices()
        Call GraficarTodo()

    End Sub
    Public Sub inputDatosG()
        Dim T, m, A
        T = CStr(Me.txtT.Text) REM periodo
        m = CStr(Me.txtM.Text) REM Masa
        A = CStr(Me.txtA.Text) REM Amortiguamiento
        DA = CStr(Me.txtDA.Text) REM Duracion del analisis
        ViewState("Ts") = T
        ViewState("ms") = m
        ViewState("As") = A
        ViewState("DAs") = DA

        On Error Resume Next
        REM Matriz de duraciones de todos los analisis
        ReDim Preserve MDA(nserie1Gtool1)
        MDA(nserie1Gtool1) = DA
    End Sub
    ''' <summary>
    ''' Carga la pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "SDOF-Dynamics"
        InicioTool()



        REM Detecto el idioma con el que estamos trabajando
        getIdioma = Request.Params("idioma")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
        If getIdioma = "es-ES" Then
            ID = "ES"
        Else
            ID = "EN"
        End If

        Call DescripciónSegunId(Me.DDLmatTyp, Me.DDLexiTyp, Me.DDLborrarA, ID)
        'Me.lblTitulo1GDLtool1.Text = Tit1Gtool1
        'lblLoadExample.Text = titLoadExample
        Call NombresLabelsTitulos()
        Call NombresLabelsDescarga()
        If Not Page.IsPostBack Then

            HayError = False
            ViewState("siGAS") = False
            ViewState("ns1") = 0
            nserie1Gtool1 = ViewState("ns1")
            ViewState("nsAS1") = -1
            nserieAS1Gtool1 = ViewState("nsAS1")
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
            Call PrepararMarco()
            Call EncerarMat()
        End If
        RedimMat()
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
    REM Procedimeintos para caragar archivo y para preparara marcos
    Public Sub CargarFile()
        On Error Resume Next
        Call GEN.subCargarArchivo(FUpLoadAC, lblMensaje, txtpasoAC, txtdAC, Me.DDLsepCol, ID, DirACE)
        REM Call CargarAcelerograma(FUpLoadAC, lblMensaje)
        Call PrepararMarco()
    End Sub
    ''' <summary>
    ''' Prepara las pantallas para luego proceder a graficar
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrepararMarco()
        establecerPropCtrlGraficos(XYChart_Grafica7, NombreGraficoAS, ejexExi, ejeyAS)
        wcdAcSoil.Image = XYChart_Grafica7.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica6, NombreGraficoExi, ejexExi, ejeyExi)
        wcdFuncionFuerza.Image = XYChart_Grafica6.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica1, NombreGrafico1, ejex1, ejey1)
        wcdDespVsTime.Image = XYChart_Grafica1.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica2, NombreGrafico2, ejex2, ejey2)
        wcdVeloVsTime.Image = XYChart_Grafica2.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica3, NombreGrafico3, ejex3, ejey3)
        wcdAceVsTime.Image = XYChart_Grafica3.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica4, NombreGrafico4, ejex4, ejey4)
        wcdForceVsTime.Image = XYChart_Grafica4.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica5, NombreGrafico5, ejex5, ejey5)
        wcdFvsD.Image = XYChart_Grafica5.makeWebImage(Chart.PNG)
    End Sub
#End Region
#Region "LECTURA DE RESULTADOS"

    ''' <summary>
    ''' Lee los resultados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subLeerResultados(ByVal nameFileD As String, ByVal nameFileV As String, ByVal nameFileA As String, ByVal nameFileF As String)

        Dim DirUsuarioR As String = DirUsuarioReadResultados
        Dim nfilas As Integer
        nfilas = 0 : nColumnas = 0
        REM Abro el archivo para calcular el número de filas y columnas totales
        Using archivo As StreamReader = New StreamReader(DirUsuarioR & nameFileD)
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
        ReDim MDesp(nfilas, nColumnas)
        ReDim MVelo(nfilas, nColumnas)
        ReDim MAce(nfilas, nColumnas)
        ReDim MForce(nfilas, nColumnas)
        ReDim MFvsD(nfilas, nColumnas)
        MDesp(0, 0) = 0
        MDesp(0, 1) = 0
        MVelo(0, 0) = 0
        MVelo(0, 1) = 0
        MAce(0, 0) = 0
        MAce(0, 1) = 0
        MForce(0, 0) = 0
        MForce(0, 1) = 0
        MFvsD(0, 0) = 0
        MFvsD(0, 1) = 0

        xmax = 0 : xomax = 0 : xoomax = 0 : Fomax = 0
        REM LEO EL ARCHIVO DE DESPLAZAMIENTOS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(DirUsuarioR & nameFileD)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MDesp(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xmax) < Abs(CDbl(MDesp(nfilas, 1))) Then
                    txmax = Abs(CDbl(MDesp(nfilas, 0)))
                    xmax = Abs(CDbl(MDesp(nfilas, 1)))

                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE VELOCIDADES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(DirUsuarioR & nameFileV)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MVelo(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xomax) < Abs(CDbl(MVelo(nfilas, 1))) Then
                    txomax = Abs(CDbl(MVelo(nfilas, 0)))
                    xomax = Abs(CDbl(MVelo(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE ACELERACIONES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(DirUsuarioR & nameFileA)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MAce(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(xoomax) < Abs(CDbl(MAce(nfilas, 1))) Then
                    txoomax = Abs(CDbl(MAce(nfilas, 0)))
                    xoomax = Abs(CDbl(MAce(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE FUERZAS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(DirUsuarioR & nameFileF)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MForce(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(Fomax) < Abs(CDbl(MForce(nfilas, 1))) Then
                    tFomax = Abs(CDbl(MForce(nfilas, 0)))
                    Fomax = Abs(CDbl(MForce(nfilas, 1)))
                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using


    End Sub
    Public Sub DispRespMax()
        nserie1Gtool1 = ViewState("ns1")
        MRespMax = Session("MRespMaxR")
        ReDim Preserve MRespMax(7, nserie1Gtool1)
        Session("MRespMaxR") = MRespMax
        MRespMax = Session("MRespMaxR")
        For j As Integer = 0 To 7
            If j = 0 Then
                MRespMax(j, nserie1Gtool1) = xmax
            ElseIf j = 1 Then
                MRespMax(j, nserie1Gtool1) = txmax
            ElseIf j = 2 Then
                MRespMax(j, nserie1Gtool1) = xomax
            ElseIf j = 3 Then
                MRespMax(j, nserie1Gtool1) = txomax
            ElseIf j = 4 Then
                MRespMax(j, nserie1Gtool1) = xoomax
            ElseIf j = 5 Then
                MRespMax(j, nserie1Gtool1) = txoomax
            ElseIf j = 6 Then
                MRespMax(j, nserie1Gtool1) = Fomax
            ElseIf j = 7 Then
                MRespMax(j, nserie1Gtool1) = tFomax
            End If
        Next j
        Session("MRespMaxR") = MRespMax
        Me.txtXmax.Text = Round(xmax, 4) : Me.lblXmax.Text = "(" & Round(txmax, 2) & " s)"
        Me.txtXomax.Text = Round(xomax, 4) : Me.lblXoMax.Text = "( " & Round(txomax, 2) & " s)"
        Me.txtXoomax.Text = Round(xoomax, 4) : Me.lblXooMax.Text = "( " & Round(txoomax, 2) & " s)"
        Me.txtFomax.Text = Round(Fomax, 4) : Me.lblFomax.Text = "( " & Round(tFomax, 2) & " s)"

    End Sub



#End Region
#Region "PREPARAR MATRICES"
    Public Sub PrepararMatrices()
        RedimMat()
        nserie1Gtool1 = ViewState("ns1")
        NDG = ViewState("NDG_S") : NDE = ViewState("NDES")
        ReDim Preserve NDG(nserie1Gtool1) REM Numero de datos del analisis
        ReDim Preserve NDE(nserie1Gtool1) REM Numero de datos de exitación
        NDG(nserie1Gtool1) = CInt(MDesp.GetUpperBound(0))

        ViewState("NDG_S") = NDG : ViewState("NDES") = NDE
        NDG = ViewState("NDG_S")


        MGDesp = Session("MGDespS")
        MGVelo = Session("MGVeloS")
        MGAce = Session("MGAceS")
        MGForce = Session("MGForceS")
        MGFvsD = Session("MGFvsDS")
        For u = 0 To NDG(nserie1Gtool1)
            REM CREO UNA MATRIZ ENTRE LA FUERZA Y EL DESPLAZAMIENTO
            MFvsD(u, 0) = MDesp(u, 1)
            MFvsD(u, 1) = MForce(u, 1)
            For j As Integer = 0 To 1
                REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                MGDesp(u, j, nserie1Gtool1) = MDesp(u, j)
                MGVelo(u, j, nserie1Gtool1) = MVelo(u, j)
                MGAce(u, j, nserie1Gtool1) = MAce(u, j)
                MGForce(u, j, nserie1Gtool1) = MForce(u, j)
                MGFvsD(u, j, nserie1Gtool1) = MFvsD(u, j)
            Next
        Next
        Session("MGDespS") = MGDesp
        Session("MGVeloS") = MGVelo
        Session("MGAceS") = MGAce
        Session("MGForceS") = MGForce
        Session("MGFvsDS") = MGFvsD


        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                I = Me.txtI.Text
                DI = Me.txtDI.Text
                ReDim MExiTyp(1, 1)
                MExiTyp(0, 0) = 0
                MExiTyp(0, 1) = 0
                MExiTyp(1, 0) = DI
                MExiTyp(1, 1) = I * DI

                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Función de fuerza lineal"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Linear force function"
                End If

            Case 1
                Fmax = Me.txtFmax.Text
                t1 = Me.txtT1.Text
                t2 = Me.txtT2.Text
                t3 = Me.txtT3.Text
                ReDim MExiTyp(3, 1)
                MExiTyp(0, 0) = 0
                MExiTyp(0, 1) = 0
                MExiTyp(1, 0) = t1
                MExiTyp(1, 1) = Fmax
                MExiTyp(2, 0) = t2
                MExiTyp(2, 1) = Fmax
                MExiTyp(3, 0) = t3
                MExiTyp(3, 1) = 0

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
                PasoExi = Ta / 20
                Dexi = 0
                Do While Dexi <= DA
                    Dexi += PasoExi
                    Ndexi += 1
                Loop
                ReDim MExiTyp(Ndexi, 1)
                Ndexi = 0
                Dexi = 0
                Do While Ndexi <= MExiTyp.GetUpperBound(0)
                    MExiTyp(Ndexi, 0) = Dexi
                    MExiTyp(Ndexi, 1) = Fo * Sin(wa * Dexi)
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

                ReDim MExiTyp(Ndexi, 1)
                ReDim MacSoil(Ndexi, 1)

                Dexi = 0
                Ndexi = 0
                Do While Ndexi <= MExiTyp.GetUpperBound(0)
                    MExiTyp(Ndexi, 0) = Dexi
                    MacSoil(Ndexi, 0) = Dexi
                    Dexi += pasoAC
                    Ndexi += 1
                Loop
                On Error Resume Next
                Dim ncAce As Integer = (Acelerograma.GetUpperBound(0) + 1) * (Acelerograma.GetUpperBound(1) + 1)
                For nf As Integer = 0 To ncAce
                    For nc As Integer = 0 To Acelerograma.GetUpperBound(1)
                        MacSoil(nf, 1) = Acelerograma(nf, nc) * facAC
                        MExiTyp(nf, 1) = Acelerograma(nf, nc) * facAC * (-10)
                        If nf = Ndexi Then Exit For
                    Next
                    If nf = Ndexi Then Exit For
                Next

                ViewState("siGAS") = True
                ViewState("nsAS1") = ViewState("nsAS1") + 1
                nserieAS1Gtool1 = ViewState("nsAS1")

                NDAcSoil = ViewState("NDAcSoilS")
                ReDim Preserve NDAcSoil(nserieAS1Gtool1)
                NDAcSoil(nserieAS1Gtool1) = CDbl(MacSoil.GetUpperBound(0))
                ViewState("NDAcSoilS") = NDAcSoil
                MGacSoil = Session("MGacSoilS")
                ReDim Preserve MGacSoil(100000, 1, nserieAS1Gtool1)
                Session("MGacSoilS") = MGacSoil
                MGacSoil = Session("MGacSoilS")
                NDAcSoil = ViewState("NDAcSoilS")
                For u = 0 To NDAcSoil(nserieAS1Gtool1)
                    For j As Integer = 0 To 1
                        REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                        MGacSoil(u, j, nserieAS1Gtool1) = MacSoil(u, j)
                    Next
                Next
                Session("MGacSoilS") = MGacSoil

                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Acelerograma"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Acceleration record"
                End If
        End Select

        NDE = ViewState("NDES")
        NDE(nserie1Gtool1) = CDbl(MExiTyp.GetUpperBound(0))
        ViewState("NDES") = NDE

        MGExiTyp = Session("MGExiTypS")
        NDE = ViewState("NDES")
        For u = 0 To NDE(nserie1Gtool1)
            For j As Integer = 0 To 1
                REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                MGExiTyp(u, j, nserie1Gtool1) = MExiTyp(u, j)
            Next
        Next
        Session("MGExiTypS") = MGExiTyp
    End Sub

    Public Sub EncerarMat()
        ViewState("ns1") = 0
        ViewState("nsAS1") = -1
        nserie1Gtool1 = ViewState("ns1")
        nserieAS1Gtool1 = ViewState("nsAS1")
        NDG = ViewState("NDG_S") : NDE = ViewState("NDES") : NDAcSoil = ViewState("NDAcSoilS")
        MGDesp = Session("MGDespS") : MGVelo = Session("MGVeloS") : MGAce = Session("MGAceS") : MGForce = Session("MGForceS")
        MGFvsD = Session("MGFvsDS") : MGExiTyp = Session("MGExiTypS") : MGacSoil = Session("MGacSoilS")
        ReDim MDA(nserie1Gtool1)
        ReDim NDG(nserie1Gtool1)
        ReDim NDE(nserie1Gtool1)
        ReDim NDAcSoil(nserieAS1Gtool1)

        ReDim MGDesp(100000, 1, nserie1Gtool1), MGVelo(100000, 1, nserie1Gtool1), MGAce(100000, 1, nserie1Gtool1), MGForce(100000, 1, nserie1Gtool1), MGFvsD(100000, 1, nserie1Gtool1)
        ReDim MDesp(0, 0), MVelo(0, 0), MAce(0, 0), MForce(0, 0), MFvsD(0, 0)
        ReDim MGExiTyp(100000, 1, nserie1Gtool1)
        ReDim MExiTyp(0, 0)
        ReDim MGacSoil(100000, 1, nserieAS1Gtool1)
        ReDim MacSoil(0, 0)
        Session("MGDespS") = MGDesp : Session("MGVeloS") = MGVelo : Session("MGAceS") = MGAce : Session("MGForceS") = MGForce : Session("MGFvsDS") = MGFvsD
        ViewState("NDG_S") = NDG : ViewState("NDES") = NDE : ViewState("NDAcSoilS") = NDAcSoil
        Session("MGExiTypS") = MGExiTyp : Session("MGacSoilS") = MGacSoil
    End Sub


    Public Sub RedimMat()
        nserie1Gtool1 = ViewState("ns1")
        MGDesp = Session("MGDespS")
        MGVelo = Session("MGVeloS")
        MGAce = Session("MGAceS")
        MGForce = Session("MGForceS")
        MGFvsD = Session("MGFvsDS")
        NDG = ViewState("NDG_S") : NDE = ViewState("NDES") : NDAcSoil = ViewState("NDAcSoilS")
        MGExiTyp = Session("MGExiTypS") : MGacSoil = Session("MGacSoilS")
        ReDim Preserve MGDesp(100000, 1, nserie1Gtool1)
        ReDim Preserve MGVelo(100000, 1, nserie1Gtool1)
        ReDim Preserve MGAce(100000, 1, nserie1Gtool1)
        ReDim Preserve MGForce(100000, 1, nserie1Gtool1)
        ReDim Preserve MGFvsD(100000, 1, nserie1Gtool1)
        ReDim Preserve MGExiTyp(100000, 1, nserie1Gtool1)
        ReDim Preserve NDG(nserie1Gtool1)
        ReDim Preserve NDE(nserie1Gtool1)
        ReDim Preserve NDAcSoil(nserieAS1Gtool1)
        Session("MGDespS") = MGDesp : Session("MGVeloS") = MGVelo : Session("MGAceS") = MGAce : Session("MGForceS") = MGForce : Session("MGFvsDS") = MGFvsD
        ViewState("NDG_S") = NDG : ViewState("NDES") = NDE : ViewState("NDAcSoilS") = NDAcSoil
        Session("MGExiTypS") = MGExiTyp : Session("MGacSoilS") = MGacSoil
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
    Protected Sub btnDownResul1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownResul1.Click,
       btnDownResul2.Click,
       btnDownResul3.Click,
       btnDownResul4.Click,
       btnDownResul5.Click,
       btnDownResul6.Click,
       btnDownResul7.Click
        nserie1Gtool1 = ViewState("ns1")
        nserieAS1Gtool1 = ViewState("nsAS1")
        MGDesp = Session("MGDespS") : MGVelo = Session("MGVeloS") : MGAce = Session("MGAceS") : MGForce = Session("MGForceS") : MGFvsD = Session("MGFvsDS")
        NDG = ViewState("NDG_S") : NDE = ViewState("NDES") : NDAcSoil = ViewState("NDAcSoilS")
        MGExiTyp = Session("MGExiTypS") : MGacSoil = Session("MGacSoilS")

        Select Case CType(sender, ImageButton).ID
            Case "btnDownResul1"
                REM grafico la aceleración del suelo
                Call DescargarResp(MGacSoil, NombreGraficoAS, ejexExi, ejeyAS, NDAcSoil, nserieAS1Gtool1)
            Case "btnDownResul2"
                REM Historia de exitación
                Call DescargarResp(MGExiTyp, NombreGraficoExi, ejexExi, ejeyExi, NDE, nserie1Gtool1)
            Case "btnDownResul3"
                REM Archivo Desplazamiento Vs.Tiempo
                Call DescargarResp(MGDesp, NombreGrafico1, ejex1, ejey1, NDG, nserie1Gtool1)
            Case "btnDownResul4"
                REM Archivo Velocidad Vs.Tiempo
                Call DescargarResp(MGVelo, NombreGrafico2, ejex2, ejey2, NDG, nserie1Gtool1)
            Case "btnDownResul5"
                REM Archivo Aceleración Vs.Tiempo
                Call DescargarResp(MGAce, NombreGrafico3, ejex3, ejey3, NDG, nserie1Gtool1)
            Case "btnDownResul6"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce, NombreGrafico4, ejex4, ejey4, NDG, nserie1Gtool1)
            Case "btnDownResul7"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD, NombreGrafico5, ejex5, ejey5, NDG, nserie1Gtool1)
        End Select

    End Sub

#End Region
#Region "DESCRIBIR VARIABLES"

    Public Sub DescripciónSegunId(ByVal ListaTM As DropDownList, ByVal ListaTE As DropDownList, ByVal ListaRUN As DropDownList, ByVal Idioma As String)
        If Idioma = "ES" Then
            Tit1Gtool1 = "ANÁLISIS DE HISTORIA EN EL TIEMPO DE UN SISTEMA DE UN GRADO DE LIBERTAD"
            titLoadExample = "Cargar ejemplo"
            namefileRM = "Respuestas Maximas"
            REM NOMBRES DE LOS GRAFICOS_________________________________________________
            titGRAF = "GRAFICAS"
            NombreGraficoAS = "Aceleración del suelo (Solo con acelerograma)"
            ejeyAS = "Aceleración [m /s" + Chr(178) & "]"
            NombreGraficoExi = "Tipo de excitación"
            ejexExi = "Tiempo [s]"
            ejeyExi = "Fuerza externa [kN]"
            NombreGrafico1 = "Desplazamiento relativo (Nudo 2)"
            NombreGrafico1b = "Desplazamiento relativo (Nudo 3)"
            ejex1 = "Tiempo [s]"
            ejey1 = "Desplazamiento [m]"
            NombreGrafico2 = "Velocidad relativa (Nudo 2)"
            NombreGrafico2b = "Velocidad relativa (Nudo 3)"
            ejex2 = "Tiempo [s]"
            ejey2 = "Velocidad [m/s]"
            NombreGrafico3 = "Aceleración relativa (Nudo 2)"
            NombreGrafico3b = "Aceleración relativa (Nudo 3)"
            ejex3 = "Tiempo [s]"
            ejey3 = "Aceleración [m/s" & Chr(178) & "]"
            NombreGrafico4 = "Fuerza interna (Elemento 1)"
            NombreGrafico4b = "Fuerza interna (Elemento 2)"
            ejex4 = "Tiempo [s]"
            ejey4 = "Fuerza interna [kN]"
            NombreGrafico5 = "Histerisis (Elemento 1)"
            NombreGrafico5b = "Histerisis (Elemento 2)"
            ejex5 = "Desplazamiento [m]"
            ejey5 = "Fuerza interna [kN]"
 _
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
            ListaRUN.Items.Item(1).Text = "Borrar el último analisis"
            ListaRUN.Items.Item(2).Text = "Borrar todos los analisis"
            REM para los labels de descarga
            DownAns = "Descargar resultados"
            ProSis = "PROPIEDADES DEL SISTEMA"
            EsquemaMain = "ESQUEMA"
            titMaterial = "TIPO DE MATERIAL"
            titExi = "TIPO DE EXCITACIÓN"
            titCtipo = "COMPORTAMIENTO TIPO"
            titAnal = "ANÁLISIS"
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
            Tit1Gtool1 = "TIME HISTORY ANALYSIS OF SINGLE DEGREE OF FREEDOM SYSTEM"
            titLoadExample = "Load example"
            namefileRM = "MAXIMUM RESPONSE"
            REM NOMBRES DE LOS GRAFICOS______________________________________________________________
            NombreGraficoAS = "Ground acceleration (Only with acceleration record)"
            ejeyAS = "Acceleration [m/s^2]"
            NombreGraficoExi = "Type of Excitation"
            ejexExi = "Time [s]"
            ejeyExi = "External force [kN]"
            REM NOMBRES DE LOS GRAFICOS
            titGRAF = "GRAPHICS"
            NombreGrafico1 = "Relative displacement (Node 2)"
            NombreGrafico1b = "Relative displacement (Node 3)"
            ejex1 = "Time [s]"
            ejey1 = "Displacement [m]"
            NombreGrafico2 = "Relative velocity (Node 2)"
            NombreGrafico2b = "Relative velocity (Node 3)"
            ejex2 = "Time [s]"
            ejey2 = "Velocity [m/s]"
            NombreGrafico3 = "Relative acceleration (Node 2)"
            NombreGrafico3b = "Relative acceleration (Node 3)"
            ejex3 = "Time [s]"
            ejey3 = "Acceleration [m/s^2]"
            NombreGrafico4 = "Internal force (Element 1)"
            NombreGrafico4b = "Internal force (Element 2)"
            ejex4 = "Time [s]"
            ejey4 = "Internal force [kN]"
            NombreGrafico5 = "Hysterisis (Element 1)"
            NombreGrafico5b = "Hysterisis (Element 2)"
            ejex5 = "Displacement [m]"
            ejey5 = "Internal force [kN]"

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
        'lblDR1.Text = DownAns
        'lblDR2.Text = DownAns
        'lblDR3.Text = DownAns
        'lblDR4.Text = DownAns
        'lblDR5.Text = DownAns
        'lblDR6.Text = DownAns
        'lblDR7.Text = DownAns
        'lblDR8.Text = DownAns
        Dim base, Altura As Single
        base = 35
        Altura = 30

        'DimFiguras(btnDownResul1, base, Altura)
        'DimFiguras(btnDownResul2, base, Altura)
        'DimFiguras(btnDownResul3, base, Altura)
        'DimFiguras(btnDownResul4, base, Altura)
        'DimFiguras(btnDownResul5, base, Altura)
        'DimFiguras(btnDownResul6, base, Altura)
        'DimFiguras(btnDownResul7, base, Altura)
        'DimFiguras(ibtnDescRmax, base, Altura)
        'DimFiguras(ibtnLoadExample, 30, 25)
    End Sub
    Public Sub NombresLabelsTitulos()
        Me.lblTE.Text = titExi
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
        Call NameNyE(ID)
        Me.lblNudo2.Text = Nudo1
        Me.lblEle1.Text = Elemento1
        REM Esquema principal
        UbicFiguraMain = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/Tools/"
        Me.FigMain.ImageUrl = UbicFiguraMain & "Dinamica_1GDL_Tool1.bmp"


        If ID = "ES" Then
            REM Titulo del laboratorio segun ID
            'Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-ES.png"

            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónES/"

            REM Figuras de los materiales
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_ES.png"
            Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_ES.png"
            Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_ES.png"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_ES.png"
            Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_ES.png"
            Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_ES.png"
            Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_ES.png"


            Me.lblM.Text = "Masa [tonnes]"
            Me.lblT.Text = "Periodo [s]"
            Me.lblA.Text = "Amortiguamiento[%]"
            Me.lblEscTM.Text = "Selecionar: "
            Me.lblEscTE.Text = "Seleccionar:"


        ElseIf ID = "EN" Then
            REM Titulo del laboratorio segun ID
            'Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png"

            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónEN/"
            REM Figuras de los materiales
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_EN.png"
            Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_EN.png"
            Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_EN.png"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_EN.png"
            Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_EN.png"
            Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_EN.png"
            Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_EN.png"
            Me.lblM.Text = "Mass  [Tonne =kN.s^2/m =kN/g]"
            Me.lblT.Text = "Period [s]"
            Me.lblA.Text = "Damping [%]"
            Me.lblEscTM.Text = "Select:"
            Me.lblEscTE.Text = "Select:"

        End If
        REM Dimensiones de los graficos de materiales y exitación
        'DimFiguras(FigMat1, 300, 300)
        'DimFiguras(FigMat2, 300, 300)
        'DimFiguras(FigMat3, 300, 300)
        'DimFiguras(FigExi1, 300, 300)
        'DimFiguras(FigExi2, 300, 300)
        'DimFiguras(FigExi3, 300, 300)
        'DimFiguras(FigExi4, 300, 300)
    End Sub

    REM NOMBRES DE LOS GRAFICOS
    REM Para el tipo de exitación
    Public Sub NameNyE(ByVal id)
        If id = "ES" Then
            Nudo1 = "Nudo 2"
            Elemento1 = "Elemento 1"
        ElseIf id = "EN" Then
            Nudo1 = "Node 2"
            Elemento1 = "Element 1"
        End If
    End Sub

#End Region
#Region "CARGAR EJEMPLO"
    Public Sub LoadExample()
        REM Caso 1GTool1
        Me.txtT.Text = 0.2
        Me.txtM.Text = 100
        Me.txtA.Text = 5
        Me.txtDA.Text = 20
        Dim Fy, r, Ro
        Dim I, DI, Pmax, t1, t2, t3, Pomax, w, Dace, Pace, face
        Fy = 100
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
                Me.txtFy.Text = Fy
                Me.txtr.Text = r
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
                Me.txtFy1.Text = Fy
                Me.txtr1.Text = r
                Me.txtRo.Text = Ro

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
            'Me.lblLoadExample.Text = "Ejemplo cargado:"
        ElseIf ID = "EN" Then
            lblMensCE.Text = "OK!!"
            'Me.lblLoadExample.Text = "Loaded example:"
        End If
        Me.lblError.Visible = False
        PrepararMarco()
    End Sub


    Protected Sub ibtnLoadExample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ibtnLoadExample.Click
        Call LoadExample()

    End Sub
#End Region
#Region "ENCERAR DATOS"
    Public Sub ClearData()
        REM Caso 1GTool1
        Me.txtT.Text = Nothing
        Me.txtM.Text = Nothing
        Me.txtA.Text = Nothing
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

        Me.txtFy.Text = Fy
        Me.txtr.Text = r

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
        Me.txtRo.Text = Ro

        txtXmax.Text = Nothing
        txtXomax.Text = Nothing
        txtXoomax.Text = Nothing
        txtFomax.Text = Nothing
        lblXmax.Text = Nothing
        lblXoMax.Text = Nothing
        lblXooMax.Text = Nothing
        lblFomax.Text = Nothing

        Me.lblError.Visible = False
        Me.lblMensCE.Visible = False
    End Sub



#End Region



End Class

