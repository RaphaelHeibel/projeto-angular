import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { response } from 'express';
import { error, time } from 'console';
import { get } from 'https';
import { trigger, state, style, animate, transition } from '@angular/animations';


@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [CommonModule, FormsModule, CommonModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
  animations: [
    trigger('fadeIn', [
      state('void', style({ opacity: 0 })),
      transition(':enter, :leave', [
        animate('500ms', style({ opacity: 1 }))
      ])
    ])
  ]
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImg: boolean = true;
  private _filterList: string = "";
  isAnimated: boolean = true;

  constructor(private http: HttpClient) { }

  toggleShowImg() {
    this.showImg = !this.showImg;
  }

  public get filterList() {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventosFiltrados = this.filterList ? this.filtrarEventos(this.filterList) : this.eventos;

  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; lote: string; dataEvento: string;}) =>
        evento.tema.toLowerCase().indexOf(filtrarPor) !== -1
        || evento.local.toLowerCase().indexOf(filtrarPor) !== -1
        || evento.lote.toLowerCase().indexOf(filtrarPor) !== -1
        || evento.dataEvento.toLowerCase().indexOf(filtrarPor) !== -1

    )
  }

  ngOnInit(): void {
    this.http.get("http://localhost:5181/api/eventos").subscribe((data) => {
      this.eventos = data;
      this.eventosFiltrados = data;
      console.log(data);
    });
  }
}
