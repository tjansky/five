import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Article } from '../schema/Article';

@Injectable({
  providedIn: 'root'
})
export class ArticleApiService {

  constructor(private http: HttpClient) { }

  getArticles(categoryId = 0) {
    return this.http.get<Article[]>(environment.baseUrl + '/Article/GetAll/' + categoryId);
  }
}
