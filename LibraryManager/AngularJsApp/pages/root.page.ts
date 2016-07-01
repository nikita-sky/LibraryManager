module LM
{
    export class RootPage {
        static $inject = ["$document", "$mdSidenav", "$mdToast", "$timeout"];
        static $name = "rootPage";
        static factory(): angular.IComponentOptions {
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
            private $timeout: angular.ITimeoutService) {
        }

        get sidenavId() { return "left" }

        private _isBusy = false;
        private _indicator: angular.IPromise<any>;

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
            const template = `<md-toast><md-progress-circular class="md-warn" md-mode="indeterminate" md-diameter="30"></md-progress-circular><span class="md-toast-text">${message}</span></md-toast>`;
            const toast: angular.material.IToastOptions = {
                hideDelay: 0,
                template: template,
                position: "bottom left"
            };
            this._indicator = this.$mdToast.show(toast);
        }

        notify(message: string): angular.IPromise<any> {
            if (!message || !message.length)
                return null;

            this.isBusy = false;
            return this.$mdToast.showSimple(message);
        }

        openMenu() {
            this.$mdSidenav("left").open();
        }

        private hideIndicator() {
            if (!this._indicator)
                return;

            this.$timeout(() => this.$mdToast.hide(this._indicator), 150);
            this._indicator = null;
        }
    }
}