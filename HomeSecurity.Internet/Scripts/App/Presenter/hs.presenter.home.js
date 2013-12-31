/// <reference path="../../_references.js" />

define("hs.presenter.home", ["jquery", "ko", "hs.helper.common", "hs.helper.home", "hs.helper.router", "hs.helper.ui"], function ($, ko, common, home, router, ui) {
    var         
        transitionOptions = {
            ease: 'swing',
            fadeOut: 100,
            floatIn: 500,
            offsetLeft: '20px',
            offsetRight: '-20px'
        },

        displayView = function ($view, route, group) {

            $('.view').hide();

            var $activeViews = $('.view-active');

            common.toggleActivity(true);

            if ($activeViews.length) {
                $activeViews.fadeOut(transitionOptions.fadeOut, function () {
                    resetViews();
                    entranceThemeTransition($view);
                });
                $('.view').removeClass('view-active');
            } else {
                resetViews();
                entranceThemeTransition($view);
            }

            highlightActiveView(route, group);

            common.toggleActivity(false);
        },

        routeData = [
            {
                view: common.viewIds.pictures,
                routes: [
                    {
                        isDefault: true,
                        route: common.routes.pictures,
                        callback: displayView,
                        title: 'Pictures',
                        group: 'route-left'
                    }
                ]
            },

            {
                view: common.viewIds.videos,
                routes: [
                    {
                        isDefault: false,
                        callback: displayView,
                        route: common.routes.videos,
                        title: 'Videos',
                        group: 'route-left'
                    }
                ]
            }
        ],

        entranceThemeTransition = function ($view) {
            $view.css({
                display: 'block',
                visibility: 'visible'
            }).addClass('view-active').animate({
                marginRight: 0,
                marginLeft: 0,
                opacity: 1
            }, transitionOptions.floatIn, transitionOptions.ease);
        },

        highlightActiveView = function (route, group) {
            // Reset top level nav links
            // Find all NAV links by CSS classname 
            var $group = $(group);
            if ($group) {
                $(group + '.route-active').removeClass('route-active');
                if (route) {
                    // Highlight the selected nav that matches the route
                    $group.has('a[href="' + route + '"]').addClass('route-active');
                }
            }
        },

        resetViews = function () {
            $('.view').css({
                marginLeft: transitionOptions.offsetLeft,
                marginRight: transitionOptions.offsetRight,
                opacity: 0
            });
        },

        loadModel = function () {
            home.createHomeModel(0, 10, 0, 10);            
        },

        loadRouter = function () {            
            router.registerRoutes(routeData);            
            router.run();
        },

        loadUI = function () {
            ui.run();
        }

        run = function () {
            common.toggleActivity(!0), $.when(loadModel())
            .done(loadUI())
            .done(loadRouter())            
            .always(function () {
                common.toggleActivity(!1)
            })
        }
    return {
        run: run        
    }
});