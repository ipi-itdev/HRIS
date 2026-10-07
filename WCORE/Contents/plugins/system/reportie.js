"use strict";
function reportie(mguid, mCode, _FilterView) {
    var self = this;
    @{var ObjectID = Common.GenerateName();}
    var @{@ObjectID} = { @{@Html.Raw(ViewBag.FilterDefaultValue)} }
	init();
	$('#Filter_' + mCode).off('click').on('click',function () {
		run_waitMe($('.container'), 1, "roundBounce");
		var arr = JSON.stringify(@{@ObjectID});
		$('#rptframe_' + mCode).attr('src', '@Url.Action("rptSource", "RV")?mguid=' + mguid + '&param=' + arr );
		$('.container').waitMe('hide');
	});

	function init(){
		var r = $.Deferred();
		var dvFormat = [{Name: 'Details',Controls: _FilterView}];
		function GetControl(Selector, CtrlFormat ) {
			var control = new controly(Selector, { PropertyName: CtrlFormat.Name , Caption: (CtrlFormat.Caption == undefined ? CtrlFormat.Name : CtrlFormat.Caption ), type : CtrlFormat.ControlType, Model : CtrlFormat.ControlModel, ControlID : CtrlFormat.ControlID ,  ControlFormat: CtrlFormat.strFormat },CtrlFormat, mCode, true);
			control.ParentDiv = Selector;
			control.Init();
			control.CurrentObject = @{@ObjectID};
			return control;           
		};

		$.each(dvFormat, function(x,tabs) { 
			$.each( tabs.Controls, function( i, val ) {
				Selector = $('#' + mCode + '_FilterView');
				var control = GetControl(Selector,val);
				control.SetValue(@{@ObjectID}[val.Name]);
			});
		});
		return r;
	}
}

