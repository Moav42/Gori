import { CategoriesService } from './../../../Services/categories.service';
import { DrinkCategoryModel } from './../../../Models/drink-category-model';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  createRoute = environment.routes.categoriesCreate;
  editRoute = environment.routes.categoriesEdit;

  categories: DrinkCategoryModel[] = [];

  constructor(
    private router: Router,
    private categoryService: CategoriesService) { }

  ngOnInit() {
    this.categoryService.getAllCategories().subscribe(data => {
      this.categories = data;
    })
  }  

  navigateToCreate(){
    this.router.navigateByUrl(this.createRoute);
  }
  
  navigateToEdit(id: number){

    this.router.navigate([this.editRoute+"/"+id]);
  }

}
