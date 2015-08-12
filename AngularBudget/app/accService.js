(function () {
    angular.module('app').factory('asvc', ['$http', '$q', function ($http, $q) {
        var service = {};

        service.getAccounts = function (id) {

            return $http.post('/api/Accounts/GetAccounts', id).then(function (response) {
                return response.data;
            });
        }

        //service.getUsers = function (id) {

        //    return $http.post('/api/Group/GetUsers', id).then(function (response) {
        //        return response.data;
        //    });
        //}

        return service;

    }])
})();