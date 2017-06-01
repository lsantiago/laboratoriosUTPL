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

Partial Class VirtualLabIS_Experimentos_Dinamica_2GDL_Tool1_Dinamica_2GDL1

    Inherits System.Web.UI.Page



#Region "VARIABLES"
    REM numero de test
    REM NUMERO DE SERIE
    Dim nserie2Gtool1, nserieAS2Gtool1 As Integer
    REM TODOS LOS ANALISIS
    Dim MGDesp1(100000, 1, 0), MGVelo1(100000, 1, 0), MGAce1(100000, 1, 0), MGForce1(100000, 1, 0), MGForce3(100000, 1, 0), MGFvsD1(100000, 1, 0), MGFvsD3(100000, 1, 0) As Double
    Dim MGDesp2(100000, 1, 0), MGVelo2(100000, 1, 0), MGAce2(100000, 1, 0), MGForce2(100000, 1, 0), MGForce4(100000, 1, 0), MGFvsD2(100000, 1, 0), MGFvsD4(100000, 1, 0) As Double

    REM TIPO DE EXCITACIÓN
    Dim MGExiTypX(100000, 1, 0), MExiTypX(,) As Double
    REM ACELERACION DEL SUELO
    Dim MGacSoilX(100000, 1, 0), MacSoilX(,) As Double
    Dim MRM_2G_tool1(19, 0) As Double
    REM NUMERO DE DATOS
    Dim NDG1(), NDG2(), NDEX(), NDAcSoilX() As Integer
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
    REM DATOS GENERALES:
    Public m1, m2, k1, k2, c1, c2, TagMaterial1, TagMaterial2, TagMaterial11, TagMaterial12, TagMaterial21, TagMaterial22
    Public Damp1, Damp2, H1, H2, EI1, EI2
    REM TIPO DE MATERIAL:
    Public Fy1, r1, Fy2, r2, E1, E2, Ro1, Ro2 As String
    REM Nombres de los archivos de resulatdos
    Dim namefileD1, namefileV1, namefileA1, namefileF1, namefileF3, namefileD2, namefileV2, namefileA2, namefileF2, namefileF4 As String
    Public MDesp1(,), MVelo1(,), MAce1(,), MForce1(,), MForce3(,), MFvsD1(,), MFvsD3(,) As Double
    Public MDesp2(,), MVelo2(,), MAce2(,), MForce2(,), MForce4(,), MFvsD2(,), MFvsD4(,) As Double
    REM FIGURAS
    Dim UbicFiguras As String
    Dim UbicFiguraMain As String
    REM DIRECTORIOS
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
    Public NombreGraficoAS1 As String

    Public NombreGraficoExi As String
    Public NombreGrafico1 As String
    Public NombreGrafico1b As String

    Public ejex1 As String
    Public ejey1 As String

    Public NombreGrafico2 As String
    Public NombreGrafico2b As String


    Public NombreGrafico3 As String
    Public NombreGrafico3b As String


    Public NombreGrafico4 As String
    Public NombreGrafico4b As String
    Public NombreGrafico41 As String
    Public NombreGrafico4b1 As String


    Public NombreGrafico5 As String
    Public NombreGrafico5b As String
    Public NombreGrafico51 As String
    Public NombreGrafico5b1 As String

    Public ejex5 As String
    Public ejey5 As String
    REM para los Nudos y elementos
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

    Public Sub NameNyE2GTOOL1(ByVal id)
        If id = "ES" Then
            Nudo1 = "Nudo 2"
            Elemento1 = "Elemento 1"
            Nudo2 = "Nudo 3"
            Elemento2 = "Elemento 2"
            ElementoR1 = "Elemento 1"
            ElementoR2 = "Elemento 2"
            ElementoA1 = "Elemento amortiguador 1"
            ElementoA2 = "Elemento amortiguador 2"
        ElseIf id = "EN" Then
            Nudo1 = "Node 2"
            Elemento1 = "Element 1"
            Nudo2 = "Node 3"
            Elemento2 = "Element 2"
            ElementoR1 = "Element 1"
            ElementoR2 = "Element 2"
            ElementoA1 = "Damper Element 1"
            ElementoA2 = "Damper Element 1"
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
        VectorDatos(3) = Me.txtK1.Text
        VectorDatos(4) = Me.txtK2.Text
        VectorDatos(5) = Me.txtC1.Text
        VectorDatos(6) = Me.txtC2.Text
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
                    MensError1 = "Error: Faltan datos"
                ElseIf ID = "EN" Then
                    MensError1 = "Error: Missing data"
                End If
                HayError1 = True
                GoTo mensaje
            Else
                If IsNumeric(VectorDatos(i)) = False Then
                    If ID = "ES" Then
                        MensError1 = "Error: Datos incorrectos"
                    ElseIf ID = "EN" Then
                        MensError1 = "Error: Incorrect data"
                    End If
                    HayError1 = True
                    GoTo Mensaje
                End If

            End If

        Next
mensaje:
        If HayError1 = False Then
            Select Case Me.DDLexiTyp.SelectedValue
                Case 3
                    If AceLoad = False Then
                        If ID = "ES" Then
                            lblMensaje.Text = "Error: Aún no se carga acelerograma"
                        ElseIf ID = "EN" Then
                            lblMensaje.Text = "Error: Accelerogram is not loaded yet"
                        End If
                        HayError1 = True
                    End If
            End Select
        End If
        Me.lblError.Visible = True
        Me.lblError.Text = MensError1

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

    REM aunmento 4 graficas mas
    Dim XYChart_Grafica13 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica14 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica15 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico
    Dim XYChart_Grafica16 As XYChart = New XYChart(intAnchoGraficas, intAltoGraficas, intColorFondo, intColorFondo, 0) 'XYChart para el primer gráfico


    Public Sub GraficarTodo()
        nserie2Gtool1 = ViewState("ns2")
        nserieAS2Gtool1 = ViewState("nsAS2")
        MGExiTypX = Session("MGExiTypXAS") : MGacSoilX = Session("MGacSoilXAS")
        MGDesp1 = Session("MGDesp1S") : MGVelo1 = Session("MGVelo1S") : MGAce1 = Session("MGAce1S") : MGForce1 = Session("MGForce1S") : MGForce3 = Session("MGForce3S")
        MGDesp2 = Session("MGDesp2S") : MGVelo2 = Session("MGVelo2S") : MGAce2 = Session("MGAce2S") : MGForce2 = Session("MGForce2S") : MGForce4 = Session("MGForce4S")
        Session("MGFvsD1S") = MGFvsD1 : Session("MGFvsD2S") = MGFvsD2 : Session("MGFvsD3S") = MGFvsD3 : Session("MGFvsD4S") = MGFvsD4
        NDG1 = ViewState("NDG1S") : NDG2 = ViewState("NDG2S")
        NDEX = ViewState("NDEXS") : NDAcSoilX = ViewState("NDAcSoilXS")
        On Error Resume Next
        REM grafico la aceleración del suelo
        Call GEN.subGraficarXY(XYChart_Grafica1, MGacSoilX, wcdAcSoil, NombreGraficoAS1, ejexExi, ejeyAS, True, NDAcSoilX, nserieAS2Gtool1)
        REM Tipo de exitación
        Call GEN.subGraficarXY(XYChart_Grafica2, MGExiTypX, wcdFuncionFuerza, NombreGraficoExi, ejexExi, ejeyExi, True, NDEX, nserie2Gtool1)

        REM Grafica Desplazamiento Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica3, MGDesp1, wcdDespVsTime1, NombreGrafico1, ejex1, ejey1, True, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica4, MGDesp2, wcdDespVsTime2, NombreGrafico1b, ejex1, ejey1, True, NDG2, nserie2Gtool1)

        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica5, MGVelo1, wcdVeloVsTime1, NombreGrafico2, ejex2, ejey2, True, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica6, MGVelo2, wcdVeloVsTime2, NombreGrafico2b, ejex2, ejey2, True, NDG2, nserie2Gtool1)
        REM Grafica Velocidad Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica7, MGAce1, wcdAceVsTime1, NombreGrafico3, ejex3, ejey3, True, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica8, MGAce2, wcdAceVsTime2, NombreGrafico3b, ejex3, ejey3, True, NDG2, nserie2Gtool1)

        REM Grafica Fuerza Vs.Tiempo
        Call GEN.subGraficarXY(XYChart_Grafica9, MGForce1, wcdForceVsTime1, NombreGrafico4, ejex4, ejey4, True, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica10, MGForce2, wcdForceVsTime2, NombreGrafico4b, ejex4, ejey4, True, NDG2, nserie2Gtool1)

        Call GEN.subGraficarXY(XYChart_Grafica11, MGForce3, wcdForceVsTime3, NombreGrafico4, ejex4, ejey4, True, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica12, MGForce4, wcdForceVsTime4, NombreGrafico4b, ejex4, ejey4, True, NDG2, nserie2Gtool1)

        REM Grafica Fuerza Vs.Desplazamiento
        Call GEN.subGraficarXY(XYChart_Grafica13, MGFvsD1, wcdFvsD1, NombreGrafico5, ejex5, ejey5, False, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica14, MGFvsD2, wcdFvsD2, NombreGrafico5b, ejex5, ejey5, False, NDG2, nserie2Gtool1)

        Call GEN.subGraficarXY(XYChart_Grafica15, MGFvsD3, wcdFvsD3, NombreGrafico5, ejex5, ejey5, False, NDG1, nserie2Gtool1)
        Call GEN.subGraficarXY(XYChart_Grafica16, MGFvsD4, wcdFvsD4, NombreGrafico5b, ejex5, ejey5, False, NDG2, nserie2Gtool1)

        REM Redimensiono las matrices para que almacenen el siguiente futuro analisis
        YaHayGrafico1 = True
        ViewState("ns2") = ViewState("ns2") + 1
        nserie2Gtool1 = ViewState("ns2")
        ReDimMat()
       
    End Sub
#End Region
#Region "Escritura de TCL"

    Public Sub inputDatosG()
        m1 = CStr(Me.txtM1.Text) REM Masa
        m2 = CStr(Me.txtM2.Text) REM Masa
        k1 = CStr(Me.txtK1.Text) REM Masa
        k2 = CStr(Me.txtK2.Text) REM Masa
        c1 = CStr(Me.txtC1.Text) REM Masa
        c2 = CStr(Me.txtC2.Text) REM Masa
        DA = CStr(Me.txtDA.Text) REM Duracion del analisis
        On Error Resume Next
        REM Matriz de duraciones de todos los analisis
        ReDim Preserve MDA(nserie2Gtool1)
        MDA(nserie2Gtool1) = DA
    End Sub

    ''' <summary>
    ''' Es el procedimeinto principal
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Main()
        NameTcl = NameTool & usuario & ".tcl"
        Dim CrearArchivo As String = DirTCL & NameTcl
        WriteFile2GDLTool1(DirTCL, NameTcl)
    End Sub
    ''' <summary>
    ''' Escribe el archivo
    ''' </summary>
    ''' <param name="UbicacionFile"></param>
    ''' <param name="NombreFile"></param>
    ''' <remarks></remarks>
    Public Sub WriteFile2GDLTool1(ByVal UbicacionFile As String, ByVal NombreFile As String)
        Dim I, DI
        REM Borro el archivo que ya estaba creado:
        File.Delete(UbicacionFile & NombreFile)
        REM Hago uso del archivo
        Using w As StreamWriter = File.AppendText(UbicacionFile & NombreFile)
            REM Etiqueta del ejercicio
            w.WriteLine("######################################################################################")
            w.WriteLine("#" & NombreFile & "                                                                  #")
            w.WriteLine("#Analisis dinamico de  una estructura de dos grados de libertad 2GDL                 #")
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
            w.WriteLine("{0} {1} {2}", "set m1", m1, ";#Masa 1")
            w.WriteLine("{0} {1} {2}", "set m2", m2, ";#Masa 2")
            w.WriteLine("{0} {1} {2}", "set k1", k1, ";#Rigidez 1")
            w.WriteLine("{0} {1} {2}", "set k2", k2, ";#Rigidez 2")
            w.WriteLine("{0} {1} {2}", "set c1", c1, ";#Constante de amortiguamiento 1")
            w.WriteLine("{0} {1} {2}", "set c2", c2, ";#Constante de amortiguamiento  2")
            w.WriteLine("{0} {1} {2}", "set duracionA", DA, ";#Duración del analisis")
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
            w.WriteLine("# Se empotra el nudo 1, del resto solo se restringe el segundo grado de libertad")
            w.WriteLine("#   n 1 2 ")
            w.WriteLine("fix 1 1 1")
            w.WriteLine("fix 2 0 1 ")
            w.WriteLine("fix 3 0 1 ")
            w.WriteLine("fix 4 0 1 ")
            w.WriteLine("# Se asigna una masa en Tonne (kN/g) al nudo 2 y 3 en la dirección X")
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
                    w.WriteLine("{0} {1} {2}", "set TagMaterial11", 11, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial12", 12, ";#Etiqueta")
                    w.WriteLine("# MATERIAL: Elastico")
                    w.WriteLine("uniaxialMaterial Elastic  $TagMaterial11 $E1")
                    w.WriteLine("uniaxialMaterial Elastic  $TagMaterial12 $E2")
                Case 1
                    REM Bilineal 1
                    w.WriteLine("# MATERIAL: Bilineal 1")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial11", 21, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial12", 22, ";#Etiqueta")
                    Fy1 = Me.txtFy1.Text
                    r1 = Me.txtr1.Text
                    Fy2 = Me.txtFy2.Text
                    r2 = Me.txtr2.Text
                    w.WriteLine("{0} {1} {2}", "set Fy1", Fy1, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r1", r1, ";#Coeficiente")
                    w.WriteLine("{0} {1} {2}", "set Fy2", Fy2, ";#Fluencia")
                    w.WriteLine("{0} {1} {2}", "set r2", r2, ";#Coeficiente")
                    w.WriteLine("uniaxialMaterial Steel01 $TagMaterial11 $Fy1 $E1 $r1")
                    w.WriteLine("uniaxialMaterial Steel01 $TagMaterial12 $Fy2 $E2 $r2")
                Case 2
                    REM Bilineal 2
                    w.WriteLine("# MATERIAL: Bilineal 2")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial11", 31, ";#Etiqueta")
                    w.WriteLine("{0} {1} {2}", "set TagMaterial12", 32, ";#Etiqueta")
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
                    w.WriteLine("uniaxialMaterial Steel02 $TagMaterial11 $Fy1 $E1 $r1 $Ro1 $cR1 $cR2")
                    w.WriteLine("uniaxialMaterial Steel02 $TagMaterial12 $Fy2 $E2 $r2 $Ro2 $cR1 $cR2")
            End Select

            w.WriteLine(" #DEFINO EL MATERIAL VISCOSO")
            w.WriteLine("set TagMaterial21 111 ;#Etiqueta")
            w.WriteLine("set TagMaterial22 222 ;#Etiqueta")
            w.WriteLine("set alpha1 1")
            w.WriteLine("set alpha2 1")
            w.WriteLine("uniaxialMaterial Viscous $TagMaterial21 $c1 $alpha1")
            w.WriteLine("uniaxialMaterial Viscous $TagMaterial22 $c2 $alpha2")

            w.WriteLine("#Defino los elementos")
            w.WriteLine("#             nele ni nj  Area TagMaterial")
            w.WriteLine("element truss 1 1  2 1  $TagMaterial11")
            w.WriteLine("element truss 2 2  3 1  $TagMaterial12")
            w.WriteLine("element truss 3 3  4 1  $TagMaterial12")

            w.WriteLine("element truss 4 1  2 1  $TagMaterial21")
            w.WriteLine("element truss 5 2  3 1  $TagMaterial22")
            w.WriteLine("element truss 6 3  4 1  $TagMaterial22")

            w.WriteLine("#MODELO CREADO")
            w.WriteLine(" ")
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
                    w.WriteLine("set dt $DuracionImp")
                    w.WriteLine("set fileName " & """" & DirUsuarioFDE & "FacDforceCL.txt""")
                    w.WriteLine("set serie1  ""Series -dt $dt -filePath $fileName""")
                    w.WriteLine("pattern Plain 1 $serie1 {")
                    w.WriteLine("#     node Fx Fy")
                    w.WriteLine("load 2 $Fmax 0")
                    w.WriteLine("}")


                    w.WriteLine("#Se aplicará la carga a intervalos iguales de tiempo")
                    w.WriteLine("# t0 F0 t1 F1")
                    w.WriteLine("#0  0  DI Fmax")
                    w.WriteLine("set dt1 $DuracionImp")
                    w.WriteLine("set fileName " & """" & DirUsuarioFDE & "FacDforceCL.txt""")
                    w.WriteLine("set serie2  ""Series -dt $dt1 -filePath $fileName""")
                    w.WriteLine("pattern Plain 2 $serie2 {")
                    w.WriteLine("#     node Fx Fy")
                    w.WriteLine("load 3 $Fmax 0")
                    w.WriteLine("}")
                    w.WriteLine("#LA CARGA FUE DEFINIDA###########################################################")

                Case 1
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
                    w.WriteLine("{0} {1} {2}", "set wa", wa, ";#Frecuencia de excitacion")
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
            w.WriteLine("test NormDispIncr 1.0e-6 6")
            w.WriteLine("algorithm Newton")
            w.WriteLine("integrator Newmark 0.5 0.25")
            w.WriteLine("analysis Transient")
            w.WriteLine("#Guardo los resultados: GDL 1")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Desplazamiento1.out " & " -time -node 2 -dof 1 disp")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Velocidad1.out " & " -time -node 2 -dof 1 vel")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Aceleracion1.out " & " -time -node 2 -dof 1 accel")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza1.out " & " -time -ele 1  localForce")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza2.out " & " -time -ele 2  localForce")

            w.WriteLine("#Guardo los resultados: GDL 2")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Desplazamiento2.out " & " -time -node 3 -dof 1 disp")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Velocidad2.out " & " -time -node 3 -dof 1 vel")
            w.WriteLine("recorder Node -file " & DirUsuarioResulatdos & "Aceleracion2.out " & " -time -node 3 -dof 1 accel")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza3.out " & " -time -ele 4  localForce")
            w.WriteLine("recorder Element -file " & DirUsuarioResulatdos & "Fuerza4.out " & " -time -ele 5  localForce")
            REM EIGENVALORES
            w.WriteLine("#EIGENVALUES")
            w.WriteLine("set eigenvalues [eigen 2]")
            w.WriteLine("set omega1 [expr sqrt([lindex $eigenvalues 0])] ;# Las frecuencias de vibracion son la raiz cuadrada de los valores propios")
            w.WriteLine("set T1 [expr 2.0*$pi*pow($omega1,-1)] ;# Periodo del primer modo de vibración2")
            w.WriteLine("set omega2 [expr sqrt([lindex $eigenvalues 1])] ;# Las frecuencias de vibracion son la raiz cuadrada de los valores propios")
            w.WriteLine("set T2 [expr 2.0*$pi*pow($omega2,-1)] ;# Periodo del primer modo de vibración2")
            w.WriteLine("set pasoA [expr $T2*pow(30,-1)]")
            w.WriteLine("set npuntos [format ""%.0f"" [ expr $duracionA*pow($pasoA,-1)]]")
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
    ''' CUNDO INICIA LA HERRAMIENTA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InicioTool()

        REM Creo un directorio para el usuario__________________________________
        REM Detecto el usuario
        usuario = VirtualLabIS.Common.Global.Clases.Usuarios.User_Id.ToString
        'usuario = "User1"
        REM Nombre de la herramienta
        NameTool = "Din2GDLtool1"
        REM creo directorio
        DirUsuarioFDE = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/FactoresDE/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioFDE)
        DirUsuarioResulatdos = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Resultados2Gtool1/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioResulatdos)
        DirUsuarioAcelerogramas = "C:/vlee/Dinamica/" & usuario & "/TCLOpenSees/Acelerogramas/"
        'Creación de los directorios
        My.Computer.FileSystem.CreateDirectory(DirUsuarioAcelerogramas)
        DirBat = "C:/vlee/Dinamica/" & usuario & "/BATCHS/"
        My.Computer.FileSystem.CreateDirectory(DirBat)

        REM ubicacion de los TCL
        DirTCL = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\"
        DirUsuarioReadResultados = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Resultados2Gtool1\"
        DirBatRun = "C:\vlee\Dinamica\" & usuario & "\BATCHS\"
        DirACE = "C:\vlee\Dinamica\" & usuario & "\TCLOpenSees\Acelerogramas\"

        REM ______________________________________________________________________
    End Sub
    ''' <summary>
    ''' Ejecutamos la herramnienta 2GDL Tool1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImageButton1.Click

        Select Case Me.DDLborrarA.SelectedValue
            Case 0
                Call RunDinamica2GDLTool1()
        End Select
        nserieAS2Gtool1 = ViewState("nsAS2")

        If YaHayGrafico1 = True And nserie2Gtool1 >= 0 Then
            PrepararMarco()
            Select Case Me.DDLborrarA.SelectedValue
                Case 1
                    If YaHayGraficoAS1 = True And nserieAS2Gtool1 >= 0 Then
                        ViewState("nsAS2") = ViewState("nsAS2") - 1
                        nserieAS2Gtool1 = ViewState("nsAS2")
                        Me.DDLborrarA.SelectedIndex = 0
                    End If
                    ViewState("ns2") = ViewState("ns2") - 2
                    nserie2Gtool1 = ViewState("ns2")
                    REM GRAFICO LOS RESULTADOS
                    Call ReDimMat()
                    REM ClearData()
                    Call GraficarTodo()
                    nserieAS2Gtool1 = ViewState("nsAS2")
                    If nserieAS2Gtool1 >= 0 Then
                        YaHayGrafico1 = True
                    Else
                        YaHayGrafico1 = False
                    End If
                    Me.DDLborrarA.SelectedIndex = 0
                Case 2
                    ViewState("ns2") = 0
                    ViewState("nsAS2") = -1
                    nserie2Gtool1 = ViewState("ns2")
                    nserieAS2Gtool1 = ViewState("nsAS2")
                    Me.DDLborrarA.SelectedIndex = 0
                    YaHayGrafico1 = False
                    Call EncerarMat()
                    Call ClearData()
                    Call PrepararMarco()
            End Select

        End If
        ReDimMat()
    End Sub
    ''' <summary>
    ''' Cargamos el acelrograma
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImageButton2.Click
        Call CargarFile()
    End Sub
    ''' <summary>
    ''' Descargamos las respuestas maximas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ImageButton14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImageButton14.Click
        nserie2Gtool1 = ViewState("ns2")
        Dim ge As GenerarExcell = New GenerarExcell
        'No enviamos la respuesta hasta que hemos terminado de procesar todo
        Response.Buffer = True
        'Ponemos el tipo de la respuesta al valor adecuado
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment; filename=" & namefileRM & ".xls")
        REM Escribo la tabla html y luego la tranformo a una Hoja de excel
        Session("MRM_2G_tool1S") = MRM_2G_tool1
        Response.Write(ge.DoExcellRespMax_2GDL_Tool1(MRM_2G_tool1, namefileRM, nserie2Gtool1, ID))
        Response.End()
    End Sub

    ''' <summary>
    ''' llama a ejecutar
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RunDinamica2GDLTool1()
        Call VerificarDatos()
        If HayError1 = True Then
            PrepararMarco()
            HayError1 = False
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
        namefileF2 = "Fuerza2.out"
        namefileD2 = "Desplazamiento2.out"
        namefileV2 = "Velocidad2.out"
        namefileA2 = "Aceleracion2.out"
        namefileF3 = "Fuerza3.out"
        namefileF4 = "Fuerza4.out"
        On Error Resume Next
        Call subLeerResultados1(namefileD1, namefileV1, namefileA1, namefileF1)
        Call subLeerResultados2(namefileD2, namefileV2, namefileA2, namefileF2)
        Call subLeerResultados3(namefileF3, namefileF4)
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
        establecerPropCtrlGraficos(XYChart_Grafica1, NombreGraficoAS1, ejexExi, ejeyAS)
        wcdAcSoil.Image = XYChart_Grafica1.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica2, NombreGraficoExi, ejexExi, ejeyExi)
        wcdFuncionFuerza.Image = XYChart_Grafica2.makeWebImage(Chart.PNG)


        establecerPropCtrlGraficos(XYChart_Grafica3, NombreGrafico1, ejex1, ejey1)
        wcdDespVsTime1.Image = XYChart_Grafica3.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica4, NombreGrafico1b, ejex1, ejey1)
        wcdDespVsTime2.Image = XYChart_Grafica4.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica5, NombreGrafico2, ejex2, ejey2)
        wcdVeloVsTime1.Image = XYChart_Grafica5.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica6, NombreGrafico2b, ejex2, ejey2)
        wcdVeloVsTime2.Image = XYChart_Grafica6.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica7, NombreGrafico3, ejex3, ejey3)
        wcdAceVsTime1.Image = XYChart_Grafica7.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica8, NombreGrafico3b, ejex3, ejey3)
        wcdAceVsTime2.Image = XYChart_Grafica8.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica9, NombreGrafico4, ejex4, ejey4)
        wcdForceVsTime1.Image = XYChart_Grafica9.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica10, NombreGrafico4b, ejex4, ejey4)
        wcdForceVsTime2.Image = XYChart_Grafica10.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica11, NombreGrafico41, ejex4, ejey4)
        wcdForceVsTime3.Image = XYChart_Grafica11.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica12, NombreGrafico4b1, ejex4, ejey4)
        wcdForceVsTime4.Image = XYChart_Grafica12.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica13, NombreGrafico5, ejex5, ejey5)
        wcdFvsD1.Image = XYChart_Grafica13.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica14, NombreGrafico5b, ejex5, ejey5)
        wcdFvsD2.Image = XYChart_Grafica14.makeWebImage(Chart.PNG)

        establecerPropCtrlGraficos(XYChart_Grafica15, NombreGrafico51, ejex5, ejey5)
        wcdFvsD3.Image = XYChart_Grafica15.makeWebImage(Chart.PNG)
        establecerPropCtrlGraficos(XYChart_Grafica16, NombreGrafico5b1, ejex5, ejey5)
        wcdFvsD4.Image = XYChart_Grafica16.makeWebImage(Chart.PNG)
        ReDimMat()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "2DOF-Dynamics"
        InicioTool()


        REM Detecto el idioma con el que estamos trabajando
        getIdioma = Request.Params("idioma")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en")
        If getIdioma = "es-ES" Then
            ID = "ES"
        Else
            ID = "EN"
        End If

        DescripciónSegunId(Me.DDLmatTyp, Me.DDLexiTyp, Me.DDLborrarA, ID)

        Call NombresLabelsTitulos()
        Call NombresLabelsDescarga()

        If Not Page.IsPostBack Then
            HayError1 = False
            ViewState("ns2") = 0
            nserie2Gtool1 = ViewState("ns2")
            ViewState("nsAS2") = -1
            nserieAS2Gtool1 = ViewState("nsAS2")
            tmaxA = 0
            facStepA = 50
            Me.FigMat1.Visible = True
            'Me.FigMat2.Visible = False
            'Me.FigMat3.Visible = False

            'Me.panBlineal1.Visible = False
            'Me.panBlineal2.Visible = False

            'Me.panFL.Visible = True : Me.FigExi1.Visible = True
            'Me.panFT.Visible = False : Me.FigExi2.Visible = False
            'Me.panFS.Visible = False : Me.FigExi3.Visible = False
            'Me.panAC.Visible = False : Me.FigExi4.Visible = False
        End If

        If Not Page.IsPostBack Then
            Call PrepararMarco()
            Call EncerarMat()
        End If
        ReDimMat()

    End Sub


    Protected Sub DDLmattyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLmatTyp.SelectedIndexChanged
        Call PrepararMarco()
        Select Case Me.DDLmatTyp.SelectedValue
            Case 0
                REM Elastico
                Me.FigMat1.Visible = True
                'Me.FigMat2.Visible = False
                'Me.FigMat3.Visible = False
                'Me.panBlineal1.Visible = False
                'Me.panBlineal2.Visible = False

            Case 1
                REM Bilineal 1
                'Me.FigMat2.Visible = True
                Me.FigMat1.Visible = False
                'Me.FigMat3.Visible = False
                'Me.panBlineal1.Visible = True
                'Me.panBlineal2.Visible = False
            Case 2
                REM Bilineal 2
                'Me.FigMat3.Visible = True
                Me.FigMat1.Visible = False
                'Me.FigMat2.Visible = False
                'Me.panBlineal2.Visible = True
                'Me.panBlineal1.Visible = False
        End Select



    End Sub
    Protected Sub DDLexityp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLexiTyp.SelectedIndexChanged

        PrepararMarco()
        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                REM Funcion Lineal
                Me.panFL.Visible = True : Me.FigExi1.Visible = True
                'Me.panFT.Visible = False : Me.FigExi2.Visible = False
                'Me.panFS.Visible = False : Me.FigExi3.Visible = False
                'Me.panAC.Visible = False : Me.FigExi4.Visible = False
            Case 1
                REM Funcion triLineal
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                'Me.panFT.Visible = True : Me.FigExi2.Visible = True
                'Me.panFS.Visible = False : Me.FigExi3.Visible = False
                'Me.panAC.Visible = False : Me.FigExi4.Visible = False
            Case 2
                REM Funcion sinusoidal
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                'Me.panFT.Visible = False : Me.FigExi2.Visible = False
                'Me.panFS.Visible = True : Me.FigExi3.Visible = True
                'Me.panAC.Visible = False : Me.FigExi4.Visible = False

            Case 3
                REM Acelerograma
                Me.panFL.Visible = False : Me.FigExi1.Visible = False
                'Me.panFT.Visible = False : Me.FigExi2.Visible = False
                'Me.panFS.Visible = False : Me.FigExi3.Visible = False
                'Me.panAC.Visible = True : Me.FigExi4.Visible = True
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

    Public Sub subLeerResultados3(ByVal nameFile1 As String, ByVal nameFile2 As String)
        Dim UbicacionFile As String
        UbicacionFile = DirUsuarioReadResultados
        Dim nfilas As Integer
        nfilas = 0 : nColumnas = 0
        REM Abro el archivo para calcular el número de filas y columnas totales
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFile1)
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

        ReDim MForce3(nfilas, nColumnas), MForce4(nfilas, nColumnas)
        ReDim MFvsD3(nfilas, nColumnas), MFvsD4(nfilas, nColumnas)


        MForce3(0, 0) = 0
        MForce3(0, 1) = 0
        MForce4(0, 0) = 0
        MForce4(0, 1) = 0

        MFvsD3(0, 0) = 0
        MFvsD3(0, 1) = 0
        MFvsD4(0, 0) = 0
        MFvsD4(0, 1) = 0

        Fomax3 = 0 : Fomax4 = 0
        REM LEO EL ARCHIVO DE DESPLAZAMIENTOS
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFile1)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MForce3(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(Fomax3) < Abs(CDbl(MForce3(nfilas, 1))) Then
                    tFomax3 = Abs(CDbl(MForce3(nfilas, 0)))
                    Fomax3 = Abs(CDbl(MForce3(nfilas, 1)))

                End If
                REM Incremento el numero de lineas
                nfilas = nfilas + 1
                strLine = archivo.ReadLine
            End While
        End Using

        REM LEO EL ARCHIVO DE VELOCIDADES
        nfilas = 0
        Using archivo As StreamReader = New StreamReader(UbicacionFile & nameFile2)
            Dim strLine = archivo.ReadLine
            While strLine IsNot Nothing 'REPETIR HASTA que la linea leida sea vacia = NOTHING.
                Dim j As Integer
                Dim strLineaAux() As String = strLine.Split(" ")
                REM Recorro el archivo recogiendo los valores de las columnas de cada linea y
                REM y los almaceno en la matriz total
                For j = 0 To nColumnas
                    MForce4(nfilas + 1, j) = strLineaAux.GetValue(j)
                Next j
                If Abs(Fomax4) < Abs(CDbl(MForce4(nfilas, 1))) Then
                    tFomax4 = Abs(CDbl(MForce4(nfilas, 0)))
                    Fomax4 = Abs(CDbl(MForce4(nfilas, 1)))
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
        Me.txtFomax3.Text = Round(Fomax3, 4) : Me.lblFomax3.Text = "(" & Round(tFomax3, 2) & " s)"

        Me.txtXmax2.Text = Round(xmax2, 4) : Me.lblXmax2.Text = "(" & Round(txmax2, 2) & " s)"
        Me.txtXoMax2.Text = Round(xomax2, 4) : Me.lblXoMax2.Text = "(" & Round(txomax2, 2) & " s)"
        Me.txtXooMax2.Text = Round(xoomax2, 4) : Me.lblXooMax2.Text = "(" & Round(txoomax2, 2) & " s)"
        Me.txtFomax2.Text = Round(Fomax2, 4) : Me.lblFoMax2.Text = "(" & Round(tFomax2, 2) & " s)"
        Me.txtFomax4.Text = Round(Fomax4, 4) : Me.lblFomax4.Text = "(" & Round(tFomax4, 2) & " s)"
        MRM_2G_tool1 = Session("MRM_2G_tool1S")
        ReDim Preserve MRM_2G_tool1(19, nserie2Gtool1)

        For j As Integer = 0 To 19
            If j = 0 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xmax1
            ElseIf j = 1 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txmax1
            ElseIf j = 2 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xomax1
            ElseIf j = 3 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txomax1
            ElseIf j = 4 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xoomax1
            ElseIf j = 5 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txoomax1
            ElseIf j = 6 Then
                MRM_2G_tool1(j, nserie2Gtool1) = Fomax1
            ElseIf j = 7 Then
                MRM_2G_tool1(j, nserie2Gtool1) = tFomax1
            ElseIf j = 8 Then
                MRM_2G_tool1(j, nserie2Gtool1) = Fomax3
            ElseIf j = 9 Then
                MRM_2G_tool1(j, nserie2Gtool1) = tFomax3

            ElseIf j = 10 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xmax2
            ElseIf j = 11 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txmax2
            ElseIf j = 12 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xomax2
            ElseIf j = 13 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txomax2
            ElseIf j = 14 Then
                MRM_2G_tool1(j, nserie2Gtool1) = xoomax2
            ElseIf j = 15 Then
                MRM_2G_tool1(j, nserie2Gtool1) = txoomax2
            ElseIf j = 16 Then
                MRM_2G_tool1(j, nserie2Gtool1) = Fomax2
            ElseIf j = 17 Then
                MRM_2G_tool1(j, nserie2Gtool1) = tFomax2
            ElseIf j = 18 Then
                MRM_2G_tool1(j, nserie2Gtool1) = Fomax4
            ElseIf j = 19 Then
                MRM_2G_tool1(j, nserie2Gtool1) = tFomax4
            End If

        Next j
        Session("MRM_2G_tool1S") = MRM_2G_tool1
    End Sub

#End Region
#Region "PREPARAR MATRICES"
    Public Sub PrepararMatrices()
        Dim I, DI
        nserie2Gtool1 = ViewState("ns2")
        MGDesp1 = Session("MGDesp1S") : MGVelo1 = Session("MGVelo1S") : MGAce1 = Session("MGAce1S") : MGForce1 = Session("MGForce1S") : MGForce3 = Session("MGForce3S")
        MGDesp2 = Session("MGDesp2S") : MGVelo2 = Session("MGVelo2S") : MGAce2 = Session("MGAce2S") : MGForce2 = Session("MGForce2S") : MGForce4 = Session("MGForce4S")
        MGFvsD1 = Session("MGFvsD1S") : MGFvsD2 = Session("MGFvsD2S") : MGFvsD3 = Session("MGFvsD3S") : MGFvsD4 = Session("MGFvsD4S")

        NDG1 = ViewState("NDG1S") : NDG2 = ViewState("NDG2S")
        NDEX = ViewState("NDEXS")
        ReDim Preserve NDG1(nserie2Gtool1)
        ReDim Preserve NDG2(nserie2Gtool1)
        ReDim Preserve NDEX(nserie2Gtool1) REM Numero de datos de exitación
        ViewState("NDEXS") = NDEX
        NDG1(nserie2Gtool1) = CDbl(MDesp1.GetUpperBound(0))


        NDG2(nserie2Gtool1) = CDbl(MDesp2.GetUpperBound(0))
        ViewState("NDG1S") = NDG1 : ViewState("NDG2S") = NDG2
        For u = 0 To NDG1(nserie2Gtool1)
            MFvsD1(u, 0) = MDesp1(u, 1)
            MFvsD1(u, 1) = MForce1(u, 1)

            MFvsD2(u, 0) = MDesp2(u, 1) - MDesp1(u, 1)
            MFvsD2(u, 1) = MForce2(u, 1)

            For j As Integer = 0 To 1
                MGDesp1(u, j, nserie2Gtool1) = MDesp1(u, j)
                MGVelo1(u, j, nserie2Gtool1) = MVelo1(u, j)
                MGAce1(u, j, nserie2Gtool1) = MAce1(u, j)

                MGForce1(u, j, nserie2Gtool1) = MForce1(u, j)
                MGForce2(u, j, nserie2Gtool1) = MForce2(u, j)

                MGFvsD1(u, j, nserie2Gtool1) = MFvsD1(u, j)
                MGFvsD2(u, j, nserie2Gtool1) = MFvsD2(u, j)
            Next
        Next

        For u = 0 To NDG2(nserie2Gtool1)
            REM Le resto el desplazamiento 1
            MFvsD3(u, 0) = MDesp1(u, 1)
            MFvsD3(u, 1) = MForce3(u, 1)

            MFvsD4(u, 0) = MDesp2(u, 1) - MDesp1(u, 1)
            MFvsD4(u, 1) = MForce4(u, 1)

            For j As Integer = 0 To 1
                MGDesp2(u, j, nserie2Gtool1) = MDesp2(u, j)
                MGVelo2(u, j, nserie2Gtool1) = MVelo2(u, j)
                MGAce2(u, j, nserie2Gtool1) = MAce2(u, j)

                MGForce3(u, j, nserie2Gtool1) = MForce3(u, j)
                MGForce4(u, j, nserie2Gtool1) = MForce4(u, j)

                MGFvsD3(u, j, nserie2Gtool1) = MFvsD3(u, j)
                MGFvsD4(u, j, nserie2Gtool1) = MFvsD4(u, j)
            Next
        Next
        Session("MGDesp1S") = MGDesp1 : Session("MGVelo1S") = MGVelo1 : Session("MGAce1S") = MGAce1 : Session("MGForce1S") = MGForce1 : Session("MGForce3S") = MGForce3
        Session("MGDesp2S") = MGDesp2 : Session("MGVelo2S") = MGVelo2 : Session("MGAce2S") = MGAce2 : Session("MGForce2S") = MGForce2 : Session("MGForce4S") = MGForce4

        Session("MGFvsD1S") = MGFvsD1 : Session("MGFvsD2S") = MGFvsD2 : Session("MGFvsD3S") = MGFvsD3 : Session("MGFvsD4S") = MGFvsD4


        Select Case Me.DDLexiTyp.SelectedValue
            Case 0
                I = Me.txtI.Text
                DI = Me.txtDI.Text
                ReDim MExiTypX(1, 1)
                MExiTypX(0, 0) = 0
                MExiTypX(0, 1) = 0
                MExiTypX(1, 0) = DI
                MExiTypX(1, 1) = I * DI
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

                ReDim MExiTypX(3, 1)
                MExiTypX(0, 0) = 0
                MExiTypX(0, 1) = 0
                MExiTypX(1, 0) = t1
                MExiTypX(1, 1) = Fmax
                MExiTypX(2, 0) = t2
                MExiTypX(2, 1) = Fmax
                MExiTypX(3, 0) = t3
                MExiTypX(3, 1) = 0
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

                ReDim MExiTypX(Ndexi, 1)
                Ndexi = 0
                Dexi = 0
                Do While Ndexi <= MExiTypX.GetUpperBound(0)
                    MExiTypX(Ndexi, 0) = Dexi
                    MExiTypX(Ndexi, 1) = Fo * Sin(wa * Dexi)
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
                ReDim MExiTypX(Ndexi, 1)
                ReDim MacSoilX(Ndexi, 1)

                Dexi = 0
                Ndexi = 0
                Do While Ndexi <= MExiTypX.GetUpperBound(0)
                    MExiTypX(Ndexi, 0) = Dexi
                    MacSoilX(Ndexi, 0) = Dexi
                    Dexi += pasoAC
                    Ndexi += 1
                Loop
                On Error Resume Next
                Dim ncAce As Integer = (Acelerograma.GetUpperBound(0) + 1) * (Acelerograma.GetUpperBound(1) + 1)
                For nf As Integer = 0 To ncAce
                    For nc As Integer = 0 To Acelerograma.GetUpperBound(1)
                        MacSoilX(nf, 1) = Acelerograma(nf, nc) * facAC
                        MExiTypX(nf, 1) = Acelerograma(nf, nc) * facAC * (-10)
                        If nf = Ndexi Then Exit For
                    Next
                    If nf = Ndexi Then Exit For
                Next
                YaHayGraficoAS1 = True
                ViewState("nsAS2") = ViewState("nsAS2") + 1
                nserieAS2Gtool1 = ViewState("nsAS2")
                NDAcSoilX = ViewState("NDAcSoilXS")
                ReDim Preserve NDAcSoilX(nserieAS2Gtool1)
                NDAcSoilX(nserieAS2Gtool1) = CDbl(MacSoilX.GetUpperBound(0))
                ViewState("NDAcSoilXS") = NDAcSoilX
                MGacSoilX = Session("MGacSoilXAS")
                ReDim Preserve MGacSoilX(100000, 1, nserieAS2Gtool1)
                For u = 0 To NDAcSoilX(nserieAS2Gtool1)
                    For j As Integer = 0 To 1
                        REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                        MGacSoilX(u, j, nserieAS2Gtool1) = MacSoilX(u, j)
                    Next
                Next
                Session("MGacSoilXAS") = MGacSoilX
                If ID = "ES" Then
                    NombreGraficoExi = "Excitación: Acelerograma"
                ElseIf ID = "EN" Then
                    NombreGraficoExi = "Excitation: Acceleration record"

                End If

        End Select
        NDEX = ViewState("NDEXS")
        NDEX(nserie2Gtool1) = CDbl(MExiTypX.GetUpperBound(0))
        ViewState("NDEXS") = NDEX
        MGExiTypX = Session("MGExiTypXAS")
        For u = 0 To NDEX(nserie2Gtool1)
            For j As Integer = 0 To 1
                REM ALMACENO LOS RESULTADOS EN UNA MATRIZ GENERAL
                MGExiTypX(u, j, nserie2Gtool1) = MExiTypX(u, j)
            Next
        Next
        Session("MGExiTypXAS") = MGExiTypX
    End Sub

    Public Sub EncerarMat()
        ViewState("ns2") = 0
        ViewState("nsAS2") = -1
        nserie2Gtool1 = ViewState("ns2")
        nserieAS2Gtool1 = ViewState("nsAS2")


        ReDim MDA(nserie2Gtool1)
        ReDim NDEX(nserie2Gtool1)
        ReDim NDAcSoilX(nserieAS2Gtool1)
        ReDim NDG1(nserie2Gtool1)
        ReDim NDG2(nserie2Gtool1)
        ReDim MGDesp1(100000, 1, nserie2Gtool1), MGVelo1(100000, 1, nserie2Gtool1), MGAce1(100000, 1, nserie2Gtool1), MGForce1(100000, 1, nserie2Gtool1), MGForce3(100000, 1, nserie2Gtool1), MGFvsD1(100000, 1, nserie2Gtool1), MGFvsD3(100000, 1, nserie2Gtool1)
        ReDim MGDesp2(100000, 1, nserie2Gtool1), MGVelo2(100000, 1, nserie2Gtool1), MGAce2(100000, 1, nserie2Gtool1), MGForce2(100000, 1, nserie2Gtool1), MGForce4(100000, 1, nserie2Gtool1), MGFvsD2(100000, 1, nserie2Gtool1), MGFvsD4(100000, 1, nserie2Gtool1)
        ReDim MDesp1(0, 0), MVelo1(0, 0), MAce1(0, 0), MForce1(0, 0), MForce3(0, 0), MFvsD1(0, 0), MFvsD3(0, 0)
        ReDim MDesp2(0, 0), MVelo2(0, 0), MAce2(0, 0), MForce2(0, 0), MForce4(0, 0), MFvsD2(0, 0), MFvsD4(0, 0)

        ReDim MGExiTypX(100000, 1, nserie2Gtool1)
        ReDim MExiTypX(0, 0)
        ReDim MGacSoilX(100000, 1, nserieAS2Gtool1)
        ReDim MacSoilX(0, 0)
        Session("MGDesp1S") = MGDesp1 : Session("MGVelo1S") = MGVelo1 : Session("MGAce1S") = MGAce1 : Session("MGForce1S") = MGForce1 : Session("MGForce3S") = MGForce3
        Session("MGDesp2S") = MGDesp2 : Session("MGVelo2S") = MGVelo2 : Session("MGAce2S") = MGAce2 : Session("MGForce2S") = MGForce2 : Session("MGForce4S") = MGForce4
        Session("MGFvsD1S") = MGFvsD1 : Session("MGFvsD2S") = MGFvsD2 : Session("MGFvsD3S") = MGFvsD3 : Session("MGFvsD4S") = MGFvsD4
        Session("MGExiTypXAS") = MGExiTypX : Session("MGacSoilXAS") = MGacSoilX
        ViewState("NDG1S") = NDG1 : ViewState("NDG2S") = NDG2
        ViewState("NDEXS") = NDEX : ViewState("NDAcSoilXS") = NDAcSoilX
        Session("MRM_2G_tool1S") = MRM_2G_tool1
    End Sub

    Public Sub ReDimMat()
        nserie2Gtool1 = ViewState("ns2")
        nserieAS2Gtool1 = ViewState("nsAS2")
        MGDesp1 = Session("MGDesp1S") : MGVelo1 = Session("MGVelo1S") : MGAce1 = Session("MGAce1S") : MGForce1 = Session("MGForce1S") : MGForce3 = Session("MGForce3S")
        MGDesp2 = Session("MGDesp2S") : MGVelo2 = Session("MGVelo2S") : MGAce2 = Session("MGAce2S") : MGForce2 = Session("MGForce2S") : MGForce4 = Session("MGForce4S")
        MGFvsD1 = Session("MGFvsD1S") : MGFvsD2 = Session("MGFvsD2S") : MGFvsD3 = Session("MGFvsD3S") : MGFvsD4 = Session("MGFvsD4S")

        MGExiTypX = Session("MGExiTypXAS") : MGacSoilX = Session("MGacSoilXAS")
        NDG1 = ViewState("NDG1S") : NDG2 = ViewState("NDG2S")
        NDEX = ViewState("NDEXS") : NDAcSoilX = ViewState("NDAcSoilXS")
        MRM_2G_tool1 = Session("MRM_2G_tool1S")
        ReDim Preserve MRM_2G_tool1(19, nserie2Gtool1)
        ReDim Preserve MDA(nserie2Gtool1)
        ReDim Preserve NDEX(nserie2Gtool1)
        ReDim Preserve NDAcSoilX(nserieAS2Gtool1)
        ReDim Preserve NDG1(nserie2Gtool1)
        ReDim Preserve NDG2(nserie2Gtool1)
        ReDim Preserve MGDesp1(100000, 1, nserie2Gtool1), MGVelo1(100000, 1, nserie2Gtool1), MGAce1(100000, 1, nserie2Gtool1), MGForce1(100000, 1, nserie2Gtool1), MGForce3(100000, 1, nserie2Gtool1), MGFvsD1(100000, 1, nserie2Gtool1), MGFvsD3(100000, 1, nserie2Gtool1)
        ReDim Preserve MGDesp2(100000, 1, nserie2Gtool1), MGVelo2(100000, 1, nserie2Gtool1), MGAce2(100000, 1, nserie2Gtool1), MGForce2(100000, 1, nserie2Gtool1), MGForce4(100000, 1, nserie2Gtool1), MGFvsD2(100000, 1, nserie2Gtool1), MGFvsD4(100000, 1, nserie2Gtool1)
        ReDim Preserve MGExiTypX(100000, 1, nserie2Gtool1)
        ReDim Preserve MGacSoilX(100000, 1, nserieAS2Gtool1)
        Session("MGDesp1S") = MGDesp1 : Session("MGVelo1S") = MGVelo1 : Session("MGAce1S") = MGAce1 : Session("MGForce1S") = MGForce1 : Session("MGForce3S") = MGForce3
        Session("MGDesp2S") = MGDesp2 : Session("MGVelo2S") = MGVelo2 : Session("MGAce2S") = MGAce2 : Session("MGForce2S") = MGForce2 : Session("MGForce4S") = MGForce4
        Session("MGFvsD1S") = MGFvsD1 : Session("MGFvsD2S") = MGFvsD2 : Session("MGFvsD3S") = MGFvsD3 : Session("MGFvsD4S") = MGFvsD4
        Session("MGExiTypXAS") = MGExiTypX : Session("MGacSoilXAS") = MGacSoilX
        ViewState("NDG1S") = NDG1 : ViewState("NDG2S") = NDG2
        ViewState("NDEXS") = NDEX : ViewState("NDAcSoilXS") = NDAcSoilX
        Session("MRM_2G_tool1S") = MRM_2G_tool1
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
       btnDownResul2.Click, btnDownResul3.Click, btnDownResul4.Click, btnDownResul5.Click, btnDownResul6.Click,
       btnDownResul7.Click, btnDownResul8.Click, btnDownResul9.Click, btnDownResul10.Click, btnDownResul11.Click, btnDownResul12.Click,
        btnDownResul13.Click, btnDownResul14.Click, btnDownResul15.Click, btnDownResul16.Click
        nserie2Gtool1 = ViewState("ns2")
        nserieAS2Gtool1 = ViewState("nsAS2")
        NDG1 = ViewState("NDG1S") : NDG2 = ViewState("NDG2S")
        NDEX = ViewState("NDEXS") : NDAcSoilX = ViewState("NDAcSoilXS")
        MGExiTypX = Session("MGExiTypXAS") : MGacSoilX = Session("MGacSoilXAS")
        MGDesp1 = Session("MGDesp1S") : MGVelo1 = Session("MGVelo1S") : MGAce1 = Session("MGAce1S") : MGForce1 = Session("MGForce1S") : MGForce3 = Session("MGForce3S")
        MGDesp2 = Session("MGDesp2S") : MGVelo2 = Session("MGVelo2S") : MGAce2 = Session("MGAce2S") : MGForce2 = Session("MGForce2S") : MGForce4 = Session("MGForce4S")
        Session("MGFvsD1S") = MGFvsD1 : Session("MGFvsD2S") = MGFvsD2 : Session("MGFvsD3S") = MGFvsD3 : Session("MGFvsD4S") = MGFvsD4
        Select Case CType(sender, LinkButton).ID
            Case "btnDownResul1"
                REM grafico la aceleración del suelo
                Call DescargarResp(MGacSoilX, NombreGraficoAS1, ejexExi, ejeyAS, NDAcSoilX, nserieAS2Gtool1)
            Case "btnDownResul2"
                REM Historia de exitación
                Call DescargarResp(MGExiTypX, NombreGraficoExi, ejexExi, ejeyExi, NDEX, nserie2Gtool1)
            Case "btnDownResul3"
                REM Archivo Desplazamiento Vs.Tiempo
                Call DescargarResp(MGDesp1, NombreGrafico1, ejex1, ejey1, NDG1, nserie2Gtool1)
            Case "btnDownResul4"
                REM Archivo Desplazamiento Vs.Tiempo
                Call DescargarResp(MGDesp2, NombreGrafico1b, ejex1, ejey1, NDG2, nserie2Gtool1)
            Case "btnDownResul5"
                REM Archivo Velocidad Vs.Tiempo
                Call DescargarResp(MGVelo1, NombreGrafico2, ejex2, ejey2, NDG1, nserie2Gtool1)
            Case "btnDownResul6"
                REM Archivo Velocidad Vs.Tiempo
                Call DescargarResp(MGVelo2, NombreGrafico2b, ejex2, ejey2, NDG2, nserie2Gtool1)
            Case "btnDownResul7"
                REM Archivo Aceleración Vs.Tiempo
                Call DescargarResp(MGAce1, NombreGrafico3, ejex3, ejey3, NDG1, nserie2Gtool1)
            Case "btnDownResul8"
                REM Archivo Aceleración Vs.Tiempo
                Call DescargarResp(MGAce2, NombreGrafico3b, ejex3, ejey3, NDG2, nserie2Gtool1)
            Case "btnDownResul9"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce1, NombreGrafico4, ejex4, ejey4, NDG1, nserie2Gtool1)
            Case "btnDownResul10"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce2, NombreGrafico4b, ejex4, ejey4, NDG2, nserie2Gtool1)



            Case "btnDownResul3"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce3, NombreGrafico41, ejex4, ejey4, NDG1, nserie2Gtool1)
            Case "btnDownResul14"
                REM Archivo Fuerza Vs.Tiempo
                Call DescargarResp(MGForce4, NombreGrafico4b1, ejex4, ejey4, NDG2, nserie2Gtool1)

            Case "btnDownResul11"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD1, NombreGrafico5, ejex5, ejey5, NDG1, nserie2Gtool1)
            Case "btnDownResul12"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD2, NombreGrafico5b, ejex5, ejey5, NDG2, nserie2Gtool1)

            Case "btnDownResul15"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD3, NombreGrafico51, ejex5, ejey5, NDG2, nserie2Gtool1)
            Case "btnDownResul16"
                REM Archivo Fuerza Vs.Desplazamiento
                Call DescargarResp(MGFvsD4, NombreGrafico5b1, ejex5, ejey5, NDG2, nserie2Gtool1)

        End Select

    End Sub
#End Region
#Region "DESCRIBIR VARIABLES"

    Public Sub DescripciónSegunId(ByVal ListaTM As DropDownList, ByVal ListaTE As DropDownList, ByVal ListaRUN As DropDownList, ByVal Idioma As String)
        If Idioma = "ES" Then

            Tit2Gtool1 = "ANÁLISIS DE HISTORIA EN EL TIEMPO DE UN SISTEMA DE DOS GRADOS DE LIBERTAD"
            titLoadExample = "Cargar ejemplo"
            namefileRM = "Respuestas Maximas"
            REM NOMBRES DE LOS GRAFICOS_________________________________________________
            titGRAF = "GRÁFICAS"
            NombreGraficoAS1 = "Aceleración del suelo (Solo con acelerograma)"
            ejeyAS = "Aceleración [m /s^2]"
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
            ejey3 = "Aceleración [m/s2]"
            NombreGrafico4 = "Fuerza interna (Elemento 1)"
            NombreGrafico4b = "Fuerza interna (Elemento 2)"
            NombreGrafico41 = "Fuerza interna (Elemento amortiguador 1)"
            NombreGrafico4b1 = "Fuerza interna (Elemento amortiguador 2)"
            ejex4 = "Tiempo [s]"
            ejey4 = "Fuerza interna [kN]"
            NombreGrafico5 = "Histerisis (Elemento 1)"
            NombreGrafico5b = "Histerisis (Elemento 2)"
            NombreGrafico51 = "Histerisis (Elemento amortiguador 1)"
            NombreGrafico5b1 = "Histerisis (Elemento amortiguador 2)"
            ejex5 = "Desplazamiento [m]"
            ejey5 = "Fuerza interna [kN]"
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
            Tit2Gtool1 = "TIME HISTORY ANALYSIS OF TWO DEGREE OF FREEDOM SYSTEMS"
            titLoadExample = "Load example"
            namefileRM = "Maximum response"
            REM NOMBRES DE LOS GRAFICOS______________________________________________________________
            NombreGraficoAS1 = "Ground acceleration (Only with acceleration record)"
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
            NombreGrafico4 = "Internal force (Element 1 )"
            NombreGrafico4b = "Internal force (Element 2)"

            NombreGrafico41 = "Internal force (Damper element 1 )"
            NombreGrafico4b1 = "Internal force (Damper element 2)"
            ejex4 = "Time [s]"
            ejey4 = "Internal force [kN]"
            NombreGrafico5 = "Hysterisis (Element 1)"
            NombreGrafico5b = "Hysterisis (Element 2)"

            NombreGrafico51 = "Hysterisis (Damper element 1)"
            NombreGrafico5b1 = "Hysterisis (Damper element 2)"
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
    Public Sub NombresLabelsTitulos()
        'Me.lblNameTool.Text = "2DOF-Dynamics"
        'Me.lblLoadExample.Text = titLoadExample
        'Me.lblTitulo2GDLtool1.Text = Tit2Gtool1
        Me.lblGraficas.Text = titGRAF
        lblProSis.Text = ProSis
        lblEsquemaMain.Text = EsquemaMain
        lblTM.Text = titMaterial
        lblEsqTE.Text = EsquemaMain
        lblCT.Text = titCtipo
        lblAnalisis.Text = titAnal
        Me.lblTE.Text = titExi

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
        Call NameNyE2GTOOL1(ID)
        Me.lblNudo2.Text = Nudo1
        Me.lblNudo21.Text = Nudo1
        Me.lblNudo3.Text = Nudo2
        Me.lblNudo31.Text = Nudo2

        Me.lblEle1.Text = Elemento1
        Me.lblEle11.Text = Elemento1
        Me.lblEle12.Text = Elemento1

        Me.lblEle13.Text = ElementoR1
        Me.lblEle26.Text = ElementoA1

        Me.lblEle2.Text = Elemento2
        Me.lblEle21.Text = Elemento2
        Me.lblEle22.Text = Elemento2

        Me.lblEle23.Text = ElementoR2
        Me.lblEle27.Text = ElementoA2
        REM Esquema principal
        UbicFiguraMain = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/Tools/"
        Me.FigMain.ImageUrl = UbicFiguraMain & "Dinamica_2GDL_Tool1.png"

        If ID = "ES" Then
            REM Titulo del laboratorio segun ID
            'Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-ES.png"

            REM Figuras de los materiales
            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónES/"
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_ES.bmp"
            'Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_ES.bmp"
            'Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_ES.bmp"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_ES.bmp"
            'Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_ES.bmp"
            'Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_ES.bmp"
            'Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_ES.bmp"
            Me.lblM.Text = "Masa [tonnes]"
            Me.lblk.Text = "Rigidez [kN/m]"
            Me.lblc.Text = "Coeficiente de amortiguamiento[kN*s/m]"

            Me.lblEscTM.Text = "Selecionar: "
            Me.lblEscTE.Text = "Seleccionar: "


        ElseIf ID = "EN" Then
            REM Titulo del laboratorio segun ID
            'Me.imgCaratula.ImageUrl = "~/VirtualLabIS/Varios/Archivos/Imagenes/Portal/TituloVirtualLab-EN.png"

            REM Figuras de los materiales
            UbicFiguras = "~/VirtualLabIS/Experimentos/Dinamica/Imagenes/General/VersiónEN/"
            Me.FigMat1.ImageUrl = UbicFiguras & "FigTM1_EN.png"
            'Me.FigMat2.ImageUrl = UbicFiguras & "FigTM2_EN.bmp"
            'Me.FigMat3.ImageUrl = UbicFiguras & "FigTM3_EN.bmp"
            Me.FigExi1.ImageUrl = UbicFiguras & "FigTE1_EN.png"
            'Me.FigExi2.ImageUrl = UbicFiguras & "FigTE2_EN.bmp"
            'Me.FigExi3.ImageUrl = UbicFiguras & "FigTE3_EN.bmp"
            'Me.FigExi4.ImageUrl = UbicFiguras & "FigTE4_EN.bmp"
            Me.lblM.Text = "Mass  [Tonne =kN.s^2/m =kN/g]"
            Me.lblk.Text = "Stiffness [kN/m]"
            Me.lblc.Text = "Damping coefficient[kN*s/m]"
            Me.lblEscTM.Text = "Select: "
            Me.lblEscTE.Text = "Select: "

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
    Public Sub NombresLabelsDescarga()
        'lblDR1.Text = DownAns
        'lblDR2.Text = DownAns
        'lblDR3.Text = DownAns
        'lblDR4.Text = DownAns
        'lblDR5.Text = DownAns
        'lblDR6.Text = DownAns
        'lblDR7.Text = DownAns
        'lblDr8.Text = DownAns
        'lblDR9.Text = DownAns
        'lblDR10.Text = DownAns
        'lblDR11.Text = DownAns
        'lblDR12.Text = DownAns
        'lblDR13.Text = DownAns
        'lblDR14.Text = DownAns
        'lblDR15.Text = DownAns
        'lblDR16.Text = DownAns
        'lblDR17.Text = DownAns
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
        'DimFiguras(btnDownResul8, base, Altura)
        'DimFiguras(btnDownResul9, base, Altura)
        'DimFiguras(btnDownResul10, base, Altura)
        'DimFiguras(btnDownResul11, base, Altura)
        'DimFiguras(btnDownResul12, base, Altura)
        'DimFiguras(btnDownResul3, base, Altura)
        'DimFiguras(btnDownResul14, base, Altura)
        'DimFiguras(btnDownResul15, base, Altura)
        'DimFiguras(btnDownResul16, base, Altura)

        'DimFiguras(ibtnLoadExample, 30, 25)
    End Sub

    REM NOMBRES DE LOS GRAFICOS

#End Region
#Region "CARGAR EJEMPLO"
    Public Sub LoadExample()
        REM Caso 1GTool1
        Me.txtM1.Text = 10
        Me.txtM2.Text = 9
        Me.txtK1.Text = 5000
        Me.txtK2.Text = 4000

        Me.txtC1.Text = 50
        Me.txtC2.Text = 40
        Me.txtDA.Text = 15

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
            'Me.lblLoadExample.Text = "Ejemplo cargado:"
        ElseIf ID = "EN" Then
            lblMensCE.Text = "OK!!"
            'Me.lblLoadExample.Text = "Loaded example:"
        End If
        Me.lblError.Visible = False
        PrepararMarco()
    End Sub


#End Region
#Region "ENCERAR DATOS"
    Public Sub ClearData()
        REM Caso 1GTool1
        Me.txtM1.Text = Nothing
        Me.txtM2.Text = Nothing
        Me.txtK1.Text = Nothing
        Me.txtK2.Text = Nothing

        Me.txtC1.Text = Nothing
        Me.txtC2.Text = Nothing
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
        txtFomax3.Text = Nothing

        lblXmax1.Text = Nothing
        lblXoMax1.Text = Nothing
        lblXooMax1.Text = Nothing
        lblFomax1.Text = Nothing
        lblFomax3.Text = Nothing
        txtXmax2.Text = Nothing
        txtXoMax2.Text = Nothing
        txtXooMax2.Text = Nothing
        txtFomax2.Text = Nothing
        txtFomax4.Text = Nothing

        lblXmax2.Text = Nothing
        lblXoMax2.Text = Nothing
        lblXooMax2.Text = Nothing
        lblFoMax2.Text = Nothing
        lblFomax4.Text = Nothing

        Me.lblError.Visible = False
        Me.lblMensCE.Visible = False
        PrepararMarco()

    End Sub


#End Region



End Class
