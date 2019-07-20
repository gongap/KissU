"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const fs = require("fs");
const path = require("path");
const rxjs_1 = require("rxjs");
const operators_1 = require("rxjs/operators");
const alain_1 = require("../utils/alain");
const REFER = ', please refer to: https://ng-alain.com/cli/generate#%E8%87%AA%E5%AE%9A%E4%B9%89%E9%A1%B5';
function genFiles(options) {
    return (host, context) => {
        options._tplDir = path.join(process.cwd(), './_cli-tpl');
        try {
            fs.accessSync(options._tplDir);
        }
        catch (_a) {
            throw new schematics_1.SchematicsException(`Invalid path [${options._tplDir}]${REFER}`);
        }
        const names = fs.readdirSync(options._tplDir);
        if (names.indexOf(options.tplName) === -1) {
            throw new schematics_1.SchematicsException(`Could not find name [${options.tplName}] templates${REFER}`);
        }
        options._filesPath = path.relative(__dirname, path.join(options._tplDir, options.tplName));
    };
}
function parseExtraArgs(options) {
    const org = options['--'];
    if (!org || !Array.isArray(org)) {
        return;
    }
    options.extraArgs = {};
    org.forEach(val => {
        const argArr = val.substr(2).split('=');
        if (argArr.length === 2) {
            options.extraArgs[argArr[0]] = argArr[1];
        }
    });
}
function runFixJS(options) {
    parseExtraArgs(options);
    return (host, context) => {
        return rxjs_1.of(host).pipe(operators_1.mergeMap(val => {
            const fixScriptPath = path.join(options._tplDir, '_fix.js');
            if (fs.existsSync(fixScriptPath)) {
                return Promise.resolve().then(() => require(path.relative(__dirname, fixScriptPath))).then(a => {
                    if (a.fix) {
                        return a.fix(options).then(() => val);
                    }
                    return val;
                });
            }
            return Promise.resolve(val);
        }));
    };
}
function default_1(options) {
    return schematics_1.chain([genFiles(options), runFixJS(options), alain_1.buildAlain(options)]);
}
exports.default = default_1;
//# sourceMappingURL=index.js.map