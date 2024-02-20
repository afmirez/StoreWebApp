import { Component, ElementRef, ViewChild  } from '@angular/core';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.page.html',
  styleUrls: ['./categories.page.css']
})
export class CategoriesPage {
  @ViewChild("modal") modal: ElementRef

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
}
