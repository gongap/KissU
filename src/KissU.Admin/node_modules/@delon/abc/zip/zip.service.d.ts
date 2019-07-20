import { HttpClient } from '@angular/common/http';
import { LazyService } from '@delon/util';
import { ZipConfig } from './zip.config';
import { ZipSaveOptions } from './zip.types';
export declare class ZipService {
    private cog;
    private http;
    private lazy;
    constructor(cog: ZipConfig, http: HttpClient, lazy: LazyService);
    private init;
    private check;
    /** 解压 */
    read(fileOrUrl: File | string, options?: any): Promise<any>;
    /** 创建 Zip 实例，用于创建压缩文件 */
    create(): Promise<any>;
    /**
     * 下载URL资源并写入 zip
     * @param zip Zip 实例
     * @param path Zip 路径，例如： `text.txt`、`txt/hi.txt`
     * @param url URL 地址
     */
    pushUrl(zip: any, path: string, url: string): Promise<void>;
    /**
     * 保存Zip并执行打开保存对话框
     *
     * @param zip zip 对象，务必通过 `create()` 构建
     * @param options 额外参数，
     */
    save(zip: any, options?: ZipSaveOptions): Promise<void>;
}
