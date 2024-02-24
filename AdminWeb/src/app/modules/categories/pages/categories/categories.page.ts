import { Component, ElementRef, ViewChild  } from '@angular/core';
import { CategoryApi } from 'src/app/api/category/category.api'; 
import { Category } from 'src/app/api/category/category.model'; 
import { CategoryState } from 'src/app/api/category/categoryState/categoryState.model';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.page.html',
  styleUrls: ['./categories.page.css']
})

export class CategoriesPage {
  @ViewChild("modal") modal: ElementRef

  public categories: Category[] =[];

  public categoryVariable: Category = new Category();

  constructor(
    private categoryAPI: CategoryApi) { 
  
  }
  
  public ngOnInit(): void {
    this.categoryAPI.GetCategories().subscribe(result=>{
    this.categories= result.data.map((order: any)=>new Category(order));
    console.log(this.categories);
    })
  }

  public openModal(){
    this.modal.nativeElement.classList.add("open")
  }
  
  public closeModal(){
    this.modal.nativeElement.classList.remove("open")
  }

  @ViewChild("edit") edit: ElementRef

  public openEdit(){
    this.edit.nativeElement.classList.add("open")
  }
  
  public closeEdit(){
    this.edit.nativeElement.classList.remove("open")
  }

  public createCategory(): void {
    this.categoryAPI.CreateCategory(this.categoryVariable).subscribe({
      next: (response) => {
        console.log('Response:', response);
        if(!response.success){
          alert(response.messages.join('\n'));
        }
        else{
    
        }      
      }
    });
  }

  // public updateTask(): void {
  //   this.categoryAPI.UpdateCategory(this.categoryVariable, this.categoryVariable.id).subscribe({
  //     next: (response) => {
  //     console.log('Response:', response);

  //     if(!response.success){
  //       alert(response.messages.join('\n'));
  //     }
  //     else{
  //       this.closeModal('Edit Category');
  //     }}      
  //   });
  // }
}
