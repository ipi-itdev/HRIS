"use strict";
function modalViewers(DetailViewURL,IsHalf = false) {
    this.open = function () {
        BootstrapDialog.show({
            title: '',
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal-dialog',
            message: function (dialog) {
                let $content = $('<div id="myParent"></div>');
                $content.load(DetailViewURL);
                let windowHeight = $(window).height();
                let windowWidth = $(window).width()
                let dialogHeight = windowHeight;
                let dialogWidth = windowWidth;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight * 0.88);
                dialog.getModalContent().css('width', dialogWidth * (IsHalf ? 0.45 : 0.90));
                dialog.getModalContent().css('left', ((dialogWidth * (IsHalf ? 0.47 : 0.90)) - (IsHalf ? (dialogWidth / 2) : dialogWidth)) * 2.8);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            }
            ,buttons: [{
                id: 'btn-Success',
                cssClass: 'btn btn-success',
                label: 'Submit',
                action: function (dialog) {
                   
                }
            }
            ],
            onhide: function (dialogRef) { },
            onshow: function (dialogref) {
                $(document).off('focusin.modal');
            },
            closeByBackdrop: false,
            closeByKeyboard: false
        });
    };
}