import { Component, OnInit } from '@angular/core';
import { VeggieService } from '../../veggie.service';
import {IVeggie} from '../models/iveggie';
import {DatePipe} from '@angular/common';
import {ActivatedRoute} from '@angular/router';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-veggie-list',
  templateUrl: './veggie-list.component.html',
  styleUrls: ['./veggie-list.component.css'],
  providers:[DatePipe]
})
export class VeggieListComponent implements OnInit {

  veggies:IVeggie[]=[];


  constructor(private _veggieService:VeggieService) { }
  
//  ELEMENT_DATA: any = this._veggieService.getVeggieList();
  
  displayedColumns: string[] = ['name', 'entryDate', 'price'];
  dataSource = new MatTableDataSource<IVeggie>();
 
  ngOnInit(): void {
    this._veggieService.getVeggieList().subscribe((veggieData: IVeggie[]) =>
      {
        this.veggies = veggieData;
        console.log(this.veggies);
        this.dataSource =  new MatTableDataSource(this.veggies);
      });
  }

  veggieDetailsByRow(row:any)
  {
    console.log(row["id"]);
  }

}
