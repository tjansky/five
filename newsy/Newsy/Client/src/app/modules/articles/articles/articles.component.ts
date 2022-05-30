import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from 'src/app/data/schema/Article';
import { Category } from 'src/app/data/schema/Category';
import { ArticleApiService } from 'src/app/data/service/article-api.service';
import { CategoryApiService } from 'src/app/data/service/category-api.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  categories$!: Observable<Category[]>;
  articles$!: Observable<Article[]>;
  categorySelected = 1;

  constructor(private categoryApiService: CategoryApiService, private articleApiService: ArticleApiService) { }

  ngOnInit(): void {
    this.categories$ = this.categoryApiService.getCategories();
    this.articles$ = this.articleApiService.getArticles();
  }

}
