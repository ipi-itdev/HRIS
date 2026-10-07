function KPISummaryReportGM(DetailViewURL, reportHeader, buttonLabel) {
	var _ = this;
	this.CurrentObject = null;
	this.ID = null;
	this.open = function () {
		BootstrapDialog.show({
			type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + reportHeader + ' <small></small></b>',
			message: function (dialog) {
				var $content = $('<div id="myParent"></div>');
				$content.load(DetailViewURL);
				var windowHeight = $(window).height();
				var windowWidth = $(window).width()
				var dialogHeight = windowHeight * 0.88;
				var dialogWidth = windowWidth * 0.95;
				console.log('ito yung value ng height: ' + dialogHeight);
				console.log('ito yung value ng width:' + dialogWidth);
				dialog.getModalDialog().css('width', dialogWidth);
				dialog.getModalContent().css('height', dialogHeight + 40);
				dialog.getModalContent().css('width', 1200);
				dialog.getModalContent().css('left', -350);
				dialog.getModalBody().css('height', dialogHeight * 0.88);
				return $content;
			},
			buttons: [{

				id: 'btn-Close',
				cssClass: 'btn btn-danger',
				label: "CLOSE",
				action: function (dialog) {
					dialog.close();
				}
			   
				},{
				id: 'btn-Return',
				cssClass: 'btn btn-info',
				label: buttonLabel,
				action: function (dialog) {

					if (buttonLabel == "MARK AS FOR REVIEW") {

						$(document).off('focusin.modal');
						swal({
							text: 'Add Remarks to continue...',
							content: {
								element: "input",
								attributes: {
									placeholder: "Write something here...",
									type: "text",
									showCancelButton: true,
									closeOnConfirm: false,
									animation: "slide-from-top",
								}
							},

							icon: "info",
							button: {
								text: "Confirm",
							},
						}).then(remarks => {

							if (!remarks) {
								return swal("Add remarks and click Confirm!");
							} else {

								var message = remarks;
								message = message.replace(/'/g, "`");
								$.ajax({
									type: "POST",
									cache: false,
									url: '../KPI/EvaluationDoneTrigger?actionID=' + 4 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + message,
									success: function (data) {
										if (data == 'True') {
											dialog.close();
											$('#tblList_EVALUATE').DataTable().ajax.reload();
											Toast.Show("You have tagged the evaluation as for review.");
										}
									}
								})
							}
						})

	               } else if(buttonLabel == "SEND BACK"){
						$(document).off('focusin.modal');
						swal({
							text: 'Add Remarks to continue...',
							content: {
								element: "input",
								attributes: {
									placeholder: "Write something here...",
									type: "text",
									showCancelButton: true,
									closeOnConfirm: false,
									animation: "slide-from-top",
								}
							},

							icon: "info",
							button: {
								text: "Confirm",
							},
							}).then(remarks => {

							if (!remarks) {
								return swal("Add remarks and click Confirm!");
							} else {

								var message = remarks;
								message = message.replace(/'/g, "`");
								$.ajax({
									type: "POST",
									cache: false,
									url: '../KPI/EvaluationDoneTrigger?actionID=' + 4 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + message,
									success: function (data) {
										if (data == 'True') {
											dialog.close();
											$('#tblList_EVALUATE').DataTable().ajax.reload();
											Toast.Show("You have successfully send back to the evaluating supervisor.");
										}
									}
								})
							}
						})

	                    }
					
				}},{
				id: 'btn-Approve',
				cssClass: 'btn btn-success',
				label: "APPROVE",
				action: function (dialog) {

					swal({
						title: "Do you want to continue?",
						text: "This will now officially record the result of evaluation.",
						icon: "info",
						buttons: true,
						dangerMode: true,
					})
					.then((willDelete) => {

						if (willDelete) {
							var remarks = "";
							remarks = remarks.replace(/'/g, "`");
								$.ajax({    
						            type: "POST",
						            cache: false,
									url: '../KPIView/EvaluationDoneTrigger?actionID=' + 3 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
						            success: function (data) {
										if (data == 'True') {
											Toast.Show("Successfully Approved!");
								            dialog.close();
								            $('#tblList_EVALUATE').DataTable().ajax.reload();
							            }
							         }
							})
					}});
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