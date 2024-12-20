import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  // providers: [EventoService]
})
export class EventosComponent implements OnInit {
  hideSpinner() {
    throw new Error('Method not implemented.');
  }
  showSpinner() {
    throw new Error('Method not implemented.');
  }
  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem: number = 90;
  public margemImagem: number = 1;
  public exibirImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    // Corrigido aqui
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { local: any; tema: string }) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },

      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro au carregar os Eventos.', 'Error!');
      },
      complete: () => this.spinner.hide(),
    });
    //   (_eventos: Evento[]) => {
    //     this.eventos = _eventos;
    //     this.eventosFiltrados = this.eventos;

    //   },

    //   (error) => console.log(error),
    //   complete: () => this.spinner.hide();

    // );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
function complete(): void {
  throw new Error('Function not implemented.');
}
