"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const json_1 = require("../utils/json");
function pluginCodeStyle(options) {
    return (host, context) => {
        const json = json_1.getJSON(host, 'package.json');
        if (json == null)
            return;
        if (options.type === 'add') {
            json.husky = {
                hooks: {
                    'pre-commit': 'npm run lint-staged',
                },
            };
        }
        else {
            delete json.husky;
        }
        json_1.overwritePackage(host, json);
    };
}
exports.pluginCodeStyle = pluginCodeStyle;
//# sourceMappingURL=plugin.code-style.js.map