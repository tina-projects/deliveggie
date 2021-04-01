import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IVeggie} from './veggie/models/iveggie';

@Injectable({
  providedIn: 'root',
  
})
export class VeggieService{

  constructor(private _httpClient:HttpClient) { }

  getVeggieList(): Observable<IVeggie[]> {
      return this._httpClient.get<IVeggie[]>('http://localhost/Veggie');  
  }
  getVeggieDetails(Id:number): Observable<IVeggie> {
      return this._httpClient.get<IVeggie>('http://localhost/Veggie/' + Id);
 }
 // getVeggieList(): IVeggie[] {
 //   return this.veggieList;
//}

 // getVeggieDetails(Id:number): IVeggie{

 //   this.veggie.Id=Id;
 //   return this.veggie  
//}
}
