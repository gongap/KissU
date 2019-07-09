import { Injectable } from '@angular/core';
import { MenuService, SettingsService, TitleService } from '@delon/theme';
import { util } from '../../../util';

/**
 * 启动服务
 */
@Injectable()
export class StartupService {
    /**
     * 初始化启动服务
     * @param menuService 菜单服务
     * @param settingService 设置服务
     * @param titleService 标题服务
     */
    constructor( private menuService: MenuService, private settingService: SettingsService, private titleService: TitleService ) {
    }

    /**
     * 加载配置
     */
    load() {
        return util.webapi.get( '/api/home' ).handle( {
            ok: ( result: any ) => {
                this.settingService.setApp( result.app );
                this.settingService.setUser( result.user );
                this.menuService.add( result.menu );
                this.titleService.default = '';
                this.titleService.suffix = result.app.name;
            }
        } );
    }
}
