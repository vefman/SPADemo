define("hs.helper.ui", ["jquery", "ko", "hs.helper.common", "hs.presenter.addmedia", "hs.presenter.editmedia", "hs.presenter.deletemedia"], function ($, ko, common, addMediaPresenter, editMediaPresenter, deleteMediaPresenter) {
    
    var topMenu = {
        pictures: ko.observable(common.routes.pictures),
        videos: ko.observable(common.routes.videos)                
    };

    var commandMenu = {
        addMedia: function (data, event) {
            addMediaPresenter.run();
        },
        deleteMedia: function (data, event) {
            deleteMediaPresenter.run();
        }
    };

    var editMedia = function (media) {
        editMediaPresenter.run(media);
    };

    var run = function () {
        ko.applyBindings(topMenu, common.getView(common.viewIds.top));
        ko.applyBindings(commandMenu, common.getView(common.viewIds.command));        
    };
    
    return {
        run: run,
        editMedia: editMedia
    }
});