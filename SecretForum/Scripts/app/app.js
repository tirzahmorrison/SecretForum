const app = angular.module('NewsApp', ['ngRoute']);

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
    console.log('dashboardController');

    const init = () => {
        console.log('dashboardController > init');

        $scope.categories = [];

        $http({
            method: 'GET',
            url: '/api/categories'
        })
            .then(response => {
                console.log('Response for categories recieved');
                return response.data;
            })
            .then(data => {
                console.log(data);
                $scope.categories = data;
                return $scope.categories;
            })
            .then(categories => {
                categories.forEach(category => {
                    category.stories = [];
                    $http({
                        method: 'GET',
                        url: `/api/stories?category=${category.CategoryName}&count=5`
                    })
                        .then(response => {
                            console.log(`Response for stories for ${category.CategoryName} recieved`);
                            response.data
                        })
                        .then(data => {
                            console.log(data);
                            category.stories = data
                        });
                });
                    
            });
    };

    init();

}]);

app.controller('createStoryController', ['$scope', '$http', function ($scope, $http) {
    console.log('Bananas')
}]);
