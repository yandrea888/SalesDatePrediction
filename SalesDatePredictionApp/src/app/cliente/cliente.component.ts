import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { CommonModule } from '@angular/common';  
import { DatePipe } from '@angular/common';      


@Component({
  selector: 'app-cliente',
  standalone: true,
  templateUrl: './cliente.component.html',
  imports: [CommonModule, DatePipe],
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  clientes: any[] = [];

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  loadClientes(): void {
    this.clienteService.getClientes().subscribe(
      (data) => {
        this.clientes = data;
        console.log('Datos recibidos:', this.clientes);
      },
      (error) => {
        console.error('Error al cargar los clientes:', error);
      }
    );
  }
}

