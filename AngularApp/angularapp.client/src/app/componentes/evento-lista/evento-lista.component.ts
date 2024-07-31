import { Component } from '@angular/core';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrl: './evento-lista.component.css'
})
export class EventoListaComponent {

  public evento: Evento[] = [];
  public eventoFiltrados: Evento[] = [];

  message?: string;

  public width: number = 50;
  public margin: number = 2;
  public mostrar: boolean = true;
  private _filtroLista: string = "";
  dataEvento1: Date = new Date();
  event = { local: 'TesteNovo', dataEvento: this.dataEvento1, tema: 'testeNovo', qtdPesssoas: 5, imagemURL: 'nova.png', telefone: '(21)3021-2035', Email: 'novo@novo.com' };

  constructor(private eventoService: EventoService, private toastr: ToastrService, private spinner: NgxSpinnerService, private router: Router) {
  }


  public ngOnInit(): void {
    this.getEventos();
    this.spinner.show();
  }

  showSuccess() {
    this.toastr.success('Evento deletado com sucesso.', 'Sucesso.');
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




  public getEventos(): void {

    this.eventoService.getEvento().subscribe({
      next: (_evento: Evento[]) => {
        this.evento = _evento;
        this.eventoFiltrados = this.evento;
      },
      error: (erro: any) => { this.spinner.hide(); this.toastr.error("Erro ao carregar eventos", "Error"); },
      complete: () => this.spinner.hide()
    });
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

  public onSubmit() {
    this.eventoService.createEvent(this.event).subscribe(response => { console.log('sla'); });
  }

  detalheEvento(id: any) {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
