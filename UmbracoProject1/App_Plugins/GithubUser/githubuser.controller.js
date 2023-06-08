(function () {
    "use strict";

    function githubuserController($scope) {

        if ($scope.model.value === null || $scope.model.value === "" || $scope.model.value === "umbraco") {
            $scope.model.value = {
                githubUsername: "",
                githubPreferredLanguage: ""
            }
        }
    }

    angular.module("umbraco").controller("githubuserController", githubuserController);
})();