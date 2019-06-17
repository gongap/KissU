import { InjectionToken } from '@angular/core';
import { ITokenModel } from '../token/interface';
export declare const DA_STORE_TOKEN: InjectionToken<IStore>;
export interface IStore {
    get(key: string): ITokenModel;
    set(key: string, value: ITokenModel): boolean;
    remove(key: string): any;
}
