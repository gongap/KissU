import { Component } from '@angular/core';

@Component({
  selector: '<%= selector %>',
  <% if(inlineTemplate) { %>template: `
    <nz-dropdown>
      <a nz-dropdown> Hover me <i nz-icon type="down"></i> </a>
      <ul nz-menu>
        <li nz-menu-item>
          <a>1st menu item</a>
        </li>
        <li nz-menu-item>
          <a>2nd menu item</a>
        </li>
        <li nz-menu-divider></li>
        <li nz-menu-item nzDisabled>3rd menu item（disabled）</li>
      </ul>
    </nz-dropdown>
  `<% } else { %>templateUrl: './<%= dasherize(name) %>.component.html'<% } %>,
  styles: []
})
export class <%= classify(name) %>Component {}
