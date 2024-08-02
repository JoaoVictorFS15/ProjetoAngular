import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  url: string = 'https://localhost:44379/api/evento';
  constructor(private http: HttpClient) { }

  public getEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.url).pipe(take(1));
  }

  public getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.url}/${tema}/tema`).pipe(take(1));
  }

  public getEventoById(id:number): Observable<Evento> {
    return this.http.get<Evento>(`${this.url}/${id}`).pipe(take(1));
  }

  //criar evento
  public post(evento: Evento): Observable<Evento> {
    return this.http.post<Evento>(this.url, evento).pipe(take(1));
  }

  //atualizar evento
  public put(id: number, evento: Evento): Observable<Evento> {
    return this.http.put<Evento>(`${this.url}/${id}`, evento).pipe(take(1));
  }

  public delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`).pipe(take(1));
  }
}
