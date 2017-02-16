namespace PersonalProject.Controllers {

    export class HomeController {
        public remixes;
        constructor($http: ng.IHttpService) {
            $http.get(`/api/remixes`).then((response) => {
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


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
