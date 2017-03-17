Imports DotNetNuke.Services.Localization

Partial Class VirtualLabIS_Experimentos_Columna_ctlLinksFig
    Inherits System.Web.UI.UserControl

    Private Sub subInicializarTextoIdiomaCtr()
        Me.lnkResultsAMC.Text = Localization.GetString("lnkResultsAMC.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkInputData.Text = Localization.GetString("lnkInputData.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkFig1.Text = Localization.GetString("lnkFig1.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkFig2.Text = Localization.GetString("lnkFig2.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkFig3.Text = Localization.GetString("lnkFig3.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkFig4.Text = Localization.GetString("lnkFig4.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        Me.lnkFig5.Text = Localization.GetString("lnkFig5.Text", Localization.GetResourceFile(Me, "ctlLinksFig.ascx"))
        


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        subInicializarTextoIdiomaCtr()
    End Sub
End Class
