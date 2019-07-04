"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
function default_1(options) {
    const rules = [];
    const applicationOptions = Object.assign({}, options);
    rules.push(schematics_1.schematic('application', applicationOptions));
    if (options.g2) {
        rules.push(schematics_1.schematic('plugin', { name: 'g2', type: 'add' }));
    }
    if (options.codeStyle) {
        rules.push(schematics_1.schematic('plugin', { name: 'codeStyle', type: 'add' }));
    }
    if (options.defaultLanguage) {
        rules.push(schematics_1.schematic('plugin', {
            name: 'defaultLanguage',
            type: 'add',
            defaultLanguage: options.defaultLanguage,
        }));
    }
    if (options.npm) {
        rules.push(schematics_1.schematic('plugin', {
            name: 'networkEnv',
            type: 'add',
            packageManager: 'npm',
        }));
    }
    if (options.yarn) {
        rules.push(schematics_1.schematic('plugin', {
            name: 'networkEnv',
            type: 'add',
            packageManager: 'yarn',
        }));
    }
    if (options.hmr) {
        rules.push(schematics_1.schematic('plugin', { name: 'hmr', type: 'add' }));
    }
    return schematics_1.chain(rules);
}
exports.default = default_1;
//# sourceMappingURL=index.js.map