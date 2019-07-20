"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const data_1 = require("./data");
const target_version_1 = require("./target-version");
exports.delonUpgradeData = {
    classNames: data_1.classNames,
    cssSelectors: data_1.cssSelectors,
};
/**
 * Gets the changes for a given target version from the specified version changes object.
 *
 * For readability and a good overview of breaking changes, the version change data always
 * includes the related Pull Request link. Since this data is not needed when performing the
 * upgrade, this unused data can be removed and the changes data can be flattened into an
 * easy iterable array.
 */
function getChangesForTarget(target, data) {
    if (!data) {
        throw new Error(`No data could be found for target version: ${target_version_1.TargetVersion[target]}`);
    }
    if (!data[target]) {
        return [];
    }
    return data[target].reduce((result, prData) => result.concat(prData.changes), []);
}
exports.getChangesForTarget = getChangesForTarget;
/**
 * Gets all changes from the specified version changes object. This is helpful in case a migration
 * rule does not distinguish data based on the target version, but for readability the
 * upgrade data is separated for each target version.
 */
function getAllChanges(data) {
    return Object.keys(data)
        .map(targetVersion => getChangesForTarget(parseInt(targetVersion, 10), data))
        .reduce((result, versionData) => result.concat(versionData), []);
}
exports.getAllChanges = getAllChanges;
/**
 * Gets the reduced upgrade data for the specified data key from the rule walker options.
 *
 * The function reads out the target version and upgrade data object from the rule options and
 * resolves the specified data portion that is specifically tied to the target version.
 */
function getUpgradeDataFromWalker(walker, dataName) {
    return getChangesForTarget(walker.getOptions()[0], walker.getOptions()[1][dataName]);
}
exports.getUpgradeDataFromWalker = getUpgradeDataFromWalker;
//# sourceMappingURL=upgrade-data.js.map