"use strict";
function formyd(ObjectID) {
    var self = this;
    this.controller = 'DetailView';
    this.mguid = '';
    this.mNm = '';
    this.mNo = 0;
    this.mDesc = '';
    this.cObj = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    this.dvFormat = '';
    this.Save = function (Grid) {
      
		if(self.cObj[self.FKN] !== undefined)
		{ self.cObj[self.FKN]  = self.FK; }
		$.ajax({
			url: '../DetailView/Save',
			data: { mName :self.mNm ,JSONObject : JSON.stringify( self.cObj ) },
			type: 'POST',
			datatype: 'application/json; charset=utf-8',
			success: function (data) {
                var res = JSON.parse(data);
				$('#' + self.fid).trigger("OnDetailViewSaved",res.ID);
				Toast.Show( self.mDesc + " Save");
                //$('#' + self.fid).html('');
               /* $('.fa-times').click();*/
                // add this code for automatically go back in list view upon saving - july 17, 2024
                var URLView = '../ListView/ListIndex?mguid=' + mguid;
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
			}, error: function(xhr, textStatus, error) { console.log(error); }
		});
	};
    this.Delete = function() {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '../DetailView/Delete',
            data: { mName : self.mNm ,JSONObject : JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) { 
                
                $('#' + self.fid).trigger("OnDetailViewSaved");
                Toast.Show(self.mDesc + " Successfully Deleted"); 
                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
            },
            error: function(xhr, textStatus, error) { console.log(error); }
        });
    };
    this.Back = function() {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '../' + controller + '/Approve',
            data: { pKey : self.mNm , stat : 2, remarks : JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) { 
                Toast.Show(self.mDesc + " Successfully Approved." ); 
                var URLView = '../ListView/ListIndex?mguid=' + self.mguid; 
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
            },
            error: function(xhr, textStatus, error) { console.log(error); }
        });
    };
    this.Approve = function() {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '../DetailView/Approve_2',
            data: { mName: self.mNm, JSONObject: JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) {
                Toast.Show(self.mDesc + " Successfully Approved");
                $('#' + self.fid).trigger("OnDetailViewSaved");
                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
            },
            error: function (xhr, textStatus, error) { console.log(error); }
        });
    };

    this.Disapprove2 = function () {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '../DetailView/Disapprove_2',
            data: { mName: self.mNm, JSONObject: JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) {
                Toast.Show(self.mDesc + " Successfully Disapproved");
                $('#' + self.fid).trigger("OnDetailViewSaved");
                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
            },
            error: function (xhr, textStatus, error) { console.log(error); }
        });
    };

    this.Printed = function () {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '../DetailView/Printed',
            data: { mName: self.mNm, JSONObject: JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) {
                Toast.Show(self.mDesc + " Successfully Printed");
                $('#' + self.fid).trigger("OnDetailViewSaved");
                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                $('#content_mFrm' + self.mNo).load(URLView, function () { });
            },
            error: function (xhr, textStatus, error) { console.log(error); }
        });
    };
    this.Disapprove = function() {
        var item = [];
        item.push(self.cObj);
        $.ajax({
            url: '@Url.Action("Delete")',
            data: { mNm : self.mNm ,JSONObject : JSON.stringify(item) },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) { Toast.Show( "Deleted" ); $('#' + self.fid).trigger("OnDetailViewSaved"); },
            error: function(xhr, textStatus, error) { console.log(error); }
        });
    };

    this.Proceed = function () {
        var item = [];
        item.push(self.cObj);

        var retrieve_id = JSON.stringify(item[0]);
        var parsed_id = JSON.parse(retrieve_id);
        var pid = parsed_id.ID;
        console.log('ito yu=ng pid sa target setting: ' + pid);

        kpiAssignmentID = pid;
        employeeInfo = $("#select2-EmployeeRefNo_TargetSettingRev-container").text().toUpperCase();

        $.ajax({
            type: "POST",
            cache: false,
            url: '../KPI/CheckTargets?kpiid=' + kpiAssignmentID + '&empRefNo=' + 0,
            success: function (data) {

                var jsonResult = JSON.parse(data);

                console.log(jsonResult);
                console.log('dumadaan ba dito?');
                console.log('result ng json 0: ' + parseInt(jsonResult[0][0]));
                console.log('result ng json 1: ' + parseInt(jsonResult[0][1]));
                console.log('result ng json 2: ' + parseInt(jsonResult[0][2]));
                console.log('result ng json 3: ' + parseInt(jsonResult[0][3]));
                console.log('result ng json 4: ' + parseInt(jsonResult[0][4]));
                console.log('result ng json 5: ' + parseInt(jsonResult[0][5]));
                console.log('result ng json 6: ' + parseInt(jsonResult[0][6]));


               /* if (parseInt(jsonResult[0][3]) = 1) { dialogTitle = "Internal"; } else { dialogTitle = "External"; }*/

                if ((parseInt(jsonResult[0][3]) == 1 || parseInt(jsonResult[0][3]) == 2) && parseInt(jsonResult[0][4]) == 1 && parseInt(jsonResult[0][5]) == 0) {

                    if (parseInt(jsonResult[0][1]) == 0) {
                        console.log('There are still KPIs with no target.');
                        Toast.Error("There are still KPI's with no target.");
                        //var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                        //$('#content_mFrm' + self.mNo).load(URLView, function () { });
                    } else {

                        if (parseInt(jsonResult[0][0]) == 0) {
                            var remarks = "";
                            $.ajax({
                                type: "POST",
                                cache: false,
                                url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
                                success: function (data) {
                                    if (data == 'True') {
                                        //var URLView = '../ListView?ModelNo=1097'; $('#content_TargetSettingRev').load(URLView, function () { });


                                        Toast.Show(self.mDesc + " Successfully Processed. Proceed to On-Going");
                                        var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                                        $('#content_mFrm' + self.mNo).load(URLView, function () { });

                                        URL = "../KPI/KPIScorePerCategory";
                                        var detailView = new KPIScoring(URL, employeeInfo, "NEXT");
                                        detailView.open();

                                     

                                    }
                                }
                            })

                        } else {
                            var remarks = "";
                            $.ajax({
                                type: "POST",
                                cache: false,
                                url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
                                success: function (data) {
                                    if (data == 'True') {
                                        //var URLView = '../ListView?ModelNo=1097'; $('#content_TargetSettingRev').load(URLView, function () { });

                                        Toast.Show(self.mDesc + " Successfully Processed. Proceed to On-Going");
                                        var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                                        $('#content_mFrm' + self.mNo).load(URLView, function () { });

                                        URL = "../KPI/ManagersScore";
                                        console.log('ito yung URL: ' + URL);
                                        console.log('naka defined ba? ' + ManagersCore);
                                        var detailView = new ManagersCore(URL, employeeInfo, 1);
                                        detailView.open();

                                       
                                  

                                    }
                                }
                            })
                        }

                    }
                } else if ((parseInt(jsonResult[0][3]) == 1 || parseInt(jsonResult[0][3]) == 2) && parseInt(jsonResult[0][4]) == 0 && parseInt(jsonResult[0][5]) == 0) {
                    console.log('You need add KPI for the employee.');
                    Toast.Error("You need add KPI for the employee.");

                } else if ((parseInt(jsonResult[0][3]) == 1 || parseInt(jsonResult[0][3]) == 2) && parseInt(jsonResult[0][4]) == 0 && parseInt(jsonResult[0][5]) == 1) {
                    var remarks = "";
                    $.ajax({
                        type: "POST",
                        cache: false,
                        url: '../KPIView/EvaluationDoneTrigger?actionID=' + 1 + '&kpiAssignmentRefNo=' + kpiAssignmentID + '&remarks=' + remarks,
                        success: function (data) {
                            if (data == 'True') {
                                //var URLView = '../ListView?ModelNo=1097'; $('#content_TargetSettingRev').load(URLView, function () { });

                                Toast.Show(self.mDesc + " Successfully Processed. Proceed to On-Going");
                                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;

                                $('#content_mFrm' + self.mNo).load(URLView, function () { });

                                URL = "../KPI/CoreCompetenciesRev";
                                var detailView = new KPICoreCompetencies(URL, employeeInfo);
                                detailView.open();

                               
                           
                            }
                        }
                    })
                }

            }
        });


        //Toast.Show(self.mDesc + " Successfully Completed"); 
        //var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
        //$('#content_mFrm' + self.mNo).load(URLView, function () { });
    };

    function DetailView() {
		this.OpenObject = function(CurrentObject) {  InitNewObject(CurrentObject,self.cObj,self.mNm,self.mNo,self.fid,self.dvFormat); };
		this.InitDetailView = function(CurrentObject) { InitDetailView(CurrentObject,self.mNm,self.mNo,self.fid,ObjectID,self.dvFormat); };       
    }
    
     $(function () {
        $('#btnList_' + self.fid).find('button').on('click', function() {
            $('#XButton').click(); 
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch ( ids.replace('_' + self.fid,'').toUpperCase() ) {
                case 'SAVE':
                    Message = 'Save changes?';
                    OkLabel = 'Save';
                    fAction = function (result) { 

                        if (ControlValidation(self.cObj, self.mNm, self.fid) === true) {
                            //alert('1!');
                            if(ControlValidationUnique(self.cObj,self.mNm,self.fid) === true) {
                                self.Save();
                                var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                                $('#content_mFrm' + self.mNo).load(URLView, function () { }); 
                            }
                        }
                    }
                    break;
                case 'DELETE':
                    Message = 'Are you sure you want to delete?';
                    OkLabel = 'Delete';
                    fAction = function (result) {
                         self.Delete();
                        var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                        $('#content_mFrm' + self.mNo).load(URLView, function () { })
                       
                    };
                    break;
                case 'PRINTED':
                    Message = 'Are you sure you want tag this as printed?';
                    OkLabel = 'Printed';
                    fAction = function (result) {
                        self.Printed();
                        var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                        $('#content_mFrm' + self.mNo).load(URLView, function () { })

                    };
                    break;
                case 'APPROVE':
                    Message = 'Are you sure you want to approve?';
                    OkLabel = 'Approve';
                    fAction = function (result) {
                        self.Approve(); var URLView = '../ListView/ListIndex?mguid=' + self.mguid;
                        $('#content_mFrm' + self.mNo).load(URLView, function () { })
                    };
                    break;
                case 'DISAPPROVE':
                    Message = 'Are you sure you want to disapprove?';
                    OkLabel = 'Approve';
                    fAction = function (result) { self.Disapprove2(); };
                    break;
                case 'PROCEED':
                    Message = 'Do you want to proceed to evaluation?'; OkLabel = 'Ok';
                    fAction = function (result) {

                        self.Proceed();
                    }
                    break;
                default :
                    Message = 'Are you sure you want to go back to list?'; OkLabel = 'Ok';
                    fAction = function (result) { 
                        var URLView = '../ListView/ListIndex?mguid=' + self.mguid; 
                        $('#content_mFrm' + self.mNo).load(URLView, function () { }); 
                    }
					break;
            }
            BootstrapDialog.show({
                title: self.mDesc , message: Message, closable: true, draggable: true,
                buttons: [{ id: 'btn-1', label: 'Cancel' , cssClass: 'btn-warning', action: function(dialog) { dialog.close(); } },
                          { id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function(dialog) { var $button = this;  $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
            });
        });
        var $itm = new DetailView();
        $itm.InitDetailView(self.cObj);

        $('#' + self.fid).trigger("OnDetailViewContentCreated" , { BaseObject: self.cObj, DV : new DetailView() } );
        $('#' + self.fid).unbind("OnDetailViewContentCreated");

        $('#tab_' + self.fid + '>li>a').first().click();
            
     });
}

