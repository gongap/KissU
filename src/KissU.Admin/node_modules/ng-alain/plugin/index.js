"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const tasks_1 = require("@angular-devkit/schematics/tasks");
const project_1 = require("../utils/project");
const plugin_asdf_1 = require("./plugin.asdf");
const plugin_code_style_1 = require("./plugin.code-style");
const plugin_default_language_1 = require("./plugin.default-language");
const plugin_docker_1 = require("./plugin.docker");
const plugin_g2_1 = require("./plugin.g2");
const plugin_hmr_1 = require("./plugin.hmr");
const plugin_icon_1 = require("./plugin.icon");
const plugin_network_env_1 = require("./plugin.network-env");
function installPackages() {
    return (host, context) => {
        context.addTask(new tasks_1.NodePackageInstallTask());
    };
}
function default_1(options) {
    return (host, context) => {
        const project = project_1.getProject(host, options.project);
        const pluginOptions = {
            type: options.type,
            name: project.name,
            projectPrefix: project.prefix,
            root: project.root,
            sourceRoot: project.sourceRoot,
            project: options.project,
        };
        const rules = [];
        switch (options.name) {
            case 'g2':
                rules.push(plugin_g2_1.pluginG2(pluginOptions), installPackages());
                break;
            case 'codeStyle':
                rules.push(plugin_code_style_1.pluginCodeStyle(pluginOptions), installPackages());
                break;
            case 'networkEnv':
                rules.push(plugin_network_env_1.pluginNetworkEnv(Object.assign({}, pluginOptions, { packageManager: options.packageManager })));
                break;
            case 'hmr':
                rules.push(plugin_hmr_1.pluginHmr(pluginOptions), installPackages());
                break;
            case 'docker':
                rules.push(plugin_docker_1.pluginDocker(pluginOptions));
                break;
            case 'defaultLanguage':
                rules.push(plugin_default_language_1.pluginDefaultLanguage(Object.assign({}, pluginOptions, { defaultLanguage: options.defaultLanguage })));
                break;
            case 'icon':
                rules.push(plugin_icon_1.pluginIcon(pluginOptions));
                break;
            case 'asdf':
                rules.push(plugin_asdf_1.pluginAsdf(pluginOptions));
                break;
            default:
                throw new schematics_1.SchematicsException(`Could not find plugin name: ${options.name}`);
        }
        return schematics_1.chain(rules)(host, context);
    };
}
exports.default = default_1;
//# sourceMappingURL=index.js.map