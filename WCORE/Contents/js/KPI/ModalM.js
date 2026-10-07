function ModalM(DetailViewURL, documentName) {
	var _ = this;
	var isReady;
	this.CurrentObject = null;
	this.ID = null;
	this.open = function () {
		BootstrapDialog.show({
			type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + documentName + ' <small></small></b>',
			message: function (dialog) {
				var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');

				$content.load(DetailViewURL);
				var windowHeight = $(window).height();
				var windowWidth = $(window).width()
				var dialogHeight = windowHeight * 0.6;
				var dialogWidth = windowWidth * 0.4;
				dialog.getModalDialog().css('width', dialogWidth);
				dialog.getModalDialog().css('overflow-y', 'initial !important');
				dialog.getModalContent().css('height', dialogHeight);
				dialog.getModalBody().css('padding', '0px');
				dialog.getModalBody().css('height', dialogHeight * 0.85);
				//dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
				//dialog.getModalBody().css('overflow-y', 'auto');
				return $content;
			},
			buttons: [{
				id: 'btn-Close',
				cssClass: 'btn btn-danger',
				label: "Close",
				action: function (dialog) {
					dialog.close();

					$('#tblDocumentTracker').DataTable().ajax.reload();
					$('#tblDocumentTrackerDone').DataTable().ajax.reload();

				}
			},
			{
				id: 'btn-Save',
				cssClass: 'btn btn-success',
				label: "Save Details",
				action: function (dialog) {

					UpdateDocumentDetails();
					$('#tblDocumentTracker').DataTable().ajax.reload();
					$('#tblDocumentTrackerDones').DataTable().ajax.reload();
					if (isDocumentReady == 1) {
						dialog.close();
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