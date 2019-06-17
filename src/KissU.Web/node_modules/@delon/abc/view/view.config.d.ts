export declare class SVConfig {
    /** 大小 */
    size: 'small' | 'large';
    /** 间距，默认：`32` */
    gutter: number;
    /** 布局，默认：`horizontal` */
    layout: string;
    /** 列数，默认：`3` */
    col: number;
    /** 是否显示默认值，当内容为空值时显示 `-`，默认：`true` */
    default: boolean;
    /** `label` 固定宽度，若 `null` 或 `undefined` 表示非固定，默认：`null` */
    labelWidth: any;
}
