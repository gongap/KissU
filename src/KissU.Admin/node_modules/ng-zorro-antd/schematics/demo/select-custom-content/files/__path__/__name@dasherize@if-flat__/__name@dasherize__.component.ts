import { Component } from '@angular/core';

@Component({
  selector: '<%= selector %>',
  <% if(inlineTemplate) { %>template: `
    <nz-select style="width: 200px;" nzShowSearch nzAllowClear nzPlaceHolder="Select OS" [(ngModel)]="selectedOS">
      <nz-option nzCustomContent nzLabel="Windows" nzValue="windows"><i nz-icon type="windows"></i> Windows</nz-option>
      <nz-option nzCustomContent nzLabel="Mac" nzValue="mac"><i nz-icon type="apple"></i> Mac</nz-option>
      <nz-option nzCustomContent nzLabel="Android" nzValue="android"><i nz-icon type="android"></i> Android</nz-option>
    </nz-select>
  `<% } else { %>templateUrl: './<%= dasherize(name) %>.component.html'<% } %>
})
export class <%= classify(name) %>Component {
  selectedOS = null;
}
