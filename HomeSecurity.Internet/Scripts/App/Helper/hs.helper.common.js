define("hs.helper.common", ["jquery"], function ($) {
    var 
        title = 'HomeSecurity > ',

        toggleActivity = function (e) {
            $("#busyindicator").activity(e)
        },

        routes = {
            pictures: '#/pictures',
            videos: '#/videos',

            getCurrentRoute : function(){
                return window.location.hash;
            }
        },

        viewIds = {
            top: '#top-view',
            command: '#command-view',
            pictures: '#pictures-view',
            videos: '#videos-view',
            addMedia: '#add-media-view',
            editMedia: '#edit-media-view'
        },

        getView = function (viewName) {
            return $(viewName).get(0);
        };

        entityMap = function (getMethod, bindMethod, params) {
            getMethod({
                success: function (data) {
                    bindMethod(data)
                }
            }, params);
        }    

    return {
        title: title,
        toggleActivity: toggleActivity,
        entityMap: entityMap,
        viewIds: viewIds,
        routes: routes,
        getView: getView        
    }
});