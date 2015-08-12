(function () {
    var app = angular.module('app');
    app.controller('aCtrl', ['asvc', function (asvc) {
        var scope = this;
        scope.accounts = [];
        scope.id = {
            HId: 6,
        };

        scope.getAccounts = function () {
            asvc.getAccounts(scope.id).then(function (response) {
                scope.accounts = response
            })
            console.log("accounts: " + scope.accounts);
        }
        scope.getAccounts();
    }]);
})();