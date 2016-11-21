namespace WeatherApp.Controllers {

    export class HomeController {
        public WeatherResource;
        public weather;

        public getWeather() {
            this.weather = this.WeatherResource.query();
            console.log(this.weather);
        }

        constructor($resource: angular.resource.IResourceService) {
            this.WeatherResource = $resource(`/api/weather`);
            this.getWeather();
        }
    }

    //Add Weather Controller
    export class AddWeatherController {
        public weather;
        public WeatherResource;
        //public file;

        public saveWeather() {
            this.WeatherResource.save(this.weather).$promise.then(() => {
                this.weather = null;
                this.$state.go(`home`);
            })
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService, private $scope: ng.IScope, private filepickerService) {
            this.WeatherResource = this.$resource(`/api/weather`);
        }

        //public pickFile() {
        //    this.filepickerService.pick(
        //        {
        //            mimetype: `image/*`,
        //            imageQuality: 60
        //        },
        //        this.fileUploaded.bind(this)
        //    );
        //}

        //public fileUploaded(file) {
        //    //save file url to database
        //    this.file = file;
        //    console.log(this.file);
        //    console.log(this);
        //    this.weather["item"] = this.file.url;
        //    console.log(this.weather);
        //    this.$scope.$apply();  //force page to update
        //}
    }
        //Edit Weather Controller
    export class EditWeatherController {
         public weather;
         public WeatherResource;

         public getWeather(id: number) {
             this.weather = this.WeatherResource.get({ id: id });
         }
         //POST the movie after making changes
         public saveWeather() {
             this.WeatherResource.save(this.weather).$promise.then(() => {
                 this.weather = null;
                 this.$state.go(`home`);
             })
         }
         constructor(private $resource: angular.resource.IResourceService, public $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
             this.WeatherResource = $resource(`/api/weather/:id`);
             this.getWeather($stateParams[`id`]);
         }
    }

    //Delete Weather Controller
    export class DeleteWeatherController {
        public weather;
        public WeatherResource;

        public getWeather(id: number) {
            this.weather = this.WeatherResource.get({ id: id });
        }

        public deleteWeather() {
            this.WeatherResource.delete({ id: this.weather.id }).$promise.then(() => {
                this.weather = null;
                this.$state.go(`home`);
            })
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.WeatherResource = $resource(`api/weather/:id`);
            this.getWeather($stateParams[`id`]);
        }
    }


    //export class SecretController {
    //    public secrets;

    //    constructor($http: ng.IHttpService) {
    //        $http.get('/api/secrets').then((results) => {
    //            this.secrets = results.data;
    //        });
    //    }
    //}

    export class ProfileController {
        public weather;
        public WeatherResource;

        public getWeather(id: number) {
            this.weather = this.WeatherResource({ id: id })
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.WeatherResource = $resource(`api/weather/:id`);
            this.getWeather($stateParams[`id`]);
        }
    }

    export class AboutController {
        public message = 'Weather Share is a community where you can post and share current conditions around the country or in your area. Just register and start sharing now! You can also browse to find out where the sunshine or other weather that fancies your interests!';
    }

}
