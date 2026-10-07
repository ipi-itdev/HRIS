
function JIBControl(Selector, Control, CtrlSetting, ParentModel) {
    var self = this;
    var textboxControl = null;
    var IsEnabled = (Control.IsEnabled != undefined ? Control.IsEnabled : true);
    this.controltype = (Control.type == undefined ? 'text' : Control.type);
    this.CurrentObject = {};
    this.CurrentValue = null;
    this.PropertyName = (ControlModel != null ? ControlModel : Control.ControlID);
    this.IsRequired = false;
    this.IsUnique = false;
    var ControlModel = Control.Model;
    this.ControldID = Control.ControlID + (ParentModel != null ? '_' + ParentModel : '');
    this.Init = function () {
        var ControlHtml = null;
        switch (self.controltype) {
            case 'text':
                ControlHtml = '<input type="text" class="form-control"/>';
                break;
            case 'textarea':
                ControlHtml = '<textarea rows="4" cols="45" class="form-control" style="resize:none"/>';
                break;
            case 'combobox':
                ControlHtml = '<select class="select2 form-control" style="width: 100%;"></select>';
                break;
            case 'comboboxPlus':
                ControlHtml = '<div class="input-group">' +
                    '<select class="select2 form-control" style="width: 100%;"></select>' +
                    '<div class="input-group-addon">' +
                    '<i class="fa fa-plus"></i> ' +
                    '</div>' +
                    '</div>';
                break;
            case 'checkbox':
                ControlHtml = '<input type="checkbox"/>';
                break;
            case 'datepicker':
            case 'datetimepicker':
                ControlHtml =
                    '<div class="input-group date" style="width:100%;">' +
                    '<input type="text" class="form-control pull-right datepicker"/>' +
                    '<div class="input-group-addon">' +
                    '<i class="fa fa-calendar"></i> ' +
                    '</div>' +
                    '</div>';
                break;
            case 'daterange':
                ControlHtml = 
                '<div class="input-group">' +
                  '<input type="text" class="form-control pull-right daterange">' +
                  '<div class="input-group-addon">' + 
                    '<i class="fa fa-calendar"></i>' + 
                  '</div>' + 
                '</div>';
                break;
            case 'texteditor':
                ControlHtml =
                    '<div class="box-body pad">' +
                    '<form>' +
                    '<textarea class="textarea" rows="15" cols="80"></textarea>' +
                    '</form>' +
                    '</div>';
                break;
        }

        if (self.controltype == "texteditor") {
                $(Selector).append(
               '<div class="row form-group" id="cntr_' + self.ControldID + '">' +
               '<div class="col-lg-8 control-container vcenter">' + ControlHtml + '</div></div>');
        } else {
            if (self.IsRequired == true) {
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

        switch (self.controltype) {
            case 'text':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);

                if (Control.ControlFormat != undefined) {
                    textboxControl.attr('data-inputmask', "'mask':" + "'" + Control.ControlFormat + "'");
                    textboxControl.attr('data-mask', '');

                    textboxControl.inputmask();
                }

                break;
            case 'datepicker':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);

                if (Control.ControlFormat != undefined) {
                    textboxControl.attr('data-inputmask', "'alias': '" + Control.ControlFormat + "'");
                    textboxControl.attr('data-mask', '');

                    textboxControl.inputmask();
                } else {
                textboxControl.datepicker({
                    autoclose: true
                }).on("change", function() {
                    OnTextChange();
                });
                }
                break
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
                break
            case 'daterange':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('input');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                textboxControl.daterangepicker({ showClear: true }).on("change", function () {
                    OnTextChange();
                }).on('keydown', function(e) {
                    if (e.keyCode==8)
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
                break
            case 'comboboxPlus':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('select');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').attr('id', 'Click_Me_' + self.ControldID);

                $(Selector).find('#Click_Me_' + self.ControldID).click(function (evt) {
                    URL = "../DetailView/ChildIndexModal?mName=" + ControlModel + "&pKey=" + '-1' + "&IsAppendMode=false&IsCombo=true&FormParentID=" + self.ControldID;
                    var detailView = new modiedd(ControlModel, URL, Control.Caption, self.ControldID, ParentModel);
                    detailView.open();
                })
                break
            case 'texteditor':
                textboxControl = $(Selector).find('#cntr_' + self.ControldID).find('textarea.textarea');
                textboxControl.attr('id', self.ControldID);
                textboxControl.attr('name', self.ControldID);
                textboxControl.attr('title', Control.Caption);
                var instance = CKEDITOR.instances[self.ControldID];
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
                    textboxControl.updateElement()
                    OnTextChange();
                });
                break
        }
        
        if (self.IsUnique) {
            textboxControl.addClass('unique');
        }

        if (IsEnabled == false) {
            textboxControl.attr('disabled', 'disabled');
            textboxControl.css('background-color', '#eee');
        }

        if (self.IsRequired) {
            textboxControl.addClass('required');
        }

        if (self.controltype != 'texteditor')
        {
            if (textboxControl.prop('type') != 'checkbox' && textboxControl.is('.select2') == false && textboxControl.is('.datepicker') == false && textboxControl.is('.datetimepicker') == false && textboxControl.is('.daterange') == false && Control.ControlFormat == undefined) {
                textboxControl.on('input', OnTextChange);
            } else if (textboxControl.is('.select2')) {
                textboxControl.on('select2:select', OnTextChange);
            } else if (textboxControl.is('.textarea') || Control.ControlFormat != undefined) {
                textboxControl.on('change', OnTextChange);
            } else if (textboxControl.prop('type') == 'checkbox') {
                textboxControl.on('click', function (evt) {
                    evt.stopPropagation();
                    if (self.CurrentObject == null) return;
                    self.CurrentObject[Control.PropertyName] = $(this).prop('checked') ? 1 : 0;
                    $(this).prop('checked', $(this).prop('checked'))
                });
            } else {
                textboxControl.on('click', OnTextChange);
            }
        }
        if (CtrlSetting.Type == 'Decimal') {
            textboxControl.on('blur', function () {
                var value = parseFloat($(this).val().replace(',', '')).toFixed(2);
                $(this).val(value);
            });
            textboxControl.on("keypress", function IsNumber(evt) {
                var iKeyCode = (evt.which) ? evt.which : evt.keyCode
                if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                    return false;
                return true;
            });
        }
    };

    this.HideCaption = function (IshideCaption) {
        var lablelCaption = $(Selector).find('#' + self.ControldID).find('label');
        var controlContainer = $(Selector).find('#' + self.ControldID).find('.control-container');
        if (IshideCaption) {
            lablelCaption.hide();
            controlContainer.removeClass('col-lg-8');
            controlContainer.addClass('col-lg-12');
        } else {
            lablelCaption.show();
            controlContainer.removeClass('col-lg-12');
            controlContainer.addClass('col-lg-8');
        }
    }

    this.HideControl = function (IsHideControl) {
        var Control = $(Selector).find('#' + self.ControldID)
        if (IsHideControl) {
            Control.hide();
        } else {
            Control.show();
        }
    }

    function OnTextChange() {
        $(this).addClass('Dirty');
        switch (self.controltype) {
            case 'comboboxPlus':
            case 'combobox':
                SetCurrentValue(parseFloat($(this).select2().val()));
                self.CurrentObject[Control.ControlID] = parseFloat($(this).val());
                break;
            case 'text':
            case 'datepicker':
            case 'datetimepicker':
            case 'daterange':
            case 'textarea':
                if (CtrlSetting.Type == 'Decimal') {
                    if (self.CurrentObject == null) return;
                    if (jQuery.trim(textboxControl.val()).length == 0 || isNaN(textboxControl.val()) || textboxControl.val() == undefined) { textboxControl.val(0); }
                    SetCurrentValue(parseFloat($(this).val()));
                    self.CurrentObject[Control.ControlID] = parseFloat($(this).val());
                } else {
                    var stringvalue = jQuery.trim(textboxControl.val()).length == 0 ? null : textboxControl.val();
                    SetCurrentValue(stringvalue);
                    if (self.CurrentObject == null) return;
                    self.CurrentObject[Control.ControlID] = stringvalue;
                }
                break;
            case 'texteditor':
                var stringvalue = jQuery.trim(textboxControl.getData()).length == 0 ? null : textboxControl.getData();
                SetCurrentValue(stringvalue);
                if (self.CurrentObject == null) return;
                self.CurrentObject[Control.ControlID] = stringvalue;
                break;
            case 'checkbox':
                SetCurrentValue($(this).prop('checked') ? 1 : 0);
                if (self.CurrentObject == null) return;
                self.CurrentObject[Control.PropertyName] = self.CurrentValue;
                break;
        }
        self.CurrentObject.IsDirty = true;
    }

    this.SetEnabled = function (isEnabled) {
        var button = $(Selector).find('#' + self.ControldID).find('button');
        if (isEnabled) {
            textboxControl.removeAttr('disabled');
            if (self.controltype == 'comboboxPlus') { $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').removeAttr('disabled') }
            if (button) button.removeAttr('disabled');
        } else {
            textboxControl.attr('disabled', 'disabled');
            textboxControl.css('background-color', '#eee');
            if (self.controltype == 'comboboxPlus') { $(Selector).find('#cntr_' + self.ControldID).find('.input-group-addon').attr('disabled', 'disabled') }
            if (button) button.attr('disabled', 'disabled');
        }
    }

    this.SetValue = function (ObjectValue) {
        switch (self.controltype) {
            case 'daterange':
            case 'datetimepicker':
            case 'text':
                if (CtrlSetting.Type == 'Decimal') {
                    SetCurrentValue(ObjectValue.toFixed(2));
                    textboxControl.val(ObjectValue.toFixed(2));
                } else {
                    textboxControl.val(ObjectValue);
                }
                break;
            case 'textarea':
                if (ObjectValue == null) { self.CurrentObject[Control.ControlID] = ""; }
                textboxControl.val(ObjectValue);
                break;
            case 'texteditor':
                if (ObjectValue == null) { self.CurrentObject[Control.ControlID] = ""; }
                CKEDITOR.instances[self.ControldID].setData(ObjectValue, function () {
                    this.checkDirty();  // true
                });
                break;
            case 'checkbox':
                textboxControl.prop('checked', ObjectValue);
                break;
            case 'datepicker':
                var date = new Date(ObjectValue);
                var newdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
                if (ObjectValue == null) { textboxControl.val(''); } else { textboxControl.val(newdate) }
                break;
            case 'combobox':
            case 'comboboxPlus':
                InitDropdown(ObjectValue);
                break;
        }
    }

    function SetCurrentValue(Value) {
        CurrentValue = Value;
        Selector.trigger({ type: "OnCurrentValueChange", CurrentValue: Value, PropertyName: self.ControlID });
    }
    
    function InitDropdown(value) {
        jQuery.ajax({
           
            url: "../AppSet/GetDataLookUpList",
            data: { Model: ControlModel, IsJson: Control.IsJson },
            type: 'POST',
            datatype: 'application/json; charset=utf-8',
            success: function (data) {
                var jsonArray = JSON.parse(data);
                
                textboxControl.append('<option id="0" value="0">N/A</option>');
                if (jsonArray.length == 0) return;
                for (var i = 0; i < jsonArray.length; i++) {
                    const Columns = jsonArray[i];
                    textboxControl.append('<option id=' + Columns[0] + ' value=' + Columns[0] + '>' + Columns[1] + '</option>');
                    if (value == Columns[0]) {
                        textboxControl.find('option[value=' + value + ']').attr('selected', 'selected')
                    }
                }
            },
            error: function (e) {
            }
        });
        textboxControl.select2();
    }

    function formatdate(val) {
        var date = new date(val);
        return date.getmonth() + '/' + date.getdate() + '/' + date.getfullyear();
    }

}

function InitDropdownOTH(mname, textboxControl) {
    jQuery.ajax({
        url: "../AppSet/GetDataLookUpList",
        data: { Model: mname },
        type: 'POST',
        datatype: 'application/json; charset=utf-8',
        success: function (data) {
            var jsonArray = JSON.parse(data);
            if (jsonArray.length == 0) return;
            for (var i = 1; i < jsonArray.length; i++) {
                const Columns = jsonArray[i];
                textboxControl.append('<option id=' + Columns[0] + ' value=' + Columns[0] + '>' + Columns[1] + '</option>');
            }
        },
        error: function (e) {
        }
    });    
    textboxControl.select2();
}



