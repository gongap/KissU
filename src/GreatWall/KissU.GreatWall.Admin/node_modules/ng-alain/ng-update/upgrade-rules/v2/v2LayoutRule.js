"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const change_1 = require("@schematics/angular/utility/change");
const ast_1 = require("../../../utils/ast");
const json_1 = require("../../../utils/json");
const lib_versions_1 = require("../../../utils/lib-versions");
const dom_service_1 = require("../../dom/dom.service");
const DOM = new dom_service_1.DomService();
function fixClass(host, src, classes) {
    if (!host.exists(src)) {
        console.log(`Not found in [${src}]`);
        return;
    }
    let content = host.read(src).toString();
    Object.keys(classes).forEach(key => {
        content = content.replace(key, classes[key]);
    });
    host.overwrite(src, content);
}
function fixVersion(host, context) {
    json_1.addPackageToPackageJson(host, [
        'abc',
        'acl',
        'auth',
        'cache',
        'form',
        'mock',
        'theme',
        'util',
        'chart',
    ].map(pkg => `@delon/${pkg}@${lib_versions_1.VERSION}`));
}
function fixStyles(host, context) {
    const filePath = 'src/styles.less';
    if (!host.exists(filePath)) {
        console.log(`Not found in [${filePath}]`);
        return;
    }
    let content = host.read(filePath).toString();
    [
        {
            key: `theme/styles/index';`,
            insert: `
@import '~@delon/theme/styles/layout/default/index';
@import '~@delon/theme/styles/layout/fullscreen/index';`,
        },
        {
            key: `abc/index';`,
            insert: `
@import '~@delon/chart/index';`,
        },
    ].forEach(item => {
        const pos = content.indexOf(item.key);
        if (pos === -1)
            return;
        content = content.replace(item.key, item.key + item.insert);
    });
    host.overwrite(filePath, content);
}
function fixDefaultHtml(host, context) {
    const filePath = 'src/app/layout/default/default.component.html';
    if (!host.exists(filePath)) {
        console.log(`Default layout not found in [${filePath}]`);
        return;
    }
    DOM.replace(host.read(filePath).toString(), [
        {
            type: 'attr',
            name: 'class',
            rules: [
                {
                    type: 'class-name',
                    value: 'router-progress-bar',
                    newValue: 'alain-default__progress-bar',
                },
                {
                    type: 'class-name',
                    value: 'header',
                    newValue: 'alain-default__header',
                },
                {
                    type: 'class-name',
                    value: 'aside',
                    newValue: 'alain-default__aside',
                },
                {
                    type: 'class-name',
                    value: 'content',
                    newValue: 'alain-default__content',
                },
                {
                    type: 'remove-wrap-element-by-class',
                    value: 'wrapper',
                },
            ],
        },
    ], dom => {
        host.overwrite(filePath, DOM.prettify(dom));
    });
}
function fixDefaultTs(host, context) {
    const filePath = 'src/app/layout/default/default.component.ts';
    if (!host.exists(filePath)) {
        console.log(`Default layout not found in [${filePath}]`);
        return;
    }
    ast_1.updateComponentMetadata(host, filePath, (node) => {
        const end = node.properties[node.properties.length - 1].end;
        const toInsert = `,
  host: {
    '[class.alain-default]': 'true',
  }`;
        return [new change_1.InsertChange(filePath, end, toInsert)];
    });
}
function fixFullScreenTs(host, context) {
    const filePath = 'src/app/layout/fullscreen/fullscreen.component.ts';
    if (!host.exists(filePath)) {
        console.log(`FullScreen layout not found in [${filePath}]`);
        return;
    }
    ast_1.updateComponentMetadata(host, filePath, (node) => {
        const end = node.properties[node.properties.length - 1].end;
        const toInsert = `,
  host: {
    '[class.alain-fullscreen]': 'true',
  }`;
        return [new change_1.InsertChange(filePath, end, toInsert)];
    });
}
function fixHeaderHtml(host, context) {
    const filePath = 'src/app/layout/default/header/header.component.html';
    if (!host.exists(filePath)) {
        console.log(`Default layout not found in [${filePath}]`);
        return;
    }
    DOM.replace(host.read(filePath).toString(), [
        {
            type: 'attr',
            name: 'class',
            rules: [
                {
                    type: 'class-name',
                    value: 'logo',
                    newValue: 'alain-default__header-logo',
                },
                {
                    type: 'class-name',
                    value: 'expanded',
                    newValue: 'alain-default__header-logo-expanded',
                },
                {
                    type: 'class-name',
                    value: 'collapsed',
                    newValue: 'alain-default__header-logo-collapsed',
                },
                {
                    type: 'class-name',
                    value: 'top-nav-wrap',
                    newValue: 'alain-default__nav-wrap',
                },
                {
                    type: 'class-name',
                    value: 'top-nav',
                    newValue: 'alain-default__nav',
                },
                {
                    type: 'class-name',
                    value: 'item',
                    newValue: 'alain-default__nav-item',
                },
                {
                    type: 'class-name',
                    value: 'hidden-xs',
                    newValue: 'hidden-mobile',
                },
                {
                    type: 'class-name',
                    value: 'header-search',
                    newValue: 'alain-default__search',
                },
            ],
        },
        {
            type: 'tag',
            name: 'a',
            custom: dom => {
                if (dom.parent != null &&
                    dom.parent.attribs &&
                    (dom.parent.attribs['class'] || '').includes('alain-default__header-logo')) {
                    const classes = (dom.attribs['class'] || '').split(' ');
                    classes.push('alain-default__header-logo-link');
                    dom.attribs['class'] = classes.join(' ');
                }
            },
        },
    ], dom => {
        host.overwrite(filePath, DOM.prettify(dom));
    });
}
function fixSidebarHtml(host, context) {
    const filePath = 'src/app/layout/default/sidebar/sidebar.component.html';
    if (!host.exists(filePath)) {
        console.log(`Default layout not found in [${filePath}]`);
        return;
    }
    DOM.replace(host.read(filePath).toString(), [
        {
            type: 'attr',
            name: 'class',
            rules: [
                {
                    type: 'class-name',
                    value: 'aside-inner',
                    newValue: 'alain-default__aside-inner',
                },
                {
                    type: 'class-name',
                    value: 'user-block',
                    newValue: 'alain-default__aside-user',
                },
                {
                    type: 'class-name',
                    value: 'avatar',
                    newValue: 'alain-default__aside-user-avatar',
                },
                {
                    type: 'class-name',
                    value: 'user-block-dropdown',
                    newValue: '',
                },
                {
                    type: 'class-name',
                    value: 'info',
                    newValue: 'alain-default__aside-user-info',
                },
            ],
        },
    ], dom => {
        host.overwrite(filePath, DOM.prettify(dom));
    });
}
function v2LayoutRule() {
    return (host, context) => {
        fixVersion(host, context);
        fixStyles(host, context);
        fixDefaultHtml(host, context);
        fixDefaultTs(host, context);
        fixHeaderHtml(host, context);
        fixClass(host, `src/app/layout/default/header/components/search.component.ts`, {
            'header-search__focus': 'alain-default__search-focus',
            'header-search__toggled': 'alain-default__search-toggled',
        });
        fixSidebarHtml(host, context);
        fixFullScreenTs(host, context);
    };
}
exports.v2LayoutRule = v2LayoutRule;
//# sourceMappingURL=v2LayoutRule.js.map