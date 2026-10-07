
function KPIScoring(DetailViewURL, kpiinfo, buttonLabel)
{
    var _ = this;
    var isReady;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function() {
        BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + kpiinfo + ' <small></small></b>',
			message: function(dialog) {
                var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
			 
				$content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()

                var dialogHeight = windowHeight * 0.75;
                var dialogWidth = windowWidth * 0.9;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight + 70);
                dialog.getModalContent().css('width', 1200);
                dialog.getModalContent().css('left', -350);
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
                    dialog.close();
                }
            }, {
            id: 'btn-Print',
				cssClass: 'btn btn-info',
				label: "PRINT",
				action: function(dialog) {
                    var reportName;
				        $.ajax({
                    type: "POST",
				            cache: false,
							url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
				            success: function(data) {
                            var jsonResult = JSON.parse(data);
                            if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1)
                            {

                                reportName = "PEManager";
                                URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "PARTIAL" + '&reportName=' + reportName;
                            }
                            else
                            {

                                reportName = "KPIPartial";
                                URLVIEW = '../KPI/PartialKPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "PARTIAL" + '&reportName=' + reportName;
                            }
                            var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", " CLOSE ");
                            detailView.open();
                        }
                    })

					}},
				{
id: 'btn-Next',
				    cssClass: 'btn btn-success',
				    label: buttonLabel,
				    action: function(dialog) {

        if (buttonLabel == "DONE")
        {
            //$.ajax({
            //    type: "POST",
            //    cache: false,
            //    url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID,
            //    success: function (data) {
            //        if (data == 'True') {
            dialog.close();
            //            Toast.Show("KPI Score(s) updated.")
            //        }
            //    }
            //})
        }
        else
        {
				            $.ajax({
            type: "POST",
				                cache: false,
				                url: '../KPI/CheckScores?kpiid=' + kpiAssignmentID,
				                success: function(data) {
                    var jsonArray = JSON.parse(data);
                    isReady = jsonArray[0][0];

                    ////--- ACTIONS PER USER
                    if (parseInt(jsonArray[0][0]) == 0)
                    {
                        Toast.Error("Unable to proceed, there are still unscored KPI(s).", "info");
                    }
                    else if (parseInt(jsonArray[0][0]) == 1)
                    {

                        switch (buttonLabel)
                        {
                            case "NEXT": // MANAGER

                                swal({
                                title: "Do you want to continue?",
				                                    text: "You will be redirected to the next part.",
				                                    icon: "info",
				                                    buttons: true, 
				                                    dangerMode: true,
				                                })
                                              .then((willDelete) => {
                                               if (willDelete)
                                               {

                                                $.ajax({
                                                   type: "POST",
				                                cache: false,
													url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
				                                success: function(data) {
                                                           var jsonResult = JSON.parse(data);
                                                           if (parseInt(jsonResult[0][0]) == 1)
                                                           {  // IS FOR MANAGER
                                                               var remarks = "";
				                                        $.ajax({
                                                               type: "POST",
				                                            cache: false,
															url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
				                                            success: function(data) {
                                                                       if (data == 'True')
                                                                       {
                                                                           dialog.close();

                                                                           URL = "../KPI/SpecialAssignment";
                                                                           var detailView = new KPISpecialAssignment(URL, employeeInfo, "FINISH");
                                                                           detailView.open();
				                                                    $('#tblList_EVALUATE').DataTable().ajax.reload();

                                                                       }
                                                                   }
                                                               })


                                                    } else
                        { // FOR RANK AND FILE
                            var remarks = "";
				                                        $.ajax({
                            type: "POST",
				                                            cache: false,
															url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
				                                            success: function(data) {
                                    if (data == 'True')
                                    {
                                        dialog.close();

                                        URL = "../KPI/CoreCompetenciesRev";
                                        var detailView = new KPICoreCompetencies(URL, employeeInfo, "NEXT");
                                        detailView.open();
				                                                    $('#tblList_EVALUATE').DataTable().ajax.reload();
                                    }
                                }
                            })
				                                    }
                    }
                })



                                      }
        });
        break;

                                case "MARK AS REVIEWED": // HR MANAGER
            swal({
            title: "Do you want to continue?",
				                            text: "You will be redirected to the next part of the evaluation (Core Competencies).",
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
												url: '../KPIView/EvaluationDoneTrigger?actionID=' + 2 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
	                                        success: function(data) {
                                                     if (data == 'True')
                                                     {
                                                         dialog.close();

                                                         URL = "../KPI/CoreCompetenciesRev";
                                                         var detailView = new KPICoreCompetenciesHR(URL, employeeInfo, " NEXT ");
                                                         detailView.open();
	                                                $('#tblList_EVALUATE').DataTable().ajax.reload();
                                                     }
                                                 }
                                             })}
    });
    break;
}
                                        }
				                }
				            })
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