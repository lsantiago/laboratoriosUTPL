
Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_DESIGN_MC_Design_PageMain_wfMC_Design_Links
    Inherits System.Web.UI.Page

    Protected Sub rbtMcDesignBeam_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignBeam.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../DesignBeam/wfmBeamRec.aspx';</script>")
    End Sub

    Protected Sub rbtMcDesignCircular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignCircular.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../DesignColumnCir/wfmCirCol.aspx';</script>")
    End Sub

    Protected Sub rbtMcDesignRectangular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignRectangular.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../DesignColumnRec/wfmRecCol.aspx';</script>")
    End Sub
End Class
