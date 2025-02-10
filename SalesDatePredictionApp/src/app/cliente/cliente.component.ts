import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { CommonModule } from '@angular/common';  
import { DatePipe } from '@angular/common';      
import { OrdenListComponent } from '../orden-list/orden-list.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cliente',
  standalone: true,
  templateUrl: './cliente.component.html',
  imports: [CommonModule, DatePipe, OrdenListComponent],
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  clientes: any[] = [];
  selectedCustomerId: string = '';

  constructor(private clienteService: ClienteService, private router: Router) { }

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

  openOrdersModal(cliente: any) {
    this.selectedCustomerId = cliente.CustomerId;
    this.router.navigate(['/ordenes/74']);
  }

  newOrderl() {
    this.router.navigate(['/nueva-orden'])
  }
}

