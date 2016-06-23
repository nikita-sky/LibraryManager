module LM 
{
    export class BooksPage {
        static $inject = [];
        static factory(): angular.IComponentOptions {
            const component: angular.IComponentOptions = {
                controllerAs: "vm",
                controller: BooksPage,
                templateUrl: "/content/html/pages/books.html",
                require: {
                    rootPage: `^${RootPage.$name}`
                }
            };
            return component;
        }


    }
}