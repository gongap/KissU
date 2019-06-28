import { QueryParameter } from '../../../../util';

/**
 * 企业查询参数
 */
export class EnterpriseQuery extends QueryParameter {
    /**
     * 
     */
    enterpriseId;
    /**
     * 名称
     */
    name;
    /**
     * 是否启用
     */
    enabled;
    /**
     * 拼音
     */
    pinYin;
    /**
     * Wcf地址
     */
    wcfAddress;
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