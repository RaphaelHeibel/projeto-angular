import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { PalestrantesComponent } from "./palestrantes/palestrantes.component";
import { EventosComponent } from "./eventos/eventos.component";
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from "./nav/nav.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [CommonModule, RouterOutlet, PalestrantesComponent, EventosComponent, HttpClientModule, NavComponent]
})
export class AppComponent {
  title = 'ProEventos-APP';
}
