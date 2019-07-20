"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const alain_1 = require("../utils/alain");
const contents_1 = require("../utils/contents");
const json_1 = require("../utils/json");
const project_1 = require("../utils/project");
function configToAngularJson(host, options) {
    const json = json_1.getAngular(host);
    const project = project_1.getProjectFromWorkspace(json, options.project);
    // add build config
    (project.targets || project.architect).build.configurations.hmr = {
        fileReplacements: [
            {
                replace: `${options.sourceRoot}/environments/environment.ts`,
                with: `${options.sourceRoot}/environments/environment.hmr.ts`,
            },
        ],
    };
    // add serve config
    (project.targets || project.architect).serve.configurations.hmr = {
        browserTarget: `${project.name}:build:hmr`,
        hmr: true,
    };
    json_1.overwriteAngular(host, json);
}
function envConfig(host, options) {
    const defEnvPath = `${options.sourceRoot}/environments/environment.ts`;
    const defContent = host.get(defEnvPath).content;
    if (!host.exists(defEnvPath))
        return;
    // 1. update default env file
    alain_1.addValueToVariable(host, defEnvPath, 'environment', 'hmr: false');
    // 2. update prod env file
    alain_1.addValueToVariable(host, `${options.sourceRoot}/environments/environment.prod.ts`, 'environment', 'hmr: false');
    // 3. copy default env file to hmr file
    const hmrEnvPath = `${options.sourceRoot}/environments/environment.hmr.ts`;
    host.create(hmrEnvPath, defContent);
    alain_1.addValueToVariable(host, hmrEnvPath, 'environment', 'hmr: true');
}
function addNodeTypeToTsconfig(host, options) {
    const tsConfigPath = `${options.sourceRoot}/tsconfig.app.json`;
    if (!host.exists(tsConfigPath))
        return;
    const json = json_1.getJSON(host, tsConfigPath);
    const TYPENAME = 'node';
    if (options.type === 'add') {
        json.compilerOptions.types = [TYPENAME];
    }
    else {
        const idx = json.compilerOptions.types.findIndex(w => w === TYPENAME);
        if (idx !== -1)
            json.compilerOptions.types.splice(idx, 1);
    }
    json_1.overwriteJSON(host, tsConfigPath, json);
}
function pluginHmr(options) {
    return (host, context) => {
        // 1. add package
        (options.type === 'add' ? json_1.addPackageToPackageJson : json_1.removePackageFromPackageJson)(host, ['@angularclass/hmr@^2.1.3'], 'devDependencies');
        // 2. add run scripts
        (options.type === 'add' ? json_1.addPackageToPackageJson : json_1.removePackageFromPackageJson)(host, ['hmr@ng serve -c=hmr'], 'scripts');
        // 3. add angular.json
        configToAngularJson(host, options);
        if (options.type === 'add') {
            // 4. create a hmr.ts file
            alain_1.tryAddFile(host, `${options.sourceRoot}/hmr.ts`, contents_1.HMR_CONTENT.HMR_DOT_TS);
            // 5. update main.ts
            alain_1.tryAddFile(host, `${options.sourceRoot}/main.ts`, contents_1.HMR_CONTENT.HMR_MAIN_DOT_TS);
        }
        else {
            // 4. remove a hmr.ts file
            alain_1.tryDelFile(host, `${options.sourceRoot}/hmr.ts`);
            // 5. update main.ts
            alain_1.tryAddFile(host, `${options.sourceRoot}/main.ts`, contents_1.HMR_CONTENT.NO_HMR_MAIN_DOT_TS);
        }
        // 7. fix not found types
        addNodeTypeToTsconfig(host, options);
    };
}
exports.pluginHmr = pluginHmr;
//# sourceMappingURL=plugin.hmr.js.map