define("hs.viewdata.videoviewdata", ["jquery", "ko", "hs.helper.common"], function ($, ko, helper) {

    videoViewData = function (video) {
        var self = this;

        id = ko.observable(video.ID);
        self.source = ko.observable(video.Media);
        self.poster = ko.observable(video.Poster);
        self.timeStamp = ko.observable(video.DateCreated),
        self.description = ko.observable(video.Desciption);
        self.checked = ko.observable(false);
    };

    return {
        videoViewData: videoViewData
    };
});