import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {

  public orders: Order[];
  //private salesUrl = "https://localhost:44323/api/sales";
  //private salesUrl = "https://localhost:44345/gateway/sales";
  //private salesUrl = "http://localhost:1042/gateway/sales";
  private salesUrl = "https://api-management-microservices-eac.azure-api.net/gateway/sales";

  constructor(http: HttpClient) {
    http.get<Order[]>(this.salesUrl
      /*, {
      headers: {
        'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcmljayIsInVuaXF1ZV9uYW1lIjoiRXJpY2siLCJyb2xlIjpbIlNBTEVTTUFOIiwiVVNFUiJdLCJ1c2VyVHlwZSI6IlNBTEVTTUFOIiwibmJmIjoxNjQyODc1MDEzLCJleHAiOjE2NDM0Nzk4MTMsImlhdCI6MTY0Mjg3NTAxM30.R3ua5fP6ogW5Ngh14IwjYt_zQzlHsSjxUnobFNPhLew'
      }
    }
    */
    )
    .subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}

interface Order {
  OrderId: number;
  Description: string;
  Items: OrderItem[];
  Created: Date;
  Updated: Date;
}

interface OrderItem {
  OrderId: number;
  ProductId: number;
  Created: Date;
  Updated: Date;
}
