"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const testing_1 = require("@angular-devkit/schematics/testing");
const path_1 = require("path");
exports.APPNAME = 'foo';
function createNgRunner() {
    return new testing_1.SchematicTestRunner('schematics', path_1.join('./node_modules/@schematics/angular/collection.json'));
}
exports.createNgRunner = createNgRunner;
function createAlainRunner() {
    return new testing_1.SchematicTestRunner('schematics', path_1.join(__dirname, '../collection.json'));
}
exports.createAlainRunner = createAlainRunner;
function createAlainApp(ngAddOptions) {
    const baseRunner = createNgRunner();
    const workspaceTree = baseRunner.runSchematic('workspace', {
        name: 'workspace',
        newProjectRoot: 'projects',
        version: '6.0.0',
    });
    const appTree = baseRunner.runSchematic('application', {
        name: exports.APPNAME,
        inlineStyle: false,
        inlineTemplate: false,
        routing: false,
        style: 'css',
        skipTests: false,
        skipPackageJson: false,
    }, workspaceTree);
    const alainRunner = createAlainRunner();
    const tree = alainRunner.runSchematic('ng-add', Object.assign({ skipPackageJson: false }, ngAddOptions), appTree);
    return { runner: alainRunner, tree };
}
exports.createAlainApp = createAlainApp;
function createAlainAndModuleApp(name = 'trade', ngAddOptions) {
    const res = createAlainApp(ngAddOptions);
    res.tree = res.runner.runSchematic('module', { name, project: exports.APPNAME, routing: true }, res.tree);
    return res;
}
exports.createAlainAndModuleApp = createAlainAndModuleApp;
function createTestApp() {
    return createNgRunner().runSchematic('ng-new', {
        name: exports.APPNAME,
        directory: '',
        version: '6.0.0',
        routing: true,
        style: 'less',
    });
}
exports.createTestApp = createTestApp;
//# sourceMappingURL=testing.js.map