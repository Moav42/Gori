import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { CategoriesService } from './../../../Services/categories.service';
import { DrinkCategoryModel } from './../../../Models/drink-category-model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Location } from '@angular/common';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {

  id: number;
  subscription: Subscription;
  model: DrinkCategoryModel;

  categoryUpdateForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private activeRoute: ActivatedRoute,
    private categoryService: CategoriesService,
    private location: Location ) {
      this.id = this.activeRoute.snapshot.params.id;
      this.subscription = this.activeRoute.params.subscribe(params => this.id = params.id);

      this.categoryUpdateForm = fb.group({
        categoryName: ['', Validators.required],
        description: ['', Validators.required]
      });



   }

  ngOnInit() {
      this.updateView();
  }

  updateView() {
    this.categoryService.getCategory(this.id).subscribe(data => {
      this.model = data;
      this.categoryUpdateForm.get('categoryName').setValue(this.model.title);
      this.categoryUpdateForm.get('description').setValue(this.model.description);
    });
  }
  deleteCategory(){
    this.categoryService.deleteCategory(this.id).subscribe(()=>{
      this.back();
    });
  }
  saveCategory(){
    this.model.description =  this.categoryUpdateForm.get('description').value;
    this.model.title = this.categoryUpdateForm.get('categoryName').value;
    this.categoryService.updateCategory(this.model).subscribe(()=>{
      this.back();
    },(error)=>{
      console.log("error: "+error);
      
    });
  }
  back(){
    this.location.back();
  }

}
