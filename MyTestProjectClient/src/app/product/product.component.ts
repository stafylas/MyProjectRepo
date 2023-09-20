import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { product } from '../models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit{
  private tokenKey = 'authToken';
  products: product[] = [];
  constructor(private productService: ProductService){
       
  }
  ngOnInit(): void {
    const token = localStorage.getItem(this.tokenKey);
    this.getProducts();
  }
  getProducts() {
    this.productService.getProducts().subscribe(
      (response: product[]) => {
        // Handle success response
        this.products = response; // Assign the response to the property
        console.log(this.products);
        // You can also store the token or do other actions here
      },
      (error) => {
        // Handle error response
        console.error('An error occurred:', error);
      }
    );
  }
}
