import * as ts from 'typescript';
export declare const delonModulesSpecifier: string[];
/** Whether the specified node is part of an `@delon/*` declaration. */
export declare function isDelonImportDeclaration(node: ts.Node): boolean;
/** Whether the specified node is part of an `@delon/*` import declaration. */
export declare function isDelonExportDeclaration(node: ts.Node): boolean;
