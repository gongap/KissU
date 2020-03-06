import {
  Component,
  ChangeDetectionStrategy,
  OnInit,
  ChangeDetectorRef,
  ViewChild,
  ElementRef,
  NgZone,
} from '@angular/core';
import { LazyService } from '@delon/util';
import { format } from 'date-fns';
import { Base64 } from 'js-base64';

declare var mermaid: any;

@Component({
  selector: 'app-data-mermaid',
  templateUrl: './mermaid.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataMermaidComponent implements OnInit {
  inited = false;
  code = `graph TD
A[Christmas] -->|Get money| B(Go shopping)
B --> C{Let me think}
C -->|One| D[Laptop]
C -->|Two| E[iPhone]
C -->|Three| F[fa:fa-car Car]`;
  quickCodes = [
    {
      label: 'Flowchart',
      value: `graph TD;
A-->B;
A-->C;
B-->D;
C-->D;`,
    },
    {
      label: 'Sequence diagram',
      value: `sequenceDiagram
participant Alice
participant Bob
Alice->>John: Hello John, how are you?
loop Healthcheck
    John->>John: Fight against hypochondria
end
Note right of John: Rational thoughts <br/>prevail...
John-->>Alice: Great!
John->>Bob: How about you?
Bob-->>John: Jolly good!`,
    },
    {
      label: 'Gantt diagram',
      value: `gantt
dateFormat  YYYY-MM-DD
title Adding GANTT diagram to mermaid

section A section
Completed task            :done,    des1, 2014-01-06,2014-01-08
Active task               :active,  des2, 2014-01-09, 3d
Future task               :         des3, after des2, 5d
Future task2               :         des4, after des3, 5d`,
    },
    {
      label: 'Class diagram',
      value: `classDiagram
Class01 <|-- AveryLongClass : Cool
Class03 *-- Class04
Class05 o-- Class06
Class07 .. Class08
Class09 --> C2 : Where am i?
Class09 --* C3
Class09 --|> Class07
Class07 : equals()
Class07 : Object[] elementData
Class01 : size()
Class01 : int chimp
Class01 : int gorilla
Class08 <--> C2: Cool label`,
    },
  ];

  quickCode = this.quickCodes[0].value;

  @ViewChild('container', { static: true }) containerEl: ElementRef;

  constructor(private lazy: LazyService, private ngZone: NgZone, private cdr: ChangeDetectorRef) {}

  private init() {
    this.ngZone.runOutsideAngular(() => mermaid.initialize({ theme: 'default' }));
    this.inited = true;
    this.cdr.detectChanges();
    this.codeChang();
  }

  quickCodeChange() {
    this.code = this.quickCode;
    this.codeChang();
  }

  codeChang() {
    const { code, containerEl } = this;
    const el = containerEl.nativeElement as HTMLElement;
    el.removeAttribute('data-processed');
    el.innerHTML = code;
    try {
      this.ngZone.runOutsideAngular(() => {
        mermaid.parse(code);
        mermaid.init(undefined, el);
      });
    } catch (e) {
      el.innerHTML = e.str;
      console.log('Parse Error', e);
    }
  }

  download(event: MouseEvent) {
    const { containerEl } = this;
    const container = containerEl.nativeElement as HTMLElement;
    const el = event.target as HTMLAnchorElement;
    el.href = `data:image/svg+xml;base64,${Base64.encode(container.innerHTML)}`;
    el.download = `mermaid-diagram-${format(new Date(), 'YYYYMMDDHHmmss')}.svg`;
  }

  ngOnInit(): void {
    this.lazy.loadScript('https://unpkg.com/mermaid@8.0.0/dist/mermaid.min.js').then(() => this.init());
  }
}
