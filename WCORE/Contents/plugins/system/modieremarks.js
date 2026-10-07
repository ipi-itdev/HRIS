"use strict";
function modieremarks(title,url,msg,errmsg,fid,redirect,iscallerlistview = false) {
    var _ = this;
    this.open = function (caller) {
        BootstrapDialog.show({
            title: title,
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            message: function (dialog) {
                var $content = $('<div id="myParent" class="text-center">' +
                                    '<h4>Remarks</h4>' + 
                                    '<textarea id="comment" rows="10" cols="45" style="resize:none" class="form-control"></textarea>' +
                                '</div>');
                var windowHeight = 500;
                var windowWidth = 800;
                var dialogHeight = windowHeight * 0.88;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalContent().css('height', dialogHeight * 0.88);
                dialog.getModalContent().css('width', dialogWidth * 0.90);
                dialog.getModalContent().css('left', ((dialogWidth * 0.90) - dialogWidth) * 2.8);
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                return $content;
            },
            buttons: [
            {
                id: 'btn-Success',
                cssClass: 'btn btn-success',
                label: 'Submit',
                action: function (dialog) {
                    if ($('#comment').val() !== '') {
                        document.getElementById("btn-Success").setAttribute("disabled", "disabled");
                        $.ajax({
                            type: "POST",
                            cache: false,
                            url: url + '&remarks=' + $('#comment').val().replace(/\n\r?/g, 'brbr'),
                            success: function (data) {
                                if (data === 'True') { 
                                    document.getElementById("btn-Success").setAttribute("disabled", "disabled");
                                    Toast.Show(msg); dialog.close(); 
                                    if(iscallerlistview === true){caller.Refresh();}
                                    $('#content_' + fid).load(redirect, function () { });}
                                else { Toast.Error('Please contact system administrator.'); }
                            }
                        });
                    } else { Toast.Error('Remarks is required.'); return false; }
                }
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