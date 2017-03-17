
Partial Class VirtualLabIS_Experimentos_LABORATORIOS_H_SIMULATION_MC_Analysis_PageMain_wfMC_Analysis_Links
    Inherits System.Web.UI.Page

    Protected Sub rbtMcDesignBeam_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignBeam.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../MCAVIGA/wfmcaviga.aspx';</script>")
    End Sub

    Protected Sub rbtMcDesignCircular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignCircular.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../McCOLUMNACIRC/wfColumnaCircular.aspx';</script>")
    End Sub

    Protected Sub rbtMcDesignRectangular_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMcDesignRectangular.CheckedChanged
        Me.RegisterStartupScript("1", "<script language='javascript'>parent.frames['Experimento'].location.href='../McColumnaRec/wfmColRec.aspx';</script>")
    End Sub
End Class
