"use strict";
function INVEmpAccountabilityDetailsHist(ObjectID) {
    var self = this;
    this.mguid = '';
    this.mNm = '';
    this.mDesc = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    var qcfutacc = {
        ID: null, EmployeeRefNo: null, Remarks: null, FilingStatusRefNo: 1, CreatedBy: null, CreatedDate: null, ModifiedBy: null, ModifiedDate: null, IsActive: null
        , Save: function (Grid) {
            if (qcfutacc[self.FKN] !== undefined) { qcfutacc[self.FKN] = self.FK; }
            $.ajax({
                url: '../DetailView/Save',
                data: { mName: self.mNm, JSONObject: JSON.stringify(qcfutacc) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                success: function (data) {
                    var res = JSON.parse(data);
                    Toast.Show(self.mDesc + " Save");
                    var URLView = '../INV/EmployeeAccountability?pid=' + res.ID + '&mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { });
                }, error: function (xhr, textStatus, error) { console.log(error); }
            });
        }
        , Delete: function () {
            var item = [];
            item.push(qcfutacc);
            $.ajax({
                url: '../DetailView/Delete',
                data: { mName: self.mNm, JSONObject: JSON.stringify(item) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                success: function (data) {
                    Toast.Show(self.mDesc + " Successfully Deleted");
                    $('#' + self.fid).trigger("OnDetailViewSaved");
                },
                error: function (xhr, textStatus, error) { console.log(error); }
            });
        }
        , Cleared: function () {
            var item = [];
            item.push(qcfutacc);
            $.ajax({
                type: "POST",
                url: '../INV/AccountabilityStatus?status=35&pid=' + qcfutacc.ID,
                success: function (data) {
                    var ret = JSON.parse(data);

                    if (ret[0][0] === 'True') {
                        URL = '../INV/EmployeeAccountability?mguid=' + self.mguid + '&pid=' + qcfutacc.ID;
                        $('#content_mFrm' + self.mNo).load(URL, function () { });
                        Toast.Show("Employee Accountability is Successfully Cleared.");
                    } else { Toast.Error(ret[0][1]); }
                }
            });
        }
        , Deploy: function () {
            var item = [];
            item.push(qcfutacc);
            $.ajax({
                type: "POST",
                url: '../INV/AccountabilityStatus?status=7&pid=' + qcfutacc.ID,
                success: function (data) {
                    var ret = JSON.parse(data);
                    if (ret[0][0] === 'True') {
                        URL = '../INV/EmployeeAccountability?mguid=' + self.mguid + '&pid=' + qcfutacc.ID;
                        $('#content_mFrm' + self.mNo).load(URL, function () { });
                        Toast.Show("Employee Accountability is Successfully Deployed.");
                    } else { Toast.Error(ret[0][1]); }
                }
            });
        }
    }

    function DetailView() {
        var dvFormat = [{
            Name: 'Details', Controls: [{ Name: 'ID', Type: 'Int', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Details', ControlID: 'ID' },
                { Name: 'EmployeeRefNo', Caption: 'Employee', Type: 'Int', ControlType: 'combobox', RefColumn: 'emp', ControlModel: 'INVEmployeeMasterlistAll', ColumnValue: 'ID', DisplayColumnValue: 'Description', IsRequired: false, ColumnNo: 0, TbName: 'Details', ControlID: 'EmployeeRefNo', IsJson: false, IsEnabled: false },
            { Name: 'DeployedDate', Caption: 'Issued Date', ControlType: 'datepicker', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Details', ControlID: 'DeployedDate' },
            { Name: 'DeployedBy', Caption: 'Issued By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Issued By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Details', ControlID: 'DeployedBy', IsJson: false },
            { Name: 'ReturnedDate', Caption: 'Cleared Date', Type: 'String', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Details', ControlID: 'ReturnedDate' },
                { Name: 'ClearBy', Caption: 'Cleared By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: 'ClearBy', ControlModel: 'VIEW_INV_EmpAccountabilityAll', ColumnValue: 'ClearBy', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Details', ControlID: 'ClearByID', IsJson: false },
            { Name: 'Remarks', Type: 'String', ControlType: 'textarea', ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Details', ControlID: 'Remarks' }]
        },
        {
            Name: 'Other', Controls: [{ Name: 'CreatedBy', Caption: 'Created By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Created By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Other', ControlID: 'CreatedBy', IsJson: false },
            { Name: 'CreatedDate', Caption: 'Created Date', Type: 'String', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Other', ControlID: 'CreatedDate' },
            { Name: 'ModifiedBy', Caption: 'Last Modified By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Modified By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Other', ControlID: 'ModifiedBy', IsJson: false },
            { Name: 'ModifiedDate', Caption: 'Last Modified Date', Type: 'String', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Other', ControlID: 'ModifiedDate' },
            { Name: 'IsActive', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: false, ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Other', ControlID: 'IsActive' }]
        }]

        dvFormat.push({ Name: 'INVEmpAccountabilityDetailsHist', Type: '30218', FKey: 'EmpAccountabilityRefNo', FKeyValue: 'ID', HasNew: false, IsListView: true, PropertyName: 'INVEmpAccountabilityDetailsHist' });
        /* dvFormat.push({ Name: 'INVEmpAccountabilityClientDetails', Type:'30214',FKey:'EmpAccountabilityRefNo',FKeyValue:'ID',HasNew:true,IsListView:true,PropertyName:'INVEmpAccountabilityClientDetails'});*/

        this.OpenObject = function (CurrentObject) { InitNewObject(CurrentObject, qcfutacc, self.mNm, self.mNo, self.fid, dvFormat); };
        this.InitDetailView = function (CurrentObject) { InitDetailView(CurrentObject, self.mNm, self.mNo, self.fid, ObjectID, dvFormat); };
    }

    $(function () {
        $('#btnList_' + self.fid).find('button').on('click', function () {
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch (ids.replace('_' + self.fid, '').toUpperCase()) {
                case 'NEW':
                    Message = 'Create New Item?';
                    OkLabel = 'Create';
                    fAction = function (result) { var URLView = '../INV/EmployeeAccountability?pid=-1&mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); }
                    break;
                case 'SAVE':
                    Message = 'Save changes?';
                    OkLabel = 'Save';
                    fAction = function (result) { if (ControlValidation(qcfutacc, self.mNm, self.fid) === true) { qcfutacc.Save(); } };
                    break;
                case 'DELETE':
                    Message = 'Are you sure you want to delete?';
                    OkLabel = 'Delete';
                    fAction = function (result) { self.Delete(); };
                    break;
                case 'FORM':
                    let arr = JSON.stringify({ ID: qcfutacc.ID });
                    let URLVIEW = '../RV/RenderRpt?mguid=' + self.mguid + '&arr=' + arr;
                    let detailView = new modieviewer(URLVIEW);
                    detailView.open();
                    break;
                case 'CLEARED':
                    Message = 'Are you sure you want to tag this employee as cleared?';
                    OkLabel = 'Cleared';
                    fAction = function (result) { qcfutacc.Cleared(); }
                    break;
                case 'DEPLOY':
                    Message = 'Are you sure you want to deploy the employee accountability?';
                    OkLabel = 'Deploy';
                    fAction = function (result) { qcfutacc.Deploy(); }
                    break;
                default:
                    Message = 'Are you sure you want to go back to list?';
                    OkLabel = 'Yes';
                    fAction = function (result) { let URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); }
                    break;
            }
            if (ids.replace('_' + self.fid, '').toUpperCase() !== 'FORM') {
                BootstrapDialog.show({
                    title: self.mDesc, message: Message, closable: true, draggable: true,
                    buttons: [{ id: 'btn-1', label: 'Cancel', cssClass: 'btn-warning', action: function (dialog) { dialog.close(); } },
                    { id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function (dialog) { var $button = this; $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
                });
            }
        });
        var $itm = new DetailView();
        $itm.InitDetailView(qcfutacc);

        $('#tab_' + self.fid + '>li>a').first().click();
    });
}

