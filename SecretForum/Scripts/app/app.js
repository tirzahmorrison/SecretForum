﻿const app = angular.module('NewsApp', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Scripts/app/Views/Dashboard.html',
        controller: 'dashboardController'
    });

    $routeProvider.when('/create', {
        templateUrl: '/Scripts/app/Views/CreateStory.html',
        controller: 'createStoryController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});

app.controller('dashboardController' , ['$scope', '$http', function ($scope, $http) {

    const init = () => {
        $scope.categories = [];

        $http({
            method: 'GET',
            url: '/api/categories'
        })
            .then(response => response.data)
            .then(data => $scope.categories = data);
    };

    init();

}]);

app.controller('createStoryController', ['$scope', '$http', function ($scope, $http) {
    console.log('Bananas')
}]);