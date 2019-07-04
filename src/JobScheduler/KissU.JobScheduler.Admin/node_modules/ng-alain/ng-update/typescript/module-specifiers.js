"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const imports_1 = require("../typescript/imports");
exports.delonModulesSpecifier = [
    'abc',
    'acl',
    'auth',
    'cache',
    'form',
    'mock',
    'theme',
    'util',
    'chart',
].map(pkg => `@delon/${pkg}`);
/** Whether the specified node is part of an `@delon/*` declaration. */
function isDelonImportDeclaration(node) {
    return isDelonDeclaration(imports_1.getImportDeclaration(node));
}
exports.isDelonImportDeclaration = isDelonImportDeclaration;
/** Whether the specified node is part of an `@delon/*` import declaration. */
function isDelonExportDeclaration(node) {
    return isDelonDeclaration(imports_1.getExportDeclaration(node));
}
exports.isDelonExportDeclaration = isDelonExportDeclaration;
/** Whether the declaration is part of `@delon/*` */
function isDelonDeclaration(declaration) {
    if (!declaration.moduleSpecifier) {
        return false;
    }
    const moduleSpecifier = declaration.moduleSpecifier.getText();
    return exports.delonModulesSpecifier.some(k => moduleSpecifier.indexOf(k) !== -1);
}
//# sourceMappingURL=module-specifiers.js.map