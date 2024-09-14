import { Component } from '@angular/core';
import { NewsComponent } from "../news/news.component";

@Component({
  selector: 'app-news-container',
  standalone: true,
  imports: [ NewsComponent ],
  templateUrl: './news-container.component.html',
  styleUrl: './news-container.component.css'
})
export class NewsContainerComponent{}
