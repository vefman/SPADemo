define("hs.presenter.addmedia", ["jquery", "ko", "hs.helper.common", "hs.helper.home", "hs.helper.media", "hs.viewmodel.addmediamodel"], function ($, ko, common, home, media, model) {

    function dragEnter(evt) {        
        evt.stopPropagation();
        evt.preventDefault();
        $(evt.target).addClass('over');
    }

    function dragLeave(evt) {
        evt.stopPropagation();
        evt.preventDefault();
        $(evt.target).removeClass('over');
    }

    function drop(evt) {        
        evt.stopPropagation();
        evt.preventDefault();
        $(evt.target).removeClass('over');

        var files = evt.originalEvent.dataTransfer.files;

        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (i = 0; i < files.length; i++) {
                    data.append("images[]", files[i]);
                }                
                media.addMedia(data, addMediaCallBack);                                   
            }
        }
    }

    function addMediaCallBack(result) {
        $.each(result, function (i, item) {
            model.uploads.push(item);
            if (item.MediaType == 'P') {
                home.addPicture(item);
            }
            else if (item.MediaType == 'V') {
                home.addVideo(item);
            }
        });
    }

    function bind() {
        var $box = $("#add-media-view");

        $box.bind("dragenter", dragEnter);
        $box.bind("dragleave", dragLeave);
        $box.bind("drop", drop);
    }

    function init() {
        $("#add-media-view").dialog({
            autopen: false,
            height: 300,
            width: 350,
            modal: true,
            buttons: {
                "Close": function () {
                    $(this).dialog("close");
                }
            }
        });
        bind();
        $("#add-media-view").dialog("open");
    }        

    var run = function () {
        init();
    }    

    return {
        run: run
    }
});