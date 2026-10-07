"use strict";
function griddy(Selector, _tblFrmt, _tblbtn, _tblbtndtl, _tblfltr, _tblfltrdefval = {}, _isDtl = false, fID = -1, fidname = '') {
    let self = this;
    let table = null;
    let $parent = $('#' + $(Selector).parent().attr('ID'));
    let nURL = '';
    self.Icon = 'fa-list';
    self.Description = '';
    self.mguid = '';
    self.mCode = '';
    self.mNo = '';
    self.TableId = Selector.replace('#', '') + '_Table';
    self.FormID = Selector.replace('#', '');
    self.LimitLoad = 'False';
    self.DataSourceUrl = '../ListView/ListIndexRefresh';
    self.DetailViewURL = '';
    self.WithOpen = 'True';
    self.AllowInsert = 'True';
    self.AllowPrint = 'False';
    self.AllowExport = 'False';
    self.ListType = 1;
    self.refNo = -1;
    self.FKey = fID;
    self.FKeyName = fidname;
    self.OrderBy = 0;
    self.OrderByAs = 'asc';
    self.IsAPIUrl = false;
    self.DetailViewOpen = function (pkey) {
        run_waitMe($('.content-wrapper'), 1, "roundBounce");
        if (self.ListType === 1) {
            $('#content_mFrm' + self.mNo).html('');
            nURL = self.DetailViewURL.replace('PRIMARY_KEY', pkey) + '&mguid=' + self.mguid;
            $('#content_mFrm' + self.mNo).load(nURL, function () { });
        }
        else {
            nURL = self.DetailViewURL.replace('PRIMARY_KEY', pkey) + '&mguid=' + self.mguid + '&FKeyName=' + fidname + '&FKey=' + fID;
            let detailView = new formy(nURL, self.FormID, false, false);
            detailView.open(self);
        }
    };

    self.Refresh = function () { Init(); RefreshList(self.LimitLoad === 'False' ? 0 : 1); };

    $(function () { Init(); RefreshList(self.LimitLoad === 'False' ? 0 : 1); });

    function Init() {
        let container = $(Selector);
        let HTMLString = "";
        if (parseInt(self.ListType) === -1) { HTMLString = '<div class="box-header"><div class="btn-group"><h5><i class="fa ' + self.Icon + '"></i> ' + self.Description + '</h5></div></div>'; }
        HTMLString = HTMLString + '<div class="btn-group" id="btnChildList_' + self.TableId + '">';
        if (parseInt(self.ListType) === -1 && fID < 0) { HTMLString = HTMLString + (self.AllowInsert === 'True' ? '<div class="row form-group"><label class="col-lg-12 control-label style=" text-align:left"=""><span style="color:red; font-size:20px; ">*  </span>Please save the parent item before adding ' + self.Description + '</label></div>' : ''); }
        if ((parseInt(self.ListType) === -1 && fID > 0) || parseInt(self.ListType) !== -1) {  // don't show the new button if the parent of the child list is not yet saved.
            HTMLString = HTMLString + (self.AllowInsert === 'True' ? '<button type="button" class="btn btn-primary" id="New_' + self.TableId + '" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-file" title="Open"></i> New</button>' : '');
            if ((_isDtl === true && fID > 0) || (_isDtl === false)) {
                let btnctr = _tblbtn.length;
                for (i = 0; i < btnctr; i++) {
                    HTMLString = HTMLString + '<button type="button" id=' + _tblbtn[i].Code + '_' + self.TableId + ' class="btn btn-primary" title ="' + _tblbtn[i].Caption + '" onclick="SetEvent(' + _tblbtn[i].CommandTypeRefNo + ',\'' + _tblbtn[i].ActionURL + '\',\'' + self.mguid + '\')"><i class="fa fa-' + _tblbtn[i].Icon + '" title="' + _tblbtn[i].Caption + '" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"></i> ' + _tblbtn[i].Caption + '</button>';
                }
            }
            HTMLString = HTMLString + (self.WithOpen === 'True' ? '<button type="button" class="btn btn-primary" id="Open_' + self.TableId + '" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-folder-open" title="Open"></i> Open</button>' : '');
            HTMLString = HTMLString + '<button type="button" class="btn btn-primary" id="Refresh_' + self.TableId + '" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-refresh" title="Refresh"></i> Refresh</button>';
            if (self.ListType === 1 && _tblfltr.length > 0) { HTMLString = HTMLString + '<button type="button" class="btn btn-primary" id="Filter_' + self.TableId + '" onclick="var e=this; e.disabled=true; setTimeout(function(){e.disabled=false;},10000);return true;"><i class="fa fa-filter" title="Filter"></i> Advanced Search</button>'; }
        }
        HTMLString = HTMLString + '</div>';
        // if(self.LimitLoad === 'True'){
        //     HTMLString = HTMLString + '<div style="float:right;">';
        //     HTMLString = HTMLString + '<div class="form-group has-icon">';
        //     HTMLString = HTMLString + '<input type="text" class="form-control" id="QuickSearch' + self.TableId + '" placeholder="Search">';
        //     HTMLString = HTMLString + '<span class="fa fa-search form-icon-feedback"></span>';
        //     HTMLString = HTMLString + '</div></div>';
        // }
        HTMLString = HTMLString + '<table id=' + self.TableId + ' class="table table-bordered table-striped table-hover tblList table-responsive nowrap" style="font-size:13px; width:100%;">';
        HTMLString = HTMLString + '<thead><tr class="notfilter">';
        let l = _tblFrmt.length;
        for (i = 0; i < l; i++) {
            HTMLString = HTMLString + '<th align="' + (_tblFrmt[i].Align === 'right' ? 'center' : _tblFrmt[i].Align) + '" style="overflow:hidden;width:' + _tblFrmt[i].Width + '%"' + (_tblFrmt[i].Caption === '' ? '>' : ' class="wfilter">') + _tblFrmt[i].Caption + '</th>';
        }
        if (self.LimitLoad === 'False') {
            HTMLString = HTMLString + '</tr><tr class="filters">';
            for (i = 0; i < l; i++) {
                HTMLString = HTMLString + '<th align="' + (_tblFrmt[i].Align === 'right' ? 'center' : _tblFrmt[i].Align) + '" style="overflow:hidden;width:"' + _tblFrmt[i].Width + '%"' + (_tblFrmt[i].Caption === '' ? '>' : ' class="wfilter">') + _tblFrmt[i].Caption + '</th>';
            }
        }
        HTMLString = HTMLString + '</tr></thead><tbody id="tblBody"></tbody><tfoot></tfoot></table><div id="' + self.TableId + '_info"></div><div style="float:right;"><nav aria-label="Page navigation"> <ul class="pagination" id="' + self.TableId + '_pagination"></ul> </nav></div>';
        container.html(HTMLString);

        if (self.WithOpen === 'True') {
            $.when(SetListViewClickEvent()).then(function () {
                $('#' + self.TableId + ' tbody tr:first-child').click();
            });
        }

        $('#btnChildList_' + self.TableId).find('button').on('click', function () {
            let ids = $(this).attr('id');
            let URL = "";
            switch (ids.toUpperCase()) {
                case ('New_' + self.TableId).toUpperCase():
                    self.DetailViewOpen(-1);
                    break;
                case ('Open_' + self.TableId).toUpperCase():
                    if (self.refNo > 0) { if (self.refNo > 0) { self.DetailViewOpen(self.refNo); } else { Toast.Error(""); } }
                    break;
                case ('REFRESH_' + self.TableId).toUpperCase():
                    $('#' + self.FormID + '_FilterView').html('');
                    $('#' + self.TableId + '_pagination').empty();
                    $('#' + self.TableId + '_pagination').removeData("twbs-pagination");
                    $('#' + self.TableId + '_pagination').unbind("page");
                    _tblfltrdefval = {};
                    if (fidname !== '') {
                        _tblfltrdefval[fidname] = fID;
                    }
                    initFilter(_tblfltr, _tblfltrdefval, self.FormID); RefreshList(self.LimitLoad === 'False' ? 0 : 1);
                    break;
                default:
                    break;
            }
        });

        //              _tblfltrdefval = {};
        // if(self.LimitLoad === 'True'){
        //     document.getElementById("QuickSearch" + self.TableId).addEventListener("keydown", function (event) {
        //         if (event.keyCode === 13) {
        //              _tblfltrdefval["QuickSearch"] = document.getElementById("QuickSearch" + self.TableId).value;
        //              RefreshList(1,true);
        //              return true;
        //         } else { return false; }
        //     });
        //  }

        if (_tblfltr.length > 0) {
            $('#Filter_' + self.TableId).off('click').on('click', function () {
                // if(self.LimitLoad === 'True'){
                //     if(document.getElementById("QuickSearch" + self.TableId).value !== ''){
                //         document.getElementById("QuickSearch" + self.TableId).value = '';
                //         $('#' + self.FormID + '_FilterView').html('');
                //         _tblfltrdefval = {};
                //         initFilter(_tblfltr,_tblfltrdefval,self.FormID);
                //     }
                // }
                $('#mySidebar_' + self.FormID).toggle("slide", { direction: "right" }, 100);
            });
            initFilter(_tblfltr, _tblfltrdefval, self.FormID);
        }


        $('#Filter_' + self.FormID).off('click').on('click', function () {
            $('#' + self.TableId + '_pagination').empty();
            $('#' + self.TableId + '_pagination').removeData("twbs-pagination");
            $('#' + self.TableId + '_pagination').unbind("page");
            RefreshList(1, true);
            $('#Filter_' + self.TableId).click();
        });

        $('#Clear_' + self.FormID).off('click').on('click', function () {
            $('#' + self.FormID + '_FilterView').html('');
            _tblfltrdefval = {};
            initFilter(_tblfltr, _tblfltrdefval, self.FormID);
        });
    }
    var SetListViewClickEvent = function () {
        const selected = [];
        $('#' + self.TableId + ' tbody').off('click').on('click', 'tr', function () {
            if (table.row(this).data() !== undefined) {
                let data = table.row(this).data();
                if (data !== undefined) { self.refNo = data[0]; }
                let index = $.inArray(self.refNo, selected);
                if (index === -1) { selected.push(self.refNo); }
                else { selected.splice(index, 1); }
                $(this).siblings().removeClass('selected');
                $(this).addClass('selected');
                return false;
            } else { self.refNo = 0; }
        }).on('dblclick', 'tr', function () {
            if (self.WithOpen === 'True') {
                if (table.row(this).data() !== undefined) {
                    let data = table.row(this).data();
                    if (data !== undefined) { self.DetailViewOpen(data[0]); }
                }
            }
        });
    };
    function RefreshList(b, reset = false) {
        const param = JSON.stringify(_tblfltrdefval);
        if (self.LimitLoad === 'False') {
            $('#' + self.TableId + ' thead .filters th.wfilter').each(function () { $(this).html('<input type="text"/>'); });
        }
        table = $('#' + self.TableId).DataTable({
            destroy: true,
            dom: self.LimitLoad === 'False' ? "<'row'<'col-sm-10'><'col-sm-2'>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'p>>" : "<'row'<'col-sm-6'><'col-sm-6'>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'><'col-sm-7'>>",
            dom: self.AllowExport === 'True' ? 'Bfrtip' : self.LimitLoad === 'False' ? "<'row'<'col-sm-10'><'col-sm-2'>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'p>>" : "<'row'<'col-sm-6'><'col-sm-6'>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'><'col-sm-7'>>",
            buttons: [
                'excel'
            ]
            , "columnDefs": [{ "targets": [0], "width": "1%" }, {
                "targets": [-1], "data": null, "render": function (data, full, row) {
                    
              
                    if (data[0] !== 'N/A')
                    {
                        var ColCount = table.row(0).data().length;
                        var LastColCount = ColCount - 1;
                        //console.log(LastColCount + " test");  
                        const lb = _tblbtndtl.length;
                        var tblbtn = '';
                        if (lb > 0)
                        {
                            for (i = 0; i < lb; i++) {
                                //console.log(_tblbtndtl[i].Expression.length > 0);

                                console.log(_tblbtndtl[i].Expression.length + "length");

                                // tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '_' + data[0] + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')"></button>&nbsp;';
                                if (_tblbtndtl[i].Expression.length > 0)
                                {
                                    if (data[3] != null ) //
                                    {
                                        //console.log(_tblbtndtl[i].Expression.length + "length1 dtio");
                                        //tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '_' + data[0] + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="'+ _tblbtndtl[i].Code+'"></button>&nbsp;';
                                    }
                                    else if (data[5] == 'No' && data[6] == 'No') //IsCleard? & IsDeployed?
                                    {
                                        if (_tblbtndtl[i].Code == 'ReturnedCleared' || _tblbtndtl[i].Code == 'ReturnedRepair')
                                        {
                                            tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="' + _tblbtndtl[i].Code + '"  disabled ></button>&nbsp;';
                                        }
                                        else
                                        {
                                            tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="' + _tblbtndtl[i].Code + '"  ></button>&nbsp;';
                                        }
                                        //tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '_' + data[0] + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="' + _tblbtndtl[i].Code + '"  ></button>&nbsp;';
                                    }
                                    else if (data[5] == 'No' && data[6] == 'Yes') //IsCleard? & IsDeployed?
                                    {
                                        if (_tblbtndtl[i].Code == 'ReturnedCleared' || _tblbtndtl[i].Code == 'ReturnedRepair') {
                                            tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="' + _tblbtndtl[i].Code + '"   ></button>&nbsp;';
                                        }
                                        else
                                        {
                                            tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')" name="' + _tblbtndtl[i].Code + '" disabled ></button>&nbsp;';
                                        }
                                    }
                                    else if (data[5] == 'Yes' && data[6] == 'Yes') //IsCleard? & IsDeployed?
                                    {
                                        // not button showed
                                    }
                                    else
                                    {
                                        //console.log(_tblbtndtl[i].Expression.length + "length3");
                                        tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '_' + data[0] + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')"></button>&nbsp;';
                                    }
                                }
                                else
                                {
                                    console.log('hello, walang laman ung expression!');
                                    tblbtn = tblbtn + '<button type="button" id="' + _tblbtndtl[i].Code + '_' + self.TableId + '_' + data[0] + '" class="btn btn-primary fa fa-' + _tblbtndtl[i].Icon + '" title = "' + _tblbtndtl[i].Caption + '" onclick="SetEvent(' + _tblbtndtl[i].CommandTypeRefNo + ',\'' + _tblbtndtl[i].ActionURL + '\',\'' + self.FormID + '\',' + data[0] + ')"></button>&nbsp;';
                                }
                            }
                            
                        }
                        return lb > 0 ? tblbtn : data[LastColCount];

                    } else { return ''; }
                }
            }]

            , "autoWidth": false
            , "searching": (self.LimitLoad === 'False' ? true : false)
            , bSortCellsTop: (self.LimitLoad === 'False' ? true : false)
            , "bPaginate": (self.LimitLoad === 'False' ? true : false)
            , "info": (self.LimitLoad === 'False' ? true : false)
            , order: [[self.OrderBy, self.OrderByAs]]
            , ajax: {
                url: self.DataSourceUrl,
                data: { mguid: self.mguid, TPageNo: b, TdtParam: param},
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',
                headers: { "x-api-key": "14D7F4F394ECBC8B70BFDCDFFE2A93B3" },
                dataSrc: function (data) {
                    if (data === null) { return false; }
                    if (self.LimitLoad === 'True') {
                        if (reset) {
                            $('#' + self.TableId + '_pagination').empty();
                            $('#' + self.TableId + '_pagination').removeData("twbs-pagination");
                        }
                        $('#' + self.TableId + '_pagination').twbsPagination({ totalPages: data.CNT < 10 ? 1 : Math.trunc(data.CNT / 10) + (data.CNT % 10 > 0 ? 1 : 0), visiblePages: 3, initiateStartPageClick: false, onPageClick: function (event, page) { RefreshList(page); } });
                        $('#' + self.TableId + '_info').html(''); $('#' + self.TableId + '_info').html('Showing ' + (((b - 1) * 10) + 1) + ' to ' + (data.CNT < 10 ? data.CNT : (b * 10) > data.CNT ? data.CNT : b * 10) + ' of ' + data.CNT + ' entries');
                    }
                    if (self.IsAPIUrl === 'True') { return JSON.parse(data); } else { return JSON.parse(data.Result); }
                },
                error: function (e) { }
            }
            , initComplete: function () {
                $('#' + self.TableId + ' tbody tr:first-child').click();
                if (self.ListType === '2') { $('#' + self.TableId + ' tbody tr:first-child').dblclick(); }
                $('.content-wrapper').waitMe('hide');
            }
        });

        if (self.LimitLoad === 'False') {
            table.columns('.wfilter').eq(0).each(function (colIdx) {
                $('input', $('#' + self.TableId + ' thead .filters th')[colIdx]).on('keyup change', function () {
                    table
                        .column(colIdx)
                        .search(this.value)
                        .draw();
                });
            });
        }
    }
}
