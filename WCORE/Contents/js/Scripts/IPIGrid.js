"use strict";
function IPIGrid(mguid, Model, Selector, _TableFormat, IsAppendOnly, fID, MODEL_PARENT, IsHalf) {
    var self = this;
    var selected = [];
    var table;
    var $parent = $('#' + $(Selector).parent().attr('ID'));

    this.TableId = Selector.replace('#', '') + '_Table';
    this.DataSourceUrl = '';
    this.TableFormat = _TableFormat;
    this.AllowInsert = false;
    this.DetailViewURL = '';
    this.NewDetailViewURL = '';
    this.ID_ParentKey = 0;
    this.ForeignFieldKey = null;
    this.OrderBy = 0;
    this.OrderByAs = 'asc';
    this.IsNewFormDifferent = false;
    this.refNo = -1;
    this.getContainer = function () {
        return $(Selector);
    };
    this.getTable = function () {
        return $('#' + self.TableId + '_scrollbar');
    };
    this.Refresh = function (pkey) {
        $('#' + self.TableId).DataTable().ajax.reload(function(){
            if (IsAppendOnly === 'False') { $('#' + fID).html(''); self.DetailViewOpen(pkey); }
        });       
    };
    this.DetailViewOpen = function (pkey) {
        let nURL = ''; 
        nURL = self.DetailViewURL.replace('PRIMARY_KEY', pkey) + '&FKeyName=' + self.ForeignFieldKey + '&FKey=' + self.ID_ParentKey; 
        let detailView = new IPIForm(nURL, fID, false, IsHalf);
        detailView.open(self);
    };

    $(function () {  Init(); RefreshList(); });

    function Init() {
        $('#' + fID).html('');
        $("#" + self.TableId).html('');
        let container = $(Selector);
        let HTMLString = "";
        HTMLString = HTMLString + '<table id=' + self.TableId + ' class="table table-bordered table-striped table-hover display responsive" style="font-size:small;">';
        HTMLString = HTMLString + '<thead><tr>';
        let tfl = _TableFormat.length;
        for (i = 0; i < tfl ; i++) {
            HTMLString = HTMLString + '<th class="' + _TableFormat[i].visibility + '" align="' + (_TableFormat[i].align === 'right' ? 'center' : _TableFormat[i].align) + '" style="overflow:hidden;width:' + _TableFormat[i].width + '">' + _TableFormat[i].caption + '</th>';
        }
        HTMLString = HTMLString + '</tr></thead><tbody id="tblBody"></tbody><tfoot></tfoot></table>';
        container.html(HTMLString);
    }
    
    var SetListViewClickEvent = function () {
        $('#' + self.TableId + ' tbody').off('click').on('click', 'tr', function () {
            if (table.row(this).data() !== undefined) {
                var data = table.row(this).data();
                if (data !== undefined) { refNo = data[0]; }
                var index = $.inArray(refNo, selected);
                if (index === -1) { selected.push(refNo); }
                else { selected.splice(index, 1); }
                return false;
            }
        }).on('dblclick', 'tr', function () {
            if (table.row(this).data() !== undefined) {
                $(this).siblings().removeClass('selected');
                $(this).addClass('selected');
                var data = table.row(this).data();
                if (data !== undefined) { $('#' + fID).html(''); refNo = data[0]; self.DetailViewOpen(refNo > 0 ? refNo : -1); }
            }
        });
        $('#btnChildList_' + self.TableId).find('button').on('click', function () {
            var ids = $(this).attr('id');
            var URL = "";
            switch (ids.toUpperCase()) {
                case 'NEW':
                    $('#' + fID).html('');
                    self.DetailViewOpen(-1); 
                    break;
            }
        });
    };  

    function RefreshList(b) {
        if (b === true) { table.destroy(); Init(); }
        var htmlstr = ""; var htmlstr2 = "";
        table = $('#' + self.TableId).DataTable({
            ajax:{
                url: self.DataSourceUrl,
                data: { Model: Model, ForeignFieldKey: self.ForeignFieldKey, ID_ParentKey: self.ID_ParentKey },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                dataSrc: function (data) {
                    return JSON.parse(data);
                },
                error: function (e) { }
            },
            order: [[self.OrderBy, self.OrderByAs]], pageResize: false,
            "deferRender": true, "bLengthChange": false, 
            initComplete: function () {
                var HTMLString = '<div class="btn-group-horizontal" id="btnChildList_' + self.TableId + '">';
                if (self.AllowInsert === 'True')  { HTMLString = HTMLString + '<button type="button" class="btn btn-primary" id="New" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-file" title="New" ></i> New</button>'; }
                HTMLString = HTMLString + '</div>';
                $('#' + self.TableId + '_wrapper').find('.col-md-6:first-child').prepend(HTMLString);
                SetListViewClickEvent();
                if (IsAppendOnly === 'False') {  $('#' + self.TableId + ' tbody tr:first-child').dblclick(); }
                $('.content-wrapper').waitMe('hide');
            }
        });
    }
}


