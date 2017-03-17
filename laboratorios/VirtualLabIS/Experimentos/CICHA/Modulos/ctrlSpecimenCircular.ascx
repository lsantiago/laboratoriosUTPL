<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlSpecimenCircular.ascx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Experimentos_CICHA_Modulos_ctrlSpecimenCircular" %>
<link href="../../../../VirtualLabIS/Varios/Archivos/Styles/stlServicios.css" rel="stylesheet"
    type="text/css" />
    <script language="javascript" src="../../../Varios/Archivos/Scripts/scActualizacionControles.js" type="text/javascript"></script>
    <script language="javascript" src="../../../Varios/Archivos/Scripts/Validacion.js" type="text/javascript"></script>
   
<div style="text-align: center">
    <div style="text-align: center">
        <table class="TablaDatos-Graficas" style="width: 128px">
            <tr>
                <td class="PanelHeader" colspan="1" style="width: 10px">
                </td>
                <td colspan="3" class="PanelHeader">
                <asp:Label ID="lblSpecimenInf" runat="server" Text="SPECIMEN" CssClass="Funcionalidad-titulo" Width="360px"></asp:Label></td>
            </tr>
            <tr>
                <td rowspan="6" style="width: 10px; text-align: left">
                </td>
                <td colspan="3" style="text-align: left">
                    <table style="height: 90%">
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblInfGeneral" runat="server" CssClass="Funcionalidad-subtitulo" Text="GENERAL INFORMATION"
                                    Width="200px" style="text-align: left"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblNombreSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="TEST PERFORMED BY:" Width="130px"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtNombreSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                    Width="200px" AutoPostBack="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreSpec"
                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblMensajeExisteNombreSpec" runat="server" CssClass="Funcionalidad-Mensajes-Links"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblTipoSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="SECTION TYPE:" Width="130px"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTipoSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                    Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblReferenciaSpec" runat="server" CssClass="Funcionalidad-datos-entrada"
                                    Text="REFERENCE:" Width="130px"></asp:Label></td>
                            <td style="text-align: left">
                <asp:TextBox ID="txtReferenciaSpec" runat="server" CssClass="Funcionalidad-textbox-noHabilitado" Height="56px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReferenciaSpec"
                                    CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 50%; text-align: left" colspan="2">
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
                        <td>
                            <asp:Label ID="lblDiametroSeccion" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="SECTION DIAMETER D(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDiametroSeccion" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDiametroSeccion"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLongitudColumna" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="COLUMN LENGTH L(m):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtLongitudColumna" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLongitudColumna"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDiametroRefLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="LONGITUD BAR DIAMETER dbl (mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDiametroRefLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDiametroRefLong"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNumBarLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="# LONGITUDINAL BAR (Unit):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumBarLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNumBarLong"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIndiceRefLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="LONGITUDINAL STEEL RATIO %:" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtIndiceRefLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtIndiceRefLong"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDiametroRefTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="TRANSVERSE BAR DIAMETER dbt(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDiametroRefTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDiametroRefTrans"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEspamientoTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="SPACING OF TRANSVERSE BAR et(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEspamientoTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEspamientoTrans"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIndiceRefTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="TRANSVERSE STEEL RATIO %:" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtIndiceRefTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtIndiceRefTrans"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRecubrimientoEstrib" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="COVER TO CENTER OF HOOP BAR r(mm):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRecubrimientoEstrib" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRecubrimientoEstrib"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCargaAxial" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="AXIAL LOAD P(KN):" Width="300px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCargaAxial" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCargaAxial"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                </td>
                <td style="width: 50%; text-align: center" rowspan="2">
                    <div style="text-align: center">
                        <div style="text-align: center">
                            <table>
                                <tr>
                                    <td style="text-align: center">
                                        <div style="text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="width: 100px; height: 215px;">
                            <asp:Image ID="imgEsquemaSeccion" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/EsquemaSeccion.jpg" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                            <asp:Label ID="lblTituloEsq" runat="server" CssClass="Funcionalidad-subtitulo" Text="FIG 1. SECTION"
                                Width="160px"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <div style="text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/CICHA/EsquemaExperimentoCICHA.jpg" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                            <asp:Label ID="lblTituloExpReal" runat="server" CssClass="Funcionalidad-subtitulo"
                                Text="FIG 2. SETUP REAL" Width="160px"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
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
                        <td style="text-align: left">
                            <asp:Label ID="lblResistCompConcret" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="CONCRETE STRENGHT f'c(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtResistCompConcret" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtResistCompConcret"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblEsfFluencLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="YIELD STRESS OF LONGITUDINAL BAR fy(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfFluencLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtEsfFluencLong"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblEsfUltimoLong" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="ULT TENSION STRENGTH  OF LONG BAR fu(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfUltimoLong" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtEsfUltimoLong"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblEsfFluencTrans" runat="server" CssClass="Funcionalidad-datos-entrada"
                                Text="YIELD STRESS OF TRANSVERSE BAR fyh(Mpa):" Width="330px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEsfFluencTrans" runat="server" CssClass="Funcionalidad-textbox-noHabilitado"
                                Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtEsfFluencTrans"
                                CssClass="Funcionalidad-Mensajes-Links" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                </td>
                <td style="text-align: left">
                </td>
                <td style="text-align: left">
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                </td>
                <td style="text-align: left">
                </td>
                <td style="text-align: left">
                </td>
            </tr>
        </table>
    </div>
</div>
