

(function () {


    var app = angular.module('app', ['ui.router']);

    app.config(function ($stateProvider, $urlRouterProvider) {

        //$urlRouterProvider.otherwise('/home');

        $stateProvider

            .state('group', {

                templateUrl: 'group.html'
            })
            .state('dashboard', {
                templateUrl: 'dashboard.html'
            })
            .state('accounts', {
                templateUrl: 'accounts.html'
            })
            .state('accounts.create', {
                //url: '/list',
                templateUrl: 'accounts-create.html'
            })
            .state('accounts.edit', {
                templateUrl: 'accounts-edit.html'
            })
            .state('transactions', {
                templateUrl: 'transactions.html'
            })
            .state('budgetItems', {
                templateUrl: 'budgetItems.html'
            })
            .state('budget', {
                templateUrl: 'budget.html'
            });

    });
})();