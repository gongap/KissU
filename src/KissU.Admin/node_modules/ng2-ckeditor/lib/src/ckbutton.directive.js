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
/**
 * CKGroup component
 * Usage :
 *  <ckeditor [(ngModel)]="data" [config]="{...}" debounce="500">
 *      <ckbutton [name]="'SaveButton'" [command]="'saveCommand'" (click)="save($event)"
 *                [icon]="'/save.png'" [toolbar]="'customGroup,1'" [label]="'Save'">
 *      </ckbutton>
 *   </ckeditor>
 */
var CKButtonDirective = /** @class */ (function () {
    function CKButtonDirective() {
        this.click = new core_1.EventEmitter();
    }
    CKButtonDirective.prototype.initialize = function (editor) {
        var _this = this;
        editor.instance.addCommand(this.command, {
            exec: function (evt) {
                _this.click.emit(evt);
            },
        });
        editor.instance.ui.addButton(this.name, {
            label: this.label,
            command: this.command,
            toolbar: this.toolbar,
            icon: this.icon,
        });
    };
    CKButtonDirective.prototype.ngOnInit = function () {
        if (!this.name)
            throw new Error('Attribute "name" is required on <ckbutton>');
        if (!this.command)
            throw new Error('Attribute "command" is required on <ckbutton>');
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], CKButtonDirective.prototype, "click", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], CKButtonDirective.prototype, "label", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], CKButtonDirective.prototype, "command", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], CKButtonDirective.prototype, "toolbar", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], CKButtonDirective.prototype, "name", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], CKButtonDirective.prototype, "icon", void 0);
    CKButtonDirective = __decorate([
        core_1.Directive({
            selector: 'ckbutton',
        })
    ], CKButtonDirective);
    return CKButtonDirective;
}());
exports.CKButtonDirective = CKButtonDirective;
//# sourceMappingURL=ckbutton.directive.js.map