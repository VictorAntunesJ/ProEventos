import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  larguraImagem: number = 150;
  margemImagem: number = 2;
  exibirImagem: boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImagem()
  {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      (response) => (this.eventos = response),
      (error) => console.log(error)
    );
  }
}

// = [
// {
//   Tema:'Angular 11',
//   Local: 'Belo Horizonte'
// },
// {
//   Tema:'.Net 5',
//   Local: 'São Paulo'
// },
// {
//   Tema:'Angular e suas novidades',
//   Local: 'Rio de Janeiro'
// }
// ]
