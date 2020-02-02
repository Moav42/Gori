import { MenuServiceService } from '../../Services/menu-service.service';
import { Component, OnInit } from '@angular/core';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-current-sum',
  templateUrl: './current-sum.component.html',
  styleUrls: ['./current-sum.component.css']
})
export class CurrentSumComponent implements OnInit {

  constructor(private menuService: MenuServiceService) { this.menuService.getApiRoute();}

  sum: number;

  ngOnInit() {
  }

}
