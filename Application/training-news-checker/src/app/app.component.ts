import { Component } from '@angular/core';
import { HeaderComponent} from "./header/header.component";
import { NewsContainerComponent } from "./news-container/news-container.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ HeaderComponent, NewsContainerComponent ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {}
