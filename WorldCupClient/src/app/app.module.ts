import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CoachDetailComponent } from './coach-detail/coach-detail.component';
import { CoachesComponent } from './coaches/coaches.component';
import { CoachSearchComponent } from './hero-search/coach-search.component';
import { MessagesComponent } from './messages/messages.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    CoachesComponent,
    CoachDetailComponent,
    MessagesComponent,
    CoachSearchComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
