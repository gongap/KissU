"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
const path_1 = require("path");
/**
 * Overwrite files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
function overwriteFile(host, filePath, sourcePath, overwrite = false) {
    const isExists = host.exists(filePath);
    if (overwrite || isExists) {
        try {
            const buffer = fs.readFileSync(sourcePath);
            const content = buffer ? buffer.toString('utf-8') : '';
            if (overwrite) {
                if (isExists) {
                    host.delete(filePath);
                }
                host.create(filePath, content);
            }
            else {
                host.overwrite(filePath, content);
            }
        }
        catch (_a) { }
    }
    return host;
}
exports.overwriteFile = overwriteFile;
/**
 * Overwrite files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
function overwriteFiles(host, files, _filePath, overwrite = false) {
    files.forEach(p => overwriteFile(host, p, path_1.join(_filePath, p), overwrite));
    return host;
}
exports.overwriteFiles = overwriteFiles;
/**
 * Add files to the project
 *
 * @param [overwrite=false] `true` is force, default: `false`
 */
function addFiles(host, files, _filePath, overwrite = false) {
    files
        .filter(p => overwrite || !host.exists(p))
        .forEach(p => overwriteFile(host, p, path_1.join(_filePath, p), true));
    return host;
}
exports.addFiles = addFiles;
//# sourceMappingURL=file.js.map