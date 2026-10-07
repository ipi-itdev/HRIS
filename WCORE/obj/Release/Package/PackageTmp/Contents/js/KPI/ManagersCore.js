//using DocumentFormat.OpenXml.Wordprocessing;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Security.Policy;
//using System.Web.UI.WebControls;

function ManagersCore(DetailViewURL, employeeInfo, EvalPart)
{
    var _ = this;
    var isReady;
    this.CurrentObject = null;
    this.ID = null;
    this.open = function() {
        BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DEFAULT,
			ccsClass: 'modal modal-primary',
			title: '<b><i id="nav_item"/> ' + employeeInfo + ' <small></small></b>',
			message: function(dialog) {
                var $content = $('<div id="myParent_' + '' + '" style="overflow:hidden; "></div>');
			 
				$content.load(DetailViewURL);
                var windowHeight = $(window).height();
                var windowWidth = $(window).width()

                //var dialogHeight = windowHeight * 0.5;
                //var dialogWidth = windowWidth * 0.4;
                //dialog.getModalDialog().css('width', dialogWidth);
                //dialog.getModalDialog().css('overflow-y', 'initial !important');
                //dialog.getModalContent().css('height', dialogHeight);
                //dialog.getModalBody().css('padding', '0px');
                //dialog.getModalBody().css('height', dialogHeight * 0.8);
                //dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
                //dialog.getModalBody().css('overflow-y', 'auto');

                var dialogHeight = windowHeight * 0.75;
                var dialogWidth = windowWidth * 0.9;
                dialog.getModalDialog().css('width', dialogWidth);
                dialog.getModalDialog().css('overflow-y', 'initial !important');
                //dialog.getModalContent().css('height', dialogHeight);

                dialog.getModalContent().css('height', dialogHeight + 70);
                dialog.getModalContent().css('width', 1200);
                dialog.getModalContent().css('left', -350);

                dialog.getModalBody().css('padding', '0px');
                dialog.getModalBody().css('height', dialogHeight * 0.85);
                dialog.getModalBody().css('max-height', 'calc(100vh - 200px)');
                dialog.getModalBody().css('overflow-y', 'auto');
                return $content;
            },
			buttons:
            [{

            id: 'btn-Close',
			    cssClass: 'btn btn-danger',
			    label: "CLOSE",
			    action: function(dialog) {
                    dialog.close();
			        $('#tblList_EVALUATE').DataTable().ajax.reload();
                }
            }, {
            id: 'btn-Next',
				cssClass: 'btn btn-success',
				label: "NEXT",
                action: function (dialog) {
               
                    dialog.close();

                    if (parseInt(EvalPart) == 1)
                    { // KPI SCORES

                        URL = "../KPI/KPIScorePerCategory";
                        var detailView = new KPIScoring(URL, employeeInfo, "NEXT");
                        detailView.open();

                    }
                    else if (parseInt(EvalPart) == 3)
                    { // SPECIAL ASSIGNMENTS

                        URL = "../KPI/SpecialAssignment";
                        var detailView = new KPISpecialAssignment(URL, employeeInfo, "FINISH");
                        Toast.Show("Successfully Finished!");
                        detailView.open();

                    }

				    $('#tblList_EVALUATE').DataTable().ajax.reload();

                }
            }],    
	     
	onhide: function(dialogRef) {

            },
	onshow: function(dialogref) {
		$(document).off('focusin.modal');
            },
	closeByBackdrop: false,
		closeByKeyboard: false

    });
	};

	}