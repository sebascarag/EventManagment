import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'event-logs',
    loadChildren: () => import('./modules/event-logs/event-logs.module').then( m => m.EventLogsModule )
  },
  {
    path: '**',
    redirectTo: 'properties'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
