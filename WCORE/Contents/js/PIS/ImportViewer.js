"use strict";
function ImportViewer(ObjectID) {
     let self = this;
     self.mguid = '';
     self.mNo = 0;
     let APIUrl = "http:\/\/aaigcat-001-site9.htempurl.com";
     $.ajax({
		type: "GET",
		url: APIUrl + '/api/cronus/details?pkey=' + ObjectID,
		contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
		success: function (data) {
			$('#RFC_ImportEmployee').val(data[0].ContractOrderID);
			$('#LastName_ImportEmployee').val(data[0].LastName);
			$('#FirstName_ImportEmployee').val(data[0].FirstName);
			$('#MiddleName_ImportEmployee').val(data[0].MiddleName);
			$('#Suffix_ImportEmployee').val(data[0].SuffixName);
			$('#NickName_ImportEmployee').val(data[0].NickName);
			$('#Birthdate_ImportEmployee').val(data[0].BirthDate);
			$('#Age_ImportEmployee').val(data[0].Age);
			$('#BirthPlace_ImportEmployee').val(data[0].BirthPlace);

			$('#Gender_ImportEmployee').val(data[0].Gender);
			$('#CivilStatus_ImportEmployee').val(data[0].CivilStatus);
			$('#Nationality_ImportEmployee').val(data[0].Nationality);
			$('#Religion_ImportEmployee').val(data[0].Religion);
			$('#Height_ImportEmployee').val(data[0].MyHeight);
			$('#Weight_ImportEmployee').val(data[0].MyWeight);
			$('#Bloodtype_ImportEmployee').val(data[0].BloodType);
			$('#Allergies_ImportEmployee').val(data[0].Allergies);

			$('#PersonalEmailAddress_ImportEmployee').val(data[0].PrimaryEmailAddress);
			$('#WorkEmailAddress_ImportEmployee').val(data[0].SecondaryEmailAddress);
			$('#SocialMedia_ImportEmployee').val(data[0].SocialMedia);
			$('#MobileNumber_ImportEmployee').val(data[0].PrimaryMobileNumber);
			$('#MobileNumber2_ImportEmployee').val(data[0].SecondaryMobileNumber);
			$('#TelephoneNumber_ImportEmployee').val(data[0].LandLineNumber);

			$('#PresentRegion_ImportEmployee').val(data[0].PresentRegion);
			$('#PresentProvince_ImportEmployee').val(data[0].PresentProvince);
			$('#PresentCity_ImportEmployee').val(data[0].PresentCity);
			$('#PresentBarangay_ImportEmployee').val(data[0].PresentBarangay);
			$('#CurrentAddress_ImportEmployee').val(data[0].PresentAddress);

			$('#PermanentRegion_ImportEmployee').val(data[0].PermanentRegion);
			$('#PermanentProvince_ImportEmployee').val(data[0].PermanentProvince);
			$('#PermanentCity_ImportEmployee').val(data[0].PermanentCity);
			$('#PermanentBarangay_ImportEmployee').val(data[0].PermanentBarangay);
			$('#ProvinceAddress_ImportEmployee').val(data[0].PermanentAddress);

			$('#EmergencyName1_ImportEmployee').val(data[0].EmergencyName1);
			$('#EmergencyAddress1_ImportEmployee').val(data[0].EmergencyAddress1);
			$('#EmergencyContactNo1_ImportEmployee').val(data[0].EmergencyContactNo1);
			$('#EmergencySecondaryContact1_ImportEmployee').val(data[0].EmergencySecondaryContactNo1);
			$('#EmergencyEmail1_ImportEmployee').val(data[0].EmergencyEmail1);
			$('#EmergencyRelationship1_ImportEmployee').val(data[0].EmergencyRelationship1);

			$('#EmergencyName2_ImportEmployee').val(data[0].EmergencyName2);
			$('#EmergencyAddress2_ImportEmployee').val(data[0].EmergencyAddress2);
			$('#EmergencyContactNo2_ImportEmployee').val(data[0].EmergencyContactNo2);
			$('#EmergencySecondaryContact2_ImportEmployee').val(data[0].EmergencySecondaryContactNo2);
			$('#EmergencyEmail2_ImportEmployee').val(data[0].EmergencyEmail2);
			$('#EmergencyRelationship2_ImportEmployee').val(data[0].EmergencyRelationship2);

			$('#FieldofWork_ImportEmployee').val(data[0].FieldofWork);
			$('#RankLevel_ImportEmployee').val(data[0].RankLevel);
			$('#EmploymentStatus_ImportEmployee').val(data[0].EmploymentStatus);
			$('#Client_ImportEmployee').val(data[0].Client);
			$('#ClientAddress_ImportEmployee').val(data[0].ClientAddress);
			$('#JobPosition_ImportEmployee').val(data[0].JobPosition);

			$('#DateHired_ImportEmployee').val(data[0].StartDate);
			$('#StartDate_ImportEmployee').val(data[0].StartDate);
			$('#EndDate_ImportEmployee').val(data[0].EndDate);
			$('#ContractualDate_ImportEmployee').val(data[0].ContractualDate);
			$('#ProbStartDate_ImportEmployee').val(data[0].ProbStartDate);
			$('#DateRegularized_ImportEmployee').val(data[0].DateRegularized);
			$('#TechnicalSkills_ImportEmployee').val(data[0].TechnicalSkills);

			$('#ProjectName_ImportEmployee').val(data[0].ProjectName);
			$('#JobDescriptionPath_ImportEmployee').val(data[0].JobDescriptionPath);
			$('#JobDescription_ImportEmployee').val(data[0].JobDescription);

			$('#WorkSchedule_ImportEmployee').val(data[0].WorkSchedule);
			$('#PayrollParameter_ImportEmployee').val(data[0].PayrollParameter);
			$('#Frequency_ImportEmployee').val(data[0].Frequency);

			$('#BasicRate_ImportEmployee').val(data[0].BasicRate);
			$('#ClientRate_ImportEmployee').val(data[0].ClientRate);
			$('#EcolaComputation_ImportEmployee').val(data[0].EcolaComputation);
			$('#EcolaRate_ImportEmployee').val(data[0].EcolaRate);
			$('#TaxStatus_ImportEmployee').val(data[0].TaxStatus);

			$('#Holiday_ImportEmployee').val(data[0].Holiday);
			$('#Tax_ImportEmployee').val(data[0].Tax);
			$('#SeparationPay_ImportEmployee').val(data[0].SeparationPay);
			$('#ThirteenthMonth_ImportEmployee').val(data[0].ThirteenthMonth);

			$('#SIL_ImportEmployee').val(data[0].SIL);
			$('#AddtlPaidLeaves_ImportEmployee').val(data[0].AddtlPaidLeaves);
			$('#Prorated_ImportEmployee').val(data[0].Prorated);

			$('#TinNumber_ImportEmployee').val(data[0].TinNumber);
			$('#PhilHealthNumber_ImportEmployee').val(data[0].PhilHealthNumber);
			$('#SSSNumber_ImportEmployee').val(data[0].SSSNumber);
			$('#PagibigNumber_ImportEmployee').val(data[0].PagibigNumber);
		}
	});
	
	$("#OtherBenefits").DataTable({
        ajax: {
			type: "GET",
			url: APIUrl + '/api/cronus/benefits?pkey=' + ObjectID,
			contentType: 'application/json; charset=utf-8',
			datatype: 'json',
			headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
			dataSrc: function (data) { return JSON.parse(data); },
		}
    });

	$("#OtherCost").DataTable({
        ajax: {
			type: "GET",
			url: APIUrl + '/api/cronus/cost?pkey=' + ObjectID,
			contentType: 'application/json; charset=utf-8',
			datatype: 'json',
			headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
			dataSrc: function (data) { return JSON.parse(data); },
		}
    });
	
    $("#tblListDependentsAudit").DataTable({
        ajax: {
			type: "GET",
			url: APIUrl + '/api/cronus/dependents?pkey=' + ObjectID,
			contentType: 'application/json; charset=utf-8',
			datatype: 'json',
			headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
			dataSrc: function (data) { return JSON.parse(data); },
		}
    });

	$("#tblListHighestEducation").DataTable({
        ajax: {
			type: "GET",
			url: APIUrl + '/api/cronus/education?pkey=' + ObjectID,
			contentType: 'application/json; charset=utf-8',
			datatype: 'json',
			headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
			dataSrc: function (data) { return JSON.parse(data); },
		}
    });

	$("#tblListPreEmploymentRequirements").DataTable({
        ajax: {
			type: "GET",
			url: APIUrl + '/api/cronus/preemprequirements?pkey=' + ObjectID,
			contentType: 'application/json; charset=utf-8',
			datatype: 'json',
			headers: {"x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3"},
			dataSrc: function (data) { return JSON.parse(data); },
		}
    });

	$('#tab_ImportEmployee>li>a').first().click();
	$('.content-wrapper').waitMe('hide');

    CKEDITOR.replace('JobDescription_ImportEmployee', {
        toolbar: [
            { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
            { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', '-', 'Undo', 'Redo'] },
            { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
            { name: 'paragraph', groups: ['list', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
            { name: 'tools', items: ['Maximize', 'ShowBlocks'] }]
    });

    CKEDITOR.replace('AdditionalClause_ImportEmployee', {
        toolbar: [
            { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
            { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', '-', 'Undo', 'Redo'] },
            { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
            { name: 'paragraph', groups: ['list', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
            { name: 'tools', items: ['Maximize', 'ShowBlocks'] }]
    });

    $(function () {
        $('#btnList_ImportEmployee').find('button').on('click', function() {
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch (ids.replace('_ImportEmployee','').toUpperCase()) {
                 case 'IMPORT':
                    Message = 'Import Employee?';
                    OkLabel = 'Import';
                    fAction = function(result) { 
                        $.ajax({
                            type: "POST",
                            cache: false,
                            url: APIUrl + '/api/cronus/import?pkey=' + ObjectID + '&uid=1',
                            success: function (data) {
                                console.log(data);
                            }
                        });
                    };
                    break;
                 case 'RESEND':
                    Message = 'Re-send link to employee?';
                    OkLabel = 'Re-send';
                    fAction = function(result) { 
                        $.ajax({
                            type: "POST",
                            cache: false,
                            url: APIUrl + '/api/cronus/resendlink?pkey=' + ObjectID + '&uid=1',
                            success: function (data) {
                                console.log(data);
                            }
                        });
                    };
                    break;
                 default:
                    Message = 'Are you sure you want to go back to list?';
                    OkLabel = 'Yes';
                    fAction = function(result) {  var URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); };
                    break;
            }
            BootstrapDialog.show({
                title: 'Import Empolyee' , message: Message, closable: true, draggable: true,
                buttons: [{ id: 'btn-1', label: 'Cancel' , cssClass: 'btn-warning', action: function(dialog) { dialog.close(); } },
                            { id: 'btn-2', label: 'Ok', cssClass: 'btn-primary', action: function(dialog) { var $button = this;  $button.disable(); $button.spin(); fAction(); dialog.close(); } }]
            });
        });
    })
}