function KPICoreCompetenciesHR(DetailViewURL, employeeDetails) {
    var _ = this;
    var i, isFinished = false;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function () {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            ccsClass: 'modal modal-primary',
            title: '<b><i id="nav_item"/> ' + employeeDetails.toUpperCase() + ' <small></small></b>',
            message: function (dialog) {
                var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
             
                $content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()
                var dialogHeight = windowHeight * 0.75;
                var dialogWidth = windowWidth * 0.95; 
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                dialog.getModalContent().css('height', dialogHeight);
                dialog.getModalBody().css('padding', '0px');
                dialog.getModalBody().css('height', dialogHeight * 0.88);
                dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
                dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            },
            buttons: [{
                        id: 'btn-Close',
                        cssClass: 'btn btn-danger',
                        label: "CLOSE",
                        action: function (dialog) {
                   
                            swal({
                                title: "Do you want to continue?",
                                text: "Data has not been saved yet.",
                                icon: "info",
                                buttons: true, 
                                dangerMode: true,
                            })
                           .then((willDelete) => {
                               if (willDelete) {
                                     dialog.close()
                                }});
           
                            }

                        }, 
                        {

                        id: 'btn-Back',
                        cssClass: 'btn btn-info',
                        label: "BACK",
                        action: function (dialog) {

                            BackChoices();
                        }},
                        {
                        id: 'btn-Next',
                        cssClass: 'btn btn-success',
                        label: "NEXT",
                        action: function (dialog) {

                            NextChoices();
                            if (isReady == 1) {

                                swal({
                                    title: "Confirmation..",
                                    text: "Scores will now be consolidated, do you want to continue?",
                                    icon: "info",
                                    buttons: true, 
                                    dangerMode: true,
                                })
                              .then((willDelete) => {
                                  if (willDelete) {
                                        dialog.close()
                                        getScores(2);
                            }});
                        isReady = 0;
    }

                    }}],
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