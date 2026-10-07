"use strict";
function INItemPartsStatus(title,url,msg,errmsg,model,redirect,iscallerlistview = false) {
    this.open = function (caller) {
        BootstrapDialog.show({
            title: title,
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            message: function (dialog) {
                let $content = $('<div id="content" class="module-wrapper ng-scope">'
                                + ' <section class="content-header">'
                                + '      <h1>Item Parts Status Updates</h1>'
                                + '</section>'
                                + '<section class="content">'
                                + '<div class="row">'
                                    + '<div class="col-md-12">'
                                        + '<div class="box box-primary">'
                                            + '<div class="box-body">'
                                                + '<div class="row">'
					                                + '<div class="col-md-12">'
						                                + '<div class="row form-group">'
							                                + '<label class="col-lg-12 control-label style=" text-align:left"="">Item Status:   </label>'
							                                + '<div class="col-lg-12 control-container vcenter">'
								                                + '<select id="itemPartsStatus" class="form-control">'
								                                  + '<option value="1">Good</option>'
								                                  + '<option value="3">For Repair</option>'
								                                  + '<option value="4">Defective</option>'
								                                + '</select>'
							                                + '</div>'
						                                + '</div>'
						                                + '<div class="row form-group">'
							                                + '<label class="col-lg-12 control-label style=" text-align:left"="">Remarks:   </label>'
							                                + '<div class="col-lg-12 control-container vcenter">'
								                                + '<textarea rows="4" cols="45" style="resize:none" class="form-control" id="iStatusRemarks"></textarea>'
							                                + '</div>'
						                                + '</div>'
					                                + '</div>'
                                                + '</div>'
                                            + '</div>'
    	                                + '</div>'
	                                + '</div>'
                                + '</div>'
                                + '</section>'
                                + '</div>');
                let windowHeight = 500;
                let windowWidth = 800
                let dialogHeight = windowHeight * 0.88;
                let dialogWidth = windowWidth * 0.95;
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
                    if ($('#comment').val() != '') {
                        document.getElementById("btn-Success").setAttribute("disabled", "disabled");
                        $.ajax({
                            type: "POST",
                            cache: false,
                            url: '../INV/ItemStatus?pid=@ViewBag.pid&status=' + $('#itemPartsStatus').val() +'&remarks=' + $('#iStatusRemarks').val(),
                            success: function (data) {
                                const ret = JSON.parse(data);
                                if (ret[0][0] == 'True') { 
                                    document.getElementById("btn-Success").setAttribute("disabled", "disabled");
                                    Toast.Show(msg); dialog.close(); 
                                    if(iscaller
                                        === true){caller.Refresh();}
                                else { Toast.Error(ret[0][1]); }
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