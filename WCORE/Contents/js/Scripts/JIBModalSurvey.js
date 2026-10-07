function JIBModalSurvey(URLVIEW) {
    var _ = this;
    this.open = function () {
        BootstrapDialog.show({
            title: 'Survey',
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            message: function (dialog) {
                var $content = $('<div id="myParent"></div>');
                $content.load(URLVIEW);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()
                var dialogHeight = windowHeight * 0.88;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                return $content;
            },
            buttons: [ {
                id: 'btn-Cancel',
                cssClass: 'btn btn-danger',
                label: 'Skip',
                action: function (dialog) { dialog.close(); }
            },
            {
                id: 'btn-Success',
                cssClass: 'btn btn-success',
                label: 'Submit',
                action: function (dialog) { dialog.close(); }
            }
            ],
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