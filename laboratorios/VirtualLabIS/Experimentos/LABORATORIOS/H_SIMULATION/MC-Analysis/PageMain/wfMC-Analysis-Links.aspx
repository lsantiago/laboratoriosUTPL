<%@ Page Language="VB" AutoEventWireup="false" CodeFile="wfMC-Analysis-Links.aspx.vb" Inherits="VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Analysis_PageMain_wfMC_Analysis_Links" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="../../../../../Varios/Archivos/Styles/stlServicios.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 25%; height: 10%">
            <tr>
                <td style="text-align: left">
                    <asp:RadioButton ID="rbtMcDesignBeam" runat="server" AutoPostBack="True" CssClass="Funcionalidad-Link"
                        GroupName="linksMc-Design" Text="MC-ANALYSIS BEAM" Width="124px" /></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:RadioButton ID="rbtMcDesignCircular" runat="server" AutoPostBack="True" CssClass="Funcionalidad-Link"
                        GroupName="linksMc-Design" Text="MC-ANALYSIS CIRCULAR" Width="148px" /></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:RadioButton ID="rbtMcDesignRectangular" runat="server" AutoPostBack="True" CssClass="Funcionalidad-Link"
                        GroupName="linksMc-Design" Text="MC-ANALYSIS RECTANGULAR" Width="170px" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
