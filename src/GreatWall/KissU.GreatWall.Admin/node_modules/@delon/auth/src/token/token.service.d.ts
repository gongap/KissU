import { Observable } from 'rxjs';
import { DelonAuthConfig } from '../auth.config';
import { IStore } from '../store/interface';
import { AuthReferrer, ITokenModel, ITokenService } from './interface';
export declare function DA_SERVICE_TOKEN_FACTORY(): ITokenService;
export declare class TokenService implements ITokenService {
    private options;
    private store;
    private change$;
    private _referrer;
    constructor(options: DelonAuthConfig, store: IStore);
    readonly login_url: string;
    readonly referrer: AuthReferrer;
    set(data: ITokenModel): boolean;
    get(type?: any): any;
    clear(): void;
    change(): Observable<ITokenModel>;
}
