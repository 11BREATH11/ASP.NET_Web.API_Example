"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var index_1 = require("../_services/index");
var router_1 = require("@angular/router");
var SignupComponent = (function () {
    function SignupComponent(authService, router) {
        this.authService = authService;
        this.router = router;
        this.savedSuccessfully = false;
        this.message = "";
        this.registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };
    }
    SignupComponent.prototype.disableButton = function (btn, isDisable) {
        btn.disabled = isDisable;
        var spanButton = btn.getElementsByTagName("span");
        if (isDisable) {
            spanButton[0].style.display = "";
        }
        else {
            spanButton[0].style.display = "none";
        }
    };
    SignupComponent.prototype.signUp = function (event) {
        var _this = this;
        var target = event.target || event.srcElement || event.currentTarget;
        var button = target.getElementsByTagName("button");
        this.disableButton(button[0], true);
        this.authService.saveRegistration(this.registration).subscribe(function (response) {
            _this.disableButton(button[0], false);
            _this.savedSuccessfully = true;
            _this.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
            _this.startTimer();
        }, function (err) {
            var errors = [];
            _this.disableButton(button[0], false);
            for (var key in err.json().modelState) {
                for (var i = 0; i < err.json().modelState[key].length; i++) {
                    errors.push(err.json().modelState[key][i]);
                }
            }
            _this.message = "Failed to register user due to:" + errors.join(' ');
        });
    };
    ;
    SignupComponent.prototype.startTimer = function () {
        var _this = this;
        var timer = setTimeout(function () {
            _this.router.navigateByUrl('/login');
        }, 2000);
    };
    return SignupComponent;
}());
SignupComponent = __decorate([
    core_1.Component({
        moduleId: module.id.toString(),
        template: require('./signup.component.html')
    }),
    __metadata("design:paramtypes", [index_1.AuthService, router_1.Router])
], SignupComponent);
exports.SignupComponent = SignupComponent;
//# sourceMappingURL=signup.component.js.map