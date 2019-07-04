import { Rule, Tree } from '@angular-devkit/schematics';
export interface CommonSchema {
    [key: string]: any;
    _filesPath?: string;
    name?: string;
    path?: string;
    module?: string;
    target?: string;
    componentName?: string;
    importModulePath?: string;
    routerModulePath?: string;
    selector?: string;
    prefix?: string;
    withoutPrefix?: boolean;
}
export declare function addValueToVariable(host: Tree, path: string, variableName: string, text: string): void;
export declare function buildAlain(schema: CommonSchema): Rule;
export declare function tryDelFile(host: Tree, path: string): void;
export declare function tryAddFile(host: Tree, path: string, content: string): void;
