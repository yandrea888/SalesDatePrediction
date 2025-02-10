import { Component, OnInit } from '@angular/core';
import { NuevaOrdenService } from '../services/nuevaorden.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-nueva-orden',
  templateUrl: './nueva-orden.component.html',
  styleUrls: ['./nueva-orden.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule]
})
export class NuevaOrdenComponent {
  nuevaOrdenForm: FormGroup;
  //mensaje: string = '';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) {
    this.nuevaOrdenForm = this.fb.group({
      customerId: ['', Validators.required],
      employeeId: ['', Validators.required],
      shipperId: ['', Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      freight: ['', [Validators.required, Validators.min(0)]],
      shipCountry: ['', Validators.required],
      orderDetails: this.fb.array([]),  
    });
  }

  ngOnInit(): void {
    this.agregarProducto();  
  }

  get productos(): FormArray {
    return this.nuevaOrdenForm.get('orderDetails') as FormArray;
  }

  agregarProducto() {
    this.productos.push(
      this.fb.group({
        productId: ['', Validators.required],
        unitPrice: ['', [Validators.required, Validators.min(0)]],
        qty: ['', [Validators.required, Validators.min(1)]],
        discount: ['', [Validators.min(0), Validators.max(1)]],
      })
    );
  }

  eliminarProducto(indice: number) {
    this.productos.removeAt(indice);
  }

  crearOrden() {
    if (this.nuevaOrdenForm.invalid) {
      console.log('Formulario inválido');
      return;
    }

    const ordenData = this.nuevaOrdenForm.value;
    console.log('Datos para enviar:', ordenData);

    this.http.post('http://localhost:5189/api/OrdenNueva', ordenData).subscribe(
      (response) => {
        console.log('Orden creada:', response);
      },
      (error) => {
        console.error('Error al crear la orden:', error);
      }
    );
  }
}
