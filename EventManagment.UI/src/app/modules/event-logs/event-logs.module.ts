import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { EventLogsRoutingModule } from './event-logs.routing';
import { SharedModule } from 'src/app/shared/shared.module';
import { EventLogsTableComponent } from './components/table/table.component';
import { EventLogsFormComponent } from './components/form/form.component';
import { EventLogsSearchEventComponent } from './pages/search-event/search-event.component';
import { EventLogsAddEventComponent } from './pages/add-event/add-event.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    EventLogsRoutingModule,
    SharedModule,
  ],
  declarations: [
    EventLogsTableComponent,
    EventLogsFormComponent,
    EventLogsSearchEventComponent,
    EventLogsAddEventComponent
  ]
})
export class EventLogsModule { }
