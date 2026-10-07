let app = angular.module('PISApp', ['ngRoute','ui.bootstrap']);
app
    .controller("LoginController", ['$scope', '$http', function ($scope, $http) {
        $scope.login = function () {
            if($scope.User === undefined){ Toast.Error('Please enter username and password.'); return false;}
            if($scope.User.Username === undefined && $scope.User.Password === undefined) { Toast.Error('Please enter username and password.'); return false;}
            if($scope.User.Username === undefined) { Toast.Error('Please enter username.'); return false;}
            if($scope.User.Password === undefined) { Toast.Error('Please enter password.'); return false;}
         if(grecaptcha.getResponse().length){
            $http({
                method: "POST",
                url: '../Home/getLoginInfo',
                data: $scope.User
            }).then(function (response) {
                const k = JSON.parse(JSON.stringify(response.data));

                if (k.Status === 'Success' && k.GoogleAuthKey === 'Yes') {
                    if (k.IsReset) { window.location.href = '../Home/ResetPassword#!?mguid=' + k.mguid; }
                    //else{ window.location.href = '../Home/Main'; }
                    else { window.location.href = '../Home/GoogleAuthKey'; }
                }
                else if (k.Status === 'Success' && k.GoogleAuthKey === 'ByPass') {
                    if (k.IsReset) { window.location.href = '../Home/ResetPassword#!?mguid=' + k.mguid; }
                    else { window.location.href = '../Home/Main'; }
                    //else { window.location.href = '../Home/GoogleAuthKey'; }
                }
                else if (k.Status === 'Success' && k.GoogleAuthKey === 'No') {
                    window.location.href = '../Home/GoogleAuthKey';
                }
                else { Toast.Error(k.Message); }


                //if (k.Status === 'Success') {
                //    if(k.IsReset){ window.location.href = '../Home/ResetPassword#!?mguid=' + k.mguid;  }
                //    else{ window.location.href = '../Home/Main'; }
                //}
                //else { Toast.Error(k.Message); }


            }, function (error) { $scope.errorMessage = error; });
        }else{ Toast.Error("Please verify reCAPTCHA."); }
        };
        $scope.fpassword = function () { window.location.href = '../Home/ForgotPassword'; };
    }])

    .controller("GoogleAuthKeyController", ['$scope', '$http', function ($scope, $http) {
        $scope.googleauth = function () {
            if ($scope.User === undefined || $scope.User.GoogleAuthKey === undefined) { Toast.Error('Please enter Google Authentication Key.'); return false; }
            //if (grecaptcha.getResponse().length) {
            $http({
                method: "POST",
                url: '../Home/AuthenticateGoogleAuthKey',
                data: $scope.User
            }).then(function (response) {
                const k = JSON.parse(JSON.stringify(response.data));
                if (k.Status === 'Success') { window.location.href = '../Home/Main'; }
                else { Toast.Error(k.Message); }
            }, function (error) { Toast.Error("failed auth key "); });
            //} else { Toast.Error("Please verify reCAPTCHA."); }
        };
        $scope.flogin = function () { window.location.href = '../Home/Index'; };
    }])

    .controller("FPasswordController", ['$scope', '$http', function ($scope, $http) {
        $scope.rpassword = function () {
            if($scope.User === undefined || $scope.User.Email === undefined){ Toast.Error('Please enter email address.'); return false;}
            if(grecaptcha.getResponse().length){
                $http({
                    method: "POST",
                    url: '../Home/doResetPassword',
                    data: $scope.User
                }).then(function (response) {
                    const k = JSON.parse(JSON.stringify(response.data));
                    if (k.Status === 'Success') { Toast.Show('Please check your email.'); }
                    else { Toast.Error(k.Message); }
                }, function (error) { Toast.Error(error); });
            }else{ Toast.Error("Please verify reCAPTCHA."); }
        };
        $scope.flogin = function () { window.location.href = '../Home/Index'; };
    }])

    .controller("RPasswordController", ['$scope', '$http', '$location', function ($scope, $http, $location) {
        $http({
            method: "POST",
            url: '../Home/checkResetExpiry?mguid=' + $location.search()["mguid"],
            data: $scope.User
        }).then(function (response) {
            const k = JSON.parse(JSON.stringify(response.data));
            if (k.Status === 'Failed') { 
                msg = k.Message;
                swal({ title: "Information..", text: msg, icon: "info", buttons: "Ok", dangerMode: true})
                .then((willDelete) => { window.location.href = '../Home/Index'; });
            } else { 
                // Set the date we're counting down to
                let countDownDate = k.rpExpiry;
                // Update the count down every 1 second
                let x = setInterval(function(){
                  // Get today's date and time
                  countDownDate--;
                  // Time calculations for days, hours, minutes and seconds
                  let minutes = Math.floor(countDownDate % (60 * 60) / 60);
                  let seconds = Math.floor(countDownDate % 60);
                  // Output the result in an element with id="demo"
                  document.getElementById('ctrdown').innerText  = minutes + "m " + seconds + "s ";
                  console.log(minutes + "m " + seconds + "s ");
                  // If the count down is over, write some text 
                  if (countDownDate < 0) {
                    clearInterval(x);
                    msg = 'Reset password link is invalid/expired.';
                    swal({ title: "Information..", text: msg, icon: "info", buttons: "Ok", dangerMode: true}).then((willDelete) => { window.location.href = '../Home/Index'; });
                  }
                }, 1000); 
                
            }
        });
        const strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
        const mediumRegex = new RegExp("^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})");
        const strength = { 0: "Weakest", 1: "Weak", 2: "Not Good", 3: "Good", 4: "Strong" };
        const password = document.getElementById('new-password');
        const meter = document.getElementById('password-strength');
        $scope.pchange = function() {
            const val = password.value;
            const result = zxcvbn(val);
            const score = result.score < 3 ? result.score : strongRegex.test(val) ? 4 : mediumRegex.test(val) ? 3 : 2;
            meter.value = score;
            if (val !== "") { $scope.rate = "Password Strength: " + strength[score];} 
            else { $scope.rate = ""; }
        };  
        $scope.cpassword = function () {
            if($scope.User === undefined) { Toast.Error('Please enter password'); return false; }
            if($scope.User.CPassword !==  $scope.User.Password) { Toast.Error('Confirm password did not match.'); return false;}
            if (meter.value <= 2) { Toast.Error('Password should be a combination of letters and numbers and min. of 9 characters.'); return false; }
            $http({
                method: "POST",
                url: '../Home/doChangePassword?mguid=' + $location.search().mguid,
                data: $scope.User
            }).then(function (response) {
                const k = JSON.parse(JSON.stringify(response.data));
                if (k.Status === 'Success') {
                    window.location.href = '../Home/Index';
                    Toast.Show(k.Message);
                }
                else {
                    Toast.Error(k.Message);
                    if(k.Message === 'Reset password link is invalid/expired.') { window.location.href = '../Home/Index'; }
                }
            }, function (error) { Toast.Error(error); });
        };
        $scope.flogin = function () { window.location.href = '../Home/Index'; };
    }])

    .controller('CronusController', ['$scope', '$http', function ($scope,$http) {
	    alert('rok');	
        $http.get("http://localhost:8083/api/cronus/GetContractInfo?cID=22329")
        .success(function (data) {
			alert('ok');
		})
    }])

    .controller('TabCtrl', ['$scope', function ($scope) {
        $scope.tabs = [];
        const addTab = function (mID, mIcon, mTitle) {
            let oCtr = -1; 
            $scope.tabs.some(function (obj, i) { return obj.modID === mID ? oCtr = i : false; });
            if (oCtr !== -1) { $scope.tabs[oCtr].active = true;}
            else{
                console.log($scope.tabs.length);
                if($scope.tabs.length < 6)
                {  run_waitMe($('.content-wrapper'), 1, "roundBounce");
                  $scope.tabs.push({ modID: mID, icon: mIcon, title: mTitle.replace('~', ' '), content: 'content_mFrm' + mID });
                  $scope.tabs[$scope.tabs.length - 1].active = true;
                } else { Toast.Error('You have reach the maximum number of open windows. Please close the other to proceed');}
            }
        };

        // Remove tab by index
        let removeTab = function (event, index) {
            event.preventDefault(); event.stopPropagation(); $scope.tabs.splice(index, 1);
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

toastr.options = {
    "closebutton": false,
    "debug": false,
    "newestontop": false,
    "progressbar": false,
    "positionclass": "toast-bottom-right",
    "preventduplicates": false,
    "onclick": null,
    "showduration": "300",
    "hideduration": "1000",
    "timeout": "3000",
    "extendedtimeout": "3000",
    "showeasing": "swing",
    "hideeasing": "linear",
    "showmethod": "fadein",
    "hidemethod": "fadeout",
    "taptodismiss": false
};
toastr.options.preventduplicates = false;

var Toast = {
    Show: function (message) {
        toastr.success(message);
    },
    Error: function (message) {
        toastr.error(message);
    }
};
