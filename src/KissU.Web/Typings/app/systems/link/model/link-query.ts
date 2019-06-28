import { QueryParameter } from '../../../../util';

/**
 * 链接查询参数
 */
export class LinkQuery extends QueryParameter {
    /**
     * 
     */
    linkId;
    /**
     * 编码
     */
    code;
    /**
     * 标题
     */
    title;
    /**
     * 地址
     */
    address;
    /**
     * 图片
     */
    image;
    /**
     * 备注
     */
    comment;
    /**
     * 是否启用
     */
    enabled;
    /**
     * 状态
     */
    status;
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