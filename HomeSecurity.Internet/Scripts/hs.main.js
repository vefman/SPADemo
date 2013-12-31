require.config({
    paths: {
        baseUrl: 'Scripts'
    }
});

requirejs([],
function ($) {
    var root = this;
    define3rdPartyModules();
    loadPluginsAndBoot();

    function define3rdPartyModules() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        define('jquery', [], function () { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('amplify', [], function () { return root.amplify; });
        define('sammy', [], function () { return root.Sammy; });
    }

    function loadPluginsAndBoot() {
        // Plugins must be loaded after jQuery and Knockout, 
        // since they depend on them.
        requirejs([                              
        ], boot);
    }

    function boot() {
        require(['hs.presenter.home'], function (presenter) { presenter.run(); });
    }
});