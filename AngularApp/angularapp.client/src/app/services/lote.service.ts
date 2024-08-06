import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Lote } from '../models/Lote';

@Injectable({
  providedIn: 'root'
})
export class LoteService {

  url: string = 'https://localhost:44379/api/lote';
  constructor(private http: HttpClient) { }

  public GetlotesByEventoIdAsync(eventoId: number): Observable<Lote[]> {
    return this.http.get<Lote[]>(`${this.url}/${eventoId}`).pipe(take(1));
  }

  //atualizar evento
  public SaveLotes(eventoId: number, lote: Lote[]): Observable<Lote[]> {
    return this.http.put<Lote[]>(`${this.url}/${eventoId}`, lote).pipe(take(1));
  }

  public DeleteEvento(eventoId: number,loteId: number): Observable<any> {
    return this.http.delete(`${this.url}/${eventoId}/${loteId}`).pipe(take(1));
  }
}
