"use strict";
function Employee(ObjectID) {
    const self = this;
    this.mguid = '';
    this.mNm = '';
    this.mNo = 0;
    this.mDesc = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    var PersonalInformation = { ID: null, EmployeeNumber: null, EmployeeRefNo: null, LastName: null, FirstName: null, MiddleName: null, Suffix: null
        , NickName: null, GenderRefNo: null, CivilStatusRefNo: 1, Birthdate: null, Age: null, BirthPlace: null
        , BloodtypeRefNo: null, Allergies: null, NationalityRefNo: 1, ReligionRefNo: 1, Height: null, Weight: null
        , WorkEmailAddress: null, TelephoneNumber: null, SocialMedia: null, MobileNumber: null
        , RegionRefNo: null,ProvinceRefNo: null, CityRefNo: null , BrgyRefNo: null, CurrentAddress: null
		, PermanentRegionRefNo: null,PermanentProvinceRefNo: null,PermanentCityRefNo: null,PermanentBrgyRefNo: null, ProvinceAddress: null
		, EmergencyName1: null, EmergencyAddress1: null, EmergencyContactNo1: null
        , EmergencyRelationship1: null, EmergencyName2: null, EmergencyAddress2: null, EmergencyContactNo2: null
        , EmergencyRelationship2: null, TinNumber: null, PhilHealthNumber: null
        , SSSNumber: null, PagibigNumber: null, CreatedBy: null
        , CreatedDate: null, ModifiedBy: null, ModifiedDate: null, IsActive: null, EmployeeDependents: [], EmployeeHighestEducation: [], OtherBenefits: [], OtherCost: []
        , EmployeeOffense: [], EmployeePerformance: [], EmployeeTraining: [], EmployeeAccountability: [], EmpHistory: [], KPI: []
        , IsDirty: false
        , Save: function (Grid) {
            $.ajax({
                url: '../DetailView/Save',
                data: { mName: self.mNm, JSONObject: JSON.stringify(PersonalInformation) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                beforeSend: function () { },
                success: function (data) {
                   Toast.Show("Employee information successfully saved.");
                },
                error: function (xhr, textStatus, error) { console.log(error); }
            });
        }
    };
    function PersonalInformationDetail() {
        const IsEnabled = true;
        let dvFormat = [{ Name: 'Details', Controls: [ { Name: 'EmployeeNumber', Caption: 'Employee Number', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Details', ControlID: 'EmployeeNumber' },
        { Name: 'LastName', Caption: 'Last Name', Type: 'String', IsRequired: true, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'LastName' },
        { Name: 'FirstName', Caption: 'First Name', Type: 'String', IsRequired: true, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'FirstName' },
        { Name: 'MiddleName', Caption: 'Middle Name', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'MiddleName' },
        { Name: 'Suffix', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'Suffix' },
        { Name: 'NickName', Caption: 'Nick Name', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'NickName' },
        { Name: 'GenderRefNo', Caption: 'Sex', Type: 'Int', ControlType: 'combobox', RefColumn: 'Gender', ControlModel: 'Gender', ColumnValue: 'ID', DisplayColumnValue: 'Description', IsRequired: true, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'GenderRefNo' },
        { Name: 'CivilStatusRefNo', Caption: 'Civil Status', Type: 'Int', ControlType: 'combobox', RefColumn: 'CivilStatus', ControlModel: 'CivilStatus', ColumnValue: 'ID', DisplayColumnValue: 'Description', IsRequired: true, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'CivilStatusRefNo' },
        { Name: 'Birthdate', Caption: 'Birth Date', Type: 'DateTime', ControlType: 'datepicker', IsRequired: true, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'Birthdate', strFormat: 'mm/dd/yyyy' },
        { Name: 'Age', Type: 'Int', IsEnabled: false, ColumnNo: 0, TbName: 'Details', ControlID: 'Age', AllowInsert: false, AllowUpdate: false },
        { Name: 'BirthPlace', Caption: 'Birth Place', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'BirthPlace' },
        { Name: 'NationalityRefNo', Caption: 'Nationality', Type: 'Int', ControlType: 'combobox', RefColumn: 'Nationality', ControlModel: 'Nationality', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'NationalityRefNo' },
        { Name: 'ReligionRefNo', Caption: 'Religion', Type: 'Int', ControlType: 'combobox', RefColumn: 'Religion', ControlModel: 'Religion', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'ReligionRefNo' },
        { Name: 'Height', Caption: 'Height(ft)', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'Height' },
        { Name: 'Weight', Caption: 'Weight(kg)', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'Weight' },
        { Name: 'BloodtypeRefNo', Caption: 'Blood Type', Type: 'Int', ControlType: 'combobox', RefColumn: 'BloodType', ControlModel: 'BloodType', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'BloodtypeRefNo' },
        { Name: 'Allergies', Type: 'String', ControlType: 'textarea', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Details', ControlID: 'Allergies' }] },
		{ Name: 'Contact', Controls: [ { Name: 'PersonalEmailAddress', Caption: 'Primary Email', Type: 'String', IsRequired: true, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'PersonalEmailAddress' },
        { Name: 'WorkEmailAddress', Caption: 'Secondary Email', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'WorkEmailAddress' },
        { Name: 'SocialMedia', Caption: 'Social Media', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'SocialMedia' },
        { Name: 'PrimaryMobileNumber', Caption: 'Primary Mobile', Type: 'String', IsRequired: true, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'PrimaryMobileNumber', strFormat: '9999-999-9999' },
        { Name: 'SecondaryMobileNumber', Caption: 'Secondary Mobile', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'SecondaryMobileNumber', strFormat: '9999-999-9999' },
        { Name: 'LandLineNumber', Caption: 'Telephone', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Contact', ControlID: 'LandLineNumber', strFormat: '(999)999-9999' }]},
        { Name: 'Address', Controls: [{ Name: 'RegionRefNo', Caption: 'Region', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'RegionRefNo', ControlModel: 'Region', ColumnValue: 'RegionRefNo', DisplayColumnValue: 'Description', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'RegionRefNo' },
		{ Name: 'ProvinceRefNo', Caption: 'Province', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'ProvinceRefNo', ControlModel: 'Province', ColumnValue: 'ProvinceRefNo', DisplayColumnValue: 'Description',FKName: 'RegionRefNo', FKValue: PersonalInformation.RegionRefNo, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'ProvinceRefNo' },
		{ Name: 'MunicipalityRefNo', Caption: 'City / Municipality', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'City', ControlModel: 'City', ColumnValue: 'ID', DisplayColumnValue: 'Description',FKName: 'ProvinceRefNo', FKValue:PersonalInformation.ProvinceRefNo, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'MunicipalityRefNo' },
		{ Name: 'BrgyRefNo', Caption: 'Barangay', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'City', ControlModel: 'Barangay', ColumnValue: 'ID', DisplayColumnValue: 'Description',FKName: 'CityRefNo', FKValue: PersonalInformation.CityRefNo, ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'BrgyRefNo' },
		{ Name: 'PresentAddress', Caption: 'Lot & Block No / Room No / House No / Subvision / Street Name', Type: 'String', IsRequired: true, ControlType: 'textarea', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PresentAddress' },
		{ Name: 'PermanentRegionRefNo', Caption: 'Region', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'PermanentRegionRefNo', ControlModel: 'Region', ColumnValue: 'RegionRefNo', DisplayColumnValue: 'Description', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PermanentRegionRefNo' },
		{ Name: 'PermanentProvinceRefNo', Caption: 'Province', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'ProvinceRefNo', ControlModel: 'Province', ColumnValue: 'ProvinceRefNo', DisplayColumnValue: 'Description',FKName: 'RegionRefNo', FKValue: PersonalInformation.PermanentRegionRefNo, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PermanentProvinceRefNo' },
		{ Name: 'PermanentMunicipalityRefNo', Caption: 'Permanent City Address', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'City', ControlModel: 'City', ColumnValue: 'ID', DisplayColumnValue: 'Description',FKName: 'ProvinceRefNo', FKValue: PersonalInformation.PermanentProvinceRefNo, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PermanentMunicipalityRefNo' },
		{ Name: 'PermanentBrgyRefNo', Caption: 'Barangay', Type: 'Int', IsRequired: true, ControlType: 'combobox', RefColumn: 'Barangay', ControlModel: 'Barangay', ColumnValue: 'ID', DisplayColumnValue: 'Description',FKName: 'CityRefNo', FKValue: PersonalInformation.PermanentCityRefNo, ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PermanentBrgyRefNo' },
		{ Name: 'PermanentAddress', Caption: 'Lot & Block No / Room No / House No / Subvision / Street Name', Type: 'String', IsRequired: true, ControlType: 'textarea', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'Address', ControlID: 'PermanentAddress' }]},
		{ Name: 'ContactEmergency', Controls: [{ Name: 'EmergencyName1', Caption: 'Name', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyName1' },
        { Name: 'EmergencyRelationship1', Caption: 'Relationship', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyRelationship1' },
        { Name: 'EmergencyContactNo1', Caption: 'Primary Contact No.', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyContactNo1', strFormat: '9999-999-9999' },
        { Name: 'EmergencySecondaryContact1', Caption: 'Secondary Contact No.', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencySecondaryContact1', strFormat: '9999-999-9999' },
        { Name: 'EmergencyEmail1', Caption: 'Email', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyEmail1' },
        { Name: 'EmergencyAddress1', Caption: 'Address', Type: 'String', ControlType: 'textarea', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyAddress1' },
        { Name: 'EmergencyName2', Caption: 'Name', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyName2' },
        { Name: 'EmergencyRelationship2', Caption: 'Relationship', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyRelationship2' },
        { Name: 'EmergencyContactNo2', Caption: 'Primary Contact No.', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyContactNo2', strFormat: '9999-999-9999' },
        { Name: 'EmergencySecondaryContact2', Caption: 'Secondary Contact No.', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencySecondaryContact2', strFormat: '9999-999-9999' },
        { Name: 'EmergencyEmail2', Caption: 'Email', Type: 'String', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyEmail2' },
        { Name: 'EmergencyAddress2', Caption: 'Address', Type: 'String', ControlType: 'textarea', ColumnNo: 2, IsEnabled: IsEnabled , TbName: 'ContactEmergency', ControlID: 'EmergencyAddress2' }]},
		{ Name: 'AffiliationNo', Controls: [{ Name: 'TinNumber', Caption: 'TIN', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'AffiliationNo', ControlID: 'TinNumber', strFormat: '999-999-999' },
        { Name: 'PhilHealthNumber', Caption: 'PHILHEALTH No.', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'AffiliationNo', ControlID: 'PhilHealthNumber', strFormat: '99-999999999-9' },
        { Name: 'SSSNumber', Caption: 'SSS No.', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'AffiliationNo', ControlID: 'SSSNumber', strFormat: '99-9999999-9' },
        { Name: 'PagibigNumber', Caption: 'PAGIBIG No.', Type: 'String', ColumnNo: 0, IsEnabled: IsEnabled , TbName: 'AffiliationNo', ControlID: 'PagibigNumber', strFormat: '9999-9999-9999' }]},
        { Name: 'Other', Controls: [{ Name: 'CreatedBy', Caption: 'Created By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Created By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Other', ControlID: 'CreatedBy' },
        { Name: 'CreatedDate', Caption: 'Created Date', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'CreatedDate' },
        { Name: 'ModifiedBy', Caption: 'Last Modified By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Last Modified By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Other', ControlID: 'ModifiedBy' },
        { Name: 'ModifiedDate', Caption: 'Last Modified Date', Type: 'String', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'ModifiedDate' },
        { Name: 'IsActive', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: false, ColumnNo: 0, TbName: 'Other', ControlID: 'IsActive' }]}];

        dvFormat.push({ Name: 'Dependents', Type: '10230', FKey: 'EmployeeRefNo', FKeyValue: 'EmployeeRefNo', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'Dependents' });
 
        this.OpenObject = function(CurrentObject) {  InitNewObject(CurrentObject,PersonalInformation,self.mNm,self.mNo,self.fid,dvFormat); };
        this.InitDetailView = function(CurrentObject) {  InitDetailView(CurrentObject,self.mNm,self.mNo,self.fid,ObjectID,dvFormat); };       
    }

    $(function () {
        $('#Save_' + self.fid).off('click').on('click', function() {
            let Message = 'Save changes?';
            let OkLabel = 'Save';
            let fAction = function(result) { 
                if(ControlValidation(PersonalInformation,self.mNm,self.fid) === true){
                    if(ControlValidationUnique(PersonalInformation,self.mNm,self.fid) === true) { PersonalInformation.Save(); }
                }
            };
            BootstrapDialog.show({
                title: self.mDesc , message: Message, closable: true, draggable: true,
                buttons: [{ id: 'btn-1', label: 'Cancel' , cssClass: 'btn-warning', action: function(dialog) { dialog.close(); } },
                            { id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function(dialog) { let $button = this;  $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
            });
        });

        let $dtlview = new PersonalInformationDetail();
        $dtlview.InitDetailView(PersonalInformation);

        $("#Survey").off("select2:select","#ciregion").on("select2:select","#ciregion",function(){
            $scope.DHS.RegionRefNo = $('#ciregion').select2().val();
            InitDropdownChild('Province', '#ciprovince', 0 , "RegionRefNo" , $scope.DHS.RegionRefNo);
            if($scope.DHS.CityRefNo > 0) { $scope.DHS.CityRefNo = 0; InitDropdownChild('City', '#cicity', 0 , "ProvinceRefNo" , 0); $('#cicity').val("0").trigger("change"); }
            if($scope.DHS.BarangayRefNo > 0) { $scope.DHS.BarangayRefNo = 0; InitDropdownChild('Barangay', '#cibarangay', 0 , "CityRefNo" ,0); $('#cibarangay').val("0").trigger("change"); }
        });

        $("#Survey").off("select2:select","#ciprovince").on("select2:select","#ciprovince",function(){
            $scope.DHS.ProvinceRefNo = $('#ciprovince').select2().val();
            InitDropdownChild('City', '#cicity', 0 , "ProvinceRefNo" , $scope.DHS.ProvinceRefNo);
            if($scope.DHS.BarangayRefNo > 0) { $scope.DHS.BarangayRefNo = 0; InitDropdownChild('Barangay', '#cibarangay', 0 , "CityRefNo" ,0); $('#cibarangay').val("0").trigger("change"); }
        });

        $("#Survey").off("select2:select","#cicity").on("select2:select","#cicity",function(){
            $scope.DHS.CityRefNo = $('#cicity').select2().val();
            InitDropdownChild('Barangay', '#cibarangay', 0 , "CityRefNo" , $scope.DHS.CityRefNo);
        });

        $("#Survey").off("select2:select","#cibarangay").on("select2:select","#cibarangay",function(){
            $scope.DHS.BrgyRefNo = $('#cibarangay').select2().val();
            if($('#cibarangay').select2().val() === "0") { $('#cibarangay').val("0").trigger("change");}
        });
    });   
}