define("hs.viewmodel.addmediamodel", ["jquery", "ko", "hs.helper.common"], function ($, ko, common) {
    var self = this;

    self.uploads = ko.observableArray();

    function init() {
        ko.applyBindings(self, common.getView(common.viewIds.addMedia));        
    }

    init();

    return {
        uploads: uploads
    }
});