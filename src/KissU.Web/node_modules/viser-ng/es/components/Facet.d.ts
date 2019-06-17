import { Chart } from '../Chart';
import * as IStyle from './Style';
interface IColTitleProps {
    offsetY?: number;
    style?: IStyle.ITextStyle;
}
interface IRowTitleProps {
    offsetX?: number;
    style?: IStyle.ITextStyle;
}
declare class Facet extends Chart {
    type?: string;
    fields?: string[];
    cols?: number;
    rows?: number;
    colField?: string | string[];
    rowField?: string | string[];
    colValue?: number;
    rowValue?: number;
    colIndex?: number;
    rowIndex?: number;
    showTitle?: boolean;
    colTitle?: IColTitleProps;
    rowTitle?: IRowTitleProps;
    autoSetAxis?: boolean;
    padding?: number | number[];
    transpose?: boolean;
    lineSmooth?: boolean;
    line?: IStyle.ILineStyle;
    views?: any;
    eachView?: (views: any, facet: any) => void;
}
export { Facet };
