/// <reference path="./pages/root.page.ts"/>

module LM
{
    const moduleName = "lm.app";

    angular.module(moduleName, ["ngMaterial", "ngRoute", "md.data.table"])
        .component(RootPage.$name, RootPage.factory());
}