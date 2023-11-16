import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { response } from 'express';
import { error, time } from 'console';
import { get } from 'https';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("http://localhost:5181/api/eventos").subscribe((data) => {
      this.eventos = data
      console.log(data);
    });
  }
}
