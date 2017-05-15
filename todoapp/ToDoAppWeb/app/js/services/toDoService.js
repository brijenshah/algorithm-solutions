(function () {
    "use strict";

    angular
        .module("app")
        .factory("toDoService", toDoService);

    toDoService.$inject = ["$http"];

    function toDoService($http) {

        var service = {
            getItems: getItems,
            add: add,
            complete: complete
        };

        return service;

        function getItems() {
            return $http.get(apiPath + "/ToDoItems");
        }

        function add(id, task) {
            return $http.post(apiPath + "/ToDoItems", { "Id": id + 1, "Text": task, "Complete": false });
        }

        function complete(item) {
            return $http.put(apiPath + "/ToDoItems", { "Id": item.Id, "Text": item.Text, "Complete": true });
        }
    }
})();