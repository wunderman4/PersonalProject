namespace PersonalProject {

    angular.module('PersonalProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: PersonalProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: PersonalProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: PersonalProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: PersonalProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: PersonalProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state(`addRemixRequest`, {
                url: `/addRemixRequest`,
                templateUrl: `/ngApp/views/registeredViews/remixRequest.html`,
                controller: PersonalProject.Controllers.AddRemixController,
                controllerAs: `controller`
            })
            .state(`userDashboard`, {
                url: `/userDashboard`,
                templateUrl: `/ngApp/views/registeredViews/userDashboard.html`,
                controller: PersonalProject.Controllers.UserDashboardController,
                controllerAs:`controller`
            }) 
            .state(`editRemixRequest`, {
                url: `/editRemixRequest/:id`,
                templateUrl: `/ngApp/views/registeredViews/editRemix.html`,
                controller: PersonalProject.Controllers.EditRemixController,
                controllerAs: `controller`
            })
            .state('aboutRemix', {
                url: '/aboutRemix/:id',
                templateUrl: '/ngApp/views/aboutRemix.html',
                controller: PersonalProject.Controllers.AboutRemixController,
                controllerAs: 'controller'
            })
            .state(`adminDashboard`, {
                url: `/adminDashboard`,
                templateUrl: `/ngApp/views/adminViews/adminDashboard.html`,
                controller: PersonalProject.Controllers.AdminDashboardController,
                controllerAs:`controller`
            })
            .state(`adminEditRemix`, {
                url: `/adminEditRemix/:id`,
                templateUrl: `/ngApp/views/adminViews/adminEditRemix.html`,
                controller: PersonalProject.Controllers.AdminEditRemixController,
                controllerAs:`controller`
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

    
    angular.module('PersonalProject').factory('authInterceptor', (
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

    angular.module('PersonalProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
