<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlCargaSinusoidal.ascx.vb" Inherits="Modulos_ctrlCargaSinusoidal" %>

<div class="col-sm-7">
    <asp:Label ID="lblFuncionCargaLineal" runat="server" Style="position: static" CssClass="Funcionalidad-subtitulo">FUNCION DE CARGA SINUSOIDAL</asp:Label>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbCargaMaxima" runat="server" class="form-control" Style="padding-right: 0px;"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblCargaMaxima" runat="server" class="control-label small" Text="CARGA MAXIMA (kN)"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCargaMaxima"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbFrecuencia" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblFrecuencia" runat="server" class="control-label small" Text="FRECUENCIA DE EXITACIÓN (rad/s)"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFrecuencia"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-3">
            <asp:TextBox ID="tbDuracExitacion" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-9 label-der">
            <asp:Label ID="lblDuracExitacion" runat="server" class="control-label small" Text="DURACIÓN DE LA EXITACIÓN"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDuracExitacion"
                ErrorMessage="*" Style="position: static"></asp:RequiredFieldValidator>
        </div>
    </div>
</div>
<div class="col-sm-5">
    <div style="width: 305px; height: 191px;">
        <div class="image">
            <asp:Image ID="img2" runat="server" ImageUrl="~/VirtualLab/Varios/Archivos/Imagenes/Dinamica/EN/2_EN.jpg" />
        </div>
    </div>
</div>

