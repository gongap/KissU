import { Component } from '@angular/core';

@Component({
  selector: '<%= selector %>',
  <% if(inlineTemplate) { %>template: `
    <div style="height: 28px;">
      <nz-dropdown-button (nzClick)="log()">
        DropDown
        <ul nz-menu>
          <li nz-menu-item>1st menu item</li>
          <li nz-menu-item>2nd menu item</li>
          <li nz-submenu>
            <span title>sub menu</span>
            <ul>
              <li nz-menu-item>3rd menu item</li>
              <li nz-menu-item>4th menu item</li>
            </ul>
          </li>
        </ul>
      </nz-dropdown-button>
      <nz-dropdown-button nzDisabled>
        DropDown
        <ul nz-menu>
          <li nz-menu-item>
            <a>1st menu item</a>
          </li>
          <li nz-menu-item>
            <a>2nd menu item</a>
          </li>
          <li nz-menu-item>
            <a>3rd menu item</a>
          </li>
        </ul>
      </nz-dropdown-button>
      <nz-dropdown>
        <button nz-button nz-dropdown><span>Button</span> <i nz-icon type="down"></i></button>
        <ul nz-menu>
          <li nz-menu-item>
            <a>1st menu item</a>
          </li>
          <li nz-menu-item>
            <a>2nd menu item</a>
          </li>
          <li nz-menu-item>
            <a>3rd menu item</a>
          </li>
        </ul>
      </nz-dropdown>
    </div>
  `<% } else { %>templateUrl: './<%= dasherize(name) %>.component.html'<% } %>,
  <% if(inlineStyle) { %>styles: [`
      nz-dropdown-button {
        margin-right: 8px;
      }
    `]<% } else { %>styleUrls: ['./<%= dasherize(name) %>.component.<%= style %>']<% } %>
})
export class <%= classify(name) %>Component {
  log(): void {
    console.log('click dropdown button');
  }
}
