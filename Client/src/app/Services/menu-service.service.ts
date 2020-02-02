import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class MenuServiceService {

  apiRoute: string = environment.apiBaseUrl + "/PositionsController";

  constructor(private http: HttpClient) {  }

  public getApiRoute(){
    console.log(this.apiRoute);
    //console.log(environment.routes.categories);
  }
}
