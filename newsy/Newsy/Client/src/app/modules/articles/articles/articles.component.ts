import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/data/schema/Category';
import { CategoryApiService } from 'src/app/data/service/category-api.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  categories$!: Observable<Category[]>;

  constructor(private categoryApiService: CategoryApiService) { }

  ngOnInit(): void {
    this.categories$ = this.categoryApiService.getCategories();
  }

}
