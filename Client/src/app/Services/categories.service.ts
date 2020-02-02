import { DrinkCategoryModel } from './../Models/drink-category-model';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment.prod';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable()
export class CategoriesService {

  apiRoute:string = environment.apiBaseUrl+"/DrinkCategories";

  constructor(private http: HttpClient) { }

  public getAllCategories(): Observable<DrinkCategoryModel[]>{
    return this.http.get<DrinkCategoryModel[]>(this.apiRoute);
  }
  public getCategory(id: number): Observable<DrinkCategoryModel>{
    return this.http.get<DrinkCategoryModel>(this.apiRoute+"/"+id);
  }
  public addCategory(categoryModel: DrinkCategoryModel): Observable<DrinkCategoryModel>{
    return this.http.post<DrinkCategoryModel>(this.apiRoute,categoryModel);
  }
  public updateCategory(categoryModel:DrinkCategoryModel):Observable<DrinkCategoryModel>{
    return this.http.put<DrinkCategoryModel>(this.apiRoute+'/'+categoryModel.id,categoryModel);
  }
  public deleteCategory(categoryId:number):Observable<null>{
    return this.http.delete<null>(this.apiRoute+'/'+categoryId);
  }
}
