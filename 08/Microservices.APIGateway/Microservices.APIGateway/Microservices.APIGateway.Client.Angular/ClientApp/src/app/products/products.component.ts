import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public products: Product[];
  //private productUrl = "https://localhost:44376/api/products";
  //private productUrl = "https://localhost:44345/gateway/products";
  //private productUrl = "http://localhost:1042/gateway/products";
  private productUrl = "https://api-management-microservices-eac.azure-api.net/gateway/products";

  constructor(http: HttpClient) {
    http.get<Product[]>(this.productUrl
    /*,{
      headers: {
        'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcmljayIsInVuaXF1ZV9uYW1lIjoiRXJpY2siLCJyb2xlIjpbIlNBTEVTTUFOIiwiVVNFUiJdLCJ1c2VyVHlwZSI6IlNBTEVTTUFOIiwibmJmIjoxNjQyODc1MDEzLCJleHAiOjE2NDM0Nzk4MTMsImlhdCI6MTY0Mjg3NTAxM30.R3ua5fP6ogW5Ngh14IwjYt_zQzlHsSjxUnobFNPhLew'
      }
    }*/
    )    
    .subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}


interface Product {
  ProductId: number;
  Description: string;
  Price: number;
  Created: Date;
  Updated: Date;
}
