import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SelectOptions } from '../../interfaces/select-options';

@Component({
  selector: 'shared-search-box',
  templateUrl: './search-box.component.html',
  styles: [
  ]
})
export class SearchBoxComponent {

  @Input()
  public placeholder: string = '';

  @Input()
  public inputType: string = 'text'

  @Input()
  public optionsValues: SelectOptions[] = []

  @Output()
  public onValue = new EventEmitter<string>();

  emitValue( value: string ):void {
    this.onValue.emit( value );
  }

}
