define('hs.helper.router', ['jquery', 'sammy', 'ko', 'hs.helper.common'], function ($, Sammy, ko, common) {

    var 
        defaultRoute = '',
        startupUrl = '',

        sammy = new Sammy.Application(function () {
            if (Sammy.Title) {
                this.use(Sammy.Title);
                this.setTitle(common.title);
            }            
        }),

        navigateBack = function () {
            window.history.back();
        },

        navigateTo = function (url) {
            sammy.setLocation(url);
        },

        register = function (options) {
            if (options.routes) {                
                $.each(options.routes, function (key, route) {
                    registerRoute({
                        route: route.route,
                        title: route.title,
                        callback: route.callback,
                        view: options.view,
                        group: route.group,
                        isDefault: !!route.isDefault
                    });
                });
                return;
            }
            else {
                registerRoute(options);
            }
        },

        registerRoute = function (options) {

            if (options.isDefault) {
                defaultRoute = options.route;
            }

            sammy.get(options.route, function (context) {                

                if (options.callback) {
                    options.callback($(options.view), context.path, options.group);
                }                                

                if (this.title) {
                    this.title(options.title);
                }
            });
        },        

        registerRoutes = function (routeData) {            
            for (var i = 0; i < routeData.length; i++) {
                register(routeData[i]);
            }                        
        },        

        run = function () {
            startupUrl =  defaultRoute;

            if (!startupUrl) {
                return;
            }

            sammy.run(startupUrl);            
        };

    return {
        navigateBack: navigateBack,
        navigateTo: navigateTo,
        register: register,
        registerRoutes: registerRoutes,
        run: run
    };
})