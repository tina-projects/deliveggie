import { Component, OnInit } from '@angular/core';
import { VeggieService } from '../../veggie.service';
import {IVeggie} from '../models/iveggie';
import {ActivatedRoute} from '@angular/router';
import {DatePipe} from '@angular/common';

@Component({
  selector: 'app-veggie-details',
  templateUrl: './veggie-details.component.html',
  styleUrls: ['./veggie-details.component.css'],
  providers:[DatePipe]
})
export class VeggieDetailsComponent implements OnInit {
  constructor(private _veggieService:VeggieService,private _activatedRoute:ActivatedRoute) { }
  veggie:any
    
  ngOnInit(): void {
    let veggieId:number=this._activatedRoute.snapshot.params['Id'];
    this.veggie=this._veggieService.getVeggieDetails(veggieId);
  }

}
