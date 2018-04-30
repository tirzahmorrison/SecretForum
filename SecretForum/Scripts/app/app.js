const app = angular.module('NewsApp', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Scripts/app/Views/Dashboard.html',
        controller: 'otherController'
    });

    $routeProvider.when('/create', {
        templateUrl: '/Scripts/app/Views/CreateStory.html',
        controller: 'createStoryController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});

app.controller('dashboardController' , ['$scope', '$http', function ($scope, $http) {
    console.log('Apples')
}]);

app.controller('createStoryController', ['$scope', '$http', function ($scope, $http) {
    console.log('Bananas')
}]);
