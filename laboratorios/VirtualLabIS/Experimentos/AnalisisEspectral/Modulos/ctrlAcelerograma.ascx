<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlAcelerograma.ascx.vb" Inherits="Modulos_ctrlAcelerograma" %>
&nbsp;<table style="position: static" class="TablaDatos-Graficas" width="95%">
    <tr>
        <td style="height: 90%; border-top-width: 1px; width: 90%; border-top-color: activecaption;" align="left" colspan="2" class="PanelHeader">
            <asp:Label ID="lblAcelerograma" runat="server" Style="position: static" Text="ACELEROGRAMA" CssClass="Funcionalidad-subtitulo"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" style="width: 500px; border-left-color: activeborder; border-bottom-color: activeborder; border-top-color: activeborder; text-align: center; border-right-color: activeborder;" valign="top">
            <table style="border-top-width: 1px; width: 90%; border-top-color: activecaption; height: 90%;" width="400">
                <tr>
                    <td style="width: 59px" align="left">
            <asp:TextBox ID="tbDuracion" runat="server" Style="position: static" Width="64px" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px" align="left">
                        <asp:Label ID="lblDuracion" runat="server" Style="position: static" Text="DURACIÓN (s)" Width="104px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDuracion" ErrorMessage="*"
                Style="position: static" Width="14px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 59px" align="left">
            <asp:TextBox ID="tbPaso" runat="server" Style="position: static" Width="64px" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px" align="left">
                        <asp:Label ID="lblPaso" runat="server" Style="position: static" Text="PASO (s)" Width="106px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPaso" ErrorMessage="*"
                Style="position: static"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 59px" align="left">
            <asp:TextBox ID="tbFactor" runat="server" Style="position: static" Width="64px" AutoCompleteType="Disabled" CssClass="Funcionalidad-textbox-habilitado"></asp:TextBox></td>
                    <td style="width: 100px" align="left">
                        <asp:Label ID="lblFactor" runat="server" Style="position: static" Text="FACTOR PARA OBTENER m/s^2" Width="232px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbFactor" ErrorMessage="*"
                Style="position: static"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                    <asp:FileUpload ID="fuAcelerograma" runat="server" Style="position: static" BackColor="White" BorderStyle="Groove" /><asp:Button ID="btnAcelerograma" runat="server" OnClick="btnSismoSentidoX_Click" Style="position: static"
                        Text="Cargar Archivo" BackColor="#E0E0E0" BorderStyle="Groove" /><br />
                        <asp:Label ID="lblMessagesUploadFileSismoX" runat="server" ForeColor="Red" Style="position: static"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:Label ID="lblNoteAcelerograma" runat="server" Font-Size="X-Small" Width="363px"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td align="right" style="width: 42%">
            <asp:Image ID="img2" runat="server" Height="248px" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/EN/2_EN.jpg"
                Style="position: static" Width="424px" /></td>
    </tr>
    <tr>
        <td align="right" rowspan="2" style="width: 42%">
            <br />
        </td>
        <td align="left" rowspan="2" style="width: 42%">
        </td>
    </tr>
    <tr>
    </tr>
</table>
<asp:HiddenField ID="hfArchivosSismo1" runat="server" Value="0" />
<asp:TextBox ID="tbSismo1" runat="server" Height="56px" Style="position: static"
    TextMode="MultiLine" Visible="False" Width="53%" Wrap="False"></asp:TextBox>&nbsp;
