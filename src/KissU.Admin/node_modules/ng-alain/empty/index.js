"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const alain_1 = require("../utils/alain");
function default_1(options) {
    return schematics_1.chain([alain_1.buildAlain(options)]);
}
exports.default = default_1;
//# sourceMappingURL=index.js.map