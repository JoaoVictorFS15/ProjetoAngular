import { Component } from '@angular/core';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrl: './evento-lista.component.css'
})
export class EventoListaComponent {

  public evento: Evento[] = [];

  public eventoFiltrados: Evento[] = [];
  public eventoId: number = 0;

  message?: string;

  public width: number = 50;
  public margin: number = 2;
  public mostrar: boolean = true;
  private _filtroLista: string = "";


  constructor(private eventoService: EventoService, private toastr: ToastrService, private spinner: NgxSpinnerService, private router: Router) {
  }


  public ngOnInit(): void {
    this.getEventos();
    this.spinner.show();
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


  showSuccess(event: any, eventoId: number) {
    event.stopPropagation();
    this.eventoId = eventoId;
    Swal.fire({
      title: 'Tem certeza?',
      text: `Você tem certeza que deseja excluir o evento de codigo ${this.eventoId}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.spinner.show();
        this.eventoService.delete(this.eventoId).subscribe({
          next: (resultado: any) => {
            if (resultado.mensagem == "Evento deletado") {
            this.spinner.hide();
            this.toastr.success('Evento deletado com sucesso.', 'Sucesso.');
              this.getEventos();
            }
          },
          error: (erro: any) => {
            this.spinner.hide();
            this.toastr.error(`Erro ao deletar evento ${this.eventoId}`, "Error");
          },
          complete: () => {
            this.spinner.hide();
          }
        });

        // Aqui você pode colocar a lógica para excluir o item
      }
    });
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

  detalheEvento(id: any) {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
