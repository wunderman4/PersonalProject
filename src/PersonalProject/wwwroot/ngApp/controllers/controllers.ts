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

        public addRmxRequest() {
            this.$http.post(`/api/remixes`, this.remix).then((response) => {
                this.$state.go(`userDashboard`);
            })
        }
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProject.Services.AccountService) {
            

            $http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })
        }
    }

    export class UserDashboardController {
        public message = `Welcome to your Dashboard`;
        public remixes;

        public deleteRemix(id:number) {
            this.$http.delete(`/api/remixes/` + id).then(() => {
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get(`/api/remixes`).then((response) => {
                this.remixes = response.data;
            })
        }
    }

    export class EditRemixController {
        public remix;
        public genres;

        public editRmxRequest() {
            this.$http.post(`/api/remixes`, this.remix).then((response) => {
                this.$state.go(`userDashboard`);
            })
        }

        constructor(private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService) {

            let rmxId = $stateParams[`id`];
            $http.get(`/api/remixes/` + rmxId).then((response) => { 
                this.remix = response.data;
            }) 
            $http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })
        }
    }

    export class AboutRemixController {
        public remix;
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {

            let rmxId = $stateParams[`id`];
            $http.get(`/api/remixes/public/` + rmxId).then((response) => {
                this.remix = response.data;
            })
        }
    }

    export class AdminDashboardController {
        public remixes;
        public genres;
        public adminDelete(id: number) {
            this.$http.delete(`/api/remixes/` + id).then((res) => {
                this.$state.reload();
            })
        }
        
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get(`/api/remixes/admin`).then((response) => {
                this.remixes = response.data;
            })
            $http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })
        }
    }

    export class AdminEditRemixController {
        public remix;
        public genres;

        public editRmxRequest() {
            this.$http.post(`/api/remixes`, this.remix).then((response) => {
                this.$state.go(`adminDashboard`);
            })
        }

        constructor(private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService) {

            let rmxId = $stateParams[`id`];
            $http.get(`/api/remixes/` + rmxId).then((response) => {
                this.remix = response.data;
            })
            $http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })
        }
    }

}
