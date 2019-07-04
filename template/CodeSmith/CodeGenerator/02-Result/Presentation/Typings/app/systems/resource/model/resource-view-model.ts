import { TreeViewModel } from '../../../../util';

/**
 * 资源参数
 */
export class ResourceViewModel extends TreeViewModel {
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
     * 创建时间
     */
    creationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 最后修改时间
     */
    lastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
    /**
     * 版本号
     */
    version;
}