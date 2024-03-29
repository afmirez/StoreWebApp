import { Component, OnInit } from '@angular/core';
import { LayoutService } from '@services/layout/layout.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(
    private layoutService: LayoutService
  ){}

  public ngOnInit(): void {
   this.layoutService.theme$.subscribe((theme) => {
    document.body.className = theme;
   });
  }
}
