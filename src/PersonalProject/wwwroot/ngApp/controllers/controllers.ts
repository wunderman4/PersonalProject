namespace PersonalProject.Controllers {

    export class HomeController {
        public remixes;
        constructor($http: ng.IHttpService) {
            $http.get(`/api/remixes/public`).then((response) => {
                this.remixes = response.data;
            })
        }
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class AddRemixController {
        public remix;
        public genres;

        public addRmxRequest() { // help! 
            this.$http.post(`/api/remixes`, this.remix).then((response) => {
                this.$state.go(`home`);
            })
        }
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProject.Services.AccountService) {
            

            $http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
