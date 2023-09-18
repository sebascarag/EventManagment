import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventLogsSearchEventComponent } from './pages/search-event/search-event.component';
import { EventLogsAddEventComponent } from './pages/add-event/add-event.component';

const routes: Routes = [
  {
    path: 'search',
    component: EventLogsSearchEventComponent,
  },
  {
    path: 'add',
    component: EventLogsAddEventComponent,
  },
  {
    path: '**',
    redirectTo: 'search'
  }

]

@NgModule({
  imports: [
    RouterModule.forChild( routes )
  ],
  exports: [
    RouterModule
  ],
})
export class EventLogsRoutingModule { }
