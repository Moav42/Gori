import { Router } from '@angular/router';
import { DrinkCategoryModel } from './../../../Models/drink-category-model';
import { environment } from './../../../../environments/environment';
import { CategoriesService } from './../../../Services/categories.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {


  categoryCreateForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private categoriesService: CategoriesService,
    private router: Router,
    private location: Location){
      this.categoryCreateForm = fb.group({
      categoryName:['', Validators.required],
      description:['', Validators.required]
    });
  }

  ngOnInit() {

  }

  public createDrinkCategory(){
    const title = this.categoryCreateForm.get('categoryName').value;
    const description = this.categoryCreateForm.get('description').value;

    let model = new DrinkCategoryModel({id:1,title,description});
    console.log(model);
    this.categoriesService.addCategory(model).subscribe((Response)=>{
      console.log("Fine");
      this.router.navigateByUrl(environment.routes.categories);
    }, (error)=>{
      console.log("Error while adding new category: "+error);
    });
  }

  back(){
    this.location.back();
  }

}
