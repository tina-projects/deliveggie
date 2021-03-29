import { Component, OnInit } from '@angular/core';
import { VeggieService } from '../../veggie.service';
import {IVeggie} from '../models/iveggie';
import {DatePipe} from '@angular/common';
import {ActivatedRoute} from '@angular/router';


@Component({
  selector: 'app-veggie-list',
  templateUrl: './veggie-list.component.html',
  styleUrls: ['./veggie-list.component.css'],
  providers:[DatePipe]
})
export class VeggieListComponent implements OnInit {

  veggies:IVeggie[]=[];


  constructor(private _veggieService:VeggieService) { }
  
   ELEMENT_DATA: IVeggie[] = this._veggieService.getVeggieList();
  
  displayedColumns: string[] = ['Id', 'Name', 'EntryDate', 'Price'];
  dataSource = this.ELEMENT_DATA;
 
  ngOnInit(): void {
  }
  veggieDetailsByRow(row:any)
  {
console.log(row);
  }

}
