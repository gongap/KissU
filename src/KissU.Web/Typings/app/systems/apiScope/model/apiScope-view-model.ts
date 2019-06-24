import { ViewModel } from '../../../../util';

/**
 * Api许可范围视图模型
 */
export class ApiScopeViewModel extends ViewModel {
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
}