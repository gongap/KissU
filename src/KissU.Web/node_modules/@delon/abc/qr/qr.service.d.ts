import { QRConfig } from './qr.config';
export declare class QRService {
    /** 当前qr实例 */
    readonly qr: any;
    /** 背景 */
    background: string;
    /** 背景透明级别，范围：`0-1` 之间 */
    backgroundAlpha: number;
    /** 前景 */
    foreground: string;
    /** 前景透明级别，范围：`0-1` 之间 */
    foregroundAlpha: number;
    /** 误差校正级别 */
    level: string;
    /** 二维码输出图片MIME类型 */
    mime: string;
    /** 内边距（单位：px） */
    padding: number;
    /** 大小（单位：px） */
    size: number;
    /** 值 */
    value: string;
    constructor(cog: QRConfig);
    /**
     * 生成二维码，并返回Base64编码
     *
     * @param [value] 重新指定值
     */
    refresh(value?: string | {}): string;
    /**
     * 返回当前二维码Base64编码
     */
    readonly dataURL: string;
}
