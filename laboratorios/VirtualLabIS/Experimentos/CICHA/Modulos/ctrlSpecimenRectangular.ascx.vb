Imports VirtualLabIS.DTO

Namespace VirtualLabIS.VLEE

    Partial Class VirtualLabIS_Experimentos_CICHA_Modulos_ctrlSpecimenCircular
        Inherits System.Web.UI.UserControl

        Private objFacade As Facade.VirtualLabIS.Facade.Cicha.ICicha

        ''' <summary>
        ''' Agrega eventos a los TextBox, estos codificados en JavaScript del lado del Cliente
        ''' para forzar al usuario a que ingrese solo valores numericos estos TextBox
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subEstablecerAtributosAControles()
            'Propiedades de la Sección
            Me.txtAnchoSeccion.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtProfundidaSeccion.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtLongitudPila.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtDiametroRefLong.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumBarLong.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtRecubrimientoZ.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumBarZ.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtRecubrimientoY.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumBarY.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtIndiceRefLong.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtDiametroRefTrans.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumBarTrans.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtEspamientoTrans.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtIndiceRefTrans.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtNumBarCortante.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtCargaAxial.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            'Propiedades de los Materiales de Construcción
            Me.txtResistCompConcret.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtEsfFluencLong.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtEsfUltimoLong.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
            Me.txtEsfFluencTrans.Attributes.Add("onKeyDown", "return PermitirSoloNumeros(event);")
        End Sub

        ''' <summary>
        ''' Cuando se hace clip en el "cmdNuevo" para la creacion de un nuevo especimen
        ''' se prenderan los controles TXTBOX o otros controles para el ingreso de valores
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subHabilitarControles()
            Me.lblTipoSpec.Visible = False
            Me.txtTipoSpec.Visible = False
            'Información general de la sección
            Me.txtNombreSpec.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtReferenciaSpec.CssClass = "Funcionalidad-textbox-habilitado"
            'Propiedades de la Seccion.
            Me.txtAnchoSeccion.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtProfundidaSeccion.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtLongitudPila.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtDiametroRefLong.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtNumBarLong.CssClass = "Funcionalidad-textbox-habilitado"
            'Sentido perpendicular a la Carga Lateral Z.
            Me.txtRecubrimientoZ.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtNumBarZ.CssClass = "Funcionalidad-textbox-habilitado"
            'Sentido paralelo a la Carga Lateral Y.
            Me.txtRecubrimientoY.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtNumBarY.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtIndiceRefLong.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtDiametroRefTrans.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtNumBarTrans.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtEspamientoTrans.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtIndiceRefTrans.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtNumBarCortante.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtCargaAxial.CssClass = "Funcionalidad-textbox-habilitado"
            'Propiedades de los materiales.
            Me.txtResistCompConcret.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtEsfFluencLong.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtEsfUltimoLong.CssClass = "Funcionalidad-textbox-habilitado"
            Me.txtEsfFluencTrans.CssClass = "Funcionalidad-textbox-habilitado"
        End Sub

        ''' <summary>
        ''' Al agregar este control solamente para visualizar los resultados, los controles
        ''' TXTBOX y otros, se apagaran porque no se ingresaran valores es éstos.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subDesHabilitarControles()
            Me.lblTipoSpec.Visible = True
            Me.txtTipoSpec.Visible = True
            'Información general de la sección
            Me.txtNombreSpec.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtReferenciaSpec.CssClass = "Funcionalidad-textbox-noHabilitado"
            'Propiedades de la Seccion.
            Me.txtAnchoSeccion.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtProfundidaSeccion.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtLongitudPila.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtDiametroRefLong.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtNumBarLong.CssClass = "Funcionalidad-textbox-noHabilitado"
            'Sentido perpendicular a la Carga Lateral Z.
            Me.txtRecubrimientoZ.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtNumBarZ.CssClass = "Funcionalidad-textbox-noHabilitado"
            'Sentido paralelo a la Carga Lateral Y.
            Me.txtRecubrimientoY.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtNumBarY.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtIndiceRefLong.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtDiametroRefTrans.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtNumBarTrans.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtEspamientoTrans.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtIndiceRefTrans.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtNumBarCortante.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtCargaAxial.CssClass = "Funcionalidad-textbox-noHabilitado"
            'Propiedades de los materiales.
            Me.txtResistCompConcret.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtEsfFluencLong.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtEsfUltimoLong.CssClass = "Funcionalidad-textbox-noHabilitado"
            Me.txtEsfFluencTrans.CssClass = "Funcionalidad-textbox-noHabilitado"
        End Sub

        ''' <summary>
        ''' Enlace desde la pagina hacia este control de User, con el fin de inicialidar las
        ''' propiedades de los controles para edicion o solo para lectura.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property setHabilitarCtrl() As Boolean
            Get
                Return True
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    subHabilitarControles()
                Else
                    subDesHabilitarControles()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Se llena el DataTable "dtCICHA_ESPC_REC" con todos los valores del Specimen
        ''' ingresados en este Control de Usuario y se devuelven a la pagina principal
        ''' </summary>
        ''' <param name="dtCICHA_ESPC_REC"></param>
        ''' <param name="drCICHA_ESPC_REC"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fucAsignarValoresControles(ByVal dtCICHA_ESPC_REC As dsCicha.CICHA_ESPC_RECDataTable, ByRef drCICHA_ESPC_REC As dsCicha.CICHA_ESPC_RECRow) As dsCicha.CICHA_ESPC_RECDataTable
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NOMBREColumn) = Me.txtNombreSpec.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_REFERENCIAColumn) = Me.txtReferenciaSpec.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ANCHOSECCIONColumn) = Me.txtAnchoSeccion.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_PROFUNDIDADSECCIONColumn) = Me.txtProfundidaSeccion.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_LONGITUDPILAColumn) = Me.txtLongitudPila.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_DIAMETROREFLONGColumn) = Me.txtDiametroRefLong.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARLONGColumn) = Me.txtNumBarLong.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RECUBRIMIENTOZColumn) = Me.txtRecubrimientoZ.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARZColumn) = Me.txtNumBarZ.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RECUBRIMIENTOYColumn) = Me.txtRecubrimientoY.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARYColumn) = Me.txtNumBarY.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_INDICEREFLONGColumn) = Me.txtIndiceRefLong.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_DIAMETROREFTRANSColumn) = Me.txtDiametroRefTrans.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARTRANSColumn) = Me.txtNumBarTrans.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESPACIAMTRANSACEROColumn) = Me.txtEspamientoTrans.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_INDICEREFTRANSColumn) = Me.txtIndiceRefTrans.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARCORTANTEColumn) = Me.txtNumBarCortante.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_CARGAAXIALColumn) = Me.txtCargaAxial.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RESISTCOMPCONCRETOColumn) = Me.txtResistCompConcret.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOFLUENLONGColumn) = Me.txtEsfFluencLong.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOULTLONGColumn) = Me.txtEsfUltimoLong.Text
            drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOFLUENTRANSColumn) = Me.txtEsfFluencTrans.Text
            Return dtCICHA_ESPC_REC
        End Function

        ''' <summary>
        ''' Llena los controles a partir del DataTable y del DataRow los controles del especimen de
        ''' tipo circular.
        ''' </summary>
        ''' <param name="dtCICHA_ESPC_REC"></param>
        ''' <param name="drCICHA_ESPC_REC"></param>
        ''' <remarks></remarks>
        Public Sub subMostrarInfoSpecimenRectangular(ByVal dtCICHA_ESPC_REC As dsCicha.CICHA_ESPC_RECDataTable, ByVal drCICHA_ESPC_REC As dsCicha.CICHA_ESPC_RECRow)
            Me.txtNombreSpec.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NOMBREColumn)
            Me.txtTipoSpec.Text = "Rectangular"
            Me.txtReferenciaSpec.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_REFERENCIAColumn)
            Me.txtAnchoSeccion.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ANCHOSECCIONColumn)
            Me.txtProfundidaSeccion.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_PROFUNDIDADSECCIONColumn)
            Me.txtLongitudPila.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_LONGITUDPILAColumn)
            Me.txtDiametroRefLong.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_DIAMETROREFLONGColumn)
            Me.txtNumBarLong.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARLONGColumn)
            Me.txtRecubrimientoZ.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RECUBRIMIENTOZColumn)
            Me.txtNumBarZ.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARZColumn)
            Me.txtRecubrimientoY.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RECUBRIMIENTOYColumn)
            Me.txtNumBarY.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARYColumn)
            Me.txtIndiceRefLong.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_INDICEREFLONGColumn)
            Me.txtDiametroRefTrans.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_DIAMETROREFTRANSColumn)
            Me.txtNumBarTrans.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARTRANSColumn)
            Me.txtEspamientoTrans.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESPACIAMTRANSACEROColumn)
            Me.txtIndiceRefTrans.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_INDICEREFTRANSColumn)
            Me.txtNumBarCortante.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_NUMBARCORTANTEColumn)
            Me.txtCargaAxial.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_CARGAAXIALColumn)
            Me.txtResistCompConcret.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_RESISTCOMPCONCRETOColumn)
            Me.txtEsfFluencLong.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOFLUENLONGColumn)
            Me.txtEsfUltimoLong.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOULTLONGColumn)
            Me.txtEsfFluencTrans.Text = drCICHA_ESPC_REC(dtCICHA_ESPC_REC.CICHA_ESPC_REC_ESFUERZOFLUENTRANSColumn)
        End Sub

        ''' <summary>
        ''' Cuando se ingresa el Nombre del Specimen, se verificara si éste ya existe en la 
        ''' DB, si ese es el caso, se presentara un mensaje que indica que el Nombre de Specimen
        ''' ya esta almacenado en la DB y que se ingrese otro. El Nombre del Specimen sera unico
        ''' aunque no lo sea asi en la DB (no esta ingresado como un constraing)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub subVerificarExitenciaNombreSpec()
            Dim booIndicador As Boolean
            Me.lblMensajeExisteNombreSpec.Text = Nothing
            objFacade = New Facade.VirtualLabIS.Facade.Cicha.Cicha
            booIndicador = objFacade.subCicha_ObtenerNombreSpecRec(Me.txtNombreSpec.Text)
            If booIndicador Then
                Me.txtNombreSpec.Focus()
                Me.lblMensajeExisteNombreSpec.Text = "Name the Specimen exist"
            End If
        End Sub

        ''' <summary>
        ''' Procedimiento para establecer el idioma a los controles
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub subSetIdiomaControles()
            'Informacion General del Especimen
            Me.lblSpecimenInf.Text = GetLocalResourceObject("lblSpecimenInf.Text").ToString()
            Me.lblInfGeneral.Text = GetLocalResourceObject("lblInfGeneral.Text").ToString()
            Me.lblNombreSpec.Text = GetLocalResourceObject("lblNombreSpec.Text").ToString()
            Me.lblTipoSpec.Text = GetLocalResourceObject("lblTipoSpec.Text").ToString()
            Me.lblReferenciaSpec.Text = GetLocalResourceObject("lblReferenciaSpec.Text").ToString()
            'Propiedades de la Seccion
            Me.lblPropiedadSeccion.Text = GetLocalResourceObject("lblPropiedadSeccion.Text").ToString()
            Me.lblAnchoSeccion.Text = GetLocalResourceObject("lblAnchoSeccion.Text").ToString()
            Me.lblProfundidadSeccion.Text = GetLocalResourceObject("lblProfundidadSeccion.Text").ToString()
            Me.lblLongitudPila.Text = GetLocalResourceObject("lblLongitudPila.Text").ToString()
            Me.lblDiametroRefLong.Text = GetLocalResourceObject("lblDiametroRefLong.Text").ToString()
            Me.lblNumBarLong.Text = GetLocalResourceObject("lblNumBarLong.Text").ToString()
            Me.lblCargaPerpenZ.Text = GetLocalResourceObject("lblCargaPerpenZ.Text").ToString()
            Me.lblRecubrimientoZ.Text = GetLocalResourceObject("lblRecubrimientoZ.Text").ToString()
            Me.lblNumBarZ.Text = GetLocalResourceObject("lblNumBarZ.Text").ToString()
            Me.lblCargaParalY.Text = GetLocalResourceObject("lblCargaParalY.Text").ToString()
            Me.lblRecubrimientoY.Text = GetLocalResourceObject("lblRecubrimientoY.Text").ToString()
            Me.lblNumBarY.Text = GetLocalResourceObject("lblNumBarY.Text").ToString()
            Me.lblIndiceRefLong.Text = GetLocalResourceObject("lblIndiceRefLong.Text").ToString()
            Me.lblDiametroRefTrans.Text = GetLocalResourceObject("lblDiametroRefTrans.Text").ToString()
            Me.lblNumBarTrans.Text = GetLocalResourceObject("lblNumBarLong.Text").ToString()
            Me.lblEspamientoTrans.Text = GetLocalResourceObject("lblEspamientoTrans.Text").ToString()
            Me.lblIndiceRefTrans.Text = GetLocalResourceObject("lblIndiceRefTrans.Text").ToString()
            Me.lblNumBarCortante.Text = GetLocalResourceObject("lblNumBarCortante.Text").ToString()
            Me.lblCargaAxial.Text = GetLocalResourceObject("lblCargaAxial.Text").ToString()
            'Propiedades de los materiales
            Me.lblPropiedadMateriales.Text = GetLocalResourceObject("lblPropiedadMateriales.Text").ToString()
            Me.lblResistCompConcret.Text = GetLocalResourceObject("lblResistCompConcret.Text").ToString()
            Me.lblEsfFluencLong.Text = GetLocalResourceObject("lblEsfFluencLong.Text").ToString()
            Me.lblEsfUltimoLong.Text = GetLocalResourceObject("lblEsfUltimoLong.Text").ToString()
            Me.lblEsfFluencTrans.Text = GetLocalResourceObject("lblEsfFluencTrans.Text").ToString()
            'Imagenes
            Me.lblTituloEsq.Text = GetLocalResourceObject("lblTituloEsq.Text").ToString()
            Me.lblTituloExpReal.Text = GetLocalResourceObject("lblTituloExpReal.Text").ToString()
        End Sub


        ''' <summary>
        ''' Verifica cada vez que se carga la página para inicializar todos los controles
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            subEstablecerAtributosAControles()
            subSetIdiomaControles()
        End Sub

        ''' <summary>
        ''' Evento generado cuando el usuario cambia el texto del Control "txtNombreSpec"
        ''' para verificar si este nombre de espacimen ya esta almacenado en la DB
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub txtNombreSpec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombreSpec.TextChanged
            subVerificarExitenciaNombreSpec()
        End Sub
    End Class
End Namespace
