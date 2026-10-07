"use strict";
function formy(DetailViewURL, FormID, IsDetailPopup = false, IsHalf = false) {
    console.log(DetailViewURL);
  
    this.open = function (callerlistview) {
        console.log('value:' + callerlistview);
        if(IsDetailPopup === 'True'){
                BootstrapDialog.show({
                    title: '',
                    type: BootstrapDialog.TYPE_DEFAULT,
                    ccsClass: 'modal modal-primary',
                    message: function (dialog) { 
                        var $contents = $('<div id=' + FormID + '></div>');
                        $contents.on('OnDetailViewContentCreated', function (e, o) {
                    
                        });
                        $contents.off('OnDetailViewSaved').on('OnDetailViewSaved', function (event, pkey) { callerlistview.Refresh(pkey); });
                        $contents.load(DetailViewURL);
                        var windowHeight = $(window).height();
                        var windowWidth = IsHalf ? $(window).width() / 2 : $(window).width();
                        var dialogHeight = windowHeight * 0.85;
                        var dialogWidth = windowWidth * 0.95;
                        dialog.getModalDialog().css('width', dialogWidth);
                        dialog.getModalContent().css('height', dialogHeight);
                        dialog.getModalBody().css('height', dialogHeight * 0.85);
                        return $contents;
                    },
                    buttons: [
                        {
                        id: 'btn-Cancel',
                        cssClass: 'btn btn-danger',
                        label: 'Close',
                        action: function (dialog) { dialog.close(); }
                        }   
                    ],
                    onhide: function (dialogRef) {  },
                    onshow: function (dialogref) { $(document).off('focusin.modal'); },
                    closeByBackdrop: false,
                    closeByKeyboard: false
                });
        }else {
            var $contents = $('#' + FormID);
            $contents.html('');
            $contents.off('OnDetailViewSaved').on('OnDetailViewSaved', function (event, pkey) { callerlistview.Refresh(pkey);});
            $contents.load(DetailViewURL);  
            $('.content-wrapper').waitMe('hide');   
        }
    }
}
