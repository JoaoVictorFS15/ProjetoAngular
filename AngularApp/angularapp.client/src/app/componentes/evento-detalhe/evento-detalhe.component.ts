import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Lote } from '../../models/Lote';
import { LoteService } from '../../services/lote.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrl: './evento-detalhe.component.css'
})
export class EventoDetalheComponent implements OnInit {

  eventoId!: number;
  form!: FormGroup;
  evento = {} as Evento;
  estadoSalvar = 'post';
  loteAtual = { id: 0, nome: '', indice: 0 }

  imagemURL = "/assets/upload.jpg";


  get editar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get lotes(): FormArray {
    return this.form.get('lotes') as FormArray;
  }
  get f() {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY  h:mm:ss a',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }

  get bsConfigLote(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private eventoService: EventoService,
    private loteService: LoteService,
    private spinner: NgxSpinnerService,
    private toast: ToastrService,
    private rota: Router) {

    this.localeService.use('pt-br');
  }

  ngOnInit(): void {
    this.carregarEvento();
    this.validacao();
  }

  public carregarEvento(): void {
    this.eventoId = +this.router.snapshot.paramMap.get('id')!;

    if (this.eventoId !== null && this.eventoId !== 0) {

      this.estadoSalvar = 'put';
      this.spinner.show();
      this.eventoService.getEventoById(this.eventoId).subscribe({
        next: (evento: Evento) => {
          this.evento = { ...evento };
          this.form.patchValue(this.evento);
          this.carregarLotes()

          //this.evento.lote.forEach(lote => {
          //  this.lotes.push(this.criarLotes(lote));
          //})
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toast.error('Erro ao carregar evento.');
          console.log(error);
        },
        complete: () => {
          this.spinner.hide();
        }
      });
    }

  }

  public carregarLotes(): void {
    this.loteService.GetlotesByEventoIdAsync(this.eventoId).subscribe(
      (lotesRetorno: Lote[]) => {
        lotesRetorno.forEach(lote => {
          this.lotes.push(this.criarLotes(lote));
        });
      },
      (error: any) => {
        this.toast.error('Erro ao tentar carregar lotes', 'erro');
      }
    ).add(() => this.spinner.hide())
  }
  
  public validacao(): void {
    this.form = this.fb.group({

      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      qtdPesssoas: ['', [Validators.required, Validators.max(100000)]],
      imagemURL: ['', Validators.required],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      lotes: this.fb.array([]),

    });
  }

  adicionarFormLote(): void {
    this.lotes.push(this.criarLotes({ id: 0 } as Lote));
  }

  criarLotes(lote: Lote): FormGroup {
   return this.fb.group({
      id: [lote.id],
      nome: [lote.nome, Validators.required],
      preco: [lote.preco, Validators.required],
     dataInicio: [lote.dataInicio, Validators.required],
     dataFim: [lote.dataFim, Validators.required],
      quantidade: [lote.quantidade, Validators.required]
    })
  }

  salvar(): any {
    this.spinner.show();

    if (this.form.valid) {
      
      if (this.estadoSalvar === 'post') {

        

        this.evento = { ... this.form.value };

        this.eventoService.post(this.evento).subscribe({
          next: (eventoCriado: Evento) => {
            setTimeout(() => {
              this.backHome(eventoCriado);
            }, 1000);
            this.toast.success('Evento criado com sucesso.', 'Sucesso');
          },
          error: (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toast.error('Erro ao criar evento.', 'Erro');
          },
          complete: () => {   
          }
        });
      }

      else {

        this.evento = { id: this.evento.id, ... this.form.value };

        this.eventoService.put(this.evento.id, this.evento).subscribe({
          next: (eventoCriado: Evento) => {
            setTimeout(() => {
              this.backHome(eventoCriado);
            }, 1000);
            this.toast.success('Evento atualizado com sucesso.', 'Sucesso');
          },
          error: (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toast.error('Erro ao atualizar evento.', 'Erro');

          },
          complete: () => {
           
          }
        });
      }
    }
  }

  salvarLotes(): void {
    if (this.form.controls['lotes'].valid) {
      this.spinner.show();
      this.loteService.SaveLotes(this.eventoId, this.form.value.lotes).subscribe({
        next: ()=>  {
        this.toast.success('Lote salvo com sucesso!', 'Sucesso!');
        setTimeout(() => {
        this.backLista();
      }, 1000);
      //this.lotes.reset();
        },
        error:(error: any) => {
      this.toast.error('erro ao tentar salvar lotes', 'Erro');
          console.error(error);
    },
      }).add(() => this.spinner.hide());
    }
  }

  public reset(): void {
    this.form.reset();
  }

  backHome(evento: Evento) {
    this.rota.navigate([`eventos/detalhe/${evento.id}`]);
    this.spinner.hide();
  }

  backLista() {
    this.rota.navigate([`eventos/lista`]);
    this.spinner.hide();
  }

  public DeleteLote(indice: number): void {

  
    this.loteAtual.id = this.lotes.get(indice + '.id')?.value;
    this.loteAtual.nome = this.lotes.get(indice + '.nome')?.value;
    this.loteAtual.indice = indice;


    //this.eventoId = eventoId;
    Swal.fire({
      title: 'Tem certeza?',
      text: `Você tem certeza que deseja excluir o ${this.loteAtual.nome}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.spinner.show();
        this.loteService.DeleteEvento(this.eventoId, this.loteAtual.id).subscribe({
          next: (resultado: any) => {
            if (resultado.mensagem == "Lote deletado") {
              this.spinner.hide();
              this.toast.success('Lote deletado com sucesso.', 'Sucesso.');
              this.lotes.removeAt(indice);
            } else if (resultado.mensagem == "lote null") this.lotes.removeAt(indice);
          },
          error: (erro: any) => {
            this.spinner.hide();
            this.toast.error(`Erro ao deletar evento ${this.loteAtual.id}`, "Error");
          },
          complete: () => {
            this.spinner.hide();
          }
        });
      }
    });
  }

  public retornaTituloLote(nome: string): string {
    return nome === null || nome === '' ? 'Nome do Lote' : nome;
  }

  public onFileChange(evento: any): void
  {
    const reader = new FileReader();

    reader.onload = (event: any) => this.imagemURL = event.target.result;

    const file = evento.target.files[0];
    reader.readAsDataURL(file);
  }
}
