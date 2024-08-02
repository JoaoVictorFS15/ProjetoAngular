import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrl: './evento-detalhe.component.css'
})
export class EventoDetalheComponent implements OnInit {

  form!: FormGroup;
  evento = {} as Evento;
  estadoSalvar = 'post';

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

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private eventoService: EventoService,
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
    const eventoIdParams = this.router.snapshot.paramMap.get('id');

    if (eventoIdParams !== null) {

      this.estadoSalvar = 'put';
      this.spinner.show();
      this.eventoService.getEventoById(+eventoIdParams).subscribe({
        next: (evento: Evento) => {
          this.evento = { ...evento };
          this.form.patchValue(this.evento);
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

  public validacao(): void {
    this.form = this.fb.group({

      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      qtdPesssoas: ['', [Validators.required, Validators.max(100000)]],
      imagemURL: ['', Validators.required],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],

    });
  }

  salvar(): any {
    this.spinner.show();

    if (this.form.valid) {
      
      if (this.estadoSalvar === 'post') {

        this.evento = { ... this.form.value };

        this.eventoService.post(this.evento).subscribe({
          next: () => {
            this.toast.success('Evento criado com sucesso.', 'Sucesso');
          },
          error: (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toast.error('Erro ao criar evento.', 'Erro');
          },
          complete: () => {
            setTimeout(() => {
              this.backHome();
            }, 1000);
          }
        });
      }

      else {

        this.evento = { id: this.evento.id, ... this.form.value };

        this.eventoService.put(this.evento.id, this.evento).subscribe({
          next: () => {
            this.toast.success('Evento atualizado com sucesso.', 'Sucesso');
          },
          error: (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toast.error('Erro ao atualizar evento.', 'Erro');

          },
          complete: () => {
            setTimeout(() => {
              this.backHome();
            }, 1000);
          }
        });
      }
    }
  }

  public reset(): void {
    this.form.reset();
  }

  backHome() {
    this.rota.navigate([`eventos/lista`]);
    this.spinner.hide();
  }


}
