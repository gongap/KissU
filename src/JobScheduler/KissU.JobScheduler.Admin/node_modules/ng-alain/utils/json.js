"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const project_1 = require("./project");
function getJSON(host, jsonFile, type) {
    if (!host.exists(jsonFile))
        return null;
    const sourceText = host.read(jsonFile).toString('utf-8');
    const json = JSON.parse(sourceText);
    if (type && !json[type]) {
        json[type] = {};
    }
    return json;
}
exports.getJSON = getJSON;
function overwriteJSON(host, jsonFile, json) {
    host.overwrite(jsonFile, JSON.stringify(json, null, 2));
}
exports.overwriteJSON = overwriteJSON;
function getPackage(host, type) {
    return getJSON(host, 'package.json', type);
}
exports.getPackage = getPackage;
function overwritePackage(host, json) {
    return overwriteJSON(host, 'package.json', json);
}
exports.overwritePackage = overwritePackage;
/**
 * Adds a package to the package.json
 *
 * ```
 * addPackageToPackageJson(host, [ '＠delon/abc＠^1.0.0' ])
 * addPackageToPackageJson(host, [ '＠delon/abc＠^1.0.0' ], 'devDependencies')
 * ```
 */
function addPackageToPackageJson(host, pkg, type = 'dependencies') {
    const json = getJSON(host, 'package.json', type);
    if (json == null)
        return host;
    if (!Array.isArray(pkg))
        pkg = [pkg];
    pkg.forEach(p => {
        if (!json[type][p]) {
            const pos = p.lastIndexOf('@');
            json[type][p.substr(0, pos)] = p.substr(pos + 1);
        }
    });
    overwritePackage(host, json);
    return host;
}
exports.addPackageToPackageJson = addPackageToPackageJson;
/**
 * Removes a package to the package.json
 *
 * ```
 * addPackageToPackageJson(host, [ '＠delon/abc' ])
 * addPackageToPackageJson(host, [ '＠delon/abc' ], 'devDependencies')
 * ```
 */
function removePackageFromPackageJson(host, pkg, type = 'dependencies') {
    const json = getJSON(host, 'package.json', type);
    if (json == null)
        return host;
    if (!Array.isArray(pkg))
        pkg = [pkg];
    pkg.forEach(p => delete json[type][p.substr(0, p.lastIndexOf('@'))]);
    overwritePackage(host, json);
    return host;
}
exports.removePackageFromPackageJson = removePackageFromPackageJson;
function getAngular(host, type) {
    return getJSON(host, 'angular.json', type);
}
exports.getAngular = getAngular;
function overwriteAngular(host, json) {
    return overwriteJSON(host, 'angular.json', json);
}
exports.overwriteAngular = overwriteAngular;
function scriptsToAngularJson(host, resources, behavior, types = ['build', 'test'], projectName, clean = false) {
    const json = getAngular(host);
    const project = project_1.getProjectFromWorkspace(json, projectName);
    types.forEach(type => {
        const scriptsNode = (project.targets || project.architect)[type].options.scripts;
        const stylesNode = (project.targets || project.architect)[type].options.styles;
        for (const path of resources) {
            const list = path.endsWith('.js') ? scriptsNode : stylesNode;
            if (clean === true)
                list.length = 0;
            if (behavior === 'add') {
                list.push(path);
            }
            else {
                const idx = list.indexOf(path);
                if (idx !== -1) {
                    list.splice(idx, 1);
                }
            }
        }
    });
    overwriteAngular(host, json);
    return host;
}
exports.scriptsToAngularJson = scriptsToAngularJson;
//# sourceMappingURL=json.js.map