import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventosComponent } from './eventos/eventos.component';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    NoopAnimationsModule
  ]
})
export class AppModule { }
