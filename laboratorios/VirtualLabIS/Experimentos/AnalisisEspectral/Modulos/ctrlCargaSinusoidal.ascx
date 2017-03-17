<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlCargaSinusoidal.ascx.vb" Inherits="Modulos_ctrlCargaSinusoidal" %>
<table class="TablaDatos-Graficas" width="95%">
    <tr>
        <td colspan="3" class="PanelHeader" align="left">
            <asp:Label ID="lblFuncionCargaLineal" runat="server" Style="position: static" CssClass="Funcionalidad-subtitulo">FUNCION DE CARGA SINUSOIDAL</asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="" rowspan="1" style="width: 355px" valign="top">
            <table style="position: static" width="355">
                <tr>
                    <td style="width: 37px">
            <asp:TextBox ID="tbCargaMaxima" runat="server" AutoCompleteType="Disabled" Style="position: static"
                Width="48px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px">
            <asp:Label ID="lblCargaMaxima" runat="server" Style="position: static" Text="CARGA MAXIMA (kN)"
                Width="160px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCargaMaxima"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 37px">
            <asp:TextBox ID="tbFrecuencia" runat="server" AutoCompleteType="Disabled" Style="position: static"
                Width="48px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px">
            <asp:Label ID="lblFrecuencia" runat="server" Style="position: static" Text="FRECUENCIA DE EXITACIÓN (rad/s)"
                Width="256px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFrecuencia"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 37px">
            <asp:TextBox ID="tbDuracExitacion" runat="server" AutoCompleteType="Disabled" Style="position: static"
                Width="48px" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:Label ID="lblDuracExitacion" runat="server" Style="position: static" Text="DURACIÓN DE LA EXITACIÓN"
                Width="256px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDuracExitacion"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
        </td>
        <td align="right">
            <asp:Image ID="img2" runat="server" Height="248px" ImageUrl="~/VirtualLab/Varios/Archivos/Imagenes/Dinamica/EN/2_EN.jpg"
                Style="position: static" Width="424px" /></td>
    </tr>
</table>
