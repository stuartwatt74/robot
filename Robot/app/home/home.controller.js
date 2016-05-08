(function () {
    'use strict';

    angular.module('app').controller('HomeController', homeController);

    homeController.$inject = ['$scope', 'HubService'];

    function homeController($scope, hubService) {

        var vm = this;
        
        vm.model = null;

        hubService.receiveMessage($scope, 'test-display-update', function (event, args) {
            vm.model = args;
            vm.time = args.Time
            $scope.$apply();
        });

        vm.reset = function () {
            hubService.sendMessage({
                EventName: "reset",
            });
        };
    }

}());