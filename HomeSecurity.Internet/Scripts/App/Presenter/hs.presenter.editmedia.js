define("hs.presenter.editmedia", ["jquery", "ko", "hs.helper.common", "hs.helper.home", "hs.helper.media"], function ($, ko, common, home, mediaHelper) {

    var clone, med;

    function init(media) {

        med = media;

        $("#edit-media-view").dialog({
            autopen: false,
            height: 400,
            width: 800,
            modal: true,
            buttons: {                
                "Save": function () {
                    mediaHelper.updateMedia(clone, updateMediaCallback);
                    $(this).dialog("close");
                },
                "Close": function () {
                    $(this).dialog("close");
                }
            }
        });

        clone = med.clone();

        ko.applyBindings(clone, common.getView(common.viewIds.editMedia));

        $("#edit-media-view").dialog("open");
    }

    function updateMediaCallback() {
        med.description(clone.description());
    }

    var run = function (media) {
        init(media);
    }

    return {
        run: run
    }
})