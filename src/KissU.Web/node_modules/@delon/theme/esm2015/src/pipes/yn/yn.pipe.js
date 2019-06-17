/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Pipe } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
export class YNPipe {
    /**
     * @param {?} dom
     */
    constructor(dom) {
        this.dom = dom;
    }
    /**
     * @param {?} value
     * @param {?} yes
     * @param {?} no
     * @return {?}
     */
    transform(value, yes, no) {
        return this.dom.bypassSecurityTrustHtml(value ?
            `<i class="text-blue" title="${yes || '是'}"><svg viewBox="64 64 896 896" fill="currentColor" width="1em" height="1em" aria-hidden="true"><path d="M912 190h-69.9c-9.8 0-19.1 4.5-25.1 12.2L404.7 724.5 207 474a32 32 0 0 0-25.1-12.2H112c-6.7 0-10.4 7.7-6.3 12.9l273.9 347c12.8 16.2 37.4 16.2 50.3 0l488.4-618.9c4.1-5.1.4-12.8-6.3-12.8z"></path></svg></i>` :
            `<i class="text-grey" title="${no || '否'}"><svg viewBox="64 64 896 896" fill="currentColor" width="1em" height="1em" aria-hidden="true"><path d="M563.8 512l262.5-312.9c4.4-5.2.7-13.1-6.1-13.1h-79.8c-4.7 0-9.2 2.1-12.3 5.7L511.6 449.8 295.1 191.7c-3-3.6-7.5-5.7-12.3-5.7H203c-6.8 0-10.5 7.9-6.1 13.1L459.4 512 196.9 824.9A7.95 7.95 0 0 0 203 838h79.8c4.7 0 9.2-2.1 12.3-5.7l216.5-258.1 216.5 258.1c3 3.6 7.5 5.7 12.3 5.7h79.8c6.8 0 10.5-7.9 6.1-13.1L563.8 512z"></path></svg></i>`);
    }
}
YNPipe.decorators = [
    { type: Pipe, args: [{ name: 'yn' },] }
];
/** @nocollapse */
YNPipe.ctorParameters = () => [
    { type: DomSanitizer }
];
if (false) {
    /**
     * @type {?}
     * @private
     */
    YNPipe.prototype.dom;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoieW4ucGlwZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9waXBlcy95bi95bi5waXBlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsSUFBSSxFQUFpQixNQUFNLGVBQWUsQ0FBQztBQUNwRCxPQUFPLEVBQUUsWUFBWSxFQUFZLE1BQU0sMkJBQTJCLENBQUM7QUFHbkUsTUFBTSxPQUFPLE1BQU07Ozs7SUFDakIsWUFBb0IsR0FBaUI7UUFBakIsUUFBRyxHQUFILEdBQUcsQ0FBYztJQUFJLENBQUM7Ozs7Ozs7SUFFMUMsU0FBUyxDQUFDLEtBQWMsRUFBRSxHQUFXLEVBQUUsRUFBVTtRQUMvQyxPQUFPLElBQUksQ0FBQyxHQUFHLENBQUMsdUJBQXVCLENBQ3JDLEtBQUssQ0FBQyxDQUFDO1lBQ0wsK0JBQStCLEdBQUcsSUFBSSxHQUFHLHNUQUFzVCxDQUFDLENBQUM7WUFDalcsK0JBQStCLEVBQUUsSUFBSSxHQUFHLHViQUF1YixDQUNsZSxDQUFDO0lBQ0osQ0FBQzs7O1lBVkYsSUFBSSxTQUFDLEVBQUUsSUFBSSxFQUFFLElBQUksRUFBRTs7OztZQUZYLFlBQVk7Ozs7Ozs7SUFJUCxxQkFBeUIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBQaXBlLCBQaXBlVHJhbnNmb3JtIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBEb21TYW5pdGl6ZXIsIFNhZmVIdG1sIH0gZnJvbSAnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3Nlcic7XG5cbkBQaXBlKHsgbmFtZTogJ3luJyB9KVxuZXhwb3J0IGNsYXNzIFlOUGlwZSBpbXBsZW1lbnRzIFBpcGVUcmFuc2Zvcm0ge1xuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGRvbTogRG9tU2FuaXRpemVyKSB7IH1cblxuICB0cmFuc2Zvcm0odmFsdWU6IGJvb2xlYW4sIHllczogc3RyaW5nLCBubzogc3RyaW5nKTogU2FmZUh0bWwge1xuICAgIHJldHVybiB0aGlzLmRvbS5ieXBhc3NTZWN1cml0eVRydXN0SHRtbChcbiAgICAgIHZhbHVlID9cbiAgICAgICAgYDxpIGNsYXNzPVwidGV4dC1ibHVlXCIgdGl0bGU9XCIke3llcyB8fCAn5pivJ31cIj48c3ZnIHZpZXdCb3g9XCI2NCA2NCA4OTYgODk2XCIgZmlsbD1cImN1cnJlbnRDb2xvclwiIHdpZHRoPVwiMWVtXCIgaGVpZ2h0PVwiMWVtXCIgYXJpYS1oaWRkZW49XCJ0cnVlXCI+PHBhdGggZD1cIk05MTIgMTkwaC02OS45Yy05LjggMC0xOS4xIDQuNS0yNS4xIDEyLjJMNDA0LjcgNzI0LjUgMjA3IDQ3NGEzMiAzMiAwIDAgMC0yNS4xLTEyLjJIMTEyYy02LjcgMC0xMC40IDcuNy02LjMgMTIuOWwyNzMuOSAzNDdjMTIuOCAxNi4yIDM3LjQgMTYuMiA1MC4zIDBsNDg4LjQtNjE4LjljNC4xLTUuMS40LTEyLjgtNi4zLTEyLjh6XCI+PC9wYXRoPjwvc3ZnPjwvaT5gIDpcbiAgICAgICAgYDxpIGNsYXNzPVwidGV4dC1ncmV5XCIgdGl0bGU9XCIke25vIHx8ICflkKYnfVwiPjxzdmcgdmlld0JveD1cIjY0IDY0IDg5NiA4OTZcIiBmaWxsPVwiY3VycmVudENvbG9yXCIgd2lkdGg9XCIxZW1cIiBoZWlnaHQ9XCIxZW1cIiBhcmlhLWhpZGRlbj1cInRydWVcIj48cGF0aCBkPVwiTTU2My44IDUxMmwyNjIuNS0zMTIuOWM0LjQtNS4yLjctMTMuMS02LjEtMTMuMWgtNzkuOGMtNC43IDAtOS4yIDIuMS0xMi4zIDUuN0w1MTEuNiA0NDkuOCAyOTUuMSAxOTEuN2MtMy0zLjYtNy41LTUuNy0xMi4zLTUuN0gyMDNjLTYuOCAwLTEwLjUgNy45LTYuMSAxMy4xTDQ1OS40IDUxMiAxOTYuOSA4MjQuOUE3Ljk1IDcuOTUgMCAwIDAgMjAzIDgzOGg3OS44YzQuNyAwIDkuMi0yLjEgMTIuMy01LjdsMjE2LjUtMjU4LjEgMjE2LjUgMjU4LjFjMyAzLjYgNy41IDUuNyAxMi4zIDUuN2g3OS44YzYuOCAwIDEwLjUtNy45IDYuMS0xMy4xTDU2My44IDUxMnpcIj48L3BhdGg+PC9zdmc+PC9pPmAsXG4gICAgKTtcbiAgfVxufVxuIl19