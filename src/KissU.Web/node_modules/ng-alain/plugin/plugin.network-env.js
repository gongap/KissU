"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const CONFIG = {
    npm: {
        path: `./.npmrc`,
        content: `sass_binary_site=https://npm.taobao.org/mirrors/node-sass/
phantomjs_cdnurl=https://npm.taobao.org/mirrors/phantomjs/
electron_mirror=https://npm.taobao.org/mirrors/electron/
registry=https://registry.npm.taobao.org`,
    },
    yarn: {
        path: `./.yarnrc`,
        content: `sass_binary_site "https://npm.taobao.org/mirrors/node-sass/"
phantomjs_cdnurl "https://npm.taobao.org/mirrors/phantomjs/"
electron_mirror "https://npm.taobao.org/mirrors/electron/"
registry "https://registry.npm.taobao.org"`,
    },
};
function pluginNetworkEnv(options) {
    return (host, context) => {
        const item = CONFIG[options.packageManager || ''];
        if (item == null) {
            throw new schematics_1.SchematicsException(`Must be specified the "packageManager" parameter`);
        }
        if (host.exists(item.path)) {
            host.delete(item.path);
        }
        if (options.type === 'remove') {
            return;
        }
        host.create(item.path, item.content);
    };
}
exports.pluginNetworkEnv = pluginNetworkEnv;
//# sourceMappingURL=plugin.network-env.js.map