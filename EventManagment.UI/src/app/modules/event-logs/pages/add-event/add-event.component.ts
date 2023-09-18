import { Component } from '@angular/core';
import { AddEventLogs } from '../../interfaces/add-event-logs.interface';
import { EventLogsService } from '../../services/event-logs.service';
import { Router } from '@angular/router';

@Component({
  selector: 'event-logs-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class EventLogsAddEventComponent {

  public error: string|null = '';
  constructor(
    private _eventLogsService: EventLogsService,
    private _router: Router) { }

  async saveEventLog(eventLog: AddEventLogs): Promise<void>{
    let resp = await this._eventLogsService.addEventLog(eventLog);
    if (resp.succeeded) {
      this._router.navigate(['event-logs/search']);
    }
    this.error = resp.message;
  }

}
