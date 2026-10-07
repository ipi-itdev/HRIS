function JIBModal(Model, CurrentItemSelected, DetailViewURL, Icon, DisplayName) {
    var _ = this;
    this.CurrentObject = null;
    var IsEditOnly = false;
    this.open = function (callerlistview) {
        var Caption = CurrentItemSelected ? ' (' + CurrentItemSelected.CurrentObject.caption + ')' : '';
        var id = -1;
        if (CurrentItemSelected) {
            id = CurrentItemSelected ? CurrentItemSelected.CurrentObject.ID : -1;
            if (id > 0) { IsEditOnly = true; }
        }
        BootstrapDialog.configDefaultOptions({
            cssClass: Model + '_DetailView_Dialog'
        });
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'baseobject-dialog',
            title: '<b><i id="nav_item" class="fa fa-puzzle-piece"/> ' + DisplayName + ' <small></small></b>',
            message: function (dialog) {
                var $content = $('<div id="myParent_'+ Model + '"></div>');
                $content.on('OnDetailViewContentCreated', function (e, o) {
                     _.CurrentObject = o.BaseObject; 
                });
                DetailViewURL = DetailViewURL.replace('PRIMARY_KEY', id);
                DetailViewURL = DetailViewURL + '&IsEditOnly=' + IsEditOnly;
                $content.load(DetailViewURL);
                var windowHeight = window.innerHeight;
                var windowWidth = window.innerWidth;
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
                cssClass: 'btn btn-default',
                label: 'Close',
                action: function (dialog) {
                    dialog.close();
                }}],
            onhide: function (dialogRef) {
                if (callerlistview != null) callerlistview.IsDetailViewOpen = false;
            },
            onshow: function (dialogref) {
                $(document).off('focusin.modal');
            },
            closeByBackdrop: false,
            closeByKeyboard: true
        });
    }; 
    
}