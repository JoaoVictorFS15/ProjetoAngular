
import { Component, OnInit} from '@angular/core';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrl: './evento.component.css'
})

export class EventoComponent implements OnInit {

  public evento: Evento[] = [];
  public eventoFiltrados: Evento[] = [];

  message?: string;

  public width: number = 50;
  public margin: number = 2;
  public mostrar: boolean = true;
  private _filtroLista: string = "";

  constructor(private eventoService: EventoService) {
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;

    this.eventoFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.evento;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {

    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.evento.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }



  public ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {

    this.eventoService.getEvento().subscribe(
      (_evento: Evento[]) => {
        this.evento = _evento;
        this.eventoFiltrados = this.evento;
      },
      error => console.log(error)
    );
    //this.evento = [
    //  {
    //    Tema: 'Teste.',
    //    Local: 'Local De Teste.'
    //  },

    //  {
    //    Tema: 'Teste2.',
    //    Local: 'Local De Teste2.'
    //  },

    //  {
    //    Tema: 'Teste3.',
    //    Local: 'Local De Teste3.'
    //  }
    //]
  }

  public clicke(): string {
    return this.message = 'teste';
  }

  public mostrarImagem(): void {
    this.mostrar = !this.mostrar;
  }
}

