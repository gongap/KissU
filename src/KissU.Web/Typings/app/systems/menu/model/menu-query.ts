import { TreeQueryParameter } from '../../../../util';

/**
 * 查询参数
 */
export class MenuQuery extends TreeQueryParameter {
    /**
     * 
     */
    id;
    /**
     * 文本
     */
    text;
    /**
     * 拼音
     */
    pinYin;
    /**
     * i18n主键
     */
    i18n;
    /**
     * 是否显示分组名
     */
    group;
    /**
     * 路由
     */
    link;
    /**
     * 路由是否精准匹配
     */
    linkExact;
    /**
     * 外部链接
     */
    externalLink;
    /**
     * 链接 target
     */
    target;
    /**
     * 图标
     */
    icon;
    /**
     * 徽标数，展示的数字
     */
    badge;
    /**
     * 徽标数，显示小红点
     */
    badgeDot;
    /**
     * 徽标 Badge 颜色
     */
    badgeStatus;
    /**
     * 是否禁用
     */
    disabled;
    /**
     * 是否隐藏菜单
     */
    hide;
    /**
     * 隐藏面包屑
     */
    hideInBreadcrumb;
    /**
     * ACL配置
     */
    acl;
    /**
     * 是否快捷菜单项
     */
    shortcut;
    /**
     * 快捷菜单根节点
     */
    shortcutRoot;
    /**
     * 是否允许复用
     */
    reuse;
    /**
     * 是否展开
     */
    open;
    /**
     * 备注
     */
    note;
    /**
     * 起始
     */
    beginCreationTime;
    /**
     * 结束
     */
    endCreationTime;
    /**
     * 
     */
    creatorId;
    /**
     * 起始
     */
    beginLastModificationTime;
    /**
     * 结束
     */
    endLastModificationTime;
    /**
     * 
     */
    lastModifierId;
}