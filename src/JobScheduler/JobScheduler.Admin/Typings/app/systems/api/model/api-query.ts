import { QueryParameter } from '../../../../util';

/**
 * Api资源查询参数
 */
export class ApiQuery extends QueryParameter {
    /**
     * 
     */
    apiId;
    /**
     * 名称
     */
    name;
    /**
     * 显示名
     */
    displayName;
    /**
     * 描述
     */
    description;
    /**
     * 声明类型
     */
    claimTypes;
    /**
     * 是否启用
     */
    enabled;
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