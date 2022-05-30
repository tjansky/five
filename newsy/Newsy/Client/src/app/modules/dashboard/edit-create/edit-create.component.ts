import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleApiService } from 'src/app/data/service/article-api.service';

@Component({
  selector: 'app-edit-create',
  templateUrl: './edit-create.component.html',
  styleUrls: ['./edit-create.component.css']
})
export class EditCreateComponent implements OnInit {
  editCreateForm!: FormGroup;
  isCreate!: boolean;
  articleId!: number;
  
  constructor(private articleApiService: ArticleApiService, 
              private route: ActivatedRoute, 
              private router: Router) { }

  ngOnInit(): void {
    this.router.url.includes('create') ? this.isCreate = true : this.isCreate = false;

    if(!this.isCreate) {
      this.articleId = Number(this.route.snapshot.paramMap.get('id'));
      this.articleApiService.getArticleById(this.articleId).subscribe(a => {
        console.log(a);
        this.editCreateForm.patchValue(a);
      });
    }

    this.editCreateForm = new FormGroup({
      title: new FormControl(''),
      content: new FormControl(''),
      categoryId: new FormControl()
    })
  }

  onSubmit(form: FormGroup) {
    const data = form.value;
    if(this.isCreate) {
      this.articleApiService.createArticle(data.title, data.content, data.categoryId).subscribe(a => {
        this.router.navigate(['/articles']);
      });
    } else {
      this.articleApiService.updateArticle(this.articleId, data.title, data.content, data.categoryId).subscribe(a => {
        this.router.navigate(['/articles']);
      });
    }
  }


}
