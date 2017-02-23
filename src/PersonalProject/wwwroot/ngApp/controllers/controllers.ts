namespace PersonalProject.Controllers {

    export class HomeController {
        public remixes;
        constructor($http: ng.IHttpService) {
            $http.get(`/api/remixes/public`).then((response) => {
                this.remixes = response.data;
            })
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
        public genre;
        public adminDelete(id: number) {
            this.$http.delete(`/api/remixes/` + id).then((res) => {
                this.$state.reload();
            })
        }
        public adminDeleteGenre(id: number) {
            this.$http.delete(`/api/genres/` + id).then((res) => {
                this.$state.reload();
            })
        }

        public adminAddGenre() {
            this.$http.post(`/api/genres`, this.genre).then(() => {
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

    export class AdminEditGenreController {

        public remix;
        public genre;

        public editGenre() {
            this.$http.post(`/api/genres`, this.genre).then((response) => {
                this.$state.go(`adminDashboard`);
            })
        }



        constructor(private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService) {

            let gId = $stateParams[`id`];
            $http.get(`/api/genres/` + gId).then((response) => {
                this.genre = response.data;
            })
            $http.get(`/api/remix`).then((response) => {
                this.remix = response.data;
            })
        }
    }

}
