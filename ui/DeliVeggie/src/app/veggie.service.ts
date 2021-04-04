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
      return this._httpClient.get<IVeggie[]>('https://localhost:5001/Veggie');  
  }
  getVeggieDetails(Id:number): Observable<IVeggie> {
      return this._httpClient.get<IVeggie>('https://localhost:5001/Veggie/' + Id);
 }
}
