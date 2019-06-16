import { AbstractControl, ValidationErrors } from '@angular/forms';
/** 一套日常验证器 */
export declare class _Validators {
    /** 是否为数字 */
    static num(control: AbstractControl): ValidationErrors | null;
    /** 是否为整数 */
    static int(control: AbstractControl): ValidationErrors | null;
    /** 是否为小数 */
    static decimal(control: AbstractControl): ValidationErrors | null;
    /** 是否为身份证 */
    static idCard(control: AbstractControl): ValidationErrors | null;
    /** 是否为手机号 */
    static mobile(control: AbstractControl): ValidationErrors | null;
    /** 是否URL地址 */
    static url(control: AbstractControl): ValidationErrors | null;
}
