"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular-devkit/core");
const schematics_1 = require("@angular-devkit/schematics");
const tasks_1 = require("@angular-devkit/schematics/tasks");
const path = require("path");
const lang_config_1 = require("../core/lang.config");
const alain_1 = require("../utils/alain");
const contents_1 = require("../utils/contents");
const file_1 = require("../utils/file");
const html_1 = require("../utils/html");
const json_1 = require("../utils/json");
const lib_versions_1 = require("../utils/lib-versions");
const project_1 = require("../utils/project");
const overwriteDataFileRoot = path.join(__dirname, 'overwrites');
let project;
/** Remove files to be overwrite */
function removeOrginalFiles() {
    return (host) => {
        [
            `${project.root}/README.md`,
            `${project.sourceRoot}/main.ts`,
            `${project.sourceRoot}/environments/environment.prod.ts`,
            `${project.sourceRoot}/environments/environment.ts`,
            `${project.sourceRoot}/styles.less`,
            `${project.sourceRoot}/app/app.module.ts`,
            `${project.sourceRoot}/app/app.component.spec.ts`,
            `${project.sourceRoot}/app/app.component.ts`,
            `${project.sourceRoot}/app/app.component.html`,
            `${project.sourceRoot}/app/app.component.less`,
        ]
            .filter(p => host.exists(p))
            .forEach(p => host.delete(p));
    };
}
function fixMain() {
    return (host) => {
        // fix: main.ts using no hmr file
        alain_1.tryAddFile(host, `${project.sourceRoot}/main.ts`, contents_1.HMR_CONTENT.NO_HMR_MAIN_DOT_TS);
    };
}
function addDependenciesToPackageJson(options) {
    return (host, context) => {
        // 3rd
        json_1.addPackageToPackageJson(host, [
            // allow ignore ng-zorro-antd becauce of @delon/theme dependency
            `ng-zorro-antd@${lib_versions_1.ZORROVERSION}`,
            // ng-zorro-antd need
            'screenfull@~4.0.0',
            'ajv@^6.9.2',
        ]);
        // add ajv
        json_1.scriptsToAngularJson(host, ['node_modules/ajv/dist/ajv.bundle.js'], 'add', ['build', 'test']);
        // @delon/*
        json_1.addPackageToPackageJson(host, ['abc', 'acl', 'auth', 'cache', 'form', 'mock', 'theme', 'util', 'chart'].map(pkg => `@delon/${pkg}@${lib_versions_1.VERSION}`));
        // ng-alain
        json_1.addPackageToPackageJson(host, [
            `ng-alain@${lib_versions_1.VERSION}`,
            `ng-alain-codelyzer@^0.0.1`,
            `@delon/testing@${lib_versions_1.VERSION}`,
            // color-less
            `less-bundle-promise@^1.0.7`,
        ], 'devDependencies');
        // i18n
        if (options.i18n) {
            json_1.addPackageToPackageJson(host, [
                `@ngx-translate/core@^11.0.1`,
                `@ngx-translate/http-loader@^4.0.0`,
            ]);
        }
        return host;
    };
}
function addRunScriptToPackageJson() {
    return (host, context) => {
        const json = json_1.getPackage(host, 'scripts');
        if (json == null)
            return host;
        json.scripts.start = `npm run color-less && ng serve -o`;
        json.scripts.build = `npm run color-less && ng build --prod --build-optimizer`;
        json.scripts.analyze = `npm run color-less && ng build --prod --build-optimizer --stats-json`;
        json.scripts['test-coverage'] = `ng test --code-coverage --watch=false`;
        json.scripts['color-less'] = `node scripts/color-less.js`;
        json.scripts.icon = `ng g ng-alain:plugin icon`;
        json_1.overwritePackage(host, json);
        return host;
    };
}
function addPathsToTsConfig() {
    return (host, context) => {
        [
            {
                path: 'tsconfig.json',
                baseUrl: `${project.sourceRoot}/`,
            },
            {
                path: `${project.sourceRoot}/tsconfig.app.json`,
                baseUrl: './',
            },
            {
                path: `${project.sourceRoot}/tsconfig.spec.json`,
                baseUrl: './',
            },
        ].forEach(item => {
            const json = json_1.getJSON(host, item.path, 'compilerOptions');
            if (json == null)
                return host;
            if (!json.compilerOptions)
                json.compilerOptions = {};
            if (!json.compilerOptions.paths)
                json.compilerOptions.paths = {};
            json.compilerOptions.baseUrl = item.baseUrl;
            const paths = json.compilerOptions.paths;
            paths['@shared'] = ['app/shared/index'];
            paths['@shared/*'] = ['app/shared/*'];
            paths['@core'] = ['app/core/index'];
            paths['@core/*'] = ['app/core/*'];
            paths['@env/*'] = ['environments/*'];
            json_1.overwriteJSON(host, item.path, json);
        });
        return host;
    };
}
function addCodeStylesToPackageJson() {
    return (host, context) => {
        const json = json_1.getPackage(host);
        if (json == null)
            return host;
        json.scripts.lint = `npm run lint:ts && npm run lint:style`;
        json.scripts['lint:ts'] = `tslint -p src/tsconfig.app.json -c tslint.json 'src/**/*.ts'`;
        json.scripts['lint:style'] = `stylelint \"{src}/**/*.less\" --syntax less`;
        json.scripts['lint-staged'] = `lint-staged`;
        json.scripts['tslint-check'] = `tslint-config-prettier-check ./tslint.json`;
        json['lint-staged'] = {
            '*.{cmd,html,json,md,sh,txt,xml,yml}': ['editorconfig-tools fix', 'git add'],
            '*.ts': ['npm run lint:ts', 'prettier --write', 'git add'],
            '*.less': ['npm run lint:style', 'prettier --write', 'git add'],
            ignore: ['src/assets/*'],
        };
        json_1.overwritePackage(host, json);
        // tslint
        const tsLint = json_1.getJSON(host, 'tslint.json', 'rules');
        tsLint.rules.curly = false;
        tsLint.rules['use-host-property-decorator'] = false;
        tsLint.rules['directive-selector'] = [
            true,
            'attribute',
            [project.prefix, 'passport', 'exception', 'layout', 'header'],
            'camelCase',
        ];
        tsLint.rules['component-selector'] = [
            true,
            'element',
            [project.prefix, 'passport', 'exception', 'layout', 'header'],
            'kebab-case',
        ];
        json_1.overwriteJSON(host, 'tslint.json', tsLint);
        // app tslint
        const sourceTslint = `${project.sourceRoot}/tslint.json`;
        if (host.exists(sourceTslint)) {
            const appTsLint = json_1.getJSON(host, sourceTslint, 'rules');
            appTsLint.rules['directive-selector'] = [
                true,
                'attribute',
                [project.prefix, 'passport', 'exception', 'layout', 'header'],
                'camelCase',
            ];
            appTsLint.rules['component-selector'] = [
                true,
                'element',
                [project.prefix, 'passport', 'exception', 'layout', 'header'],
                'kebab-case',
            ];
            json_1.overwriteJSON(host, sourceTslint, appTsLint);
        }
        // dependencies
        json_1.addPackageToPackageJson(host, [
            `tslint-config-prettier@^1.18.0`,
            `tslint-language-service@^0.9.9`,
            `editorconfig-tools@^0.1.1`,
            `lint-staged@^8.1.0`,
            `husky@^1.3.1`,
            `prettier@^1.16.1`,
            `prettier-stylelint@^0.4.2`,
            `stylelint@^9.10.1`,
            `stylelint-config-standard@^18.2.0`,
        ]);
        return host;
    };
}
function addSchematics() {
    return (host, context) => {
        const angularJsonFile = 'angular.json';
        const json = json_1.getJSON(host, angularJsonFile, 'schematics');
        if (json == null)
            return host;
        json.schematics['ng-alain:module'] = {
            routing: true,
            spec: false,
        };
        json.schematics['ng-alain:list'] = {
            spec: false,
        };
        json.schematics['ng-alain:edit'] = {
            spec: false,
            modal: true,
        };
        json.schematics['ng-alain:view'] = {
            spec: false,
            modal: true,
        };
        json.schematics['ng-alain:curd'] = {
            spec: false,
        };
        json.schematics['@schematics/angular:module'] = {
            routing: true,
            spec: false,
        };
        json.schematics['@schematics/angular:component'] = {
            spec: false,
            flat: false,
            inlineStyle: true,
            inlineTemplate: false,
        };
        json.schematics['@schematics/angular:directive'] = {
            spec: false,
        };
        json.schematics['@schematics/angular:service'] = {
            spec: false,
        };
        json_1.overwriteJSON(host, angularJsonFile, json);
    };
}
function forceLess() {
    return (host, context) => {
        json_1.scriptsToAngularJson(host, ['src/styles.less'], 'add', ['build'], null, true);
    };
}
function addStyle(options) {
    return (host) => {
        html_1.addHeadStyle(host, project, `  <style type="text/css">.preloader{position:fixed;top:0;left:0;width:100%;height:100%;overflow:hidden;background:#49a9ee;z-index:9999;transition:opacity .65s}.preloader-hidden-add{opacity:1;display:block}.preloader-hidden-add-active{opacity:0}.preloader-hidden{display:none}.cs-loader{position:absolute;top:0;left:0;height:100%;width:100%}.cs-loader-inner{transform:translateY(-50%);top:50%;position:absolute;width:100%;color:#fff;text-align:center}.cs-loader-inner label{font-size:20px;opacity:0;display:inline-block}@keyframes lol{0%{opacity:0;transform:translateX(-300px)}33%{opacity:1;transform:translateX(0)}66%{opacity:1;transform:translateX(0)}100%{opacity:0;transform:translateX(300px)}}.cs-loader-inner label:nth-child(6){animation:lol 3s infinite ease-in-out}.cs-loader-inner label:nth-child(5){animation:lol 3s .1s infinite ease-in-out}.cs-loader-inner label:nth-child(4){animation:lol 3s .2s infinite ease-in-out}.cs-loader-inner label:nth-child(3){animation:lol 3s .3s infinite ease-in-out}.cs-loader-inner label:nth-child(2){animation:lol 3s .4s infinite ease-in-out}.cs-loader-inner label:nth-child(1){animation:lol 3s .5s infinite ease-in-out}</style>`);
        html_1.addHtmlToBody(host, project, `  <div class="preloader"><div class="cs-loader"><div class="cs-loader-inner"><label>	●</label><label>	●</label><label>	●</label><label>	●</label><label>	●</label><label>	●</label></div></div>\n`);
        // add styles
        file_1.addFiles(host, [`${project.sourceRoot}/styles/index.less`, `${project.sourceRoot}/styles/theme.less`], overwriteDataFileRoot);
        return host;
    };
}
function mergeFiles(options, from, to) {
    return schematics_1.mergeWith(schematics_1.apply(schematics_1.url(from), [
        options.i18n ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('i18n') === -1),
        options.form ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('json-schema') === -1),
        schematics_1.template(Object.assign({ utils: core_1.strings }, options, { dot: '.', VERSION: lib_versions_1.VERSION,
            ZORROVERSION: lib_versions_1.ZORROVERSION })),
        schematics_1.move(to),
    ]));
}
function addCliTpl(options) {
    const TPLS = {
        '__name@dasherize__.component.html': `<page-header></page-header>`,
        '__name@dasherize__.component.ts': `import { Component, OnInit<% if(!!viewEncapsulation) { %>, ViewEncapsulation<% }%><% if(changeDetection !== 'Default') { %>, ChangeDetectionStrategy<% }%> } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: '<%= selector %>',
  templateUrl: './<%= dasherize(name) %>.component.html',<% if(!inlineStyle) { %><% } else { %>
  styleUrls: ['./<%= dasherize(name) %>.component.<%= styleext %>']<% } %><% if(!!viewEncapsulation) { %>,
  encapsulation: ViewEncapsulation.<%= viewEncapsulation %><% } if (changeDetection !== 'Default') { %>,
  changeDetection: ChangeDetectionStrategy.<%= changeDetection %><% } %>
})
export class <%= componentName %> implements OnInit {

  constructor(private http: _HttpClient, private msg: NzMessageService) { }

  ngOnInit() { }

}
`,
        '__name@dasherize__.component.spec.ts': `import { async, ComponentFixture, TestBed } from '@angular/core/testing';
  import { <%= componentName %> } from './<%= dasherize(name) %>.component';

  describe('<%= componentName %>', () => {
    let component: <%= componentName %>;
    let fixture: ComponentFixture<<%= componentName %>>;

    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ <%= componentName %> ]
      })
      .compileComponents();
    }));

    beforeEach(() => {
      fixture = TestBed.createComponent(<%= componentName %>);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });

    it('should create', () => {
      expect(component).toBeTruthy();
    });
  });
  `,
    };
    return (host) => {
        const prefix = `${project.root}/_cli-tpl/test/__path__/__name@dasherize@if-flat__/`;
        Object.keys(TPLS).forEach(name => {
            const realPath = prefix + name;
            if (host.exists(realPath)) {
                host.overwrite(realPath, TPLS[name]);
            }
            else {
                host.create(realPath, TPLS[name]);
            }
        });
    };
}
function addFilesToRoot(options) {
    return schematics_1.chain([
        schematics_1.mergeWith(schematics_1.apply(schematics_1.url('./files/src'), [
            options.i18n ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('i18n') === -1),
            options.form ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('json-schema') === -1),
            schematics_1.template(Object.assign({ utils: core_1.strings }, options, { dot: '.', VERSION: lib_versions_1.VERSION,
                ZORROVERSION: lib_versions_1.ZORROVERSION })),
            schematics_1.move(project.sourceRoot),
        ])),
        schematics_1.mergeWith(schematics_1.apply(schematics_1.url('./files/root'), [
            options.i18n ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('i18n') === -1),
            options.form ? schematics_1.noop() : schematics_1.filter(p => p.indexOf('json-schema') === -1),
            schematics_1.template(Object.assign({ utils: core_1.strings }, options, { dot: '.', VERSION: lib_versions_1.VERSION,
                ZORROVERSION: lib_versions_1.ZORROVERSION })),
        ]), schematics_1.MergeStrategy.Overwrite),
    ]);
}
function fixLang(options) {
    return (host) => {
        if (options.i18n)
            return;
        const langs = lang_config_1.getLangData(options.defaultLanguage);
        if (!langs)
            return;
        console.log(`Translating, please wait...`);
        host.visit(p => {
            if (~p.indexOf(`/node_modules/`))
                return;
            fixLangInHtml(host, p, langs);
        });
    };
}
function fixLangInHtml(host, p, langs) {
    let html = host.get(p).content.toString('utf8');
    let matchCount = 0;
    // {{(status ? 'menu.fullscreen.exit' : 'menu.fullscreen') | translate }}
    html = html.replace(/\{\{\(status \? '([^']+)' : '([^']+)'\) \| translate \}\}/g, (word, key1, key2) => {
        ++matchCount;
        return `{{ status ? '${langs[key1] || key1}' : '${langs[key2] || key2}' }}`;
    });
    // {{ 'app.register-result.msg' | translate:params }}
    html = html.replace(/\{\{[ ]?'([^']+)'[ ]? \| translate:[^ ]+ \}\}/g, (word, key) => {
        ++matchCount;
        return langs[key] || key;
    });
    // {{ 'Please enter mobile number!' | translate }}
    html = html.replace(/\{\{[ ]?'([^']+)' \| translate[ ]?\}\}/g, (word, key) => {
        ++matchCount;
        return langs[key] || key;
    });
    // [nzTitle]="'app.login.tab-login-credentials' | translate"
    html = html.replace(/'([^']+)' \| translate[ ]?/g, (word, key) => {
        ++matchCount;
        const value = langs[key] || key;
        return `'${value}'`;
    });
    // 'app.register.get-verification-code' | translate
    html = html.replace(/'([^']+)' \| translate/g, (word, key) => {
        ++matchCount;
        return langs[key] || key;
    });
    // removed `header-i18n`
    if (~html.indexOf(`<header-i18n [showLang]="false" class="langs"></header-i18n>`)) {
        ++matchCount;
        html = html.replace(`<header-i18n [showLang]="false" class="langs"></header-i18n>`, ``);
    }
    if (matchCount > 0) {
        host.overwrite(p, html);
    }
}
function fixVsCode(options) {
    return (host) => {
        const filePath = '.vscode/extensions.json';
        let json = json_1.getJSON(host, filePath);
        if (json == null) {
            host.create(filePath, '');
            json = {};
        }
        json.recommendations = ['cipchk.ng-alain-extension-pack'];
        json_1.overwriteJSON(host, filePath, json);
    };
}
function installPackages() {
    return (host, context) => {
        console.log(`Start installing dependencies, please wait...`);
        context.addTask(new tasks_1.NodePackageInstallTask());
    };
}
function default_1(options) {
    return (host, context) => {
        project = project_1.getProject(host, options.project);
        return schematics_1.chain([
            // @delon/* dependencies
            addDependenciesToPackageJson(options),
            // ci
            addRunScriptToPackageJson(),
            addPathsToTsConfig(),
            // code style
            addCodeStylesToPackageJson(),
            addSchematics(),
            // files
            removeOrginalFiles(),
            addFilesToRoot(options),
            addCliTpl(options),
            fixMain(),
            forceLess(),
            addStyle(options),
            fixLang(options),
            fixVsCode(options),
            installPackages(),
        ])(host, context);
    };
}
exports.default = default_1;
//# sourceMappingURL=index.js.map