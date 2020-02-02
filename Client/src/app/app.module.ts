import { CategoriesService } from './Services/categories.service';
import { MenuServiceService } from './Services/menu-service.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './AppRoutingModule/app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './Components/navigation-bar/navigation-bar.component';
import { CurrentSumComponent } from './Components/current-sum/current-sum.component';
import { MenuComponent } from './Components/MenuComponent/menu/menu.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductStorageComponent } from './Components/ProductStorageComponent/product-storage/product-storage.component';
import { CategoriesComponent } from './Components/CategoriesComponent/categories/categories.component';
import { CategoryCreateComponent } from './Components/CategoriesComponent/category-create/category-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoryEditComponent } from './Components/CategoriesComponent/category-edit/category-edit.component';




@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    CurrentSumComponent,
    MenuComponent,
    ProductStorageComponent,
    CategoriesComponent,
    CategoryCreateComponent,
    CategoryEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [MenuServiceService, CategoriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
