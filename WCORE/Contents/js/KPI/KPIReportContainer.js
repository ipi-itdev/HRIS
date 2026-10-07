

function KPIReportContainer(DetailViewURL)
{
    var _ = this;
    var i, isFinished = false;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function() {
        BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            title: '<b><i id="nav_item"/> ' + "EMPLOYEE EVALUATION REPORT" + ' <small></small></b>',
            message: function(dialog) {
                var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
             
                $content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()
                var dialogHeight = windowHeight * 0.9;
                var dialogWidth = windowWidth * 0.95;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('padding', '0px');
                dialog.getModalBody().css('height', dialogHeight * 0.85);
                dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
                //dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            },
            buttons:
            [{
            id: 'btn-Done',
                cssClass: 'btn btn-info',
                label: 'DONE',
                action: function(dialog) {




                }
            }],
onhide: function(dialogRef) {

            },
onshow: function(dialogref) {
    $(document).off('focusin.modal');
            },
closeByBackdrop: false,
    closeByKeyboard: true
});
};

}