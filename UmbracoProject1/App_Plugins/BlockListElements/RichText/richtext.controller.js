(function () {
    'use strict';


    richtextController.$inject = ['$scope'];
    console.log(11);

    function richtextController($scope) {
        console.log(12);
        console.log('scope');
        console.log($scope);
        //$scope.title = 'controller';
        var vm = this;
        vm.richtextContent = $scope.block.data.richText;

        // vm.settings = $scope.block?.settingsData;
        vm.backgroundColor = $scope.block?.settingsData?.backgroundColor?.value;

        $scope.$watch('block.data', function () {
            vm.richtextContent = $scope.block.data.richText;
        }, true);

        $scope.$watch('block.settingsData', function () {
            vm.backgroundColor = $scope.block?.settingsData?.backgroundColor?.value;
        }, true);

        //activate();

        //function activate() { }
    }

    angular
        .module('umbraco')
        .controller('richtextController', richtextController);
})();
