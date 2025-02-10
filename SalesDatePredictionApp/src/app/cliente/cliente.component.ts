import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { CommonModule } from '@angular/common';  
import { DatePipe } from '@angular/common';      
import { OrdenListComponent } from '../orden-list/orden-list.component';
import { Router } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cliente',
  standalone: true,
  templateUrl: './cliente.component.html',
  imports: [CommonModule, DatePipe, OrdenListComponent, NgxPaginationModule, FormsModule],
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  clientes: any[] = [];
  selectedCustomerId: string = '';
  sortColumn: string = '';
  sortDirection: boolean = true;
  page: number = 1;
  searchTerm: string = '';

  constructor(private clienteService: ClienteService, private router: Router) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  loadClientes(searchTerm: string = ''): void {  // Acepta searchTerm
    this.clienteService.getClientes(searchTerm).subscribe(
      (data) => {
        this.clientes = data;
        console.log('Datos recibidos:', this.clientes);
      },
      (error) => {
        console.error('Error al cargar los clientes:', error);
      }
    );
  }


  sortData(column: string): void {
    this.sortColumn = column;
    this.sortDirection = !this.sortDirection;  
    this.clientes = [...this.clientes].sort((a, b) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection ? -1 : 1;
      if (valueA > valueB) return this.sortDirection ? 1 : -1;
      return 0;
    });
  }

  searchClientes(): void {
    this.loadClientes(this.searchTerm); // Llama al servidor con el término de búsqueda
  }

  onSearchChange(): void {
    this.loadClientes(this.searchTerm);  // Llama al servidor con el término de búsqueda
  }

  openOrdersModal(cliente: any) {
    this.selectedCustomerId = cliente.CustomerId;
    this.router.navigate(['/ordenes/74']);
  }

  newOrderl() {
    this.router.navigate(['/nueva-orden'])
  }
}

