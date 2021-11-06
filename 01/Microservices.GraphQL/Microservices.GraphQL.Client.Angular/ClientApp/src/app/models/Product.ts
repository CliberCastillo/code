import { ProductReview } from "./ProductReview";

export class Product {

  public id: number;
  public name: string
  public type: string;
  public description: string;
  public price: number;
  public stock: number;
  public rating: number;
  public introducedAt: Date;
  public photoFileName: string;
  public reviews: ProductReview[];
}
