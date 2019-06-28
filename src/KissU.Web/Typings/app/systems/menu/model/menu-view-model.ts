import { TreeViewModel } from '../../../../util';

/**
 * 菜单视图模型
 */
export class MenuViewModel extends TreeViewModel {
    /**
     * 菜单编码
     */
    code;
    /**
     * 菜单名称
     */
    name;
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
     * 
     */
    creationTime;
    /**
     * 
     */
    creatorId;
    /**
     * 
     */
    lastModificationTime;
    /**
     * 
     */
    lastModifierId;
    /**
     * 
     */
    version;
}