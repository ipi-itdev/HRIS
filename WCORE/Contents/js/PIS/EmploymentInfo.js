"use strict";
function EmploymentInfo(ObjectID) {
    const self = this;
    this.mguid = '';
    this.mNm = '';
    this.mNo = 0;
    this.mDesc = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    var EmploymentInformation = { ID: null, EmployeeRefNo: null, EmployeeNumber: null, EmployeeGroupRefNo: 2, ClientAccountRefNo: null, FOWRefNo: 1,
        EmployeeStatusRefNo: 1, EmployeeTypeRefNo: 5, EmploymentStatusRefNo: 1, JobPosition: null, Skills: null, StartDate: null, EndDate: null,
        DateHired: null, ContractualDate: null, DateProbationary: null, DateRegularized: null, LastDateOfEmployment: null,
        ReasonForSeperationRefNo: null, ReasonForSeparation: null, IsWithClearance:0 , IsForReHire:0, WorkSchedule: null, PayrollParameterRefNo: 7,
        PayrollRateRefNo: 2, PayFrequencyRefNo: 1, PayBasisRefNo: 2, TaxStatusRefNo: 1, EcolaComputationRefNo: null,
        EcolaRateRefNo: null, BasicRate: 0, ClientRate: 0, HDMFAddCont: 0, BankRefNo: 3, AccountNo: null, SEPTag: null,
        W13thMonth: 1, HOLTag: 1, TaxTag: 1, PagibigPercent: 0, SIL: 0, AddtlPaidLeaves: 0 , APLProRata: false,
        HMOAmount: 0, HMODC: 0, OTAssumption: 0, FieldofWork: null, JobDescription: null,  CreatedBy: 1, CreatedDate: null,
        ModifiedBy: null, ModifiedDate: null, IsActive: 1 , ProjectName: null , JobDescriptionPath: null , sclause: null
        , IsDirty: false
        , Save: function (Grid) {
            $.ajax({
                url: '../DetailView/Save',
                data: { mName: self.mNm, JSONObject: JSON.stringify(EmploymentInformation) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                success: function (data) {
                    Toast.Show("Employment information successfully saved.");
                }
            });
        }
    };
    function EmploymentInformationDetail() {
        const IsEnabled = true;
        let dvFormat = [{ Name: 'Details', Controls: [{ Name: 'ID', Type: 'Int', IsEnabled: false, ColumnNo: 0,  TbName: 'Details', ControlID: 'ID' }] },
			{ Name: 'Employment', Controls: [{ Name: 'FOWRefNo', Caption: 'Field of Work', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'FW', ControlModel: 'FOW', ColumnValue: 'FOWRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Employment', ControlID: 'FOWRefNo' },
            { Name: 'EmployeeTypeRefNo', Caption: 'Rank Level', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'ET', ControlModel: 'EmployeeType', ColumnValue: 'EmployeeTypeRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Employment', ControlID: 'EmployeeTypeRefNo' },
            { Name: 'EmploymentStatusRefNo', Caption: 'Employment Status', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'ESM', ControlModel: 'EmploymentStatus', ColumnValue: 'EmploymentStatusRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Employment', ControlID: 'EmploymentStatusRefNo' },
            { Name: 'ClientAccountRefNo', Caption: 'Client', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'Client', ControlModel: 'ClientAccount', ColumnValue: 'ClientAccountRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Employment', ControlID: 'ClientAccountRefNo' },
            { Name: 'ClientAddress', Caption: 'Client Address', Type: 'String', ControlType: 'textarea', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 0,  TbName: 'Employment', ControlID: 'ClientAddress' },
            { Name: 'JobPosition', Caption: 'Job Position', Type: 'String', ControlType: 'textarea', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 0,  TbName: 'Employment', ControlID: 'JobPosition' },
            { Name: 'DateHired', Caption: 'Date Hired', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'DateHired', strFormat: 'mm/dd/yyyy' },
            { Name: 'StartDate', Caption: 'Start Date', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'StartDate', strFormat: 'mm/dd/yyyy' },
            { Name: 'EndDate', Caption: 'End Date', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'EndDate', strFormat: 'mm/dd/yyyy' },
            { Name: 'ContractualDate', Caption: 'Contractual Date', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'ContractualDate', strFormat: 'mm/dd/yyyy' },
            { Name: 'DateProbationary', Caption: 'Prob. Start Date', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'DateProbationary', strFormat: 'mm/dd/yyyy' },
            { Name: 'DateRegularized', Caption: 'Date Regularized', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'DateRegularized', strFormat: 'mm/dd/yyyy' },
            { Name: 'Skills', Caption: 'Technical Skills', Type: 'String', ControlType: 'textarea', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Employment', ControlID: 'Skills' }]},
            { Name: 'SeparationInformation', Controls: [{ Name: 'LastDateOfEmployment', Caption: 'Last Day of Employment', Type: 'DateTime', ControlType: 'datepicker', IsEnabled: true, ColumnNo: 0,  TbName: 'Separation Information', ControlID: 'LastDateOfEmployment', strFormat: 'mm/dd/yyyy' },
            { Name: 'ReasonForSeperationRefNo', Caption: 'Reason Separation', Type: 'Int', ControlType: 'combobox', IsEnabled: true, RefColumn: 'RF', ControlModel: 'ReasonForSeperation', ColumnValue: 'ReasonForSeperationRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Separation Information', ControlID: 'ReasonForSeperationRefNo' },
            { Name: 'ReasonForSeparation', Caption: 'Other Reason', Type: 'String', ControlType: 'textarea', ColumnNo: 2,  TbName: 'Separation Information', ControlID: 'ReasonForSeparation' },
            { Name: 'IsWithClearance', Caption: 'Is With Clearance?', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: IsEnabled, ColumnNo: 0,  TbName: 'Separation Information', ControlID: 'IsWithClearance' },
            { Name: 'IsForReHire', Caption: 'Is For Re-Hire?', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Separation Information', ControlID: 'IsForReHire' }]},
            { Name: 'Payroll', Controls:[{ Name: 'WorkSchedule', Caption: 'Work Schedule', Type: 'String', IsEnabled: IsEnabled, IsRequired: false, ColumnNo: 0,  TbName: 'Payroll', ControlID: 'WorkSchedule' },
            { Name: 'PayrollParameterRefNo', Caption: 'Payroll Parameter', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'PM', ControlModel: 'PayrollParameter', ColumnValue: 'PayrollParameterRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Payroll', ControlID: 'PayrollParameterRefNo' },
            { Name: 'PayrollRateRefNo', Caption: 'Payroll Rate', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'PR', ControlModel: 'PayrollRate', ColumnValue: 'PayrollRateRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Payroll', ControlID: 'PayrollRateRefNo' },
            { Name: 'PayFrequencyRefNo', Caption: 'Frequency', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'FR', ControlModel: 'Frequency', ColumnValue: 'PayFrequencyRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Payroll', ControlID: 'PayFrequencyRefNo' },
            { Name: 'PayBasisRefNo', Caption: 'Pay Basis', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'PB', ControlModel: 'PayBasis', ColumnValue: 'PayBasisRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Payroll', ControlID: 'PayBasisRefNo' },
            { Name: 'BasicRate', Caption: 'Basic Rate', Type: 'Decimal', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 2,  TbName: 'Payroll', ControlID: 'BasicRate' },
            { Name: 'ClientRate', Caption: 'Client Rate', Type: 'Decimal', IsEnabled: IsEnabled, IsRequired: IsEnabled, ColumnNo: 2,  TbName: 'Payroll', ControlID: 'ClientRate' },
            { Name: 'TaxStatusRefNo', Caption: 'Tax Status', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, IsRequired: IsEnabled, RefColumn: 'TS', ControlModel: 'TaxStatus', ColumnValue: 'TaxStatusRefNo', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Payroll', ControlID: 'TaxStatusRefNo' },
            { Name: 'EcolaComputationRefNo', Caption: 'Ecola Computation', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, RefColumn: 'ECOM', ControlModel: 'ECOLAComputation', ColumnValue: 'EcolaComputationRefNo', DisplayColumnValue: 'Description', ColumnNo: 2,  TbName: 'Payroll', ControlID: 'EcolaComputationRefNo' },
            { Name: 'EcolaRateRefNo', Caption: 'ECOLA Rate', Type: 'Int', ControlType: 'combobox', IsEnabled: IsEnabled, RefColumn: 'ER', ControlModel: 'EcolaRate', ColumnValue: 'EcolaRateRefNo', DisplayColumnValue: 'Description', ColumnNo: 2,  TbName: 'Payroll', ControlID: 'EcolaRateRefNo' },
            { Name: 'HDMFAddCont', Caption: 'HDMF Personal Contribution', Type: 'Decimal', IsEnabled: IsEnabled, ColumnNo: 2,  TbName: 'Payroll', ControlID: 'HDMFAddCont' },
            { Name: 'BankRefNo', Caption: 'Bank', Type: 'Int', ControlType: 'combobox', IsRequired: IsEnabled, RefColumn: 'BNK', ControlModel: 'Bank', ColumnValue: 'BankRefNo', DisplayColumnValue: 'Description', ColumnNo: 2,  TbName: 'Payroll', ControlID: 'BankRefNo' },
            { Name: 'AccountNo', Caption: 'Account', Type: 'String', ColumnNo: 2,  TbName: 'Payroll', ControlID: 'AccountNo' }]},
			{ Name: 'Benefits2', Controls: [{ Name: 'SIL' ,Caption: 'Service Incentive Leave', Type: 'Decimal', IsEnabled: IsEnabled, ColumnNo: 0,  TbName: 'Benefits3', ControlID: 'SIL' },
			{ Name: 'AddtlPaidLeaves',Caption: 'Addtl Paid Leaves', Type: 'Decimal', ColumnNo: 0, TbName: 'Benefits2', ControlID: 'AddtlPaidLeaves' },
			{ Name: 'APLProRata',Caption: 'Pro-Rata?', Type: 'Boolean', ControlType: 'checkbox', ColumnNo: 0, TbName: 'Benefits2', ControlID: 'APLProRata' }]},
            { Name: 'Benefits3', Controls:[ { Name: 'HMODC', Caption: 'HMO DC(Annual)', Type: 'Decimal', IsEnabled: IsEnabled, ColumnNo: 0,  TbName: 'Benefits3', ControlID: 'HMODC' },
            { Name: 'HMOAmount', Caption: 'HMO Coverage(Annual)', Type: 'Decimal', IsEnabled: IsEnabled, ColumnNo: 0,  TbName: 'Benefits3', ControlID: 'HMOAmount' },
            { Name: 'OTAssumption', Caption: 'OT Assumption%', Type: 'Decimal', IsEnabled: IsEnabled, ColumnNo: 0,  TbName: 'Benefits3', ControlID: 'OTAssumption' }]},
            { Name: 'HealthCard', Controls: [{ Name: 'MalayanCoverageRefNo', Caption: 'Group Life Coverage', Type: 'Int', ControlType: 'combobox', RefColumn: 'GI', ControlModel: 'GroupInsurance', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Affiliation No', ControlID: 'MalayanCoverageRefNo' },
			{ Name: 'MaxicareRefNo', Caption: 'Maxicare Coverage', Type: 'Int', ControlType: 'combobox', RefColumn: 'MC', ControlModel: 'MaxicareCoverage', ColumnValue: 'MalayanCoverageRefNo', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Affiliation No', ControlID: 'MaxicareRefNo' },
			{ Name: 'MaxicareCardNo', Caption: 'Maxicare Card No.', Type: 'String', ColumnNo: 0, TbName: 'Affiliation No', ControlID: 'MaxicareCardNo' }]},
			{ Name: 'Other', Controls: [{ Name: 'CreatedBy', Caption: 'Created By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Created By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Other', ControlID: 'CreatedBy' },
            { Name: 'CreatedDate', Caption: 'Created Date', Type: 'String', IsEnabled: false, ColumnNo: 0,  TbName: 'Other', ControlID: 'CreatedDate' },
            { Name: 'ModifiedBy', Caption: 'Last Modified By', Type: 'Int', ControlType: 'combobox', IsEnabled: false, RefColumn: '[Last Modified By]', ControlModel: 'User', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0,  TbName: 'Other', ControlID: 'ModifiedBy' },
            { Name: 'ModifiedDate', Caption: 'Last Modified Date', Type: 'String', IsEnabled: false, ColumnNo: 0,  TbName: 'Other', ControlID: 'ModifiedDate' },
            { Name: 'IsActive', Type: 'Boolean', ControlType: 'checkbox', IsEnabled: false, ColumnNo: 0,  TbName: 'Other', ControlID: 'IsActive' }]},
            { Name: 'ProjectName', Controls: [{ Name: 'ProjectName', Caption: 'Project Name', Type: 'String',  ColumnNo: 0,  TbName: 'ProjectName', ControlID: 'ProjectName' },
            { Name: 'JobDescriptionPath', Caption: 'Job Description Path', Type: 'String', ControlType: 'fileupload', IsEnabled: false,  ColumnNo: 0,  TbName: 'ProjectName', ControlID: 'JobDescriptionPath' }]},
            { Name: 'JobDescription', Controls: [{ Name: 'JobDescription', Type: 'String', ControlType: 'texteditor', ColumnNo: 0,  TbName: 'JobDescription', ControlID: 'JobDescription' }], IsTextEditor: true }, 
			{ Name: 'Clause', Controls: [{ Name: 'sclause',  Type: 'String', ControlType: 'texteditor',  ColumnNo: 0,  TbName: 'Clause', ControlID: 'sclause' }], IsTextEditor: true }];
        
        dvFormat.push({ Name: 'OtherBenefits', Type: '10220', FKey: 'EmployeeRefNo', FKeyValue: 'EmployeeRefNo', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'OtherBenefits' })
        dvFormat.push({ Name: 'OtherCost', Type: '10225', FKey: 'EmployeeRefNo', FKeyValue: 'EmployeeRefNo', HasNew: true, HasRemove: true, IsListView: true, PropertyName: 'OtherCost' })

        this.OpenObject = function(CurrentObject) {  InitNewObject(CurrentObject,EmploymentInformation,self.mNm,self.mNo,self.fid,dvFormat); };
        this.InitDetailView = function(CurrentObject) {  InitDetailView(CurrentObject,self.mNm,self.mNo,self.fid,ObjectID,dvFormat); };       
    }

    $(function () {
        $('#btnList_' + self.fid).find('button').on('click', function() {
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch (ids.replace('_' + self.fid,'').toUpperCase()) {
                 case 'SAVE':
                    Message = 'Save changes?';
                    OkLabel = 'Save';
                    fAction = function(result) { 
                        if(ControlValidation(EmploymentInformation,self.mNm,self.fid) === true){
                            if(ControlValidationUnique(EmploymentInformation,self.mNm,self.fid) === true) { EmploymentInformation.Save(); }
                        }
                    };
                    break;
                 default:
                    Message = 'Are you sure you want to go back to list?';
                    OkLabel = 'Yes';
                    fAction = function(result) {  var URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); };
                    break;
            }
            if(ids.toUpperCase() !== 'dropdownMenuButton'.toUpperCase()){
                BootstrapDialog.show({
                    title: self.mDesc , message: Message, closable: true, draggable: true,
                    buttons: [{ id: 'btn-1', label: 'Cancel' , cssClass: 'btn-warning', action: function(dialog) { dialog.close(); } },
                              { id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function(dialog) { var $button = this;  $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
                });
            }
        });

        let $dtlview = new EmploymentInformationDetail();
        $dtlview.InitDetailView(EmploymentInformation);
    });   
}