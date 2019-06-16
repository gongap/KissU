import { STColumnButtonDrawerConfig, STColumnButtonModalConfig, STIcon, STMultiSort, STPage, STReq, STRes, STRowClassName, STSingleSort } from './table.interfaces';
export declare class STConfig {
    /**
     * 起始页码，默认为：`1`
     */
    pi?: number;
    /**
     * 每页数量，当设置为 `0` 表示不分页，默认：`10`
     */
    ps?: number;
    /**
     * 是否显示边框
     */
    bordered?: boolean;
    /**
     * table大小
     */
    size?: 'small' | 'middle' | 'default';
    /**
     * 是否隐藏头和尾，当小屏幕下才显示，默认：`false`
     */
    responsiveHideHeaderFooter?: boolean;
    /** 请求体配置 */
    req?: STReq;
    /** 返回体配置 */
    res?: STRes;
    /** 返回体配置 */
    page?: STPage;
    /**
     * 重命名排序值，`columns` 的重命名高于属性
     */
    sortReName?: {
        ascend?: string;
        descend?: string;
    };
    /**
     * 单排序规则
     * - 若不指定，则返回：`columnName=ascend|descend`
     * - 若指定，则返回：`sort=columnName.(ascend|descend)`
     */
    singleSort?: STSingleSort;
    /**
     * 是否多排序，当 `sort` 多个相同值时自动合并，建议后端支持时使用
     */
    multiSort?: STMultiSort;
    /**
     * 按钮模态框配置
     */
    modal?: STColumnButtonModalConfig;
    /**
     * 按钮抽屉配置
     */
    drawer?: STColumnButtonDrawerConfig;
    /**
     * 气泡确认框内容
     */
    popTitle?: string;
    /**
     * 行单击多少时长之类为双击（单位：毫秒），默认：`200`
     */
    rowClickTime?: number;
    /**
     * 过滤按钮确认文本，默认：`确认`
     */
    filterConfirmText?: string;
    /**
     * 过滤按钮重置文本，默认：`重置`
     */
    filterClearText?: string;
    /**
     * 按钮图标
     */
    btnIcon?: STIcon;
    /**
     * 行号索引，默认：`1`
     * - 计算规则为：`index + noIndex`
     */
    noIndex?: number;
    /**
     * 表格行的类名
     */
    rowClassName?: STRowClassName;
    /**
     * 通过点击行来展开子行
     */
    expandRowByClick?: boolean;
}
