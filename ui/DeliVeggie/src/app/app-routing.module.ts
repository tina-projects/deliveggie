import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { VeggieListComponent } from './veggie/veggie-list/veggie-list.component';
import { VeggieDetailsComponent } from './veggie/veggie-details/veggie-details.component'

const routes: Routes = [
  { path: 'list', component: VeggieListComponent },
  { path: 'details/:Id', component: VeggieDetailsComponent },
  { path: '', redirectTo: '/list', pathMatch: 'full' },
  { path: '**', redirectTo: 'list' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
