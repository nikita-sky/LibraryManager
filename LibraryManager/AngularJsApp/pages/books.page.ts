module LM 
{
    export class BooksPage {
        public static $inject = [];
        public static factory(): angular.IComponentOptions {
            var component: angular.IComponentOptions = {
                controllerAs: "vm",
                controller: BooksPage,
                templateUrl: "/content/html/pages/books.html",
                require: {
                    rootPage: "^" + RootPage.$name
                }
            };
            return component;
        }

        
    }
}