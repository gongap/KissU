"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
const core_1 = require("@angular-devkit/core");
const schematics_1 = require("@angular-devkit/schematics");
const ast_utils_1 = require("@schematics/angular/utility/ast-utils");
const change_1 = require("@schematics/angular/utility/change");
const config_1 = require("@schematics/angular/utility/config");
const find_module_1 = require("@schematics/angular/utility/find-module");
const parse_name_1 = require("@schematics/angular/utility/parse-name");
const ts = require("typescript");
function addDeclarationToNgModule(options) {
    return (host) => {
        if (!options.module) {
            return host;
        }
        const modulePath = core_1.normalize('/' + options.module);
        const text = host.read(modulePath);
        if (text === null) {
            throw new schematics_1.SchematicsException(`File ${modulePath} does not exist.`);
        }
        const sourceText = text.toString('utf-8');
        const source = ts.createSourceFile(modulePath, sourceText, ts.ScriptTarget.Latest, true);
        const importModulePath = core_1.normalize(`/${options.path}/${options.flat ? '' : core_1.strings.dasherize(options.name) + '/'}${core_1.strings.dasherize(options.name)}.module`);
        const relativeDir = core_1.relative(core_1.dirname(modulePath), core_1.dirname(importModulePath));
        // tslint:disable-next-line:prefer-template
        const relativePath = `${relativeDir.startsWith('.') ? relativeDir : './' + relativeDir}/${core_1.basename(importModulePath)}`;
        const changes = ast_utils_1.addImportToModule(source, modulePath, core_1.strings.classify(`${options.name}Module`), relativePath);
        const recorder = host.beginUpdate(modulePath);
        for (const change of changes) {
            if (change instanceof change_1.InsertChange) {
                recorder.insertLeft(change.pos, change.toAdd);
            }
        }
        host.commitUpdate(recorder);
        return host;
    };
}
function default_1(schema) {
    return (host, context) => {
        const workspace = config_1.getWorkspace(host);
        if (!schema.project) {
            throw new schematics_1.SchematicsException('Option (project) is required.');
        }
        const project = workspace.projects[schema.project];
        if (schema.path === undefined) {
            const projectDirName = project.projectType === 'application' ? 'app' : 'lib';
            schema.path = `/${project.sourceRoot}/${projectDirName}/routes`;
        }
        if (schema.module) {
            schema.module = find_module_1.findModuleFromOptions(host, schema);
        }
        const parsedPath = parse_name_1.parseName(schema.path, schema.name);
        schema.name = parsedPath.name;
        schema.path = parsedPath.path;
        schema.routing = true;
        schema.flat = false;
        const templateSource = schematics_1.apply(schematics_1.url('./files'), [
            schema.routing ? schematics_1.noop() : schematics_1.filter(path => !path.endsWith('-routing.module.ts')),
            schematics_1.template(Object.assign({}, core_1.strings, { 'if-flat': (s) => (schema.flat ? '' : s) }, schema)),
            schematics_1.move(parsedPath.path),
        ]);
        return schematics_1.chain([
            schematics_1.branchAndMerge(schematics_1.chain([addDeclarationToNgModule(schema), schematics_1.mergeWith(templateSource)])),
        ])(host, context);
    };
}
exports.default = default_1;
//# sourceMappingURL=index.js.map