<%@ Page Language="VB" AutoEventWireup="false" CodeFile="wfMC-Design-Links.aspx.vb" Inherits="VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_PageMain_wfMC_Design_Links" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <table style="width: 25%; height: 10%">
                <tr>
                    <td style="text-align: left;">
                        <asp:RadioButton ID="rbtMcDesignBeam" runat="server" CssClass="Funcionalidad-Link"
                            Text="MC-DESIGN BEAM" AutoPostBack="True" GroupName="linksMc-Design" Width="112px" /></td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <asp:RadioButton ID="rbtMcDesignCircular" runat="server" Text="MC-DESIGN CIRCULAR" AutoPostBack="True" CssClass="Funcionalidad-Link" GroupName="linksMc-Design" Width="132px" /></td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <asp:RadioButton ID="rbtMcDesignRectangular" runat="server" Text="MC-DESIGN RECTANGULAR" AutoPostBack="True" CssClass="Funcionalidad-Link" GroupName="linksMc-Design" Width="154px" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
