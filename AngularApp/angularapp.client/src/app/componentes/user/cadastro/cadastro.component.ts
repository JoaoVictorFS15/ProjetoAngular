import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent implements OnInit {


  form!: FormGroup;

  get f() {
    return this.form.controls;
  }
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validacao();
  }

  public validacao(): void {
    this.form = this.fb.group({

      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      usuario: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      senha: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      confirmarSenha: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      email: ['', [Validators.required, Validators.email]],

    });

  }

  public reset(): void {
    this.form.reset();
  }

}
