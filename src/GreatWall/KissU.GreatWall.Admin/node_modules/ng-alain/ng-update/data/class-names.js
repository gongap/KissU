"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const target_version_1 = require("../target-version");
exports.classNames = {
    [target_version_1.TargetVersion.V2]: [
        {
            pr: '',
            changes: [
                {
                    replace: 'SimpleTableColumn',
                    replaceWith: 'STColumn',
                },
                {
                    replace: 'SimpleTableComponent',
                    replaceWith: 'STComponent',
                },
                {
                    replace: 'SimpleTableData',
                    replaceWith: 'STData',
                },
                {
                    replace: 'SimpleTableButton',
                    replaceWith: 'STColumnButton',
                },
                {
                    replace: 'SimpleTableChange',
                    replaceWith: 'STChange',
                },
                {
                    replace: 'AdPageHeaderConfig',
                    replaceWith: 'PageHeaderConfig',
                },
            ],
        },
    ],
};
//# sourceMappingURL=class-names.js.map