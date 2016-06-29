/// <reference path="./root.page.ts"/>

module LM
{
    export abstract class Page {
        constructor(private $mdSidenav: angular.material.ISidenavService)
        { }

        protected openSidenav(sidenavId: string) {
            this.$mdSidenav(sidenavId).open();
        }

        protected closeSidenav(sidenavId: string) {
            this.$mdSidenav(sidenavId).close();
        }

        protected rootPage: RootPage;

        abstract $onInit();

        protected notify(message: string) {
            if (!this.rootPage)
                return;
            this.rootPage.notify(message);
        }
    }
}