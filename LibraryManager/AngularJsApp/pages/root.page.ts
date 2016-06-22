module LM
{
    export class RootPage {
        public static $inject = ["$document", "$mdSidenav", "$mdToast", "$timeout"];
        public static $name = "rootPage";
        public static factory(): angular.IComponentOptions {
            return {
                controllerAs: "vm",
                controller: RootPage,
                templateUrl: "/content/html/pages/root.html"
            }
        }

        constructor(
            private $document: angular.IDocumentService,
            private $mdSidenav: angular.material.ISidenavService,
            private $mdToast: angular.material.IToastService,
            private $timeout: angular.ITimeoutService)
        { }

        private _title: string;
        private _isBusy: boolean = false;
        private _indicator: angular.IPromise<any>;

        set title(value: string) {
            this._title = value;
            this.$document.title = "Library Manager - " + this._title;
        }

        set isBusy(value: boolean) {
            if (this._isBusy === value)
                return;

            this._isBusy = value;
            if (!this.isBusy)
                this.hideIndicator();
        }

        showBusyIndicator(message: string = null) {
            this._isBusy = true;
            message = message || "Загрузка...";
            var toast: angular.material.IToastOptions = {
                hideDelay: 0,
                template: [
                    '<md-toast>',
                        '<md-progress-circular class="md-warn" md-diameter="40">',
                        '</md-progress-circular>',
                        '<span class="md-toast-text">',
                            message,
                        '</span>',
                    '</md-toast>'
                ].join(""),
                position: "bottom left"
            };
            this._indicator = this.$mdToast.show(toast);
        }

        notify(message: string): angular.IPromise<any> {
            if (!message || !message.length)
                return;

            this.isBusy = false;
            return this.$mdToast.showSimple(message);
        }

        openMenu(sidenavId: string) {
            this.$mdSidenav(sidenavId).open();
        }

        private hideIndicator() {
            if (!this._indicator)
                return;

            this.$timeout(() => this.$mdToast.hide(this._indicator), 150);
            this._indicator = null;
        }
    }
}