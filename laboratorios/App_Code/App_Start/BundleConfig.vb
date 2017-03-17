Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Optimization




Namespace VirtualLabIS.Common.Global.Clases
    Public Class BundleConfig
        Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
            'BackEnd
            '2GDL1.aspx 
            bundles.Add(New ScriptBundle("~/Content/assets/js/2GDL1").Include("~/Scripts/Experimentos/2GDL1.js"))

            'BackEnd
            bundles.Add(New ScriptBundle("~/Content/assets/js").Include("~/Scripts/jquery/jquery-{version}.js", "~/Scripts/bootstrap/bootstrap.min.js",
                                                                        "~/Scripts/jquery/jquery-ui-1.11.4.min.js",
                                                                        "~/Scripts/jquery/jquery.validate.min.js",
                                                                        "~/Scripts/jquery/jquery.validate.unobtrusive.min.js",
                                                                        "~/Scripts/jquery/jquery.unobtrusive-ajax.min.js",
                                                                        "~/Content/assets/plugins/pace/pace.min.js",
                                                                        "~/Content/assets/plugins/jquery-totemticker/jquery.totemticker.js",
                                                                        "~/Content/assets/plugins/jquery-resize/jquery.ba-resize.js",
                                                                        "~/Content/assets/plugins/jquery-blockui/jquery.blockUI.js",
                                                                        "~/Content/assets/plugins/icheck/icheck.min.js",
                                                                        "~/Content/assets/plugins/switchery/switchery.min.js",
                                                                        "~/Content/assets/plugins/jquery-niftymodal/js/classie.js",
                                                                        "~/Content/assets/plugins/jquery-niftymodal/js/modalEffects.js",
                                                                        "~/Content/assets/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                                                                        "~/Content/assets/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js",
                                                                        "~/Content/assets/plugins/select2/select2.js",
                                                                        "~/Content/assets/plugins/bootstrap-slider/js/bootstrap-slider.js",
                                                                        "~/Content/assets/js/form.js",
                                                                        "~/Content/assets/js/main.js",
                                                                        "~/Scripts/prettify/prettify.js"))


            'BackEnd
            bundles.Add(New StyleBundle("~/Content/assets/css").Include("~/Content/bootstrap/bootstrap.min.css",
                                                                        "~/Content/font-awesome.css",
                                                                        "~/Content/assets/plugins/pace/pace-theme-minimal.css",
                                                                        "~/Content/assets/plugins/icheck/skins/square/blue.css",
                                                                        "~/Content/assets/plugins/switchery/switchery.min.css",
                                                                        "~/Content/assets/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css",
                                                                        "~/Content/assets/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css",
                                                                        "~/Content/assets/plugins/select2/select2.css",
                                                                        "~/Content/assets/plugins/select2/select2-bootstrap.css",
                                                                        "~/Content/assets/plugins/bootstrap-slider/css/slider.css",
                                                                        "~/Content/assets/plugins/jquery-niftymodal/css/component.css",
                                                                        "~/Content/assets/plugins/jquery-datatables/css/dataTables.bootstrap.css",
                                                                        "~/Content/assets/plugins/jquery-jvectormap/jquery-jvectormap.css",
                                                                        "~/Content/prettify/prettify.css",
                                                                        "~/Content/animate.css",
                                                                        "~/Content/themes/base/all.css",
                                                                        "~/Content/backend.css",
                                                                        "~/Content/assets/css/main.css",
                                                                        "~/Content/assets/css/skins.css"))
        End Sub
    End Class

End Namespace
