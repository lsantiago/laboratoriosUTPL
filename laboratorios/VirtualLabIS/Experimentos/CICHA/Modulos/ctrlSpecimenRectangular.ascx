<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlSpecimenRectangular.ascx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_CICHA_Modulos_ctrlSpecimenCircular" %>
<link href="../../../../VirtualLabIS/Varios/Archivos/Styles/stlServicios.css" rel="stylesheet"
    type="text/css" />
    
    <script language="javascript" src="../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
    
<div style="text-align: center">
    <table style="width: 90%" class="TablaDatos-Graficas">
        <tr>
            <td class="PanelHeader" colspan="1" style="width: 10px">
            </td>
            <td colspan="3" class="PanelHeader">
                <asp:Label ID="lblSpecimenInf" runat="server" Text="SPECIMEN" CssClass="Funcionalidad-titulo" Width="360px"></asp:Label></td>
        </tr>
        <tr>
            <td rowspan="6" style="width: 10px">
            </td>
            <td colspan="3">
                <div style="text-align: left">
                    <table style="height: 90%">
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblInfGeneral" runat="server" CssClass="Funcionalidad-subtitulo" Text="GENERAL INFORMATION"
                                    Width="200px" style="text-align: left"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombreSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="TEST PERFORMED BY:" Width="130px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtNombreSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                    Width="200px" AutoPostBack="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreSpec"
                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblMensajeExisteNombreSpec" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="SECTION TYPE:" Width="130px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtTipoSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                    Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblReferenciaSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="REFERENCE:" Width="130px"></asp:Label></td>
                            <td>
                <asp:TextBox ID="txtReferenciaSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado" Height="56px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReferenciaSpec"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="text-align: center">
                    &nbsp;</div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <table style="height: 90%">
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblPropiedadSeccion" runat="server" CssClass="Funcionalidad-subtitulo"
                                Text="SECTION PROPERTIES" Width="250px" style="text-align: left"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblAnchoSeccion" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="SECTION WIDTH b(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtAnchoSeccion" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtAnchoSeccion"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblProfundidadSeccion" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="SECTION HEIGHT h(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtProfundidaSeccion" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtProfundidaSeccion"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblLongitudPila" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="COLUMN LENGTH L(m):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtLongitudPila" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtLongitudPila"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblDiametroRefLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="LONGITUDINAL BAR DIAMETER dbl(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDiametroRefLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtDiametroRefLong"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblNumBarLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# LONGITUDINAL BAR (Unit):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtNumBarLong"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblCargaPerpenZ" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="PERPENDICULAR SENSE TO LATERAL LOAD (Z)" Width="300px" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="True"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblRecubrimientoZ" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="COVER rZ(mm): " Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRecubrimientoZ" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtRecubrimientoZ"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblNumBarZ" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# MIDDLE BAR Z(Unidades): " Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarZ" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtNumBarZ"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblCargaParalY" runat="server" CssClass="Funcionalidad-datos-entrada" Font-Italic="True"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="True" Text="PARALLEL SENSE TO LATERAL LOAD (Y)"
                                Width="300px"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblRecubrimientoY" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="COVER rY(mm): " Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRecubrimientoY" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtRecubrimientoY"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblNumBarY" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# MIDDLE BAR Y(Unidades):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarY" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtNumBarY"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblIndiceRefLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="LONGITUDINAL STEEL RATIO %:" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtIndiceRefLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtIndiceRefTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblDiametroRefTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="TRANSVERSE BAR DIAMETER dbt(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDiametroRefTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtDiametroRefTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblNumBarTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# TRANSVERSE BAR (Unit):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtNumBarTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblEspamientoTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="SPACING OF TRANSVERSE BAR et(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEspamientoTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtEspamientoTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblIndiceRefTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="TRANSVERSE STEEL RATIO %:" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtIndiceRefTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtIndiceRefTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblNumBarCortante" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# SHEAR BOUGH (Unit):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarCortante" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtNumBarCortante"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="lblCargaAxial" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="AXIAL LOAD P(KN):" Width="300px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtCargaAxial" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtCargaAxial"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td colspan="1" style="text-align: center" rowspan="2">
                <table style="width: 90%">
                    <tr>
                        <td style="text-align: center">
                <table style="width: 90%">
                    <tr>
                        <td style="text-align: center">
                            <asp:Image ID="imgEsquemaSeccion" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/CICHA_EsquemaRectangular.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="lblTituloEsq" runat="server" CssClass="Funcionalidad-subtitulo" Text="FIG 1. SECTION"
                                Width="160px"></asp:Label></td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <table style="width: 90%">
                    <tr>
                        <td style="text-align: center">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/EsquemaExperimentoCICHARectangular.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="lblTituloExpReal" runat="server" CssClass="Funcionalidad-subtitulo"
                                Text="SETUP REAL" Width="160px"></asp:Label></td>
                    </tr>
                </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; text-align: left">
                <table style="height: 90%">
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblPropiedadMateriales" runat="server" CssClass="Funcionalidad-subtitulo"
                                Text="MATERIAL PROPERTIES" Width="250px" style="text-align: left"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblResistCompConcret" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="CONCRETE STRENGHT f'c(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtResistCompConcret" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtResistCompConcret"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEsfFluencLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="YIELD STRESS OF LONGITUDINAL BAR fy(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfFluencLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtEsfFluencLong"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEsfUltimoLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="ULT TENSION STRENGTH  OF LONG BAR fu(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfUltimoLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtEsfUltimoLong"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEsfFluencTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="YIELD STRESS OF TRANSVERSE BAR fyh(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfFluencTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" CssClass="Funcionalidad-Mensajes-Links"
                                ErrorMessage="*" ControlToValidate="txtEsfFluencTrans"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px">
            </td>
            <td style="width: 100px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</div>
