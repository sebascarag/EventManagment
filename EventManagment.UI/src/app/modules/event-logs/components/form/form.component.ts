import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AddEventLogs } from '../../interfaces/add-event-logs.interface';
import { ErrorForm } from '../../interfaces/error-form.interface';
import { SelectOptions } from 'src/app/shared/interfaces/select-options';
import { EType } from 'src/app/shared/enums/etype.enum';

@Component({
  selector: 'event-logs-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class EventLogsFormComponent implements OnInit {

  public eventLog: AddEventLogs = this.defaultEventLog();
  public errorForm: ErrorForm[] = this.defaultErrors();
  public optionsValues: SelectOptions[] = [{option: 'Api', value: '1'}, {option: 'Manual', value: '2'}];

  @Output()
  public onNewEventLog: EventEmitter<AddEventLogs> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  getError(key: string){
    return this.errorForm.find(x => x.key === key)?.status
  }

  setStatusError(key: string, newStatus: boolean): void{
    const objIndex = this.errorForm.findIndex((obj => obj.key === key));
    this.errorForm[objIndex].status = newStatus;
  }

  emitFormValues(): void{
    this.validationForm();
    this.onNewEventLog.emit(this.eventLog);
    this.eventLog = this.defaultEventLog(); // reset form
  }

  private validationForm(): boolean{
    // set default
    this.errorForm.forEach(x => x.status = false);

    if (this.eventLog.description.length === 0)
      this.setStatusError('errorDescriptionRequired', true);

    if (this.eventLog.description.length > 100)
      this.setStatusError('errorDescriptionLong', true);

    if (!this.eventLog.date)
      this.setStatusError('errorDate', true);

    if (!Object.values(EType).includes(this.eventLog.eType))
      this.setStatusError('errorEType', true);


    return true;
  }

  private defaultEventLog(): AddEventLogs{
    return {
      date: undefined,
      description: '',
      eType: 2
    };
  }

  private defaultErrors(): ErrorForm[]{

    return [
      {key: 'errorDate', status: false},
      {key: 'errorDescriptionRequired', status: false},
      {key: 'errorDescriptionLong', status: false},
      {key: 'errorEType', status: false}
    ];
  }
}
