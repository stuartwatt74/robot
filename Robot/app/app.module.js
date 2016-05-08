(function () {
    'use strict';

    angular.module('app', [
        'ui.router',
        'ui.bootstrap',
    ]);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/home");

        $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: 'app/home/home.template.html',
            controller: 'HomeController as home',
        })
        .state('manual', {
            url: '/manual',
            templateUrl: 'app/manual/manual.template.html',
            controller: 'ManualController as manual',
        })
        .state('program', {
            url: '/program',
            templateUrl: 'app/program/program.template.html',
            controller: 'ProgramController as program',
        })
        .state('settings', {
            url: '/settings',
            templateUrl: 'app/settings/settings.template.html',
            controller: 'SettingsController as settings',
        })
    }

    angular.module('app').config(config);

}());