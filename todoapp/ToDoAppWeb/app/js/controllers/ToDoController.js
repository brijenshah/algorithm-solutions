(function () {
    "use strict";

    angular
        .module("app")
        .controller("toDoController", toDoController);

    toDoController.$inject = ["$scope", "toDoService"];

    function toDoController($scope, toDoService) {

        $scope.itemCount = 0;

        $scope.get = function () {

            $scope.loading = true;

            toDoService.getItems()
                .then(function (res) {
                    $scope.itemCount = res.data.length;
                    $scope.items = res.data;
                    $scope.loading = false;
                })
                .catch(function (reason) {
                    console.log(reason);
                    $scope.loading = false;
                });
        };

        $scope.add = function () {
            toDoService.add($scope.itemCount, $scope.itemText)
            .then(function (res) {
                $scope.itemText = "";
                $scope.get();
            });
        };

        $scope.complete = function (item) {
            toDoService.complete(item)
                .then(function (res) {
                    $scope.get();
                });
        };

        $scope.get();
    }

})();