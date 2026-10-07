
function KPISpecialAssignments(DetailViewURL, employeeDetails, buttonLabel)
{
    var _ = this;
    var i, isFinished = false;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function() {
        BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + employeeDetails.toUpperCase() + ' <small></small></b>',
			message: function(dialog) {
                var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
			 
				$content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()

                var dialogHeight = windowHeight * 0.80;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('padding', '0px');
                dialog.getModalBody().css('height', dialogHeight * 0.85);
                dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
                dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            },
			buttons:
            [{

            id: 'btn-Close',
				cssClass: 'btn btn-danger',
				label: "CLOSE",
				action: function(dialog) {

                    swal({
                    title: "Do you want to continue?",
				        text: "Data might have not been saved yet.",
				        icon: "info",
				        buttons: true,
				        dangerMode: true,
				    })
					.then((willDelete) => {
                         if (willDelete)
                         {
                             dialog.close();
                         }
                     });
				}

				},{
id: 'btn-Finish',
				cssClass: 'btn btn-info',
				label: buttonLabel,
				action: function(dialog) {

        RequiredFieldCheck();

        if (isReady == false)
        {
            Toast.Error("You are required to fill-in the Core Strengths, Core Areas for improvement and Action Plan.");
        }
        else
        {

            FieldCheck();

            switch (buttonLabel)
            {

                case "FINISH": // MANAGER
                    if (isReady == false)
                    {
                        swal({
                        title: "Confirmation..",
				                        text: "Some of the field(s) are empty, do still want to continue?",
				                        icon: "info",
				                        buttons: true,
				                        dangerMode: true,
				                    })
                                        .then((willDelete) => {
                                         if (willDelete)
                                         {
                                             var remarks = "";
                                                $.ajax({
                                             type: "POST",
				                                    cache: false,
													url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
				                                    success: function(data) {
                                                     if (data == 'True')
                                                     {
                                                         dialog.close();

                                                         var reportName;
				                                            $.ajax({
                                                         type: "POST",
				                                                cache: false,
																url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
				                                                success: function(data) {
                                                                 var jsonResult = JSON.parse(data);
                                                                 UpdatingPartThree();
                                                                 if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1)
                                                                 { // FOR MANAGER
                                                                     reportName = "PEManager";
                                                                     URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                                                                     var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                                                                     detailView.open();

                                                                 }
                                                                 else
                                                                 {
                                                                     reportName = "PerformanceEvaluation";
                                                                     URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                                                                     var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                                                                     detailView.open();

                                                                 }

				                                                    $('#tblList_EVALUATE').DataTable().ajax.reload();
                                                             }
                                                         })

                                                        }
            }
        }) 
                                         }
});    

                                } else
{
    var remarks = "";
                                     $.ajax({
    type: "POST",
                                        cache: false,
										 url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
                                        success: function(data) {
            if (data == 'True')
            {
                dialog.close();
                var reportName;
                                                $.ajax({
                type: "POST",
                                                    cache: false,
													url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
                                                    success: function(data) {
                        var jsonResult = JSON.parse(data);
                        UpdatingPartThree();

                        if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1)
                        { // FOR MANAGER
                            reportName = "PEManager";
                            URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                            var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                            detailView.open();

                        }
                        else
                        {
                            reportName = "PerformanceEvaluation";
                            URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                            var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                            detailView.open();

                        }

                                                        $('#tblList_EVALUATE').DataTable().ajax.reload();
                    }
                })
                                    
                                            }
        }
    });

}

break;


                            case "DONE": // HR MANAGER

    if (isReady == false)
    {

        swal({
        title: "Confirmation..",
	                                    text: "Some of the field(s) are empty, do still want to continue?",
	                                    icon: "info",
	                                    buttons: true,
	                                    dangerMode: true,
	                                })
                                    .then((willDelete) => {
                                     if (willDelete)
                                     {

                                         dialog.close();


                                         //$.ajax({
                                         //    type: "POST",
                                         //    cache: false,
                                         //    url: '../KPIView/EvaluationDoneTrigger?actionID=' + 2 + '&kpiAssignmentRefNo=' + kpiAssignmentID,
                                         //    success: function (data) {
                                         //        if (data == 'True') {
                                         dialog.close();

                                         var reportName;
	                                                    $.ajax({
                                         type: "POST",
	                                                        cache: false,
															url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
	                                                        success: function(data) {
                                                 var jsonResult = JSON.parse(data);
                                                 UpdatingPartThree();
                                                 if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1)
                                                 { // FOR MANAGER
                                                     reportName = "PEManager";
                                                     URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                                                     var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                                                     detailView.open();

                                                 }
                                                 else
                                                 {
                                                     reportName = "PerformanceEvaluation";
                                                     URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                                                     var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", "ENDORSE");
                                                     detailView.open();

                                                 }

	                                                            $('#tblList_EVALUATE').DataTable().ajax.reload();
                                             }
                                         })
                                            //        }
                                            //    }
                                            //}) 

                                       }
});


                            }  else
{
    dialog.close();

    //$.ajax({
    //    type: "POST",
    //    cache: false,
    //    url: '../KPIView/EvaluationDoneTrigger?actionID=' + 2 + '&kpiAssignmentRefNo=' + kpiAssignmentID,
    //    success: function (data) {
    //        if (data == 'True') {
    dialog.close();
    var reportName;
                                            $.ajax({
    type: "POST",
                                                cache: false,
												url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
                                                success: function(data) {
            var jsonResult = JSON.parse(data);
            UpdatingPartThree();
            if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1)
            { // FOR MANAGER
                reportName = "PEManager";
                URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                detailView.open();

            }
            else
            {
                reportName = "PerformanceEvaluation";
                URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
                var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", "ENDORSE");
                detailView.open();

            }

                                                    $('#tblList_EVALUATE').DataTable().ajax.reload();
        }
    })
                                //        }
                                //    }
                                //}) 
  
                            }

break;

default:
                                break;
                         }
               
                      }
				}
			}],
onhide: function(dialogRef) {

},
onshow: function(dialogref) {
	$(document).off('focusin.modal');
},
closeByBackdrop: false,
	closeByKeyboard: false
});
};

}