angular
    .module("Application", [])
    .controller("AppCtrl", function ($scope, $http) {
        $scope.isLoading = false;

        $scope.GetDrives = function () {
            var url = "/api/App";
            get(url, false);
        }

        $scope.GetDirectory = function (path) {
            if (path === '') {
                $scope.GetDrives();
            } else {
                var url = "/api/App?path=" + encodeURIComponent(path);
                get(url, true);
            }
        }

        function get (url, showParent) {
            $scope.isLoading = true;
            $http.get(url).success(function (response) {
                $scope.counter = response.Counter;
                $scope.files = response.Files;
                $scope.directories = response.Directories;
                $scope.parent = response.ParentNode;
                $scope.path = response.Path;

                if (showParent) {
                    $("#parent").show();
                } else {
                    $("#parent").hide();
                }

                $scope.isLoading = false;
            });
        }                 
    })