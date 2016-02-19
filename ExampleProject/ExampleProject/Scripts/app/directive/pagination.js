(function () {

    var directive = function () {
        return {
            restrict: 'EA',
            template: "User 11: {{user.firstName}} {{user.lastName}}",
            scope: {
                user: "=user"
            }
        };
    };

    angular.module('appModule')
        .directive('pagination', directive);

}());