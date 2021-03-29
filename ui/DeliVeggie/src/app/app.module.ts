import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VeggieListComponent } from './veggie/veggie-list/veggie-list.component';
import { VeggieDetailsComponent } from './veggie/veggie-details/veggie-details.component';
import {  MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [
    AppComponent,
    VeggieListComponent,
    VeggieDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    HttpClientModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
