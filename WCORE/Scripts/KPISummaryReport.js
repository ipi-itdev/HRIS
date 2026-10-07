
function KPISummaryReport(DetailViewURL, reportHeader , buttonLabel)
{
    var _ = this;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function() {
        BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + reportHeader + ' <small></small></b>',
			message: function(dialog) {
                var $content = $('<div id="myParent"></div>');
				$content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()

                var dialogHeight = windowHeight * 0.88;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                return $content;
            },
			buttons:
            [{
            id: 'btn-Report',
				cssClass: 'btn btn-danger',
				label: buttonLabel,
				action: function(dialog) {

                    switch (buttonLabel)
                    {

                        case " CLOSE ": // MANAGER
                            dialog.close();
                            break;

                        case "CLOSE": // MANAGER
                            swal("All done!", "Keep track of the status of evaluation of the selected employee at the ON-GOING tab.", "success");
                            dialog.close();
                            break;

                        case "ENDORSE": // HR MANAGER

                            swal({
                            title: "Confirmation..",
								text: "Are you sure you want to endorse this to the General Manager for approval?",
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
									            $('#tblList_EVALUATE').DataTable().ajax.reload();
                                            }
                                    }
                                })
							}});
break;
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