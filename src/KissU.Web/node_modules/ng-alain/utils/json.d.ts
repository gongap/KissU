import { Tree } from '@angular-devkit/schematics';
export declare function getJSON(host: Tree, jsonFile: string, type?: string): any;
export declare function overwriteJSON(host: Tree, jsonFile: string, json: any): void;
export declare function getPackage(host: Tree, type?: string): any;
export declare function overwritePackage(host: Tree, json: any): void;
/**
 * Adds a package to the package.json
 *
 * ```
 * addPackageToPackageJson(host, [ '＠delon/abc＠^1.0.0' ])
 * addPackageToPackageJson(host, [ '＠delon/abc＠^1.0.0' ], 'devDependencies')
 * ```
 */
export declare function addPackageToPackageJson(host: Tree, pkg: string | string[], type?: string): Tree;
/**
 * Removes a package to the package.json
 *
 * ```
 * addPackageToPackageJson(host, [ '＠delon/abc' ])
 * addPackageToPackageJson(host, [ '＠delon/abc' ], 'devDependencies')
 * ```
 */
export declare function removePackageFromPackageJson(host: Tree, pkg: string | string[], type?: string): Tree;
export declare function getAngular(host: Tree, type?: string): any;
export declare function overwriteAngular(host: Tree, json: any): void;
export declare function scriptsToAngularJson(host: Tree, resources: string | string[], behavior: string, types?: string[], projectName?: string, clean?: boolean): Tree;
