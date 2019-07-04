import { QueryParameter } from '../../../../util';

/**
 * Api许可范围查询参数
 */
export class ApiScopeQuery extends QueryParameter {
    /**
     * 
     */
    apiScopeId;
    /**
     * Api资源标识
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
     * 是否必选
     */
    required;
    /**
     * 是否强调
     */
    emphasize;
    /**
     * 是否显示在发现文档中
     */
    showInDiscoveryDocument;
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