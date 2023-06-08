(function () {
    "use strict";

    function contactrequestsController($scope, contactRequestsService) {

        var vm = this;
        vm.contactRequestsNumber = 0;
        vm.contactRequests = [];
        $scope.model.badge = { count: 0 };

        getTotalNumber();
        getContactRequests();

        function getTotalNumber() {
            contactRequestsService.getTotalNumber().then(function (number) {
                vm.contactRequestsNumber = number;
                $scope.model.badge = { count: number };
            })
        }

        function getContactRequests() {
            contactRequestsService.getAll().then(function (data) {
                vm.contactRequestsNumber = data;
            })
        }
    }

    angular.module("umbraco").controller("contactrequestsController", contactrequestsController);
})();