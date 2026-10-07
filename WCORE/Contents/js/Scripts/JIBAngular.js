var app = angular.module('PISApp', ['ngRoute','ui.bootstrap']);
app
    .controller("LoginController", ['$scope', '$http', function ($scope, $http) {
        $scope.btntext = "Login";
        $scope.login = function () {
            $http({
                method: "POST",
                url: '../Home/Login',
                data: $scope.User
            }).then(function (response) {
                var k = JSON.parse(JSON.stringify(response.data));
                if (k.Message === 'Ok') {
                    if (k.IsReset === true) { window.location.href = '../Home/ResetPassword'; }
                    else { window.location.href = '../Home/Main'; }
                }
                else {
                    Toast.Error(k.Message);
                }
            }, function (error) {
                $scope.errorMessage = error;
            });
        }
        $scope.fpassword = function () {
            window.location.href = '../Home/ForgotPassword';
        }
    }])

    .controller("FPasswordController", ['$scope', '$http', function ($scope, $http) {
        $scope.rpassword = function () {
            $http({
                method: "POST",
                url: '../Home/RPassword',
                data: $scope.User
            }).then(function (response) {
                var k = JSON.parse(JSON.stringify(response.data));
                if (k.Message === 'Ok') {
                    Toast.Show('Please check your email.');
                }
                else {
                    Toast.Error('Invalid email address.');
                }
            }, function (error) {
                Toast.Error(error);
            });
        }
        $scope.flogin = function () {
            window.location.href = '../Home/Index';
        }
    }])

    .controller('TabCtrl', ['$scope', '$http',  function ($scope, $http) {
        $scope.tabs = [];
        var addTab = function (mID, mIcon, mTitle, mContent) {
            var oCtr = -1; 
            $scope.tabs.some(function (obj, i) {
                return obj.modID === mID ? oCtr = i : false;
            });
            if (oCtr !== -1) {
                $scope.tabs[oCtr].active = true;
            }else{
                $scope.tabs.push({ modID: mID, icon: mIcon, title: mTitle.replace('~', ' '), content: 'content_' + mContent  });
                $scope.tabs[$scope.tabs.length - 1].active = true;
            }
        };

        // Remove tab by index
        var removeTab = function (event, index) {
            event.preventDefault();
            event.stopPropagation();
            $scope.tabs.splice(index, 1);
        };

        // Initialize the scope functions
        $scope.addTab = addTab;
        $scope.removeTab = removeTab;       

    }])
    .directive('tabHighlight', [function () {
        return {
            restrict: 'A',
            link: function (scope, element) {

                var x, y, initial_background = '#c3d5e6';
                
                element
                    .removeAttr('style')
                    .mousemove(function (e) {
                        // Add highlight effect on inactive tabs
                        if (!element.hasClass('active')) {
                            x = e.pageX - this.offsetLeft;
                            y = e.pageY - this.offsetTop;

                            // Set the background when mouse moves over inactive tabs
                            element
                                .css({ background: '-moz-radial-gradient(circle at ' + x + 'px ' + y + 'px, rgba(255,255,255,0.4) 0px, rgba(255,255,255,0.0) 45px), ' + initial_background })
                                .css({ background: '-webkit-radial-gradient(circle at ' + x + 'px ' + y + 'px, rgba(255,255,255,0.4) 0px, rgba(255,255,255,0.0) 45px), ' + initial_background })
                                .css({ background: 'radial-gradient(circle at ' + x + 'px ' + y + 'px, rgba(255,255,255,0.4) 0px, rgba(255,255,255,0.0) 45px), ' + initial_background });
                        }
                    })
                    .mouseout(function () {
                        element.removeAttr('style');
                    });
            }
        };
    }]);
    

