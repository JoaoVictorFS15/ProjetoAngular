import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  url: string = 'https://localhost:44379/api/evento';
  constructor(private http: HttpClient) { }

 public getEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.url);
  }

  public getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.url}/${tema}/tema`);
  }

  public getEventoById(id:number): Observable<Evento> {
    return this.http.get<Evento>(`${this.url}/${id}`);
  }
}
