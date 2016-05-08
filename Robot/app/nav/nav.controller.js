(function () {
    'use strict';

    angular.module('app').controller('NavController', navController);

    navController.$inject = ['$state'];

    function navController($state) {

        var vm = this;

        vm.selectState = function (name) {
            $state.go(name);
        };

    }

}());