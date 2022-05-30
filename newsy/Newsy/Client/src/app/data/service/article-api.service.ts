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

  getArticleById(articleId: number) {
    return this.http.get<Article>(environment.baseUrl + '/Article/GetById/' + articleId);
  }

  getArticlesFromCurrentAuthor() {
    return this.http.get<Article[]>(environment.baseUrl + '/Article/GetArticleFromCurrentAuthor');
  }

  deleteArticle(articleId: number) {
    return this.http.delete(environment.baseUrl + '/Article/DeleteById/' + articleId);
  }

  createArticle() {

  }

  updateArticle() {
    
  }
}
