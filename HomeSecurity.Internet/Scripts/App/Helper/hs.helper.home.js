define('hs.helper.home', ["jquery", "amplify", "hs.helper.common", "hs.helper.router", "hs.viewmodel.homemodel"], function ($, amplify, common, router, model) {

    var

    init = function () {
        amplify.request.define('pictures', 'ajax', {
            url: '/api/Picture?skip={skip}&count={count}',
            dataType: 'json',
            type: 'GET'
        }),

        amplify.request.define('videos', 'ajax', {
            url: '/api/Video?skip={skip}&count={count}',
            dataType: 'json',
            type: 'GET'
        });
    },

    createHomeModel = function (picSkip, picCount, videoSkip, videoCount) {
        return $.Deferred(function (e) {
            var data = {
                pictures: null,
                videos: null
            };

            $.when(getMedia(data, picSkip, picCount, videoSkip, videoCount))
            .fail(function () {
                e.reject()
            }).done(function () {
                e.resolve()
            })

        }).promise()
    },

    //#region Get Methods

    getMedia = function (data, picSkip, picCount, videoSkip, videoCount) {
        common.entityMap(getPictures, model.bindPictures, { skip: picSkip, count: picCount });
        common.entityMap(getVideos, model.bindVideos, { skip: videoSkip, count: videoCount });
    },

    getPictures = function (callbacks, params) {
        return amplify.request({
            resourceId: 'pictures',
            data: { skip: params.skip, count: params.count },
            success: callbacks.success
        });
    },

    getVideos = function (callbacks, params) {
        return amplify.request({
            resourceId: 'videos',
            data: { skip: params.skip, count: params.count },
            success: callbacks.success
        });
    },

    //#endregion 

    addPicture = function (picture) {
        model.addPicture(picture);
    },

    addVideo = function (video) {
        model.addVideo(video);
    },

    deletePicture = function (picture) {
        model.deletePicture(picture);
    },

    deleteVideo = function (video) {
        model.deleteVideo(video);
    }

    getModel = function () {
        return model;
    }

    init();

    return {
        createHomeModel: createHomeModel,
        getModel: getModel,
        addPicture: addPicture,
        addVideo: addVideo,
        deletePicture: deletePicture,
        deleteVideo: deleteVideo
    }
});