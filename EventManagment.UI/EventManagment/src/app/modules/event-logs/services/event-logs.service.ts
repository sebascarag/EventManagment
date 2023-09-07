import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, catchError, lastValueFrom, map, of } from "rxjs";

import { SearchParams } from "../interfaces/search-params.interface";
import { EventLogDto } from "../interfaces/event-logs-dto.interface";
import { ApiResponse } from "src/app/shared/interfaces/api-response.interface";
import { AddEventLogs } from "../interfaces/add-event-logs.interface";
import { API_URL } from "src/app/shared/constants/api-url.constant";

@Injectable({providedIn: 'root'})
export class EventLogsService{

  constructor(private _http: HttpClient ) { }

  searchEventLogs(searchParams: SearchParams[]): Observable<EventLogDto[]> {
    const url = `${API_URL}/EventLogs`;
    let params = new HttpParams()
    searchParams.forEach(param => params = params.append(param.key, param.value));

    return this._http.get<ApiResponse<EventLogDto[]>>(url, { params })
            .pipe(
              map( resp => resp.data?.length > 0 ? resp.data : [] ),
              catchError( err => of([]))
            );
  }

  async addEventLog(eventLog: AddEventLogs): Promise<ApiResponse<boolean>>{
    const url = `${API_URL}/EventLogs`;
    return await lastValueFrom(this._http.post<ApiResponse<boolean>>(url, eventLog));
  }
}
