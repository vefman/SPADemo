/// <reference path="../../Reference/_references.js" />

define("hs.viewmodel.homemodel", ["jquery", "ko", "hs.helper.common", "hs.viewdata.pictureviewdata", "hs.viewdata.videoviewdata"], function ($, ko, common, pictureView, videoView) {

    var
        self = this;
       
        self.pictures = ko.observableArray();
        self.videos = ko.observableArray();                    

        self.bindPictures = function (data) {
            $.each(data, function (key, picture) {
                var pictureViewData = new pictureView.pictureViewData(picture);
                pictures.push(pictureViewData);
            });

            ko.applyBindings(self, common.getView(common.viewIds.pictures));
        }

        self.bindVideos = function (data) {
            $.each(data, function (key, video) {
                var videoViewData = new videoView.videoViewData(video);
                videos.push(videoViewData);
            });

            ko.applyBindings(self, common.getView(common.viewIds.videos));
        }

        self.addPicture = function (picture) {
            var pictureViewData = new pictureView.pictureViewData(picture);
            pictures.push(pictureViewData);
        }

        self.addVideo = function (video) {
            var videoViewData = new videoView.videoViewData(video);
            videos.push(videoViewData);
        }

        self.deletePicture = function (picture) {
            pictures.remove(picture);
        }

        self.deleteVideo = function (video) {
            videos.remove(video);
        }

    return {
        bindPictures: bindPictures,
        bindVideos: bindVideos,
        addPicture: addPicture,
        addVideo: addVideo,
        deletePicture: deletePicture,
        deleteVideo: deleteVideo,
        pictures: pictures,
        videos: videos,
    };
});