define("hs.viewdata.pictureviewdata", ["require", "jquery", "ko", "hs.helper.common"], function (require, $, ko, common) {    

    self.pictureViewData = function (picture) {
        var self = this;

        self.id = ko.observable(picture.ID);
        self.source = ko.observable(picture.Media),
        self.timeStamp = ko.observable(picture.DateCreated),
        self.description = ko.observable(picture.Description);
        self.checked = ko.observable(false);        

        self.editPicture = function () {
            ui = require("hs.helper.ui");
            ui.editMedia(this);
        };

        self.clone = function () {

            var result = new Object();

            result.id = ko.observable(this.id());
            result.source = ko.observable(this.source());
            result.timeStamp = ko.observable(this.timeStamp());
            result.description = ko.observable(this.description());

            return result;
        };
    };       

    return {
        pictureViewData: pictureViewData        
    };
});