import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from 'src/app/data/schema/Article';
import { ArticleApiService } from 'src/app/data/service/article-api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private articleApiService: ArticleApiService) { }
  articles$!: Observable<Article[]>;

  ngOnInit(): void {
    this.articles$ = this.articleApiService.getArticlesFromCurrentAuthor();
  }

}
