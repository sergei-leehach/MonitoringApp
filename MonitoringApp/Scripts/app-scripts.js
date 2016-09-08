angular
    .module("Application", [])
    .controller("AppCtrl", function ($scope, $http, $q) {
        var canceller = $q.defer();
        var isRequest = false;

        $scope.GetDrives = function () {
            var url = "/api/App";
            var counterUrl = "/api/Counter";
            get(url, counterUrl, false);
        }

        $scope.GetDirectory = function (path) {
            if (path === '') {
                $scope.GetDrives();
            } else {
                var url = "/api/App?path=" + encodeURIComponent(path);
                var counterUrl = "/api/Counter?path=" + encodeURIComponent(path);
                get(url, counterUrl, true);
            }
        }

        function get(url, counterUrl, showParent) {
            $scope.isLoading = true;

            $http.get(url).success(function (response) {
                $scope.files = response.Files;
                $scope.directories = response.Directories;
                $scope.parent = response.ParentNode;
                $scope.path = response.Path;

                if (showParent) {
                    $("#parent").show();
                } else {
                    $("#parent").hide();
                }
                if (isRequest) {
                    canceller.resolve();
                }
                isRequest = true;
                canceller = $q.defer();
                $http.get(counterUrl, { timeout: canceller.promise }).success(function (data) {
                    $scope.counter = data;
                    $scope.isLoading = false;
                    isRequest = false;
                });
            });
        }
    })