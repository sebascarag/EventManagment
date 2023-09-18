import { Component, Input } from '@angular/core';
import { EventLogDto } from '../../interfaces/event-logs-dto.interface';

@Component({
  selector: 'event-logs-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class EventLogsTableComponent {

  @Input()
  public eventLogs: EventLogDto[] = [];

}
