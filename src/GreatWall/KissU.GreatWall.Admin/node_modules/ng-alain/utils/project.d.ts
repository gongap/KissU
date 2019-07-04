import { Tree } from '@angular-devkit/schematics';
export declare const ANGULAR_CLI_WORKSPACE_PATH = "/angular.json";
/** An Angular CLI Workspacer config (angular.json) */
export interface Workspace {
    /** Link to schema. */
    $schema?: string;
    /** Workspace Schema version. */
    version: number;
    /** New project root. */
    newProjectRoot?: string;
    /** Tool options. */
    cli?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** Tool options. */
    schematics?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** Tool options. */
    architect?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** Tool options. */
    targets?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** A map of project names to project options. */
    projects: {
        [k: string]: Project;
    };
    /** 默认项目 */
    defaultProject: string;
}
/**
 * A project in an Angular CLI workspace (e.g. an app or a library). A single workspace
 * can house multiple projects.
 */
export interface Project {
    /** 名称 */
    name: string;
    /** 前缀名 */
    prefix: string;
    /** 项目类型 */
    projectType: 'application' | 'library';
    /** 项目根目录 */
    root: string;
    /** 项目源文件目录，例如：`src` */
    sourceRoot: string;
    /** Tool options. */
    cli?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** Tool options. */
    schematics?: {
        /** Link to schema. */
        $schema?: string;
        [k: string]: any;
    };
    /** Tool options. */
    targets?: ProjectBuildOptions;
    /** Tool options. */
    architect?: ProjectBuildOptions;
}
/** Architect options for an Angular CLI workspace. */
export interface ProjectBuildOptions {
    /** Link to schema. */
    $schema?: string;
    [k: string]: any;
}
/** Gets the Angular CLI workspace config (angular.json) */
export declare function getWorkspace(host: Tree): Workspace;
/**
 * Gets a project from the Angular CLI workspace. If no project name is given, the first project
 * will be retrieved.
 */
export declare function getProjectFromWorkspace(config: Workspace, projectName?: string): Project;
/** 获取当前 Angular 项目 */
export declare function getProject(host: Tree, projectName?: string): Project;
