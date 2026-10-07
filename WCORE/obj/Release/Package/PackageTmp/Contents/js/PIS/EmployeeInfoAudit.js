"use strict";
function EmployeeInfoAudit(ObjectID) {
    const self = this;
    this.mguid = '';
    this.mNm = '';
    this.mNo = 0;
    this.mDesc = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    var infoaudit = { ID: null, EmployeeNumber: null, EmployeeRefNo: null, LastName: null, FirstName: null, MiddleName: null, Suffix: null
        , NickName: null, GenderRefNo: null, CivilStatusRefNo: 1, Birthdate: null, Age: null, BirthPlace: null
        , BloodtypeRefNo: null, Allergies: null, NationalityRefNo: 1, ReligionRefNo: 1, Height: null, Weight: null
        , WorkEmailAddress: null, TelephoneNumber: null, SocialMedia: null, MobileNumber: null, CurrentAddress: null
        , CityRefNo: null, ProvinceAddress: null, EmergencyName1: null, EmergencyAddress1: null, EmergencyContactNo1: null
        , EmergencyRelationship1: null, EmergencyName2: null, EmergencyAddress2: null, EmergencyContactNo2: null
        , EmergencyRelationship2: null, TinNumber: null, PhilHealthNumber: null
        , SSSNumber: null, PagibigNumber: null, UCPBCardNo: null, UCPBPolicyNo: null, CreatedBy: null
        , CreatedDate: null, ModifiedBy: null, ModifiedDate: null, IsActive: null, IsConfirmed:1, Changes:[]
		, Apply : function() {
            $.ajax({
                type: "POST",
                cache: false,
                url:  '../PIS/ApplyAudit?pid=' + infoaudit.ID,
                success: function (data) {
                    if (data === 'True') {
                        let URLView = '../ListView/ListIndex?mguid=' + self.mguid; 
                        $('#content_' + self.fid).load(URLView, function () { });
                        Toast.Show( "Successfully Applied.");
                    }
                    else { Toast.Error("Error"); }
                }
            });
		}
        , Return : function() {
            let URLVIEW = '../PIS/ReturnAudit?pid=' + infoaudit.ID
			let redURLView = '../ListView/ListIndex?mguid=' + self.mguid; 
			let detailView = new modieremarks("Employee Information Update",URLVIEW,"Successfully Back to the Employee.","Failed. Please contact administrator.",self.fid,redURLView);
			detailView.open();
		}
    };

    function DetailView() {
        let dvFormat = [{ Name: 'Details', Controls: [{ Name: 'EmployeeNumber', Caption: 'Employee Number', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Details', ControlID: 'EmployeeNumber' },
        { Name: 'LastName', Caption: 'Last Name', Type: 'String',  ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'LastName' },
        { Name: 'FirstName', Caption: 'First Name', Type: 'String',  ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'FirstName' },
        { Name: 'MiddleName', Caption: 'Middle Name', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'MiddleName' },
        { Name: 'Suffix', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'Suffix' },
        { Name: 'NickName', Caption: 'Nick Name', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'NickName' },
        { Name: 'Birthdate', Caption: 'Birth Date', Type: 'DateTime', ControlType: 'datepicker',  ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'Birthdate', strFormat: 'mm/dd/yyyy' },
        { Name: 'Age', Type: 'Int', IsEnabled: false, ColumnNo: 0, TbName: 'Details', ControlID: 'Age', AllowInsert: false, AllowUpdate: false },
        { Name: 'BirthPlace', Caption: 'Birth Place', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Details', ControlID: 'BirthPlace' },
        { Name: 'Gender', Caption: 'Sex', Type: 'String',  ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Gender' },
        { Name: 'CivilStatus', Caption: 'Civil Status', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'CivilStatus' },
        { Name: 'Nationality', Caption: 'Nationality', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Nationality' },
        { Name: 'Religion', Caption: 'Religion', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Religion' },
        { Name: 'Height', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Height' },
        { Name: 'Weight', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Weight' },
        { Name: 'Bloodtype', Caption: 'Blood Type', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Bloodtype' },
        { Name: 'Allergies', Type: 'String', ControlType: 'textarea', ColumnNo: 2, IsEnabled: false, TbName: 'Details', ControlID: 'Allergies' }] },
		{ Name: 'Contact', Controls: [ { Name: 'PersonalEmailAddress', Caption: 'Primary Email', Type: 'String',  ColumnNo: 0, IsEnabled: false, TbName: 'Contact', ControlID: 'PersonalEmailAddress' },
        { Name: 'WorkEmailAddress', Caption: 'Secondary Email', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Contact', ControlID: 'WorkEmailAddress' },
        { Name: 'SocialMedia', Caption: 'Social Media', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Contact', ControlID: 'SocialMedia' },
        { Name: 'MobileNumber', Caption: 'Primary Mobile', Type: 'String',  ColumnNo: 2, IsEnabled: false, TbName: 'Contact', ControlID: 'MobileNumber', strFormat: '9999-999-9999' },
        { Name: 'MobileNumber2', Caption: 'Secondary Mobile', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Contact', ControlID: 'MobileNumber2', strFormat: '9999-999-9999' },
        { Name: 'TelephoneNumber', Caption: 'Telephone', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Contact', ControlID: 'TelephoneNumber', strFormat: '(999)999-9999' }]},
        { Name: 'Address', Controls: [{ Name: 'PresentRegion', Caption: 'Region', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Address', ControlID: 'PresentRegion' },
        { Name: 'PresentProvince', Caption: 'Province', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Address', ControlID: 'PresentProvince' },
        { Name: 'PresentCity', Caption: 'City', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Address', ControlID: 'PresentCity' },
        { Name: 'PresentBarangay', Caption: 'Barangay', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'Address', ControlID: 'PresentBarangay' },
        { Name: 'CurrentAddress', Caption: 'Address', Type: 'String',  ControlType: 'textarea', ColumnNo: 0, IsEnabled: false, TbName: 'Address', ControlID: 'CurrentAddress' },
        { Name: 'PermanentRegion', Caption: 'Region', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Address', ControlID: 'PermanentRegion' },
        { Name: 'PermanentProvince', Caption: 'Province', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Address', ControlID: 'PermanentProvince' },
        { Name: 'PermanentCity', Caption: 'City', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Address', ControlID: 'PermanentCity' },
        { Name: 'PermanentBarangay', Caption: 'Barangay', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'Address', ControlID: 'PermanentBarangay' },
        { Name: 'ProvinceAddress', Caption: 'Address', Type: 'String',  ControlType: 'textarea', ColumnNo: 2, IsEnabled: false, TbName: 'Address', ControlID: 'ProvinceAddress' }]},
		{ Name: 'ContactEmergency', Controls: [{ Name: 'EmergencyName1', Caption: 'Name', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyName1' },
        { Name: 'EmergencyAddress1', Caption: 'Address', Type: 'String',  ControlType: 'textarea', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyAddress1' },
        { Name: 'EmergencyContactNo1', Caption: 'Primary Contact No.', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyContactNo1' },
        { Name: 'EmergencySecondaryContact1', Caption: 'Secondary Contact No.', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencySecondaryContact1' },
        { Name: 'EmergencyEmail1', Caption: 'Email', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyEmail1' },
        { Name: 'EmergencyRelationship1', Caption: 'Relationship', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyRelationship1' },
        { Name: 'EmergencyName2', Caption: 'Name', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyName2' },
        { Name: 'EmergencyAddress2', Caption: 'Address', Type: 'String',  ControlType: 'textarea', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyAddress2' },
        { Name: 'EmergencyContactNo2', Caption: 'Primary Contact No.', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyContactNo2' },
        { Name: 'EmergencySecondaryContact2', Caption: 'Secondary Contact No.', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencySecondaryContact12' },
        { Name: 'EmergencyEmail2', Caption: 'Email', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyEmail2' },
        { Name: 'EmergencyRelationship2', Caption: 'Relationship 2', Type: 'String', ColumnNo: 2, IsEnabled: false, TbName: 'ContactEmergency', ControlID: 'EmergencyRelationship2' }]},
		{ Name: 'AffiliationNo', Controls: [{ Name: 'TinNumber', Caption: 'TIN', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'AffiliationNo', ControlID: 'TinNumber', strFormat: '999-999-999' },
        { Name: 'PhilHealthNumber', Caption: 'PHILHEALTH No.', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'AffiliationNo', ControlID: 'PhilHealthNumber', strFormat: '99-999999999-9' },
        { Name: 'SSSNumber', Caption: 'SSS No.', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'AffiliationNo', ControlID: 'SSSNumber', strFormat: '99-9999999-9' },
        { Name: 'PagibigNumber', Caption: 'PAGIBIG No.', Type: 'String', ColumnNo: 0, IsEnabled: false, TbName: 'AffiliationNo', ControlID: 'PagibigNumber', strFormat: '9999-9999-9999' }]},
        { Name: 'Other', Controls: [{ Name: 'CreatedDate', Caption: 'Created Date', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'CreatedDate' },
        { Name: 'ModifiedDate', Caption: 'Last Modified Date', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'ModifiedDate' },
        { Name: 'IsActive', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'IsActive' }]}]

        dvFormat.push({ Name: 'AuditChanges', Type: '10835', FKey: 'ID', FKeyValue: 'ID', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'AuditChanges' })
        dvFormat.push({ Name: 'HighestEducationAudit', Type: '10735', FKey: 'ID', FKeyValue: 'ID', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'HighestEducationAudit' })
        dvFormat.push({ Name: 'DependentsAudit', Type: '10935', FKey: 'ID', FKeyValue: 'ID', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'DependentsAudit' })
        
        this.OpenObject = function(CurrentObject) {  InitNewObject(CurrentObject,qcfutitm,self.mNm,self.mNo,self.fid,dvFormat); };
        this.InitDetailView = function(CurrentObject) {  InitDetailView(CurrentObject,self.mNm,self.mNo,self.fid,ObjectID,dvFormat); };       
    }

    $(function () {
        $('#btnList_' + self.fid).find('button').on('click', function () {
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch (ids.replace('Employee-', '').toUpperCase()) {
                case ('Approve_' + self.fid).toUpperCase():
                    Message = 'Apply Changes?';
                    OkLabel = 'Ok';
                    fAction = function (result) { infoaudit.Apply(); var URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_' + self.fid).load(URLView, function () { }); } 
                    break;
				case ('Return_' + self.fid).toUpperCase():
                    Message = 'Return to Employee?';
                    OkLabel = 'Ok';
                    fAction = function (result) { infoaudit.Return(); } 
                    break;
				case ('BACK_' + self.fid).toUpperCase():
                    Message = 'Back to List to List?';
                    OkLabel = 'Ok';
                    fAction = function (result) { var URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_' + self.fid).load(URLView, function () { }); }
                    break;
            }
			BootstrapDialog.show({
				title: 'Employee Information Update',
				icon: 'fa-circle-o',
				message: Message,
				closable: true,
				draggable: true,
				buttons: [{ id: 'btn-1', label: 'Cancel', cssClass: 'btn-warning', action: function (dialog) { dialog.close(); } },
							{ id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function (dialog) { var $button = this; $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
			});
        });

        let $itmaudit = new DetailView();
        $itmaudit.InitDetailView(infoaudit);

        $('#tab_' + self.fid + '>li>a').first().click();
    })   
}