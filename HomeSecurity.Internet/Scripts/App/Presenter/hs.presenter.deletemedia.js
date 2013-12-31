define("hs.presenter.deletemedia", ["jquery", "ko", "hs.helper.common", "hs.helper.home", "hs.helper.media"], function ($, ko, common, home, media) {
    
    var pics = [], videos = [];

    var run = function () {

        var ids = [], message;

        if (common.routes.getCurrentRoute() == common.routes.pictures) {
            var model = home.getModel();
            $.each(model.pictures(), function (key, picture) {
                if (picture.checked()) {
                    ids.push(picture.id() + ';' + picture.source());
                    pics.push(picture);
                }
            });

            message = 'Are you sure you want to delete the selected pictures?';
        }
        else {
            var model = home.getModel();
            $.each(model.videos(), function (key, video) {
                if (video.checked()) {
                    ids.push(video.id() + ';' + video.source());
                    videos.push(video);
                }
            });

            message = 'Are you sure you want to delete the selected videos?';            
        }

        if (confirm(message)) {
            media.deleteMedia(ids, deleteCallBack);
        }
    },

    deleteCallBack = function () {
        $.each(pics, function (key, pic) {
            home.deletePicture(pic);
        });
        $.each(videos, function (key, video) {
            home.deleteVideo(video);
        });
    }

    return {
        run: run
    }
});