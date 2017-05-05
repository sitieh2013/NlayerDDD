'use strict';

angular.module('app', [])
    .controller('projectController', [
        '$scope', '$http', function($scope, $http) {

            $http.get('/api/projectapi/getall')
                .then(
                    function(response) {
                        console.log(response);
                        $scope.rows = response.data;
                    },
                    function(errResponse) {
                        console.log(errResponse);
                    }
                );
        }
    ]);