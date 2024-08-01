import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';


@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrl: './evento-detalhe.component.css'
})
export class EventoDetalheComponent implements OnInit {

  form!: FormGroup;

  get f() {
    return this.form.controls;
  }

  get bsConfig(): any {
    return { adaptivePosition: true, dateInputFormat: 'DD/MM/YYYY  h:mm:ss', containerClass: 'theme-default' }
  }
  constructor(private fb: FormBuilder, private localeService: BsLocaleService) {
    this.localeService.use('pt-br');
  }

  ngOnInit(): void {
    this.validacao();
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

  public reset(): void {
    this.form.reset();
  }

}
