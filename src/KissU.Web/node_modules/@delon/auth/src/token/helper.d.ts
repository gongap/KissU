import { Injector } from '@angular/core';
import { DelonAuthConfig } from '../auth.config';
import { JWTTokenModel } from './jwt/jwt.model';
import { SimpleTokenModel } from './simple/simple.model';
export declare function CheckSimple(model: SimpleTokenModel): boolean;
export declare function CheckJwt(model: JWTTokenModel, offset: number): boolean;
export declare function ToLogin(options: DelonAuthConfig, injector: Injector, url: string): void;
