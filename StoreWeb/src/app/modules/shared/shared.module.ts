import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayout } from './layout/main/main.layout';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MainLayout
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class SharedModule { }
