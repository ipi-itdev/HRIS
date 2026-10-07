"use strict";
function modieviewer(DetailViewURL, fid, IsHalf = false) {
    console.log('detail view url: ' + DetailViewURL);
    console.log('m form: ' + fid);
    
    this.open = function (Caller) {
        BootstrapDialog.show({
            title: '',
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            message: function (dialog) {
                var windowHeight = $(window).height();
                var windowWidth = $(window).width();
                var dialogHeight = windowHeight;
                var dialogWidth = windowWidth;
                console.log('size ng dialogwidth: ' + dialogWidth);
                console.log('is half ba?: ' + IsHalf);
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight * 0.88);
                if (fid = "mFrm1097") {
                    console.log('para lang to sa kpi target setting na modal');
                    dialog.getModalContent().css('width', dialogWidth * 0.792);
                    dialog.getModalContent().css('left', ((dialogWidth * (IsHalf ? 0.47 : 0.90)) - (IsHalf ? (dialogWidth / 2) : dialogWidth)) * 8.5);
                } else {
                    dialog.getModalContent().css('width', dialogWidth * (IsHalf ? 0.9 : 2.00));
                    dialog.getModalContent().css('left', ((dialogWidth * (IsHalf ? 0.47 : 0.90)) - (IsHalf ? (dialogWidth / 2) : dialogWidth)) * 8.5);
                }
                
                //dialog.getModalContent().css('left', ((dialogWidth * (IsHalf ? 0.47 : 0.90)) - (IsHalf ? (dialogWidth / 2) : dialogWidth)) * 8.5);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                dialog.getModalBody().css('overflow-y', 'auto');
                var $content = $('<div id="modal_' + fid + '"></div>');
                $content.empty();

                $content.load(DetailViewURL, function (response, status, xhr) {
                    if (status == "error") {
                        console.log("Error loading content: " + xhr.status + " " + xhr.statusText);
                    } else {
                        console.log("Content loaded successfully");


                    }
                });

                //$content.load(DetailViewURL);
                return $content;
            },
            buttons: [{
                id: 'btn-Close',
                cssClass: 'btn btn-danger',
                label: 'Close',
                action: function (dialog) {
                    $('#modal').remove();
                    dialog.close();
               
                   
                
                }
            }],
            onhide: function (dialogRef) {},
            onshow: function (dialogref) {
                $(document).off('focusin.modal');
            },
        
            closeByBackdrop: false,
            closeByKeyboard: false
        });
    };


}