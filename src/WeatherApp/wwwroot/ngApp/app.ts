namespace WeatherApp {

    angular.module('WeatherApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular-filepicker']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        filepickerProvider) => {
        filepickerProvider.setKey(`Ay6rDlAOGReSSGb7Fq4B4z`)
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: WeatherApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state(`addWeather`, {
                url: `/addWeather`,
                templateUrl: `/ngApp/views/addWeather.html`,
                controller: WeatherApp.Controllers.AddWeatherController,
                controllerAs: `controller`
            })
            .state(`editWeather`, {
                url: `/editWeather/:id`,
                templateUrl: `/ngApp/views/editWeather.html`,
                controller: WeatherApp.Controllers.EditWeatherController,
                controllerAs: `controller`
                requireLogin: true
            })
            .state(`deleteWeather`, {
                url: `/deleteWeather/:id`,
                templateUrl: `/ngApp/views/deleteWeather.html`,
                controller: WeatherApp.Controllers.DeleteWeatherController,
                controllerAs: `controller`
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: WeatherApp.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: WeatherApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: WeatherApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: WeatherApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: WeatherApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('WeatherApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('WeatherApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
