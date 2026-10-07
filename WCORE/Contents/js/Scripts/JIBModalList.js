function JIBModalList(DetailViewURL) {
    var _ = this;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function () {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            message: function (dialog) {
                var $content = $('<div id="myParent"></div>');
                $content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()
                var dialogHeight = windowHeight * 0.88;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            },
            buttons: [{
                id: 'btn-Cancel',
                cssClass: 'btn btn-danger',
                label: 'Close',
                action: function (dialog) {
                    dialog.close();
                }
            }],
            onhide: function (dialogRef) {

            },
            onshow: function (dialogref) {
                $(document).off('focusin.modal');
            },
            closeByBackdrop: false,
            closeByKeyboard: true
        });
    };
}