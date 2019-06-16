import { Tree } from '@angular-devkit/schematics';
/**
 * Overwrite files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
export declare function overwriteFile(host: Tree, filePath: string, sourcePath?: string, overwrite?: boolean): Tree;
/**
 * Overwrite files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
export declare function overwriteFiles(host: Tree, files: string[], _filePath: string, overwrite?: boolean): Tree;
/**
 * Add files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
export declare function addFiles(host: Tree, files: string[], _filePath: string, overwrite?: boolean): Tree;
