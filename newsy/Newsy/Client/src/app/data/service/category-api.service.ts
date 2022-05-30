import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../schema/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryApiService {

  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<Category[]>(environment.baseUrl + '/Category/GetAll');
  }
}
