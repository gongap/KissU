import { NzTreeNode } from 'ng-zorro-antd';
import { DelonUtilConfig } from '../util.config';
export declare class ArrayService {
    private c;
    constructor(cog: DelonUtilConfig);
    /**
     * 将树结构转换成数组结构
     */
    treeToArr(tree: any[], options?: {
        /** 深度项名，默认：`'deep'` */
        deepMapName?: string;
        /** 扁平后数组的父数据项名，默认：`'parent'` */
        parentMapName?: string;
        /** 源数据子项名，默认：`'children'` */
        childrenMapName?: string;
        /** 是否移除 `children` 节点，默认：`true` */
        clearChildren?: boolean;
        /** 转换成数组结构时回调 */
        cb?: (item: any, parent: any, deep: number) => void;
    }): any[];
    /**
     * 数组转换成树数据
     */
    arrToTree(arr: any[], options?: {
        /** 编号项名，默认：`'id'` */
        idMapName?: string;
        /** 父编号项名，默认：`'parent_id'` */
        parentIdMapName?: string;
        /** 子项名，默认：`'children'` */
        childrenMapName?: string;
        /** 转换成树数据时回调 */
        cb?: (item: any) => void;
    }): any[];
    /**
     * 数组转换成 `nz-tree` 数据源，通过 `options` 转化项名，也可以使用 `options.cb` 更高级决定数据项
     */
    arrToTreeNode(arr: any[], options?: {
        /** 编号项名，默认：`'id'` */
        idMapName?: string;
        /** 父编号项名，默认：`'parent_id'` */
        parentIdMapName?: string;
        /** 标题项名，默认：`'title'` */
        titleMapName?: string;
        /** 设置为叶子节点项名，若数据源不存在时自动根据 `children` 值决定是否为叶子节点，默认：`'isLeaf'` */
        isLeafMapName?: string;
        /** 节点 Checkbox 是否选中项名，默认：`'checked'` */
        checkedMapname?: string;
        /** 节点本身是否选中项名，默认：`'selected'` */
        selectedMapname?: string;
        /** 节点是否展开(叶子节点无效)项名，默认：`'expanded'` */
        expandedMapname?: string;
        /** 设置是否禁用节点(不可进行任何操作)项名，默认：`'disabled'` */
        disabledMapname?: string;
        /** 转换成树数据后，执行的递归回调 */
        cb?: (item: any, parent: any, deep: number) => void;
    }): NzTreeNode[];
    /**
     * 递归访问整个树
     */
    visitTree(tree: any[], cb: (item: any, parent: any, deep: number) => void, options?: {
        /** 子项名，默认：`'children'` */
        childrenMapName?: string;
    }): void;
    /**
     * 获取所有已经选中的 `key` 值
     */
    getKeysByTreeNode(tree: NzTreeNode[], options?: {
        /** 是否包含半选状态的值，默认：`true` */
        includeHalfChecked?: boolean;
        /** 是否重新指定 `key` 键名，若不指定表示使用 `NzTreeNode.key` 值 */
        keyMapName?: string;
        /** 回调，返回一个值 `key` 值，优先级高于其他 */
        cb?: (item: NzTreeNode, parent: NzTreeNode, deep: number) => any;
    }): any[];
}
