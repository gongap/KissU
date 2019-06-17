import { Rule, SchematicContext, Tree } from '@angular-devkit/schematics';
import {
  addPackageToPackageJson,
  removePackageFromPackageJson,
  scriptsToAngularJson,
} from '../utils/json';
import { PluginOptions } from './interface';

function g2Typing(host: Tree, options: PluginOptions) {
  const typingsPath = '/src/typings.d.ts';
  if (!host.exists(typingsPath)) {
    host.create(typingsPath, '');
  }
  let content = host.get(typingsPath).content.toString('UTF-8');
  if (content.includes('G2')) return;

  content += `\n// G2
declare var G2: any;
declare var DataSet: any;
declare var Slider: any;`;
  host.overwrite(typingsPath, content);
}

export function pluginG2(options: PluginOptions): Rule {
  return (host: Tree, context: SchematicContext) => {
    // typing
    g2Typing(host, options);
    // package
    (options.type === 'add' ? addPackageToPackageJson : removePackageFromPackageJson)(host, [
      '@antv/data-set@^0.10.1',
      '@antv/g2@^3.4.8',
      '@antv/g2-plugin-slider@^2.1.1',
    ]);
    // angular
    scriptsToAngularJson(
      host,
      [
        'node_modules/@antv/g2/dist/g2.min.js',
        'node_modules/@antv/data-set/dist/data-set.min.js',
        'node_modules/@antv/g2-plugin-slider/dist/g2-plugin-slider.min.js',
      ],
      options.type,
      ['build', 'test'],
      options.project,
    );
  };
}
