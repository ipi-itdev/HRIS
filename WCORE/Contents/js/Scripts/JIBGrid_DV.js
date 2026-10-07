function JIBGrid_DV(Model, Selector, _TableFormat, IsAppendOnly, fID, MODEL_PARENT, _TableFilter) {
    var self = this;
    var selected = [];
    var table;
    var $parent = $('#' + $(Selector).parent().attr('ID'));
    this.TableId = Selector.replace('#', '') + '_Table';
    this.DataSourceUrl = '';
    this.TableFormat = _TableFormat;
    this.AllowInsert = false;
    this.AllowUpdate = false;
    this.AllowDelete = false;
    this.AllowExport = false;
    this.DetailViewURL = '';
    this.ID_ParentKey = 0;
    this.ForeignFieldKey = null;
    this.OrderBy = 0;
    this.OrderByAs = 'asc';
    this.getContainer = function () {
        return $(Selector);
    }
    this.getTable = function () {
        return $('#' + self.TableId + '_scrollbar');
    }
    this.Refresh = function (pkey) {
        $('#' + self.TableId).DataTable().ajax.reload(function(){
            if (IsAppendOnly == 'False') { $('#' + fID).html(''); self.DetailViewOpen(pkey); }
        });       
    }
    this.DetailViewOpen = function (pkey) {
        var nURL = self.DetailViewURL.replace('PRIMARY_KEY', pkey) + '&mName=' + Model + '&FKeyName=' + self.ForeignFieldKey + '&FKey=' + self.ID_ParentKey + '&ParentModel=' + MODEL_PARENT + '&FormParentID=' + fID + '&IsAllowEdit=' + self.AllowUpdate + '&IsDetailList=' + (IsAppendOnly == 'False' ? 'True' : 'False');
        var detailView = new JIBForm(nURL, fID);
        detailView.open(self);
    };

    $(function () {
        Init();
        RefreshList()
    });
    function Init() {
        $('#' + fID).html('');
        $("#" + self.TableId).html('');
        var container = $(Selector);
        var btncontainer = $(Selector + '_btn');
        var HTMLString = "", BTNHTMLString = "";
        BTNHTMLString = BTNHTMLString + '<button type="button" class="btn btn-default" id="Refresh_"' + self.TableId + '"><i class="fa fa-refresh" title="Refresh" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"></i> Refresh</button></div>';
        BTNHTMLString = BTNHTMLString + '<div style="float:right;"><button type="button" data-widget="control-sidebar" data-slide="true" href="#" role="button" class="btn btn-default fltrbtn" id="Filter_' + self.TableId + '"><i class="fa fa-filter" title="Filter" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"></i> Filter</button></div></div >';
        HTMLString = HTMLString + '<table id=' + self.TableId + ' class="table table-bordered table-striped table-hover display responsive" style="font-size:small;">';
        HTMLString = HTMLString + '<thead><tr>'
        for (i = 0; i < _TableFormat.length; i++) {
            HTMLString = HTMLString + '<th class="' + _TableFormat[i].visibility + '" align="' + (_TableFormat[i].align == 'right' ? 'center' : _TableFormat[i].align) + '" style="overflow:hidden;width:' + _TableFormat[i].width + '">' + _TableFormat[i].caption + '</th>';
        }
        HTMLString = HTMLString + '</tr></thead><tbody id="tblBody"></tbody><tfoot></tfoot></table>';
        btncontainer.html(BTNHTMLString);
        container.html(HTMLString);
    }
    
    var SetListViewClickEvent = function () {
        $('#' + self.TableId + ' tbody').off('click').on('click', 'tr', function () {
            if (table.row(this).data() != undefined) {
                var data = table.row(this).data();
                if (data != undefined) { refNo = data[0]; }
                var index = $.inArray(refNo, selected);
                if (index === -1) { selected.push(refNo); }
                else { selected.splice(index, 1); }
                return false;
            }
        }).on('dblclick', 'tr', function () {
            if (table.row(this).data() != undefined) {
                $(this).siblings().removeClass('selected');
                $(this).addClass('selected');
                var data = table.row(this).data();
                if (data != undefined) { $('#' + fID).html(''); refNo = data[0]; self.DetailViewOpen(refNo > 0 ? refNo : -1) }
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
        })

        

    };  
    function RefreshList(b) {
        var jsonArray = null;
        if (b == true) { table.destroy(); Init(); }
        table = $('#' + self.TableId).DataTable({
            ajax:{
                url: self.DataSourceUrl,
                data: { Model: Model, ForeignFieldKey: self.ForeignFieldKey, ID_ParentKey: self.ID_ParentKey, ctrPage: 1, odrPage: 'ID' },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                dataSrc: function (data) { jsonArray = JSON.parse(data); return ProcessData(jsonArray, 1); },
                error: function (e) { }
            },
            order: [[self.OrderBy, self.OrderByAs]], pageResize: false, searching: false, paging: false, info: false,
            "deferRender": true, "bLengthChange": false, 
            initComplete: function () {
                var HTMLPagin = "";
                HTMLPagin = HTMLPagin + '<div style="float:right;">';
                HTMLPagin = HTMLPagin + '<ul class="pagination pagination-sm m-0 float-right pagin" id="pagin">';
                HTMLPagin = HTMLPagin + '</ul>';
                HTMLPagin = HTMLPagin + '</div>';
                var HTMLString = '<div class="btn-group" id="btnChildList_' + self.TableId + '">';
                if (self.AllowInsert == 'True') {
                    if (IsAppendOnly == 'True') {
                        if (self.ID_ParentKey > 0) { HTMLString = HTMLString + '<button type="button" class="btn btn-default" id="New" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-plus" title="New" ></i>  Add</button>'; }
                    } else { HTMLString = HTMLString + '<button type="button" class="btn btn-default" id="New" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-file" title="New" ></i> New</button>'; }
                }
                HTMLString = HTMLString + '</div>';
                $('#' + self.TableId + '_wrapper').find('.col-sm-6:first-child').prepend(HTMLString);
                $('#' + self.TableId + '_wrapper').find('.col-sm-7:last-child').prepend(HTMLPagin);

                pageSize = 4; incremSlide = 5; startPage = 0; numberPage = 0;
                var pageCount = 100 / pageSize;
                var totalSlidepPage = Math.floor(pageCount / incremSlide);
                for (var i = 0; i < pageCount; i++) {
                    $("#pagin").append('<li class="page-item"><a class="page-link " href="#">' + (i + 1) + '</a></li> ');
                    if (i > pageSize) {
                        $("#pagin li").eq(i).hide();
                    }
                }

                var prev = $("<li/>").addClass("prev").html("Prev").click(function () {
                    startPage -= 5;
                    incremSlide -= 5;
                    numberPage--;
                    slide();
                });

                prev.hide();
                var next = $("<li/>").addClass("next").html("Next").click(function () {
                    startPage += 5;
                    incremSlide += 5;
                    numberPage++;
                    slide();
                });

                $("#pagin").prepend(prev).append(next);

                SetListViewClickEvent();
                if (IsAppendOnly == 'False') { $('#' + self.TableId + " tbody tr:first-child").dblclick(); }
            }
        });
    };
    function ProcessData(arr, row) { arr = arr.slice(0);  arr.splice(row - 1, 1); return arr; }
}


