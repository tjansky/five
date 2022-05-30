import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ArticleCardComponent } from './component/article-card/article-card.component';



@NgModule({
  declarations: [
    ArticleCardComponent
  ],
  imports: [
    TooltipModule.forRoot(),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    TooltipModule,
    ArticleCardComponent
  ]
})
export class SharedModule { }
