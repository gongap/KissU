/**
 * @license
 * Copyright Google LLC All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { DefaultTreeElement } from 'parse5';
export declare function parseDocument(html: string): any;
export declare function findElementsWithTagName(html: string, tagName: string): DefaultTreeElement[];
/**
 * Parses a HTML fragment and traverses all AST nodes in order find elements that
 * include the specified attribute.
 */
export declare function findElementsWithAttribute(html: string, attributeName: string): DefaultTreeElement[];
/**
 * Finds elements with explicit tag names that also contain the specified attribute. Returns the
 * attribute start offset based on the specified HTML.
 */
export declare function findAttributeOnElementWithTag(html: string, name: string, tagNames: string[]): number[];
/**
 * Finds elements that contain the given attribute and contain at least one of the other
 * specified attributes. Returns the primary attribute's start offset based on the specified HTML.
 */
export declare function findAttributeOnElementWithAttrs(html: string, name: string, attrs: string[]): number[];
/** 查找元素是否包含属性，返回开始位置集合 */
export declare function findElements(html: string, tagName: string): number[];
/** 查找元素是否包含属性，返回开始位置集合 */
export declare function findElementHasAttribute(html: string, tagName: string, attr: string): number[];
/** 查找元素是否包含一组属性，返回一个属性与开始位置的数组集合 */
export declare function findElementHasAttributes(html: string, tagName: string, attrs: string[]): Array<{
    attr: string;
    offset: number;
}>;
/** Gets the start offset of the given attribute from a Parse5 element. */
export declare function getStartOffsetOfAttribute(element: any, attributeName: string): number;
