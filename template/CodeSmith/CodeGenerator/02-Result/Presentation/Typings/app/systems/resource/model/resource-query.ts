import { TreeQueryParameter } from '../../../../util';

/**
 * 资源查询参数
 */
export class ResourceQuery extends TreeQueryParameter {
    /**
     * 资源标识
     */
    resourceId;
    /**
     * 应用程序标识
     */
    applicationId;
    /**
     * 资源标识
     */
    uri;
    /**
     * 资源名称
     */
    name;
    /**
     * 资源类型
     */
    type;
    /**
     * 备注
     */
    remark;
    /**
     * 拼音简码
     */
    pinYin;
    /**
     * 扩展
     */
    extend;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 起始最后修改时间
     */
    beginLastModificationTime;
    /**
     * 结束最后修改时间
     */
    endLastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
}