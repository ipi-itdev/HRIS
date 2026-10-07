"use strict";
function INVItemsDetails(ObjectID) {
    const self = this;
    this.mguid = '';
    this.mNm = '';
    this.mNo = 0;
    this.mDesc = '';
    this.FKN = '';
    this.FK = '';
    this.fid = '';
    var qcfutitm = { ID:null,ItemName:null,IsRented:0,Qty:null,DepOwnedBy:null,DatePurchased:null,Price:null,DepRate:null,PresentValue:null,Remarks:null,ItemStatusRefNo:1,CreatedBy:null,CreatedDate:null,ModifiedBy:null,ModifiedDate:null,IsActive:null
        ,Save : function(Grid) {
            if(qcfutitm[self.FKN] !== undefined) { qcfutitm[self.FKN]  = self.FK; }
            $.ajax({
                url: '../DetailView/Save',
                data: { mName :self.mNm ,JSONObject : JSON.stringify( qcfutitm ) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                success: function (data) {
                    let res = JSON.parse(data);
                    Toast.Show( self.mDesc + " Save" );
                    let URLView = '../INV/Items?pid='+ res.ID + '&mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { });				    
                }, error: function(xhr, textStatus, error) { console.log(error); }
            });
        }
        ,Delete : function() {
            var item = [];
            item.push(qcfutitm);
            $.ajax({
                url: '../DetailView/Delete',
                data: { mName : self.mNm ,JSONObject : JSON.stringify(item) },
                type: 'POST',
                datatype: 'application/json; charset=utf-8',
                success: function (data) { 
                    Toast.Show( self.mDesc + " Successfully Deleted" ); 
                    $('#' + self.fid).trigger("OnDetailViewSaved"); 
                },
                error: function(xhr, textStatus, error) { console.log(error); }
            });
        }
        ,Available : function() {
            let nURL = '../INV/ItemStatus?pid=' + qcfutitm.ID + '&status=1'
            let nURLredirect = '../ListView/ListIndex?mguid=' + self.mguid; 
            let mr = new modieremarks('Tag as available',nURL,'Successfully tagged as available.','Tagging failed.',self.mNm,nURLredirect);
            mr.open(self);
        }
        ,Defective : function() {
            let nURL = '../INV/ItemStatus?pid=' + qcfutitm.ID + '&status=4'
            let nURLredirect = '../ListView/ListIndex?mguid=' + self.mguid; 
            let mr = new modieremarks('Tag as Defective',nURL,'Successfully tagged as defective.','Tagging failed.',self.mNm,nURLredirect);
            mr.open(self);
        }
        ,ForRepair : function() {
             let nURL = '../INV/ItemStatus?pid=' + qcfutitm.ID + '&status=3'
            let nURLredirect = '../ListView/ListIndex?mguid=' + self.mguid; 
            let mr = new modieremarks('Tag as For Repair',nURL,'Successfully tagged as for repair.','Tagging failed.',self.mNm,nURLredirect);
            mr.open(self);
        }
        ,Dispose : function() {
            let nURL = '../INV/ItemStatus?pid=' + qcfutitm.ID + '&status=5'
            let nURLredirect = '../ListView/ListIndex?mguid=' + self.mguid; 
            let mr = new modieremarks('Tag as Decommissioned',nURL,'Successfully tagged as decommissioned .','Tagging failed.',self.mNm,nURLredirect);
            mr.open(self);
        }
    }
	
    function DetailView() {
        var dvFormat = [{Name:'Details',Controls:[{Name:'ID',Type:'Int',IsEnabled:false,ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'ID'},
        {Name:'ItemTypeRefNo',Caption:'Type',Type:'Int',ControlType:'combobox',RefColumn:'ITT',ControlModel:'ItemsType',ColumnValue:'ID',DisplayColumnValue:'Description',IsRequired:true,ColumnNo:0,TbName:'Details',ControlID:'ItemTypeRefNo'},
        {Name:'ItemName',Caption:'Unique Identity',Type:'String',ControlType:'textarea',ControlModel:'INVItems',IsRequired:true,ColumnNo:0,TbName:'Details',ControlID:'ItemName'},
            { Name: 'IsForExternal', Caption: 'Is For External?', Type: 'Boolean', ControlType: 'checkbox', ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Other', ControlID: 'IsForExternal' },       
        {Name:'DepOwnedBy',Caption:'Owner',Type:'Int',ControlType:'combobox',RefColumn:'Dep',ControlModel:'Department',ColumnValue:'ID',DisplayColumnValue:'Description',ColumnNo:0,TbName:'Details',ControlID:'DepOwnedBy'},
        {Name:'DatePurchased',Caption:'Date Purchased',Type:'DateTime',ControlType:'datepicker',ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'DatePurchased', strFormat: 'mm/dd/yyyy'},
        {Name:'SupplierRefNo', Caption: 'Supplier', Type: 'Int', ControlType: 'combobox', RefColumn: 'Sup', ControlModel: 'Supplier', ColumnValue: 'ID', DisplayColumnValue: 'Description', ColumnNo: 0, TbName: 'Details', ControlID: 'SupplierRefNo' },
        {Name:'Warranty',Type:'String',ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'Warranty'},
        {Name:'LicensedEndDate',Caption:'Licensed End Date',Type:'DateTime',ControlType:'datepicker',ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'LicensedEndDate', strFormat: 'mm/dd/yyyy'},
        {Name:'Price',Type:'Decimal',ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'Price'},
        { Name: 'PresentValue', Caption: 'Present Value', Type: 'Decimal', ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Details', ControlID: 'PresentValue' },
        { Name: 'IsRented', Caption: 'Is Rented?', Type: 'Boolean', ControlType: 'checkbox', ControlModel: 'INVItems', ColumnNo: 0, TbName: 'Other', ControlID: 'IsRented' },
        {Name:'Remarks',Type:'String',ControlType:'textarea',ControlModel:'INVItems',ColumnNo:0,TbName:'Details',ControlID:'Remarks'}]},
        {Name:'Other',Controls:[{Name:'CreatedBy',Caption:'Created By',Type:'Int',ControlType:'combobox',IsEnabled:false,RefColumn:'[Last Modified By]',ControlModel:'User',ColumnValue:'ID',DisplayColumnValue:'Description',ColumnNo:0,TbName:'Other',ControlID:'CreatedBy'},
        {Name:'CreatedDate',Caption:'Created Date',Type:'String',IsEnabled:false,ControlModel:'INVItems',ColumnNo:0,TbName:'Other',ControlID:'CreatedDate'},
        {Name:'ModifiedBy',Caption:'Last Modified By',Type:'Int',ControlType:'combobox',IsEnabled:false,RefColumn:'[Last Modified By]',ControlModel:'User',ColumnValue:'ID',DisplayColumnValue:'Description',ColumnNo:0,TbName:'Other',ControlID:'ModifiedBy'},
        {Name:'ModifiedDate',Caption:'Last Modified Date',Type:'String',IsEnabled:false,ControlModel:'INVItems',ColumnNo:0,TbName:'Other',ControlID:'ModifiedDate'},
        {Name:'IsActive',Type:'Boolean',ControlType:'checkbox',IsEnabled:false,ControlModel:'INVItems',ColumnNo:0,TbName:'Other',ControlID:'IsActive'}]},
        {Name:'Specifications',Controls:[{Name:'Description',ControlType:'texteditor',Caption:'Specifications',Type:'String',ColumnNo:0,TbName:'Specifications',ControlID:'Description'}]}];

        dvFormat.push({ Name: 'INVItemDetails', Type: '30110', FKey: 'ItemsRefNo', FKeyValue: 'ID', HasNew: true, IsListView: true, PropertyName: 'INVItemDetails' })
        dvFormat.push({ Name: 'INVItemHistory', Type: '30120', FKey: 'ItemsRefNo', FKeyValue: 'ID', HasNew: true, IsListView: true, PropertyName: 'INVItemHistory' })
        
		this.OpenObject = function(CurrentObject) {  InitNewObject(CurrentObject,qcfutitm,self.mNm,self.mNo,self.fid,dvFormat); };
		this.InitDetailView = function(CurrentObject) {  InitDetailView(CurrentObject,self.mNm,self.mNo,self.fid,ObjectID,dvFormat); };       
    }

     $(function () {
        $('#btnList_' + self.fid).find('button').on('click', function() {
            var ids = $(this).attr('id'); var Message = ''; var OkLabel = 'OK'; var fAction = null;
            switch (ids.replace('_' + self.fid,'').toUpperCase()) {
                 case 'NEW':
                    Message = 'Create New Item?';
                    OkLabel = 'Create';
                    fAction = function(result) {  var URLView = '../INV/Items?pid=-1&mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); }
                    break;
                case 'SAVE':
                    Message = 'Save changes?';
                    OkLabel = 'Save';
                    fAction = function(result) { 
                        if(ControlValidation(qcfutitm,self.mNm,self.fid) === true){
                            if(ControlValidationUnique(qcfutitm,self.mNm,self.fid) === true) { qcfutitm.Save(); }
                        }
                    };
                    break;
                case 'DELETE':
                    Message = 'Are you sure you want to delete?';
                    OkLabel = 'Delete';
                    fAction = function(result) { self.Delete();};
                    break;
                case 'AVAILABLE':
                    Message = 'Are you sure you want to tag this item as available?';
                    OkLabel = 'Available';
                    fAction = function(result) { qcfutitm.Available();};
                    break;
                case 'DEFECTIVE':
                    Message = 'Are you sure you want to tag this item as defective?';
                    OkLabel = 'Defective';
                    fAction = function(result) { qcfutitm.Defective();};
                    break;
                case 'FORREPAIR':
                    Message = 'Are you sure you want to tag this item as for repair?';
                    OkLabel = 'For Repair';
                    fAction = function(result) { qcfutitm.ForRepair();};
                    break;
                case 'DISPOSE':
                    Message = 'Are you sure you want to tag this item as decommissioned?';
                    OkLabel = 'Dispose';
                    fAction = function(result) { qcfutitm.Dispose();};
                    break;
                 default:
                    Message = 'Are you sure you want to go back to list?';
                    OkLabel = 'Yes';
                    fAction = function(result) {  var URLView = '../ListView/ListIndex?mguid=' + self.mguid; $('#content_mFrm' + self.mNo).load(URLView, function () { }); }
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
        var $itm = new DetailView();
        $itm.InitDetailView(qcfutitm);

        $('#tab_' + self.fid + '>li>a').first().click();
     });

}

