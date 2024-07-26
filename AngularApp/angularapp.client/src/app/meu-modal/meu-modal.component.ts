
import { Component, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'; // Certifique-se de importar o serviço NgbModal

@Component({
  selector: 'app-meu-modal',
  templateUrl: './meu-modal.component.html',
  styleUrl: './meu-modal.component.css'
})
export class MeuModalComponent {

  @ViewChild('meuModal') meuModal: any; // Referência ao modal no template

  constructor(private modalService: NgbModal) { } // Injete o serviço NgbModal

  abrirModal() {
    this.modalService.open(this.meuModal); // Abre o modal
  }

}
