import { Component, OnDestroy, OnInit } from '@angular/core';
import { SearchParams } from '../../interfaces/search-params.interface';
import { SelectOptions } from 'src/app/shared/interfaces/select-options';
import { EventLogsService } from '../../services/event-logs.service';
import { EventLogDto } from '../../interfaces/event-logs-dto.interface';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'event-logs-search-event',
  templateUrl: './search-event.component.html',
  styleUrls: ['./search-event.component.css']
})
export class EventLogsSearchEventComponent implements OnInit, OnDestroy {

  public searchParams: SearchParams[] = [];
  public eventLogs: EventLogDto[] = [];
  public options: SelectOptions[] = [{option: 'Api', value: '1'}, {option: 'Manual', value: '2'}];
  public errorDate: Boolean = false;

  private _searchSub!: Subscription;

  constructor(private _eventLogsService: EventLogsService ) { }

  ngOnInit(): void {
    this.search();
  }

  ngOnDestroy(): void {
    this._searchSub.unsubscribe();
  }

  addSearchParam(key: string, value: any){
    console.log(value);
    this.searchParams = this.searchParams.filter(x => x.key !== key && x.value);
    this.searchParams.push({key, value});
  }

  search(): void{
    if(this.checkDateRange()){
      this._searchSub = this._eventLogsService.searchEventLogs(this.searchParams)
        .subscribe( data => this.eventLogs = data);
    }
  }

  private checkDateRange(): boolean{
    if(this.searchParams.some(x => x.key === 'endDate')){
      if(!this.searchParams.find(x => x.key === 'startDate')?.value){
        console.error("no date");
        this.errorDate = true;
        return false;
      }
    }
    // console.log(this.searchParams);
    this.errorDate = false;
    return true;
  }
}
