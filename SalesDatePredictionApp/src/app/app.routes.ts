import { Routes } from '@angular/router';
//import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdenListComponent } from './orden-list/orden-list.component';
import { NuevaOrdenComponent } from './nueva-orden/nueva-orden.component';


//export const routes: Routes = [
//  { path: '', component: ClienteComponent },
//  { path: '', redirectTo: '/ordenes/1', pathMatch: 'full' },
//  { path: 'ordenes/:customerId', component: OrdenListComponent },
//  { path: '**', redirectTo: '/ordenes/1' },
//  { path: 'nueva-orden', component: NuevaOrdenComponent },
//];

export const routes: Routes = [
  { path: '', component: ClienteComponent },
  { path: 'ordenes/:customerId', component: OrdenListComponent },
  { path: 'nueva-orden', component: NuevaOrdenComponent },  // Mueve esto antes del comodín
  { path: '**', redirectTo: '/ordenes/1' },
];

imports: [
  MatTableModule,
  MatPaginatorModule,
  MatSortModule,
  BrowserAnimationsModule,
]
