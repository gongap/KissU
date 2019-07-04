"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const lang_config_1 = require("../core/lang.config");
const project_1 = require("../utils/project");
function pluginDefaultLanguage(options) {
    return (host, context) => {
        if (options.type !== 'add') {
            throw new schematics_1.SchematicsException(`Can't be specified the "type" parameter`);
        }
        if (options.defaultLanguage == null) {
            throw new schematics_1.SchematicsException(`Must be specified the "defaultLanguage" parameter`);
        }
        const project = project_1.getProject(host, options.project);
        const modulePath = `${project.sourceRoot}/app/app.module.ts`;
        if (!host.exists(modulePath)) {
            throw new schematics_1.SchematicsException(`AppModule file (${modulePath}) not found`);
        }
        let content = host.get(modulePath).content.toString('UTF-8');
        const start = content.indexOf(`#region default language`);
        if (start === -1) {
            console.warn(`[#region default language] area not found`);
            return;
        }
        const oldMatch = content.match(/@angular\/common\/locales\/([^']+)/);
        const oldLang = oldMatch != null ? oldMatch[1] : 'zh-Hans';
        if (oldLang === options.defaultLanguage) {
            return;
        }
        const targetLang = lang_config_1.getLangConfig(options.defaultLanguage);
        if (targetLang == null) {
            console.warn(`Target language not supported, refer to https://ng-alain.com/cli/plugin#defaultLanguage`);
            return;
        }
        console.log(`Changes default languare [${oldLang}] to [${options.defaultLanguage}]`);
        // angular
        content = content
            .replace(/@angular\/common\/locales\/([^']+)/, `@angular/common/locales/${options.defaultLanguage}`)
            .replace(/abbr: '([^']+)/, `abbr: '${options.defaultLanguage}`);
        // zorro
        content = content.replace(/NZ_I18N, ([^ ]+)/, `NZ_I18N, ${targetLang.zorro}`);
        // delon
        content = content.replace(/DELON_LOCALE, ([^ ]+)/, `DELON_LOCALE, ${targetLang.zorro}`);
        host.overwrite(modulePath, content);
    };
}
exports.pluginDefaultLanguage = pluginDefaultLanguage;
//# sourceMappingURL=plugin.default-language.js.map