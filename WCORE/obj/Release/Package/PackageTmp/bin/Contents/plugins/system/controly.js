"use strict";
function controly(Selector, Control, CtrlSetting, ParentModel , ForFilter) {
    const self = this;
    var textboxControl = null;
    var IsEnabled = Control.IsEnabled !== undefined ? Control.IsEnabled : true;
    var ControlModel = Control.Model;
    this.controltype = Control.type === undefined ? 'text' : Control.type;
    this.CurrentObject = {};
    this.CurrentValue = null;
    this.PropertyName = ControlModel !== null ? ControlModel : Control.ControlID;
    this.IsRequired = false;
    this.IsUnique = false;
    this.ControldID = Control.ControlID + (ParentModel !== null ? '_' + ParentModel : '');
    this.Init = function () {
        let ControlHtml = '';
        switch (self.controltype) {
            case 'text': // ControlType 1
                ControlHtml = '<input type="text" class="form-control"/>';
                break;
            case 'textarea': // ControlType 2
                ControlHtml = '<textarea rows="4" cols="45" style="resize:none" class="form-control" />';
                break;
            case 'combobox': // ControlType 3
                ControlHtml = '<select class="select2 form-control" style="width: 100%;"></select>';
                break;
            case 'comboboxPlus': // ControlType 4
                ControlHtml = '<div class="input-group">' +
                    '<select class="select2 form-control" style="width: 100%;"></select>' +
                    '<div class="input-group-addon">' +
                    '<i class="fa fa-plus"></i> ' +
                    '</div>' +
                    '</div>';
                break;
            case 'checkbox': // ControlType 5
                ControlHtml = '<input type="checkbox"/>';
                break;
            case 'datepicker': // ControlType 6
            case 'datetimepicker': // ControlType 7
                ControlHtml =
                    '<div class="form-group has-icon">' +
                    '<input type="text" class="form-control pull-right datepicker"/>' +
                    '<span class="fa fa-calendar form-icon-feedback"></span>' +
                    '</div>';
                break;
            case 'daterange': // ControlType 8
                ControlHtml = 
                    '<div class="form-group has-icon">' +
                    '<input type="text" class="form-control pull-right daterange">' +
                    '<span class="fa fa-calendar form-icon-feedback"></span>' +
                    '</div>';
                break;
            case 'texteditor': // ControlType 9
                ControlHtml =
                    '<div class="box-body pad">' +
                    '<form>' +
                    '<textarea class="textarea" rows="15" cols="80"></textarea>' +
                    '</form>' +
                    '</div>';
                break;
            case 'imagebox': // ControlType 10
                ControlHtml =
                    '<div class="box-body box-profile">' +
                    '<img class="profile-user-img img-responsive img-circle">' +
					'<input type="file" title="search image" accept="image/png, image/jpeg" style="display:none;" />' +
					'</div>';
                break;
            default: 
               ControlHtml = '<input type="text" class="form-control"/>';
               break;
        }

        if(ForFilter){
                    $(Selector).append(
                    '<div class="row form-group" id="cntr_' + self.ControldID + '">' +
                    '<label class="col-lg-12 control-label style="text-align:left">' + Control.Caption + '</label>' +
                    '<div class="col-lg-12 control-container vcenter">' + ControlHtml + '</div></div>');
        }else{
            if (self.controltype === "texteditor") {
                    $(Selector).append(
                    '<div class="row form-group" id="cntr_' + self.ControldID + '">' +
                    '<div class="col-lg-12 control-container vcenter">' + ControlHtml + '</div></div>');
            } else { 
                if (self.IsRequired === true) {
                    $(Selector).append(
                    '<div class="row form-group" id="cntr_' + self.ControldID + '">' +
                    '<label class="col-lg-4 control-label style="text-align:left"><span style="color:red; font-size:20px; ">*  </span>' + Control.Caption + '</label>' +
                    '<div class="col-lg-8 control-container vcenter">' + ControlHtml + '</div></div>');
                }
                else {
                    $(Selector).append(
                    '<div class="row form-group" id="cntr_' + self.ControldID + '">' +
                    '<label class="col-lg-4 control-label style="text-align:left"><span style="visibility:hidden;">.  </span>' + Control.Caption + '</label>' +
                    '<div class="col-lg-8 control-container vcenter">' + ControlHtml + '</div></div>');
                }
            }
        }

        switch (self.controltype) {
            case 'datepicker':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);

                if (Control.ControlFormat !== undefined) {
                    //textboxControl.attr('data-inputmask', "'alias': '" + Control.ControlFormat + "'");
                    //textboxControl.attr('data-mask', '');
                    textboxControl.inputmask(Control.ControlFormat,{clearIncomplete: true , onincomplete: function(){ textboxControl.val("").trigger("change");}});
                } else {
                    textboxControl.datepicker({ autoclose: true }).on("change", function() { OnTextChange(); });
                }
                break;
            case 'datetimepicker':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                
                textboxControl.datepicker({
                    autoclose: true,
                    isRTL: true,
                    dateFormat: "yy/mm/dd 23:59",
                    changeMonth: true,
                    changeYear: true
                }).on("change", function () {
                    OnTextChange();
                });
                break;
            case 'daterange':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                textboxControl.daterangepicker({ showClear: true }).on("change", function () {
                    OnTextChange();
                }).on('keydown', function(e) {
                    if (e.keyCode===8)
                        textboxControl.val('').datepicker('update');
                });
                break;
            case 'textarea':
                $(Selector).find('#cntr_' + self.ControldID).find('.control-label').removeClass('vcenter');
                $(Selector).find('#cntr_' + self.ControldID).find('.control-container').removeClass('vcenter');
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find(self.controltype);
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                break;
            case 'checkbox':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input[type=checkbox]');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                break;
            case 'combobox':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('select');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                break;
            case 'comboboxPlus':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('select');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').attr('id', 'Click_Me_' + self.ControldID);

                $(Selector).find('#Click_Me_' + self.ControldID).click(function (evt) {
                    URL = "../DV/ChildIndexModal?mName=" + ControlModel + "&pKey=" + '-1' + "&IsAppendMode=false&IsCombo=true&FormParentID=" + self.ControldID;
                    let detailView = new IPIModalDD(ControlModel, URL, Control.Caption, self.ControldID, ParentModel);
                    detailView.open();
                });
                break;
            case 'texteditor':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('textarea.textarea');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                let instance = CKEDITOR.instances[self.ControldID];
                if (instance) { CKEDITOR.remove(instance); }
                textboxControl = CKEDITOR.replace(self.ControldID, {
                    toolbar: [
                        { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
                        { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', '-', 'Undo', 'Redo'] },
                        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
                        { name: 'paragraph', groups: ['list', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
                        { name: 'tools', items: ['Maximize', 'ShowBlocks'] }]
                });
                textboxControl.on('change', function () {
                    textboxControl.updateElement();
                    OnTextChange();
                });
                break;
            default:
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                if (Control.ControlFormat !== undefined) {
                    textboxControl.inputmask(Control.ControlFormat,{clearIncomplete: true , onincomplete: function(){ textboxControl.trigger("change");}});
                }
                break;
        }
        
        if (self.IsUnique) {
            textboxControl.addClass('unique');
        }

        if (IsEnabled === false) {
            if (textboxControl.is('.select2')){ $(Selector).find('#cntr_' + self.ControldID).find('.select2-container .select2-selection--single').css('background-color', '#eee');
            }else{ textboxControl.attr('disabled', 'disabled'); textboxControl.css('background-color', '#eee');}
        }

        if (self.IsRequired) {
            textboxControl.addClass('required');
        }

        if (self.controltype !== 'texteditor')
        {
            if (textboxControl.prop('type') !== 'checkbox' && textboxControl.is('.select2') === false && textboxControl.is('.datepicker') === false && textboxControl.is('.datetimepicker') === false && textboxControl.is('.daterange') === false && Control.ControlFormat === undefined) {
                textboxControl.on('input', OnTextChange);
            } else if (textboxControl.is('.select2')) {
                textboxControl.on('select2:select', OnTextChange);
            } else if (textboxControl.is('.textarea') || Control.ControlFormat !== undefined) {
                textboxControl.on('change', OnTextChange);
            } else if (textboxControl.prop('type') === 'checkbox') {
                textboxControl.on('click', function (evt) {
                    evt.stopPropagation();
                    if (self.CurrentObject === null) return;
                    self.CurrentObject[Control.PropertyName] = $(this).prop('checked') ? 1 : 0;
                    $(this).prop('checked', $(this).prop('checked'));
                });
            } else {
                textboxControl.on('click', OnTextChange);
            }
        }
        if (CtrlSetting.Type === 'Decimal') {
            textboxControl.on('blur', function () {
                let value = parseFloat($(this).val().replace(',', '')).toFixed(2);
                $(this).val(value);
            });
            textboxControl.on("keypress", function IsNumber(evt) {
                let iKeyCode = evt.which ? evt.which : evt.keyCode;
                if (iKeyCode !== 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                    return false;
                return true;
            });
        }
    };

    this.HideCaption = function (IshideCaption) {
        let lablelCaption = $(Selector).find('#' + self.ControldID).find('label');
        let controlContainer = $(Selector).find('#' + self.ControldID).find('.control-container');
        if (IshideCaption) {
            lablelCaption.hide();
            controlContainer.removeClass('col-lg-8');
            controlContainer.addClass('col-lg-12');
        } else {
            lablelCaption.show();
            controlContainer.removeClass('col-lg-12');
            controlContainer.addClass('col-lg-8');
        }
    };

    function OnTextChange() {
        $(this).addClass('Dirty');
        switch (self.controltype) {
            case 'comboboxPlus':
            case 'combobox':
                SetCurrentValue(parseFloat($(this).select2().val()));
                self.CurrentObject[Control.ControlID] = parseFloat($(this).val());
                break;
            case 'texteditor':
                let stringvalue = jQuery.trim(textboxControl.getData()).length === 0 ? null : textboxControl.getData();
                SetCurrentValue(stringvalue);
                if (self.CurrentObject === null) return;
                self.CurrentObject[Control.ControlID] = stringvalue;
                break;
            case 'checkbox':
                SetCurrentValue($(this).prop('checked') ? 1 : 0);
                if (self.CurrentObject === null) return;
                self.CurrentObject[Control.PropertyName] = self.CurrentValue;
                break;
            default:
                 if (CtrlSetting.Type === 'Decimal') {
                    if (self.CurrentObject === null) return;
                    if (jQuery.trim(textboxControl.val()).length === 0 || isNaN(textboxControl.val()) || textboxControl.val() === undefined) { textboxControl.val(0); }
                    SetCurrentValue(parseFloat($(this).val()));
                    self.CurrentObject[Control.ControlID] = parseFloat($(this).val());
                } else {
                    let stringvalue = jQuery.trim(textboxControl.val()).length === 0 ? null : textboxControl.val();
                    SetCurrentValue(stringvalue);
                    if (self.CurrentObject === null) return;
                    self.CurrentObject[Control.ControlID] = stringvalue;
                }
                break;
        }
        self.CurrentObject.IsDirty = true;
    }

    this.SetEnabled = function (isEnabled) {
        const button = $(Selector).find('#' + self.ControldID).find('button');
        if (isEnabled) {
            textboxControl.removeAttr('disabled');
            if (self.controltype === 'comboboxPlus') { $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').removeAttr('disabled'); }
            if (button) button.removeAttr('disabled');
        } else {
            textboxControl.attr('disabled', 'disabled');
            textboxControl.css('background-color', '#eee');
            if (self.controltype === 'comboboxPlus') { $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').attr('disabled', 'disabled'); }
            if (button) button.attr('disabled', 'disabled');
        }
    };

    this.SetValue = function (ObjectValue) {
        switch (self.controltype) {
            case 'textarea':
                if (ObjectValue === null) { self.CurrentObject[Control.ControlID] = ""; }
                textboxControl.val(ObjectValue);
                break;
            case 'texteditor':
                if (ObjectValue === null) { self.CurrentObject[Control.ControlID] = ""; }
                    CKEDITOR.instances[self.ControldID].setData(ObjectValue, function () {
                    this.checkDirty();  // true
                });
                break;
            case 'checkbox':
                textboxControl.prop('checked', ObjectValue);
                break;
            case 'datepicker':
                const date = new Date(ObjectValue);
                const newdate = date.getMonth() + 1 + '/' + date.getDate() + '/' + date.getFullYear();
                if (ObjectValue === null) { textboxControl.val(''); } else { textboxControl.val(newdate); }
                break;
            case 'combobox':
            case 'comboboxPlus':
                InitDropdown(ObjectValue);
                break;
            default:
                 if (CtrlSetting.Type === 'Decimal') {
                    SetCurrentValue(ObjectValue.toFixed(2));
                    textboxControl.val(ObjectValue.toFixed(2));
                } else {
                    textboxControl.val(ObjectValue);
                }
                break;
        }
    };

    function SetCurrentValue(Value) {
        CurrentValue = Value;
        Selector.trigger({ type: "OnCurrentValueChange", CurrentValue: Value, PropertyName: self.ControlID });
    }
   
    function InitDropdown(value) {
        jQuery.ajax({
            url: "../AppSet/GetList",
            data: { Model: ControlModel, ForeignFieldKey: Control.ControlFKey , ID_ParentKey: Control.ControlFKeyValue , IsJson: Control.IsJson },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) {
                const jsonArray = JSON.parse(data);
              
                textboxControl.append('<option id="0" value="0">N/A</option>');
                if (jsonArray.length === 0) return;
                for (var i = 0; i < jsonArray.length; i++) {
                    const Columns = jsonArray[i];
                    textboxControl.append('<option id=' + Columns[0] + ' value=' + Columns[0] + '>' + Columns[1] + '</option>');
                    if (parseInt(value) === parseInt(Columns[0])) {
                        textboxControl.find('option[value=' + value + ']').attr('selected', 'selected');
                    }
                }
            },
            error: function (e) {
            }
        });
        textboxControl.select2();
    }

    function formatdate(val) {
        const date = new date(val);
        return date.getmonth() + '/' + date.getdate() + '/' + date.getfullyear();
    }

}

function InitDropdownOTH(mname, textboxControl) {
    jQuery.ajax({
        url: "../AppSet/GetList",
        data: { Model: mname },
        type: 'POST',
        datatype: 'application/json; charset=utf-8',
        success: function (data) {
            const jsonArray = JSON.parse(data);
            if (jsonArray.length === 0) return;
            let jl = jsonArray.length;
            for (var i = 1; i < jl; i++) {
                const Columns = jsonArray[i];
                textboxControl.append('<option id=' + Columns[0] + ' value=' + Columns[0] + '>' + Columns[1] + '</option>');
            }
        },
        error: function (e) {
        }
    });    
    textboxControl.select2();
}

function InitDropdownChild(mname, textboxControl, value, fkey , fkeyval) {
    $(textboxControl).empty();
    jQuery.ajax({
        url: "../AppSet/GetList",
        data: { Model: mname, ForeignFieldKey: fkey , ID_ParentKey: fkeyval },
        type: 'POST',
        datatype: 'application/json; charset=utf-8',
        success: function (data) {
            var jsonArray = JSON.parse(data);
            $(textboxControl).append('<option id="0" value="0">N/A</option>');
            if (jsonArray.length === 0) return;
            let jl = jsonArray.length;
            for (var i = 1; i < jl; i++) {
                const Columns = jsonArray[i];
                $(textboxControl).append('<option id=' + Columns[0] + ' value=' + Columns[0] + '>' + Columns[1] + '</option>');
                if (parseInt(value) === parseInt(Columns[0])) {
                    $(textboxControl).find('option[value=' + value + ']').attr('selected', 'selected');
                }
            }
        },
        error: function (e) {
        }
    });    
    $(textboxControl).select2();
}

function LoadListViewTab(Selector, Type, fkey, fkeyName, pmrefno) {  

    if(fkey===null){ fkey= -1;}
    let URLView = '../ListView/ListIndex?mguid=' + Type + '&FKey=' + fkey + '&FKeyName=' + fkeyName + '&ParentMenuRefNo=' + pmrefno;
    Selector.load(URLView);
	Selector.on('OnGridCreated', function (e, o) {
		var grid = o.Grid; 
		grid.Refresh();
	});
}

function GetControl(ModelName, Selector, CtrlFormat, CurrentObject) {
	let control = new controly(Selector, { PropertyName: CtrlFormat.Name , Caption: CtrlFormat.Caption === undefined ? CtrlFormat.Name : CtrlFormat.Caption, type : CtrlFormat.ControlType, Model : CtrlFormat.ControlModel, ControlID : CtrlFormat.ControlID , ControlFormat: CtrlFormat.strFormat },CtrlFormat, ModelName);
	control.IsRequired = CtrlFormat.IsRequired !== undefined ? CtrlFormat.IsRequired : false;
	control.IsUnique = CtrlFormat.IsUnique !== undefined ? CtrlFormat.IsUnique : false;
	control.ParentDiv = Selector;
	control.Init();
	if ( CtrlFormat.IsEnabled !== undefined ) control.SetEnabled( CtrlFormat.IsEnabled );
	control.CurrentObject = CurrentObject;
	return control;           
}

function InitNewObject(newObject , CurrentObject, mName , mNo , fid, dvFrmt) { 
    $.each(JSON.parse(newObject), function(key, value) { if ( key !== "IsEditOnly" ) { CurrentObject[key] = value; } });
    $.each(dvFrmt, function(i,tabs) {
        if ( tabs.IsListView !== undefined ) { 
            Selector = $('#' + tabs.Name + '_List_' + fid);
            LoadListViewTab(Selector,tabs.Type,CurrentObject[tabs.FKeyValue],tabs.FKey,mNo);
        }
       else {
            $.each(tabs.Controls, function(x,val ) {
                if(val.ColumnNo === 2) {Selector = $('#' + tabs.Name + '_' + fid + '_dtlv2');
                } else{ Selector = $('#' + tabs.Name + '_' + fid + '_dtlv');}
                var control = GetControl(mName,Selector,val,CurrentObject);
                control.SetValue(CurrentObject[val.Name]);
            });
        }
    });
}

function InitDetailView(CurrentObject, mName, mNo , fid , ObjectID, dvFrmt){
    $.ajax({
        url: '../DetailView/GetBaseObject',
        data: { model: mName , pid: ObjectID },
        type: 'POST',                   
        datatype: 'application/json; charset=utf-8',
        beforeSend: function () { },
        success: function (data) {
            if ( ObjectID <= 0 ) { 
                var newObject = data;
                InitNewObject(newObject,CurrentObject,mName, mNo,fid,dvFrmt);
            } else {
                const jsonArray = JSON.parse(data);
                if (jsonArray.length === 0) return;
                const Columns = jsonArray[0];
                const Values = jsonArray[1]; 
                $.each(Columns,function(i,o){ 
                    CurrentObject[o] = Values[i];
                });
                $.each(dvFrmt, function(x,tabs) { 
                    if ( tabs.IsListView !== undefined ) {               
                        Selector = $('#' + tabs.Name + '_List_' + fid);
                        LoadListViewTab(Selector,tabs.Type,CurrentObject[tabs.FKeyValue],tabs.FKey,mNo);
                    } else {
                        $.each( tabs.Controls, function( i, val ) {
                            if(parseInt(val.ColumnNo) === 2) {Selector = $('#' + tabs.Name + '_' + fid + '_dtlv2');
                            } else{ Selector = $('#' + tabs.Name + '_' + fid + '_dtlv');}
                            let control = GetControl(mName,Selector,val,CurrentObject); 
                            let ColumnIndex = Columns.indexOf( val.Name );
                            let Value = Values[ColumnIndex];
                            control.SetValue(Value);
                        });
                    }
                });
          }}, error: function ( e ) { alert(e.responseText); }
    });
}

function ControlValidation(CurrentObject,mName,fid) {
    var valid_Required = true;
    var objVal = JSON.parse(JSON.stringify( CurrentObject ));
    $("#" + fid + " .required").each(function() {
		var fname_itms = $(this).attr('name').split("_");
		if(objVal[fname_itms[0]] === null || objVal[fname_itms[0]] === 0 || objVal[fname_itms[0]] === '')
		{ Toast.Error( $(this).attr('title') + " is required." ); valid_Required = false; return false; }
	});
    return valid_Required;
}

function ControlValidationUnique(CurrentObject,mName,fid) {
    let valid_Unique = true;
    let objVal = JSON.parse(JSON.stringify( CurrentObject ));
    $("#" + fid + " .unique").each(function() {
        let fname_itms = $(this).attr('name').split("_");
		if(objVal[fname_itms[0]] !== null) { 
            $.ajax({
                type: "POST", 
                async: false,
                url: '../AppSet/IsUnique',
				data: { ObjID: objVal["ID"], Obj: fname_itms[0],  ObjVal: objVal[fname_itms[0]], mName : mName},
                success: function(data) {
                    let jsonArray = JSON.parse(data);
                    if (jsonArray.length > 0) { Toast.Error("Record is already exist."); valid_Unique = false; return false; }
                    else { valid_Unique = true; }
                },
                error: function (e) {
                }
            });
		}
    });
    return valid_Unique;
}

function initFilter(Cntrols, CurrentObject, mCode){
    
	const dvFormat = [{Name: 'Details', Controls: Cntrols }];
	function GetControl(Selector, CtrlFormat ) {
		let control = new controly(Selector, { PropertyName: CtrlFormat.Name , Caption: CtrlFormat.Caption === undefined ? CtrlFormat.Name : CtrlFormat.Caption , type : CtrlFormat.ControlType, Model : CtrlFormat.ControlModel, ControlID : CtrlFormat.ControlID ,  ControlFormat: CtrlFormat.strFormat },CtrlFormat, mCode , true);
		control.ParentDiv = Selector;
		control.Init();
		control.CurrentObject = CurrentObject;
		return control;           
	}
	$.each(dvFormat, function(x,tabs) { 
		$.each( tabs.Controls, function( i, val ) {
			Selector = $('#' + mCode + '_FilterView');
			let control = GetControl(Selector,val);   
			control.SetValue(CurrentObject[val.Name]);
		});
	});
}


    function SetEvent(CommandTypeRefNo, ActionURL , fid = 'myParentDialog', FKey = 0){
        let fAction = null, Message = '', OkLabel = 'Ok';
        switch (CommandTypeRefNo) {
            case 1: // Large Screen
                nURL = ActionURL.replace('F_KEY_VALUE',FKey);
                detailView = new modieviewer(nURL.replace('PKEY',FKey), fid);
                detailView.open(self);
                break;
            case 2: // Half Screen
                nURL = ActionURL.replace('F_KEY_VALUE',FKey);
                detailView = new modieviewer(nURL.replace('PKEY',FKey),fid,true);
                detailView.open(self);
                break;

            case 10: // Custom Action Here
                nURL = ActionURL.replace('F_KEY_VALUE', FKey);
                detailView = new modieviewer(nURL.replace('PKEY', FKey), fid,true);
                detailView.open(self);
                break;

            default:
                Message = 'Are you sure you want to proceed?'
                OkLabel = 'Yes'
                nURL = ActionURL.replace('F_KEY_VALUE',FKey);
               // alert(nURL.replace('PKEY',FKey));
                fAction = function(result) { 
                    if(result){
                        $.ajax({
                            type: "POST",
                            url: nURL.replace('PKEY',FKey),
                            success: function (data) {
                                if (data === true) { Toast.Show('Action Successfully.'); }
                                else { Toast.Error('Error'); }
                            }
                        });
                    }
                }
                break;
        }
        if(CommandTypeRefNo === 3){ BootstrapDialog.confirm({ message: Message, closable: true, btnCancelLabel: 'Cancel', btnOKLabel: OkLabel, callback: fAction }); }
    }

   function ItemPartsStatusUpdate(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/ItemStatus?pid='+ pid + '&status=' + $('#itemPartsStatus').val() + '&remarks=' + $('#iStatusRemarks').val() + '&IsItemParts=1',
                success: function (data) {
                    if (data === 'True') { Toast.Show('Update Successfully.'); $('#btn-Success').click(); $('#Refresh_INVItemDetails_ListView_30102_Table').click(); }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }
    
    function AccountabilityItemStatusUpdate(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/AccountabilityItemStatus?pid='+ pid + '&status=' + $('#AccountabilityStatus').val() + '&remarks=' + $('#AccountabilityItemStatusRemarks').val() + '&iStatus=1' + $('#AccountabilityItemStatus').val(),
                success: function (data) {
                    if (data === 'True') { Toast.Show('Update Successfully.'); $('#btn-Success').click(); $('#Refresh_INVItemDetails_ListView_30102_Table').click(); }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }


    function AccountabilityItemStatusChangetoRepair(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/AccountabilityItemStatus?pid=' + pid + '&status=' + $('#AccountabilityStatus').val() + '&remarks=' + $('#AccountabilityItemStatusRemarks').val() + '&iStatus=1' + $('#AccountabilityItemStatus').val(),
                success: function (data) {
                    if (data === 'True') { Toast.Show('Update Successfully.'); $('#btn-Success').click(); $('#Refresh_INVItemDetails_ListView_30102_Table').click(); }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }
   
    function AccountabilityItemStatusChangetoRepairSave(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/AccountabilityItemStatustoRepairSave?pid=' + pid + '&status=3' + '&remarks=' + $('#AccountabilityItemStatusRemarks').val() ,
                success: function (data) {
                    if (data === 'True') {
                        Toast.Show('Update Successfully.'); $('#btn-Success').click();
                        if ($("#Refresh_30215_ListView_30216_Table").length > 0) {
                            $('#Refresh_30215_ListView_30216_Table').click();
                        }
                        else if ($("#Refresh_30210_ListView_30212_Table").length > 0) {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                        else {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                    }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }


    function AccountabilityItemStatusChangetoReturnSave(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/AccountabilityItemStatustoReturnSave?pid=' + pid + '&status=1' + '&remarks=' + $('#AccountabilityItemStatusRemarks').val(),
                success: function (data) {
                    if (data === 'True') {
                        Toast.Show('Update Successfully.');

                        $('#btn-Success').click();
                        if ($("#Refresh_30215_ListView_30216_Table").length > 0) {
                            $('#Refresh_30215_ListView_30216_Table').click();
                        }
                        else if ($("#Refresh_30210_ListView_30212_Table").length > 0) {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                        else {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                    }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }



    function AccountabilityItemStatusChangetoActiveSave(pid) {
        if ($('#iStatusRemarks').val() !== '') {
            $.ajax({
                type: "POST",
                cache: false,
                url: '../INV/AccountabilityItemStatustoActiveSave?pid=' + pid + '&status=1' + '&remarks=' + $('#AccountabilityItemStatusRemarks').val(),
                success: function (data) {
                    if (data === 'True') {
                        Toast.Show('Item Removed Successfully.');
                        $('#btn-Success').click();
                        if ($("#Refresh_30215_ListView_30216_Table").length > 0)
                        {
                            $('#Refresh_30215_ListView_30216_Table').click();
                        }
                        else if ($("#Refresh_30210_ListView_30212_Table").length > 0) {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                        else
                        {
                            $('#Refresh_30210_ListView_30212_Table').click();
                        }
                    }
                    else { Toast.Error('Error'); }
                }
            });
        } else { Toast.Error('Remarks is required.'); }
    }





