define("hs.helper.media", ["jquery", "ko", "hs.helper.common"], function ($, ko, common) {

    var 

    addMedia = function (data, callback) {
        $.ajax({
            type: "POST",
            url: "/api/upload",
            contentType: false,
            processData: false,
            data: data,
            success: callback
            }
        );        
    },

    updateMedia = function (data, callback) {
        $.ajax({
            type: "PUT",
            url: "/api/media",
            contentType: "application/json; charset=utf-8",
            data: ko.toJSON(data),
            success: callback
            }
        );
    },

    deleteMedia = function (data, callback) {
        $.ajax({
            type: "DELETE",
            url: "/api/media",
            contentType: "application/json; charset=utf-8",            
            data: ko.toJSON(data),
            success: callback
            }
        );
    }

    return {
        addMedia: addMedia,
        updateMedia: updateMedia,
        deleteMedia: deleteMedia
    }
});
