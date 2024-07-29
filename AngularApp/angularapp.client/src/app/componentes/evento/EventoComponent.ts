import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";


@Component({
    selector: 'app-evento',
    templateUrl: './evento.component.html',
    styleUrl: './evento.component.css'
})

export class EventoComponent implements OnInit {

    public evento: any;

    constructor(private http: HttpClient) { }

    ngOnInit(): void {
        this.getEventos();
    }


    public getEventos(): void {

        this.http.get('https://localhost:4200/api/evento').subscribe(
            response => this.evento = response,
            error => console.log(error)
        );

        this.evento = [
            {
                Tema: 'Teste.',
                Local: 'Local De Teste.'
            },

            {
                Tema: 'Teste2.',
                Local: 'Local De Teste2.'
            },

            {
                Tema: 'Teste3.',
                Local: 'Local De Teste3.'
            }
        ];
    }

    mensagem: string = '';

    onclick() {
        this.mensagem = 'Click';
    }
}
