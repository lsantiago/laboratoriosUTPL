<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="VirtualLabIS.VLEE.VirtualLabIS_Varios_ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página de ERROR</title>
    <link href="../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <table style="width: 70%; height: 50%">
                <tr>
                    <td>
                        <div style="text-align: center">
                            <table class="Tabla-Principales" style="width: 90%; height: 90%">
                                <tr>
                                    <td style="height: 58px;" class="Funcionalidad-subtitulo">
                                        PAGE OF ERROR</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <div style="text-align: center">
                                            <table class="TablaDatosEntrada" style="width: 80%; height: 90%">
                                                <tr>
                                                    <td>
                                        <asp:Label ID="lblMensajeError" runat="server" Width="448px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMensajeErrorDetalle" runat="server" Width="384px"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; text-align: center">
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
