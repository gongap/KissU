// ================ 树形表格查询基类 ==================

import { Injector, ViewChild, forwardRef, AfterViewInit } from '@angular/core';
import { util, ViewModel, QueryParameter, TreeTable } from '../index';

/**
 * 表格查询基类
 */
export abstract class TreeTableQueryComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> implements AfterViewInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 树形表格组件
     */
    @ViewChild(forwardRef(() => TreeTable)) protected table: TreeTable<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected abstract createQuery(): TQuery;

    /**
     * 视图加载完成
     */
    ngAfterViewInit() {
        if (!this.table)
            return;
        this.table.loadAfter = result => {
            this.loadAfter(result);
        };
    }

    /**
     * 查询
     * @param button 按钮
     */
    query(button) {
        this.table.query(button);
    }

    /**
     * 延迟搜索
     * @param button 按钮
     */
    search(button) {
        //this.table.search(button, this.getDelay());
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 清空复选框
     */
    clearCheckboxs() {
        //this.table.clearCheckboxs();
    }

    /**
     * 删除
     * @param button 按钮
     * @param id 标识
     */
    delete(button?, id?) {
        //this.table.delete(button, id);
    }

    /**
     * 刷新
     * @param button 按钮
     */
    refresh(button?) {
        this.queryParam = this.createQuery();
        this.table.refresh(this.queryParam, button);
    }

    /**
     * 获取选中项列表
     */
    getChecked() {
        return this.table.getChecked();
    }

    /**
     * 获取选中项标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }

    afterOperation(node, parentNode = null) {
        //this.table.afterOperation(node, parentNode);
    }

    /**
     * 选中实体
     */
    select() {
        const selection = this.getChecked();
        if (!selection || selection.length === 0) {
            this.util.dialog.close(new ViewModel());
            return;
        }
        if (selection.length === 1) {
            this.util.dialog.close(selection[0]);
            return;
        }
        this.util.dialog.close(selection);
    }

    /**
     * 修正排序
     */
    fixSort(id = null) {
        //this.table.fixSort(id);
    }

    /**
     * 修正排序
     */
    disable(id = null) {
        //this.table.disable(id);
    }

    /**
     * 修正排序
     */
    enable(id = null) {
        //this.table.enable(id);
    }

    /**
     * 数据加载完成操作
     * @param result result
     */
    loadAfter(result) {
    }
}
