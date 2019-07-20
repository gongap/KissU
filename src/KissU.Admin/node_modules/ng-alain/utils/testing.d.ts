import { SchematicTestRunner, UnitTestTree } from '@angular-devkit/schematics/testing';
import { Schema as NgAddSchema } from '../ng-add/schema.d';
export declare const APPNAME = "foo";
export declare function createNgRunner(): SchematicTestRunner;
export declare function createAlainRunner(): SchematicTestRunner;
export declare function createAlainApp(ngAddOptions?: NgAddSchema): {
    runner: SchematicTestRunner;
    tree: UnitTestTree;
};
export declare function createAlainAndModuleApp(name?: string, ngAddOptions?: object): {
    runner: SchematicTestRunner;
    tree: UnitTestTree;
};
export declare function createTestApp(): UnitTestTree;
