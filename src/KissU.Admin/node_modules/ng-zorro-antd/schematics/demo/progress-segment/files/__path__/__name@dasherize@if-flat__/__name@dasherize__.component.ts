import { Component } from '@angular/core';

@Component({
  selector: '<%= selector %>',
  <% if(inlineTemplate) { %>template: `
    <nz-tooltip nzTitle="3 done / 3 in progress / 4 to do">
      <nz-progress nz-tooltip [nzPercent]="60" [nzSuccessPercent]="30"></nz-progress>
    </nz-tooltip>
  `<% } else { %>templateUrl: './<%= dasherize(name) %>.component.html'<% } %>
})
export class <%= classify(name) %>Component {}
