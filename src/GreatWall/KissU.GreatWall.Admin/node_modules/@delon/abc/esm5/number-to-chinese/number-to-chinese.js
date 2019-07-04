/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
/**
 * @param {?} value
 * @param {?=} rmb
 * @param {?=} options
 * @return {?}
 */
export function numberToChinese(value, rmb, options) {
    if (rmb === void 0) { rmb = true; }
    var _a;
    options = tslib_1.__assign({ minusSymbol: '负', validThrow: false }, options);
    if (typeof value === 'number')
        value = value.toString();
    if (!/^-?\d+(\.\d+)?$/.test(value) && options.validThrow)
        throw new Error(value + " is invalid number type");
    /** @type {?} */
    var integer;
    /** @type {?} */
    var decimal;
    _a = tslib_1.__read(value.split('.'), 2), integer = _a[0], decimal = _a[1];
    /** @type {?} */
    var symbol = '';
    if (integer.startsWith('-')) {
        symbol = options.minusSymbol;
        integer = integer.substr(1);
    }
    if (/^-?\d+$/.test(value))
        decimal = null;
    integer = (+integer).toString();
    /** @type {?} */
    var unit = {
        num: rmb
            ? ['', '壹', '贰', '叁', '肆', '伍', '陆', '柒', '捌', '玖', '点']
            : ['', '一', '二', '三', '四', '五', '六', '七', '八', '九', '点'],
        radice: rmb
            ? [
                '',
                '拾',
                '佰',
                '仟',
                '万',
                '拾',
                '佰',
                '仟',
                '亿',
                '拾',
                '佰',
                '仟',
                '万亿',
                '拾',
                '佰',
                '仟',
                '兆',
                '拾',
                '佰',
                '仟',
            ]
            : [
                '',
                '十',
                '百',
                '千',
                '万',
                '十',
                '百',
                '千',
                '亿',
                '十',
                '百',
                '千',
                '万亿',
                '十',
                '百',
                '千',
                '兆',
                '十',
                '百',
                '千',
            ],
        dec: ['角', '分', '厘', '毫'],
    };
    if (rmb)
        value = (+value).toFixed(5).toString();
    /** @type {?} */
    var integerRes = '';
    /** @type {?} */
    var integerCount = integer.length;
    if (integer === '0' || integerCount === 0) {
        integerRes = '零';
    }
    else {
        /** @type {?} */
        var cnDesc = '';
        for (var i = 0; i < integerCount; i++) {
            /** @type {?} */
            var n = +integer[i];
            /** @type {?} */
            var j = integerCount - i - 1;
            /** @type {?} */
            var isZero = i > 1 && n !== 0 && integer[i - 1] === '0';
            /** @type {?} */
            var cnZero = isZero ? '零' : '';
            /** @type {?} */
            var isEmpptyUnit = (n === 0 && j % 4 !== 0) || integer.substr(i - 3, 4) === '0000';
            /** @type {?} */
            var descMark = cnDesc;
            /** @type {?} */
            var cnNum = unit.num[n];
            cnDesc = isEmpptyUnit ? '' : unit.radice[j];
            // 第一位是一十
            if (i === 0 && cnNum === '一' && cnDesc === '十')
                cnNum = '';
            /** @type {?} */
            var isChangeEr = n > 1 &&
                cnNum === '二' && // 去除首位
                ['', '十', '百'].indexOf(cnDesc) === -1 && // 不读两\两十\两百
                descMark !== '十';
            if (isChangeEr)
                cnNum = '两';
            integerRes += cnZero + cnNum + cnDesc;
        }
    }
    // 小数部分拼接
    /** @type {?} */
    var decimalRes = '';
    /** @type {?} */
    var decimalCount = decimal ? decimal.toString().length : 0;
    if (decimal === null) {
        decimalRes = rmb ? '整' : '';
    }
    else if (decimal === '0') {
        decimalRes = '零';
    }
    else {
        for (var i = 0; i < decimalCount; i++) {
            if (rmb && i > unit.dec.length - 1)
                break;
            /** @type {?} */
            var n = decimal[i];
            /** @type {?} */
            var cnZero = n === '0' ? '零' : '';
            /** @type {?} */
            var cnNum = unit.num[n];
            /** @type {?} */
            var cnDesc = rmb ? unit.dec[i] : '';
            decimalRes += cnZero + cnNum + cnDesc;
        }
    }
    /** @type {?} */
    var ret = symbol +
        (rmb
            ? integerRes + (decimalRes === '零' ? '元整' : "\u5143" + decimalRes)
            : integerRes + (decimalRes === '' ? '' : "\u70B9" + decimalRes));
    return ret;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnVtYmVyLXRvLWNoaW5lc2UuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL251bWJlci10by1jaGluZXNlLyIsInNvdXJjZXMiOlsibnVtYmVyLXRvLWNoaW5lc2UudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7QUFFQSxNQUFNLFVBQVUsZUFBZSxDQUM3QixLQUFzQixFQUN0QixHQUFVLEVBQ1YsT0FBZ0M7SUFEaEMsb0JBQUEsRUFBQSxVQUFVOztJQUdWLE9BQU8sc0JBQ0wsV0FBVyxFQUFFLEdBQUcsRUFDaEIsVUFBVSxFQUFFLEtBQUssSUFDZCxPQUFPLENBQ1gsQ0FBQztJQUNGLElBQUksT0FBTyxLQUFLLEtBQUssUUFBUTtRQUFFLEtBQUssR0FBRyxLQUFLLENBQUMsUUFBUSxFQUFFLENBQUM7SUFDeEQsSUFBSSxDQUFDLGlCQUFpQixDQUFDLElBQUksQ0FBQyxLQUFLLENBQUMsSUFBSSxPQUFPLENBQUMsVUFBVTtRQUN0RCxNQUFNLElBQUksS0FBSyxDQUFJLEtBQUssNEJBQXlCLENBQUMsQ0FBQzs7UUFDakQsT0FBd0I7O1FBQ3hCLE9BQXdCO0lBQzVCLHdDQUFxQyxFQUFwQyxlQUFPLEVBQUUsZUFBTyxDQUFxQjs7UUFDbEMsTUFBTSxHQUFHLEVBQUU7SUFDZixJQUFJLE9BQU8sQ0FBQyxVQUFVLENBQUMsR0FBRyxDQUFDLEVBQUU7UUFDM0IsTUFBTSxHQUFHLE9BQU8sQ0FBQyxXQUFXLENBQUM7UUFDN0IsT0FBTyxHQUFHLE9BQU8sQ0FBQyxNQUFNLENBQUMsQ0FBQyxDQUFDLENBQUM7S0FDN0I7SUFDRCxJQUFJLFNBQVMsQ0FBQyxJQUFJLENBQUMsS0FBSyxDQUFDO1FBQUUsT0FBTyxHQUFHLElBQUksQ0FBQztJQUMxQyxPQUFPLEdBQUcsQ0FBQyxDQUFDLE9BQU8sQ0FBQyxDQUFDLFFBQVEsRUFBRSxDQUFDOztRQUMxQixJQUFJLEdBQUc7UUFDWCxHQUFHLEVBQUUsR0FBRztZQUNOLENBQUMsQ0FBQyxDQUFDLEVBQUUsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsRUFBRSxHQUFHLENBQUM7WUFDeEQsQ0FBQyxDQUFDLENBQUMsRUFBRSxFQUFFLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsQ0FBQztRQUMxRCxNQUFNLEVBQUUsR0FBRztZQUNULENBQUMsQ0FBQztnQkFDRSxFQUFFO2dCQUNGLEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxJQUFJO2dCQUNKLEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7YUFDSjtZQUNILENBQUMsQ0FBQztnQkFDRSxFQUFFO2dCQUNGLEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxJQUFJO2dCQUNKLEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7Z0JBQ0gsR0FBRztnQkFDSCxHQUFHO2dCQUNILEdBQUc7YUFDSjtRQUNMLEdBQUcsRUFBRSxDQUFDLEdBQUcsRUFBRSxHQUFHLEVBQUUsR0FBRyxFQUFFLEdBQUcsQ0FBQztLQUMxQjtJQUNELElBQUksR0FBRztRQUFFLEtBQUssR0FBRyxDQUFDLENBQUMsS0FBSyxDQUFDLENBQUMsT0FBTyxDQUFDLENBQUMsQ0FBQyxDQUFDLFFBQVEsRUFBRSxD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QyxDQUFDLENBQUMsQ0FBQyxDQUFDLENBQUMsRUFBRTtZQUNyQyxVQUFVLElBQUksTUFBTSxHQUFHLEtBQUssR0FBRyxNQUFNLENBQUM7U0FDdkM7S0FDRjs7UUFDSyxHQUFHLEdBQ1AsTUFBTTtRQUNOLENBQUMsR0FBRztZQUNGLENBQUMsQ0FBQyxVQUFVLEdBQUcsQ0FBQyxVQUFVLEtBQUssR0FBRyxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsQ0FBQyxDQUFDLFdBQUksVUFBWSxDQUFDO1lBQzdELENBQUMsQ0FBQyxVQUFVLEdBQUcsQ0FBQyxVQUFVLEtBQUssRUFBRSxDQUFDLENBQUMsQ0FBQyxFQUFFLENBQUMsQ0FBQyxDQUFDLFdBQUksVUFBWSxDQUFDLENBQUM7SUFDL0QsT0FBTyxHQUFHLENBQUM7QUFDYixDQUFDIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgTnVtYmVyVG9DaGluZXNlT3B0aW9ucyB9IGZyb20gJy4vbnVtYmVyLXRvLWNoaW5lc2UuaW50ZXJmYWNlcyc7XG5cbmV4cG9ydCBmdW5jdGlvbiBudW1iZXJUb0NoaW5lc2UoXG4gIHZhbHVlOiBudW1iZXIgfCBzdHJpbmcsXG4gIHJtYiA9IHRydWUsXG4gIG9wdGlvbnM/OiBOdW1iZXJUb0NoaW5lc2VPcHRpb25zLFxuKTogc3RyaW5nIHtcbiAgb3B0aW9ucyA9IHtcbiAgICBtaW51c1N5bWJvbDogJ+i0nycsXG4gICAgdmFsaWRUaHJvdzogZmFsc2UsXG4gICAgLi4ub3B0aW9ucyxcbiAgfTtcbiAgaWYgKHR5cGVvZiB2YWx1ZSA9PT0gJ251bWJlcicpIHZhbHVlID0gdmFsdWUudG9TdHJpbmcoKTtcbiAgaWYgKCEvXi0/XFxkKyhcXC5cXGQrKT8kLy50ZXN0KHZhbHVlKSAmJiBvcHRpb25zLnZhbGlkVGhyb3cpXG4gICAgdGhyb3cgbmV3IEVycm9yKGAke3ZhbHVlfSBpcyBpbnZhbGlkIG51bWJlciB0eXBlYCk7XG4gIGxldCBpbnRlZ2VyOiBudW1iZXIgfCBzdHJpbmc7XG4gIGxldCBkZWNpbWFsOiBudW1iZXIgfCBzdHJpbmc7XG4gIFtpbnRlZ2VyLCBkZWNpbWFsXSA9IHZhbHVlLnNwbGl0KCcuJyk7XG4gIGxldCBzeW1ib2wgPSAnJztcbiAgaWYgKGludGVnZXIuc3RhcnRzV2l0aCgnLScpKSB7XG4gICAgc3ltYm9sID0gb3B0aW9ucy5taW51c1N5bWJvbDtcbiAgICBpbnRlZ2VyID0gaW50ZWdlci5zdWJzdHIoMSk7XG4gIH1cbiAgaWYgKC9eLT9cXGQrJC8udGVzdCh2YWx1ZSkpIGRlY2ltYWwgPSBudWxsO1xuICBpbnRlZ2VyID0gKCtpbnRlZ2VyKS50b1N0cmluZygpO1xuICBjb25zdCB1bml0ID0ge1xuICAgIG51bTogcm1iXG4gICAgICA/IFsnJywgJ+WjuScsICfotLAnLCAn5Y+BJywgJ+iChicsICfkvI0nLCAn6ZmGJywgJ+afkicsICfmjYwnLCAn546WJywgJ+eCuSddXG4gICAgICA6IFsnJywgJ+S4gCcsICfkuownLCAn5LiJJywgJ+WbmycsICfkupQnLCAn5YWtJywgJ+S4gycsICflhasnLCAn5LmdJywgJ+eCuSddLFxuICAgIHJhZGljZTogcm1iXG4gICAgICA/IFtcbiAgICAgICAgICAnJyxcbiAgICAgICAgICAn5ou+JyxcbiAgICAgICAgICAn5L2wJyxcbiAgICAgICAgICAn5LufJyxcbiAgICAgICAgICAn5LiHJyxcbiAgICAgICAgICAn5ou+JyxcbiAgICAgICAgICAn5L2wJyxcbiAgICAgICAgICAn5LufJyxcbiAgICAgICAgICAn5Lq/JyxcbiAgICAgICAgICAn5ou+JyxcbiAgICAgICAgICAn5L2wJyxcbiAgICAgICAgICAn5LufJyxcbiAgICAgICAgICAn5LiH5Lq/JyxcbiAgICAgICAgICAn5ou+JyxcbiAgICAgICAgICAn5L2wJyxcbiAgICAgICAgICAn5LufJyxcbiAgICAgICAgICAn5YWGJyxcbiAgICAgICAgICAn5ou+JyxcbiAgICAgICAgICAn5L2wJyxcbiAgICAgICAgICAn5LufJyxcbiAgICAgICAgXVxuICAgICAgOiBbXG4gICAgICAgICAgJycsXG4gICAgICAgICAgJ+WNgScsXG4gICAgICAgICAgJ+eZvicsXG4gICAgICAgICAgJ+WNgycsXG4gICAgICAgICAgJ+S4hycsXG4gICAgICAgICAgJ+WNgScsXG4gICAgICAgICAgJ+eZvicsXG4gICAgICAgICAgJ+WNgycsXG4gICAgICAgICAgJ+S6vycsXG4gICAgICAgICAgJ+WNgScsXG4gICAgICAgICAgJ+eZvicsXG4gICAgICAgICAgJ+WNgycsXG4gICAgICAgICAgJ+S4h+S6vycsXG4gICAgICAgICAgJ+WNgScsXG4gICAgICAgICAgJ+eZvicsXG4gICAgICAgICAgJ+WNgycsXG4gICAgICAgICAgJ+WFhicsXG4gICAgICAgICAgJ+WNgScsXG4gICAgICAgICAgJ+eZvicsXG4gICAgICAgICAgJ+WNgycsXG4gICAgICAgIF0sXG4gICAgZGVjOiBbJ+inkicsICfliIYnLCAn5Y6YJywgJ+avqyddLFxuICB9O1xuICBpZiAocm1iKSB2YWx1ZSA9ICgrdmFsdWUpLnRvRml4ZWQoNSkudG9TdHJpbmcoKTtcbiAgbGV0IGludGVnZXJSZXMgPSAnJztcbiAgY29uc3QgaW50ZWdlckNvdW50ID0gaW50ZWdlci5sZW5ndGg7XG4gIGlmIChpbnRlZ2VyID09PSAnMCcgfHwgaW50ZWdlckNvdW50ID09PSAwKSB7XG4gICAgaW50ZWdlclJlcyA9ICfpm7YnO1xuICB9IGVsc2Uge1xuICAgIGxldCBjbkRlc2MgPSAnJztcbiAgICBmb3IgKGxldCBpID0gMDsgaSA8IGludGVnZXJDb3VudDsgaSsrKSB7XG4gICAgICBjb25zdCBuID0gK2ludGVnZXJbaV07XG4gICAgICBjb25zdCBqID0gaW50ZWdlckNvdW50IC0gaSAtIDE7XG4gICAgICBjb25zdCBpc1plcm8gPSBpID4gMSAmJiBuICE9PSAwICYmIGludGVnZXJbaSAtIDFdID09PSAnMCc7XG4gICAgICBjb25zdCBjblplcm8gPSBpc1plcm8gPyAn6Zu2JyA6ICcnO1xuICAgICAgY29uc3QgaXNFbXBwdHlVbml0ID0gKG4gPT09IDAgJiYgaiAlIDQgIT09IDApIHx8IGludGVnZXIuc3Vic3RyKGkgLSAzLCA0KSA9PT0gJzAwMDAnO1xuICAgICAgY29uc3QgZGVzY01hcmsgPSBjbkRlc2M7XG4gICAgICBsZXQgY25OdW0gPSB1bml0Lm51bVtuXTtcblxuICAgICAgY25EZXNjID0gaXNFbXBwdHlVbml0ID8gJycgOiB1bml0LnJhZGljZVtqXTtcbiAgICAgIC8vIOesrOS4gOS9jeaYr+S4gOWNgVxuICAgICAgaWYgKGkgPT09IDAgJiYgY25OdW0gPT09ICfkuIAnICYmIGNuRGVzYyA9PT0gJ+WNgScpIGNuTnVtID0gJyc7XG4gICAgICBjb25zdCBpc0NoYW5nZUVyID1cbiAgICAgICAgbiA+IDEgJiZcbiAgICAgICAgY25OdW0gPT09ICfkuownICYmIC8vIOWOu+mZpOmmluS9jVxuICAgICAgICBbJycsICfljYEnLCAn55m+J10uaW5kZXhPZihjbkRlc2MpID09PSAtMSAmJiAvLyDkuI3or7vkuKRcXOS4pOWNgVxc5Lik55m+XG4gICAgICAgIGRlc2NNYXJrICE9PSAn5Y2BJzsgLy8g5LiN6K+75Y2B5LikXG4gICAgICBpZiAoaXNDaGFuZ2VFcikgY25OdW0gPSAn5LikJztcbiAgICAgIGludGVnZXJSZXMgKz0gY25aZXJvICsgY25OdW0gKyBjbkRlc2M7XG4gICAgfVxuICB9XG5cbiAgLy8g5bCP5pWw6YOo5YiG5ou85o6lXG4gIGxldCBkZWNpbWFsUmVzID0gJyc7XG4gIGNvbnN0IGRlY2ltYWxDb3VudCA9IGRlY2ltYWwgPyBkZWNpbWFsLnRvU3RyaW5nKCkubGVuZ3RoIDogMDtcbiAgaWYgKGRlY2ltYWwgPT09IG51bGwpIHtcbiAgICBkZWNpbWFsUmVzID0gcm1iID8gJ+aVtCcgOiAnJztcbiAgfSBlbHNlIGlmIChkZWNpbWFsID09PSAnMCcpIHtcbiAgICBkZWNpbWFsUmVzID0gJ+mbtic7XG4gIH0gZWxzZSB7XG4gICAgZm9yIChsZXQgaSA9IDA7IGkgPCBkZWNpbWFsQ291bnQ7IGkrKykge1xuICAgICAgaWYgKHJtYiAmJiBpID4gdW5pdC5kZWMubGVuZ3RoIC0gMSkgYnJlYWs7XG4gICAgICBjb25zdCBuID0gZGVjaW1hbFtpXTtcbiAgICAgIGNvbnN0IGNuWmVybyA9IG4gPT09ICcwJyA/ICfpm7YnIDogJyc7XG4gICAgICBjb25zdCBjbk51bSA9IHVuaXQubnVtW25dO1xuICAgICAgY29uc3QgY25EZXNjID0gcm1iID8gdW5pdC5kZWNbaV0gOiAnJztcbiAgICAgIGRlY2ltYWxSZXMgKz0gY25aZXJvICsgY25OdW0gKyBjbkRlc2M7XG4gICAgfVxuICB9XG4gIGNvbnN0IHJldCA9XG4gICAgc3ltYm9sICtcbiAgICAocm1iXG4gICAgICA/IGludGVnZXJSZXMgKyAoZGVjaW1hbFJlcyA9PT0gJ+mbticgPyAn5YWD5pW0JyA6IGDlhYMke2RlY2ltYWxSZXN9YClcbiAgICAgIDogaW50ZWdlclJlcyArIChkZWNpbWFsUmVzID09PSAnJyA/ICcnIDogYOeCuSR7ZGVjaW1hbFJlc31gKSk7XG4gIHJldHVybiByZXQ7XG59XG4iXX0=