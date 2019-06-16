import { VersionChanges } from '../upgrade-data';
export interface ClassNameUpgradeData {
    /** The Class name to replace. */
    replace: string;
    /** The new name for the Class. */
    replaceWith: string;
}
export declare const classNames: VersionChanges<ClassNameUpgradeData>;
