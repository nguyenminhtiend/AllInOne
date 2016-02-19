app.controller('projectController', function ($scope, projectService) {
   
    getAllProject();
        
    $scope.page = 0;
    $scope.rowsPerPage = 10;
    $scope.itemCount = 100;

    $scope.setPage = function (page) {
        if (page > $scope.pageCount) {
            return;
        }

        $scope.page = page;
    };

    $scope.nextPage = function () {
        if ($scope.isLastPage()) {
            return;
        }

        $scope.page++;
    };

    $scope.perviousPage = function () {
        if ($scope.isFirstPage()) {
            return;
        }

        $scope.page--;
    };

    $scope.firstPage = function () {
        $scope.page = 0;
    };

    $scope.lastPage = function () {
        $scope.page = $scope.pageCount - 1;
    };

    $scope.isFirstPage = function () {
        return $scope.page == 0;
    };

    $scope.isLastPage = function () {
        return $scope.page == $scope.pageCount - 1;
    };

    $scope.pageCountArray = function () {
        return new Array($scope.pageCount);
    };
    //To Get All Records  
    function getAllProject() {

        var promiseGet = projectService.getAllProject();
        $scope.jakob = {};
        $scope.jakob.firstName = "Jakob";
        $scope.jakob.lastName = "Jenkov";

        promiseGet.then(function (result) {
            $scope.projects = result.data.Projects;
            $scope.page = result.data.CurrentPage;
            $scope.pageCount = result.data.TotalPage;
                
            },
              function (error) {
                  $log.error('Some Error in Getting Records.', error);
              });
    }
});