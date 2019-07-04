import { ConvertAction, VDom } from './interfaces';
export declare class DomService {
    private dom;
    private rules;
    private ingoreClosedTag;
    private count;
    replace(html: string, rules: ConvertAction[], callback: (dom: VDom[], count: number) => void): void;
    private parseRule;
    private resolveTagName;
    private resolveTagAttr;
    private resolveRule;
    private resolveName;
    private resolveAttrName;
    private resolveRemoveChild;
    private resolveRemoveWrapElementByClass;
    private resolveRemoveChildTemplateAttr;
    private resolveChangeTagToText;
    private resolveNameToAttr;
    /** 将属性转化为元素 */
    private resolveAttrToName;
    /** 添加未指定属性名的 ng-template */
    private resolveAddTemplateAtrr;
    /** 除 ng-template 以外所有子项都应该包裹至 rule.value 下面 */
    private resolveAddContentToTemplate;
    /** 为所有 ng-template 名称增加一个前缀 */
    private resolveAddPrefixToTemplate;
    private resolveClassName;
    private resolveExtra;
    prettify(dom: VDom[]): string;
    private genAttr;
    private genTab;
}
