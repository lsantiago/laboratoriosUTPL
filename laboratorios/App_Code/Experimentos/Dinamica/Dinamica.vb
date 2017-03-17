Imports Microsoft.VisualBasic

'Clase para los experimentos de dinamica
Public Class Dinamica
    Const pi = 3.1415927
    Dim xooEQ()
    Dim P()
    Dim F()
    Dim xoo()
    Dim xo()
    Dim x()
    Dim t()
    Dim Eqpath, eqfactor As Single, durationEQ As Single, stepEQ As Single, mass As Single, period As Single, damping As Single, stepA As Single, durationA As Single, xooi As Single, xoi As Single, xi As Single, npointsA As Integer
    Dim maxxoo As Single, maxxo As Single, maxx As Single, floading As Single, maxload As Single
    Dim peakvalues(10)
    Dim LoadFunction()
    Dim spectrumA(,), spectrumV(,), spectrumD(,), ductility(,), speriod(), Elasticdisplacement(), elasticforce()
    Dim lparameters(200, 5)
    Dim Fy As Single, Dy As Single, rr As Single, maxxF As Single, maxF(), maxxD As Single, npoints, ncurves
    Dim keff, teff, maxdisp, eqdamping
    Const stepfactor = 20
    Const stepfactorn = 200

    'VARIABLES SIN DECLARAR
    Dim tol, w, dampc, cd, c, k
    Dim npointsEQ
    'Freevibration
    Dim Ta, q, T1eq, T2eq, xooEQ1, xooeq2
    'responseto3linearload
    Dim tt
    'linearization
    Dim periodi As Single, dampingi As Single, maxxFE As Single, maxxE As Single, maxxooE As Single, stepeqfactor As Single, maxxFI As Single, maxxI As Single, maxxooI As Single, duct As Single
    'spectralanalysisseq
    Dim period1 As Single, period2 As Single, damping1 As Single, damping2 As Single, stepdamping As Single
    Dim pstep
    'inelasticspectrum
    Dim R1 As Single, R2 As Single, stepR As Single, r As Single, stepA1 As Single, stepA2 As Single
    'newmark1
    Dim mbar As Single, deltaP As Single, pbar As Single
    'newmark3
    Dim ccp As Single, kini As Single, kt As Single, dantes As Single, ddespues As Single, loadfactor As Single, _
        Fp As Single, Fn As Single, ktn As Single, RF As Single


    Sub Equivalentdamping()
        'encuentra el amortiguamiento viscoso equivalente en funcion de los siguientes datos:
        tol = 0.001
        w = 2 * pi / teff
        mass = keff / w ^ 2
        period = teff
        xooi = 0
        xoi = 0
        xi = 0
        damping = 0
        dampc = 0.1
        cd = 1

        Do
            newmark1() 'analsis con acelerograma como entrada
            If maxx > maxdisp Then
                If cd = 1 Then damping = damping + dampc
                If cd = -1 Then dampc = dampc / 10 : damping = damping + dampc
                cd = 1
            End If
            If maxx < maxdisp Then
                If cd = 1 Then dampc = dampc / 10 : damping = damping - dampc
                If cd = -1 Then damping = damping - dampc
                cd = -1
            End If
            If Math.Abs((maxx - maxdisp) / maxdisp) < tol Then Exit Do
        Loop
        eqdamping = damping

    End Sub

    Public Function return_peakvalues()
        return_peakvalues = peakvalues
    End Function
    Public Function return_Dhistory()
        return_Dhistory = x
    End Function
    Public Function return_Vhistory()
        return_Vhistory = xo
    End Function
    Public Function return_Ahistory()
        return_Ahistory = xoo
    End Function
    Public Function return_lparameters()
        return_lparameters = lparameters
    End Function

    Public Function return_Loading()
        return_Loading = P
    End Function
    Public Function return_groundacceleration()
        return_groundacceleration = xooEQ
    End Function

    Public Function return_Time()
        return_Time = t
    End Function
    Public Function return_Aspectrum()
        return_Aspectrum = spectrumA
    End Function
    Public Function return_Vspectrum()
        return_Vspectrum = spectrumV
    End Function
    Public Function return_Dspectrum()
        return_Dspectrum = spectrumD
    End Function
    Public Function return_ductility()
        return_ductility = ductility
    End Function
    Public Function return_period()
        return_period = speriod
    End Function
    Public Function return_elementforce()
        return_elementforce = F
    End Function
    Public Function return_npoints()
        return_npoints = npointsA
    End Function
    Public Function return_npointsspectrum()
        return_npointsspectrum = npoints
    End Function
    Public Function return_ncurves()
        return_ncurves = ncurves
    End Function

    Sub Freevibration(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        ReDim LoadFunction(1)
        LoadFunction(0) = 0
        LoadFunction(1) = 0
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(6)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        stepEQ = durationEQ
        stepA = period / stepfactor
        newmark2()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max displacement

    End Sub




    Sub Freevibration_nonlinear(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        ReDim LoadFunction(1)
        LoadFunction(0) = 0
        LoadFunction(1) = 0
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(6)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        Fy = dinput(7)
        rr = dinput(8)

        stepEQ = durationEQ
        stepA = period / stepfactorn

        npointsA = durationA / stepA
        ReDim xooEQ(npointsA) 'pads with 0 at the end

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = LoadFunction(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = LoadFunction(q + 1) Else xooeq2 = 0
            P(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        For n As Integer = 0 To npointsA
            xooEQ(n) = P(n) / -mass
        Next



        newmark3()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max displacement

    End Sub

    Sub responsetolinearload(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        ReDim LoadFunction(0 To 1)
        LoadFunction(0) = 0
        LoadFunction(1) = dinput(7) * dinput(8)
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(8)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        stepEQ = durationEQ
        stepA = period / stepfactor

        newmark2()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max displacement

    End Sub

    Sub responsetolinearload_nonlinear(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        ReDim LoadFunction(0 To 1)
        LoadFunction(0) = 0
        LoadFunction(1) = dinput(7) * dinput(8)
        npointsEQ = 1
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(8)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        stepEQ = durationEQ
        stepA = period / stepfactorn
        Fy = dinput(9)
        rr = dinput(10)

        npointsA = durationA / stepA
        ReDim xooEQ(npointsA) 'pads with 0 at the end

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            If Ta > durationEQ Then Exit For
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = LoadFunction(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = LoadFunction(q + 1) Else xooeq2 = 0
            P(n) = (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next


        newmark3()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max displacement

    End Sub

    Sub responseto3linearload(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(10)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        stepA = period / stepfactor
        stepEQ = stepA

        Dim time1 As Single, time2 As Single, time3 As Single

        maxload = dinput(7)
        time1 = dinput(8) 'Time 1 (s)
        time2 = dinput(9)   'Time 2 (s)
        time3 = dinput(10)   'Time 3 (s)
        ReDim LoadFunction(time3 / stepA)


        For n As Integer = 0 To (durationEQ / stepA)
            tt = n * stepA
            If tt < time1 Then
                LoadFunction(n) = maxload / time1 * (n * stepA)
            End If
            If tt >= time1 And tt < time2 Then
                LoadFunction(n) = maxload
            End If
            If tt > time2 Then
                LoadFunction(n) = maxload - maxload / (time3 - time2) * (n * stepA - time2)
            End If
        Next

        newmark2()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max force

    End Sub

    Sub responseto3linearload_nonlinear(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = dinput(10)
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        Fy = dinput(11)
        rr = dinput(12)
        stepA = period / stepfactorn
        stepEQ = stepA

        Dim time1 As Single, time2 As Single, time3 As Single

        maxload = dinput(7)
        time1 = dinput(8) 'Time 1 (s)
        time2 = dinput(9)   'Time 2 (s)
        time3 = dinput(10)   'Time 3 (s)
        ReDim LoadFunction(time3 / stepA)


        For n As Integer = 0 To (durationEQ / stepA)
            tt = n * stepA
            If tt < time1 Then
                LoadFunction(n) = maxload / time1 * (n * stepA)
            End If
            If tt >= time1 And tt <= time2 Then
                LoadFunction(n) = maxload
            End If
            If tt > time2 Then
                LoadFunction(n) = maxload - maxload / (time3 - time2) * (n * stepA - time2)
            End If
        Next

        npointsA = durationA / stepA
        ReDim xooEQ(npointsA) 'pads with 0 at the end
        npointsEQ = durationEQ / stepEQ
        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            If Ta > durationEQ Then Exit For
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = LoadFunction(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = LoadFunction(q + 1) Else xooeq2 = 0
            P(n) = (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        newmark3()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max force

    End Sub



    Sub responsetosineload(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = durationA
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        floading = dinput(8)
        maxload = dinput(7)

        stepA = period / stepfactor
        stepEQ = stepA

        ReDim LoadFunction(Int(durationEQ / stepA))

        For n As Integer = 0 To (Int(durationEQ / stepA))
            LoadFunction(n) = maxload * Math.Sin(floading * n * stepA)
        Next

        newmark2()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF
    End Sub

    Sub responsetosineload_nonlinear(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        xi = dinput(0)
        xoi = dinput(1)
        xooi = dinput(2)
        durationA = dinput(6)
        durationEQ = durationA
        mass = dinput(3)
        damping = dinput(5) / 100
        period = dinput(4)
        floading = dinput(8)
        maxload = dinput(7)
        Fy = dinput(9)
        rr = dinput(10)
        stepA = period / stepfactorn
        stepEQ = stepA
        npointsA = Int(durationA / stepA)
        npointsEQ = npointsA

        ReDim P(npointsA)
        For n As Integer = 0 To npointsA
            P(n) = maxload * Math.Sin(floading * n * stepA)
        Next

        ReDim xooEQ(npointsA) 'pads with 0 at the end

        newmark3()

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF
    End Sub



    Sub linearization(ByRef dinput)
        Dim targetduct As Single
        Dim PP()
        period = dinput(1) 'period
        periodi = period
        mass = dinput(2)  'mass
        Fy = dinput(3)  'fy
        rr = dinput(4) 'rr
        damping = dinput(5) / 100 'damping
        dampingi = damping
        targetduct = dinput(6) 'maxDuct
        durationA = dinput(7) 'duration of analysis
        stepEQ = dinput(8) 'eq step
        durationEQ = durationA
        stepA = stepEQ / 2
        npointsA = Int(durationA / stepA)
        Dim n As Integer

        'lee acelerograma
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim Preserve xooEQ(npointsA) 'pads with 0 at the end

        'runs elastic analisis to compute eqfactorstep
        eqfactor = 0.01
        For q = 0 To npointsA
            xooEQ(q) = xooEQ(q)
        Next
        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim P(0 To npointsA)
        ReDim PP(0 To npointsA)
        For n = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = xooEQ(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = xooEQ(q + 1) Else xooeq2 = 0
            PP(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        For q = 0 To npointsA
            P(q) = PP(q) * eqfactor
        Next
        ETHA()
        maxxFE = maxxF
        maxxE = maxx
        maxxooE = maxxoo
        eqfactor = eqfactor * (Fy / maxxF)
        stepeqfactor = 0.2 * eqfactor
        n = 0

        Do
            period = periodi
            damping = dampingi
            For q = 0 To npointsA
                P(q) = PP(q) * eqfactor
            Next
            ETHA()
            maxxFE = maxxF
            maxxE = maxx
            maxxooE = maxxoo
            ITHA1()
            maxxFI = maxxF
            maxxI = maxx
            maxxooI = maxxoo
            duct = maxxD
            keff = maxxFI / maxxI
            teff = 2 * pi * (mass / keff) ^ 0.5
            maxdisp = maxxI
            Equivalentdamping()
            'saves results
            lparameters(n, 1) = duct 'ductility
            lparameters(n, 2) = (maxxFE / maxxFI) ' reductionfactor
            lparameters(n, 3) = (maxxI / maxxE) ' displacement coefficient
            lparameters(n, 4) = eqdamping * 100
            lparameters(n, 5) = teff / periodi  'alargamiento del periodo
            eqfactor = eqfactor + stepeqfactor
            If (duct > targetduct) Or n > 20 Then Exit Do
            n = n + 1
        Loop
        npointsA = n
    End Sub

    Sub ETHA()
        xooi = 0
        xoi = 0
        xi = 0

        newmark1() 'analsis con acelerograma como entrada
    End Sub

    Sub ITHA1()
        'encuentra el amortiguamiento viscoso equivalente en funcion de los siguientes datos:
        xooi = 0
        xoi = 0
        xi = 0
        newmark3() 'analsis con acelerograma como entrada
    End Sub


    Sub responsetoeqload(ByRef dinput)
        'Eqpath = dinput(0)
        eqfactor = dinput(1)
        durationEQ = dinput(2)
        stepEQ = dinput(3)
        period = dinput(4)
        mass = dinput(5)
        durationA = dinput(6)
        damping = dinput(7) / 100
        '################## Termina entrada de datos

        stepA = stepEQ / 2
        xooi = 0
        xoi = 0
        xi = 0

        npointsA = Int(durationA / stepA)
        'lee acelerograma
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim Preserve xooEQ(npointsA) 'pads with 0 at the end
        For q = 0 To npointsA
            xooEQ(q) = xooEQ(q) * eqfactor
        Next

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(0 To npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = xooEQ(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = xooEQ(q + 1) Else xooeq2 = 0
            P(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        For n As Integer = 0 To npointsA
            xooEQ(n) = P(n) / -mass
        Next

        newmark1() 'analsis con acelerograma como entrada

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max displacement

    End Sub


    Sub pasagacceleration(ByRef Ar)
        xooEQ = Ar
    End Sub

    Sub itha(ByRef dinput)
        'encuentra el amortiguamiento viscoso equivalente en funcion de los siguientes datos:
        Eqpath = dinput(0)
        eqfactor = dinput(1)
        durationEQ = dinput(2)
        stepEQ = dinput(3)
        period = dinput(4)
        mass = dinput(5)
        durationA = dinput(6)
        damping = dinput(7) / 100
        Fy = dinput(8)
        rr = dinput(9)
        '################## Termina entrada de datos

        stepA = stepEQ / 2
        xooi = 0
        xoi = 0
        xi = 0

        npointsA = Int(durationA / stepA)
        'lee acelerograma
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim Preserve xooEQ(npointsA) 'pads with 0 at the end
        For q = 0 To npointsA
            xooEQ(q) = xooEQ(q) * eqfactor
        Next

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = xooEQ(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = xooEQ(q + 1) Else xooeq2 = 0
            P(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        For n As Integer = 0 To npointsA
            xooEQ(n) = P(n) / -mass
        Next

        newmark3() 'analsis con acelerograma como entrada

        'saves results
        peakvalues(1) = maxxoo  'max acceleration
        peakvalues(2) = maxxo  'max velocity
        peakvalues(3) = maxx  'max displacement
        peakvalues(4) = maxxF  'max force

    End Sub


    Sub spectralanalysiseq(ByRef dinput)
        'encuentra el amortiguamiento viscoso equivalente en funcion de los siguientes datos:
        eqfactor = dinput(1)
        durationEQ = dinput(2)
        stepEQ = dinput(3)
        period1 = dinput(4)
        If period1 = 0 Then period1 = 0.01
        period2 = dinput(5)
        npoints = dinput(6)
        mass = dinput(7)
        damping1 = dinput(8) / 100
        damping2 = dinput(9) / 100
        ncurves = dinput(10)
        '################## Termina entrada de datos
        durationA = durationEQ
        stepA = stepEQ / 2
        xooi = 0
        xoi = 0
        xi = 0

        ReDim spectrumA(npoints, ncurves)
        ReDim spectrumV(npoints, ncurves)
        ReDim spectrumD(npoints, ncurves)
        ReDim ductility(npoints, ncurves)
        ReDim speriod(npoints)
        pstep = (period2 - period1) / npoints

        npointsA = Int(durationA / stepA)
        'lee acelerograma
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim Preserve xooEQ(npointsA) 'pads with 0 at the end
        For q = 0 To npointsA
            xooEQ(q) = xooEQ(q) * eqfactor
        Next

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(0 To npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = xooEQ(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = xooEQ(q + 1) Else xooeq2 = 0
            P(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        stepdamping = (damping2 - damping1) / (ncurves - 1)
        For d As Integer = 1 To ncurves
            damping = damping1 + (d - 1) * stepdamping
            For n As Integer = 0 To npoints
                period = pstep * n + period1
                speriod(n) = period
                newmark1() 'analsis con acelerograma como entrada
                spectrumA(n, d) = maxxoo 'max acceleration
                spectrumV(n, d) = maxxo 'max velocity
                spectrumD(n, d) = maxx 'max displacement
                ductility(n, d) = 1
            Next
        Next
    End Sub

    Sub inelasticspectrum(ByRef dinput)
        'encuentra el amortiguamiento viscoso equivalente en funcion de los siguientes datos:
        Dim d As Integer
        eqfactor = dinput(1)
        durationEQ = dinput(2)
        stepEQ = dinput(3)
        period1 = dinput(4)
        If period1 = 0 Then period1 = 0.01
        period2 = dinput(5)
        npoints = dinput(6)
        mass = dinput(7)
        R1 = dinput(8)
        R2 = dinput(9)
        ncurves = dinput(10)
        rr = dinput(11)
        damping = dinput(12) / 100

        '################## Termina entrada de datos
        durationA = durationEQ
        stepA = stepEQ / 2
        xooi = 0
        xoi = 0
        xi = 0

        ReDim spectrumA(npoints, ncurves)
        ReDim spectrumV(npoints, ncurves)
        ReDim spectrumD(npoints, ncurves)
        ReDim ductility(npoints, ncurves)
        ReDim speriod(npoints)
        ReDim elasticforce(npoints)
        pstep = (period2 - period1) / npoints

        npointsA = Int(durationA / stepA)
        'lee acelerograma
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim Preserve xooEQ(npointsA) 'pads with 0 at the end
        For q = 0 To npointsA
            xooEQ(q) = xooEQ(q) * eqfactor
        Next

        'interpola acelerograma a stepA para obtener funcion de carga P(t)
        ReDim P(0 To npointsA)
        P(0) = 0
        For n As Integer = 0 To npointsA
            Ta = n * stepA
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = xooEQ(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = xooEQ(q + 1) Else xooeq2 = 0
            P(n) = -mass * (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        'run elastic spectral analysis R=1

        d = 1
        For n As Integer = 0 To npoints
            period = pstep * n + period1
            speriod(n) = period
            newmark1() 'analsis con acelerograma como entrada
            elasticforce(n) = maxxF 'max force
        Next

        If ncurves > 1 Then stepR = (R2 - R1) / (ncurves - 1) Else stepR = 0
        For d = 1 To ncurves
            r = R1 + (d - 1) * stepR
            For n As Integer = 0 To npoints
                period = pstep * n + period1
                Fy = elasticforce(n) / r
                newmark3() 'analsis con acelerograma como entrada
                spectrumA(n, d) = maxxoo 'max acceleration
                spectrumV(n, d) = maxxo 'max velocity
                spectrumD(n, d) = maxx 'max displacement
                ductility(n, d) = maxxD
            Next
        Next
    End Sub


    Sub spectralanalysissine(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        maxload = dinput(0)
        durationEQ = dinput(1)
        floading = dinput(2)
        period1 = dinput(3)
        period2 = dinput(4)
        npoints = dinput(5)
        mass = dinput(6)
        damping1 = dinput(7) / 100
        damping2 = dinput(8) / 100
        ncurves = dinput(9)

        xi = 0
        xoi = 0
        xooi = 0
        durationA = durationEQ


        ReDim spectrumA(npoints, ncurves)
        ReDim spectrumV(npoints, ncurves)
        ReDim spectrumD(npoints, ncurves)
        ReDim ductility(npoints, ncurves)
        ReDim speriod(npoints)
        pstep = (period2 - period1) / npoints

        stepdamping = (damping2 - damping1) / (ncurves - 1)
        For d As Integer = 1 To ncurves
            damping = damping1 + (d - 1) * stepdamping

            For n As Integer = 0 To npoints
                period = pstep * n + period1
                speriod(n) = period
                stepA1 = period / stepfactor
                stepA2 = 2 * pi / floading / stepfactor
                If stepA1 < stepA2 Then stepA = stepA1 Else stepA = stepA2
                stepEQ = stepA
                ReDim LoadFunction(Int(durationEQ / stepA))
                For nn As Integer = 0 To (Int(durationEQ / stepA))
                    LoadFunction(nn) = maxload * Math.Sin(floading * nn * stepA)
                Next
                newmark2()
                spectrumA(n, d) = maxxoo 'max acceleration
                spectrumV(n, d) = maxxo 'max velocity
                spectrumD(n, d) = maxx 'max displacement
                ductility(n, d) = 1 'ductilidad
            Next
        Next

    End Sub


    Sub spectralanalysissine_nonlinear(ByRef dinput)
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        Dim d As Integer

        maxload = dinput(0)
        durationEQ = dinput(1)
        floading = dinput(2)
        period1 = dinput(3)
        period2 = dinput(4)
        npoints = dinput(5)
        mass = dinput(6)
        R1 = dinput(7)
        R2 = dinput(8)
        ncurves = dinput(9)
        rr = dinput(10)
        damping = dinput(11) / 100

        xi = 0
        xoi = 0
        xooi = 0
        durationA = durationEQ

        ReDim spectrumA(npoints, ncurves)
        ReDim spectrumV(npoints, ncurves)
        ReDim spectrumD(npoints, ncurves)
        ReDim ductility(npoints, ncurves)
        ReDim speriod(npoints)
        ReDim elasticforce(npoints)
        pstep = (period2 - period1) / npoints

        d = 1
        For n As Integer = 0 To npoints
            period = pstep * n + period1
            speriod(n) = period
            stepA1 = period / stepfactorn
            stepA2 = 2 * pi / floading / stepfactorn
            If stepA1 < stepA2 Then stepA = stepA1 Else stepA = stepA2
            stepEQ = stepA
            npointsA = Int(durationEQ / stepA)
            ReDim P(npointsA)
            For nn As Integer = 0 To (npointsA)
                P(nn) = maxload * Math.Sin(floading * nn * stepA)
            Next
            newmark1() 'analsis con acelerograma como entrada
            elasticforce(n) = maxxF 'max force
        Next

        If ncurves > 1 Then stepR = (R2 - R1) / (ncurves - 1) Else stepR = 0
        For d = 1 To ncurves
            r = R1 + (d - 1) * stepR
            For n As Integer = 0 To npoints
                period = pstep * n + period1
                speriod(n) = period
                stepA1 = period / stepfactorn
                stepA2 = 2 * pi / floading / stepfactorn
                If stepA1 < stepA2 Then stepA = stepA1 Else stepA = stepA2
                stepEQ = stepA
                npointsA = Int(durationEQ / stepA)
                ReDim P(npointsA)
                For nn As Integer = 0 To (npointsA)
                    P(nn) = maxload * Math.Sin(floading * nn * stepA)
                Next
                Fy = elasticforce(n) / r
                newmark3()
                spectrumA(n, d) = maxxoo 'max acceleration
                spectrumV(n, d) = maxxo 'max velocity
                spectrumD(n, d) = maxx 'max displacement
                ductility(n, d) = maxxD 'ductilidad
            Next
        Next

    End Sub



    Sub newmark1()
        ' realiza analisis elastico con un acelerograma como entrada
        ' require los siguientes datos: Eqpath, eqfactor, durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        w = 2 * pi / period
        c = 2 * damping * w * mass
        k = w ^ 2 * mass

        'solucion
        maxxoo = 0
        maxxo = 0
        maxx = 0
        maxxF = 0
        ReDim xoo(npointsA)
        ReDim xo(npointsA)
        ReDim x(npointsA)
        ReDim t(npointsA)
        ReDim F(npointsA)
        Dim deltaxoo As Double
        Dim deltaxo As Double
        Dim deltax As Double


        xoo(0) = xooi : xo(0) = xoi : x(0) = xi
        For n As Integer = 1 To npointsA - 1
            t(n) = n * stepA
            mbar = mass + stepA / 2 * c + stepA ^ 2 / 6 * k
            deltaP = P(n) - P(n - 1)
            pbar = deltaP - stepA * c * xoo(n - 1) - stepA * k * (xo(n - 1) + stepA / 2 * xoo(n - 1))
            deltaxoo = pbar / mbar
            deltaxo = stepA * xoo(n - 1) + stepA / 2 * deltaxoo
            deltax = stepA * xo(n - 1) + stepA ^ 2 / 2 * xoo(n - 1) + stepA ^ 2 / 6 * deltaxoo
            xoo(n) = xoo(n - 1) + deltaxoo
            xo(n) = xo(n - 1) + deltaxo
            x(n) = x(n - 1) + deltax
            F(n) = F(n - 1) + k * deltax
            If Math.Abs(xoo(n)) > maxxoo Then maxxoo = Math.Abs(xoo(n))
            If Math.Abs(xo(n)) > maxxo Then maxxo = Math.Abs(xo(n))
            If Math.Abs(x(n)) > maxx Then maxx = Math.Abs(x(n))
            If Math.Abs(F(n)) > maxxF Then maxxF = Math.Abs(F(n))
        Next


    End Sub

    Sub newmark3()
        Dim vdes As Integer
        Dim vant As Integer
        Dim deltaPbar As Double
        Dim newdeltaR As Double
        Dim ktu As Double
        Dim deltaR As Double
        Dim kbar As Double
        Dim deltaF As Double
        Dim iter As Integer


        ' realiza analisis inelastico con un acelerograma como entrada
        ' require los siguientes datos: Eqpath, eqfactor, durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        ' also: Fy, r

        'solucion
        w = 2 * pi / period
        c = 2 * damping * w * mass
        kini = w ^ 2 * mass
        Dy = Fy / kini
        vdes = 1
        maxxoo = 0
        maxxo = 0
        maxx = 0
        maxxD = 0
        maxxF = 0
        ReDim xoo(npointsA)
        ReDim xo(npointsA)
        ReDim x(npointsA)
        ReDim t(npointsA)
        ReDim F(npointsA)
        Dim deltaxoo As Double
        Dim deltaxo As Double
        Dim deltax As Double

        xoo(0) = xooi : xo(0) = xoi : x(0) = xi : F(0) = 0
        kt = kini
        ' initial calculations
        Dim a As Single
        Dim b As Single
        a = 4 / stepA * mass + 2 * c
        b = 2 * mass

        For n As Integer = 1 To npointsA
            t(n) = n * stepA
            deltaPbar = (P(n) - P(n - 1)) + a * xo(n - 1) + b * xoo(n - 1)
            'determine tangent stiffness
            'modified Newton
            newdeltaR = deltaPbar
            ktu = kt
            For iter = 1 To 6 'to allow 6 iterations
                deltaR = newdeltaR
                If (vant <> vdes) Then
                    kt = kini : ktu = kini
                End If
                kbar = ktu + 2 / stepA * c + 4 * mass / stepA ^ 2
                deltax = deltaR / kbar
                x(n) = x(n - 1) + deltax
                'element force
                F(n) = F(n - 1) + kt * deltax
                Fp = kini * (Dy + rr * (x(n) - Dy))
                Fn = kini * (-Dy + rr * (x(n) + Dy))
                If F(n) >= Fp Then
                    F(n) = Fp : kt = kini * rr
                End If
                If F(n) <= Fn Then
                    F(n) = Fn : kt = kini * rr
                End If

                deltaF = F(n) - F(n - 1) + (kbar - ktu) * deltax
                newdeltaR = deltaR - deltaF
                If newdeltaR < 0.01 Then Exit For
                n = n + 1
            Next
            x(n - iter + 1) = x(n)
            F(n - iter + 1) = F(n)
            n = n - iter + 1
            deltax = x(n) - x(n - 1)
            deltaxo = 2 * deltax / stepA - 2 * xo(n - 1)
            deltaxoo = 4 / stepA ^ 2 * deltax - 4 / stepA * xo(n - 1) - 2 * xoo(n - 1)
            xoo(n) = xoo(n - 1) + deltaxoo
            If xo(n - 1) > 0 Then vant = 1 Else vant = -1
            xo(n) = xo(n - 1) + deltaxo
            If xo(n) < 0 Then vdes = -1 Else vdes = 1

            duct = x(n) / Dy

            If Math.Abs(xoo(n)) > maxxoo Then maxxoo = Math.Abs(xoo(n))
            If Math.Abs(xo(n)) > maxxo Then maxxo = Math.Abs(xo(n))
            If Math.Abs(x(n)) > maxx Then maxx = Math.Abs(x(n))
            If Math.Abs(F(n)) > maxxF Then maxxF = Math.Abs(F(n))
            If Math.Abs(duct) > maxxD Then maxxD = Math.Abs(duct)

        Next


    End Sub


    Sub newmark2()
        ' realiza analisis elastico con una funcion de fuerza como entrada
        ' require los siguientes datos:  durationEQ, stepEQ, mass, period, damping, stepA, durationA, xooi, xoi, xi
        w = 2 * pi / period
        c = 2 * damping * w * mass
        k = w ^ 2 * mass
        'loading function
        npointsA = Int(durationA / stepA)
        npointsEQ = Int(durationEQ / stepEQ)
        ReDim xooEQ(npointsA)
        For n As Integer = 0 To npointsA
            xooEQ(n) = 0
        Next
        'interpola loading function a stepA para obtener funcion de carga P(t)
        ReDim P(0 To npointsA)
        P(0) = 0

        For n As Integer = 1 To npointsA
            Ta = n * stepA
            If Ta >= durationEQ Then Exit For
            q = Int(Ta / stepEQ)
            T1eq = q * stepEQ
            T2eq = (q + 1) * stepEQ
            If q <= npointsEQ Then xooEQ1 = LoadFunction(q) Else xooEQ1 = 0
            If q < npointsEQ Then xooeq2 = LoadFunction(q + 1) Else xooeq2 = 0
            P(n) = (xooEQ1 + (Ta - T1eq) / (T2eq - T1eq) * (xooeq2 - xooEQ1))
        Next

        'solucion
        maxxoo = 0
        maxxo = 0
        maxx = 0
        maxxF = 0
        ReDim xoo(npointsA)
        ReDim xo(npointsA)
        ReDim x(npointsA)
        ReDim t(npointsA)
        ReDim F(npointsA)
        Dim deltaxoo As Double
        Dim deltaxo As Double
        Dim deltax As Double

        xoo(0) = xooi : xo(0) = xoi : x(0) = xi
        If Math.Abs(xoo(0)) > maxxoo Then maxxoo = Math.Abs(xoo(0))
        If Math.Abs(xo(0)) > maxxo Then maxxo = Math.Abs(xo(0))
        If Math.Abs(x(0)) > maxx Then maxx = Math.Abs(x(0))
        For n As Integer = 1 To npointsA - 1
            t(n) = n * stepA
            mbar = mass + stepA / 2 * c + stepA ^ 2 / 6 * k
            deltaP = P(n) - P(n - 1)
            pbar = deltaP - stepA * c * xoo(n - 1) - stepA * k * (xo(n - 1) + stepA / 2 * xoo(n - 1))
            deltaxoo = pbar / mbar
            deltaxo = stepA * xoo(n - 1) + stepA / 2 * deltaxoo
            deltax = stepA * xo(n - 1) + stepA ^ 2 / 2 * xoo(n - 1) + stepA ^ 2 / 6 * deltaxoo
            xoo(n) = xoo(n - 1) + deltaxoo
            xo(n) = xo(n - 1) + deltaxo
            x(n) = x(n - 1) + deltax
            F(n) = F(n - 1) + deltax * k
            If Math.Abs(xoo(n)) > maxxoo Then maxxoo = Math.Abs(xoo(n))
            If Math.Abs(xo(n)) > maxxo Then maxxo = Math.Abs(xo(n))
            If Math.Abs(x(n)) > maxx Then maxx = Math.Abs(x(n))
            If Math.Abs(F(n)) > maxxF Then maxxF = Math.Abs(F(n))
        Next

    End Sub



End Class


