import { Component, OnInit, AfterViewInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { OrdenService } from '../services/orden.service';
import { ActivatedRoute } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-orden-list',
  standalone: true,
  templateUrl: './orden-list.component.html',
  styleUrls: ['./orden-list.component.css'],
  imports: [
    CommonModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,

  ],
})
export class OrdenListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['OrderId', 'RequiredDate', 'ShippedDate', 'ShipName', 'ShipAddress', 'ShipCity'];
  dataSource = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @Input() customerId: string = '';

  constructor(
    private ordenService: OrdenService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = +params['customerId'];
      this.cargarOrdenes(id);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  //cargarOrdenes(customerId: number): void {
  //  this.ordenService.getOrdenesPorCliente(customerId).subscribe({
  //    next: (ordenes) => {
  //      this.dataSource.data = ordenes;
  //    },
  //    error: (err) => {
  //      console.error('Error al cargar las órdenes:', err);
  //    }
  //  });
  //}

  cargarOrdenes(customerId: number): void {
    console.log('Cargando órdenes para el cliente:', customerId);
    this.ordenService.getOrdenesPorCliente(customerId).subscribe({
      next: (ordenes) => {
        console.log('Órdenes recibidas:', ordenes);
        this.dataSource.data = ordenes;
      },
      error: (err) => {
        console.error('Error al cargar las órdenes:', err);
      }
    });
  }

  aplicarFiltro(event: Event) {
    const filtro = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filtro.trim().toLowerCase();
  }
}
