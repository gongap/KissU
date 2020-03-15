import { STColumn } from '@delon/abc';

/**
 * 应用定制列，一些简单规则：
 * - `ccChecked` 表示是否允许定制列，默认：`true`
 * - `ccDisabled` 表示是否禁止定制列，默认：`false`
 */
export function applyCC(list: STColumn[]) {
  list.forEach(i => {
    if (i.ccDisabled) return;
    i.iif = _ => _.ccDisabled !== true && _.ccChecked !== false;
  });
  return list;
}
