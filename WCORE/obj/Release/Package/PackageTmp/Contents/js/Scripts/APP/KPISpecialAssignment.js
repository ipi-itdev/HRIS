function KPISpecialAssignment(DetailViewURL, employeeDetails, buttonLabel) {
	var _ = this;
	var i, isFinished = false;
	this.CurrentObject = null;
	this.ID = null;
	this.open = function () {
		BootstrapDialog.show({
			type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + employeeDetails.toUpperCase() + ' <small></small></b>',
			message: function (dialog) {
				var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
			 
				$content.load(DetailViewURL);
				var windowHeight = $(window).height();
				var windowWidth = $(window).width()
				var dialogHeight = windowHeight * 0.80;
				var dialogWidth = windowWidth * 0.95;
				console.log('value ng window height: ' + windowHeight);
				console.log('value ng window width: ' + windowWidth);
				dialog.getModalDialog().css('width', dialogWidth);
				dialog.getModalDialog().css('overflow-y', 'initial !important');
				//dialog.getModalContent().css('height', dialogHeight);
				//dialog.getModalBody().css('padding', '0px');
				//dialog.getModalBody().css('height', dialogHeight * 0.85);
				//dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
				//dialog.getModalBody().css('overflow-y', 'auto');

				dialog.getModalContent().css('height', dialogHeight + 70);
				dialog.getModalContent().css('width', 1200);
				dialog.getModalContent().css('left', -350);

				dialog.getModalBody().css('padding', '0px');
				dialog.getModalBody().css('height', dialogHeight * 0.85);
				dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
				dialog.getModalBody().css('overflow-y', 'auto');
				return $content;
			},
			buttons: [{

				id: 'btn-Close',
				cssClass: 'btn btn-danger',
				label: "CLOSE",
				action: function (dialog) {

				    swal({
				        title: "Do you want to continue?",
				        text: "Data might have not been saved yet.",
				        icon: "info",
				        buttons: true,
				        dangerMode: true,
				    })
					.then((willDelete) => {
					if (willDelete) {			
				        dialog.close();
				    }});
				}

				},{
				id: 'btn-Finish',
				cssClass: 'btn btn-info',
				label: buttonLabel,
				action: function (dialog) {

					RequiredFieldCheck();

					if (isready == false) {
						Toast.Error("You are required to fill-in the Core Strengths, Core Areas for improvement and Action Plan.");
					} else {

						swal({
							title: "Are you sure?",
							text: "Scores will now be consolidated.",
							icon: "info",
							buttons: true,
							dangerMode: true,
						})
						.then((willDelete) => {
							if (willDelete) {
								UpdatingPartThree();
								if (isready == true) {
									var remarks = "";
									$.ajax({
										type: "POST",
										cache: false,
										url: '../KPI/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
										success: function (data) {
											if (data == 'True') {
												var reportName;
												$.ajax({
													type: "POST",
													cache: false,
													url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
													success: function (data) {
														var jsonResult = JSON.parse(data);
														if (parseInt(jsonResult[0][0]) == 1 && parseInt(jsonResult[0][3]) == 1) {
															reportName = "PEManager";
															URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
															var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", buttonLabel === "FINISH" ? "CLOSE" : "ENDORSE");
															detailView.open();
						
														} else {
															reportName = "PerformanceEvaluation";
															URLVIEW = '../KPI/KPIReport?KPIAssignmentDetailsID=' + kpiAssignmentID + '&status=' + "DRAFT" + '&reportName=' + reportName;
															var detailView = new KPISummaryReport(URLVIEW, "KEY PERFORMANCE INDICATOR", "CLOSE");
															detailView.open();
														}
														dialog.close()
														$('#tblList_EVALUATE').DataTable().ajax.reload();
													}
												})
											}
										}
									})
								}
							}
						});
					}
				}

			}],
onhide: function (dialogRef) {
				
},
onshow: function (dialogref) {
	$(document).off('focusin.modal');
},
closeByBackdrop: false,
	closeByKeyboard: false
});
};

}