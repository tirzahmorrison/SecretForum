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

    $routeProvider.when('/stories/:id', {
        templateUrl: '/Scripts/app/Views/StoryPage.html',
        controller: 'viewStoryController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});

app.controller('dashboardController', ['$scope', '$http', function ($scope, $http) {
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

    const init = () => {
        $scope.categories = [];
        $scope.story = {};

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
            });

        $scope.postStory = () => {
            console.warn('Not yet implemented!');
            console.log('Would post', $scope.story);

            // Check if object can be pushed
            //const story = $scope.story;
            //if (!story.tagline
            //    || !story.body
            //    || !story.category) {
            //    // TODO: Decided to not add user validation yet
            //}

            $http({
                method: 'POST',
                url: '/api/story',
                data: JSON.stringify($scope.story)
            })
                .then(response => {
                    if (response === 200) {
                        return data;
                    }
                    else {
                        console.error('Bad response');
                    }
                })
                .then(data => {
                    window.location = `/stories/${data.ID}`
                });

        };
    };

    init();

}]);

app.controller('viewStoryController', ['$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {
    console.log('oranges')
    $http({
        method: "GET",
        url: `/api/story/${$routeParams.id}`
    }).then(resp => {
        $scope.story = resp.data
    })
}]);