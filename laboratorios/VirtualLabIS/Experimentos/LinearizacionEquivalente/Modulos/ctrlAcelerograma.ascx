<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrlAcelerograma.ascx.vb" Inherits="Modulos_ctrlAcelerograma" %>
<div class="col-md-7">
    <div class="form-horizontal" role="form">
        <%--Value 1--%>
        <div id="tevalue0">
            <div class="form-group">
                <div class="col-sm-3">
                    <asp:TextBox ID="tbDuracion" runat="server" class="form-control"></asp:TextBox>
                </div>
                <asp:Label ID="lblDuracion" runat="server" class="control-label small" Text="MAX LOAD -Fmax- (kN)"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDuracion" ErrorMessage="*"
                    Style="position: static" Width="14px"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <div class="col-sm-3">
                    <asp:TextBox ID="tbPaso" runat="server" class="form-control"></asp:TextBox>
                </div>
                <asp:Label ID="lblPaso" runat="server" class="control-label small" Text="FREQUENCY -Ω- (rad/s)"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPaso" ErrorMessage="*"
                    Style="position: static"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <div class="col-sm-3">
                    <asp:TextBox ID="tbFactor" runat="server" class="form-control"></asp:TextBox>
                </div>
                <asp:Label ID="lblFactor" runat="server" class="control-label small" Text="DURATION (s)"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbFactor" ErrorMessage="*"
                    Style="position: static"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <div class="col-sm-8">
                    <asp:FileUpload ID="fuAcelerograma" runat="server" class="btn btn-warning" />
                </div>
                <div class="col-sm-4">
                    <asp:LinkButton ID="btnAcelerograma" runat="server" class="btn btn-warning" Style="height: 33px;">
                        <i class="fa fa-cloud-upload"></i>
                        Upload
                    </asp:LinkButton>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-9">
                    <asp:Label ID="lblMessagesUploadFileSismoX" runat="server" ForeColor="Red" Style="position: static"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNoteAcelerograma" runat="server" class="col-sm-12 text-justify small"
                    Text="The file must be a single column of values. The number of lines in the file must be equal to or greater than duration / time step +1"></asp:Label>
            </div>
            <div class="form-group">
                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                <asp:TextBox ID="tbSismo1" runat="server" Height="56px" Style="position: static" TextMode="MultiLine" Visible="False" Width="53%" Wrap="False"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div class="col-md-5">
    <div style="width: 100%; height: 220px;">
        <div class="image">
            <asp:Image ID="img2" runat="server" ImageUrl="~/VirtualLabIS/Varios/Archivos/Imagenes/Dinamica/EN/2_EN.jpg" />
        </div>
    </div>
</div>

<asp:HiddenField ID="hfArchivosSismo1" runat="server" Value="0" />

