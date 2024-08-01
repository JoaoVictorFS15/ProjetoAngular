import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidarCampo } from '../../../helpers/ValidarCampo';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css'
})
export class PerfilComponent implements OnInit {
  form!: FormGroup;

  get f() {
    return this.form.controls;
  }
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validacao();
  }

  public validacao(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidarCampo.mustMatch('senha', 'confirmarSenha')
    };


    this.form = this.fb.group({

      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      confirmarSenha: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      email: ['', [Validators.required, Validators.email]],
      descricao: ['',  Validators.maxLength(200)],
      funcao: ['', Validators.required],
      titulo: ['', Validators.required],
      telefone: ['', Validators.required],
    }, formOptions);

  }

  public reset(): void {
    this.form.reset();
  }

  public validaCss(form: FormControl): any {

    return { 'is-invalid': form.errors && form.touched, 'is-valid': !form.errors && form.touched }
  };
}
