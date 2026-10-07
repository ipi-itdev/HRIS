using System.Web.Optimization;

namespace WCORE
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // main styles that needs to be loaded first or top of all
            bundles.Add(new StyleBundle("~/Styles/css").Include(
                        "~/Contents/plugins/jquery/jquery-ui.min.css", // v1.13.0-rc.2 - 2021-09-03
                        "~/Contents/plugins/bootstrap/bootstrap.min.css", // v4.4.1
                        //"~/Contents/plugins/font-awesome/css/fontawesome.css", 
                        "~/Contents/plugins/bootstrap/bootstrap-dialog.min.css", // used in message confirmation prompt
                        "~/Contents/plugins/bootstrap/font-awesome.min.css", // v 4.5.0 
                        "~/Contents/plugins/bootstrap/ionicons.min.css", // v2.0.0
                        "~/Contents/plugins/datatables/jquery.dataTables.min.css",
                        "~/Contents/plugins/sweetalert/sweetalert.min.css", // used in message prompt kpi
                        "~/Contents/plugins/toaster/toastr.css", // v4.4.1
                        "~/Contents/css/_all-skins.min.css",
                        "~/Contents/css/Style.css"
                        ));

            // main scripts that needs to be loaded first or top of all
            bundles.Add(new ScriptBundle("~/Script/js").Include(
                       "~/Contents/plugins/jquery/jquery.min.js", //  v3.3.1
                       "~/Contents/plugins/bootstrap/popper.min.js", // used for dropdown button
                       "~/Contents/plugins/bootstrap/bootstrap.min.js", // v3.3.7
                       "~/Contents/plugins/bootstrap/bootstrap-dialog.min.js",
                       "~/Contents/plugins/toaster/toastr.min.js",
                       "~/Contents/plugins/sweetalert/sweetalert.min.js", // used in message prompt kpi
                       "~/Contents/plugins/angular/angular.min.js", // AngularJS v1.8.2
                       "~/Contents/plugins/angular/angular-route.js", // AngularJS v1.8.2
                       "~/Contents/plugins/angular/angular-resource.js", // AngularJS v1.8.2
                       "~/Contents/plugins/bootstrap/ui-bootstrap-tpls.min.js", // 0.12.1
                       "~/Contents/plugins/system/lfrcontroller.js" // controller for lognin forgot and reset password
                       ));


            bundles.Add(new StyleBundle("~/Styles/main").Include(
                       "~/Contents/plugins/angular/tab.css", // used in chrome tab like features
                       "~/Contents/plugins/datatables/dataTables.bootstrap5.min.css", // used in list
                       "~/Contents/plugins/datatables/buttons.dataTables.min.css", // used in list
                       "~/Contents/plugins/select2/select2.min.css", // used in dropdown
                       "~/Contents/plugins/daterangepicker/daterangepicker.css", // used in dates
                       "~/Contents/plugins/waitme/waitMe.min.css", // used in loading
                       "~/Contents/plugins/morris/morris.css"
                       ));

            bundles.Add(new ScriptBundle("~/Script/plugins/main").Include(
                       "~/Contents/plugins/jquery/jquery-ui.min.js", // v1.12.1
                        "~/Contents/plugins/datatables/jquery.dataTables.js",
                       "~/Contents/plugins/datatables/jquery.dataTables.min.js",
                       "~/Contents/plugins/datatables/dataTables.bootstrap5.min.js",
                       "~/Contents/plugins/datatables/dataTables.responsive.min.js",
                       "~/Contents/plugins/datatables/dataTables.buttons.min.js",
                       "~/Contents/plugins/datatables/jszip.min.js",
                       "~/Contents/plugins/datatables/buttons.html5.min.js",
                       "~/Contents/plugins/slimScroll/jquery.slimscroll.min.js",
                       "~/Contents/plugins/daterangepicker/moment.min.js",
                       "~/Contents/plugins/bootstable/bootstable.js",
                       "~/Contents/plugins/waitme/waitMe.min.js",
                       "~/Contents/js/app.min.js" // IPI AdminLTE

            ));

            bundles.Add(new ScriptBundle("~/Script/dashboard").Include(
                       "~/Contents/plugins/chartjs/Chart.min.js",
                       "~/Contents/plugins/morris/raphael.min.js",
                       "~/Contents/plugins/morris/morris.min.js",
                       "~/Contents/plugins/flot/jquery.flot.min.js",
                       "~/Contents/plugins/flot/jquery.flot.resize.min.js",
                       "~/Contents/plugins/flot/jquery.flot.pie.min.js",
                       "~/Contents/plugins/flot/jquery.flot.categories.min.js"
                       ));


            bundles.Add(new StyleBundle("~/Styles/plugins/treegrid").Include(
                        "~/Contents/plugins/treegrid/jquery.treegrid.css"
                        ));

            bundles.Add(new ScriptBundle("~/Script/plugins/treegrid").Include(
                        "~/Contents/plugins/treegrid/jquery.treegrid.js",
                        "~/Contents/plugins/treegrid/jquery.treegrid.bootstrap3.js"
                        ));

            bundles.Add(new ScriptBundle("~/Script/plugins/list").Include(
                       "~/Contents/plugins/jquery/jquery.twbsPagination.js",
                       "~/Contents/plugins/system/formy.js",
                       "~/Contents/plugins/system/griddy.js",
                       "~/Contents/plugins/system/formyd.js",
                       "~/Contents/plugins/system/modie.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/plugins/forms").Include(
                      "~/Contents/plugins/daterangepicker/daterangepicker.js", // used in date
                      "~/Contents/plugins/select2/select2.full.min.js", // used in drop down
                      "~/Contents/plugins/input-mask/jquery.inputmask.js",
                      "~/Contents/plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Contents/plugins/system/controly.js",
                      "~/Contents/plugins/system/modiedd.js",
                      "~/Contents/plugins/system/modieremarks.js",
                      "~/Contents/plugins/system/modieviewer.js",
                       "~/Contents/js/Scripts/JIBGrid.js",
                      "~/Contents/js/Scripts/JIBForm.js",
                      "~/Contents/js/Scripts/JIBModal.js",
                       "~/Contents/js/Scripts/JIBControl.js",
                       "~/Contents/js/KPI/KPIList.js"
           ));

            bundles.Add(new ScriptBundle("~/Script/INVItemsDetails").Include(
                      "~/Contents/js/INV/INVItemsDetails.js"
           ));

            bundles.Add(new ScriptBundle("~/Script/INVAccountabilityDetails").Include(
                     "~/Contents/js/INV/INVAccountabilityDetails.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/INVExtAccountabilityDetails").Include(
                   "~/Contents/js/INV/INVExtAccountabilityDetails.js"
            ));

            //
            bundles.Add(new ScriptBundle("~/Script/INVEmpAccountabilityDetailsHist").Include(
                   "~/Contents/js/INV/INVEmpAccountabilityDetailsHist.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/EmployeeInfoAudit").Include(
                      "~/Contents/js/PIS/EmployeeInfoAudit.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/Employee").Include(
                      "~/Contents/js/PIS/Employee.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/Employment").Include(
                      "~/Contents/js/PIS/EmploymentInfo.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/ImportViewer").Include(
                      "~/Contents/js/PIS/ImportViewer.js"
            ));

            bundles.Add(new ScriptBundle("~/Script/KPICoreCompetencies").Include(
                    "~/Contents/js/KPI/KPICoreCompetencies.js"
          ));
            bundles.Add(new ScriptBundle("~/Script/ImportViewer").Include(
                    "~/Contents/js/PIS/ImportViewer.js"
          ));

            bundles.Add(new ScriptBundle("~/Script/KPICoreCompetenciesHR").Include(
                     "~/Contents/js/KPI/KPICoreCompetenciesHR.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPIItem").Include(
                     "~/Contents/js/KPI/KPIItem.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPIList").Include(
                     "~/Contents/js/KPI/KPIList.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPIPopup").Include(
                     "~/Contents/js/KPI/KPIPopup.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPIReportContainer").Include(
                    "~/Contents/js/KPI/KPIReportContainer.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPIScoring").Include(
                   "~/Contents/js/KPI/KPIScoring.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPISpecialAssignment").Include(
                   "~/Contents/js/KPI/KPISpecialAssignment.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPISummaryExternal").Include(
                  "~/Contents/js/KPI/KPISummaryExternal.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPISummaryExternalMRtoMM").Include(
                 "~/Contents/js/KPI/KPISummaryExternalMRtoMM.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPISummaryReport").Include(
                 "~/Contents/js/KPI/KPISummaryReport.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/KPISummaryReportGM").Include(
                 "~/Contents/js/KPI/KPISummaryReportGM.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/ManagersCore").Include(
                 "~/Contents/js/KPI/ManagersCore.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/ModalM").Include(
                 "~/Contents/js/KPI/ModalM.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/ModalS").Include(
                "~/Contents/js/KPI/ModalS.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/Summary").Include(
               "~/Contents/js/KPI/Summary.js"
           ));
            bundles.Add(new ScriptBundle("~/Script/AllKPIScripts").Include(
                     "~/Contents/js/KPI/Summary.js",
                     "~/Contents/js/KPI/KPICoreCompetenciesHR.js",
                     "~/Contents/js/KPI/KPIItem.js",
                     "~/Contents/js/KPI/KPIList.js",
                     "~/Contents/js/KPI/KPIPopup.js",
                    "~/Contents/js/KPI/KPIReportContainer.js",
                   "~/Contents/js/KPI/KPIScoring.js",
                   "~/Contents/js/KPI/KPISpecialAssignment.js",
                  "~/Contents/js/KPI/KPISummaryExternal.js",
                 "~/Contents/js/KPI/KPISummaryExternalMRtoMM.js",
                 "~/Contents/js/Scripts/App/KPISummaryReport.js",
                 "~/Contents/js/KPI/KPISummaryReportGM.js",
                 "~/Contents/js/KPI/ManagersCore.js",
                 "~/Contents/js/KPI/ModalM.js",
                "~/Contents/js/KPI/ModalS.js"
                      ));

            bundles.Add(new ScriptBundle("~/Script/plugins/formslist").Include(
                      "~/Contents/js/Scripts/JIBGrid.js",
                      "~/Contents/js/Scripts/JIBForm.js",
                      "~/Contents/js/Scripts/JIBModal.js",
                       "~/Contents/js/Scripts/JIBControl.js"
                      ));
        }
    }
}