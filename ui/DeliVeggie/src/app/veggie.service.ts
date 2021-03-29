import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IVeggie} from './veggie/models/iveggie';
@Injectable({
  providedIn: 'root',
  
})
export class VeggieService{

  veggieList:IVeggie[]=[{
Id:1,
Name:'Potato',
EntryDate:new Date(),
Price:100
},
{
  Id:2,
  Name:'Cucumber',
  EntryDate:new Date(),
  Price:50
  },
  {
    Id:3,
    Name:'Tomato',
    EntryDate:new Date(),
    Price:60
    },
    {
      Id:4,
      Name:'Onion',
      EntryDate:new Date(),
      Price:70
      },
]

veggie:IVeggie={
  Id:1,
  Name:'Potato',
  EntryDate:new Date(),
  Price:100
  }
  constructor(private _httpClient:HttpClient) { }

  //getVeggieList(): Observable<IVeggie[]> {
           //return this._httpClient.get<IVeggie[]>('');
  //}
  //getVeggieDetails(Id:number): Observable<IVeggie> {
  //   return this._httpClient.get<IVeggie>('');
 //}
  getVeggieList(): IVeggie[] {
    return this.veggieList;
}

  getVeggieDetails(Id:number): IVeggie{

    this.veggie.Id=Id;
    return this.veggie  
}
}
