function JIBModalDD(ModelNo, DetailViewURL, DisplayName,CallerName, ParentModel) {
    var _ = this;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function () {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            title: '<b><i id="nav_item" class="fa fa-puzzle-piece"/> ' + DisplayName + ' <small></small></b>',
            message: function (dialog) {
                var $content = $('<div id="myParent_' + ModelNo + '"></div>');
                $content.on('OnDetailViewContentCreated', function (e, o) {
                    _.CurrentObject = o.BaseObject;
                });
                DetailViewURL = DetailViewURL.replace('_Index', '_IndexDialog');
                $content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()
                var dialogHeight = windowHeight * 0.85;
                var dialogWidth = windowWidth * 0.70;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('padding', '0px');
                dialog.getModalBody().css('height', dialogHeight * 0.82);
                return $content;
            },
            buttons: [{
                id: 'btn-Cancel',
                cssClass: 'btn btn-danger',
                label: 'Close',
                action: function (dialog) {
                    if (_.CurrentObject.ID > 0) {
                        var slct = $('select[name=' + CallerName + ']', parent.document);
                        var option = new Option(_.CurrentObject.Description, _.CurrentObject.ID, true, true);
                        slct.append(option).trigger('select2:select');
                    }
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