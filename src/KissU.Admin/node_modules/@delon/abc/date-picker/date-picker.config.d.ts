export declare class DateRangePickerConfig {
    nzFormat?: string;
    nzClassName?: string;
    nzSize?: string;
    nzStyle?: string;
    nzAllowClear?: boolean;
    nzAutoFocus?: boolean;
    nzDisabled?: boolean;
    nzDisabledDate?: any;
    nzDisabledTime?: any;
    nzLocale?: any;
    nzPopupStyle?: any;
    nzDropdownClassName?: any;
    nzRenderExtraFooter?: any;
    nzPlaceHolder?: any;
    nzShowTime?: any;
    nzShowToday: boolean;
    nzMode?: any;
    nzRanges?: any;
    shortcuts?: DateRangePickerShortcut;
}
export interface DateRangePickerShortcut {
    /** Whether to enable, default: `false` */
    enabled?: boolean;
    /** Whether to close the panel after clicking, default: `true` */
    closed?: boolean;
    /**
     * Shortcut list, default: `今天`, `昨天`, `近3天`, `近7天`, `本周`, `本月`, `全年`
     */
    list?: DateRangePickerShortcutItem[];
}
export interface DateRangePickerShortcutItem {
    text: string;
    fn: (value: [Date, Date]) => [Date, Date];
}
export declare class DatePickerConfig {
    range?: DateRangePickerConfig;
}
