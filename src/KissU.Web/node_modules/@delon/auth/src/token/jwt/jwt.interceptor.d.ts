import { HttpRequest } from '@angular/common/http';
import { DelonAuthConfig } from '../../auth.config';
import { BaseInterceptor } from '../base.interceptor';
export declare class JWTInterceptor extends BaseInterceptor {
    isAuth(options: DelonAuthConfig): boolean;
    setReq(req: HttpRequest<any>, options: DelonAuthConfig): HttpRequest<any>;
}
