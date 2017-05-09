<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlAcelerograma.ascx.vb" Inherits="Modulos_ctrlAcelerograma" %>

<div class="col-sm-7">
    <asp:Label ID="lblAcelerograma" runat="server" Style="position: static" Text="ACELEROGRAMA" CssClass="Funcionalidad-subtitulo"></asp:Label>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbDuracion" runat="server" class="form-control" AutoCompleteType="Disabled" Style="padding-right: 0px;"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblDuracion" runat="server" class="control-label small" Text="DURACIÓN (s)"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDuracion" ErrorMessage="*"
                Style="position: static" Width="14px"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbPaso" runat="server" class="form-control" Style="padding-right: 0px;"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblPaso" runat="server" class="control-label small" Text="PASO (s)"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPaso" ErrorMessage="*"
                Style="position: static"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbFactor" runat="server" class="form-control" Style="padding-right: 0px;"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblFactor" runat="server" class="control-label small" Text="FACTOR PARA OBTENER m/s^2"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbFactor" ErrorMessage="*"
                Style="position: static"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-8">
            <asp:FileUpload ID="fuAcelerograma" runat="server" class="btn btn-warning" />
        </div>
        <div class="col-sm-4">
            <asp:LinkButton ID="btnAcelerograma" runat="server" class="btn btn-warning" OnClick="btnSismoSentidoX_Click" Height="33px">
                <i class="fa fa-cloud-upload"></i>
                Upload
            </asp:LinkButton>
        </div>
    </div>
    <div>
        <asp:Label ID="lblMessagesUploadFileSismoX" runat="server" class="col-sm-12" Font-Bold="True" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <asp:Label ID="lblNoteAcelerograma" runat="server" class="col-sm-12" Font-Bold="True" ForeColor="Red"></asp:Label>
    </div>
</div>
<div class="col-sm-5">
    <div style="width: 305px; height: 191px;">
        <asp:Image ID="img2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/EN/2_EN.jpg" Style="position: static" Width="100%" Height="100%" />
    </div>
</div>
<asp:HiddenField ID="hfArchivosSismo1" runat="server" Value="0" />
<asp:TextBox ID="tbSismo1" runat="server" Height="56px" Style="position: static"
    TextMode="MultiLine" Visible="False" Width="53%" Wrap="False"></asp:TextBox>&nbsp;
