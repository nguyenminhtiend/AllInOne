//app.directive('customMessi', function () {
//    var directive = {};

//    directive.restrict = 'E';

//    directive.template = "User : {{user.firstName}} {{user.lastName}}";

//    directive.scope = {
//        user: "=user"
//    }

//    return directive;
//});


(function () {

    var directive = function () {
        return {
            restrict : 'EA',
            template : "User 11: {{user.firstName}} {{user.lastName}}",
            scope : {
                user: "=user"
            }
        };
    };

    angular.module('appModule')
        .directive('customMessi', directive);

}());