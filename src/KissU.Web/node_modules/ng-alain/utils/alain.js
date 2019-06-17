"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular-devkit/core");
const schematics_1 = require("@angular-devkit/schematics");
const ast_utils_1 = require("@schematics/angular/utility/ast-utils");
const change_1 = require("@schematics/angular/utility/change");
const find_module_1 = require("@schematics/angular/utility/find-module");
const parse_name_1 = require("@schematics/angular/utility/parse-name");
const validation_1 = require("@schematics/angular/utility/validation");
const ts = require("typescript");
const ast_1 = require("./ast");
const project_1 = require("./project");
function buildSelector(schema, projectPrefix) {
    const ret = [];
    if (!schema.withoutPrefix) {
        if (schema.prefix) {
            ret.push(schema.prefix);
        }
        else if (schema.prefix === undefined && projectPrefix) {
            ret.push(projectPrefix);
        }
    }
    // module name
    if (schema.module) {
        ret.push(schema.module);
    }
    // target name
    if (schema.target) {
        ret.push(...schema.target.split('/'));
    }
    // name
    ret.push(core_1.strings.dasherize(schema.name));
    return ret.join('-');
}
function buildComponentName(schema, projectPrefix) {
    const ret = [schema.module];
    if (schema.target && schema.target.length > 0) {
        ret.push(...schema.target.split('/'));
    }
    ret.push(schema.name);
    ret.push(`Component`);
    return core_1.strings.classify(ret.join('-'));
}
function resolveSchema(host, project, schema) {
    if (!schema._filesPath) {
        schema._filesPath = './files';
    }
    // module name
    if (!schema.module) {
        throw new schematics_1.SchematicsException(`Must specify module name. (e.g: ng g ng-alain:list <list name> -m=<module name>)`);
    }
    // path
    if (schema.path === undefined) {
        const projectDirName = project.projectType === 'application' ? 'app' : 'lib';
        schema.path = `/${project.sourceRoot}/${projectDirName}/routes`;
    }
    schema.path += `/${schema.module}`;
    const parsedPath = parse_name_1.parseName(schema.path, schema.name);
    schema.name = parsedPath.name;
    schema.path = parsedPath.path;
    schema.importModulePath = find_module_1.findModuleFromOptions(host, schema);
    // fill target
    if (schema.target) {
        schema.path += '/' + schema.target;
    }
    schema.routerModulePath = schema.importModulePath.replace('.module.ts', '-routing.module.ts');
    // html selector
    schema.selector =
        schema.selector || buildSelector(schema, project.prefix);
    validation_1.validateName(schema.name);
    validation_1.validateHtmlSelector(schema.selector);
}
function addImportToModule(host, path, symbolName, fileName) {
    const source = ast_1.getSourceFile(host, path);
    const change = ast_utils_1.insertImport(source, path, symbolName, fileName);
    const declarationRecorder = host.beginUpdate(path);
    declarationRecorder.insertLeft(change.pos, change.toAdd);
    host.commitUpdate(declarationRecorder);
}
function addValueToVariable(host, path, variableName, text) {
    const source = ast_1.getSourceFile(host, path);
    const node = ast_utils_1.findNode(source, ts.SyntaxKind.Identifier, variableName);
    if (!node) {
        throw new schematics_1.SchematicsException(`Could not find any [${variableName}] variable.`);
    }
    const arr = node.parent.initializer;
    const change = new change_1.InsertChange(path, arr.end - 1, `${arr.elements && arr.elements.length > 0 ? ',' : ''}\n  ${text}`);
    const declarationRecorder = host.beginUpdate(path);
    declarationRecorder.insertLeft(change.pos, change.toAdd);
    host.commitUpdate(declarationRecorder);
}
exports.addValueToVariable = addValueToVariable;
function getRelativePath(path, schema) {
    const importPath = `/${schema.path}/${schema.flat ? '' : core_1.strings.dasherize(schema.name) + '/'}${core_1.strings.dasherize(schema.name)}.component`;
    return find_module_1.buildRelativePath(path, importPath);
}
function addDeclaration(schema) {
    return (host) => {
        if (schema.skipImport || !schema.module) {
            return host;
        }
        // imports
        addImportToModule(host, schema.importModulePath, schema.componentName, getRelativePath(schema.importModulePath, schema));
        // component
        if (schema.modal === true) {
            addValueToVariable(host, schema.importModulePath, 'COMPONENTS_NOROUNT', schema.componentName);
        }
        else {
            addValueToVariable(host, schema.importModulePath, 'COMPONENTS', schema.componentName);
            // routing
            addImportToModule(host, schema.routerModulePath, schema.componentName, getRelativePath(schema.routerModulePath, schema));
            addValueToVariable(host, schema.routerModulePath, 'routes', `{ path: '${schema.name}', component: ${schema.componentName} }`);
        }
        return host;
    };
}
function buildAlain(schema) {
    return (host, context) => {
        const project = project_1.getProject(host, schema.project);
        resolveSchema(host, project, schema);
        schema.componentName = buildComponentName(schema, project.prefix);
        // Don't support inline
        schema.inlineTemplate = false;
        const templateSource = schematics_1.apply(schematics_1.url(schema._filesPath), [
            schematics_1.filter(path => !path.endsWith('.DS_Store')),
            schema.spec ? schematics_1.noop() : schematics_1.filter(path => !path.endsWith('.spec.ts')),
            schema.inlineStyle ? schematics_1.filter(path => !path.endsWith('.__styleext__')) : schematics_1.noop(),
            schema.inlineTemplate ? schematics_1.filter(path => !path.endsWith('.html')) : schematics_1.noop(),
            schematics_1.template(Object.assign({}, core_1.strings, { 'if-flat': (s) => (schema.flat ? '' : s) }, schema)),
            schematics_1.move(null, schema.path + '/'),
        ]);
        return schematics_1.chain([schematics_1.branchAndMerge(schematics_1.chain([addDeclaration(schema), schematics_1.mergeWith(templateSource)]))])(host, context);
    };
}
exports.buildAlain = buildAlain;
function tryDelFile(host, path) {
    if (host.exists(path)) {
        host.delete(path);
    }
}
exports.tryDelFile = tryDelFile;
function tryAddFile(host, path, content) {
    tryDelFile(host, path);
    host.create(path, content);
}
exports.tryAddFile = tryAddFile;
//# sourceMappingURL=alain.js.map