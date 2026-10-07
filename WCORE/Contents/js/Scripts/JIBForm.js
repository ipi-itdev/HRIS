function JIBForm(DetailViewURL, pID) {
    this.open = function (callerlistview) {
        var $content = $('#' + pID);
        $content.html('');
        $content.off('OnDetailViewSaved').on('OnDetailViewSaved', function (event, pkey) {
            callerlistview.Refresh(pkey);
        });
        $content.load(DetailViewURL);      
    }
}
