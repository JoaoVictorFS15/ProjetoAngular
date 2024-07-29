import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrl: './titulo.component.css'
})
export class TituloComponent implements OnInit {

  @Input() titulo: string = '';
  constructor() {}

  ngOnInit(): void {
      throw new Error('Method not implemented.');
  }

}
