Imports Microsoft.VisualBasic

Public Class MomentoCurvatura
    Dim ecun() As Double, fcun() As Double 'concrete strain and stress in mander model fon unconfined concrete
    Dim eccon() As Double, fccon() As Double 'concrete strain and stress in mander model for confined concrete
    Dim es() As Double, fs() As Double ' steel strain and stress vectors
    Dim Ec As Double, Ess As Double, Ast As Double, Dh As Double, clb As Double, s As Double, fpc As Double, fyh As Double, fy As Double, eco As Double, esm As Double, espall As Double, ecu As Double, section As String, d As Double, b As Double, ncx As Double, ncy As Double, wi As Double, dels As Double, stype As String, P As Double, ecMC As Double, slayers As Double, yna As Double, ductilitymode
    Dim dbl As Double, nbl As Integer, ecser As Double, ecdam, ncl As Double, npoints, pt As Integer, NAD As Double
    Dim fsu As Double, esh As Double, esu As Double, Hsec As Double, Wsec As Double, Hs As Double, fpcc As Double, ecc As Double
    Dim fibers(,) As Object
    Dim rt As Double, rmr As Double, rsr As Double, ro As Double, ros As Double, dbls As Double, nbls As Double, nfiber As Integer, pratio As Double, Mv As Double, dbh As Double, curv As Double
    Dim MCR(10, 51, 6) As Single
    Dim mpy As Double, fipy As Double, my As Double, fiy As Double, r As Double, Mn As Double, mes, mec As Double, fsr As Double, ssr As Double
    Dim rot As Double, sb As Double, sh As Double, Avsx As Double, Avsy As Double, RL(10, 6) As Double, RV(4, 4) As Double, CC(4, 4) As Double, areacon As Double, areaunc As Double, areast As Double, inertia, maxVcap As Double
    Const pi = 3.14159265358979
    Dim Mp As Double, Mneg As Double, ntsteel As Double, nbsteel As Double, nlsteel As Double, nslegs As Double, cover As Double, coverp As Double, maxy As Double, design As Integer, moment As Double, msx As Double, msy As Double, ms As Double, dbll As Double, nlegsx As Double, nlegsy As Double, Mu As Double, shr As Double, dblt As Double, dblb As Double
    Dim materialproperties(30, 10) As Double, sectionproperties(30, 10) As Double, designresult(30) As Double, nsections As Integer, nsection As Integer
    Dim figura1(,) As Object, figura2(,) As Object, figura3(,) As Object, figura4(,,) As Object, figura5(,,) As Object




    

    Sub readinput_design_beam(ByRef Dbeam_in() As Object, ByRef shear As Double)
        sb = Dbeam_in(1)       ' section base (mm)
        sh = Dbeam_in(2)          ' section height (mm)
        fpc = Dbeam_in(3)          ' concrete compressive strength (MPa)
        fy = Dbeam_in(4)          ' long steel yielding stress (MPa)
        fyh = Dbeam_in(5)         ' transverse steel yielding stress (MPa)
        Hs = Dbeam_in(6)           ' shear span (m)
        Mp = Dbeam_in(7)         ' Positive moment (kN-m)
        Mneg = Dbeam_in(8)           ' Negative moment (kN-m)
        ntsteel = Dbeam_in(9)             ' # bars of top steel
        nbsteel = Dbeam_in(10)            ' # bars of bottom steel
        nlsteel = Dbeam_in(11)            ' # lateral bars
        nslegs = Dbeam_in(12)           ' # of stirrup legs resisting shear
        s = Dbeam_in(13)           ' spacing of stirrups (mm)
        cover = Dbeam_in(14)            ' cover up to bottom bar centre(mm)
        coverp = Dbeam_in(15)  ' cover up to top bar centr(mm)
        dbll = Dbeam_in(16)  ' diameter of lateral bars(mm)
        shear = shear ' Cortante debido a cargas gravitacionales


    End Sub

    Sub readinput_design_reccol(ByRef Dreccol_in)
        sb = Dreccol_in(1)          ' section base (mm)
        sh = Dreccol_in(2)          ' section height (mm)
        fpc = Dreccol_in(3)         ' concrete compressive strength (MPa)
        fy = Dreccol_in(4)          ' long steel yielding stress (MPa)
        fyh = Dreccol_in(5)       ' transverse steel yielding stress (MPa)
        Hs = Dreccol_in(6)            ' shear span (m)
        Mp = Dreccol_in(7)           ' Moment (kN-m)
        P = Dreccol_in(8) * 1000        ' Carga axial (N)
        ntsteel = Dreccol_in(9)             ' # bars of top  and bottom steel
        nlsteel = Dreccol_in(10)             ' # bars of lateral steel
        rot = Dreccol_in(11)              ' # biaxial angle
        nlegsx = Dreccol_in(12)             ' # of stirrup legs resisting shear in x direction
        nlegsy = Dreccol_in(13)             ' # of stirrup legs resisting shear in y direction
        s = Dreccol_in(14)           ' spacing of stirrups (mm)
        cover = Dreccol_in(15)              ' cover up to top and bottom rebar centre(mm)
        coverp = Dreccol_in(16)             ' cover up to lateral rebar centre(mm)
    End Sub

    Sub readinput_design_circol(ByRef Dcircol_in)
        rt = Dcircol_in(1) / 2      ' section diameter (mm)
        fpc = Dcircol_in(2)            ' concrete compressive strength (MPa)
        fy = Dcircol_in(3)           ' long steel yielding stress (MPa)
        fyh = Dcircol_in(4)          ' transverse steel yielding stress (MPa)
        Hs = Dcircol_in(5)             ' shear span (m)
        Mu = Dcircol_in(6)         ' Moment (kN-m)
        P = Dcircol_in(7) * 1000        ' Carga axial (kN)
        nbl = Dcircol_in(8)             ' # bars of main reiforcement
        s = Dcircol_in(9)          ' spacing of stirrups (mm)
        rmr = rt - Dcircol_in(10)            ' cover up to top and bottom rebar centre(mm)
    End Sub

    Sub readinput_MC_circol(ByRef MCcircol_in)
        rt = MCcircol_in(1) / 2        ' section diameter (mm)
        fpc = MCcircol_in(2)           ' concrete compressive strength (MPa)
        fy = MCcircol_in(3)        ' long steel yielding stress (MPa)
        shr = MCcircol_in(4)            'steel hardening ratio
        fyh = MCcircol_in(5)           ' transverse steel yielding stress (MPa)
        Hs = MCcircol_in(6)         ' shear span (m)
        P = MCcircol_in(7) * 1000       ' Carga axial (N)
        nbl = MCcircol_in(8)             ' # bars of main reiforcement
        dbl = MCcircol_in(9)           'diameter bars of main reiforcement (mm)
        s = MCcircol_in(10)           ' spacing of transverse reinforcement (mm)
        Dh = MCcircol_in(11)          ' diameter of transverse reinforcement (mm)
        stype = MCcircol_in(12)     ' type of transverse reinforcement
        rmr = rt - MCcircol_in(13)       ' cover up main reinforcement rebar centre(mm)
        ductilitymode = MCcircol_in(14)
        nsection = 1
    End Sub
    Sub readnsection(ByRef n)
        nsection = n
    End Sub
    Sub readnsections(ByRef n)
        nsections = n
    End Sub
    Sub readinput_MC_circol_Parameter(ByRef MCcircol_in)
        rt = MCcircol_in(1, nsection) / 2       ' section diameter (mm)
        fpc = MCcircol_in(2, nsection)          ' concrete compressive strength (MPa)
        fy = MCcircol_in(3, nsection)       ' long steel yielding stress (MPa)
        shr = MCcircol_in(4, nsection)           'steel hardening ratio
        fyh = MCcircol_in(5, nsection)          ' transverse steel yielding stress (MPa)
        Hs = MCcircol_in(6, nsection)        ' shear span (m)
        P = MCcircol_in(7, nsection) * 1000      ' Carga axial (N)
        nbl = MCcircol_in(8, nsection)            ' # bars of main reiforcement
        dbl = MCcircol_in(9, nsection)          'diameter bars of main reiforcement (mm)
        s = MCcircol_in(10, nsection)          ' spacing of transverse reinforcement (mm)
        Dh = MCcircol_in(11, nsection)         ' diameter of transverse reinforcement (mm)
        stype = MCcircol_in(12, nsection)    ' type of transverse reinforcement
        rmr = rt - MCcircol_in(13, nsection)      ' cover up main reinforcement rebar centre(mm)
        ductilitymode = MCcircol_in(14, nsection)
    End Sub

    Sub readinput_MC_reccol(ByRef MCreccol_in)
        sb = MCreccol_in(1)          ' section base (mm)
        sh = MCreccol_in(2)            ' section height (mm)
        fpc = MCreccol_in(3)            ' concrete compressive strength (MPa)
        fy = MCreccol_in(4)           ' long steel yielding stress (MPa)
        shr = MCreccol_in(5)          ' steel hardening ratio
        fyh = MCreccol_in(6)        ' transverse steel yielding stress (MPa)
        Hs = MCreccol_in(7)             ' shear span (m)
        P = MCreccol_in(8) * 1000         ' Carga axial (N)
        ntsteel = MCreccol_in(9)              ' # bars of top and bottom steel
        dblt = MCreccol_in(10)             ' diameter bars of top and bottom steel
        nlsteel = MCreccol_in(11)             ' # bars of lateral steel
        dbll = MCreccol_in(12)             ' diameter bars of lateral steel
        rot = MCreccol_in(13)              ' # biaxial angle
        nlegsx = MCreccol_in(14)              ' # of stirrup legs resisting shear in x direction
        nlegsy = MCreccol_in(15)              ' # of stirrup legs resisting shear in y direction
        Dh = MCreccol_in(16)              ' diameter of stirrups
        s = MCreccol_in(17)            ' spacing of stirrups (mm)
        cover = MCreccol_in(18)              ' cover up to top and bottom rebar centre(mm)
        coverp = MCreccol_in(19)              ' cover up to lateral rebar centre(mm)
        ductilitymode = MCreccol_in(20)     ' ductility mode
        nsection = 1
    End Sub
    Sub readinput_MC_reccol_Parameter(ByRef MCreccol_in)
        sb = MCreccol_in(1, nsection)         ' section base (mm)
        sh = MCreccol_in(2, nsection)           ' section height (mm)
        fpc = MCreccol_in(3, nsection)           ' concrete compressive strength (MPa)
        fy = MCreccol_in(4, nsection)          ' long steel yielding stress (MPa)
        shr = MCreccol_in(5, nsection)         ' steel hardening ratio
        fyh = MCreccol_in(6, nsection)       ' transverse steel yielding stress (MPa)
        Hs = MCreccol_in(7, nsection)            ' shear span (m)
        P = MCreccol_in(8, nsection) * 1000        ' Carga axial (N)
        ntsteel = MCreccol_in(9, nsection)             ' # bars of top and bottom steel
        dblt = MCreccol_in(10, nsection)            ' diameter bars of top and bottom steel
        nlsteel = MCreccol_in(11, nsection)            ' # bars of lateral steel
        dbll = MCreccol_in(12, nsection)            ' diameter bars of lateral steel
        rot = MCreccol_in(13, nsection)             ' # biaxial angle
        nlegsx = MCreccol_in(14, nsection)             ' # of stirrup legs resisting shear in x direction
        nlegsy = MCreccol_in(15, nsection)             ' # of stirrup legs resisting shear in y direction
        Dh = MCreccol_in(16, nsection)             ' diameter of stirrups
        s = MCreccol_in(17, nsection)           ' spacing of stirrups (mm)
        cover = MCreccol_in(18, nsection)             ' cover up to top and bottom rebar centre(mm)
        coverp = MCreccol_in(19, nsection)             ' cover up to lateral rebar centre(mm)
        ductilitymode = MCreccol_in(20, nsection)    ' ductility mode
    End Sub
    Sub readinput_MC_beam(ByRef MCbeam_in)
        'beam MC
        sb = MCbeam_in(1)           ' section base (mm)
        sh = MCbeam_in(2)            ' section height (mm)
        fpc = MCbeam_in(3)            ' concrete compressive strength (MPa)
        fy = MCbeam_in(4)           ' long steel yielding stress (MPa)
        shr = MCbeam_in(5)          ' steel hardening ratio
        fyh = MCbeam_in(6)          ' transverse steel yielding stress (MPa)
        Hs = MCbeam_in(7)            ' shear span (m)
        ntsteel = MCbeam_in(8)             ' # bars of top steel
        dblt = MCbeam_in(9)              ' diameter bars of top steel
        nbsteel = MCbeam_in(10)              ' # bars of bottom steel
        dblb = MCbeam_in(11)            ' diameter bars of bottom steel
        nlsteel = MCbeam_in(12)             ' # bars of lateral steel
        dbll = MCbeam_in(13)              ' diameter bars of lateral steel
        nlegsx = MCbeam_in(14)             ' # of stirrup legs resisting shear in x direction
        nlegsy = MCbeam_in(15)            ' # of stirrup legs resisting shear in y direction
        Dh = MCbeam_in(16)              ' diameter of stirrups
        s = MCbeam_in(17)            ' spacing of stirrups (mm)
        coverp = MCbeam_in(18)             ' cover up to top  rebar centre(mm)
        cover = MCbeam_in(19)              ' cover up to bottom rebar centre(mm)
        ductilitymode = MCbeam_in(20)     ' ductility mode
        rot = MCbeam_in(21)    ' rotation
        nsection = 1
    End Sub
    Sub readinput_MC_beam_Parameter(ByRef MCbeam_in)
        'beam MC
        sb = MCbeam_in(1, nsection)          ' section base (mm)
        sh = MCbeam_in(2, nsection)           ' section height (mm)
        fpc = MCbeam_in(3, nsection)           ' concrete compressive strength (MPa)
        fy = MCbeam_in(4, nsection)          ' long steel yielding stress (MPa)
        shr = MCbeam_in(5, nsection)         ' steel hardening ratio
        fyh = MCbeam_in(6, nsection)         ' transverse steel yielding stress (MPa)
        Hs = MCbeam_in(7, nsection)           ' shear span (m)
        ntsteel = MCbeam_in(8, nsection)            ' # bars of top steel
        dblt = MCbeam_in(9, nsection)             ' diameter bars of top steel
        nbsteel = MCbeam_in(10, nsection)             ' # bars of bottom steel
        dblb = MCbeam_in(11, nsection)           ' diameter bars of bottom steel
        nlsteel = MCbeam_in(12, nsection)            ' # bars of lateral steel
        dbll = MCbeam_in(13, nsection)             ' diameter bars of lateral steel
        nlegsx = MCbeam_in(14, nsection)            ' # of stirrup legs resisting shear in x direction
        nlegsy = MCbeam_in(15, nsection)           ' # of stirrup legs resisting shear in y direction
        Dh = MCbeam_in(16, nsection)             ' diameter of stirrups
        s = MCbeam_in(17, nsection)           ' spacing of stirrups (mm)
        cover = MCbeam_in(18, nsection)            ' cover up to top and bottom rebar centre(mm)
        coverp = MCbeam_in(19, nsection)             ' cover up to lateral rebar centre(mm)
        ductilitymode = MCbeam_in(20, nsection)    ' ductility mode
        rot = MCbeam_in(21, nsection)   ' rotation
    End Sub

    Public Function Return_sectionproperties() As Object
        Dim matrix(30, 10)
        
        For i As Integer = 1 To 30
            For j As Integer = 1 To 10
                matrix(i, j) = sectionproperties(i, j)
            Next
        Next
        Return_sectionproperties = matrix
    End Function

    Public Function Return_materialproperties() As Object
        Dim matrix(30, 10)
        For i As Integer = 1 To 30
            For j As Integer = 1 To 10
                matrix(i, j) = materialproperties(i, j)
            Next
        Next
        Return_materialproperties = matrix
    End Function

    Public Function Return_MCcurves() As Object
        Dim matrix(10, 51, 6)
        For k As Integer = 1 To 10
            For i As Integer = 0 To 50
                For j As Integer = 1 To 6
                    matrix(k, i, j) = MCR(k, i, j)
                Next
            Next
        Next
        Return_MCcurves = matrix
    End Function
    Public Function Return_Designresult() As Object
        Dim vector(30) As Object
        For i As Integer = 1 To 30
            vector(i) = designresult(i)
        Next
        Return_Designresult = vector
    End Function



    Sub MC_circol()
        Dim cduct As Double
        Dim ecinc As Double
        'ReDim MCR(10, 51, 6)
        'ReDim materialproperties(30, 10)
        'ReDim sectionproperties(30, 10)


        design = 0
        npoints = 50
        ms = 50 'size of mesh
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * shr         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        ro = 0 ' no void
        dbls = 0 : nbls = 0 'no secondary ring
        section = "circular"
        sectioncircular1()
        ecinc = ecu / npoints
        yna = rt / 2
        pt = 1
        mes = 0 'maximum steel strain
        mec = 0
        mpy = 0
        Mn = 0
        cduct = 0
        For ecMC = ecinc To ecu Step ecinc
            MC()
            If fiy > 0 Then cduct = MCR(nsection, pt, 1) / fiy
            If cduct > 20 Then Exit For
        Next
        For n As Integer = pt To 50
            For i As Integer = 1 To 6
                MCR(nsection, n, i) = MCR(nsection, pt, i)
            Next
        Next

        MCR(nsection, 1, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 2, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 3, 6) = MCR(nsection, 4, 6)


        ssr = ((MCR(nsection, npoints - 1, 2) - Mn) / (MCR(nsection, npoints - 1, 1) - fiy)) / (mpy / fipy)

        ''RESULTADOS

        materialproperties(1, nsection) = Ec                      ' Elastic Modulus of Concrete
        materialproperties(2, nsection) = fpc                     ' Unconfined concrete strength
        materialproperties(3, nsection) = eco                     ' strain at unconfined concrete strength
        materialproperties(4, nsection) = espall                  ' ultimate unconfined strain (spalling)
        materialproperties(5, nsection) = fpcc                     ' confined concrete strength
        materialproperties(6, nsection) = ecc                     ' strain at confined concrete strength
        materialproperties(7, nsection) = ecu                     ' ultimate confined strain (spalling)
        materialproperties(8, nsection) = Ess                     ' Elastic Modulus of Steel
        materialproperties(9, nsection) = fy                      ' Yield strengh of longitudinal reinforcement
        materialproperties(10, nsection) = fy / Ess               ' Yield strain of longitudinal reinforcement
        materialproperties(11, nsection) = esh                    ' strain at begining of strain hardening
        materialproperties(12, nsection) = fy * shr               ' max strength of reinforment steel
        materialproperties(13, nsection) = esu                    ' strain at maximum strenght of reinforcement steel
        materialproperties(14, nsection) = fyh                    ' Yield strengh of transverse reinforcement
        materialproperties(15, nsection) = esm                    ' ultimate strain of transverse reinforcement

        sectionproperties(1, nsection) = fsr                         ' Longitudinal steel ratio
        sectionproperties(2, nsection) = ros                         ' transverse steel ratio
        sectionproperties(3, nsection) = pratio                      ' Axial Load Ratio
        sectionproperties(4, nsection) = inertia                     ' Inertia
        sectionproperties(5, nsection) = mpy                         ' Moment at first yield
        sectionproperties(6, nsection) = fipy                        ' Curvature at first yield
        sectionproperties(7, nsection) = Mn                          ' Nominal moment strength
        sectionproperties(8, nsection) = fiy                         ' Nominal yield curvature
        sectionproperties(9, nsection) = ecser                       ' Concrete strain at nominal moment strengh
        sectionproperties(10, nsection) = MCR(nsection, npoints - 1, 2)        ' Damage control moment
        sectionproperties(11, nsection) = MCR(nsection, npoints - 1, 1)       ' Damage control curvature
        sectionproperties(12, nsection) = ssr                        ' Second to first slope ratio
        sectionproperties(13, nsection) = MCR(nsection, npoints - 1, 1) / fiy  ' Ductilidad
        sectionproperties(14, nsection) = rt
        sectionproperties(15, nsection) = rot  ' Rotacion

        'La matrix MCR contiene las curvas MC

    End Sub

    

    Sub MC_reccol()
        Dim cduct As Double
        Dim spac As Double
        Dim ecinc As Double
        'ReDim MCR(10, 51, 6)
        'ReDim materialproperties(30, 10)
        'ReDim sectionproperties(30, 10)


        design = 0
        npoints = 50
        msy = 50 'size of mesh in y direction
        msx = 50 'size of mesh in x direction
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * shr         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        ' confined core
        CC(1, 1) = -sb / 2 + coverp          ' x1 confined core 1
        CC(1, 2) = -sh / 2 + cover              ' y1 confined core 1
        CC(1, 3) = sb / 2 - coverp               ' x2 confined core 1
        CC(1, 4) = sh / 2 - cover               ' y2 confined core 1
        ' bottom reinforcement
        RL(1, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 1
        RL(1, 2) = -sh / 2 + cover              ' y1 reinforcing layer 1
        RL(1, 3) = sb / 2 - coverp              ' x2 reinforcing layer 1
        RL(1, 4) = -sh / 2 + cover              ' y2 reinforcing layer 1
        RL(1, 5) = ntsteel / 2                    ' #bars reinforcing layer 1
        RL(1, 6) = dblt              ' dia. bars reinforcing layer 1
        ' top reinforcement
        RL(2, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 2
        RL(2, 2) = sh / 2 - cover             ' y1 reinforcing layer 2
        RL(2, 3) = sb / 2 - coverp              ' x2 reinforcing layer 2
        RL(2, 4) = sh / 2 - cover              ' y2 reinforcing layer 2
        RL(2, 5) = ntsteel / 2                    ' #bars reinforcing layer 2
        RL(2, 6) = dblt                  ' dia. bars reinforcing layer 2

        ' lateral left reinforcement
        If nlsteel > 0 Then
            spac = (sh - 2 * cover) / (nlsteel / 2 + 1)
            RL(3, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 3
            RL(3, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 3
            RL(3, 3) = -sb / 2 + coverp             ' x2 reinforcing layer 3
            RL(3, 4) = sh / 2 - cover - spac              ' y2 reinforcing layer 3
            RL(3, 5) = nlsteel / 2                    ' #bars reinforcing layer 3
            RL(3, 6) = dbll              ' dia. bars reinforcing layer 3
            RL(4, 1) = sb / 2 - coverp               ' x1 reinforcing layer 4
            RL(4, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 4
            RL(4, 3) = sb / 2 - coverp             ' x2 reinforcing layer 4
            RL(4, 4) = sh / 2 - cover - spac             ' y2 reinforcing layer 4
            RL(4, 5) = nlsteel / 2                    ' #bars reinforcing layer 4
            RL(4, 6) = dbll              ' dia. bars reinforcing layer 4
        End If

        'min shear reinforcement for flexural design
        Avsy = nlegsy * Dh ^ 2 * pi / 4    ' area of steel resisting shear in Y direction
        Avsx = nlegsx * Dh ^ 2 * pi / 4    ' area of steel resisting shear in X direction
        section = "rectangular"
        sectionrectangular1()
        ecinc = ecu / npoints
        yna = maxy * 0.7
        rt = maxy
        pt = 1
        mes = 0 'maximum steel strain
        mec = 0
        mpy = 0
        Mn = 0
        cduct = 0
        For ecMC = ecinc To ecu Step ecinc
            MC()
            If fiy > 0 Then cduct = MCR(nsection, pt, 1) / fiy
            If cduct > 20 Then Exit For
        Next
        For n As Integer = pt To 50
            For i As Integer = 1 To 6
                MCR(nsection, n, i) = MCR(nsection, pt, i)
            Next
        Next

        MCR(nsection, 1, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 2, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 3, 6) = MCR(nsection, 4, 6)

        ssr = ((MCR(nsection, npoints - 1, 2) - Mn) / (MCR(nsection, npoints - 1, 1) - fiy)) / (mpy / fipy)

        ''RESULTADOS

        materialproperties(1, nsection) = Ec                      ' Elastic Modulus of Concrete
        materialproperties(2, nsection) = fpc                     ' Unconfined concrete strength
        materialproperties(3, nsection) = eco                     ' strain at unconfined concrete strength
        materialproperties(4, nsection) = espall                  ' ultimate unconfined strain (spalling)
        materialproperties(5, nsection) = fpcc                     ' confined concrete strength
        materialproperties(6, nsection) = ecc                     ' strain at confined concrete strength
        materialproperties(7, nsection) = ecu                     ' ultimate confined strain (spalling)
        materialproperties(8, nsection) = Ess                     ' Elastic Modulus of Steel
        materialproperties(9, nsection) = fy                      ' Yield strengh of longitudinal reinforcement
        materialproperties(10, nsection) = fy / Ess               ' Yield strain of longitudinal reinforcement
        materialproperties(11, nsection) = esh                    ' strain at begining of strain hardening
        materialproperties(12, nsection) = fy * shr               ' max strength of reinforment steel
        materialproperties(13, nsection) = esu                    ' strain at maximum strenght of reinforcement steel
        materialproperties(14, nsection) = fyh                    ' Yield strengh of transverse reinforcement
        materialproperties(15, nsection) = esm                    ' ultimate strain of transverse reinforcement

        sectionproperties(1, nsection) = fsr                         ' Longitudinal steel ratio
        sectionproperties(2, nsection) = ros                         ' transverse steel ratio
        sectionproperties(3, nsection) = pratio                      ' Axial Load Ratio
        sectionproperties(4, nsection) = inertia                     ' Inertia
        sectionproperties(5, nsection) = mpy                         ' Moment at first yield
        sectionproperties(6, nsection) = fipy                        ' Curvature at first yield
        sectionproperties(7, nsection) = Mn                          ' Nominal moment strength
        sectionproperties(8, nsection) = fiy                         ' Nominal yield curvature
        sectionproperties(9, nsection) = ecser                       ' Concrete strain at nominal moment strengh
        sectionproperties(10, nsection) = MCR(nsection, npoints - 1, 2)        ' Damage control moment
        sectionproperties(11, nsection) = MCR(nsection, npoints - 1, 1)       ' Damage control curvature
        sectionproperties(12, nsection) = ssr                        ' Second to first slope ratio
        sectionproperties(13, nsection) = MCR(nsection, npoints - 1, 1) / fiy  ' Ductilidad
        sectionproperties(14, nsection) = rt
        sectionproperties(15, nsection) = rot  ' Rotacion
        'La matrix MCR contiene las curvas MC

    End Sub

    Sub MC_beam()
        Dim cduct As Single
        Dim spac As Single
        Dim ecinc As Single

        'ReDim MCR(10, 51, 6)
        'ReDim materialproperties(30, 10)
        'ReDim sectionproperties(30, 10)

        design = 0
        npoints = 50
        P = 0
        msy = 50 'size of mesh in y direction
        msx = 1 'size of mesh in x direction
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * shr         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        ' confined core
        CC(1, 1) = -sb / 2 + coverp          ' x1 confined core 1
        CC(1, 2) = -sh / 2 + cover              ' y1 confined core 1
        CC(1, 3) = sb / 2 - coverp               ' x2 confined core 1
        CC(1, 4) = sh / 2 - coverp               ' y2 confined core 1
        ' bottom reinforcement
        RL(1, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 1
        RL(1, 2) = -sh / 2 + cover              ' y1 reinforcing layer 1
        RL(1, 3) = sb / 2 - coverp              ' x2 reinforcing layer 1
        RL(1, 4) = -sh / 2 + cover              ' y2 reinforcing layer 1
        RL(1, 5) = nbsteel                    ' #bars reinforcing layer 1
        RL(1, 6) = dblb              ' dia. bars reinforcing layer 1
        ' top reinforcement
        RL(2, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 2
        RL(2, 2) = sh / 2 - coverp             ' y1 reinforcing layer 2
        RL(2, 3) = sb / 2 - coverp              ' x2 reinforcing layer 2
        RL(2, 4) = sh / 2 - coverp              ' y2 reinforcing layer 2
        RL(2, 5) = ntsteel                    ' #bars reinforcing layer 2
        RL(2, 6) = dblt                  ' dia. bars reinforcing layer 2

        ' lateral left reinforcement
        If nlsteel > 0 Then
            spac = (sh - cover - coverp) / (nlsteel / 2 + 1)
            RL(3, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 3
            RL(3, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 3
            RL(3, 3) = -sb / 2 + coverp             ' x2 reinforcing layer 3
            RL(3, 4) = sh / 2 - coverp - spac              ' y2 reinforcing layer 3
            RL(3, 5) = nlsteel / 2                    ' #bars reinforcing layer 3
            RL(3, 6) = dbll              ' dia. bars reinforcing layer 3
            RL(4, 1) = sb / 2 - coverp               ' x1 reinforcing layer 4
            RL(4, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 4
            RL(4, 3) = sb / 2 - coverp             ' x2 reinforcing layer 4
            RL(4, 4) = sh / 2 - coverp - spac             ' y2 reinforcing layer 4
            RL(4, 5) = nlsteel / 2                    ' #bars reinforcing layer 4
            RL(4, 6) = dbll              ' dia. bars reinforcing layer 4
        End If
        'min shear reinforcement for flexural design
        Avsy = nlegsy * Dh ^ 2 * pi / 4    ' area of steel resisting shear in Y direction
        Avsx = nlegsx * Dh ^ 2 * pi / 4    ' area of steel resisting shear in X direction
        section = "rectangular"
        sectionrectangular1()
        ecinc = ecu / npoints
        yna = maxy * 0.7
        rt = maxy

        pt = 1
        mes = 0 'maximum steel strain
        mec = 0
        mpy = 0
        Mn = 0
        fiy = 0

        For ecMC = ecinc To ecu Step ecinc
            MC()
            'comienza nuevo
            If fiy > 0 Then cduct = MCR(nsection, pt, 1) / fiy
            'termina nuevo
            If cduct > 20 Then Exit For
        Next
        For n As Integer = pt To 50
            For i As Integer = 1 To 6
                MCR(nsection, n, i) = MCR(nsection, pt, i)
            Next
        Next

        MCR(nsection, 1, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 2, 6) = MCR(nsection, 4, 6)
        MCR(nsection, 3, 6) = MCR(nsection, 4, 6)

        'comienza nuevo
        If fipy > 0 Then ssr = ((MCR(nsection, npoints - 1, 2) - Mn) / (MCR(nsection, npoints - 1, 1) - fiy)) / (mpy / fipy)
        'termina nuevo

        'OJO ESTO LO COMENTÉ EL 24 DE ABRIL DE 2009''''' ssr = ((MCR(nsection, npoints - 1, 2) - Mn) / (MCR(nsection, npoints - 1, 1) - fiy)) / (mpy / fipy)

        ''RESULTADOS

        materialproperties(1, nsection) = Ec                      ' Elastic Modulus of Concrete
        materialproperties(2, nsection) = fpc                     ' Unconfined concrete strength
        materialproperties(3, nsection) = eco                     ' strain at unconfined concrete strength
        materialproperties(4, nsection) = espall                  ' ultimate unconfined strain (spalling)
        materialproperties(5, nsection) = fpcc                     ' confined concrete strength
        materialproperties(6, nsection) = ecc                     ' strain at confined concrete strength
        materialproperties(7, nsection) = ecu                     ' ultimate confined strain (spalling)
        materialproperties(8, nsection) = Ess                     ' Elastic Modulus of Steel
        materialproperties(9, nsection) = fy                      ' Yield strengh of longitudinal reinforcement
        materialproperties(10, nsection) = fy / Ess               ' Yield strain of longitudinal reinforcement
        materialproperties(11, nsection) = esh                    ' strain at begining of strain hardening
        materialproperties(12, nsection) = fy * shr               ' max strength of reinforment steel
        materialproperties(13, nsection) = esu                    ' strain at maximum strenght of reinforcement steel
        materialproperties(14, nsection) = fyh                    ' Yield strengh of transverse reinforcement
        materialproperties(15, nsection) = esm                    ' ultimate strain of transverse reinforcement

        sectionproperties(1, nsection) = fsr                         ' Longitudinal steel ratio
        sectionproperties(2, nsection) = ros                         ' transverse steel ratio
        sectionproperties(3, nsection) = pratio                      ' Axial Load Ratio
        sectionproperties(4, nsection) = inertia                     ' Inertia
        sectionproperties(5, nsection) = mpy                         ' Moment at first yield
        sectionproperties(6, nsection) = fipy                        ' Curvature at first yield
        sectionproperties(7, nsection) = Mn                          ' Nominal moment strength
        sectionproperties(8, nsection) = fiy                         ' Nominal yield curvature
        sectionproperties(9, nsection) = ecser                       ' Concrete strain at nominal moment strengh
        sectionproperties(10, nsection) = MCR(nsection, npoints - 1, 2)        ' Damage control moment
        sectionproperties(11, nsection) = MCR(nsection, npoints - 1, 1)       ' Damage control curvature
        sectionproperties(12, nsection) = ssr                        ' Second to first slope ratio
        'comienza nuevo
        If fiy > 0 Then sectionproperties(13, nsection) = MCR(nsection, npoints - 1, 1) / fiy ' Ductilidad
        'termina nuevo

        'ESTO LO COMENTE EL 24 DE ABRIL DE 2009''''''sectionproperties(13, nsection) = MCR(nsection, npoints - 1, 1) / fiy  ' Ductilidad
        sectionproperties(14, nsection) = rt

        'La matrix MCR contiene las curvas MC

    End Sub


    Sub sectioncircular1()
        Dim xm1 As Double
        ReDim fibers(20000, 7)
        Dim rf As Single
        Dim deltang As Single
        Dim barang As Single
        Dim xf As Single
        Dim ym1 As Double
        Dim fsize As Double
        Dim yf As Double
        Dim af As Double

        nfiber = 0
        'maps a circular section with 3 types of materials unmander 1, mander 2, steelking 3
        'fibers(nfiber,x,y,area,material,stress,strain,force)
        'mesh borders
        xm1 = -rt
        ym1 = -rt
        fsize = (2 * -xm1) / ms
        'concrete fibers
        For i As Integer = 1 To ms
            For j As Integer = 1 To ms
                xf = xm1 + (i - 1) * fsize + fsize / 2
                yf = ym1 + (j - 1) * fsize + fsize / 2
                af = fsize ^ 2 ' area of fiber in mm
                rf = (xf ^ 2 + yf ^ 2) ^ 0.5
                If rf > (rmr + dbl / 2 + dbh / 2) And rf < rt And rf > ro Then
                    nfiber = nfiber + 1
                    fibers(nfiber, 1) = xf
                    fibers(nfiber, 2) = yf
                    fibers(nfiber, 3) = af
                    fibers(nfiber, 4) = 1 'unconfined concrete
                End If
                If rf <= (rmr + dbl / 2 + dbh / 2) And rf >= ro Then
                    nfiber = nfiber + 1
                    fibers(nfiber, 1) = xf
                    fibers(nfiber, 2) = yf
                    fibers(nfiber, 3) = af
                    fibers(nfiber, 4) = 2 'confined concrete
                End If

            Next
        Next

        'steel fibers
        deltang = 2 * pi / nbl 'main ring
        barang = 0
        af = pi * dbl ^ 2 / 4
        For n As Integer = 1 To nbl
            barang = (n - 1) * deltang
            yf = rmr * Math.Cos(barang)
            xf = rmr * Math.Sin(barang)
            nfiber = nfiber + 1
            fibers(nfiber, 1) = xf
            fibers(nfiber, 2) = yf
            fibers(nfiber, 3) = af
            fibers(nfiber, 4) = 3 'steel
        Next
        If nbls > 0 Then
            deltang = 2 * pi / nbls 'secondary ring
            barang = 0
            af = pi * dbls ^ 2 / 4
            For n As Integer = 1 To nbls
                barang = (n - 1) * deltang
                yf = rsr * Math.Cos(barang)
                xf = rsr * Math.Sin(barang)
                nfiber = nfiber + 1
                fibers(nfiber, 1) = xf
                fibers(nfiber, 2) = yf
                fibers(nfiber, 3) = af
                fibers(nfiber, 4) = 3 'steel
            Next
        End If
        'material models
        dels = 0.0001      '    % delta strain for default material models
        pratio = P / ((rt ^ 2 - ro ^ 0) * pi * fpc)
        If design = 0 Then manderun()
        If design = 0 Then manderconf()
        steelking()
    End Sub

    Sub sectionrectangular1()
        ReDim Preserve fibers(20000, 7)
        Dim fsizex As Single
        Dim fsizey As Single
        Dim Void As Single
        Dim xv1 As Single
        Dim yv1 As Single
        Dim xv2 As Single
        Dim yv2 As Single
        Dim confined As Single
        Dim xstep As Single
        Dim ystep As Single
        Dim xpf As Single
        Dim ypf As Single
        Dim xm1 As Double
        Dim ym1 As Double
        Dim xf As Double
        Dim yf As Double
        Dim af As Double

        areaunc = 0
        areacon = 0
        areast = 0

        nfiber = 0
        'maps a rectangular section with 3 types of materials unmander 1, mander 2, steelking 3
        'fibers(nfiber,x,y,area,material,stress,strain,force)
        'mesh borders
        xm1 = -sb / 2
        ym1 = -sh / 2
        fsizex = (2 * -xm1) / msx
        fsizey = (2 * -ym1) / msy

        'concrete fibers
        For i As Integer = 1 To msx
            For j As Integer = 1 To msy
                xf = xm1 + (i - 1) * fsizex + fsizex / 2
                yf = ym1 + (j - 1) * fsizey + fsizey / 2
                af = fsizex * fsizey ' area of fiber in mm
                'checking if it is on void
                Void = 0
                For n As Integer = 1 To 4
                    xv1 = RV(n, 1) : yv1 = RV(n, 2) : xv2 = RV(n, 3) : yv2 = RV(n, 4)
                    If xf > xv1 And xf < xv2 And yf > yv1 And yf < yv2 Then Void = 1
                Next
                confined = 0
                'checking if it is on confined region
                For n As Integer = 1 To 4
                    xv1 = CC(n, 1) : yv1 = CC(n, 2) : xv2 = CC(n, 3) : yv2 = CC(n, 4)
                    If xf > xv1 And xf < xv2 And yf > yv1 And yf < yv2 Then confined = 1
                Next
                If confined = 0 And Void = 0 Then
                    nfiber = nfiber + 1
                    fibers(nfiber, 1) = xf
                    fibers(nfiber, 2) = yf
                    fibers(nfiber, 3) = af
                    fibers(nfiber, 4) = 1 'unconfined concrete
                    areaunc = areaunc + af
                End If
                If confined = 1 And Void = 0 Then
                    nfiber = nfiber + 1
                    fibers(nfiber, 1) = xf
                    fibers(nfiber, 2) = yf
                    fibers(nfiber, 3) = af
                    fibers(nfiber, 4) = 2 'unconfined concrete
                    areacon = areacon + af
                End If

            Next
        Next

        'steel fibers
        For m As Integer = 1 To 10
            xv1 = RL(m, 1) : yv1 = RL(m, 2) : xv2 = RL(m, 3) : yv2 = RL(m, 4)
            nbl = RL(m, 5)
            dbl = RL(m, 6)
            If nbl > 0 Then
                xstep = (xv2 - xv1) / (nbl - 1)
                ystep = (yv2 - yv1) / (nbl - 1)
                af = pi * dbl ^ 2 / 4
                For n As Integer = 1 To nbl
                    xf = xv1 + (n - 1) * xstep
                    yf = yv1 + (n - 1) * ystep
                    nfiber = nfiber + 1
                    fibers(nfiber, 1) = xf
                    fibers(nfiber, 2) = yf
                    fibers(nfiber, 3) = af
                    fibers(nfiber, 4) = 3 'steel
                    areast = areast + af
                Next
            End If
        Next

        'coor rotation
        maxy = 0
        For n As Integer = 1 To nfiber
            xf = fibers(n, 1)
            yf = fibers(n, 2)
            xpf = xf * Math.Cos(rot * pi / 180) - yf * Math.Sin(rot * pi / 180)
            ypf = yf * Math.Cos(rot * pi / 180) + xf * Math.Sin(rot * pi / 180)
            fibers(n, 1) = xpf
            fibers(n, 2) = ypf
            If ypf > maxy Then maxy = ypf
        Next

        'material models
        dels = 0.0001      '    % delta strain for default material models
        pratio = P / ((areacon + areaunc) * fpc)
        If design = 0 Then manderun()
        If design = 0 Then manderconf()
        steelking()
    End Sub

    Sub MC()
        Dim itermc As Double
        Dim CCC As Double
        Dim e As Double
        Dim stress As Double
        Dim force As Double
        Dim c As Double
        Dim t As Double
        Dim finc As Double
        Dim fint As Double
        Dim i As Integer
        Dim eps As Double
        Dim ff1 As Double
        Dim fff As Double
        Dim ey As Double
        pt = pt + 1
        itermc = 0
        CCC = 0.1
        mes = 0
        mec = 0

        Do
            itermc = itermc + 1
            NAD = rt - yna
            curv = ecMC / NAD ' in 1/mm
            For n As Integer = 1 To nfiber
                'computing strain
                e = curv * (fibers(n, 2) - yna)  ' positive strains are compresion
                If fibers(n, 4) = 3 And e < mes Then mes = e
                If e > mec Then
                    mec = e
                End If

                If fibers(n, 2) > yna And fibers(n, 4) < 3 Then 'only analyzes concrete fibers in compresion zone
                    If fibers(n, 4) = 1 Then 'interpolate strees from unconfined model
                        i = 0
                        If e < espall * 0.98 And e > 0 Then
                            Do
                                i = i + 1
                                eps = ecun(i)
                                If eps > e Then Exit Do
                            Loop
                            stress = (fcun(i) - fcun(i - 1)) / (ecun(i) - ecun(i - 1)) * (e - ecun(i - 1)) + fcun(i - 1)
                        Else
                            stress = 0
                        End If
                        force = stress * fibers(n, 3)
                        fibers(n, 5) = e
                        fibers(n, 6) = stress
                        fibers(n, 7) = force
                    End If

                    If fibers(n, 4) = 2 Then 'interpolate strees from confined model
                        i = 0
                        If e < ecu * 0.99 And e > 0 Then
                            Do
                                i = i + 1
                                eps = eccon(i)
                                If eps > e Then Exit Do
                            Loop
                            stress = (fccon(i) - fccon(i - 1)) / (eccon(i) - eccon(i - 1)) * (e - eccon(i - 1)) + fccon(i - 1)
                        Else
                            stress = 0
                        End If
                        force = stress * fibers(n, 3)
                        fibers(n, 5) = e
                        fibers(n, 6) = stress
                        fibers(n, 7) = force
                    End If
                Else
                    fibers(n, 5) = e
                    fibers(n, 6) = 0
                    fibers(n, 7) = 0
                End If

                If fibers(n, 4) = 3 Then 'interpolate strees from steel model

                    i = 0
                    If Math.Abs(e) < esu * 0.99 And Math.Abs(e) > 0 Then
                        Do
                            i = i + 1
                            eps = es(i)
                            If eps > Math.Abs(e) Then Exit Do
                        Loop
                        stress = (fs(i) - fs(i - 1)) / (es(i) - es(i - 1)) * (Math.Abs(e) - es(i - 1)) + fs(i - 1)
                    Else
                        stress = 0
                    End If
                    force = stress * fibers(n, 3)
                    fibers(n, 5) = e
                    fibers(n, 6) = stress
                    fibers(n, 7) = force
                End If


            Next

            'check equilibrium

            'computing compresion and tension forces
            c = 0
            t = 0
            finc = 0
            fint = 0
            For n As Integer = 1 To nfiber
                If fibers(n, 5) > 0 Then
                    c = c + fibers(n, 7)
                    finc = finc + 1
                Else
                    t = t + fibers(n, 7)
                    fint = fint + 1
                End If
            Next
            t = t + P

            If itermc > 1 Then ff1 = fff
            If c > t Then NAD = NAD - CCC * NAD : fff = -1 Else NAD = NAD + CCC * NAD : fff = 1
            If ff1 <> fff And itermc > 1 Then CCC = CCC / 2
            If (Math.Abs(c - t) / c) < 0.000001 Then Exit Do
            If itermc = 100 Then Exit Do
            yna = rt - NAD
        Loop

        moment = 0
        For n As Integer = 1 To nfiber
            moment = moment + Math.Abs(fibers(n, 2)) / 1000 * fibers(n, 7) / 1000
        Next

        If design = 0 Then ' only in analysis mode
            mes = -mes
            ey = fy / Ess
            If mes > ey And mpy = 0 Then
                'Dim curv1 As Double
                'Dim curv2 As Double
                'Dim m1 As Double
                'Dim m2 As Double
                'Dim mes2 As Double
                'Dim mes1 As Double
                'mes2 = mes
                'mes1 = MCR(nsection, pt - 1, 5)
                'curv1 = MCR(nsection, pt - 1, 1)
                'm1 = MCR(nsection, pt - 1, 2)
                'curv2 = curv * 1000
                'm2 = moment
                'fipy = curv1 + (curv2 - curv1) / (mes2 - mes1) * (ey - mes1)
                'mpy = m1 + (m2 - m1) / (mes2 - mes1) * (ey - mes1)
                'inertia = mpy / fipy / (Ec * 1000)

                mpy = moment : fipy = curv * 1000
                inertia = mpy / fipy / (Ec * 1000)
            End If

            'nominal moment
            If Mn = 0 And (mec > ecser) Then
                Mn = moment
                'fiy = Mn / mpy * fipy
                If mpy > 0 Then fiy = Mn / mpy * fipy
            End If

            'comienza nuevo
            If section = "circular" And s > 0 Then shearstrengthcircular()
            If section = "rectangular" And s > 0 Then shearstrengthrectangular()
            'termina nuevo

            'results are moment, curv, NAD, stresses and strain that are storaged in vectors
            MCR(nsection, pt, 1) = curv * 1000
            MCR(nsection, pt, 2) = moment
            MCR(nsection, pt, 3) = NAD
            MCR(nsection, pt, 4) = mec
            MCR(nsection, pt, 5) = mes
            MCR(nsection, pt, 6) = Mv
        End If


    End Sub

    Sub MCdesign()
        Dim itermc As Double
        Dim i As Single
        Dim CCC As Double
        Dim e As Double
        Dim stress As Double
        Dim force As Double
        Dim eps As Double
        Dim c As Double
        Dim t As Double
        Dim finc As Double
        Dim fint As Double
        Dim ff1 As Double
        Dim fff As Double

        itermc = 0
        CCC = 0.1
        mes = 0
        mec = 0

        Do
            itermc = itermc + 1
            NAD = rt - yna
            curv = ecMC / NAD ' in 1/mm
            For n As Integer = 1 To nfiber
                'computing strain
                e = curv * (fibers(n, 2) - yna)  ' positive strains are compresion
                If fibers(n, 4) = 3 And e < mes Then mes = e
                If e > mec Then
                    mec = e
                End If

                If fibers(n, 2) > (yna + 0.15 * NAD) And fibers(n, 4) < 3 Then 'only analyzes concrete fibers in compresion zone
                    'checking if fiber is in "a" section
                    stress = 0.85 * fpc
                    force = stress * fibers(n, 3)
                    fibers(n, 5) = e
                    fibers(n, 6) = stress
                    fibers(n, 7) = force
                Else
                    fibers(n, 6) = 0
                    fibers(n, 7) = 0
                End If

                If fibers(n, 4) = 3 Then 'interpolate strees from steel model
                    i = 0
                    If Math.Abs(e) < esu * 0.99 And Math.Abs(e) > 0 Then
                        Do
                            i = i + 1
                            eps = es(i)
                            If eps > Math.Abs(e) Then Exit Do
                        Loop
                        stress = (fs(i) - fs(i - 1)) / (es(i) - es(i - 1)) * (Math.Abs(e) - es(i - 1)) + fs(i - 1)
                    Else
                        stress = 0
                    End If
                    force = stress * fibers(n, 3)
                    fibers(n, 5) = e
                    fibers(n, 6) = stress
                    fibers(n, 7) = force
                End If


            Next

            'check equilibrium

            'computing compresion and tension forces
            c = 0
            t = 0
            finc = 0
            fint = 0
            For n As Integer = 1 To nfiber
                If fibers(n, 5) > 0 Then
                    c = c + fibers(n, 7)
                    finc = finc + 1
                Else
                    t = t + fibers(n, 7)
                    fint = fint + 1
                End If
            Next
            t = t + P

            If itermc > 1 Then ff1 = fff
            If c > t Then NAD = NAD - CCC * NAD : fff = -1 Else NAD = NAD + CCC * NAD : fff = 1
            If ff1 <> fff And itermc > 1 Then CCC = CCC / 2
            If (Math.Abs(c - t) / c) < 0.0001 Then Exit Do
            If itermc = 100 Then Exit Do
            yna = rt - NAD
        Loop

        moment = 0
        For n As Integer = 1 To nfiber
            moment = moment + Math.Abs(fibers(n, 2)) / 1000 * fibers(n, 7) / 1000
        Next

    End Sub

    Sub shearstrengthcircular()

        Dim av As Double
        Dim Avs As Double
        Dim dcore As Double
        Dim hoopratio As Double
        Dim rho As Double
        Dim Vs As Double
        Dim beta As Double
        Dim alpha As Double
        Dim curduct As Double
        Dim gama As Double
        Dim Vc As Double
        Dim Vp As Double
        Dim Vcap As Double

        'shear strength
        If NAD > 0.4 * 2 * rt Then NAD = 0.4 * 2 * rt
        av = dbl ^ 2 * pi / 4
        Avs = Dh ^ 2 * pi / 4
        dcore = (2 * rmr + Dh)
        hoopratio = 4 * Avs / (dcore * s)
        rho = av * nbl / ((rt ^ 2) * pi)
        Vs = (0.5 * pi * Avs * (fyh / 1000) / Math.Tan(pi / 6) * (2 * rt - NAD) / (s))
        beta = 0.5 + 20 * rho : If beta > 1 Then beta = 1
        alpha = 1.5 - ((Hs * 1000 / (2 * rt)) - 1.5) * (1.5 - 1) / (2 - 1.5)
        If alpha < 1 Then alpha = 1
        If alpha > 1.5 Then alpha = 1.5
        If fiy = 0 Then
            curduct = 1
        Else
            curduct = (curv * 1000) / fiy
        End If
        If ductilitymode = "uniaxial" Then gama = 0.29 - (curduct - 4) * (0.29 - 0.05) / (15 - 4)
        If ductilitymode = "biaxial" Then gama = 0.29 - (curduct - 1) * (0.29 - 0.05) / (13 - 4)
        If gama < 0.05 Then gama = 0.05
        If gama > 0.29 Then gama = 0.29
        Vc = (alpha * beta * gama) * (fpc ^ 0.5) * (0.8 * (pi * ((rt / 1000) ^ 2 - (ro / 1000) ^ 2))) * 1000
        Vp = 0.85 * (P / 1000) * (2 * rt - NAD) / 2 / (Hs * 1000)
        Vcap = (Vc + Vs + Vp)
        If pt = 2 Then maxVcap = Vcap
        If Vcap > maxVcap Then Vcap = maxVcap
        Mv = Vcap * Hs ' moment capacity based on shear strength
    End Sub

    Sub shearstrengthrectangular()
        Dim rtt As Single
        Dim nlr As Single
        Dim Avs As Double
        Dim hoopratio As Double
        Dim rho As Double
        Dim Vs As Double
        Dim beta As Double
        Dim alpha As Double
        Dim curduct As Double
        Dim gama As Double
        Dim Vc As Double
        Dim Vp As Double
        Dim Vcap As Double
        'shear strength

        Avs = Math.Abs(Avsy * Math.Cos(rot * pi / 180) + Avsx * Math.Sin(rot * pi / 180))
        hoopratio = (Avsy * (sh - 2 * cover) + Avsx * (sb - 2 * coverp)) / ((areacon + areaunc) * s)
        rho = fsr
        rtt = maxy * 2
        If NAD > 0.4 * rtt Then NAD = 0.4 * rtt
        nlr = (rtt - NAD) / Math.Tan(pi / 6) / s
        Vs = Avs * fyh * nlr / 1000
        beta = 0.5 + 20 * rho : If beta > 1 Then beta = 1
        alpha = 1.5 - ((Hs * 1000 / (rtt)) - 1.5) * (1.5 - 1) / (2 - 1.5)
        If alpha < 1 Then alpha = 1
        If alpha > 1.5 Then alpha = 1.5
        If fiy = 0 Then
            curduct = 1
        Else
            curduct = (curv * 1000) / fiy
        End If
        If ductilitymode = "uniaxial" Then gama = 0.29 - (curduct - 4) * (0.29 - 0.05) / (15 - 4)
        If ductilitymode = "biaxial" Then gama = 0.29 - (curduct - 1) * (0.29 - 0.05) / (13 - 4)
        If gama < 0.05 Then gama = 0.05
        If gama > 0.29 Then gama = 0.29
        Vc = (alpha * beta * gama) * (fpc ^ 0.5) * (areacon) / 1000
        Vp = 0.85 * (P / 1000) * (rtt - NAD) / 2 / (Hs * 1000)
        Vcap = (Vc + Vs + Vp)

        If pt = 2 Then maxVcap = Vcap
        If Vcap > maxVcap Then Vcap = maxVcap
        Mv = Vcap * Hs ' moment capacity based on shear strength
    End Sub


    Sub manderun()
        Dim Esecu As Single
        Dim ru As Single
        Dim n As Integer
        Dim xu As Single
        '% unconfined concrete:
        Esecu = fpc / eco
        ru = Ec / (Ec - Esecu)
        n = 0

        ReDim ecun(Int(espall / dels + 1))
        ReDim fcun(Int(espall / dels + 1))
        For eccv As Single = 0 To espall Step dels
            n = n + 1
            ecun(n) = eccv
            xu = eccv / eco
            If ecun(n) < 2 * eco Then fcun(n) = fpc * xu * ru / (ru - 1 + xu ^ ru)
            If ecun(n) >= 2 * eco And ecun(n) <= espall Then
                fcun(n) = fpc * (2 * ru / (ru - 1 + 2 ^ ru)) * (1 - (eccv - 2 * eco) / (espall - 2 * eco))
            End If
            If ecun(n) > espall Then fcun(n) = 0
        Next
    End Sub



    Sub manderconf()
        Dim rocc As Single
        Dim rox As Single
        Dim roy As Single
        Dim ke As Single
        Dim fpl As Single
        Dim Asts As Single
        Dim sp As Single
        Dim Ash As Single
        Dim ds As Single
        Dim ac As Single
        Dim Esec As Single
        Dim n As Single
        Dim x As Single


        'confined concrete:
        If section = "rectangular" Then
            ' comienza nuevo
            rocc = areast / areacon
            fsr = areast / (areacon + areaunc)
            If Avsx = 0 Or Avsy = 0 Or s = 0 Then
                fpl = 0
            Else
                rox = Avsx / (s * sh)
                roy = Avsy / (s * sb)
                ros = rox + roy
                ke = ((1 - wi ^ 2 / (6 * areacon)) * (1 - s / (2 * sb)) * (1 - s / (2 * sh))) / (1 - rocc)
                ro = 0.5 * ros
                fpl = ke * ro * fy
            End If
            'termina nuevo
        End If
        If Left(section, 8) = "circular" Then
            ' comienza nuevo
            ds = 2 * rmr + Dh ' confined core diameter
            Ast = dbl ^ 2 * pi / 4 * nbl  'main ring
            Asts = dbls ^ 2 * pi / 4 * nbls 'secondary ring
            ac = 0.25 * pi * (ds ^ 2) 'confined area
            rocc = (Ast + Asts) / ac
            fsr = (Ast + Asts) / ((rt ^ 2 - ro ^ 2) * pi)
            If Dh = 0 Or s = 0 Then
                fpl = 0
            Else
                sp = s - Dh  'free distance between hoops, Dh is diameter of transverse reinforcement
                Ash = 0.25 * pi * (Dh ^ 2) 'area of shear reinforcement
                ds = 2 * rmr + Dh ' confined core diameter
                ros = 4 * Ash / (ds * s) 'shear reinforcement ratio
                If stype = "spirals" Then ke = (1 - sp / (2 * ds)) / (1 - rocc)
                If stype = "hoops" Then ke = ((1 - sp / (2 * ds)) / (1 - rocc)) ^ 2
                fpl = 0.5 * ke * ros * fy
            End If
            'termina nuevo

        End If


        fpcc = (-1.254 + 2.254 * (1 + 7.94 * fpl / fpc) ^ 0.5 - 2 * fpl / fpc) * fpc
        ecc = eco * (1 + 5 * (fpcc / fpc - 1))
        Esec = fpcc / ecc
        r = Ec / (Ec - Esec)
        ecu = 1.5 * (0.004 + 1.4 * ros * fy * esm / fpcc) 'revisar esto

        ReDim eccon(Int(ecu / dels + 1))
        ReDim fccon(Int(ecu / dels + 1))

        n = 0

        For eccv As Single = 0 To ecu Step dels
            n = n + 1
            eccon(n) = eccv
            x = (1 / ecc) * eccv
            fccon(n) = fpcc * x * r / (r - 1 + x ^ r)
        Next

    End Sub


    Sub steelking()
        Dim m As Single
        Dim n As Single
        Dim ey As Single

        r = esu - esh
        m = ((fsu / fy) * ((30 * r + 1) ^ 2) - 60 * r - 1) / (15 * (r ^ 2))
        n = 0
        ey = fy / Ess
        ReDim es(Int(esu / dels + 1))
        ReDim fs(Int(esu / dels + 1))
        For esv As Single = 0 To esu Step dels
            n = n + 1
            es(n) = esv
            If esv < ey Then fs(n) = Ess * esv
            If esv >= ey And esv <= esh Then fs(n) = fy
            If esv > esh Then fs(n) = ((m * (esv - esh) + 2) / (60 * (esv - esh) + 2) + (esv - esh) * (60 - m) / (2 * ((30 * r + 1) ^ 2))) * fy
        Next
    End Sub

    Sub design_beam()

        Dim Vu As Single
        Dim phic As Single
        Dim mesn As Single
        Dim NADn As Single
        Dim mesp As Single
        Dim NADp As Single
        Dim spac As Double
        Dim av As Double
        Dim Vs As Double
        Dim Vc As Double
        Dim minrho As Double
        Dim errm As Double
        Dim strain As Double
        Dim phif As Double
        Dim errm1 As Double
        Dim iStep As Double
        Dim Shear As Double

        'diseno por corte de acuerdo a ACI
        Mu = Mp : If Mneg > Mu Then Mu = Mneg
        ' resistencia requerida
        Vu = (Mu / Hs * 1.25) + Shear  'I am using 1.25 overstrength factor
        ' strength reduction facto for shear design 9.3.3.2
        phic = 0.75
        ' concrete contribution to shear strength ACI 318 11.3.1.1
        Vc = (0.17 * fpc ^ 0.5) * (sb / 1000 * (sh - cover) / 1000) * 1000
        If 0.5 * Vu > Vc Then Vc = 0

        Vs = Vu / phic - Vc
        av = Vs / (fyh) * (s / (sh - cover)) * 1000 'mm^2
        Dh = (av / nslegs * 4 / pi) ^ 0.5
        Dh = checkdbl(Dh)
        Avsy = nslegs * Dh ^ 2 * pi / 4    ' area of steel resisting shear in Y direction
        Avsx = nslegs * Dh ^ 2 * pi / 4    ' area of steel resisting shear in X direction
        ' flexural design
        design = 1
        msy = 50 'size of mesh in y direction
        msx = 1 'size of mesh in x direction
        P = 0
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * 1.35         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        ' confined core
        CC(1, 1) = -sb / 2 + coverp          ' x1 confined core 1
        CC(1, 2) = -sh / 2 + cover              ' y1 confined core 1
        CC(1, 3) = sb / 2 - coverp               ' x2 confined core 1
        CC(1, 4) = sh / 2 - coverp               ' y2 confined core 1
        ' bottom reinforcement
        RL(1, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 1
        RL(1, 2) = -sh / 2 + cover              ' y1 reinforcing layer 1
        RL(1, 3) = sb / 2 - coverp             ' x2 reinforcing layer 1
        RL(1, 4) = -sh / 2 + cover              ' y2 reinforcing layer 1
        RL(1, 5) = nbsteel                      ' #bars reinforcing layer 1
        minrho = 0.005
        dblb = ((minrho * sb * sh / nbsteel) * 4 / pi) ^ 0.5
        dblb = checkdbl(dblb)
        RL(1, 6) = dblb              ' dia. bars reinforcing layer 1
        ' top reinforcement
        RL(2, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 2
        RL(2, 2) = sh / 2 - coverp              ' y1 reinforcing layer 2
        RL(2, 3) = sb / 2 - coverp              ' x2 reinforcing layer 2
        RL(2, 4) = sh / 2 - coverp              ' y2 reinforcing layer 2
        RL(2, 5) = ntsteel                      ' #bars reinforcing layer 2
        minrho = 0.005
        dblt = ((minrho * sb * sh / ntsteel) * 4 / pi) ^ 0.5
        dblt = checkdbl(dblt)
        RL(2, 6) = dblt              ' dia. bars reinforcing layer 2

        ' lateral left reinforcement
        If nlsteel > 0 Then
            spac = (sh - cover - coverp) / (nlsteel / 2 + 1)
            RL(3, 1) = -sb / 2 + cover               ' x1 reinforcing layer 3
            RL(3, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 3
            RL(3, 3) = -sb / 2 + cover             ' x2 reinforcing layer 3
            RL(3, 4) = sh / 2 - coverp - spac              ' y2 reinforcing layer 3
            RL(3, 5) = ntsteel / 2                    ' #bars reinforcing layer 3
            If dbll = 0 Then
                minrho = 0.005
                dbll = ((minrho * sb * sh / nlsteel) * 4 / pi) ^ 0.5
                dbll = checkdbl(dbll)
            End If
            RL(3, 6) = dbll              ' dia. bars reinforcing layer 3
            RL(4, 1) = sb / 2 - cover               ' x1 reinforcing layer 4
            RL(4, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 4
            RL(4, 3) = sb / 2 - cover             ' x2 reinforcing layer 4
            RL(4, 4) = sh / 2 - coverp - spac             ' y2 reinforcing layer 4
            RL(4, 5) = ntsteel / 2                    ' #bars reinforcing layer 4
            RL(4, 6) = dbll              ' dia. bars reinforcing layer 4
        End If

        section = "rectangular"
        iStep = 1

        'first design for least moment and then for greater moment
        For iter As Integer = 1 To 2
            If Mp <= Mneg Then
                errm = 1
                For q As Integer = 1 To 10
                    rot = 180
                    sectionrectangular1()
                    rt = maxy
                    yna = maxy * 0.7
                    ecMC = 0.003
                    MCdesign()
                    'computing phif
                    strain = -mes
                    If strain < 0.002 Then phif = 0.65
                    If strain > 0.005 Then phif = 0.9
                    If strain > 0.002 And strain < 0.005 Then phif = 0.65 + 0.25 * (strain - 0.002) / 0.003
                    ' the error
                    errm1 = Math.Abs(((phif * moment) - Mneg) / Mneg)
                    If (phif * moment) < Mneg Then
                        RL(2, 6) = RL(2, 6) + iStep
                    Else
                        RL(2, 6) = RL(2, 6) - iStep
                    End If
                    If errm1 > errm Then Exit For
                    errm = errm1
                Next
                dblt = RL(2, 6)
                mesn = mes
                NADn = NAD

                For q As Integer = 1 To 10
                    rot = 0
                    errm = 1
                    sectionrectangular1()
                    rt = maxy
                    yna = maxy * 0.7
                    ecMC = 0.003
                    pt = 1
                    MCdesign()
                    'computing phif
                    strain = -mes
                    If strain < 0.002 Then phif = 0.65
                    If strain > 0.005 Then phif = 0.9
                    If strain > 0.002 And strain < 0.005 Then phif = 0.65 + 0.25 * (strain - 0.002) / 0.003
                    ' the error
                    errm1 = Math.Abs(((phif * moment) - Mp) / Mp)
                    If (phif * moment) < Mp Then
                        RL(1, 6) = RL(1, 6) + iStep
                    Else
                        RL(1, 6) = RL(1, 6) - iStep
                    End If
                    If errm1 > errm Then Exit For
                    errm = errm1
                Next
                dblb = RL(1, 6)
                mesp = mes
                NADp = NAD

            Else
            End If
        Next

        dblt = checkdbl(dblt)
        dblb = checkdbl(dblb)

        'flexural design results as dblb, dblt,dbll

        'MC ojojojo

        shr = 1.35          ' steel hardening ratio
        nlegsx = 2             ' # of stirrup legs resisting shear in x direction
        nlegsy = nslegs            ' # of stirrup legs resisting shear in y direction
        ductilitymode = "uniaxial"     ' ductility mode
        rot = 0
        nsection = 1
        MC_beam()

        shr = 1.35          ' steel hardening ratio
        nlegsx = 2             ' # of stirrup legs resisting shear in x direction
        nlegsy = nslegs            ' # of stirrup legs resisting shear in y direction
        ductilitymode = "uniaxial"     ' ductility mode
        rot = 180
        nsection = 2
        MC_beam()

        'design results
        ReDim designresult(30)
        designresult(1) = phif ' phi flexion
        designresult(2) = phic ' phi corte
        designresult(3) = Vu ' ultimate shear based on moment overstrength
        designresult(4) = Vc ' concrete contribution to shear resistance
        designresult(5) = Vs ' reinforcement contribution to shear resistance
        designresult(6) = Dh ' diameter of stirrup bar
        designresult(7) = ecser 'concrete design strain
        designresult(8) = -mesp ' maximum tensile strain with positive moment
        designresult(9) = NADp  'neutral axis depth with positive moment
        designresult(10) = -mesn ' maximum tensile strain with neg moment
        designresult(11) = NADn  'neutral axis depth with neg moment
        designresult(12) = dblb ' diameter bottom bars
        designresult(13) = dblt ' diameter top bars
        designresult(14) = dbll ' diameter lateral bars

    End Sub


    Sub design_reccol()
        Dim Mpxx As Single
        Dim Mpyy As Single
        Dim Vuy As Single
        Dim Vux As Single
        Dim phic As Single
        Dim Vcx As Single
        Dim Vcy As Single
        Dim Vsy As Single
        Dim Avy As Single
        Dim Dhy As Single
        Dim Vsx As Single
        Dim Avx As Single
        Dim Dhx As Single
        Dim spac As Double
        Dim Vc As Double
        Dim minrho As Double
        Dim errm As Double
        Dim strain As Double
        Dim phif As Double
        Dim iStep As Double
       
        'diseno por corte de acuerdo a ACI
        Mpxx = Mp * Math.Cos(rot * pi / 180)
        Mpyy = Mp * Math.Sin(rot * pi / 180)
        Vuy = (Mpxx / Hs * 1.25) 'I am using 1.25 overstrength factor
        Vux = (Mpyy / Hs * 1.25) 'I am using 1.25 overstrength factor
        phic = 0.75
        ' concrete contribution to shear strength ACI 318 11.3.1.1
        Vcx = (0.17 * fpc ^ 0.5) * ((sb - coverp) / 1000 * (sh) / 1000) * 1000
        Vcy = (0.17 * fpc ^ 0.5) * ((sb) / 1000 * (sh - cover) / 1000) * 1000
        If 0.5 * Vux > Vcx Then Vcx = 0
        If 0.5 * Vuy > Vcy Then Vcy = 0

        Vsy = Vuy / phic - Vc
        Avy = Vsy / (fyh * 1000) * s / (sh - cover) * 1000000
        Dhy = (Avy / nlegsy * 4 / pi) ^ 0.5
        Vsx = Vuy / phic - Vc
        Avx = Vsy / (fyh * 1000) * s / (sb - coverp) * 1000000
        Dhx = (Avy / nlegsx * 4 / pi) ^ 0.5
        Dh = Dhx : If Dhy > Dh Then Dh = Dhy
        Dh = checkdbl(Dh)
        Avsy = nlegsy * Dh ^ 2 * pi / 4    ' area of steel resisting shear in Y direction
        Avsx = nlegsx * Dh ^ 2 * pi / 4    ' area of steel resisting shear in X direction

        'flexural design
        design = 1
        msy = 50 'size of mesh in y direction
        msx = 50 'size of mesh in x direction
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * 1.35         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        ' confined core
        CC(1, 1) = -sb / 2 + coverp          ' x1 confined core 1
        CC(1, 2) = -sh / 2 + cover              ' y1 confined core 1
        CC(1, 3) = sb / 2 - coverp               ' x2 confined core 1
        CC(1, 4) = sh / 2 - cover               ' y2 confined core 1
        ' bottom reinforcement
        minrho = 0.01
        dbl = ((minrho * sb * sh / (ntsteel + nlsteel)) * 4 / pi) ^ 0.5
        dbl = checkdbl(dbl)
        RL(1, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 1
        RL(1, 2) = -sh / 2 + cover              ' y1 reinforcing layer 1
        RL(1, 3) = sb / 2 - coverp              ' x2 reinforcing layer 1
        RL(1, 4) = -sh / 2 + cover              ' y2 reinforcing layer 1
        RL(1, 5) = ntsteel / 2                    ' #bars reinforcing layer 1
        RL(1, 6) = dbl              ' dia. bars reinforcing layer 1
        ' top reinforcement
        RL(2, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 2
        RL(2, 2) = sh / 2 - cover             ' y1 reinforcing layer 2
        RL(2, 3) = sb / 2 - coverp              ' x2 reinforcing layer 2
        RL(2, 4) = sh / 2 - cover              ' y2 reinforcing layer 2
        RL(2, 5) = ntsteel / 2                    ' #bars reinforcing layer 2
        RL(2, 6) = dbl                  ' dia. bars reinforcing layer 2

        ' lateral left reinforcement
        If nlsteel > 0 Then
            spac = (sh - 2 * cover) / (nlsteel / 2 + 1)
            RL(3, 1) = -sb / 2 + coverp               ' x1 reinforcing layer 3
            RL(3, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 3
            RL(3, 3) = -sb / 2 + coverp             ' x2 reinforcing layer 3
            RL(3, 4) = sh / 2 - cover - spac              ' y2 reinforcing layer 3
            RL(3, 5) = nlsteel / 2                    ' #bars reinforcing layer 3
            RL(3, 6) = dbl              ' dia. bars reinforcing layer 3
            RL(4, 1) = sb / 2 - coverp               ' x1 reinforcing layer 4
            RL(4, 2) = -sh / 2 + cover + spac            ' y1 reinforcing layer 4
            RL(4, 3) = sb / 2 - coverp             ' x2 reinforcing layer 4
            RL(4, 4) = sh / 2 - cover - spac             ' y2 reinforcing layer 4
            RL(4, 5) = nlsteel / 2                    ' #bars reinforcing layer 4
            RL(4, 6) = dbl              ' dia. bars reinforcing layer 4
        End If

        section = "rectangular"

        errm = 1
        Do
            sectionrectangular1()
            rt = maxy
            yna = maxy * 0.7
            ecMC = 0.003
            pt = 1
            MCdesign()
            'computing phif
            strain = -mes
            If strain < 0.002 Then phif = 0.65
            If strain > 0.005 Then phif = 0.9
            If strain > 0.002 And strain < 0.005 Then phif = 0.65 + 0.25 * (strain - 0.002) / 0.003
            ' the error
            iStep = 1
            If (phif * moment) < Mp Then
                RL(1, 6) = RL(1, 6) + iStep
                RL(2, 6) = RL(2, 6) + iStep
                RL(3, 6) = RL(3, 6) + iStep
                RL(4, 6) = RL(4, 6) + iStep
            End If
            If (phif * moment) > Mp Then Exit Do
        Loop
        dbl = RL(1, 6)
        dbl = checkdbl(dbl)

        'flexural design results as dbl

        'need for MC
        shr = 1.35          ' steel hardening ratio
        dblt = dbl             ' diameter bars of top and bottom steel
        dbll = dbl             ' diameter bars of lateral steel
        If rot = 0 Or rot = 90 Or rot = 270 Or rot = 180 Then ductilitymode = "uniaxial" Else ductilitymode = "biaxial"
        nsection = 1
        MC_reccol()

        'design results
        ReDim designresult(30)
        designresult(1) = phif ' phi flexion
        designresult(2) = phic ' phi corte
        designresult(3) = Vux ' ultimate shear based on moment overstrength in x direction
        designresult(4) = Vuy ' ultimate shear based on moment overstrength in y direction
        designresult(5) = Vcx ' Concrete contribution  in x direction
        designresult(6) = Vcy ' Concrete contribution  in y direction
        designresult(7) = Vsx ' Required Steel contribution  in x direction
        designresult(8) = Vsy ' Required Steel contribution  in y direction
        designresult(9) = Dh ' diameter of stirrup bar
        designresult(10) = ecser 'concrete design strain
        designresult(11) = strain ' maximum tensile strain
        designresult(12) = NAD  'neutral axis depth
        designresult(13) = dblt ' requiered diameter of longitudinal reinforcement
        designresult(14) = pratio ' Axialloadratio

    End Sub


    Sub design_circol()
        Dim Vu As Single
        Dim phic As Single
        Dim rebard As Single
        Dim av As Double
        Dim Vs As Double
        Dim Vc As Double
        Dim minrho As Double
        Dim errm As Double
        Dim strain As Double
        Dim phif As Double
        Dim errm1 As Double
        Dim iStep As Double
       
        'diseno por corte de acuerdo a ACI
        Vu = Mu / Hs * 1.25 'I am using 1.25 overstrength factor
        phic = 0.75
        Vc = 0
        Vs = Vu / phic - Vc
        av = Vs * s / (fyh) / (0.8 * 2 * rt) * 10
        Dh = (av / 2 * 4 / pi) ^ 0.5
        Dh = checkdbl(Dh)

        'flexural design
        design = 1
        ms = 50 'size of mesh
        Ess = 200000        ' steel modulus of elasticity (MPa)
        Ec = 4700 * (fpc) ^ 0.5        ' concrete modulus of elasticity (MPa) check ACI
        fsu = fy * 1.35         ' steel max stress (MPa)*
        esh = 0.008         ' steel strain for strain hardening (usually 0.008)*
        esu = 0.12          ' long. steel maximum strain (usually 0.12-0.15)*
        eco = 0.002        ' unconfined strain (usually 0.002 for normal weight or 0.004 for lightweight)*
        esm = 0.12         ' max transv. steel strain (usually 0.12-0.15)*
        espall = 0.0064     ' max uncon. conc. strain (usually 0.0064)
        ecser = 0.003       ' concrete strain at nominal moment
        section = "circular"
        ' min long reinforcement
        minrho = 0.01
        dbl = (minrho * (2 * rt) ^ 2 / nbl) ^ 0.5
        dbl = checkdbl(dbl)
        errm = 1
        sectioncircular1()
        yna = rt * 0.7
        ecMC = 0.003
        Do
            pt = 1
            MCdesign()
            'computing phif
            strain = -mes
            If strain < 0.002 Then phif = 0.65
            If strain > 0.005 Then phif = 0.9
            If strain > 0.002 And strain < 0.005 Then phif = 0.65 + 0.25 * (strain - 0.002) / 0.003
            ' the error
            errm1 = Math.Abs(((phif * moment) - Mu) / Mu)
            If (phif * moment) > Mu Then Exit Do
            iStep = 1
            If (phif * moment) < Mu Then dbl = dbl + iStep
            sectioncircular1()
        Loop
        dbl = checkdbl(dbl)
        rebard = dbl
        'flexural design result is dbl

        'necesito para MC analysis
        fpc = 1.3 * fpc         'expected concrete compressive strength (MPa)
        fy = 1.1 * fy        ' expected long steel yielding stress (MPa)
        shr = 1.35            'steel hardening ratio
        stype = "hoops"     ' type of transverse reinforcement
        ductilitymode = "biaxial"
        nsection = 1
        MC_circol()

        'design results
        ReDim designresult(30)
        designresult(1) = phif ' phi flexion
        designresult(2) = phic ' phi corte
        designresult(3) = Vu ' ultimate shear based on moment overstrength
        designresult(4) = Vc ' concrete contribution to shear resistance
        designresult(5) = Vs ' reinforcement contribution to shear resistance
        designresult(6) = Dh ' diameter of stirrup bar
        designresult(7) = ecser 'concrete design strain
        designresult(8) = strain ' maximum tensile strain
        designresult(9) = NAD  'neutral axis depth
        designresult(10) = rebard ' requiered diameter of longitudinal reinforcement
        designresult(11) = pratio ' axial load ratio
        designresult(12) = fsr ' long reinforcement ratio
        designresult(13) = ros ' transverse reinforcement ratio


    End Sub



    Function checkdbl(ByVal bard)
        If bard < 10 Then checkdbl = 10 : Exit Function
        If bard < 12 Then checkdbl = 12 : Exit Function
        If bard < 14 Then checkdbl = 14 : Exit Function
        If bard < 16 Then checkdbl = 16 : Exit Function
        If bard < 18 Then checkdbl = 18 : Exit Function
        If bard < 20 Then checkdbl = 20 : Exit Function
        If bard < 22 Then checkdbl = 22 : Exit Function
        If bard < 24 Then checkdbl = 24 : Exit Function
        If bard < 26 Then checkdbl = 26 : Exit Function
        If bard < 28 Then checkdbl = 28 : Exit Function
        If bard < 30 Then checkdbl = 30 : Exit Function
        If bard < 32 Then checkdbl = 32 : Exit Function
        If bard < 36 Then checkdbl = 36 : Exit Function
        If bard < 40 Then checkdbl = 40 : Exit Function
        checkdbl = bard
    End Function




End Class
