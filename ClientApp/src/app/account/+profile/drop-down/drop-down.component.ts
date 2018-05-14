import { Component, Input, Output, EventEmitter } from '@angular/core';

export class DropdownValue {
    value: string;
    label: string;

    constructor(value: string, label: string) {
        this.value = value;
        this.label = label;
    }
}

@Component({
  selector: 'appc-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.scss']
})
export class DropDownComponent{

    @Input()
    values: DropdownValue[];

    @Output()
    select: EventEmitter<string>;

    constructor() {
        this.select = new EventEmitter();
    }

    selectItem(value) {
        this.select.emit(value);
    }

}
