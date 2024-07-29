import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrl: './titulo.component.css'
})
export class TituloComponent implements OnInit {

  @Input() titulo: string = '';
  @Input() subtitulo: string = 'Desde ontem';
  @Input() iconeClass: string = 'fa fa-user';
  @Input() botaoListar: boolean = false;
  constructor() {}

  ngOnInit(): void {
      throw new Error('Method not implemented.');
  }

}
