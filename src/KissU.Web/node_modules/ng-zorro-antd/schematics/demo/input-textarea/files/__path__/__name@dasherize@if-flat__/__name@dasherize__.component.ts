import { Component } from '@angular/core';

@Component({
  selector: '<%= selector %>',
  <% if(inlineTemplate) { %>template: `
    <textarea rows="4" nz-input [(ngModel)]="inputValue"></textarea>
  `<% } else { %>templateUrl: './<%= dasherize(name) %>.component.html'<% } %>,

  styles: []
})
export class <%= classify(name) %>Component {
  inputValue: string;
}
